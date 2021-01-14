namespace unzipPackage.QL
{
    partial class XtraForm_mdl_groups
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.gribang = new DevExpress.XtraGrid.GridControl();
            this.grichon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.courseid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idnumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descriptionformat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.enrolmentkey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.picture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hidepicture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timecreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timemodified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btncapnhat = new DevExpress.XtraEditors.SimpleButton();
            this.btnxem = new DevExpress.XtraEditors.SimpleButton();
            this.lblChon = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gribang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grichon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gribang
            // 
            this.gribang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gribang.Location = new System.Drawing.Point(12, 113);
            this.gribang.MainView = this.grichon;
            this.gribang.Name = "gribang";
            this.gribang.Size = new System.Drawing.Size(715, 270);
            this.gribang.TabIndex = 34;
            this.gribang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grichon});
            // 
            // grichon
            // 
            this.grichon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.courseid,
            this.idnumber,
            this.name,
            this.description,
            this.descriptionformat,
            this.enrolmentkey,
            this.Color,
            this.picture,
            this.hidepicture,
            this.timecreated,
            this.timemodified});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Color";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Expression = "[Color] = 1";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "trungthongtin";
            formatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.Red;
            formatConditionRuleExpression2.Appearance.BackColor2 = System.Drawing.Color.Red;
            formatConditionRuleExpression2.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression2.Expression = "[Repeat] > 1";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.grichon.FormatRules.Add(gridFormatRule1);
            this.grichon.FormatRules.Add(gridFormatRule2);
            this.grichon.GridControl = this.gribang;
            this.grichon.Name = "grichon";
            this.grichon.OptionsBehavior.Editable = false;
            this.grichon.OptionsSelection.MultiSelect = true;
            this.grichon.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grichon.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.grichon.OptionsView.ColumnAutoWidth = false;
            this.grichon.OptionsView.RowAutoHeight = true;
            this.grichon.OptionsView.ShowFooter = true;
            this.grichon.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.AppearanceCell.Options.UseTextOptions = true;
            this.id.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.OptionsColumn.ReadOnly = true;
            this.id.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "id", "Tổng: ")});
            this.id.Visible = true;
            this.id.VisibleIndex = 0;
            this.id.Width = 54;
            // 
            // courseid
            // 
            this.courseid.Caption = "courseid";
            this.courseid.FieldName = "courseid";
            this.courseid.Name = "courseid";
            this.courseid.OptionsColumn.ReadOnly = true;
            this.courseid.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MaKH", "{0}")});
            this.courseid.Visible = true;
            this.courseid.VisibleIndex = 1;
            this.courseid.Width = 70;
            // 
            // idnumber
            // 
            this.idnumber.Caption = "idnumber";
            this.idnumber.FieldName = "idnumber";
            this.idnumber.Name = "idnumber";
            this.idnumber.Visible = true;
            this.idnumber.VisibleIndex = 9;
            // 
            // name
            // 
            this.name.Caption = "name";
            this.name.FieldName = "name";
            this.name.MinWidth = 40;
            this.name.Name = "name";
            this.name.OptionsColumn.ReadOnly = true;
            this.name.Visible = true;
            this.name.VisibleIndex = 2;
            this.name.Width = 222;
            // 
            // description
            // 
            this.description.Caption = "description";
            this.description.FieldName = "description";
            this.description.MinWidth = 40;
            this.description.Name = "description";
            this.description.OptionsColumn.ReadOnly = true;
            this.description.Visible = true;
            this.description.VisibleIndex = 3;
            this.description.Width = 100;
            // 
            // descriptionformat
            // 
            this.descriptionformat.Caption = "descriptionformat";
            this.descriptionformat.FieldName = "descriptionformat";
            this.descriptionformat.Name = "descriptionformat";
            this.descriptionformat.Visible = true;
            this.descriptionformat.VisibleIndex = 4;
            this.descriptionformat.Width = 120;
            // 
            // enrolmentkey
            // 
            this.enrolmentkey.Caption = "enrolmentkey";
            this.enrolmentkey.FieldName = "enrolmentkey";
            this.enrolmentkey.Name = "enrolmentkey";
            this.enrolmentkey.Visible = true;
            this.enrolmentkey.VisibleIndex = 5;
            this.enrolmentkey.Width = 153;
            // 
            // Color
            // 
            this.Color.Caption = "Color";
            this.Color.FieldName = "Color";
            this.Color.Name = "Color";
            // 
            // picture
            // 
            this.picture.Caption = "picture";
            this.picture.FieldName = "picture";
            this.picture.Name = "picture";
            this.picture.Visible = true;
            this.picture.VisibleIndex = 6;
            // 
            // hidepicture
            // 
            this.hidepicture.Caption = "hidepicture";
            this.hidepicture.FieldName = "hidepicture";
            this.hidepicture.Name = "hidepicture";
            this.hidepicture.Visible = true;
            this.hidepicture.VisibleIndex = 7;
            // 
            // timecreated
            // 
            this.timecreated.Caption = "timecreated";
            this.timecreated.FieldName = "timecreated";
            this.timecreated.Name = "timecreated";
            this.timecreated.Visible = true;
            this.timecreated.VisibleIndex = 8;
            // 
            // timemodified
            // 
            this.timemodified.Caption = "timemodified";
            this.timemodified.FieldName = "timemodified";
            this.timemodified.Name = "timemodified";
            this.timemodified.Visible = true;
            this.timemodified.VisibleIndex = 10;
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btncapnhat);
            this.panelControl2.Controls.Add(this.btnxem);
            this.panelControl2.Controls.Add(this.lblChon);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(12, 12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(715, 95);
            this.panelControl2.TabIndex = 33;
            // 
            // btncapnhat
            // 
            this.btncapnhat.ImageOptions.ImageIndex = 0;
            this.btncapnhat.Location = new System.Drawing.Point(556, 35);
            this.btncapnhat.Name = "btncapnhat";
            this.btncapnhat.Size = new System.Drawing.Size(100, 37);
            this.btncapnhat.TabIndex = 7;
            this.btncapnhat.Text = "Cập nhật";
            this.btncapnhat.Click += new System.EventHandler(this.btncapnhat_Click);
            // 
            // btnxem
            // 
            this.btnxem.ImageOptions.ImageIndex = 0;
            this.btnxem.Location = new System.Drawing.Point(450, 35);
            this.btnxem.Name = "btnxem";
            this.btnxem.Size = new System.Drawing.Size(100, 37);
            this.btnxem.TabIndex = 6;
            this.btnxem.Text = "Xem";
            this.btnxem.Click += new System.EventHandler(this.btnxem_Click);
            // 
            // lblChon
            // 
            this.lblChon.AllowHtmlString = true;
            this.lblChon.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblChon.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblChon.Appearance.Options.UseFont = true;
            this.lblChon.Appearance.Options.UseForeColor = true;
            this.lblChon.Location = new System.Drawing.Point(71, 47);
            this.lblChon.Name = "lblChon";
            this.lblChon.Size = new System.Drawing.Size(73, 14);
            this.lblChon.TabIndex = 0;
            this.lblChon.Text = "Đang chọn:[]";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(4, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Danh sách";
            // 
            // XtraForm_mdl_groups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 395);
            this.Controls.Add(this.gribang);
            this.Controls.Add(this.panelControl2);
            this.Name = "XtraForm_mdl_groups";
            this.Text = "XtraForm_mdl_groups";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gribang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grichon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gribang;
        private DevExpress.XtraGrid.Views.Grid.GridView grichon;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn courseid;
        private DevExpress.XtraGrid.Columns.GridColumn name;
        private DevExpress.XtraGrid.Columns.GridColumn description;
        private DevExpress.XtraGrid.Columns.GridColumn descriptionformat;
        private DevExpress.XtraGrid.Columns.GridColumn enrolmentkey;
        private DevExpress.XtraGrid.Columns.GridColumn Color;
        private DevExpress.XtraGrid.Columns.GridColumn picture;
        private DevExpress.XtraGrid.Columns.GridColumn hidepicture;
        private DevExpress.XtraGrid.Columns.GridColumn timecreated;
        private DevExpress.XtraGrid.Columns.GridColumn idnumber;
        private DevExpress.XtraGrid.Columns.GridColumn timemodified;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btncapnhat;
        private DevExpress.XtraEditors.SimpleButton btnxem;
        private DevExpress.XtraEditors.LabelControl lblChon;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}