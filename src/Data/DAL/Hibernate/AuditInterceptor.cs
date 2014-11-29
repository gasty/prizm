﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Ninject;
using Domain.Entity;

namespace Data.DAL.Hibernate
{
    [Serializable]
    public class AuditInterceptor : EmptyInterceptor
    {
        private readonly IAuditLogRepository repo;

        [Inject]
        public AuditInterceptor()
        {
            repo = new AuditLogRepository(HibernateUtil.OpenAuditSession());
        }
        enum Actions { Insert, Delete };

        /// <summary>
        /// Is called while inserting new record
        /// </summary>
        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            LogAudit(entity, propertyNames, Actions.Insert, state);
            return base.OnSave(entity, id, state, propertyNames, types);
        }

        /// <summary>
        /// Is called while updating existing record
        /// </summary>
        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            if (previousState == null) return false;
            var curentity = entity as Item;
            if (curentity != null)
            {
                for (var i = 0; i < currentState.Count(); i++)
                {
                    if (currentState[i] == null && previousState[i] == null) continue; // prevent exeption 
                    else if (currentState[i] == null || previousState[i] == null) //prevent exeption
                    {
                        string newValue = (currentState[i] == null) ? "" : currentState[i].ToString();
                        string oldValue = (previousState[i] == null || previousState == null) ? "" : previousState[i].ToString();
                        NewAuditRecord(curentity, propertyNames[i], newValue, oldValue);

                    }
                    else if (currentState[i] as Item == null && currentState[i].ToString() != previousState[i].ToString())
                    {
                        NewAuditRecord(curentity, propertyNames[i], currentState[i].ToString(), previousState[i].ToString());
                    }
                    else
                    {
                        var objectProperty = currentState[i] as Item;
                        if (objectProperty!=null && currentState[i].Equals(previousState[i]) == false)
                        { NewAuditRecord(curentity, propertyNames[i], objectProperty.Id.ToString(), objectProperty.Id.ToString()); }
                    }
                }
            }
         return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);                 
        }

        /// <summary>
        /// Creating log record and saving it to DB
        /// </summary>
        private void NewAuditRecord(Item curentity, string fieldName, string newValue, string oldValue )
        {
            AuditLog record = new AuditLog()
            {
                AuditID = Guid.NewGuid(),
                EntityID = curentity.Id,
                AuditDate = DateTime.Now,
                User = curentity.GetUser(),
                TableName = curentity.GetType().ToString(),
                FieldName = fieldName,
                NewValue = newValue,
                OldValue = oldValue
            };
            repo.BeginTransaction();
            repo.Save(record);
            repo.Commit();   
        }

        /// <summary>
        /// Is called whilr deleting record
        /// </summary>
        public override void OnDelete(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            LogAudit(entity, propertyNames, Actions.Delete, state);
            base.OnDelete(entity, id, state, propertyNames, types);
        }

        /// <summary>
        /// Log  insert/delete record (just one state)
        /// </summary>
        private  void LogAudit(object entity, string[] propertyNames, Actions actionType, params object[] state)
        {
            string oldValue = "just inserted", newValue = "";
            var curentity = entity as Item;
            if (curentity != null)
            {
                for (var i = 0; i < propertyNames.Count(); i++)
                {
                    if (state[i] == null) continue;
                    var objectProperty = state[i] as Item;
                    switch (actionType)
                    {
                        case Actions.Insert: newValue = (objectProperty ==null)? state[i].ToString(): objectProperty.Id.ToString();
                            break;
                        case Actions.Delete: oldValue = (objectProperty == null) ? state[i].ToString() : objectProperty.Id.ToString();
                            newValue = "deleted";
                            break;
                        default: break;
                    }
                    NewAuditRecord(curentity, propertyNames[i], newValue, oldValue);
                }
            }
        }
    }
}