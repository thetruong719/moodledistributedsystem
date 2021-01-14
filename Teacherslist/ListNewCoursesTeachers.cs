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
//using Ionic.Zip;
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

//import com.google.api.services.drive.Drive;
//import com.google.api.services.drive.Drive.Files;
//import com.google.api.services.drive.model.File;

namespace unzipPackage.Teacherslist
{
    public partial class ListNewCoursesTeachers : DevExpress.XtraEditors.XtraForm
    {
        Class.cls_course clc = new Class.cls_course();
        //grade x folder for courses
        string[] gradesFolders = {
            "18OwYSJU2rhY84BXagwtukC5o0iKm6N4A", //grade1
            "1PsdajHA6qvHB16GQOBVOSZHkHVojOEuA", //grade2
            "1Nr9f0xMP4gCy3WEWhViwyPh1hZ0DmM-Y", //grade3
            "1CKRgrAHyc6CLiZFk1rNExqLo9X84ET4j", //grade4
            "1hD7vGxKgm6XgUoyV4558IBVVItIvK5U8", //grade5
            "14WTUbjpDHg3bgOdDiJbGUsikfyx6NJMA", //grade6
            "1HiuLTcwX2hdyWeN4zeUZ6kLOf17mFRR1", //grade7
            "1d5DDe67iBHrF3kLl_d-Zb2T8yc4aDy5T", //grade8
            "1qm_cFeepHRuD2q2IKuY_-40YJxUKMUqK", //grade9
            "1vjTJQ7kWuDyuEahg_HrI-1i_DyF_HRSs", //grade10
            "1e8veHoCi8IJEw3pv-1UBKcPSwccZBuCY", //grade11
            "1CJd84yjEZYWEUZwO4rt7ktO_fD4LtKj5" }; //grade12
           
        ListCoursesToRun_Teacherslist listC2Ra = new ListCoursesToRun_Teacherslist();
        public ListNewCoursesTeachers()
        {
            InitializeComponent();
        }
        public ListNewCoursesTeachers(ListCoursesToRun_Teacherslist listC2R)
        {
            InitializeComponent();
            listC2Ra = listC2R;
        }
        public ListNewCoursesTeachers(string a)
        {
            InitializeComponent();
            //MessageBox.Show(a);
            //ds.Columns.Add("Check", Type.GetType("System.Boolean"));
            //ds.Columns.Add("CourseName");
            //for (int i = 0; i < 10; i++)
            //{
            //    ds.Rows.Add(false, i.ToString());
            //}
            //gridControl1.DataSource = ds;
        }
        public DataTable ds = new DataTable();
        string rootPath = "";
        string pathFileIni = "appInfo.ini";
        //private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        //private System.Windows.Forms.OpenFileDialog openFileDialog3;

        private void ListNewCourses_Load(object sender, EventArgs e)
        {
            //ds.Columns.Add("CourseName");
            //ds.Columns.Add("Check", Type.GetType("System.Boolean"));
            
            
            //for (int i = 0; i < 10; i++)
            //{
            //    ds.Rows.Add(false, i.ToString());
            //}
            //gridControl1.DataSource = ds;
        }

        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        static string[] Scopes = { DriveService.Scope.DriveReadonly };
        //static string ApplicationName = "Drive API .NET Quickstart";

        public long GetFileSize(string fileId)
        {
            /*
            //!string[] scopes = new string[] { DriveService.Scope.Drive }; // Full access

            var keyFilePath = @"moodlehv-teacher-1594910513742-b991fcd2279e.p12";// @"c:\file.p12";    // Downloaded from https://console.developers.google.com
            var serviceAccountEmail = "myaccount@moodlehv-teacher-1594910513742.iam.gserviceaccount.com";// "xx@developer.gserviceaccount.com";  // found https://console.developers.google.com

            //loading the Key file
            var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                //!Scopes = scopes
                Scopes = Scopes
            }.FromCertificate(certificate));

            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "MoodleHV Teachers 3",

            });
            */
            UserCredential credential;
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "MoodleHV Teachers 3",
            });

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name, size)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            Console.WriteLine("Files:");
            if (files != null && files.Count > 0 && files.Count <20)
            {
                foreach (var file in files)
                    if (file.Id == fileId)
                    {
                        Console.WriteLine("{0} ({1}) ({2})", file.Name, file.Id, file.Size);
                        return long.Parse(file.Size.ToString());
                    }
                //{
                //    Console.WriteLine("{0} ({1}) ({2})", file.Name, file.Id,file.Size);
                //}
            }
            else
            {
                Console.WriteLine("No files found.");
                return 0;
            }
            Console.Read();
            MessageBox.Show("just update!");
            return 0;
        }

        private async Task<long> GetFileSize1(string fileId)
        {
            UserCredential credential;
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "MoodleHV Teachers 3",
            });

            var file = await service.Files.Get(fileId).ExecuteAsync();
            var size = file.Size;//.size;
            return long.Parse(size.ToString());
        }

        const int KB_ = 0x400;
        //int ChunkSize1 = 256 * KB_;//256 * KB; // 256KB;
        //private async Task DownloadFile(DriveService service, string url)
        //{
        //    //var downloader = new MediaDownloader(service);
        //    //downloader.ChunkSize = ChunkSize1;
        //    //// add a delegate for the progress changed event for writing to console on changes
        //    //downloader.ProgressChanged += Download_ProgressChanged;

        //    //// figure out the right file type base on UploadFileName extension
        //    //var lastDot = UploadFileName.LastIndexOf('.');
        //    //var fileName = DownloadDirectoryName + @"\Download" +
        //    //    (lastDot != -1 ? "." + UploadFileName.Substring(lastDot + 1) : "");
        //    //using (var fileStream = new System.IO.FileStream(fileName,
        //    //    System.IO.FileMode.Create, System.IO.FileAccess.Write))
        //    //{
        //    //    var progress = await downloader.DownloadAsync(url, fileStream);
        //    //    if (progress.Status == DownloadStatus.Completed)
        //    //    {
        //    //        Console.WriteLine(fileName + " was downloaded successfully");
        //    //    }
        //    //    else
        //    //    {
        //    //        Console.WriteLine("Download {0} was interpreted in the middle. Only {1} were downloaded. ",
        //    //            fileName, progress.BytesDownloaded);
        //    //    }
        //    //}
        //}

        const int KB = 0x400;
        int ChunkSize = 128 * KB;//256 * KB; // 256KB;
        //public async Task ExportFileAsync(string downloadFileName, string fileId, string exportMimeType)
        public async         //public async Task ExportFileAsync(string downloadFileName, string fileId, string exportMimeType)
        Task ExportFileAsync(string downloadFileName, string fileId, string exportMimeType)
        {
            /*
            string[] scopes = new string[] { DriveService.Scope.Drive }; // Full access

            var keyFilePath = @"moodlehv-teacher-1594910513742-b991fcd2279e.p12";// @"c:\file.p12";    // Downloaded from https://console.developers.google.com
            var serviceAccountEmail = "myaccount@moodlehv-teacher-1594910513742.iam.gserviceaccount.com";// "xx@developer.gserviceaccount.com";  // found https://console.developers.google.com

            //loading the Key file
            var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = scopes
            }.FromCertificate(certificate));

            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "MoodleHV Teachers 3",

            });
            */
            UserCredential credential;
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "MoodleHV Teachers 3",
            });
            //MessageBox.Show(exportMimeType.ToString());
            var exportRequest = service.Files.Export(fileId, exportMimeType);
            var client = exportRequest.Service.HttpClient;

            //you would need to know the file size
            //var size =  await GetFileSize(fileId); //205058560;//
            var size = GetFileSize(fileId); //617661783; // 623;// GetFileSize(fileId); //928471708;// 299396;// 617661783;// fileSize;// GetFileSize
            //var size = await GetFileSize1(fileId); //617661783; // 623;// GetFileSize(fileId); //928471708;// 299396;// 617661783;// fileSize;// 
            //MessageBox.Show("just update!" + GetFileSize(fileId).ToString()); //(fileId); //205058560;//   //617.661.783
            //623 
            MessageBox.Show(size.ToString());
            File.Delete(downloadFileName);
            using (var file = new FileStream(downloadFileName, FileMode.CreateNew, FileAccess.ReadWrite))
            {

                file.SetLength(size);

                var chunks = (size / ChunkSize) + 1;
                for (long index = 0; index < chunks; index++)
                {
                    Console.WriteLine(index.ToString() + " / " + chunks.ToString());
                    var request = exportRequest.CreateRequest();

                    var from = index * ChunkSize;//0
                    var to = from + ChunkSize - 1;//0

                    request.Headers.Range = new RangeHeaderValue(from, to);

                    var response = await client.SendAsync(request);

                    if (response.StatusCode == HttpStatusCode.PartialContent || response.IsSuccessStatusCode)
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            file.Seek(from, SeekOrigin.Begin);
                            await stream.CopyToAsync(file);
                        }
                    }
                }
            }
        }

        public async         //public async Task ExportFileAsync(string downloadFileName, string fileId, string exportMimeType)
        Task ExportFileAsync_test(string downloadFileName, string fileId, string exportMimeType)
        {
            
            string[] scopes = new string[] { DriveService.Scope.Drive }; // Full access

            var keyFilePath = @"moodlehv-teacher-1594910513742-b991fcd2279e.p12";// @"c:\file.p12";    // Downloaded from https://console.developers.google.com
            var serviceAccountEmail = "myaccount@moodlehv-teacher-1594910513742.iam.gserviceaccount.com";// "xx@developer.gserviceaccount.com";  // found https://console.developers.google.com

            //loading the Key file
            var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = scopes
            }.FromCertificate(certificate));

            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "MoodleHV Teachers 3",

            });
            
            //MessageBox.Show(exportMimeType.ToString());
            var exportRequest = service.Files.Export(fileId, exportMimeType);
            var client = exportRequest.Service.HttpClient;

            var request = exportRequest.CreateRequest();
            var response = await client.SendAsync(request);
            /*
            //you would need to know the file size
            //var size =  await GetFileSize(fileId); //205058560;//
            var size = GetFileSize(fileId); //617661783; // 623;// GetFileSize(fileId); //928471708;// 299396;// 617661783;// fileSize;// GetFileSize
            //var size = await GetFileSize1(fileId); //617661783; // 623;// GetFileSize(fileId); //928471708;// 299396;// 617661783;// fileSize;// 
            //MessageBox.Show("just update!" + GetFileSize(fileId).ToString()); //(fileId); //205058560;//   //617.661.783
            //623 
            MessageBox.Show(size.ToString());
            File.Delete(downloadFileName);
            using (var file = new FileStream(downloadFileName, FileMode.CreateNew, FileAccess.ReadWrite))
            {

                file.SetLength(size);

                var chunks = (size / ChunkSize) + 1;
                for (long index = 0; index < chunks; index++)
                {
                    Console.WriteLine(index.ToString() + " / " + chunks.ToString());
                    var request = exportRequest.CreateRequest();

                    var from = index * ChunkSize;//0
                    var to = from + ChunkSize - 1;//0

                    request.Headers.Range = new RangeHeaderValue(from, to);

                    var response = await client.SendAsync(request);

                    if (response.StatusCode == HttpStatusCode.PartialContent || response.IsSuccessStatusCode)
                    {
                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            file.Seek(from, SeekOrigin.Begin);
                            await stream.CopyToAsync(file);
                        }
                    }
                }
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
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

            //UserCredential credentials;
            //return credentials;

            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "e-learningHVStudentDesktopApp",
                //"MoodleHV Teachers 3",

            });

            //Google.Apis.Drive.v3.Data.File f = null;
            //string FileID = "1VzpP1MGowpU8XHwLQfzakPw3YyKISJa4";// "1CYQ2gOBdjlWb_iXJkI-BQoor229nOr0L";// "1xQlEntUf-wctzhzCD-22k4KIaTPg_vMU";// "1VzpP1MGowpU8XHwLQfzakPw3YyKISJa4";// "1SwoNpemcDCtRpnJvAUiXE-0Sjbq0y_NS";//
            // @"Mathematics07_14072020_15h30.zip";// @"DONE_HOC247DB.rar";// "MyFiles_MathMoodle3.zip";// "helloThang.txt";

            //GoogleDrive.Download(service, FileID, PathToSave);


            //service.HttpClient.Timeout = TimeSpan.FromMinutes(10000);
            //using (var wc = new System.Net.WebClient())
            //{
            //    wc.DownloadFile("https://drive.google.com/u/0/uc?export=download&confirm=vI6r&id=1VzpP1MGowpU8XHwLQfzakPw3YyKISJa4", "MyFiles_MathMoodle3.zip");
            //}
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
                        string PathToSave = ds.Rows[i]["CourseName"].ToString();// + ".zip";
                        //ds.Columns.Add("updatedDate");
                        //var request = service.Files.Get(fileId);


                        long fileSize = long.Parse(ds.Rows[i]["size"].ToString());
                        if ((strPercent != "") && (strPercent != "0%"))
                            continue;

                        Task.Run(() => { Download(service, fileId.ToString(), PathToSave, fileSize, this); });
                        //Task.Run(() => { Download(service, "1DtFxJwIngCnCDknteOnZa4yTtp_1Z9JB", PathToSave, fileSize, this); });
                        //Thread.Sleep(1000);                        
                    }
                }
        }

        public void updateStatusBar(long bytes, string msg,string fileId)
        {
            
            if (InvokeRequired)
            {
                Invoke(new Action<long, string,string>(updateStatusBar), new object[] { bytes, msg, fileId });
                return;
            }
            if (bytes == -1)
            {
                //ds.Rows[rowId].va = "100";
                //gridControl1.s.SetRowCellValue(rowId, "status", "OK");
                //gridView1.SetRowCellValue(1, "status", "100%");
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
                //progressBar.Value = (int)bytes; //20;// 
                for (int i = 0; i < gridView1.RowCount; i++)
                    if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
                    {
                        gridView1.SetRowCellValue(i, "status", bytes.ToString() + "%");
                        gridView1.SetRowCellValue(i, "statusDU", "Downloading");
                    }
                //if (progressBar.Value == 100)
                //    MessageBox.Show("Download Completed");
            }
            //lblProgress.Text = msg;
            //lblProgress.Location = new Point(this.ClientRectangle.Width - lblProgress.Width - progressBar.Width - 20, 4);

        }

        //public static parentForm = 0;
        public void Download(DriveService service, string fileId, string localDestinationFilename, long fileSize, ListNewCoursesTeachers parentForm)
        {
            ListNewCoursesTeachers parent= parentForm;
            long totalSize = fileSize;// 100000;
            parent.updateStatusBar(0, "Downloading...", fileId);

            //parent.ds.Rows[5]["status"] = bytesDownloaded1.ToString();
            try
            {
                var request = service.Files.Get(fileId);
                using (var stream = new System.IO.FileStream(localDestinationFilename, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    //parent = parentForm;
                    //parent.ds.Rows[5]["status"] = bytesDownloaded1.ToString();
                    //parent.gridControl1.DataSource = ds;
                    //Google.Apis.Download.IDownloadProgress x = await request.DownloadAsync(stream);
                    //Google.Apis.Download.IDownloadProgress x = request.DownloadWithStatus(stream);

                    //Console.WriteLine("status: " + x.Status.ToString() + "downloaded: "+ x.BytesDownloaded.ToString());
                    //bytesDownloaded1 = x.BytesDownloaded;
                    //request.DownloadAsync(stream);

                    request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
                    {
                        switch (progress.Status)
                        {
                            case Google.Apis.Download.DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    //bytesDownloaded1 = long.Parse(progress.BytesDownloaded.ToString());
                                    parent.updateStatusBar((progress.BytesDownloaded * 100) / totalSize, "Downloading...", fileId);
                                    //bytesDownloaded.Text = progress.BytesDownloaded.ToString();

                                    //bytesDownloaded.Text = bytesDownloaded1.ToString();
                                    //ds.Rows[5]["status"] = bytesDownloaded1.ToString();
                                    //gridControl1.DataSource = ds;
                                    //MessageBox.Show(bytesDownloaded1.ToString());
                                    //return bytesDownloaded1;
                                    //await updateStatus();
                                    break;
                                }
                            case Google.Apis.Download.DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download complete.");
                                    parent.updateStatusBar(-1, localDestinationFilename, fileId);
                                   // MessageBox.Show("done download");
                                    //call unzip stuffs                                   
                                    //readRootPath(pathFileIni);                                    
                                    string[] words = localDestinationFilename.Split('_');
                                    //MessageBox.Show("finished download");
                                    Task.Run(() => { MyExtract(localDestinationFilename, rootPath + "//" + words[0], this, fileId); });  
                                                                      
                                    break;
                                }
                            case Google.Apis.Download.DownloadStatus.Failed:
                                {
                                    Console.WriteLine("Download failed.");
                                    break;
                                }
                        }
                    };
                    // request.Download(stream);
                    request.DownloadWithStatus(stream);
                    //await request.DownloadAsync(stream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            //call set para
            //setParas();

        }
        /// <summary>
        /// Function to calculate the square of the provided number
        /// </summary>
        /// <param name="number">Int32 -> Number to be squared</param>
        /// <returns>Double -> THe provided number squared</returns>
        /// <remarks></remarks>
        public static double CalculateSquare(Int32 number)
        {
            return Math.Pow(number, 2);
        }


        /// <summary>
        /// Function to calculate the cube of the provided number
        /// </summary>
        /// <param name="number">Int32 -> Number to be cubed</param>
        /// <returns>Double -> THe provided number cubed</returns>
        /// <remarks></remarks>
        public static double CalculateCube(Int32 number)
        {
            return Math.Pow(number, 3);
        }

        public static double ConvertSize(double bytes, string type)
        {
            try
            {
                const int CONVERSION_VALUE = 1024;
                //determine what conversion they want
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
        
        private void ListNewCourses_Load_1(object sender, EventArgs e)
        {
            //bring to front
            //this.WindowState = FormWindowState.Minimized;
            //this.Show();
            //this.WindowState = FormWindowState.Normal;
            //if (WindowState == FormWindowState.Minimized)
            //    WindowState = FormWindowState.Normal;
            //else
            //{
            //    TopMost = true;
            //    Focus();
            //    BringToFront();
            //    TopMost = false;
            //}
            monhoc();
            initListCourse();

            //update subjects name to courseInfo.xml
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            //string rootPath = originalForm.readRootPath(originalForm.pathFileIni);
            //string rootPath = "";// originalForm.readRootPath(originalForm.pathFileIni);
            node = myXmlDocument.DocumentElement;

            //if (subjectSelect.Text != "")
                foreach (XmlNode nodechild in node.ChildNodes)
                {                    
                    if (nodechild.Name == "teacherSubject")
                    {
                    if (nodechild.InnerText != "")
                        subjectSelect.Text = nodechild.InnerText;
                        //nodechild.InnerText = subjectSelect.Text;//DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        //Program.up_grade = nodechild.InnerText;
                    }                    
                }
            //myXmlDocument.Save(@"coursesInfo.xml");
            grimonhoc_EditValueChanged(null, null);
        }
        DataTable dsmonhoc = new DataTable();
        void monhoc()
        {
            Program.Name_Courses = "moodle_offline_10";
            dsmonhoc = clc.GiaoVien_MonHoc_DS_IDGV(int.Parse(Program.ID_GV));
            grimonhoc.EditValue = null;
            grimonhoc.Properties.DisplayMember = "MonHoc";
            grimonhoc.Properties.ValueMember = "MonHoc";
            grimonhoc.Properties.PopupFormSize = new Size(120, 90);
            grimonhoc.Properties.DataSource = dsmonhoc;
            if (dsmonhoc.Rows.Count > 0)
                grimonhoc.EditValue = dsmonhoc.Rows[0]["MonHoc"].ToString();


        }
        public void listDrivePatition()
        {
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            //string rootPath = originalForm.readRootPath(originalForm.pathFileIni);
            string rootPath = "";// originalForm.readRootPath(originalForm.pathFileIni);
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

        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public void getCourseInFolders(DriveService service, string folderId ,string teacherSubject)
        {
            //string[] parentFolderId = "1_Afbct4lzdLKWmAGNaSBmPAai5oZYIpF";// GoogleDrive.SearchForFileId(service1a, "Grader-7", false);
            //string folderId = "1HiuLTcwX2hdyWeN4zeUZ6kLOf17mFRR1";// "1_Afbct4lzdLKWmAGNaSBmPAai5oZYIpF";            
            List<Google.Apis.Drive.v3.Data.File> filesList = new List<Google.Apis.Drive.v3.Data.File>();

            filesList = GoogleDrive.ListFiles(service, folderId);
            string[] words;
            string datetimeStr = "";

            foreach (var file in filesList)
            {
                //only show .zip files
                if (file.Name.ToLower().IndexOf(".zip") < 0)
                    continue;

                string fileName = file.Name.Replace(".zip", "");

                //MessageBox.Show(teacherSubject);
                if (fileName.IndexOf(teacherSubject) < 0)
                    continue;
                //MessageBox.Show("file: " + file.Name + " id: " + file.Id);
                words = fileName.Split('_');
                if (words.Length > 2)
                {
                    words[1] = words[1].Insert(2, ":");
                    words[2] = words[2].Insert(2, "/");
                    words[2] = words[2].Insert(5, "/");
                    datetimeStr = words[1] + ", " + words[2];
                    if (listNewCoursesMethod.SelectedItem.ToString().Trim() == "Toàn bộ các khóa học".Trim())
                    //if (allCourses.Checked == true)
                    {
                        if (fileName.IndexOf("_NotYetConfirmed") > 0)
                            continue;
                        double sizeMB = ConvertBytesToMegabytes(long.Parse(file.Size.ToString()));
                        string sizeMBString = String.Format("{0:0.00}", sizeMB);

                        ds.Rows.Add(false, words[0], datetimeStr, file.Name, sizeMBString, "", "", file.Id, file.Size);// i.ToString());
                    }
                    if (listNewCoursesMethod.SelectedItem.ToString().Trim() == "Các khóa học mới nhất".Trim())
                    //if (coursesNewest.Checked == true)
                    {
                        if (fileName.IndexOf("_NotYetConfirmed") > 0)
                            continue;
                        //words[1].Insert(2,":")+", "+words[2].Insert(2,"/").Insert(5, "/")
                        try
                        {
                            string dateTime3 = datetimeStr;
                            string[] iDateNow = dateTime3.Split(',');// "05/05/2005";

                            //DateTime date = new DateTime(2011, 2, 19);
                            //string formatted = date.ToString("dd/M/yyyy");

                            DateTime comparingDate = DateTime.ParseExact(iDateNow[1].Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                            //DateTime comparingDate = DateTime.ParseExact("24/01/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture);

                            //DateTime comparingDate = Convert.ToDateTime(iDateNow[1]);
                            DateTime comparingDate_time = Convert.ToDateTime(iDateNow[0]);
                            bool justRemove = true;
                            //remove the older versions
                            for (int i = ds.Rows.Count - 1; i >= 0; i--)
                            {
                                string courseName = ds.Rows[i][1].ToString();
                                if (words[0] == courseName)
                                {
                                    string dateTime2 = ds.Rows[i][2].ToString();
                                    string[] iDate = dateTime2.Split(',');// "05/05/2005";
                                    //DateTime previousDate = Convert.ToDateTime(iDate[1]);
                                    DateTime previousDate = DateTime.ParseExact(iDate[1].Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    DateTime previousDate_time = Convert.ToDateTime(iDate[0]);
                                    //MessageBox.Show(previousDate.Day + " " + previousDate.Month + "  " + previousDate.Year);

                                    int result = DateTime.Compare(previousDate, comparingDate);
                                    int result_time = DateTime.Compare(previousDate_time, comparingDate_time);

                                    if (result < 0)
                                    {
                                        //MessageBox.Show("is earlier than");
                                        ds.Rows.RemoveAt(i);
                                    }
                                    else if (result == 0)
                                    {
                                        //MessageBox.Show("is the same time as");
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
                                    //    MessageBox.Show("is later than");
                                    //if (result < 0)                                     
                                }
                            }
                            if (justRemove == true)
                            {
                                double sizeMB = ConvertBytesToMegabytes(long.Parse(file.Size.ToString()));
                                string sizeMBString = String.Format("{0:0.00}", sizeMB);
                                //ds.Rows.Add(false, words[0], datetimeStr, file.Name, "", "", file.Id, file.Size);// i.ToString());
                                ds.Rows.Add(false, words[0], datetimeStr, file.Name, sizeMBString, "", "", file.Id, file.Size);// i.ToString());                                
                            }
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine(Ex.ToString());
                        }
                    }
                    else
                        if (listNewCoursesMethod.SelectedItem.ToString().Trim() == "Các khóa học chưa được thẩm định")
                    //if (allCourses.Checked == true)
                    {
                        double sizeMB = ConvertBytesToMegabytes(long.Parse(file.Size.ToString()));
                        string sizeMBString = String.Format("{0:0.00}", sizeMB);
                        if (file.Name.IndexOf("NotYetConfirmed") >= 0)
                            ds.Rows.Add(false, words[0], datetimeStr, file.Name, sizeMBString, "", "", file.Id, file.Size);// i.ToString());
                    }
                }
            }
        }

        public string convertSubjectNameToEnglish(string teacherSubject)
        {
            //int caseSwitch = 1;
            
            switch (teacherSubject)
            {
                case "Tiếng Việt":
                    return "Vietnamese";                    
                case "Ngữ Văn":
                    return "Literatures";
                case "Tiếng Anh":
                    return "English";
                case "Toán học":
                    return "Mathematics";
                case "Vật lý":
                    return "Physics";
                case "Hóa học":
                    return "Chemistry";
                case "Sinh học":
                    return "Biology";
                case "Tin học":
                    return "Informatics";
                case "Lịch sử":
                    return "History";
                case "Địa lý":
                    return "Geography";
                case "GDCD":
                    return "CivicEducation";
                case "Kỹ năng sống":
                    return "LifeSkills";
                case "Toán và Tiếng Việt":
                    return "MathViet";
                default:
                    return "";
                    
            }
        }

        public void updateListCourses(DriveService service)
        {
            string teacherSubject = "";
            //if (subjectSelect.Text != "")
            //    teacherSubject = subjectSelect.Text;

            teacherSubject = convertSubjectNameToEnglish(subjectSelect.Text);
            foreach (string folderId in gradesFolders)
                getCourseInFolders(service, folderId, teacherSubject);
        }
        public void updateListCourses_(DriveService service)
        {
            string teacherSubject = "";
            //if (subjectSelect.Text != "")
            //    teacherSubject = subjectSelect.Text;

            teacherSubject = convertSubjectNameToEnglish(grimonhoc.EditValue.ToString());
            foreach (string folderId in gradesFolders)
                getCourseInFolders(service, folderId, teacherSubject);
        }
        DriveService service1a;
        public void initListCourse()
        {
            
            //show present rootpath            
            readRootPath(pathFileIni);
            //MessageBox.Show("present root path: " + rootPath);

            listDrivePatition();

            //connect google drive---------------------------------------------------------            
            string[] scopes = new string[] { DriveService.Scope.Drive, // Full access
            DriveService.Scope.DriveReadonly,
            DriveService.Scope.DriveAppdata,
            DriveService.Scope.DriveFile,
            DriveService.Scope.DriveMetadata,
            DriveService.Scope.DriveMetadataReadonly,
            DriveService.Scope.DriveScripts };

            var keyFilePath = @"testp12-1d982ecaf837.p12";// "moodlehv-teacher-1594910513742-b991fcd2279e.p12";// @"c:\file.p12";    // Downloaded from https://console.developers.google.com
            var serviceAccountEmail = "e-learninghv@testp12.iam.gserviceaccount.com";// "myaccount@moodlehv-teacher-1594910513742.iam.gserviceaccount.com";// "xx@developer.gserviceaccount.com";  // found https://console.developers.google.com

            //loading the Key file
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
            
            //var clientId = "803852290659-ed87bj86p500cbeupq0suj66fsstc468.apps.googleusercontent.com";
            //var secret = "lO4kRRUx5Mn2Hec1HlEXVRPh";

            //var service1a = GoogleDriveFileListDirectoryStructure.AuthenticateOauth(clientId, secret, "UserName1a");
            
            //get id from folder name
            //public static string[] SearchForFileId(DriveService service, string name, bool includeTrash = false)

            //add columns paras to grid
            ds.Columns.Add("Check", Type.GetType("System.Boolean"));
            ds.Columns.Add("CourseName1");
            ds.Columns.Add("updatedDate");
            ds.Columns.Add("CourseName");
            ds.Columns.Add("sizeMB");
            ds.Columns.Add("statusDU");
            ds.Columns.Add("status");
            ds.Columns.Add("Id");
            ds.Columns.Add("size");

            //updateListCourses(service1a);
            updateListCourses_(service1a);

            //check new course again:
            removeOlderCoursesFromListDS();

            //update grid data
            gridControl1.DataSource = ds;

        }

        public void removeOlderCoursesFromListDS()
        {
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            string newCourseName = "";
            //foreach (string item2 in dirs)
            for (int i=ds.Rows.Count-1;i>=0;i--)
            {
                //FileInfo f = new FileInfo(item2);
                newCourseName = ds.Rows[i]["CourseName1"].ToString();
                bool foundCourse = false;
                foreach (XmlNode nodechild in node.ChildNodes)
                {
                    if (nodechild.Name == newCourseName)
                    {
                        foundCourse = true;

                        //nodechild.InnerText = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        //Program.up_grade = nodechild.InnerText;
                    }
                }

                if (foundCourse == false)
                {
                    //MessageBox.Show("Course: " + newCourseName + " is not exist");

                    //MessageBox.Show(newCourseName + " is a new course");
                    //XmlElement courseInfo = myXmlDocument.CreateElement(newCourseName);
                    //XmlElement bar = myXmlDocument.CreateElement("date");
                    //bar.InnerText = ds.Rows[i]["updatedDate"].ToString();
                    //courseInfo.AppendChild(bar);
                    //myXmlDocument.DocumentElement.AppendChild(courseInfo);
                }
                else
                {
                    
                    
                    foreach (XmlNode nodechild in node.ChildNodes)
                    {
                        //MessageBox.Show(nodechild.Name);
                        if (nodechild.Name == newCourseName)
                        {
                            foreach (XmlNode nodechild1 in nodechild.ChildNodes)
                                if (nodechild1.Name == "date")
                                {
                                    //MessageBox.Show(newCourseName + " is existed\r\n" + "new ver:" + ds.Rows[i]["updatedDate"].ToString() + "\r\nold ver:" + nodechild1.InnerText);
                                    if (ds.Rows[i]["updatedDate"].ToString() == nodechild1.InnerText)
                                        ds.Rows.RemoveAt(i);
                                    //nodechild1.InnerText = ds.Rows[i]["updatedDate"].ToString();
                                    //Program.up_grade = nodechild.InnerText;
                                    break;
                                }
                        }
                    }

                }
            }
        }
        private void saveRootToFile(string fileName, string content)
        {
            //fileName = @"C:\Temp\Mahesh.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }

                // Create a new file     
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    // Add some text to file    
                    Byte[] title = new UTF8Encoding(true).GetBytes(content);
                    fs.Write(title, 0, title.Length);
                    fs.Close();
                    //byte[] author = new UTF8Encoding(true).GetBytes("Mahesh Chand");
                    //fs.Write(author, 0, author.Length);
                }

                /*
                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }*/
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        private async void unzipFile(string filePath, string extractPath)
        {
            //extractPath = "extractZip";
            if (Directory.Exists(extractPath))
                Directory.Delete(extractPath, true);

            //ZipArchive zipArchive = new  ZipFile.OpenRead(Application.StartupPath + @"\patch001.zip");
            //foreach (ZipArchiveEntry entry in zipArchive.Entries)
            //{
            //    entry.ExtractToFile(Application.StartupPath + entry.Name, true);
            //}
            //zipArchive.Dispose();

            //System.IO.Compression.ZipFile.ExtractToDirectory(filePath, extractPath);
            await Task.Run(() => System.IO.Compression.ZipFile.ExtractToDirectory(filePath, extractPath));

            /*
             * System.IO.File.Copy(fileNameTest1, fileNameTest2, true);
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
                    }*/
        }

        private void readRootPath(string pathFileIni)
        {
            try
            {
                //string content = "";
                // Open the stream and read it back.    
                using (StreamReader sr = System.IO.File.OpenText(pathFileIni))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(s);
                        //content += s;
                        rootPath = s;
                    }
                    sr.Close();

                    //MessageBox.Show(rootPath);
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        /*
        void zip_ExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if (e.TotalBytesToTransfer > 0)
            {
                progressBar.Value = Convert.ToInt32(100 * e.BytesTransferred / e.TotalBytesToTransfer);
            }
        }
        */
        //private int totalFiles;
        //private int filesExtracted;

        private void ZipExtractProgress(object sender, ExtractProgressEventArgs e, int filesExtracted)
        {
            if (e.EventType != ZipProgressEventType.Extracting_BeforeExtractEntry)
                return;
            filesExtracted++;
            //progressBar.Value = 100 * filesExtracted / totalFiles;

            //!updateUnzipStatusBar(100 * filesExtracted / totalFiles, "downloading...", fileIdUnzipping);
            //parentForm.updateStatusBar((progressBar.Value * 100) / 100000000, "Downloading...", fileId);
            //label3.Text = progressBar.Value.ToString();
        }

        public void updateUnzipStatusBar(long bytes, string msg,string fileId)
        {

            if (InvokeRequired)
            {
                Invoke(new Action<long, string,string>(updateUnzipStatusBar), new object[] { bytes, msg, fileId});
                return;
            }
            if (bytes == -1)
            {
                //ds.Rows[rowId].va = "100";
                //gridControl1.s.SetRowCellValue(rowId, "status", "OK");
                //gridView1.SetRowCellValue(1, "status", "100%");
                for (int i = 0; i < gridView1.RowCount; i++)
                    if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
                    {
                        gridView1.SetRowCellValue(i, "status", "100%");
                        gridView1.SetRowCellValue(i, "statusDU", "Finished");
                    }
                //MessageBox.Show("Course: " + msg + " is downloaded " + fileId);
            }
            else
            {
                //progressBar.Value = (int)bytes; //20;// 
                for (int i = 0; i < gridView1.RowCount; i++)
                    if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
                    {
                        gridView1.SetRowCellValue(i, "status", bytes.ToString() + "%");
                        gridView1.SetRowCellValue(i, "statusDU", "Unzipping");
                    }
                //if (progressBar.Value == 100)
                //    MessageBox.Show("Download Completed");
            }
            //lblProgress.Text = msg;
            //lblProgress.Location = new Point(this.ClientRectangle.Width - lblProgress.Width - progressBar.Width - 20, 4);

        }

        public void updateStatusBarUnzip(float bytes, string msg, string fileId,string zipToUnpack)
        {

            if (InvokeRequired)
            {
                Invoke(new Action<float, string, string,string>(updateStatusBarUnzip), new object[] { bytes, msg, fileId, zipToUnpack });
                return;
            }
            //updateUnzipStatusBar(100 * filesExtracted / totalFiles, "downloading...", fileId);
            
            if (bytes == -1)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                    if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
                    {
                        gridView1.SetRowCellValue(i, "status", "100%");
                        gridView1.SetRowCellValue(i, "statusDU", "Finished");

                        //delete
                        //if (File.Exists(zipToUnpack) == true)
                        //    File.Delete(zipToUnpack);
                    }


                //call set paras stuffs
                //read rootPath
                for (int i = 0; i < gridView1.RowCount; i++)
                    if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
                    {
                        //parent.gridView1.SetRowCellValue(i, "statusDU", "Installing");
                        //Form1_student originalForm = new Form1_student();

                        ////read rootPath
                        string courseName = ds.Rows[i]["CourseName1"].ToString(); //ds.Rows[i]["CourseName"].ToString()
                        //MessageBox.Show("hello");
                        setParasCourse(courseName);
                        
                        break;
                        //readRootPath(pathFileIni);
                        //setParasCourse(courseName);
                        //setParas();


                        //parent.gridView1.SetRowCellValue(i, "statusDU", "Finished");
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
            //lblProgress.Text = msg;
            //lblProgress.Location = new Point(this.ClientRectangle.Width - lblProgress.Width - progressBar.Width - 20, 4);
            
        }

        //public string readRootPath(string pathFileIni)
        //{
        //    try
        //    {
        //        //string content = "";
        //        // Open the stream and read it back.    
        //        using (StreamReader sr = System.IO.File.OpenText(pathFileIni))
        //        {
        //            string s = "";
        //            while ((s = sr.ReadLine()) != null)
        //            {
        //                //Console.WriteLine(s);
        //                //content += s;
        //                return s;
        //            }
        //            sr.Close();

        //            //MessageBox.Show(rootPath);
        //        }

        //    }
        //    catch (Exception Ex)
        //    {
        //        Console.WriteLine(Ex.ToString());
        //    }

        //    return "error";
        //}

        //public string fileIdUnzipping = "";
        //!private void MyExtract(string zipToUnpack, string unpackDirectory)
        private void MyExtract(string zipToUnpack, string unpackDirectory, ListNewCoursesTeachers parentForm,string fileId)
        {
            ListNewCoursesTeachers parent = parentForm;
            //fileIdUnzipping = fileId;
            long filesExtracted = 0;

            bool finishedUnzip = false;
            //Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipToUnpack);
            using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipToUnpack))
            {
                int totalFiles = zip.Count;
                
                //zip.ExtractProgress += ZipExtractProgress(filesExtracted);
                //zip.ExtractAll(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                


                foreach (ZipEntry z in zip)
                {
                    try
                    {
                        filesExtracted++;
                        parent.updateStatusBarUnzip(100*filesExtracted / totalFiles, "unzipping", fileId, zipToUnpack);
                        //parent.updateStatusBarUnzip(filesExtracted , "unzipping", fileId);
                        //Task.Run(() => { z.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently); });
                        z.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                    }
                    catch (Exception ex)
                    {
                        //Write ex.ToString() to file and move on...
                        Console.WriteLine(ex.ToString());
                    }
                    if (totalFiles <= filesExtracted)
                    {
                        //!updateUnzipStatusBar(-1, "Finished", fileId);
                        parent.updateStatusBarUnzip(-1, "unzipping", fileId, zipToUnpack);

                        finishedUnzip = true;                        
                    }
                }
                

            }
            if (finishedUnzip == true)
            {
                if (File.Exists(zipToUnpack) == true)
                    File.Delete(zipToUnpack);

                //update courses info
                updateCoursesInfo();
            }
            /*ok
            using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipToUnpack))
            {
                zip.ExtractProgress +=
                   new EventHandler<ExtractProgressEventArgs>(zip_ExtractProgress);
                zip.ExtractAll(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);

            }*/
            /*
            using (Ionic.Zip.ZipFile zip1 = Ionic.Zip.ZipFile.Read(zipToUnpack))
            {
                // here, we extract every entry, but we could extract conditionally
                // based on entry name, size, date, checkbox status, etc.
                Directory.CreateDirectory(unpackDirectory);

                
                foreach (ZipEntry e in zip1)
                    //e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                    //FOR ASYNC IS OK
                    //!await Task.Run(() => e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently));
                    e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                    //await Task.Run(() => Ionic.Zip.ZipFile.ExtractToDirectory(unpackDirectory, ExtractExistingFileAction.OverwriteSilently));
                    //await Task.Run(() => e.Ionic.Zip.ZipFile.ExtractToDirectory(unpackDirectory, ExtractExistingFileAction.OverwriteSilently));
                    //-----------------------
                    //foreach (ZipEntry e in zip1)
                    //{
                    //    try
                    //    {
                    //        e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                    //    }
                    //    catch (Exception Ex)
                    //    {
                    //        Console.WriteLine(e.FileName.ToString());
                    //    }
                    //}--------------------------

            }*/
        }

        public string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_]+", "_", RegexOptions.Compiled);
        }

        public void ExtractZipFileToPath(string zipFilePath,string ouputPath)
        {
            //using (var zip = ZipFile.Read(zipFilePath))
            //{
            //    foreach (var entry in zip.Entries.ToList())
            //    {
            //        entry.FileName = RemoveSpecialCharacters(entry.FileName);
            //        entry.Extract(ouputPath);
            //    }
            //}
        }

        public void ExtractFileToDirectory(string zipFileName, string outputDirectory)
        {
            //ZipFile zip = ZipFile.Read(zipFileName);
            //Directory.CreateDirectory(outputDirectory);
            ////zip.ExtractSelectedEntries("name = *.doc", "document\", outputDirectory, ExtractExistingFileAction.OverwriteSilently);
            //zip.ExtractAll(outputDirectory);// Extract(outputDirectory, ExtractExistingFileAction.OverwriteSilently);
        }

        //public void ExtractFileToDirectory(string zipFileName, string outputDirectory)
        //{
        //    //int segmentsCreated;
        //    //using (ZipFile zip = new ZipFile())
        //    //{
        //    //    //zip.UseUnicode = true;  // utf-8
        //    //    zip.AddDirectory(@"C:\\Users\\Thang\\Downloads\\Mathematics07_14072020_15h30");// (@"MyDocuments\ProjectX");
        //    //    zip.Comment = "This zip was created at " + System.DateTime.Now.ToString("G");
        //    //    zip.MaxOutputSegmentSize = 200 * 1024 * 1024;// 100 * 1024; // 100k segments
        //    //    zip.Save("MyFiles.zip");

        //    //    segmentsCreated = zip.NumberOfSegmentsForMostRecentSave;
        //    //    MessageBox.Show(segmentsCreated.ToString());
        //    //}

        //    ZipFile zip = ZipFile.Read(zipFileName);
        //    Directory.CreateDirectory(outputDirectory);
        //    foreach (ZipEntry e in zip)
        //    {
        //        // check if you want to extract e or not
        //        //if (e.FileName == "TheFileToExtract")
        //            e.Extract(outputDirectory, ExtractExistingFileAction.OverwriteSilently);
        //    }
        //}

        //public static Task DeleteAsync(this FileInfo fi)
        //{
        //    return Task.Factory.StartNew(() => fi.Delete());
        //}

        public static bool EraseDirectory(string folderPath, bool recursive)
        {
            //Safety check for directory existence.
            if (!Directory.Exists(folderPath))
                return false;

            foreach (string file in Directory.GetFiles(folderPath))
            {
                File.Delete(file);
            }

            //Iterate to sub directory only if required.
            if (recursive)
            {
                foreach (string dir in Directory.GetDirectories(folderPath))
                {
                    EraseDirectory(dir, recursive);
                }
            }
            //Delete the parent directory before leaving
            Directory.Delete(folderPath);
            return true;
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            unzipStuffs();       
        }

        private bool CheckAvailableServerPort(int port)
        {
            //LOG.InfoFormat("Checking Port {0}", port);
            bool isAvailable = true;

            // Evaluate current system tcp connections. This is the same information provided
            // by the netstat command line application, just in .Net strongly-typed object
            // form.  We will look through the list, and if our port we would like to use
            // in our TcpClient is occupied, we will set isAvailable to false.
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endpoint in tcpConnInfoArray)
            {
                if (endpoint.Port == port)
                {
                    isAvailable = false;
                    break;
                }
            }

            //LOG.InfoFormat("Port {0} available = {1}", port, isAvailable);

            return isAvailable;
        }

        //int webPort = 80;
        //int sslListenPort = 443;
        //int mySQLPort = 3306;

        private void updatePorts()
        {
            //check used port
            int webPort = 80;
            while (CheckAvailableServerPort(webPort) == false)
                webPort++;
            MessageBox.Show("port web is: " + webPort.ToString());

            int sslListenPort = 443;
            while (CheckAvailableServerPort(sslListenPort) == false)
                sslListenPort++;
            MessageBox.Show("port web is: " + sslListenPort.ToString());

            int mySQLPort = 3306;
            while (CheckAvailableServerPort(mySQLPort) == false)
                mySQLPort++;
            MessageBox.Show("port web is: " + mySQLPort.ToString());


        }

        public void changeParaDirectories(string moodlePath, string rootPath1)
        {
            //change config.php
            //string path = 
            //MessageBox.Show(moodlePath+ "\\server\\moodle\\config.php");

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
                        //Console.WriteLine(s);
                        //$CFG->dataroot  =
                        //if (s.IndexOf(path1.Text) >= 0)
                        if (s.IndexOf("$CFG->dataroot") >= 0)
                        {
                            //MessageBox.Show(rootPath1 + "\\\\server\\\\moodle\\\\config.php");
                            //s = s.Replace(path1.Text, rootPath1);
                            s = "$CFG->dataroot = '" + rootPath1 + "\\\\server\\\\moodledata';";
                        }
                        content += s + "\r\n";
                    }
                    sr.Close();
                    //MessageBox.Show(content);

                    // Check if file already exists. If yes, delete it.     
                    //string fileName = moodlePath + "\\server\\moodle\\config.php";
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
                        //byte[] author = new UTF8Encoding(true).GetBytes("Mahesh Chand");
                        //fs.Write(author, 0, author.Length);
                    }
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }


        }

        public void setParas()
        {
            //read rootPath
            Form1_student originalForm = new Form1_student();
            //read rootPath
            //!string rootPath = originalForm.readRootPath(originalForm.pathFileIni);
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            //string rootPath = originalForm.readRootPath(originalForm.pathFileIni);
            string rootPath = "";// originalForm.readRootPath(originalForm.pathFileIni);
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

            string[] dirs = Directory.GetDirectories(rootPath);
            //string rootPath1 = rootPath.Replace("\\", "\\\\");

            foreach (string item2 in dirs)
            {
                FileInfo f = new FileInfo(item2);
                //listBox1.Items.Add(f.Name);               
                //ds.Rows.Add(f.Name, "", "");//

                string path = rootPath.Replace("\\", "\\\\");
                path += "\\\\" + f.Name;
                //MessageBox.Show(path);
                //change directory paramaters: config.php
                changeParaDirectories(path, path);

                //create bat files
                //update startMoodle.bat file

                string fileName = rootPath + "\\" + f.Name + "\\starMoodle.bat";
                //MessageBox.Show(fileName);
                try
                {
                    //string fileName = moodlePath + "\\server\\moodle\\config.php";

                    string content = "";
                    // Open the stream and read it back.    
                    //using (StreamReader sr = File.OpenText(fileName))
                    {

                        content = "CD " + rootPath + "\\" + f.Name + "\r\n";
                        string partitionName = rootPath.Substring(0, rootPath.IndexOf(":") + 1);
                        //MessageBox.Show(partitionName);

                        content += partitionName + "\r\n";
                        content += rootPath + "\\" + f.Name + "\\StartMoodle.exe";
                        //MessageBox.Show(content);

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            // Add some text to file    
                            Byte[] title = new UTF8Encoding(true).GetBytes(content);
                            fs.Write(title, 0, title.Length);
                            fs.Close();
                            //byte[] author = new UTF8Encoding(true).GetBytes("Mahesh Chand");
                            //fs.Write(author, 0, author.Length);
                        }
                    }

                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                }

                fileName = rootPath + "\\" + f.Name + "\\stopMoodle.bat";

                try
                {
                    //string fileName = moodlePath + "\\server\\moodle\\config.php";

                    string content = "";
                    // Open the stream and read it back.    
                    //using (StreamReader sr = File.OpenText(fileName))
                    {

                        content = "CD " + rootPath + "\\" + f.Name + "\r\n";
                        string partitionName = rootPath.Substring(0, rootPath.IndexOf(":") + 1);
                        //MessageBox.Show(partitionName);

                        content += partitionName + "\r\n";
                        content += rootPath + "\\" + f.Name + "\\StopMoodle.exe";
                        //MessageBox.Show(content);

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            // Add some text to file    
                            Byte[] title = new UTF8Encoding(true).GetBytes(content);
                            fs.Write(title, 0, title.Length);
                            fs.Close();
                            //byte[] author = new UTF8Encoding(true).GetBytes("Mahesh Chand");
                            //fs.Write(author, 0, author.Length);
                        }
                    }

                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                }
                capnhatdiem(f.Name);
            }
        }
        string Name_Courses = "";
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
        private static void luu_xml(string url, string name)
        {
            string _config = "";
            int kt = 0;
            XmlReader xmlReader;
            xmlReader = new XmlTextReader(url);
            try
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.Name == name)
                    {
                        _config = xmlReader.ReadElementString();
                        kt = 1;
                        break;
                    }

                }
                xmlReader.Close();
                if (kt == 0)
                {
                    string b = loaddata(url);
                    string c = "<" + name + "></" + name + ">\n</root>";
                    b = b.Replace("<root>", "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<root>\n");
                    b = b.Replace("</root>", c);
                    _config = b;
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(_config);
                    xdoc.Save(url);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi!");
            }
            Cursor.Current = Cursors.Default;
            // su dung kiem tra port
        }
        private static string loaddata(string url)
        {

            XmlTextReader reader = new XmlTextReader(@url);
            string a = "";
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        a = a + "<" + reader.Name + ">";
                        Console.Write("<" + reader.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        a = a + reader.Value;
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        a = a + "</" + reader.Name + ">\n";
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
            reader.Close();
            return a;
        }
        void luuxml(string myXmlDocument_, string Name_, string nodechild_)
        {
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@myXmlDocument_);
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            foreach (XmlNode nodechild in node.ChildNodes)
            {
                if (nodechild.Name == Name_)
                {
                    nodechild.InnerText = nodechild_;
                }
            }
            myXmlDocument.Save(myXmlDocument_);
        }
        public void setParasCourse(string courseName)
        {
            
            //read rootPath
            Form1_student originalForm = new Form1_student();
            //read rootPath
            //!string rootPath = originalForm.readRootPath(originalForm.pathFileIni);
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            //string rootPath = originalForm.readRootPath(originalForm.pathFileIni);
            string rootPath = "";// originalForm.readRootPath(originalForm.pathFileIni);
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
            //string[] dirs = Directory.GetDirectories(rootPath);
            //string rootPath1 = rootPath.Replace("\\", "\\\\");

            //foreach (string item2 in dirs)

            //FileInfo f = new FileInfo(item2);
            //listBox1.Items.Add(f.Name);               
            //ds.Rows.Add(f.Name, "", "");//

            //string path = rootPath.Replace("\\", "\\\\");
            //path += "\\\\" + f.Name;
            //MessageBox.Show(path);
            //change directory paramaters: config.php
            changeParaDirectories(path1, path1);

            //create bat files
            //update startMoodle.bat file

            string fileName = path1 + "\\starMoodle.bat";
            //MessageBox.Show("in setParasCourse()\r\n"+ fileName.ToString());

            //MessageBox.Show(fileName);
            try
            {
                //string fileName = moodlePath + "\\server\\moodle\\config.php";

                string content = "";
                // Open the stream and read it back.    
                //using (StreamReader sr = File.OpenText(fileName))
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
                        //byte[] author = new UTF8Encoding(true).GetBytes("Mahesh Chand");
                        //fs.Write(author, 0, author.Length);
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
                //string fileName = moodlePath + "\\server\\moodle\\config.php";

                string content = "";
                // Open the stream and read it back.    
                //using (StreamReader sr = File.OpenText(fileName))
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
                        //byte[] author = new UTF8Encoding(true).GetBytes("Mahesh Chand");
                        //fs.Write(author, 0, author.Length);
                    }
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            capnhatdiem(courseName);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update port
            //!updatePorts();
            setParas();
            //rootPath = readRootPath(pathFileIni);
            //rootPath = rootPath.Replace("\\", "\\\\");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listC2Ra.updateCoursesInfoInit();
            this.Close();
        }

        public void updateDiskPatitions()
        {
            string folderName = "moodleLocalhost";
            //string pathToZipFile = "";
            rootPath = diskPatitions.Text.Substring(0, 3) + folderName;
            //MessageBox.Show(rootPath);
            //save rootPath to ini file
            //!saveRootToFile(pathFileIni, rootPath);

            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            //string rootPath = originalForm.readRootPath(originalForm.pathFileIni);
            //string rootPath = "";// originalForm.readRootPath(originalForm.pathFileIni);
            node = myXmlDocument.DocumentElement;

            //read rootPath            
            foreach (XmlNode nodechild in node.ChildNodes)
            {
                if (nodechild.Name == "rootDir")
                {
                    //rootPath = nodechild.InnerText;

                    nodechild.InnerText = rootPath;// DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                                                   //Program.up_grade = nodechild.InnerText;
                }
            }
            myXmlDocument.Save(@"coursesInfo.xml");
        }

        private void button5_Click(object sender, EventArgs e)
        {

            updateDiskPatitions();
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
                                //nodechild.InnerText = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                                //Program.up_grade = nodechild.InnerText;
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
                                //MessageBox.Show(nodechild.Name);
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

        private void button6_Click(object sender, EventArgs e)
        {
            updateCoursesInfo();
        }

        private void diskPatitions_TextChanged(object sender, EventArgs e)
        {
            updateDiskPatitions();
        }

        private void ListNewCourses_FormClosed(object sender, FormClosedEventArgs e)
        {
            listC2Ra.updateCoursesInfoInit();
        }



        private void coursesNewest_CheckedChanged(object sender, EventArgs e)
        {
            while (ds.Rows.Count > 0)
                ds.Rows.RemoveAt(0);

            //updateListCourses(service1a);
            updateListCourses_(service1a);
            //check new course again:
            removeOlderCoursesFromListDS();

            //update grid data
            gridControl1.DataSource = ds;
        }

        private void allCourses_CheckedChanged(object sender, EventArgs e)
        {
            while (ds.Rows.Count > 0)
                ds.Rows.RemoveAt(0);

            //updateListCourses(service1a);
            updateListCourses_(service1a);
            //check new course again:
            //removeOlderCoursesFromListDS();

            //update grid data
            gridControl1.DataSource = ds;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            capnhat.ShowWaitForm();
            //Các khóa học mới nhất
            //Các khóa học chưa được thẩm định
            //Toàn bộ các khóa học
            //MessageBox.Show(listNewCoursesMethod.SelectedItem.ToString().Trim());
            while (ds.Rows.Count > 0)
                ds.Rows.RemoveAt(0);

            if (listNewCoursesMethod.SelectedItem.ToString().Trim() == "Toàn bộ các khóa học".Trim())
            {
                //while (ds.Rows.Count > 0)
                //    ds.Rows.RemoveAt(0);

               // updateListCourses(service1a);//ko dang nhap
                updateListCourses_(service1a);//dang nhap
                //check new course again:
                //removeOlderCoursesFromListDS();

                //update grid data
                gridControl1.DataSource = ds;
            } else
            if (listNewCoursesMethod.SelectedItem.ToString().Trim() == "Các khóa học mới nhất".Trim())
            {


                //updateListCourses(service1a);
                updateListCourses_(service1a);
                //check new course again:
                removeOlderCoursesFromListDS();

                //update grid data
                gridControl1.DataSource = ds;
            }
            else
            if (listNewCoursesMethod.SelectedItem.ToString().Trim() == "Các khóa học chưa được thẩm định")
            {
                //while (ds.Rows.Count > 0)
                //    ds.Rows.RemoveAt(0);
                //updateListCourses(service1a);
                updateListCourses_(service1a);
                //check new course again:
                removeOlderCoursesFromListDS();

                //update grid data
                gridControl1.DataSource = ds;
            }
            capnhat.CloseWaitForm();
        }

        private void listNewCoursesMethod_Click(object sender, EventArgs e)
        {
            
        }

        public void RenameMyFile(DriveService service, string name, string id)
        {
            Google.Apis.Drive.v3.Data.File file = service.Files.Get(id).Execute();

            var update = new Google.Apis.Drive.v3.Data.File();
            update.Name = name;

            service.Files.Update(update, id).Execute();
        }


        //public async Task<File> RenameFile(DriveService service, String fileId,String newFilename)
        //public bool RenameFile(DriveService service, String fileId, String newFilename)
        //{
        //    try
        //    {
        //        //DriveService service = await GetDriveService();
        //        // First retrieve the file from the API.
        //        /*
        //        Google.Apis.Drive.v3.Data.File file = service.Files.Get(fileId).Execute();

        //        // File's new metadata.
        //        // file.Name = newFilename;
        //        file.OriginalFilename = newFilename;
        //        Google.Apis.Drive.v3.Data.File newFile = new Google.Apis.Drive.v3.Data.File();
        //        newFile = file;
        //        // Send the request to the API.
        //        FilesResource.UpdateRequest request = service.Files.Update(newFile, fileId);
        //        //request.Fields = "id, name, thumbnailLink";
        //        request.Fields = "id, name";
        //        Google.Apis.Drive.v3.Data.File uploadedFile = request.Execute();
        //        */
        //        //Drive service... // your own declared implementation of service
        //        Google.Apis.Drive.v3.Data.File file = new Google.Apis.Drive.v3.Data.File(); //using the com.google.api.services.drive.model package
        //                                                                                       // part where you set your data to file like:
        //        file.Name("new name for file");
        //        String fileID = "id of file, which you want to change";
        //        service.files().update(fileID, file).execute();

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("An error occurred: " + e.Message);
        //        return false;
        //    }
        //}
        private static void OverwriteDriveFileNames(DriveService driveService,string fileId)
        {
            //string fileId = "myId";
            Google.Apis.Drive.v3.Data.File file = driveService.Files.Get(fileId).Execute();
            file.Id = null;
            FilesResource.UpdateRequest request = driveService.Files.Update(file, fileId);
            request.Execute();
        }

        public string getFolderIdFromCourseName(string filename)
        {
            //if ()
            string[] words;
            //string datetimeStr = "";
            words = filename.Split('_');
            if (words.Length > 2)
            {
                if (words[0].IndexOf("01") > 0)
                    return gradesFolders[0];
                if (words[0].IndexOf("02") > 0)
                    return gradesFolders[1];
                if (words[0].IndexOf("03") > 0)
                    return gradesFolders[2];
                if (words[0].IndexOf("04") > 0)
                    return gradesFolders[3];
                if (words[0].IndexOf("05") > 0)
                    return gradesFolders[4];
                if (words[0].IndexOf("06") > 0)
                    return gradesFolders[5];
                if (words[0].IndexOf("07") > 0)
                    return gradesFolders[6];
                if (words[0].IndexOf("08") > 0)
                    return gradesFolders[7];
                if (words[0].IndexOf("09") > 0)
                    return gradesFolders[8];
                if (words[0].IndexOf("10") > 0)
                    return gradesFolders[9];
                if (words[0].IndexOf("11") > 0)
                    return gradesFolders[10];
                if (words[0].IndexOf("12") > 0)
                    return gradesFolders[11];
            }
            return "";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.TopMost = false;
            string[] scopes = new string[] { DriveService.Scope.Drive }; // Full access
            UserCredential credential;
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token_new.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "MoodleHV Teachers 3",
            });

            service.HttpClient.Timeout = TimeSpan.FromMinutes(1000);


            //check permission:
            
            string folderId = "1ideFv7ieb_NRlyO5TkmOOTQtvFtYDPRq";// confirmAccounts folder
            List<Google.Apis.Drive.v3.Data.File> filesList = new List<Google.Apis.Drive.v3.Data.File>();           
            filesList = GoogleDrive.ListFiles(service, folderId);

            if (filesList.Count == 0)
            {                
                //DialogResult dialogResult = MessageBox.Show("Tài khoản đăng nhập này không được quyền thẩm định khóa học.\r\nBạn có muốn đăng nhập lại không?", "Thông báo", MessageBoxButtons.YesNo);

                DialogResult dialogResult = MessageBox.Show(new Form { TopMost = true }, "Tài khoản đăng nhập này không được quyền thẩm định khóa học.\r\nBạn có muốn đăng nhập lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    System.IO.DirectoryInfo di = new DirectoryInfo(@"token_new.json");

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                //MessageBox.Show("Num. files: " + filesList.Count.ToString());

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
                            string courseInfo = ds.Rows[i]["CourseName"].ToString();

                            //string folderID = "";// "1HiuLTcwX2hdyWeN4zeUZ6kLOf17mFRR1";//grade-7
                            //string filename = Path.GetFileName(pathFile);
                            //fileId = getFolderIdFromCourseName(courseInfo);

                            OverwriteDriveFileNames(service, fileId);
                            string newFilename = courseInfo.Replace("_NotYetConfirmed", "");
                            //MessageBox.Show(fileId.ToString() + "\r\n" + courseInfo + "\r\n" + newFilename);
                            //RenameFile(service, fileId, newFilename);
                            RenameMyFile(service, newFilename, fileId);

                            //MessageBox.Show("Đã thẩm định xong khóa học: " + newFilename);
                            MessageBox.Show(new Form { TopMost = true }, "Đã thẩm định xong khóa học: " + newFilename, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            //string PathToSave = ds.Rows[i]["CourseName"].ToString();// + ".zip";
                            ////ds.Columns.Add("updatedDate");
                            ////var request = service.Files.Get(fileId);


                            //long fileSize = long.Parse(ds.Rows[i]["size"].ToString());
                            //if ((strPercent != "") && (strPercent != "0%"))
                            //    continue;

                            //Task.Run(() => { Download(service, fileId.ToString(), PathToSave, fileSize, this); });
                            //Task.Run(() => { Download(service, "1DtFxJwIngCnCDknteOnZa4yTtp_1Z9JB", PathToSave, fileSize, this); });
                            //Thread.Sleep(1000);                        
                        }
                    }

                //remove stuffs
                while (ds.Rows.Count > 0)
                    ds.Rows.RemoveAt(0);
                //updateListCourses(service1a);
                updateListCourses_(service1a);
                //check new course again:
                removeOlderCoursesFromListDS();
                //update grid data
                gridControl1.DataSource = ds;
            }
            this.TopMost = true;
        }

        private void subjectSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            //update subjects name to courseInfo.xml
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            //string rootPath = originalForm.readRootPath(originalForm.pathFileIni);
            //string rootPath = "";// originalForm.readRootPath(originalForm.pathFileIni);
            node = myXmlDocument.DocumentElement;

            if (subjectSelect.Text != "")
            foreach (XmlNode nodechild in node.ChildNodes)
            {
                //MessageBox.Show(nodechild.Name);
                
                if (nodechild.Name == "teacherSubject")
                {
                        nodechild.InnerText = subjectSelect.Text;//DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    Program.up_grade = nodechild.InnerText;
                }

                //if (nodechild.Name == newCourseName)
                //{
                //    foundCourse = true;
                //    //nodechild.InnerText = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                //    //Program.up_grade = nodechild.InnerText;
                //}
            }
            myXmlDocument.Save(@"coursesInfo.xml");

            //reload
            //initListCourse();
            while (ds.Rows.Count > 0)
                ds.Rows.RemoveAt(0);
            updateListCourses(service1a);
            */

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void grimonhoc_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                capnhat.ShowWaitForm();
                XmlDocument myXmlDocument = new XmlDocument();
                myXmlDocument.Load(@"coursesInfo.xml");
                XmlNode node;
                node = myXmlDocument.DocumentElement;
                if (grimonhoc.EditValue.ToString() != "")
                    foreach (XmlNode nodechild in node.ChildNodes)
                    {
                        //MessageBox.Show(nodechild.Name);

                        if (nodechild.Name == "teacherSubject")
                        {
                            nodechild.InnerText = grimonhoc.EditValue.ToString();
                            Program.up_grade = nodechild.InnerText;
                        }
                    }
                myXmlDocument.Save(@"coursesInfo.xml");
                while (ds.Rows.Count > 0)
                    ds.Rows.RemoveAt(0);
                updateListCourses_(service1a);
                capnhat.CloseWaitForm();
            }
            catch
            {
                capnhat.CloseWaitForm();
            }
            
        }
    }
}