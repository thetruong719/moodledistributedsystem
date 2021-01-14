namespace unzipPackage.ToolModle
{
    partial class fixWMF
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
            this.richload = new DevExpress.XtraRichEdit.RichEditControl();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.imageWMF_checkBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label3 = new System.Windows.Forms.Label();
            this.capnhat = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::unzipPackage.WaitForm1), true, true);
            this.SuspendLayout();
            // 
            // richload
            // 
            this.richload.Location = new System.Drawing.Point(0, 0);
            this.richload.Name = "richload";
            this.richload.Size = new System.Drawing.Size(400, 200);
            this.richload.TabIndex = 0;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser2.Location = new System.Drawing.Point(10, 421);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(718, 317);
            this.webBrowser2.TabIndex = 9;
            // 
            // imageWMF_checkBox
            // 
            this.imageWMF_checkBox.AutoSize = true;
            this.imageWMF_checkBox.Checked = true;
            this.imageWMF_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.imageWMF_checkBox.Location = new System.Drawing.Point(218, 12);
            this.imageWMF_checkBox.Name = "imageWMF_checkBox";
            this.imageWMF_checkBox.Size = new System.Drawing.Size(114, 17);
            this.imageWMF_checkBox.TabIndex = 10;
            this.imageWMF_checkBox.Text = "Kiểm tra ảnh WMF";
            this.imageWMF_checkBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Mở tập tin word";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Sửa ảnh WMF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(405, 13);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(48, 13);
            this.lblFileName.TabIndex = 13;
            this.lblFileName.Text = "fileName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nội dung sau khi sửa (từ HTML):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nội dung trước khi sửa (từ DOCX):";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 75);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(716, 310);
            this.webBrowser1.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tên tập tin:";
            // 
            // capnhat
            // 
            this.capnhat.ClosingDelay = 500;
            // 
            // fixWMF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 749);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imageWMF_checkBox);
            this.Controls.Add(this.webBrowser2);
            this.Name = "fixWMF";
            this.Text = "Sửa các ảnh WMF trong tập tin word";
            this.Load += new System.EventHandler(this.fixWMF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraRichEdit.RichEditControl richload;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.CheckBox imageWMF_checkBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraSplashScreen.SplashScreenManager capnhat;
    }
}