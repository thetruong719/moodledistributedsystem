namespace unzipPackage.Teacherslist
{
    partial class ListCoursesToRun_Teacherslist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListCoursesToRun_Teacherslist));
            this.button1 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.courseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lastestUpdateVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.percent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.protiendo = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblname = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbltiendo = new System.Windows.Forms.ToolStripStatusLabel();
            this.splcapnhat = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::unzipPackage.WaitForm1), true, true);
            this.btnhoanthanh = new System.Windows.Forms.Button();
            this.btnmacdinh = new System.Windows.Forms.Button();
            this.btnnen = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Vào khóa học";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(7, 39);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(605, 200);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.courseName,
            this.lastestUpdateVersion,
            this.status,
            this.percent});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // courseName
            // 
            this.courseName.Caption = "Tên môn học";
            this.courseName.FieldName = "courseName";
            this.courseName.Name = "courseName";
            this.courseName.Visible = true;
            this.courseName.VisibleIndex = 0;
            this.courseName.Width = 143;
            // 
            // lastestUpdateVersion
            // 
            this.lastestUpdateVersion.Caption = "Phiên bản";
            this.lastestUpdateVersion.FieldName = "lastestUpdateVersion";
            this.lastestUpdateVersion.Name = "lastestUpdateVersion";
            this.lastestUpdateVersion.Visible = true;
            this.lastestUpdateVersion.VisibleIndex = 1;
            this.lastestUpdateVersion.Width = 173;
            // 
            // status
            // 
            this.status.Caption = "Trạng thái";
            this.status.FieldName = "status";
            this.status.Name = "status";
            this.status.Visible = true;
            this.status.VisibleIndex = 2;
            // 
            // percent
            // 
            this.percent.Caption = "Phần trăm";
            this.percent.FieldName = "percent";
            this.percent.Name = "percent";
            this.percent.Visible = true;
            this.percent.VisibleIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Các khóa học hiện tại:";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(374, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Nộp bài";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(490, 338);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Stop Course";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(346, 245);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(59, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Đóng";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(94, 245);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Tải Bài làm";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(199, 245);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(141, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Đưa khóa học lên server";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(129, 11);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(152, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "Cập nhật các khóa học mới";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // protiendo
            // 
            this.protiendo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.protiendo.Location = new System.Drawing.Point(4, 274);
            this.protiendo.Name = "protiendo";
            this.protiendo.Size = new System.Drawing.Size(609, 23);
            this.protiendo.TabIndex = 15;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblname,
            this.lbltiendo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 309);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(625, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(13, 17);
            this.lblStatus.Text = "1";
            // 
            // lblname
            // 
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(13, 17);
            this.lblname.Text = "2";
            // 
            // lbltiendo
            // 
            this.lbltiendo.Name = "lbltiendo";
            this.lbltiendo.Size = new System.Drawing.Size(13, 17);
            this.lbltiendo.Text = "3";
            // 
            // splcapnhat
            // 
            this.splcapnhat.ClosingDelay = 500;
            // 
            // btnhoanthanh
            // 
            this.btnhoanthanh.Location = new System.Drawing.Point(411, 245);
            this.btnhoanthanh.Name = "btnhoanthanh";
            this.btnhoanthanh.Size = new System.Drawing.Size(99, 23);
            this.btnhoanthanh.TabIndex = 7;
            this.btnhoanthanh.Text = "Hoan thanh";
            this.btnhoanthanh.UseVisualStyleBackColor = true;
            this.btnhoanthanh.Visible = false;
            this.btnhoanthanh.Click += new System.EventHandler(this.btnhoanthanh_Click);
            // 
            // btnmacdinh
            // 
            this.btnmacdinh.Location = new System.Drawing.Point(644, 245);
            this.btnmacdinh.Name = "btnmacdinh";
            this.btnmacdinh.Size = new System.Drawing.Size(99, 23);
            this.btnmacdinh.TabIndex = 22;
            this.btnmacdinh.Text = "Mặc định";
            this.btnmacdinh.UseVisualStyleBackColor = true;
            this.btnmacdinh.Visible = false;
            this.btnmacdinh.Click += new System.EventHandler(this.btnmacdinh_Click);
            // 
            // btnnen
            // 
            this.btnnen.Location = new System.Drawing.Point(411, 5);
            this.btnnen.Name = "btnnen";
            this.btnnen.Size = new System.Drawing.Size(99, 23);
            this.btnnen.TabIndex = 23;
            this.btnnen.Text = "Nén";
            this.btnnen.UseVisualStyleBackColor = true;
            this.btnnen.Visible = false;
            this.btnnen.Click += new System.EventHandler(this.btnnen_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(513, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(99, 23);
            this.button9.TabIndex = 23;
            this.button9.Text = "Giải nén";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            // 
            // ListCoursesToRun_Teacherslist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 331);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.btnnen);
            this.Controls.Add(this.btnmacdinh);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.protiendo);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnhoanthanh);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListCoursesToRun_Teacherslist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Learning Hoang Viet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.ListCoursesToRun_Teacherslist_Activated);
            this.Deactivate += new System.EventHandler(this.listCoursesToRun_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListCoursesToRun_Teacherslist_FormClosed);
            this.Load += new System.EventHandler(this.listCoursesToRun_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListCoursesToRun_Teacherslist_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn courseName;
        private DevExpress.XtraGrid.Columns.GridColumn lastestUpdateVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        private DevExpress.XtraGrid.Columns.GridColumn percent;
        private System.Windows.Forms.ProgressBar protiendo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblname;
        private DevExpress.XtraSplashScreen.SplashScreenManager splcapnhat;
        private System.Windows.Forms.Button btnhoanthanh;
        private System.Windows.Forms.Button btnmacdinh;
        private System.Windows.Forms.ToolStripStatusLabel lbltiendo;
        private System.Windows.Forms.Button btnnen;
        private System.Windows.Forms.Button button9;
    }
}