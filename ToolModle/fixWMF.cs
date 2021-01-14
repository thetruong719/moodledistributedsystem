using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Diagnostics;
using System.Drawing.Imaging;
using Microsoft.Office.Interop.Word;

using HTMLtoDOCX.Converter;

namespace unzipPackage.ToolModle
{
    public partial class fixWMF : Form
    {
        string currentFile = string.Empty;
        public fixWMF()
        {
            InitializeComponent();
        }

        private void InitEditor()
        {
            System.Diagnostics.Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.ToString().IndexOf("WINWORD") >= 0)
                    //MessageBox.Show(theprocess.ProcessName.ToString());
                    theprocess.Kill();
            }

            string executionPath = Path.GetDirectoryName(currentFile);
            executionPath = executionPath + @"\EditorInit.html";
            //wbHTMLViewer.Navigate(executionPath);
            //!System.Windows.Forms.Application.DoEvents();
            //wbHTMLViewer.Document.InvokeScript("InitEditor");
        }
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            
            
        }

        //---------------------------------------
        //string currentFile = string.Empty;
        //private System.Windows.Forms.WebBrowser webBrowser1;
        delegate void ConvertDocumentDelegate(string fileName);
        string tempFileName = null;

        private void button1A_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Office Files|*.docx";
            //dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select your document (docx)";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = dialog.FileName;
                LoadDocument(currentFile);

                while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.Application.DoEvents();
                    System.Threading.Thread.Sleep(1);
                }

                string dirName1 = Path.GetDirectoryName(currentFile);
                string name1 = Path.GetFileNameWithoutExtension(currentFile);
                string loadFile = dirName1 + "\\" + name1 + ".htm";

                webBrowser2.Navigate(loadFile);
                //lblFileName.Text = Path.GetFileName(currentFile);
            }


        }        

        public void LoadDocument(string fileName)
        {
            // Call ConvertDocument asynchronously. 
            ConvertDocumentDelegate del = new ConvertDocumentDelegate(ConvertDocument);

            // Call DocumentConversionComplete when the method has completed. 
            del.BeginInvoke(fileName, DocumentConversionComplete, null);
        }

        void ConvertDocument(string fileName)
        {
            object m = System.Reflection.Missing.Value;
            object oldFileName = (object)fileName;
            object readOnly = (object)false;
            Microsoft.Office.Interop.Word.Application ac = null;

            try
            {
                // First, create a new Microsoft.Office.Interop.Word.ApplicationClass.

                ac = new Microsoft.Office.Interop.Word.Application();

                // Now we open the document.
                //Document doc = ac.Documents.Open(ref oldFileName, ref m, ref readOnly,
                //    ref m, ref m, ref m, ref m, ref m, ref m, ref m,
                //     ref m, ref m, ref m, ref m, ref m, ref m);
                Document doc = ac.Documents.Open(ref oldFileName, ref m, ref m,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m,
                     ref m, ref m, ref m, ref m, ref m, ref m);

                // Create a temp file to save the HTML file to. 
                tempFileName = GetTempFile("html");

                // Cast these items to object.  The methods we're calling 
                // only take object types in their method parameters. 
                object newFileName = (object)tempFileName;

                // We will be saving this file as HTML format. 
                //object fileType = (object)WdSaveFormat.wdFormatHTML;
                object fileType = (object)WdSaveFormat.wdFormatHTML;

                // Save the file. 
                doc.SaveAs(ref newFileName, ref fileType,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m);

                string dirName1 = Path.GetDirectoryName(currentFile);
                string name1 = Path.GetFileNameWithoutExtension(currentFile);
                string saveFile = dirName1 + "\\" + name1;
                fileType = (object)WdSaveFormat.wdFormatFilteredHTML;////.wdFormatHTML;
                doc.SaveAs(saveFile, ref fileType,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m);

            }
            finally
            {
                // Make sure we close the application class. 
                if (ac != null)
                    //ac.Quit(ref readOnly, ref m, ref m);
                    ac.Quit(ref m, ref m, ref m);
            }
        }

        void DocumentConversionComplete(IAsyncResult result)
        {
            // navigate to our temp file. 
            webBrowser1.Navigate(tempFileName);
            //System.Windows.Forms.Application.DoEvents();
        }

        void webBrowser1_DocumentCompleted(object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
            if (tempFileName != string.Empty)
            {
                // delete the temp file we created. 
                //!File.Delete(tempFileName);

                //// set the tempFileName to an empty string. 
                //!tempFileName = string.Empty;
            }
        }

        string GetTempFile(string extension)
        {
            // Uses the Combine, GetTempPath, ChangeExtension, 
            // and GetRandomFile methods of Path to 
            // create a temp file of the extension we're looking for. 
            return Path.Combine(Path.GetTempPath(),
                Path.ChangeExtension(Path.GetRandomFileName(), extension));
        }

        private void Save_Click(object sender, EventArgs e)
        {


            string dirName1 = Path.GetDirectoryName(currentFile);
            string name1 = Path.GetFileNameWithoutExtension(currentFile);
            string saveFile = dirName1 + "\\[fixedWMF]_" + name1 + ".docx";

            Clipboard.Clear();
            webBrowser2.Document.Window.Focus();
            webBrowser2.Document.ExecCommand("SelectAll", true, null);
            webBrowser2.Document.ExecCommand("Copy", true, null);
            webBrowser2.Document.ExecCommand("Unselect", true, null);
            richload.Paste();

            richload.SaveDocument(saveFile, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            richload.Document.Delete(richload.Document.Range);
            
            MessageBox.Show("Done!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.ToString().IndexOf("WINWORD") >= 0)
                    //MessageBox.Show(theprocess.ProcessName.ToString());
                    theprocess.Kill();
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Office Files|*.docx";
            //dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select your document (docx)";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = dialog.FileName;
                lblFileName.Text = currentFile;
                capnhat.ShowWaitForm();
                LoadDocument(currentFile);
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.Application.DoEvents();
                    System.Threading.Thread.Sleep(1);
                }

                string dirName1 = Path.GetDirectoryName(currentFile);
                string name1 = Path.GetFileNameWithoutExtension(currentFile);
                string loadFile = dirName1 + "\\" + name1 + ".htm";                                

                //show result:
                webBrowser2.Navigate(loadFile);              

                //check and inform WMF
                string fileNameTest1 = dirName1 + "\\" + name1 + ".docx";
                string fileNameTest2 = name1 + ".zip";
                string pathMedia = "extractZip\\word\\media";
                if (imageWMF_checkBox.Checked == true)
                {

                    System.IO.File.Copy(fileNameTest1, fileNameTest2, true);
                    string extractPath = "extractZip";
                    if (Directory.Exists("extractZip"))
                        Directory.Delete("extractZip", true);
                    ZipFile.ExtractToDirectory(fileNameTest2, extractPath);
                    if (Directory.Exists(pathMedia))
                    {
                        capnhat.CloseWaitForm();
                        MessageBox.Show("Tập tin \r\n" + name1 + ".docx\r\n" + " CÓ chứa ảnh WMF");
                    }
                    else
                    {
                        capnhat.CloseWaitForm();
                        MessageBox.Show("Tập tin  \r\n" + name1 + ".docx\r\n" + " KHÔNG chứa ảnh WMF");
                    }


                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            capnhat.ShowWaitForm();
            string name1 = Path.GetFileNameWithoutExtension(currentFile);// txtPath.Text);   
            string dirName1 = Path.GetDirectoryName(currentFile);
            //string fileNameTest1 = dirName1 + "\\" + "[Standardized]_" + name1 + ".docx";
            string fileNameTest1 = dirName1 + "\\" + name1 + ".docx";
            string fileNameTest2 = name1 + ".zip";
            string pathMedia = "extractZip\\word\\media";
           
            if (Directory.Exists(pathMedia))
            {
                try
                {
                    //string dirName1 = Path.GetDirectoryName(currentFile);
                    //string name1 = Path.GetFileNameWithoutExtension(currentFile);
                    string saveFile = dirName1 + "\\[fixedWMF]_" + name1 + ".docx";

                    Clipboard.Clear();
                    webBrowser2.Document.Window.Focus();
                    webBrowser2.Document.ExecCommand("SelectAll", true, null);
                    webBrowser2.Document.ExecCommand("Copy", true, null);
                    webBrowser2.Document.ExecCommand("Unselect", true, null);
                    richload.Paste();
                    //txtnoidung.Paste();//.LoadDocument(currentFile);

                    richload.SaveDocument(saveFile, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
                    richload.Document.Delete(richload.Document.Range);
                    capnhat.CloseWaitForm();
                    MessageBox.Show("Đã chỉnh sửa tập tin chứa ảnh WMF: \r\n" + "[fixedWMF]_" + name1 + ".docx");
                    //string dirName1 = Path.GetDirectoryName(currentFile);
                    //string name1 = Path.GetFileNameWithoutExtension(currentFile);
                    //string loadFile = dirName1 + "\\" + name1 + ".htm";
                    //webBrowser2.Navigate(loadFile);
                }
                catch (Exception ex)
                {
                    capnhat.CloseWaitForm();
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, "Exception occured", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


            //MessageBox.Show("Done!");
        }

        private void fixWMF_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Người dùng nên chuyển đổi các công thức trong tập tin word sang dạng Mathjax bằng công cụ Mathtype trên M.Word trước khi chạy chương trình sửa công thức ảnh WMF này.");
        }
    }
}
