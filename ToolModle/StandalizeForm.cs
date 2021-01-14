using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.IO.Compression.FileSystem;
using System.IO.Compression;
//using SautinSoft.Document;

namespace unzipPackage.ToolModle
{
    //private DevExpress.XtraSplashScreen.SplashScreenManager capnhat;
    public partial class StandalizeForm : DevExpress.XtraEditors.XtraForm
    {
        String[] FilesSelected;
        public StandalizeForm()
        {
            InitializeComponent();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Excel File Dialog";
            //fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|Word Documents (*.docx; *.doc)|*.docx*; *.doc*";
            fdlg.FilterIndex = 2;
            fdlg.Multiselect = true;
            fdlg.RestoreDirectory = true;
            DialogResult result = fdlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                //txtPath.Text = fdlg.FileName;
                //String[] Files = fdlg.FileNames;// d.GetFiles("*.docx");
                FilesSelected = fdlg.FileNames;
                //StandardizedWordsDocument(Files);

                //capnhat.ShowWaitForm();
                //txtnoidung.LoadDocument(FilesSelected[0].ToString());
                //capnhat.CloseWaitForm();

                string txtPath1 = FilesSelected[0].ToString();//fdlg.FileName;
                splcapnhat.ShowWaitForm();
                txtnoidung.LoadDocument(txtPath1);
                splcapnhat.CloseWaitForm();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            keywrods_listBox.Items.Add(keyword_textBox.Text);
            keywordsRepalce_listBox.Items.Add(keywrodReplace_textBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (String file in FilesSelected)
            {
                string name = Path.GetFileNameWithoutExtension(file);// txtPath.Text);   
                string dirName = Path.GetDirectoryName(file);

                analyKeywords(file);
            }
        }

        //private void ConvertFromFile()
        //{
        //    foreach (String file in FilesSelected)
        //    {
        //        string inpFile = file;// FilesSelected[0].ToString();// @"..\..\example.docx";
        //        string outFile = @"Result.html";

        //        DocumentCore dc = DocumentCore.Load(inpFile);
        //        dc.Save(outFile);

        //        // Open the result for demonstration purposes.
        //        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
        //    }
        //}

        

        private void button2_Click(object sender, EventArgs e)
        {

            //ConvertFromFile();
            
            System.Diagnostics.Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.ToString().IndexOf("WINWORD") >= 0)
                    //MessageBox.Show(theprocess.ProcessName.ToString());
                    theprocess.Kill();
            }
            foreach (String file in FilesSelected)
            {
                splcapnhat.ShowWaitForm();
                txtnoidung.LoadDocument(file);
                //capnhat.CloseWaitForm();

                //MessageBox.Show("load file");    
                //splcapnhat.ShowWaitForm();
                StandardizedWordDocument(file);

                //check image WMF------------------------------
                
                string name = Path.GetFileNameWithoutExtension(file);// txtPath.Text);   
                string dirName = Path.GetDirectoryName(file);
                string fileNameTest = dirName + "\\" + "[Standardized]_" + name + ".docx";
                txtnoidung.LoadDocument(fileNameTest);
                splcapnhat.CloseWaitForm();

                if (imageEquation_checkbox.Checked == true)
                {
                    Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

                    
                    object missing = Missing.Value;
                    object readOnly = false;
                    //object readOnlyTemplate = true;
                    object isVisible = false;
                    object fileNameDocx = dirName + "\\" + "[Standardized]_" + name + ".docx";  //change fileName to path instead of txtPath !!!!
                    object fileNameDoc = dirName + "\\" + "[Standardized]_" + name + ".doc";  //change fileName to path instead of txtPath !!!!

                    //Create a new document  
                    Document document = winword.Documents.Open(ref fileNameDocx, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                    //MessageBox.Show("just opening");
                    document.SaveAs2(ref fileNameDoc);

                    //Create a new document  
                    document = winword.Documents.Open(ref fileNameDoc, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                    //MessageBox.Show("just opening");
                    document.SaveAs2(ref fileNameDocx);

                    //Quit all process
                    //Save change option
                    object doNotSaveChanges = WdSaveOptions.wdDoNotSaveChanges;

                    //Close word process
                    document.Close(ref doNotSaveChanges, ref missing, ref missing);
                    document = null;
                    winword.Quit(ref doNotSaveChanges, ref missing, ref missing);
                    winword = null;
                }

            }

            
                
                
        }

        private static void RemoveHighlightingFromRange(Microsoft.Office.Interop.Word.Range range)
        {
            range.Find.ClearFormatting();
            range.Find.ClearAllFuzzyOptions();
            range.Find.Highlight = 1;
            range.Find.Replacement.ClearFormatting();
            //range.Find.Replacement.Text = "";
            range.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
            range.Find.Execute(Replace: Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll);
        }
        private void StandardizedWordDocument(string path)
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
            object fileName = @path; //change fileName to path instead of txtPath !!!!
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
                document.Application.Selection.Find.ClearFormatting();


                if (stand_replaceCheck.Checked == true)
                    for (int icount = 0; icount < keywrods_listBox.Items.Count; icount++)
                        document.Application.Selection.Find.Execute(keywrods_listBox.Items[icount].ToString(), ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, keywordsRepalce_listBox.Items[icount].ToString(), WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);

                if (removeHighLight_checkBox.Checked == true)
                {
                    document.Range(start, end).HighlightColorIndex = 0;

                }

                if (removeNumbering_checkBox.Checked == true)
                {
                    document.Range(start, end).ListFormat.RemoveNumbers();
                }




                //MessageBox.Show("cutABCDCheck");
                //removeNumbering_checkBox

                if (cutABCDCheck.Checked == true)
                {
                    document.Application.Selection.Find.Execute("A.", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "A. ", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute("B.", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "B. ", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute("C.", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "C. ", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute("D.", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "D. ", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);

                    document.Application.Selection.Find.Execute("A. ", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "^pA. ", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute("B. ", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "^pB. ", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute("C. ", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "^pC. ", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute("D. ", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "^pD. ", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute("^p^p", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "^p", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                }

                //MessageBox.Show("removeLinesPhrases_checkBox");
                if (removeLinesPhrases_checkBox.Checked == true)
                {
                    start = document.Content.Start;
                    end = document.Content.End;
                    document.Range(start, end).Select();
                    document.Application.Selection.Find.ClearFormatting();

                    //document.Range(start, end).ListFormat.RemoveNumbers();
                    foreach (string item in listPhrases_listBox.Items)
                        document.Application.Selection.Find.Execute(item, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);

                    document.Application.Selection.Find.Execute("^p^p", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "^p", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                }

                //MessageBox.Show("emptyLines_checkBox4");
                if (emptyLines_checkBox4.Checked == true)
                    for (int i = 0; i < 10; i++)
                    {
                        start = document.Content.Start;
                        end = document.Content.End;
                        document.Range(start, end).Select();
                        document.Application.Selection.Find.ClearFormatting();

                        document.Application.Selection.Find.Execute("^p^p", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "^p", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    }

               
                
                 int   numQuestions = Int16.Parse(maxQuestions_textBox.Text);
                string[] arr1 = new string[numQuestions];

                //MessageBox.Show("addAnswerRows_checkBox");
                if (addAnswerRows_checkBox.Checked == true)
                {

                    for (int i = 0; i < numQuestions; i++)
                        arr1[i] = "";
                    foreach (string line in answers_textBox.Lines)
                    {
                        if (line.IndexOf(".") > 0)
                        {
                            string[] words = line.Split('.');
                            int quesIndex = Int16.Parse(words[0]);
                            arr1[quesIndex] = words[1].Trim();
                        }

                    }
                    for (int i = 2; i < numQuestions; i++)
                        if (arr1[i] != "")
                            document.Application.Selection.Find.Execute(beginQesPhrases_textBox.Text + " " + i.ToString() + ":", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, arr1[i-1] + "^p^p" + beginQesPhrases_textBox.Text + " " + i.ToString() + ":", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);


                }

                if (beginQesCheck_checkBox.Checked == true)
                {
                    document.Application.Selection.Find.Execute(beginQesPhrases_textBox.Text + " ^#^#:", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute(beginQesPhrases_textBox.Text + " ^#^#.", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute(beginQesPhrases_textBox.Text + "^#^#:", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute(beginQesPhrases_textBox.Text + "^#^#.", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);

                    document.Application.Selection.Find.Execute(beginQesPhrases_textBox.Text + " ^#:", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute(beginQesPhrases_textBox.Text + " ^#.", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute(beginQesPhrases_textBox.Text + "^#:", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                    document.Application.Selection.Find.Execute(beginQesPhrases_textBox.Text + "^#.", ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, "", WdReplace.wdReplaceAll, ref missing, ref missing, ref missing, ref missing);
                }

                //document.Application.Selection.ConvertToTable(WdTableFieldSeparator.wdSeparateByParagraphs, ref missing, ref missing, ref missing, WdTableFormat.wdTableFormatClassic1, true);
                //document.Application.Selection.ConvertToTable(WdTableFieldSeparator.wdSeparateByParagraphs,, ref missing, ref missing, ref missing, WdTableFormat.wdTableFormatClassic1, true);
                start = document.Content.Start;
                end = document.Content.End;
                document.Range(start, end).Select();
                document.Application.Selection.Find.ClearFormatting();

                if (table_checkBox.Checked == true)
                    document.Application.Selection.ConvertToTable(WdTableFieldSeparator.wdSeparateByParagraphs, ref missing, ref missing, ref missing, WdTableFormat.wdTableFormatGrid1, true,
                        ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);


                //System.Threading.Thread.Sleep(1000);
                //Save the document  
                string name = Path.GetFileNameWithoutExtension(path);// txtPath.Text);
                //name = ConvertToUnSign(name);
                //object filename = @txtSavePath.Text + "\\" + "[Standardized]_" + name + ".docx";
                object filename = Path.GetDirectoryName(path) + "\\" + "[Standardized]_" + name + ".docx";
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
                //MessageBox.Show("Đã tạo tệp thành công!");
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
        private void analyKeywords(string path)
        {
            //Create an instance for word app  
            Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

            //Set animation status for word application  
            winword.ShowAnimation = false;

            //Set status for word application is to be visible or not.  
            winword.Visible = false;

            //Create a missing variable for missing value  
            object missing = Missing.Value;

            object readOnly = false;
            //object readOnlyTemplate = true;
            object isVisible = false;
            object fileName = @path; //change fileName to path instead of txtPath !!!!
            //MessageBox.Show(fileName.ToString());
            string workingDirectory = Environment.CurrentDirectory;
            string runningPath = Directory.GetParent(workingDirectory).Parent.FullName;

            //Create a new document  
            Document document = winword.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);

            String read = string.Empty;
            List<string> data = new List<string>();
            for (int i = 0; i < document.Paragraphs.Count; i++)
            {
                string temp = document.Paragraphs[i + 1].Range.Text.Trim();
                wordsFrequence.Text += temp + "\r\n";
                if (temp != string.Empty)
                    data.Add(temp);
            }

        }
        private void countWordsInFile(string file, Dictionary<string, int> words)
        {
            var content = File.ReadAllText(file);

            var wordPattern = new Regex(@"\w+");

            foreach (Match match in wordPattern.Matches(content))
            {
                int currentCount = 0;
                words.TryGetValue(match.Value, out currentCount);

                currentCount++;
                words[match.Value] = currentCount;
            }
        }

        private void StandalizeForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (newPharase_textBox.Text != "")
            {
                listPhrases_listBox.Items.Add(newPharase_textBox.Text);
                //keywordsRepalce_listBox.Items.Add(keywrodReplace_textBox.Text);
                newPharase_textBox.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listPhrases_listBox.Items.Clear();
        }
    }
}