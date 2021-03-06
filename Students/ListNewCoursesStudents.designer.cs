﻿namespace unzipPackage.Students
{
    partial class ListNewCoursesStudents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListNewCoursesStudents));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CourseName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.updatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CourseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sizeMB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statusDU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.size = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.diskPatitions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.listNewCoursesMethod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gradeSeletect = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(15, 71);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(735, 200);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            // Check
            // 
            this.Check.Caption = "Chọn";
            this.Check.FieldName = "Check";
            this.Check.Name = "Check";
            this.Check.Visible = true;
            this.Check.VisibleIndex = 0;
            this.Check.Width = 37;
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
            // CourseName
            // 
            this.CourseName.Caption = "CourseName";
            this.CourseName.FieldName = "CourseName";
            this.CourseName.Name = "CourseName";
            this.CourseName.OptionsColumn.AllowEdit = false;
            this.CourseName.OptionsColumn.ReadOnly = true;
            this.CourseName.Width = 30;
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
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.OptionsColumn.AllowEdit = false;
            this.Id.OptionsColumn.ReadOnly = true;
            this.Id.Width = 147;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tải khóa học";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Unzip and Install";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // diskPatitions
            // 
            this.diskPatitions.FormattingEnabled = true;
            this.diskPatitions.Location = new System.Drawing.Point(515, 44);
            this.diskPatitions.Name = "diskPatitions";
            this.diskPatitions.Size = new System.Drawing.Size(235, 21);
            this.diskPatitions.TabIndex = 3;
            this.diskPatitions.TextChanged += new System.EventHandler(this.diskPatitions_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(512, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ổ đĩa cài đặt:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Danh sách các khóa học mới:";
            this.label2.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(312, 277);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Set Parameters";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(688, 277);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Đóng";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(434, 277);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(197, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "update course info";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // listNewCoursesMethod
            // 
            this.listNewCoursesMethod.FormattingEnabled = true;
            this.listNewCoursesMethod.Items.AddRange(new object[] {
            "Các khóa học mới nhất",
            "Các khóa học chưa được thẩm định",
            "Toàn bộ các khóa học"});
            this.listNewCoursesMethod.Location = new System.Drawing.Point(157, 44);
            this.listNewCoursesMethod.Name = "listNewCoursesMethod";
            this.listNewCoursesMethod.Size = new System.Drawing.Size(195, 21);
            this.listNewCoursesMethod.TabIndex = 14;
            this.listNewCoursesMethod.Text = "Các khóa học mới nhất";
            this.listNewCoursesMethod.Visible = false;
            this.listNewCoursesMethod.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.listNewCoursesMethod.Click += new System.EventHandler(this.listNewCoursesMethod_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Chọn khối học:";
            // 
            // gradeSeletect
            // 
            this.gradeSeletect.FormattingEnabled = true;
            this.gradeSeletect.Items.AddRange(new object[] {
            "Khối 1",
            "Khối 2",
            "Khối 3",
            "Khối 4",
            "Khối 5",
            "Khối 6",
            "Khối 7",
            "Khối 8",
            "Khối 9",
            "Khối 10",
            "Khối 11",
            "Khối 12"});
            this.gradeSeletect.Location = new System.Drawing.Point(15, 44);
            this.gradeSeletect.Name = "gradeSeletect";
            this.gradeSeletect.Size = new System.Drawing.Size(121, 21);
            this.gradeSeletect.TabIndex = 27;
            this.gradeSeletect.Text = "Khối 7";
            this.gradeSeletect.SelectedIndexChanged += new System.EventHandler(this.gradeSeletect_SelectedIndexChanged);
            // 
            // ListNewCoursesStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 308);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gradeSeletect);
            this.Controls.Add(this.listNewCoursesMethod);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.diskPatitions);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(769, 340);
            this.MinimumSize = new System.Drawing.Size(769, 319);
            this.Name = "ListNewCoursesStudents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Các khóa học mới";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListNewCourses_FormClosed);
            this.Load += new System.EventHandler(this.ListNewCourses_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Check;
        private DevExpress.XtraGrid.Columns.GridColumn CourseName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox diskPatitions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn CourseName1;
        private DevExpress.XtraGrid.Columns.GridColumn updatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        private DevExpress.XtraGrid.Columns.GridColumn size;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private DevExpress.XtraGrid.Columns.GridColumn statusDU;
        private System.Windows.Forms.Button button6;
        private DevExpress.XtraGrid.Columns.GridColumn sizeMB;
        private System.Windows.Forms.ComboBox listNewCoursesMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox gradeSeletect;
    }
}