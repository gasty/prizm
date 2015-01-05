﻿using System;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

using Prizm.Main.Forms.MainChildForm;
using Prizm.Main.Common;
using System.Windows.Forms;
using Prizm.Main.Forms.Common;
using System.ComponentModel;
using Prizm.Domain.Entity.Construction;
using Prizm.Main.Commands;
using Prizm.Main.Properties;


using construct = Prizm.Domain.Entity.Construction;

namespace Prizm.Main.Forms.Reports.Construction
{
    [System.ComponentModel.DesignerCategory("Form")] 
    public partial class ConstructionReportsXtraForm : ChildForm
    {
        private ConstructionReportViewModel viewModel;
        private ICommandManager commandManager = new CommandManager();

        public ConstructionReportsXtraForm()
        {
            InitializeComponent();
            typeLayout.ContentVisible = false;
            start.SetRequiredText();
            end.SetRequiredText();
        }

        private void BindToViewModel()
        {
            bindingSource.DataSource = viewModel;
            previewReportDocument.DataBindings.Add("DocumentSource", bindingSource, "PreviewSource");
            reportType.DataBindings.Add("EditValue", bindingSource, "ReportType");
            viewModel.LoadData();

            start.DataBindings.Add("EditValue", bindingSource, "StartJoint");
            end.DataBindings.Add("EditValue", bindingSource, "EndJoint");
            startKPComboBox.DataBindings.Add("EditValue", bindingSource, "StartPK");
            endKPComboBox.DataBindings.Add("EditValue", bindingSource, "EndPK");
        }

        private void BindCommands()
        {
            commandManager["CreateReport"]
                .Executor(viewModel.CreateCommand).AttachTo(createReportButton);

            commandManager["PreviewButton"]
                .Executor(viewModel.PreviewCommand).AttachTo(previewButton);
        }

        private void RefreshTypes()
        {
            BindingList<PartType> selectedTypes = new BindingList<PartType>();
            for (int i = 0; i < type.Properties.Items.Count; i++)
            {
                if (type.Properties.Items[i].CheckState == CheckState.Checked)
                {
                    selectedTypes.Add((PartType)type.Properties.Items[i].Value);
                }
            }
            viewModel.Types.Clear();
            viewModel.Types = selectedTypes;
        }

        private void ConstructionReportsXtraForm_Load(object sender, EventArgs e)
        {
            viewModel = (ConstructionReportViewModel)Program.Kernel.GetService(typeof(ConstructionReportViewModel));
            BindToViewModel();
            BindCommands();

            var pipeCheck = new EnumWrapper<PartType> { Value = PartType.Pipe };
            var spoolCheck = new EnumWrapper<PartType> { Value = PartType.Spool };
            var componentCheck = new EnumWrapper<PartType> { Value = PartType.Component };

            type.Properties.Items.Add(pipeCheck.Value, pipeCheck.Text, CheckState.Checked, true);
            type.Properties.Items.Add(spoolCheck.Value, spoolCheck.Text, CheckState.Checked, true);
            type.Properties.Items.Add(componentCheck.Value, componentCheck.Text, CheckState.Checked, true);


            var usedProduct = new EnumWrapper<ReportType> { Value = ReportType.UsedProductReport };
            var length = new EnumWrapper<ReportType> { Value = ReportType.PipelineLengthReport };
            var highway = new EnumWrapper<ReportType> { Value = ReportType.HighwayReport };

            reportType.Properties.Items.Add(usedProduct);
            reportType.Properties.Items.Add(length);
            reportType.Properties.Items.Add(highway);

            foreach (var joint in viewModel.Joints)
            {
                start.Properties.Items.Add(joint);
                end.Properties.Items.Add(joint);
            }

            RefreshTypes();
            reportType.SelectedIndex = 0;
        }

        private void reportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportType.SelectedItem.ToString() == Resources.UsedProductReport)
            {
                viewModel.report = new UsedProductsXtraReport();
                typeLayout.ContentVisible = true;
            }
            else
            {
                viewModel.report = new TracingReporn();
                typeLayout.ContentVisible = false;
            }
        }

        private void createReportButton_Click(object sender, EventArgs e)
        {
            RefreshTypes();
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            RefreshTypes();
        }

        private void ConstructionReportsXtraForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            commandManager.Dispose();
            viewModel = null;
        }


        private void reportType_EditValueChanged(object sender, EventArgs e)
        {
            viewModel.ReportType = reportType.EditValue as EnumWrapper<ReportType>;
            commandManager["PreviewButton"].RefreshState();
            commandManager["CreateReport"].RefreshState();
        }

        private void start_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.StartJoint = start.EditValue as construct.Joint;
            commandManager["PreviewButton"].RefreshState();
            commandManager["CreateReport"].RefreshState();
        }

        private void end_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewModel.EndJoint = start.EditValue as construct.Joint;
            commandManager["PreviewButton"].RefreshState();
            commandManager["CreateReport"].RefreshState();
        }


    }
}