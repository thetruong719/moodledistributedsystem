namespace unzipPackage.QL
{
    partial class XtraForm_quiz
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
            this.course = new DevExpress.XtraGrid.Columns.GridColumn();
            this.name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.intro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.introformat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timeopen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timelimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.overduehandling = new DevExpress.XtraGrid.Columns.GridColumn();
            this.graceperiod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.preferredbehaviour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.canredoquestions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.attempts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.attemptonlast = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.panelControl2.Size = new System.Drawing.Size(790, 95);
            this.panelControl2.TabIndex = 30;
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
            this.gribang.Size = new System.Drawing.Size(790, 280);
            this.gribang.TabIndex = 31;
            this.gribang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grichon});
            // 
            // grichon
            // 
            this.grichon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.course,
            this.name,
            this.intro,
            this.introformat,
            this.timeopen,
            this.Color,
            this.timelimit,
            this.overduehandling,
            this.graceperiod,
            this.preferredbehaviour,
            this.canredoquestions,
            this.attempts,
            this.attemptonlast});
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
            // course
            // 
            this.course.Caption = "course";
            this.course.FieldName = "course";
            this.course.Name = "course";
            this.course.OptionsColumn.ReadOnly = true;
            this.course.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MaKH", "{0}")});
            this.course.Visible = true;
            this.course.VisibleIndex = 1;
            this.course.Width = 95;
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
            this.name.Width = 92;
            // 
            // intro
            // 
            this.intro.Caption = "intro";
            this.intro.FieldName = "intro";
            this.intro.MinWidth = 40;
            this.intro.Name = "intro";
            this.intro.OptionsColumn.ReadOnly = true;
            this.intro.Visible = true;
            this.intro.VisibleIndex = 3;
            this.intro.Width = 100;
            // 
            // introformat
            // 
            this.introformat.Caption = "introformat";
            this.introformat.FieldName = "introformat";
            this.introformat.Name = "introformat";
            this.introformat.Visible = true;
            this.introformat.VisibleIndex = 4;
            this.introformat.Width = 120;
            // 
            // timeopen
            // 
            this.timeopen.Caption = "timeopen";
            this.timeopen.FieldName = "timeopen";
            this.timeopen.Name = "timeopen";
            this.timeopen.Visible = true;
            this.timeopen.VisibleIndex = 5;
            this.timeopen.Width = 153;
            // 
            // Color
            // 
            this.Color.Caption = "Color";
            this.Color.FieldName = "Color";
            this.Color.Name = "Color";
            // 
            // timelimit
            // 
            this.timelimit.Caption = "timelimit";
            this.timelimit.FieldName = "timelimit";
            this.timelimit.Name = "timelimit";
            this.timelimit.Visible = true;
            this.timelimit.VisibleIndex = 6;
            // 
            // overduehandling
            // 
            this.overduehandling.Caption = "overduehandling";
            this.overduehandling.FieldName = "overduehandling";
            this.overduehandling.Name = "overduehandling";
            this.overduehandling.Visible = true;
            this.overduehandling.VisibleIndex = 7;
            // 
            // graceperiod
            // 
            this.graceperiod.Caption = "graceperiod";
            this.graceperiod.FieldName = "graceperiod";
            this.graceperiod.Name = "graceperiod";
            this.graceperiod.Visible = true;
            this.graceperiod.VisibleIndex = 8;
            // 
            // preferredbehaviour
            // 
            this.preferredbehaviour.Caption = "preferredbehaviour";
            this.preferredbehaviour.FieldName = "preferredbehaviour";
            this.preferredbehaviour.Name = "preferredbehaviour";
            this.preferredbehaviour.Visible = true;
            this.preferredbehaviour.VisibleIndex = 9;
            // 
            // canredoquestions
            // 
            this.canredoquestions.Caption = "canredoquestions";
            this.canredoquestions.FieldName = "canredoquestions";
            this.canredoquestions.Name = "canredoquestions";
            this.canredoquestions.Visible = true;
            this.canredoquestions.VisibleIndex = 10;
            // 
            // attempts
            // 
            this.attempts.Caption = "attempts";
            this.attempts.FieldName = "attempts";
            this.attempts.Name = "attempts";
            this.attempts.Visible = true;
            this.attempts.VisibleIndex = 11;
            // 
            // attemptonlast
            // 
            this.attemptonlast.Caption = "attemptonlast";
            this.attemptonlast.FieldName = "attemptonlast";
            this.attemptonlast.Name = "attemptonlast";
            this.attemptonlast.Visible = true;
            this.attemptonlast.VisibleIndex = 12;
            // 
            // XtraForm_quiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 405);
            this.Controls.Add(this.gribang);
            this.Controls.Add(this.panelControl2);
            this.Name = "XtraForm_quiz";
            this.Text = "XtraForm_quiz";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.XtraForm_quiz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gribang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grichon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnxem;
        private DevExpress.XtraEditors.LabelControl lblChon;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gribang;
        private DevExpress.XtraGrid.Views.Grid.GridView grichon;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn course;
        private DevExpress.XtraGrid.Columns.GridColumn name;
        private DevExpress.XtraGrid.Columns.GridColumn intro;
        private DevExpress.XtraGrid.Columns.GridColumn introformat;
        private DevExpress.XtraGrid.Columns.GridColumn timeopen;
        private DevExpress.XtraGrid.Columns.GridColumn Color;
        private DevExpress.XtraGrid.Columns.GridColumn timelimit;
        private DevExpress.XtraGrid.Columns.GridColumn overduehandling;
        private DevExpress.XtraGrid.Columns.GridColumn graceperiod;
        private DevExpress.XtraGrid.Columns.GridColumn preferredbehaviour;
        private DevExpress.XtraGrid.Columns.GridColumn canredoquestions;
        private DevExpress.XtraGrid.Columns.GridColumn attempts;
        private DevExpress.XtraGrid.Columns.GridColumn attemptonlast;
        private DevExpress.XtraEditors.SimpleButton btncapnhat;
    }
}