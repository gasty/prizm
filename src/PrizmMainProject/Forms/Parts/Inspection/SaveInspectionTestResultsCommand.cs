﻿using DevExpress.Mvvm.DataAnnotations;
using Prizm.Data.DAL;
using Prizm.Domain.Entity.Construction;
using Prizm.Main.Commands;
using Prizm.Main.Properties;
using Prizm.Main.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Prizm.Main.Forms.Parts.Inspection
{
    public class SaveInspectionTestResultsCommand : ICommand
    {
        private readonly IInspectionTestResultRepository repo;
        private readonly PartInspectionViewModel viewModel;
        private readonly IUserNotify notify;
        ISecurityContext ctx = Program.Kernel.Get<ISecurityContext>();

        public SaveInspectionTestResultsCommand(IInspectionTestResultRepository repo, PartInspectionViewModel viewModel, IUserNotify notify)
        {
            this.repo = repo;
            this.viewModel = viewModel;
            this.notify = notify;
        }

        [Command(UseCommandManager = false)]
        public void Execute()
        {
            try
            {
                repo.BeginTransaction();
                foreach (InspectionTestResult itr in viewModel.InspectionTestResults)
                {
                    repo.SaveOrUpdate(itr);
                }
                repo.Commit();
                foreach (InspectionTestResult itr in viewModel.InspectionTestResults)
                {
                    repo.Evict(itr);
                }
                notify.ShowNotify(string.Concat(Resources.DLG_INSPECTIONS_SAVED, viewModel.SelectedElement.Number), Resources.DLG_INSPECTIONS_SAVED_HEADER);
            }
            catch (RepositoryException ex)
            {
                notify.ShowFailure(ex.InnerException.Message, ex.Message);
            }
        }
        public virtual bool IsExecutable { get; set; }
        public bool CanExecute()
        {
            return (viewModel.InspectionTestResults != null && ctx.HasAccess(global::Domain.Entity.Security.Privileges.EditData));
        }
    }
}