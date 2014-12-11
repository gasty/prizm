﻿using Domain.Entity.Setup;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Mapping
{
    public class JointOperationMap : SubclassMap<JointOperation>
    {
        public JointOperationMap() 
        {
            Map(_ => _.Name, "Name");
            Map(_ => _.IsRequired, "isRequired");
            Map(_ => _.IsTest, "isTest");
            Map(_ => _.TestHasAccepted, "testHasAccepted");
            Map(_ => _.TestHasToRepair, "testHasToRepair");
            Map(_ => _.TestHasToWithdraw, "testHasToWithdraw");
            Map(_ => _.TestResultRequired, "testResultRequired");
        }
    }
}