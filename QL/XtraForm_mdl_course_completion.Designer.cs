namespace unzipPackage.QL
{
    partial class XtraForm_mdl_course_completion
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.grimonhoc = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MonHoc_ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grikhoi = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Khoi_ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnxemhoanthanh = new DevExpress.XtraEditors.SimpleButton();
            this.lblChon = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gribang = new DevExpress.XtraGrid.GridControl();
            this.grichon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.userid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.username = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Color = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grimonhoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grikhoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.grimonhoc);
            this.panelControl2.Controls.Add(this.grikhoi);
            this.panelControl2.Controls.Add(this.btnxemhoanthanh);
            this.panelControl2.Controls.Add(this.lblChon);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(12, 12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(755, 95);
            this.panelControl2.TabIndex = 30;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(323, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(111, 23);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "CHỌN MÔN";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(71, 5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(116, 23);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "CHỌN KHỐI";
            // 
            // grimonhoc
            // 
            this.grimonhoc.EditValue = "[Vui lòng chọn chi nhánh]";
            this.grimonhoc.Location = new System.Drawing.Point(450, 3);
            this.grimonhoc.Name = "grimonhoc";
            this.grimonhoc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grimonhoc.Properties.Appearance.Options.UseFont = true;
            this.grimonhoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grimonhoc.Properties.NullText = "[CHỌN MÔN HỌC]";
            this.grimonhoc.Properties.PopupView = this.gridView2;
            this.grimonhoc.Size = new System.Drawing.Size(161, 26);
            this.grimonhoc.TabIndex = 2;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MonHoc_});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // MonHoc_
            // 
            this.MonHoc_.Caption = "Môn học";
            this.MonHoc_.FieldName = "MonHoc";
            this.MonHoc_.Name = "MonHoc_";
            this.MonHoc_.Visible = true;
            this.MonHoc_.VisibleIndex = 0;
            this.MonHoc_.Width = 581;
            // 
            // grikhoi
            // 
            this.grikhoi.EditValue = "[Vui lòng chọn chi nhánh]";
            this.grikhoi.Location = new System.Drawing.Point(193, 3);
            this.grikhoi.Name = "grikhoi";
            this.grikhoi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grikhoi.Properties.Appearance.Options.UseFont = true;
            this.grikhoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grikhoi.Properties.NullText = "[CHỌN KHỐI]";
            this.grikhoi.Properties.PopupView = this.gridView1;
            this.grikhoi.Size = new System.Drawing.Size(124, 26);
            this.grikhoi.TabIndex = 2;
            this.grikhoi.EditValueChanged += new System.EventHandler(this.grikhoi_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Khoi_});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Khoi_
            // 
            this.Khoi_.Caption = "Khối";
            this.Khoi_.FieldName = "Khoi";
            this.Khoi_.Name = "Khoi_";
            this.Khoi_.Visible = true;
            this.Khoi_.VisibleIndex = 0;
            this.Khoi_.Width = 581;
            // 
            // btnxemhoanthanh
            // 
            this.btnxemhoanthanh.ImageOptions.ImageIndex = 0;
            this.btnxemhoanthanh.Location = new System.Drawing.Point(450, 35);
            this.btnxemhoanthanh.Name = "btnxemhoanthanh";
            this.btnxemhoanthanh.Size = new System.Drawing.Size(125, 37);
            this.btnxemhoanthanh.TabIndex = 6;
            this.btnxemhoanthanh.Text = "Hoàn thành tác vụ";
            this.btnxemhoanthanh.Click += new System.EventHandler(this.btnxemdiem_Click);
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
            this.gribang.Size = new System.Drawing.Size(755, 260);
            this.gribang.TabIndex = 31;
            this.gribang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grichon});
            // 
            // grichon
            // 
            this.grichon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.userid,
            this.username,
            this.HoTen,
            this.Lop,
            this.Color});
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
            // userid
            // 
            this.userid.Caption = "Userid";
            this.userid.FieldName = "userid";
            this.userid.MinWidth = 40;
            this.userid.Name = "userid";
            this.userid.OptionsColumn.ReadOnly = true;
            this.userid.Visible = true;
            this.userid.VisibleIndex = 0;
            this.userid.Width = 60;
            // 
            // username
            // 
            this.username.Caption = "User Name";
            this.username.FieldName = "username";
            this.username.MinWidth = 40;
            this.username.Name = "username";
            this.username.OptionsColumn.ReadOnly = true;
            this.username.Visible = true;
            this.username.VisibleIndex = 1;
            this.username.Width = 140;
            // 
            // HoTen
            // 
            this.HoTen.Caption = "Họ Tên";
            this.HoTen.FieldName = "HoTen";
            this.HoTen.Name = "HoTen";
            this.HoTen.Visible = true;
            this.HoTen.VisibleIndex = 2;
            this.HoTen.Width = 200;
            // 
            // Lop
            // 
            this.Lop.Caption = "Lớp";
            this.Lop.DisplayFormat.FormatString = "0,0 VNĐ";
            this.Lop.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Lop.FieldName = "Lop";
            this.Lop.Name = "Lop";
            this.Lop.Visible = true;
            this.Lop.VisibleIndex = 3;
            this.Lop.Width = 110;
            // 
            // Color
            // 
            this.Color.Caption = "Color";
            this.Color.FieldName = "Color";
            this.Color.Name = "Color";
            // 
            // XtraForm_mdl_course_completion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 385);
            this.Controls.Add(this.gribang);
            this.Controls.Add(this.panelControl2);
            this.Name = "XtraForm_mdl_course_completion";
            this.Text = "XtraForm_mdl_course_completion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.XtraForm_mdl_course_completion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grimonhoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grikhoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gribang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grichon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GridLookUpEdit grimonhoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn MonHoc_;
        private DevExpress.XtraEditors.GridLookUpEdit grikhoi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Khoi_;
        private DevExpress.XtraEditors.SimpleButton btnxemhoanthanh;
        private DevExpress.XtraEditors.LabelControl lblChon;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gribang;
        private DevExpress.XtraGrid.Views.Grid.GridView grichon;
        private DevExpress.XtraGrid.Columns.GridColumn userid;
        private DevExpress.XtraGrid.Columns.GridColumn username;
        private DevExpress.XtraGrid.Columns.GridColumn HoTen;
        private DevExpress.XtraGrid.Columns.GridColumn Lop;
        private DevExpress.XtraGrid.Columns.GridColumn Color;
    }
}