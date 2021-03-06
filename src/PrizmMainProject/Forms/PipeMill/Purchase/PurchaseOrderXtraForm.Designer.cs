﻿namespace Prizm.Main.Forms.PipeMill
{
    partial class PurchaseOrderXtraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseOrderXtraForm));
            this.purchaseOrderLayout = new DevExpress.XtraLayout.LayoutControl();
            this.date = new DevExpress.XtraEditors.DateEdit();
            this.number = new DevExpress.XtraEditors.TextEdit();
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.purchaseOrderLayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.purchaseOrderNumberLayout = new DevExpress.XtraLayout.LayoutControlItem();
            this.purchaseOrderDateLayout = new DevExpress.XtraLayout.LayoutControlItem();
            this.saveButtonEmptySpace = new DevExpress.XtraLayout.EmptySpaceItem();
            this.generalEmptySpace = new DevExpress.XtraLayout.EmptySpaceItem();
            this.saveButtonLayoutControl = new DevExpress.XtraLayout.LayoutControlItem();
            this.canselLayoutControl = new DevExpress.XtraLayout.LayoutControlItem();
            this.bindingSource = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderLayout)).BeginInit();
            this.purchaseOrderLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderLayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderNumberLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderDateLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveButtonEmptySpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.generalEmptySpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveButtonLayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canselLayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // purchaseOrderLayout
            // 
            this.purchaseOrderLayout.Controls.Add(this.date);
            this.purchaseOrderLayout.Controls.Add(this.number);
            this.purchaseOrderLayout.Controls.Add(this.saveButton);
            this.purchaseOrderLayout.Controls.Add(this.cancelButton);
            this.purchaseOrderLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchaseOrderLayout.Location = new System.Drawing.Point(0, 0);
            this.purchaseOrderLayout.Name = "purchaseOrderLayout";
            this.purchaseOrderLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(694, 114, 250, 350);
            this.purchaseOrderLayout.Root = this.purchaseOrderLayoutGroup;
            this.purchaseOrderLayout.Size = new System.Drawing.Size(389, 116);
            this.purchaseOrderLayout.TabIndex = 0;
            this.purchaseOrderLayout.Text = "layoutControl1";
            // 
            // date
            // 
            this.date.EditValue = null;
            this.date.Location = new System.Drawing.Point(276, 33);
            this.date.Name = "date";
            this.date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date.Size = new System.Drawing.Size(96, 20);
            this.date.StyleController = this.purchaseOrderLayout;
            this.date.TabIndex = 5;
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(17, 33);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(245, 20);
            this.number.StyleController = this.purchaseOrderLayout;
            this.number.TabIndex = 4;
            // 
            // saveButton
            // 
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Location = new System.Drawing.Point(171, 81);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(89, 23);
            this.saveButton.StyleController = this.purchaseOrderLayout;
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "&Сохранить";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.Location = new System.Drawing.Point(278, 81);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(92, 23);
            this.cancelButton.StyleController = this.purchaseOrderLayout;
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "О&тменить";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // purchaseOrderLayoutGroup
            // 
            this.purchaseOrderLayoutGroup.CustomizationFormText = "purchaseOrderLayoutGroup";
            this.purchaseOrderLayoutGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.purchaseOrderLayoutGroup.GroupBordersVisible = false;
            this.purchaseOrderLayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.purchaseOrderNumberLayout,
            this.purchaseOrderDateLayout,
            this.saveButtonEmptySpace,
            this.saveButtonLayoutControl,
            this.canselLayoutControl,
            this.generalEmptySpace});
            this.purchaseOrderLayoutGroup.Location = new System.Drawing.Point(0, 0);
            this.purchaseOrderLayoutGroup.Name = "purchaseOrderLayoutGroup";
            this.purchaseOrderLayoutGroup.Size = new System.Drawing.Size(389, 116);
            this.purchaseOrderLayoutGroup.Text = "purchaseOrderLayoutGroup";
            this.purchaseOrderLayoutGroup.TextVisible = false;
            // 
            // purchaseOrderNumberLayout
            // 
            this.purchaseOrderNumberLayout.Control = this.number;
            this.purchaseOrderNumberLayout.CustomizationFormText = "Номер Наряд заказа";
            this.purchaseOrderNumberLayout.Location = new System.Drawing.Point(0, 0);
            this.purchaseOrderNumberLayout.Name = "purchaseOrderNumberLayout";
            this.purchaseOrderNumberLayout.Size = new System.Drawing.Size(259, 50);
            this.purchaseOrderNumberLayout.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.purchaseOrderNumberLayout.Text = "Ном&ер";
            this.purchaseOrderNumberLayout.TextLocation = DevExpress.Utils.Locations.Top;
            this.purchaseOrderNumberLayout.TextSize = new System.Drawing.Size(31, 13);
            // 
            // purchaseOrderDateLayout
            // 
            this.purchaseOrderDateLayout.Control = this.date;
            this.purchaseOrderDateLayout.CustomizationFormText = "Дата наряд-заказа";
            this.purchaseOrderDateLayout.Location = new System.Drawing.Point(259, 0);
            this.purchaseOrderDateLayout.Name = "purchaseOrderDateLayout";
            this.purchaseOrderDateLayout.Size = new System.Drawing.Size(110, 50);
            this.purchaseOrderDateLayout.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.purchaseOrderDateLayout.Text = "&Дата";
            this.purchaseOrderDateLayout.TextLocation = DevExpress.Utils.Locations.Top;
            this.purchaseOrderDateLayout.TextSize = new System.Drawing.Size(31, 13);
            // 
            // saveButtonEmptySpace
            // 
            this.saveButtonEmptySpace.AllowHotTrack = false;
            this.saveButtonEmptySpace.CustomizationFormText = "saveButtonEmptySpace";
            this.saveButtonEmptySpace.Location = new System.Drawing.Point(0, 69);
            this.saveButtonEmptySpace.Name = "saveButtonEmptySpace";
            this.saveButtonEmptySpace.Size = new System.Drawing.Size(159, 27);
            this.saveButtonEmptySpace.Text = "saveButtonEmptySpace";
            this.saveButtonEmptySpace.TextSize = new System.Drawing.Size(0, 0);
            // 
            // generalEmptySpace
            // 
            this.generalEmptySpace.AllowHotTrack = false;
            this.generalEmptySpace.CustomizationFormText = "generalEmptySpace";
            this.generalEmptySpace.Location = new System.Drawing.Point(0, 50);
            this.generalEmptySpace.Name = "generalEmptySpace";
            this.generalEmptySpace.Size = new System.Drawing.Size(369, 19);
            this.generalEmptySpace.Text = "generalEmptySpace";
            this.generalEmptySpace.TextSize = new System.Drawing.Size(0, 0);
            // 
            // saveButtonLayoutControl
            // 
            this.saveButtonLayoutControl.Control = this.saveButton;
            this.saveButtonLayoutControl.CustomizationFormText = "saveButtonLayoutControl";
            this.saveButtonLayoutControl.Location = new System.Drawing.Point(159, 69);
            this.saveButtonLayoutControl.MaxSize = new System.Drawing.Size(154, 31);
            this.saveButtonLayoutControl.MinSize = new System.Drawing.Size(70, 27);
            this.saveButtonLayoutControl.Name = "saveButtonLayoutControl";
            this.saveButtonLayoutControl.Size = new System.Drawing.Size(100, 27);
            this.saveButtonLayoutControl.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.saveButtonLayoutControl.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 7, 0, 0);
            this.saveButtonLayoutControl.Text = "saveButtonLayoutControl";
            this.saveButtonLayoutControl.TextSize = new System.Drawing.Size(0, 0);
            this.saveButtonLayoutControl.TextVisible = false;
            // 
            // canselLayoutControl
            // 
            this.canselLayoutControl.Control = this.cancelButton;
            this.canselLayoutControl.CustomizationFormText = "canselLayoutControl";
            this.canselLayoutControl.Location = new System.Drawing.Point(259, 69);
            this.canselLayoutControl.MaxSize = new System.Drawing.Size(154, 31);
            this.canselLayoutControl.MinSize = new System.Drawing.Size(70, 27);
            this.canselLayoutControl.Name = "canselLayoutControl";
            this.canselLayoutControl.Size = new System.Drawing.Size(110, 27);
            this.canselLayoutControl.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.canselLayoutControl.Spacing = new DevExpress.XtraLayout.Utils.Padding(7, 7, 0, 0);
            this.canselLayoutControl.Text = "canselLayoutControl";
            this.canselLayoutControl.TextSize = new System.Drawing.Size(0, 0);
            this.canselLayoutControl.TextVisible = false;
            // 
            // PurchaseOrderXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 116);
            this.Controls.Add(this.purchaseOrderLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PurchaseOrderXtraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Наряд-заказ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PurchaseOrderXtraForm_FormClosed);
            this.Load += new System.EventHandler(this.PurchaseOrderXtraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderLayout)).EndInit();
            this.purchaseOrderLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.date.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderLayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderNumberLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderDateLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveButtonEmptySpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.generalEmptySpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveButtonLayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canselLayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl purchaseOrderLayout;
        private DevExpress.XtraLayout.LayoutControlGroup purchaseOrderLayoutGroup;
        private DevExpress.XtraEditors.DateEdit date;
        private DevExpress.XtraEditors.TextEdit number;
        private DevExpress.XtraLayout.LayoutControlItem purchaseOrderNumberLayout;
        private DevExpress.XtraLayout.LayoutControlItem purchaseOrderDateLayout;
        private DevExpress.XtraLayout.EmptySpaceItem generalEmptySpace;
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraLayout.EmptySpaceItem saveButtonEmptySpace;
        private DevExpress.XtraLayout.LayoutControlItem saveButtonLayoutControl;
        private DevExpress.XtraLayout.LayoutControlItem canselLayoutControl;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}