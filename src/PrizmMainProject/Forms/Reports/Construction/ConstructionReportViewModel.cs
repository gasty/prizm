﻿using Prizm.Data.DAL;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraReports.UI;
using Prizm.Domain.Entity.Construction;
using NHibernate;
using Ninject;
using Prizm.Main.Commands;
using Prizm.Main.Forms.Common;
using Prizm.Main.Forms.Parts.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prizm.Data.DAL.Construction;

using construct = Prizm.Domain.Entity.Construction;
using System.Data;
using Prizm.Main.Properties;
using Prizm.Data.DAL.ADO;
using Prizm.Main.Common;

namespace Prizm.Main.Forms.Reports.Construction
{
    public class ConstructionReportViewModel : ViewModelBase
    {
        private readonly IMillReportsRepository repo;
        private readonly IUserNotify notify;

        private readonly CreateReportCommand createCommand;
        private readonly PreviewReportCommand previewCommand;
        private readonly ReportCommand reportCommand;

        private DataTable data;
        private construct.Joint startJoint;
        private construct.Joint endJoint;
        private EnumWrapper<ReportType> reportType;
        private IList<PartData> partDataList;

        public int startPK;
        public int endPK;

        public object previewSource;
        public BindingList <PartType> selectedTypes;
        public XtraReport report;
        public BindingList<int> AllKP { get; set; }

        public IList<construct.Joint> Joints { get; set; }


        [Inject]
        public ConstructionReportViewModel(
            IMillReportsRepository repo, 
            IJointRepository repoJoint, 
            IUserNotify notify)
        {
            this.repo = repo;
            this.notify = notify;

            this.data = repo.GetPipelineElements(SQLQueryString.GetWeldedParts);
            this.partDataList = FormWeldedParts(data);

            this.Joints = repoJoint.GetAll();

            createCommand = ViewModelSource
                .Create<CreateReportCommand>(() => new CreateReportCommand(this, repo, notify));

            previewCommand = ViewModelSource
                .Create<PreviewReportCommand>(() => new PreviewReportCommand(this, repo, notify));

            reportCommand = ViewModelSource
                .Create<ReportCommand>(() => new ReportCommand(this, repo, notify));

        }


        public void LoadData()
        {
            AllKP = repo.GetAllKP();
        }

        private BindingList<Part> parts = new BindingList<Part>();
        public BindingList<Part> Parts
        {
            get { return parts; }
            set
            {
                if (value != parts)
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
                if (value != types)
                {
                    types = value;
                    RaisePropertyChanged("Types");
                }
            }
        }

        public int StartPK
        {
            get
            {
                return startPK;
            }
            set
            {
                if (value != startPK)
                {
                    startPK = value;
                    RaisePropertyChanged("StartPK");
                }
            }
        }

        public int EndPK
        {
            get
            {
                return endPK;
            }
            set
            {
                if (value != endPK)
                {
                    endPK = value;
                    RaisePropertyChanged("EndPK");
                }
            }
        }

        public object PreviewSource
        {
            get
            {
                return previewSource;
            }
            set
            {
                if (value != previewSource)
                {
                    previewSource = value;
                    RaisePropertyChanged("PreviewSource");
                }
            }
        }

        public construct.Joint StartJoint
        {
            get
            {
                return startJoint;
            }
            set
            {
                if (value != startJoint)
                {
                    startJoint = value;
                    RaisePropertyChanged("StartJoint");
                }
            }
        }

        public construct.Joint EndJoint
        {
            get
            {
                return endJoint;
            }
            set
            {
                if (value != endJoint)
                {
                    endJoint = value;
                    RaisePropertyChanged("EndJoint");
                }
            }
        }

        public EnumWrapper<ReportType> ReportType
        {
            get { return reportType; }
            set
            {
                if (value != reportType)
                {
                    reportType = value;
                    RaisePropertyChanged("ReportType");
                }
            }
        }

        public ICommand CreateCommand
        {
            get
            {
                return createCommand;
            }
        }

        public ICommand PreviewCommand
        {
            get 
            { 
                return previewCommand; 
            }
        }

        public ICommand ReportCommand
        {
            get
            {
                return reportCommand;
            }
        }

        public IList<PartData> PartDataList 
        {
            get
            {
                return partDataList;
            }
            set
            {
                if (value != partDataList)
                {
                    partDataList = value;
                    RaisePropertyChanged("PartDataList");
                }
            }
        }

        private IList<PartData> FormWeldedParts(DataTable dataTable)
        {
            List<PartData> list = new List<PartData>();

            dataTable.Columns.Add("typeTranslated", typeof(String));

            foreach (DataRow row in dataTable.Rows)
            {
                if (row.Field<string>("type") != "Component")
                {
                    row.SetField(
                        "typeTranslated",
                        Resources.ResourceManager.GetString(row.Field<string>("type")));
                }
                else
                {
                    row.SetField(
                        "typeTranslated",
                        row.Field<string>("componentTypeName"));
                }

                PartData p = new PartData()
                {
                    Id = row.Field<Guid>("id"),
                    Number = row.Field<string>("number"),
                    PartType = (PartType)Enum.Parse(typeof(PartType), row.Field<string>("type")),
                    Length = row.Field<int>("length"),
                    PartTypeDescription = row.Field<string>("typeTranslated")
                };

                list.Add(p);
            }

            return list;
        }
    }
}
