using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop.Word;



using System.Diagnostics;
using System.IO;
using System.IO.Compression;


using System.Net;


//using DevExpress.XtraEditors;
//using System.Text.RegularExpressions;

using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Security.Permissions;
//using mshtml;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Reflection;

namespace unzipPackage.ToolModle
{
    public partial class mathjaxToHtml : Form
    {
        string currentFile = string.Empty;
        delegate void ConvertDocumentDelegate(string fileName);
        string tempFileName = null;

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public mathjaxToHtml()
        {
            SetBrowserFeatureControl();
            InitializeComponent();
        }

        public void LoadDocument(string fileName)
        {
            // Call ConvertDocument asynchronously. 
            ConvertDocumentDelegate del = new ConvertDocumentDelegate(ConvertDocument);

            // Call DocumentConversionComplete when the method has completed. 
            del.BeginInvoke(fileName, DocumentConversionComplete, null);
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
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

        //turn on ajax ------------------------------
        private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(
                String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
            }
        }

        private void SetBrowserFeatureControl()
        {
            // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

            // FeatureControl settings are per-process
            var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            // make the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                return;

            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode()); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
            SetBrowserFeatureControlKey("FEATURE_AJAX_CONNECTIONEVENTS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_MANAGE_SCRIPT_CIRCULAR_REFS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_DOMSTORAGE ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_GPU_RENDERING ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI  ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_LEGACY_COMPRESSION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_LOCALMACHINE_LOCKDOWN", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_OBJECT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_SCRIPT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SCRIPTURL_MITIGATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SPELLCHECKING", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_STATUS_BAR_THROTTLING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_TABBED_BROWSING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_VALIDATE_NAVIGATE_URL", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_DOCUMENT_ZOOM", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_MOVESIZECHILD", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ADDON_MANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBSOCKET", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WINDOW_RESTRICTIONS ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_XMLHTTP", fileName, 1);
        }

        private UInt32 GetBrowserEmulationMode()
        {
            int browserVersion = 7;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }

            UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. Default value for Internet Explorer 11.
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 mode. Default value for Internet Explorer 10.
                    break;
                default:
                    // use IE11 mode by default
                    break;
            }

            return mode;
        }

        [ComVisible(true)]

        private void button1_Click(object sender, EventArgs e)
        {

            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser2.ScriptErrorsSuppressed = true;

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);



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

                //load docx content to richEditControl
                capnhat.ShowWaitForm();
                richEditControl1.LoadDocument(currentFile);
                capnhat.CloseWaitForm();

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
                var file = new FileInfo(loadFile);
                while (IsFileLocked(file)) { }

                //while (File.Exists(loadFile)==false)
                //{
                //    System.Threading.Thread.Sleep(1);
                //}

                //StreamReader sr = new StreamReader(loadFile);
                //string s = sr.ReadToEnd();
                //s.Replace("#name", "123456").Replace("#Family", "123456");
                //sr.Close();


                //string browserContents = webBrowser1.DocumentText;// Document.Body.InnerText;
                //MessageBox.Show(browserContents);


                //string html = File.ReadAllText(loadFile);

                //browserContents = browserContents.Replace("<head>", "<head>\r\n<script type=\"text/javascript\"\r\n  src = \"http://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-AMS-MML_HTMLorMML\">\r\n</script> ");
                //browserContents = browserContents.Replace("<head>", "<head>\r\n<script>  </script> ");

                //webBrowser2.DocumentText = browserContents;
                webBrowser2.Navigate(loadFile);
                //IHTMLElement iScriptEl = (IHTMLElement)scriptEl.DomElement;

                //HtmlElement head = webBrowser2.Document.GetElementsByTagName("head")[-1];//[0];
                //HtmlElement head = webBrowser2.Document.All["HEAD"];
                //HtmlElement scriptEl = webBrowser2.Document.CreateElement("script");
                //mshtml.IHTMLScriptElement element = (mshtml.IHTMLScriptElement)scriptEl.DomElement;
                //string alertBlocker = @"window.alert = function () { }; window.confirm=function () { };";
                //element.text = alertBlocker;
                //head.AppendChild(scriptEl);

                while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.Application.DoEvents();
                    System.Threading.Thread.Sleep(1);
                }
                //richTextBox1.Text = webBrowser2.DocumentText;

                var myGoodString = System.IO.File.ReadAllText(loadFile, Encoding.GetEncoding(webBrowser2.Document.DefaultEncoding));// "windows-1258"));


                myGoodString = myGoodString.Replace("<head>", "<head>\r\n<script type=\"text/javascript\"\r\n  src = \"http://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-AMS-MML_HTMLorMML\">\r\n</script> ");

                //myGoodString = myGoodString.Replace("<head>", "<head>\r\n<script type=\"text/javascript\" async src = \"MathJax/MathJax.js?config=TeX-MML-AM_CHTML\"></script>");

                //myGoodString = myGoodString.Replace("<head>", "<head>\r\n<script type=\"text/javascript\" async src = \"MathJax-2.7.5/MathJax.js?config=TeX-MML-AM_CHTML\"></script>");


                //Encoding encoding1 = GetEncoding(loadFile);
                //MessageBox.Show(encoding1.ToString());

                string saveHtml = dirName1 + "\\" + name1 + ".htm";
                //File.WriteAllText(saveHtml, browserContents, Encoding.Default);
                File.WriteAllText(saveHtml, myGoodString, Encoding.GetEncoding(webBrowser2.Document.DefaultEncoding));// "windows-1258"));// (loadFile));//.Unicode);// encoding1);                


                //file = new FileInfo(loadFile);
                //while (IsFileLocked(file)) { }

                //string applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                //string myFile = Path.Combine(applicationDirectory, "Sample.html");
                //webMain.Url = new Uri("file:///" + myFile);

                //string curDir = Directory.GetCurrentDirectory();
                //webBrowser2.Url = new Uri(String.Format("file:///{0}/my_html.html", curDir));
                //webBrowser2.Url = new Uri(String.Format("file:///"+ name1 + "_1.htm", curDir));

                //webBrowser2.IsWebBrowserContextMenuEnabled = false;
                //webBrowser2.Navigate();

                //string curDir = Directory.GetCurrentDirectory();
                //webBrowser2.Navigate(new Uri(String.Format("file:///{0}/" + name1 + ".htm", curDir)));

                //while (this.webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                //    System.Windows.Forms.Application.DoEvents();

                //foreach (string contact in Contract.Items)
                //{
                //    webBrowser2.Document.InvokeScript("postform_open");

                //    object[] args = new object[1] { contact };

                //    webBrowser2.Document.InvokeScript("postform_sharewith_user", args);

                //    webBrowser2.Document.Window.Frames[0].Document.GetElementsByTagName("body")[0].InnerHtml = this.Message.Text;

                //    webBrowser2.Document.InvokeScript("postform_submit");
                //}


                webBrowser2.Navigate(saveHtml);
                while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.Application.DoEvents();
                    System.Threading.Thread.Sleep(1);
                }
                //capnhat.ShowWaitForm();
                //txtnoidung.LoadDocument(txtPath1);
                capnhat.CloseWaitForm();
                MessageBox.Show("Đã lưu tập tin \r\n" + name1 + ".htm");

                //check and inform WMF
                //string fileNameTest1 = dirName1 + "\\" + name1 + ".docx";
                //string fileNameTest2 = name1 + ".zip";
                //string pathMedia = "extractZip\\word\\media";
                //if (imageWMF_checkBox.Checked == true)
                //{

                //    System.IO.File.Copy(fileNameTest1, fileNameTest2, true);
                //    string extractPath = "extractZip";
                //    if (Directory.Exists("extractZip"))
                //        Directory.Delete("extractZip", true);
                //    ZipFile.ExtractToDirectory(fileNameTest2, extractPath);
                //    if (Directory.Exists(pathMedia))
                //    {
                //        //capnhat.CloseWaitForm();
                //        MessageBox.Show("Tập tin \r\n" + name1 + ".docx\r\n" + " CÓ chứa ảnh WMF");
                //    }
                //    else
                //    {
                //        //capnhat.CloseWaitForm();
                //        MessageBox.Show("Tập tin  \r\n" + name1 + ".docx\r\n" + " KHÔNG chứa ảnh WMF");
                //    }


                //}
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("in StandardizedWordDocument");
            //Create an instance for word app  
            Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

            //MessageBox.Show("just create windord");
            //Set animation status for word application  
            //!winword.ShowAnimation = false;

            //Set status for word application is to be visible or not.  
            //!winword.Visible = false;

            //Create a missing variable for missing value  
            object missing = Missing.Value;

            object readOnly = false;
            //object readOnlyTemplate = true;
            object isVisible = false;
            object fileName = currentFile; //change fileName to path instead of txtPath !!!!
            //MessageBox.Show(fileName.ToString());
            string workingDirectory = Environment.CurrentDirectory;
            string runningPath = Directory.GetParent(workingDirectory).Parent.FullName;

            //MessageBox.Show("init - declaring");
            //Create a new document  
            Document document = winword.Documents.Open(ref fileName, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
            //MessageBox.Show("just opening");
            try
            {
                //MessageBox.Show("in try - just open word and create files");
                object start = document.Content.Start;
                object end = document.Content.End;
                document.Range(start, end).Select();
                //document.Application.Selection.Find.ClearFormatting();

                document.Application.Selection.Find.Execute("\\(", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, "\\[", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                document.Application.Selection.Find.Execute("\\)", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, "\\]", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);






                //System.Threading.Thread.Sleep(1000);
                //Save the document  
                string name = Path.GetFileNameWithoutExtension(currentFile);// txtPath.Text);
                //name = ConvertToUnSign(name);
                //object filename = @txtSavePath.Text + "\\" + "[Standardized]_" + name + ".docx";
                object filename = Path.GetDirectoryName(currentFile) + "\\" + "[Outline]_" + name + ".docx";
                //MessageBox.Show(filename.ToString());
                document.SaveAs2(ref filename);

                //Quit all process
                //Save change option
                object doNotSaveChanges = WdSaveOptions.wdDoNotSaveChanges;

                //Close word process
                document.Close(ref doNotSaveChanges, ref missing, ref missing);
                document = null;
                winword.Quit(ref doNotSaveChanges, ref missing, ref missing);
                winword = null;
                MessageBox.Show("Đã tạo tệp "+ "[Outline]_" + name + ".docx thành công!\r\nNgười dùng mở tập tin này bằng phần mềm M.Word,\r\nNhấn Ctrl + A để chọn hết sau đó nhấn chức năng Toggle Tex trên Tab MathType để chuyển công thức về dạng MathType.");
            }
            catch (Exception ex)
            {
                //Save change option
                object doNotSaveChanges = WdSaveOptions.wdDoNotSaveChanges;

                //Close word process
                document.Close(ref doNotSaveChanges, ref missing, ref missing);
                document = null;
                winword.Quit(ref doNotSaveChanges, ref missing, ref missing);
                winword = null;

                MessageBox.Show(ex.Message);
            }
        }
    }
}
