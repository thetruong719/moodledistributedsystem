namespace unzipPackage
{
    partial class XtraForm_NewCourses
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
            this.coursesNewest = new System.Windows.Forms.RadioButton();
            this.allCourses = new System.Windows.Forms.RadioButton();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.diskPatitions = new System.Windows.Forms.ComboBox();
            this.btnUnzipandInstall = new System.Windows.Forms.Button();
            this.btntaikhoahoc = new System.Windows.Forms.Button();
            this.size = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statusDU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sizeMB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CourseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.updatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CourseName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // coursesNewest
            // 
            this.coursesNewest.AutoSize = true;
            this.coursesNewest.Checked = true;
            this.coursesNewest.Location = new System.Drawing.Point(245, 5);
            this.coursesNewest.Name = "coursesNewest";
            this.coursesNewest.Size = new System.Drawing.Size(66, 17);
            this.coursesNewest.TabIndex = 24;
            this.coursesNewest.TabStop = true;
            this.coursesNewest.Text = "Mới nhất";
            this.coursesNewest.UseVisualStyleBackColor = true;
            this.coursesNewest.CheckedChanged += new System.EventHandler(this.coursesNewest_CheckedChanged);
            // 
            // allCourses
            // 
            this.allCourses.AutoSize = true;
            this.allCourses.Location = new System.Drawing.Point(175, 5);
            this.allCourses.Name = "allCourses";
            this.allCourses.Size = new System.Drawing.Size(64, 17);
            this.allCourses.TabIndex = 23;
            this.allCourses.Text = "Toàn bộ";
            this.allCourses.UseVisualStyleBackColor = true;
            this.allCourses.CheckedChanged += new System.EventHandler(this.allCourses_CheckedChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(305, 299);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(197, 23);
            this.button6.TabIndex = 22;
            this.button6.Text = "update course info";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(685, 237);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 23);
            this.button4.TabIndex = 21;
            this.button4.Text = "Đóng";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(183, 299);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Set Parameters";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Danh sách các khóa học mới:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Ổ đĩa cài đặt:";
            // 
            // diskPatitions
            // 
            this.diskPatitions.FormattingEnabled = true;
            this.diskPatitions.Location = new System.Drawing.Point(512, 4);
            this.diskPatitions.Name = "diskPatitions";
            this.diskPatitions.Size = new System.Drawing.Size(235, 21);
            this.diskPatitions.TabIndex = 17;
            this.diskPatitions.TextChanged += new System.EventHandler(this.diskPatitions_TextChanged);
            // 
            // btnUnzipandInstall
            // 
            this.btnUnzipandInstall.Location = new System.Drawing.Point(50, 299);
            this.btnUnzipandInstall.Name = "btnUnzipandInstall";
            this.btnUnzipandInstall.Size = new System.Drawing.Size(118, 23);
            this.btnUnzipandInstall.TabIndex = 16;
            this.btnUnzipandInstall.Text = "Unzip and Install";
            this.btnUnzipandInstall.UseVisualStyleBackColor = true;
            this.btnUnzipandInstall.Click += new System.EventHandler(this.btnUnzipandInstall_Click);
            // 
            // btntaikhoahoc
            // 
            this.btntaikhoahoc.Location = new System.Drawing.Point(12, 237);
            this.btntaikhoahoc.Name = "btntaikhoahoc";
            this.btntaikhoahoc.Size = new System.Drawing.Size(145, 23);
            this.btntaikhoahoc.TabIndex = 15;
            this.btntaikhoahoc.Text = "Tải khóa học";
            this.btntaikhoahoc.UseVisualStyleBackColor = true;
            this.btntaikhoahoc.Click += new System.EventHandler(this.btntaikhoahoc_Click);
            // 
            // size
            // 
            this.size.Caption = "size";
            this.size.FieldName = "size";
            this.size.Name = "size";
            this.size.OptionsColumn.AllowEdit = false;
            this.size.OptionsColumn.ReadOnly = true;
            this.size.Width = 76;
            // 
            // status
            // 
            this.status.Caption = "Phần trăm";
            this.status.FieldName = "status";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowEdit = false;
            this.status.OptionsColumn.ReadOnly = true;
            this.status.Visible = true;
            this.status.VisibleIndex = 5;
            this.status.Width = 69;
            // 
            // statusDU
            // 
            this.statusDU.Caption = "Trạng thái";
            this.statusDU.FieldName = "statusDU";
            this.statusDU.Name = "statusDU";
            this.statusDU.OptionsColumn.AllowEdit = false;
            this.statusDU.OptionsColumn.ReadOnly = true;
            this.statusDU.Visible = true;
            this.statusDU.VisibleIndex = 4;
            this.statusDU.Width = 95;
            // 
            // sizeMB
            // 
            this.sizeMB.Caption = "Kích thước (MB)";
            this.sizeMB.FieldName = "sizeMB";
            this.sizeMB.Name = "sizeMB";
            this.sizeMB.OptionsColumn.AllowEdit = false;
            this.sizeMB.OptionsColumn.ReadOnly = true;
            this.sizeMB.Visible = true;
            this.sizeMB.VisibleIndex = 3;
            // 
            // CourseName
            // 
            this.CourseName.Caption = "CourseName";
            this.CourseName.FieldName = "CourseName";
            this.CourseName.Name = "CourseName";
            this.CourseName.OptionsColumn.AllowEdit = false;
            this.CourseName.OptionsColumn.ReadOnly = true;
            this.CourseName.Width = 30;
            // 
            // updatedDate
            // 
            this.updatedDate.Caption = "Ngày cập nhật";
            this.updatedDate.FieldName = "updatedDate";
            this.updatedDate.Name = "updatedDate";
            this.updatedDate.OptionsColumn.AllowEdit = false;
            this.updatedDate.OptionsColumn.ReadOnly = true;
            this.updatedDate.Visible = true;
            this.updatedDate.VisibleIndex = 2;
            this.updatedDate.Width = 139;
            // 
            // CourseName1
            // 
            this.CourseName1.Caption = "Tên môn học";
            this.CourseName1.FieldName = "CourseName1";
            this.CourseName1.Name = "CourseName1";
            this.CourseName1.OptionsColumn.AllowEdit = false;
            this.CourseName1.OptionsColumn.ReadOnly = true;
            this.CourseName1.Visible = true;
            this.CourseName1.VisibleIndex = 1;
            this.CourseName1.Width = 124;
            // 
            // Check
            // 
            this.Check.Caption = "Chọn";
            this.Check.FieldName = "Check";
            this.Check.Name = "Check";
            this.Check.Visible = true;
            this.Check.VisibleIndex = 0;
            this.Check.Width = 37;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Check,
            this.CourseName1,
            this.updatedDate,
            this.CourseName,
            this.sizeMB,
            this.statusDU,
            this.status,
            this.Id,
            this.size});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.OptionsColumn.AllowEdit = false;
            this.Id.OptionsColumn.ReadOnly = true;
            this.Id.Width = 147;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 31);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(735, 200);
            this.gridControl1.TabIndex = 14;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // XtraForm_NewCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 344);
            this.Controls.Add(this.coursesNewest);
            this.Controls.Add(this.allCourses);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.diskPatitions);
            this.Controls.Add(this.btnUnzipandInstall);
            this.Controls.Add(this.btntaikhoahoc);
            this.Controls.Add(this.gridControl1);
            this.Name = "XtraForm_NewCourses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XtraForm_NewCourses";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XtraForm_NewCourses_FormClosing);
            this.Load += new System.EventHandler(this.XtraForm_NewCourses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton coursesNewest;
        private System.Windows.Forms.RadioButton allCourses;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox diskPatitions;
        private System.Windows.Forms.Button btnUnzipandInstall;
        private System.Windows.Forms.Button btntaikhoahoc;
        private DevExpress.XtraGrid.Columns.GridColumn size;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        private DevExpress.XtraGrid.Columns.GridColumn statusDU;
        private DevExpress.XtraGrid.Columns.GridColumn sizeMB;
        private DevExpress.XtraGrid.Columns.GridColumn CourseName;
        private DevExpress.XtraGrid.Columns.GridColumn updatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn CourseName1;
        private DevExpress.XtraGrid.Columns.GridColumn Check;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        public DevExpress.XtraGrid.GridControl gridControl1;
    }
}