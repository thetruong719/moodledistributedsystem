namespace unzipPackage.QL
{
    partial class XtraForm_mdl_user
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btncapnhat = new DevExpress.XtraEditors.SimpleButton();
            this.btnxem = new DevExpress.XtraEditors.SimpleButton();
            this.lblChon = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gribang = new DevExpress.XtraGrid.GridControl();
            this.grichon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.auth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.confirmed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.policyagreed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.suspended = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mnethostid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.username = new DevExpress.XtraGrid.Columns.GridColumn();
            this.password = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idnumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.firstname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lastname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.email = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gribang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grichon)).BeginInit();
            this.SuspendLayout();
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
            this.panelControl2.Size = new System.Drawing.Size(822, 95);
            this.panelControl2.TabIndex = 31;
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
            // gribang
            // 
            this.gribang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gribang.Location = new System.Drawing.Point(12, 113);
            this.gribang.MainView = this.grichon;
            this.gribang.Name = "gribang";
            this.gribang.Size = new System.Drawing.Size(822, 281);
            this.gribang.TabIndex = 32;
            this.gribang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grichon});
            // 
            // grichon
            // 
            this.grichon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.auth,
            this.confirmed,
            this.policyagreed,
            this.deleted,
            this.suspended,
            this.Color,
            this.mnethostid,
            this.username,
            this.password,
            this.idnumber,
            this.firstname,
            this.lastname,
            this.email});
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
            // auth
            // 
            this.auth.Caption = "auth";
            this.auth.FieldName = "auth";
            this.auth.Name = "auth";
            this.auth.OptionsColumn.ReadOnly = true;
            this.auth.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MaKH", "{0}")});
            this.auth.Visible = true;
            this.auth.VisibleIndex = 1;
            this.auth.Width = 95;
            // 
            // confirmed
            // 
            this.confirmed.Caption = "confirmed";
            this.confirmed.FieldName = "confirmed";
            this.confirmed.MinWidth = 40;
            this.confirmed.Name = "confirmed";
            this.confirmed.OptionsColumn.ReadOnly = true;
            this.confirmed.Visible = true;
            this.confirmed.VisibleIndex = 2;
            this.confirmed.Width = 92;
            // 
            // policyagreed
            // 
            this.policyagreed.Caption = "policyagreed";
            this.policyagreed.FieldName = "policyagreed";
            this.policyagreed.MinWidth = 40;
            this.policyagreed.Name = "policyagreed";
            this.policyagreed.OptionsColumn.ReadOnly = true;
            this.policyagreed.Visible = true;
            this.policyagreed.VisibleIndex = 3;
            this.policyagreed.Width = 100;
            // 
            // deleted
            // 
            this.deleted.Caption = "deleted";
            this.deleted.FieldName = "deleted";
            this.deleted.Name = "deleted";
            this.deleted.Visible = true;
            this.deleted.VisibleIndex = 4;
            this.deleted.Width = 120;
            // 
            // suspended
            // 
            this.suspended.Caption = "suspended";
            this.suspended.FieldName = "suspended";
            this.suspended.Name = "suspended";
            this.suspended.Visible = true;
            this.suspended.VisibleIndex = 5;
            this.suspended.Width = 153;
            // 
            // Color
            // 
            this.Color.Caption = "Color";
            this.Color.FieldName = "Color";
            this.Color.Name = "Color";
            // 
            // mnethostid
            // 
            this.mnethostid.Caption = "mnethostid";
            this.mnethostid.FieldName = "mnethostid";
            this.mnethostid.Name = "mnethostid";
            this.mnethostid.Visible = true;
            this.mnethostid.VisibleIndex = 6;
            // 
            // username
            // 
            this.username.Caption = "username";
            this.username.FieldName = "username";
            this.username.Name = "username";
            this.username.Visible = true;
            this.username.VisibleIndex = 7;
            // 
            // password
            // 
            this.password.Caption = "password";
            this.password.FieldName = "password";
            this.password.Name = "password";
            this.password.Visible = true;
            this.password.VisibleIndex = 8;
            // 
            // idnumber
            // 
            this.idnumber.Caption = "idnumber";
            this.idnumber.FieldName = "idnumber";
            this.idnumber.Name = "idnumber";
            this.idnumber.Visible = true;
            this.idnumber.VisibleIndex = 9;
            // 
            // firstname
            // 
            this.firstname.Caption = "firstname";
            this.firstname.FieldName = "firstname";
            this.firstname.Name = "firstname";
            this.firstname.Visible = true;
            this.firstname.VisibleIndex = 10;
            // 
            // lastname
            // 
            this.lastname.Caption = "lastname";
            this.lastname.FieldName = "lastname";
            this.lastname.Name = "lastname";
            this.lastname.Visible = true;
            this.lastname.VisibleIndex = 11;
            // 
            // email
            // 
            this.email.Caption = "email";
            this.email.FieldName = "email";
            this.email.Name = "email";
            this.email.Visible = true;
            this.email.VisibleIndex = 12;
            // 
            // XtraForm_mdl_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 406);
            this.Controls.Add(this.gribang);
            this.Controls.Add(this.panelControl2);
            this.Name = "XtraForm_mdl_user";
            this.Text = "XtraForm_mdl_user";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gribang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grichon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btncapnhat;
        private DevExpress.XtraEditors.SimpleButton btnxem;
        private DevExpress.XtraEditors.LabelControl lblChon;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gribang;
        private DevExpress.XtraGrid.Views.Grid.GridView grichon;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn auth;
        private DevExpress.XtraGrid.Columns.GridColumn confirmed;
        private DevExpress.XtraGrid.Columns.GridColumn policyagreed;
        private DevExpress.XtraGrid.Columns.GridColumn deleted;
        private DevExpress.XtraGrid.Columns.GridColumn suspended;
        private DevExpress.XtraGrid.Columns.GridColumn Color;
        private DevExpress.XtraGrid.Columns.GridColumn mnethostid;
        private DevExpress.XtraGrid.Columns.GridColumn username;
        private DevExpress.XtraGrid.Columns.GridColumn password;
        private DevExpress.XtraGrid.Columns.GridColumn idnumber;
        private DevExpress.XtraGrid.Columns.GridColumn firstname;
        private DevExpress.XtraGrid.Columns.GridColumn lastname;
        private DevExpress.XtraGrid.Columns.GridColumn email;
    }
}