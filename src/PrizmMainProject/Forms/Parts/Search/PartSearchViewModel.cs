﻿using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Prizm.Domain.Entity.Construction;
using NHibernate;
using Ninject;
using Prizm.Main.Commands;
using Prizm.Main.Forms.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prizm.Main.Properties;

namespace Prizm.Main.Forms.Parts.Search
{
    public class PartSearchViewModel : ViewModelBase, IDisposable
    {
        PartsSearchCommand searchCommand;
        ISession session;
        

        [Inject]
        public PartSearchViewModel(ISession session)
        {
            this.session = session;
            searchCommand = ViewModelSource.Create(() => new PartsSearchCommand(this, session));
            Activity = ActivityArray[0];
        }
        public string[] ActivityArray = { Resources.PipeStatusComboAll, Resources.PipeStatusComboActive, Resources.PipeStatusComboUnactive };

        private string activity;
        public string Activity
        {
            get { return activity; }
            set
            {
                if (value != activity)
                {
                    activity = value;
                    RaisePropertyChanged("Activity");
                }
            }
        }

        private string number = string.Empty;
        public string Number
        {
            get { return number; }
            set
            {
                if(value != number)
                {
                    number = value;
                    RaisePropertyChanged("Number");
                }
            }
        }

        private BindingList<Part> parts = new BindingList<Part>();
        public BindingList<Part> Parts 
        {
            get { return parts; }
            set
            {
                if(value != parts)
                {
                    parts = value;
                    RaisePropertyChanged("Parts");
                }
            }
        }

        private BindingList<PartType> types = new BindingList<PartType>();
        public BindingList<PartType> Types
        {
            get { return types; }
            set
            {
                if(value != types)
                {
                    types = value;
                    RaisePropertyChanged("Types");
                }
            }
        }

        public ICommand SearchCommand
        {
            get { return searchCommand; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            session.Dispose();
        }

        #endregion
    }
}
