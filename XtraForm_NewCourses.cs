using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Download;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using System.Net;
using System.Threading;
using Google.Apis.Util.Store;
using System.IO.Compression;
using Ionic.Zip;
using System.Net.NetworkInformation;
using System.Xml;
using System.Globalization;

namespace unzipPackage
{
    public partial class XtraForm_NewCourses : DevExpress.XtraEditors.XtraForm
    {
        Teacherslist.ListCoursesToRun_Teacherslist listC2Ra = new Teacherslist.ListCoursesToRun_Teacherslist();
        public DataTable ds = new DataTable();
        string rootPath = "";
        string pathFileIni = "appInfo.ini";
        DriveService service1a;
        public XtraForm_NewCourses()
        {
            InitializeComponent();
        }
        public XtraForm_NewCourses(Teacherslist.ListCoursesToRun_Teacherslist listC2R)
        {
            InitializeComponent();
            listC2Ra = listC2R;
        }
        public XtraForm_NewCourses(string a)
        {
            InitializeComponent();
        }
        private void XtraForm_NewCourses_Load(object sender, EventArgs e)
        {
            initListCourse();
        }
        public void initListCourse()
        {
            readRootPath(pathFileIni);
            listDrivePatition();
            string[] scopes = new string[] { DriveService.Scope.Drive, // Full access
            DriveService.Scope.DriveReadonly,
            DriveService.Scope.DriveAppdata,
            DriveService.Scope.DriveFile,
            DriveService.Scope.DriveMetadata,
            DriveService.Scope.DriveMetadataReadonly,
            DriveService.Scope.DriveScripts };

            var keyFilePath = @"moodlehv-teacher-1594910513742-b991fcd2279e.p12";
            var serviceAccountEmail = "myaccount@moodlehv-teacher-1594910513742.iam.gserviceaccount.com";
            var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = scopes
            }.FromCertificate(certificate));

            service1a = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "MoodleHV Teachers 3",

            });
            ds.Columns.Add("Check", Type.GetType("System.Boolean"));
            ds.Columns.Add("CourseName1");
            ds.Columns.Add("updatedDate");
            ds.Columns.Add("CourseName");
            ds.Columns.Add("sizeMB");
            ds.Columns.Add("statusDU");
            ds.Columns.Add("status");
            ds.Columns.Add("Id");
            ds.Columns.Add("size");
            updateListCourses(service1a);
            removeOlderCoursesFromListDS();
            gridControl1.DataSource = ds;
        }
        private void coursesNewest_CheckedChanged(object sender, EventArgs e)
        {
            ds.Rows.Clear();
            updateListCourses(service1a);
            removeOlderCoursesFromListDS();
            gridControl1.DataSource = ds;
        }
        private void allCourses_CheckedChanged(object sender, EventArgs e)
        {
            ds.Rows.Clear();
            updateListCourses(service1a);
            gridControl1.DataSource = ds;
        }
        #region hiển thị course lên winform
        private void readRootPath(string pathFileIni)
        {
            try
            {
                using (StreamReader sr = System.IO.File.OpenText(pathFileIni))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        rootPath = s;
                    }
                    sr.Close();
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        public void listDrivePatition()
        {
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            string rootPath = "";
            node = myXmlDocument.DocumentElement;

            foreach (XmlNode nodechild in node.ChildNodes)
            {
                if (nodechild.Name == "rootDir")
                {
                    rootPath = nodechild.InnerText;
                }
            }

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            string presentDrivePatition = rootPath.Substring(0, 3);

            string driveInfo = "";
            foreach (DriveInfo d in allDrives)
            {
                driveInfo = "";
                Console.WriteLine("Drive {0}", d.Name);
                if (d.Name == presentDrivePatition)
                    diskPatitions.Text = presentDrivePatition;
                driveInfo += d.Name;
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  File system: {0}", d.DriveFormat);
                    Console.WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        d.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        d.TotalFreeSpace);
                    driveInfo += "FreeSpace: " + ((int)ConvertSize(d.TotalFreeSpace, "GB")).ToString() + "GB / ";
                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        d.TotalSize);
                    driveInfo += ((int)ConvertSize(d.TotalSize, "GB")).ToString() + "GB";
                }

                diskPatitions.Items.Add(driveInfo);
            }

        }
        public static double ConvertSize(double bytes, string type)
        {
            try
            {
                const int CONVERSION_VALUE = 1024;
                switch (type)
                {
                    case "BY":
                        //convert to bytes (default)
                        return bytes;
                    case "KB":
                        //convert to kilobytes
                        return (bytes / CONVERSION_VALUE);
                    case "MB":
                        //convert to megabytes
                        return (bytes / CalculateSquare(CONVERSION_VALUE));
                    case "GB":
                        //convert to gigabytes
                        return (bytes / CalculateCube(CONVERSION_VALUE));
                    default:
                        //default
                        return bytes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static double CalculateSquare(Int32 number)
        {
            return Math.Pow(number, 2);
        }
        public static double CalculateCube(Int32 number)
        {
            return Math.Pow(number, 3);
        }
        public void updateListCourses(DriveService service)
        {
            string folderId = "1HiuLTcwX2hdyWeN4zeUZ6kLOf17mFRR1";
            List<Google.Apis.Drive.v3.Data.File> filesList = new List<Google.Apis.Drive.v3.Data.File>();
            filesList = GoogleDrive.ListFiles(service, folderId);
            string[] words;
            string datetimeStr = "";

            //foreach (var file in filesList)
            //{
            //    ds.Rows.Add(false, file.Name, datetimeStr, file.Name, file.Size.ToString(), "", "", file.Id, file.Size);// i.ToString());
            //}

            foreach (var file in filesList)
            {
                if (file.Name.ToLower().IndexOf(".zip") < 0)
                    continue;
                string fileName = file.Name.Replace(".zip", "");
                words = fileName.Split('_');
                if (words.Length > 2)
                {
                    words[1] = words[1].Insert(2, ":");
                    words[2] = words[2].Insert(2, "/");
                    words[2] = words[2].Insert(5, "/");
                    datetimeStr = words[1] + ", " + words[2];
                    if (allCourses.Checked == true)
                    {
                        double sizeMB = ConvertBytesToMegabytes(long.Parse(file.Size.ToString()));
                        string sizeMBString = String.Format("{0:0.00}", sizeMB);

                        ds.Rows.Add(false, words[0], datetimeStr, file.Name, sizeMBString, "", "", file.Id, file.Size);// i.ToString());
                    }
                    if (coursesNewest.Checked == true)
                    {
                        try
                        {
                            string dateTime3 = datetimeStr;
                            string[] iDateNow = dateTime3.Split(',');
                            DateTime comparingDate = DateTime.ParseExact(iDateNow[1].Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            DateTime comparingDate_time = Convert.ToDateTime(iDateNow[0]);
                            bool justRemove = true;
                            for (int i = ds.Rows.Count - 1; i >= 0; i--)
                            {
                                string courseName = ds.Rows[i][1].ToString();
                                if (words[0] == courseName)
                                {
                                    string dateTime2 = ds.Rows[i][2].ToString();
                                    string[] iDate = dateTime2.Split(',');
                                    DateTime previousDate = DateTime.ParseExact(iDate[1].Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    DateTime previousDate_time = Convert.ToDateTime(iDate[0]);
                                    int result = DateTime.Compare(previousDate, comparingDate);
                                    int result_time = DateTime.Compare(previousDate_time, comparingDate_time);

                                    if (result < 0)
                                    {
                                        ds.Rows.RemoveAt(i);
                                    }
                                    else if (result == 0)
                                    {
                                        if (result_time <= 0)
                                            ds.Rows.RemoveAt(i);
                                        else
                                            justRemove = false;
                                    }
                                    else
                                    {
                                        justRemove = false;
                                        break;
                                    }
                                }
                            }
                            if (justRemove == true)
                            {
                                double sizeMB = ConvertBytesToMegabytes(long.Parse(file.Size.ToString()));
                                string sizeMBString = String.Format("{0:0.00}", sizeMB);
                                ds.Rows.Add(false, words[0], datetimeStr, file.Name, sizeMBString, "", "", file.Id, file.Size);
                            }
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine(Ex.ToString());
                        }
                    }
                }
            }

        }
        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
        public void removeOlderCoursesFromListDS()
        {
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            string newCourseName = "";
            for (int i = ds.Rows.Count - 1; i >= 0; i--)
            {
                newCourseName = ds.Rows[i]["CourseName1"].ToString();
                bool foundCourse = false;
                foreach (XmlNode nodechild in node.ChildNodes)
                {
                    if (nodechild.Name == newCourseName)
                    {
                        foundCourse = true;
                    }
                }
                if (foundCourse != false)
                {
                    foreach (XmlNode nodechild in node.ChildNodes)
                    {
                        if (nodechild.Name == newCourseName)
                        {
                            foreach (XmlNode nodechild1 in nodechild.ChildNodes)
                                if (nodechild1.Name == "date")
                                {
                                    if (ds.Rows[i]["updatedDate"].ToString() == nodechild1.InnerText)
                                        ds.Rows.RemoveAt(i);
                                    break;
                                }
                        }
                    }

                }
            }
        }

        #endregion

        private void diskPatitions_TextChanged(object sender, EventArgs e)
        {
            updateDiskPatitions();
        }
        public void updateDiskPatitions()
        {
            string folderName = "moodleLocalhost";
            rootPath = diskPatitions.Text.Substring(0, 3) + folderName;
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            foreach (XmlNode nodechild in node.ChildNodes)
            {
                if (nodechild.Name == "rootDir")
                {
                    nodechild.InnerText = rootPath;
                }
            }
            myXmlDocument.Save(@"coursesInfo.xml");
        }

        private void btntaikhoahoc_Click(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            string[] scopes = new string[] { DriveService.Scope.Drive, // Full access
                    DriveService.Scope.DriveAppdata,
                    DriveService.Scope.DriveFile,
                    DriveService.Scope.DriveMetadata,
                    DriveService.Scope.DriveScripts,
                    //DriveService.Scope.DriveReadonly,
                    DriveService.Scope.DrivePhotosReadonly,
                    };
            //string ACTIVITY_ID = "z12gtjhq3qn2xxl2o224exwiqruvtda0i";
            Console.WriteLine("Plus API - Service Account");
            Console.WriteLine("==========================");

            String serviceAccountEmail = "myaccount@moodlehv-teacher-1594910513742.iam.gserviceaccount.com";// "SERVICE_ACCOUNT_EMAIL_HERE";

            var certificate = new X509Certificate2(@"moodlehv-teacher-1594910513742-b991fcd2279e.p12", "notasecret", X509KeyStorageFlags.Exportable);

            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(serviceAccountEmail)
               {
                   Scopes = scopes //new[] { PlusService.Scope.PlusMe }
               }.FromCertificate(certificate));
            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "e-learningHVStudentDesktopApp",
            });
            
            string test = ds.Rows[0]["Check"].ToString();
            for (int i = 0; i < ds.Rows.Count; i++)
                if (ds.Rows[i]["Check"].ToString() != "")
                {
                    string strPercent = ds.Rows[i]["status"].ToString();
                    string strStatusDU = ds.Rows[i]["statusDU"].ToString();

                    if ((bool.Parse(ds.Rows[i]["Check"].ToString()) == true) && (strPercent == "100%") && (strStatusDU == "Finished"))
                        continue;
                    if (bool.Parse(ds.Rows[i]["Check"].ToString()) == true)
                    {
                        // ID File lấy tài khoản Google Drive của bạn 
                        string fileId = ds.Rows[i]["Id"].ToString();// "1RtPMXrk3WJ9QYwcM4ogBojgB-nOz63rn";
                        string PathToSave = ds.Rows[i]["CourseName"].ToString();
                        long fileSize = long.Parse(ds.Rows[i]["size"].ToString());
                        if ((strPercent != "") && (strPercent != "0%"))
                            continue;

                        Task.Run(() => { Download(service, fileId.ToString(), PathToSave, fileSize, this); });                     
                    }
                }
        }
        public void Download(DriveService service, string fileId, string localDestinationFilename, long fileSize, XtraForm_NewCourses parentForm)
        {
            XtraForm_NewCourses parent = parentForm;
            long totalSize = fileSize;// 100000;
            parent.updateStatusBar(0, "Downloading...", fileId);
            try
            {
                var request = service.Files.Get(fileId);
                using (var stream = new System.IO.FileStream(localDestinationFilename, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
                    {
                        switch (progress.Status)
                        {
                            case Google.Apis.Download.DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    parent.updateStatusBar((progress.BytesDownloaded * 100) / totalSize, "Downloading...", fileId);
                                    break;
                                }
                            case Google.Apis.Download.DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download complete.");
                                    parent.updateStatusBar(-1, localDestinationFilename, fileId);                                 
                                    string[] words = localDestinationFilename.Split('_');
                                    //MessageBox.Show("finished download");
                                    Task.Run(() => { MyExtract(localDestinationFilename, rootPath + "//" + words[0], this, fileId); });

                                    break;
                                }
                            case Google.Apis.Download.DownloadStatus.Failed:
                                {
                                    MessageBox.Show("Download failed.");
                                    Console.WriteLine("Download failed.");
                                    break;
                                }
                        }
                    };
                    request.DownloadWithStatus(stream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

        }
        public void updateStatusBar(long bytes, string msg, string fileId)
        {

            if (InvokeRequired)
            {
                Invoke(new Action<long, string, string>(updateStatusBar), new object[] { bytes, msg, fileId });
                return;
            }
            if (bytes == -1)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                    if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
                    {
                        gridView1.SetRowCellValue(i, "status", "100%");
                        gridView1.SetRowCellValue(i, "statusDU", "Done Download");
                    }
                //MessageBox.Show("Course: " + msg + " is downloaded " + fileId);
            }
            else
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                    if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
                    {
                        gridView1.SetRowCellValue(i, "status", bytes.ToString() + "%");
                        gridView1.SetRowCellValue(i, "statusDU", "Downloading");
                    }
            }
        }
        private void MyExtract(string zipToUnpack, string unpackDirectory, XtraForm_NewCourses parentForm, string fileId)
        {
            XtraForm_NewCourses parent = parentForm;
            //fileIdUnzipping = fileId;
            long filesExtracted = 0;

            bool finishedUnzip = false;
            //Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipToUnpack);
            using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipToUnpack))
            {
                int totalFiles = zip.Count;
                foreach (ZipEntry z in zip)
                {
                    try
                    {
                        filesExtracted++;
                        parent.updateStatusBarUnzip(100 * filesExtracted / totalFiles, "unzipping", fileId, zipToUnpack);
                        z.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                    }
                    catch (Exception ex)
                    {
                        //Write ex.ToString() to file and move on...
                        Console.WriteLine(ex.ToString());
                    }
                    if (totalFiles <= filesExtracted)
                    {
                        parent.updateStatusBarUnzip(-1, "unzipping", fileId, zipToUnpack);

                        finishedUnzip = true;
                    }
                }
            }
            if (finishedUnzip == true)
            {
                if (File.Exists(zipToUnpack) == true)
                    File.Delete(zipToUnpack);
                updateCoursesInfo();
            }
        }
        public void updateStatusBarUnzip(float bytes, string msg, string fileId, string zipToUnpack)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<float, string, string, string>(updateStatusBarUnzip), new object[] { bytes, msg, fileId, zipToUnpack });
                return;
            }
            if (bytes == -1)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                    if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
                    {
                        gridView1.SetRowCellValue(i, "status", "100%");
                        gridView1.SetRowCellValue(i, "statusDU", "Finished");
                    }
                for (int i = 0; i < gridView1.RowCount; i++)
                    if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
                    {
                        string courseName = ds.Rows[i]["CourseName1"].ToString(); 
                        setParasCourse(courseName);

                        break;
                    }
            }
            else
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                    if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
                    {
                        gridView1.SetRowCellValue(i, "status", bytes.ToString() + "%");
                        gridView1.SetRowCellValue(i, "statusDU", "Unzipping");
                    }
            }
        }
        public void updateCoursesInfo()
        {
            //update course info to xml file
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            // MessageBox.Show(node.Name);
            string newCourseName = "";
            for (int i = 0; i < ds.Rows.Count; i++)
                if (ds.Rows[i]["Check"].ToString() != "")
                {
                    string strPercent = ds.Rows[i]["status"].ToString();
                    string strStatusDU = ds.Rows[i]["statusDU"].ToString();
                    if ((bool.Parse(ds.Rows[i]["Check"].ToString()) == true) && (strPercent == "100%") && (strStatusDU == "Finished"))
                    {
                        newCourseName = ds.Rows[i]["CourseName1"].ToString();
                        bool foundCourse = false;
                        foreach (XmlNode nodechild in node.ChildNodes)
                        {
                            //MessageBox.Show(nodechild.Name);
                            if (nodechild.Name == "up_grade")
                            {
                                nodechild.InnerText = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                                Program.up_grade = nodechild.InnerText;
                            }

                            if (nodechild.Name == newCourseName)
                            {
                                foundCourse = true;
                            }
                        }

                        if (foundCourse == false)
                        {
                            //MessageBox.Show(newCourseName + " is a new course");
                            XmlElement courseInfo = myXmlDocument.CreateElement(newCourseName);
                            XmlElement bar = myXmlDocument.CreateElement("date");
                            bar.InnerText = ds.Rows[i]["updatedDate"].ToString();
                            courseInfo.AppendChild(bar);
                            myXmlDocument.DocumentElement.AppendChild(courseInfo);
                        }
                        else
                        {
                            //MessageBox.Show(newCourseName + " is NOT a new course");
                            foreach (XmlNode nodechild in node.ChildNodes)
                            {
                                if (nodechild.Name == newCourseName)
                                {
                                    foreach (XmlNode nodechild1 in nodechild.ChildNodes)
                                        if (nodechild1.Name == "date")
                                        {
                                            nodechild1.InnerText = ds.Rows[i]["updatedDate"].ToString();
                                            Program.up_grade = nodechild.InnerText;
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
            myXmlDocument.Save(@"coursesInfo.xml");
        }
        public void setParasCourse(string courseName)
        {
            Form1_student originalForm = new Form1_student();
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            string rootPath = "";
            node = myXmlDocument.DocumentElement;

            //bool foundRootDir = false;
            foreach (XmlNode nodechild in node.ChildNodes)
            {
                if (nodechild.Name == "rootDir")
                {
                    rootPath = nodechild.InnerText;
                    //foundRootDir = true;
                    break;
                }
            }
            string path1 = rootPath + "\\" + courseName;
            changeParaDirectories(path1, path1);
            string fileName = path1 + "\\starMoodle.bat";
            try
            {
                string content = "";
                {

                    content = "CD " + rootPath + "\\" + courseName + "\r\n";
                    string partitionName = rootPath.Substring(0, rootPath.IndexOf(":") + 1);
                    //MessageBox.Show(partitionName);

                    content += partitionName + "\r\n";
                    content += rootPath + "\\" + courseName + "\\StartMoodle.exe";
                    //MessageBox.Show(content);

                    using (FileStream fs = System.IO.File.Create(fileName))
                    {
                        // Add some text to file    
                        Byte[] title = new UTF8Encoding(true).GetBytes(content);
                        fs.Write(title, 0, title.Length);
                        fs.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            fileName = path1 + "\\stopMoodle.bat";

            try
            {
                string content = "";
                {

                    content = "CD " + rootPath + "\\" + courseName + "\r\n";
                    string partitionName = rootPath.Substring(0, rootPath.IndexOf(":") + 1);
                    //MessageBox.Show(partitionName);

                    content += partitionName + "\r\n";
                    content += rootPath + "\\" + courseName + "\\StopMoodle.exe";
                    //MessageBox.Show(content);

                    using (FileStream fs = System.IO.File.Create(fileName))
                    {
                        // Add some text to file    
                        Byte[] title = new UTF8Encoding(true).GetBytes(content);
                        fs.Write(title, 0, title.Length);
                        fs.Close();
                    }
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            capnhatdiem(courseName);
        }
        void capnhatdiem(string name_)
        {
            RegistryWriter rg = new RegistryWriter();
            if (Program.GV == "1")//1 la hoc sinh khac 1 la giao vien
            {
                rg.WriteKey(name_, 0.ToString());
                string _GV = rg.valuekey(name_ + "_GV");
                if (_GV == "null")
                    rg.WriteKey(name_ + "_GV", 0.ToString());
                string HS = rg.valuekey(name_);
                if (HS == "null")
                    rg.WriteKey(name_, 0.ToString());
                rg.WriteKey(name_ + "_completionstate", 0.ToString());
            }
            else
            {
                rg.WriteKey(name_ + "_GV_KT", 0.ToString());
                string _GV = rg.valuekey(name_ + "_GV");
                if (_GV == "null")
                    rg.WriteKey(name_ + "_GV", 0.ToString());
                string HS = rg.valuekey(name_);
                if (HS == "null")
                    rg.WriteKey(name_, 0.ToString());
                string completions = rg.valuekey(name_ + "_completions");
                if (completions == "null")
                    rg.WriteKey(name_ + "_completions", 0.ToString());
            }
        }
        public void changeParaDirectories(string moodlePath, string rootPath1)
        {
            try
            {
                string fileName = moodlePath + "\\server\\moodle\\config.php";

                string content = "";
                // Open the stream and read it back.    
                using (StreamReader sr = System.IO.File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.IndexOf("$CFG->dataroot") >= 0)
                        {
                            s = "$CFG->dataroot = '" + rootPath1 + "\\\\server\\\\moodledata';";
                        }
                        content += s + "\r\n";
                    }
                    sr.Close();
                    if (System.IO.File.Exists(fileName))
                    {
                        System.IO.File.Delete(fileName);
                    }
                    using (FileStream fs = System.IO.File.Create(fileName))
                    {
                        // Add some text to file    
                        Byte[] title = new UTF8Encoding(true).GetBytes(content);
                        fs.Write(title, 0, title.Length);
                        fs.Close();
                    }
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        #region giải nén
        public void unzipStuffs()
        {
            string folderName = "moodleLocalhost";
            //string pathToZipFile = "";
            rootPath = diskPatitions.Text.Substring(0, 3) + folderName;
            //MessageBox.Show(rootPath);
            //save rootPath to ini file
            saveRootToFile(pathFileIni, rootPath);
            string[] words;

            for (int i = 0; i < ds.Rows.Count; i++)
                if (ds.Rows[i]["Check"].ToString() != "")
                    if (bool.Parse(ds.Rows[i]["Check"].ToString()) == true)
                    {
                        words = ds.Rows[i]["CourseName"].ToString().Split('_');

                        if ((words.Length >= 1) && (File.Exists(ds.Rows[i]["CourseName"].ToString()) == true))
                        {
                            string fileId = ds.Rows[i]["Id"].ToString();
                            string PathToSave = ds.Rows[i]["CourseName"].ToString();
                            Task.Run(() => { MyExtract(PathToSave, rootPath + "//" + words[0], this, fileId); });
                        }
                    }
        }
        private void saveRootToFile(string fileName, string content)
        {
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    // Add some text to file    
                    Byte[] title = new UTF8Encoding(true).GetBytes(content);
                    fs.Write(title, 0, title.Length);
                    fs.Close();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        #endregion
        private void btnUnzipandInstall_Click(object sender, EventArgs e)
        {
            unzipStuffs();
        }

        private void XtraForm_NewCourses_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}