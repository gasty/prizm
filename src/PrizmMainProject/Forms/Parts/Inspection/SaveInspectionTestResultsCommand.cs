﻿using DevExpress.Mvvm.DataAnnotations;
using Prizm.Data.DAL;
using Prizm.Domain.Entity.Construction;
using Prizm.Main.Commands;
using Prizm.Main.Common;
using Prizm.Main.Properties;
using Prizm.Main.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Prizm.Main.Languages;

namespace Prizm.Main.Forms.Parts.Inspection
{
    public class SaveInspectionTestResultsCommand : ICommand
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SaveInspectionTestResultsCommand));

        private readonly IInspectionTestResultRepository repo;
        private readonly PartInspectionViewModel viewModel;
        private readonly IUserNotify notify;
        private readonly ISecurityContext ctx;
        private int numberOfOperationWithoutInspectors = 0;
        public event RefreshVisualStateEventHandler RefreshVisualStateEvent = delegate { };

        public SaveInspectionTestResultsCommand(IInspectionTestResultRepository repo, PartInspectionViewModel viewModel, IUserNotify notify, ISecurityContext ctx)
        {
            this.repo = repo;
            this.viewModel = viewModel;
            this.notify = notify;
            this.ctx = ctx;
        }

        [Command(UseCommandManager = false)]
        public void Execute()
        {
            if(!viewModel.InspectionTestResults.All(x => x.Date.IsValid()))
            {
                notify.ShowInfo(Program.LanguageManager.GetString(StringResources.WrongDate),
                    Program.LanguageManager.GetString(StringResources.Message_ErrorHeader));
                log.Warn("Date limits not valid!");
                return;
            }

            foreach (InspectionTestResult t in viewModel.InspectionTestResults)
            {
                if (t.Status != PartInspectionStatus.Pending && t.Inspectors.Count <= 0)
                {
                    numberOfOperationWithoutInspectors++;
                }
            }
            if (numberOfOperationWithoutInspectors==0)
            {
                try
                {
                    viewModel.ConvertedPart.InspectionStatus = viewModel.ConvertedPart.GetPartInspectionStatus();
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
                    notify.ShowNotify(string.Concat(Program.LanguageManager.GetString(StringResources.PartInspection_InspectionsSaved), viewModel.SelectedElement.Number), Program.LanguageManager.GetString(StringResources.PartInspection_InspectionsSavedHeader));

                    log.Info(string.Format("The Inspection Test Results for entity #{0}, id:{1} has been saved in DB.",
                        viewModel.SelectedElement.Number,
                        viewModel.SelectedElement.Id));
                }
                catch (RepositoryException ex)
                {
                    log.Error(ex.Message);
                    notify.ShowFailure(ex.InnerException.Message, ex.Message);
                }
                RefreshVisualStateEvent();
            }
            else 
            {
                notify.ShowError(
                    Program.LanguageManager.GetString(StringResources.SelectInspectorsForTestResult),
                    Program.LanguageManager.GetString(StringResources.SelectInspectorsForTestResultHeader));
                numberOfOperationWithoutInspectors = 0;
            }
        }

        public bool CanExecute()
        {
            return (viewModel.InspectionTestResults != null && ctx.HasAccess(global::Domain.Entity.Security.Privileges.PartsInspection));
        }
    }
}
