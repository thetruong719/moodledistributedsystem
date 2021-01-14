namespace unzipPackage.Students
{
    partial class listCoursesToRun_Students
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(listCoursesToRun_Students));
            this.button1 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.courseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lastAccess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lastestUpdateVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.percent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.splcapnhat = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::unzipPackage.WaitForm1), true, true);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.protiendo = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblthongbao = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblthongbaoloi = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblbatdau = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblketthuc = new System.Windows.Forms.ToolStripStatusLabel();
            this.button8 = new System.Windows.Forms.Button();
            this.btnhoanthanh = new System.Windows.Forms.Button();
            this.btnnopdiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Học bài";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(8, 35);
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
            this.lastAccess,
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
            // lastAccess
            // 
            this.lastAccess.Caption = "Last Access";
            this.lastAccess.FieldName = "lastAccess";
            this.lastAccess.Name = "lastAccess";
            this.lastAccess.Width = 185;
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
            this.status.Caption = "status";
            this.status.FieldName = "status";
            this.status.Name = "status";
            // 
            // percent
            // 
            this.percent.Caption = "percent";
            this.percent.FieldName = "percent";
            this.percent.Name = "percent";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Các khóa học hiện tại:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(554, 241);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(59, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Đóng";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(459, 11);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(152, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "Cập nhật các khóa học mới";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(642, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "label2";
            // 
            // splcapnhat
            // 
            this.splcapnhat.ClosingDelay = 500;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.protiendo);
            this.groupBox1.Controls.Add(this.progressBar2);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(1, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 120);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // protiendo
            // 
            this.protiendo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.protiendo.Location = new System.Drawing.Point(3, 19);
            this.protiendo.Name = "protiendo";
            this.protiendo.Size = new System.Drawing.Size(609, 23);
            this.protiendo.TabIndex = 21;
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar2.Location = new System.Drawing.Point(354, 90);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(197, 23);
            this.progressBar2.TabIndex = 20;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.Location = new System.Drawing.Point(279, 46);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(109, 23);
            this.button6.TabIndex = 19;
            this.button6.Text = "Zip, Upload";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(32, 46);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 23);
            this.button5.TabIndex = 18;
            this.button5.Text = "Download Marks";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(155, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Stop Course";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(394, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Nộp bài";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblthongbao,
            this.lblthongbaoloi,
            this.lblbatdau,
            this.lblketthuc});
            this.statusStrip1.Location = new System.Drawing.Point(0, 276);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(627, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(238, 17);
            this.lblStatus.Text = "Developed by Hoang Viet E-Learning Group";
            // 
            // lblthongbao
            // 
            this.lblthongbao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblthongbao.Name = "lblthongbao";
            this.lblthongbao.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblthongbao.Size = new System.Drawing.Size(0, 17);
            // 
            // lblthongbaoloi
            // 
            this.lblthongbaoloi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblthongbaoloi.Name = "lblthongbaoloi";
            this.lblthongbaoloi.Size = new System.Drawing.Size(0, 17);
            // 
            // lblbatdau
            // 
            this.lblbatdau.Name = "lblbatdau";
            this.lblbatdau.Size = new System.Drawing.Size(53, 17);
            this.lblbatdau.Text = "Bắt đầu: ";
            // 
            // lblketthuc
            // 
            this.lblketthuc.Name = "lblketthuc";
            this.lblketthuc.Size = new System.Drawing.Size(57, 17);
            this.lblketthuc.Text = "Kết thúc: ";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(110, 344);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(85, 23);
            this.button8.TabIndex = 22;
            this.button8.Text = "nopbai";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // btnhoanthanh
            // 
            this.btnhoanthanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnhoanthanh.Location = new System.Drawing.Point(186, 241);
            this.btnhoanthanh.Name = "btnhoanthanh";
            this.btnhoanthanh.Size = new System.Drawing.Size(85, 23);
            this.btnhoanthanh.TabIndex = 23;
            this.btnhoanthanh.Text = "Hoàn thành";
            this.btnhoanthanh.UseVisualStyleBackColor = true;
            this.btnhoanthanh.Visible = false;
            this.btnhoanthanh.Click += new System.EventHandler(this.btnhoanthanh_Click);
            // 
            // btnnopdiem
            // 
            this.btnnopdiem.Location = new System.Drawing.Point(95, 241);
            this.btnnopdiem.Name = "btnnopdiem";
            this.btnnopdiem.Size = new System.Drawing.Size(85, 23);
            this.btnnopdiem.TabIndex = 24;
            this.btnnopdiem.Text = "Nop diem";
            this.btnnopdiem.UseVisualStyleBackColor = true;
            this.btnnopdiem.Visible = false;
            this.btnnopdiem.Click += new System.EventHandler(this.btnnopdiem_Click);
            // 
            // listCoursesToRun_Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 298);
            this.Controls.Add(this.btnnopdiem);
            this.Controls.Add(this.btnhoanthanh);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "listCoursesToRun_Students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Learning Hoang Viet";
            this.Activated += new System.EventHandler(this.listCoursesToRun_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.listCoursesToRun_Students_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.listCoursesToRun_Students_FormClosed);
            this.Load += new System.EventHandler(this.listCoursesToRun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
        private DevExpress.XtraGrid.Columns.GridColumn lastAccess;
        private DevExpress.XtraGrid.Columns.GridColumn lastestUpdateVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        private DevExpress.XtraGrid.Columns.GridColumn percent;
        private DevExpress.XtraSplashScreen.SplashScreenManager splcapnhat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar protiendo;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblthongbao;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnhoanthanh;
        private System.Windows.Forms.Button btnnopdiem;
        private System.Windows.Forms.ToolStripStatusLabel lblthongbaoloi;
        private System.Windows.Forms.ToolStripStatusLabel lblbatdau;
        private System.Windows.Forms.ToolStripStatusLabel lblketthuc;
    }
}