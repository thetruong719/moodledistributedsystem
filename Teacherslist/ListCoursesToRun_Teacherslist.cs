using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
//using System.IO.Compression;
using Ionic.Zip;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Google.Apis.Upload;
using System.Threading;
using NetFwTypeLib;
using Google.Apis.Util.Store;
//using System.Management.Automation;

namespace unzipPackage.Teacherslist
{
    public partial class ListCoursesToRun_Teacherslist : Form
    {
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

        Class.cls_macdinh clmd = new Class.cls_macdinh();
        Class.mdl_question clq = new Class.mdl_question();
        Class.cls_mdl_quiz_grades clqg = new Class.cls_mdl_quiz_grades();
        Class.clsnopdiem clnd = new Class.clsnopdiem();
        DataTable ds = new DataTable();
        Form1_student originalForm = new Form1_student();
        //string folderName = "moodleLocalhost";
        //string rootPath = "";
        //string pathFileIni = "appInfo.ini";

        public ListCoursesToRun_Teacherslist()
        {
            InitializeComponent();
        }

        public void updateCoursesInfoInit()
        {
            if (ds.Columns.Count == 0)
            {
                gridView1.OptionsBehavior.Editable = false;

                ds.Columns.Add("courseName");
                //ds.Columns.Add("lastAccess");
                ds.Columns.Add("lastestUpdateVersion");
                ds.Columns.Add("status");
                ds.Columns.Add("percent");
            }
            else
                while (ds.Rows.Count > 0)
                    ds.Rows.RemoveAt(0);

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
            //read rootPath
            //foreach (string item2 in dirs)
            //{
            //    FileInfo f = new FileInfo(item2);
            //    //listBox1.Items.Add(f.Name);               
            //    ds.Rows.Add(f.Name, "", "","","");//
            //}

            ////update grid data
            //gridControl1.DataSource = ds;

            //string subPath = "ImagesPath"; // your code goes here

            //bool exists = ;

            if (!System.IO.Directory.Exists(rootPath))
                System.IO.Directory.CreateDirectory(rootPath);

            string[] dirs = Directory.GetDirectories(rootPath);
            string newCourseName = "";
            //MessageBox.Show("call init");
            foreach (string item2 in dirs)
            //for (int i = ds.Rows.Count - 1; i >= 0; i--)
            {
                FileInfo f = new FileInfo(item2);
                newCourseName = f.Name;//ds.Rows[i]["CourseName1"].ToString();
                bool foundCourse = false;
                foreach (XmlNode nodechild in node.ChildNodes)
                {
                    if (nodechild.Name == "rootDir")
                    {
                        rootPath = nodechild.InnerText;

                        //nodechild.InnerText = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        //Program.up_grade = nodechild.InnerText;
                    }

                    if (nodechild.Name == newCourseName)
                    //if (nodechild.Name.IndexOf(newCourseName)>=0)
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
                    //int col = ds.Columns.Count;//.Rows.Count;
                    //ds.Rows.Add(f.Name, "", "", "","");
                    //try
                    //{
                        ds.Rows.Add(f.Name, "", "", "");//,"");
                    //gridControl1.DataSource = ds;
                    //MessageBox.Show("hello"+ f.Name.ToString());
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show("ds.Columns.Count: " + ds.Columns.Count.ToString() + "\r\n" + f.Name.ToString());
                    //    MessageBox.Show(ex.ToString(), "Thông báo lỗi!");
                    //}
                }
                else
                {                   
                    foreach (XmlNode nodechild in node.ChildNodes)
                    {
                        //MessageBox.Show(nodechild.Name);
                        if (nodechild.Name == newCourseName)
                        //if (nodechild.Name.IndexOf(newCourseName)>=0)
                        {
                            foreach (XmlNode nodechild1 in nodechild.ChildNodes)
                                if (nodechild1.Name == "date")
                                {
                                    //MessageBox.Show(newCourseName + " is existed\r\n" + "new ver:" + ds.Rows[i]["updatedDate"].ToString() + "\r\nold ver:" + nodechild1.InnerText);
                                    //if (ds.Rows[i]["updatedDate"].ToString() == nodechild1.InnerText)
                                    //    ds.Rows.RemoveAt(i);

                                    //ds.Rows.Add(f.Name, "", nodechild1.InnerText, "", "");
                                    //!ds.Rows.Add(f.Name, "",nodechild1.InnerText, "","");
                                    //try
                                    //{
                                        ds.Rows.Add(f.Name, nodechild1.InnerText, "", "");
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    MessageBox.Show(ex.ToString(), "Thông báo lỗi!");
                                    //}
                            //nodechild1.InnerText = ds.Rows[i]["updatedDate"].ToString();
                            //Program.up_grade = nodechild.InnerText;
                            break;
                                }
                        }
                    }

                }
            }
            gridControl1.DataSource = ds;
            //gridControl1.Refresh();
            myXmlDocument.Save(@"coursesInfo.xml");

            
        }

        private void listCoursesToRun_Load(object sender, EventArgs e)
        {
            kt = 0;
            gridView1.OptionsBehavior.Editable = false;

            //add columns paras to grid
            //ds.Columns.Add("Check", Type.GetType("System.Boolean"));            
            ds.Columns.Add("courseName");
            //ds.Columns.Add("lastAccess");
            ds.Columns.Add("lastestUpdateVersion");
            ds.Columns.Add("status");
            ds.Columns.Add("percent");

            updateCoursesInfoInit();

            if (ds.Rows.Count == 0)
            {
                ListNewCoursesTeachers lnc = new ListNewCoursesTeachers();

                lnc.Show();
                lnc.Focus();//.BringToFront();
            }            
            //getCourseInfo("", "coursesInfo.xml");
            //rootPath = diskPatitions.Text.Substring(0, 3) + folderName;
            kiemtraduongdan();

        }
        string http = @"C:\Moodle-36\server\apache\bin\httpd.exe";
        string mysql = @"C:\Moodle-36\server\mysql\bin\mysqld.exe";
        private void kiemtraduongdan()
        {
            http = duongdan(@"Config - Offline.xml", "http");
            Program.http = http;
            mysql = duongdan(@"Config - Offline.xml", "mysql");
            Program.mysql = mysql;
            string port_http = duongdan(@"Config - Offline.xml", "port_http");
            Program.port_http = port_http;
            Program.up_grade = duongdan(@"Config - Offline.xml", "up_grade");
            //Program.usages_id = duongdan(@"Config - Offline.xml", "usages_id");
            //Program.usages_id_Load = duongdan(@"Config - Offline.xml", "usages_id_Load");
            Program.usages_id = duongdan(@"Config-usages-id.xml", "usages_id");
            Program.usages_id_Load = duongdan(@"Config-usages-id.xml", "usages_id_Load");
            //lblStatus.Text = "Develop by Hoàng Việt E-Learning. Nộp điểm gần nhất lúc: " + Program.up_grade;
        }

        private static string getCourseInfo(string url, string name)
        {
            string _config = "";
            string server = "";
            XmlReader xmlReader;
            if (url.IndexOf("http") > 0)
            {
                xmlReader = XmlReader.Create(url);
            }
            else
            {
                xmlReader = new XmlTextReader(url);
            }

            try
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.Name == name)
                    {
                        _config = xmlReader.ReadElementString();
                    }
                    if (xmlReader.Name == "server")
                    {
                        server = xmlReader.ReadElementString();
                    }
                }
                xmlReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi!");
            }
            Cursor.Current = Cursors.Default;
            // su dung kiem tra port
            return _config;
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

        //public static int httpdPort = 80;
        //public static int sslListenPort = 443;
        //public static int mySQLPort = 3306;

        private void updatePorts()
        {
            //check used port
            int httpdPort = 80;
            while (CheckAvailableServerPort(httpdPort) == false)
                httpdPort++;
            MessageBox.Show("port web is: " + httpdPort.ToString());

            int sslListenPort = 443;
            while (CheckAvailableServerPort(sslListenPort) == false)
                sslListenPort++;
            //MessageBox.Show("port web is: " + sslListenPort.ToString());

            int mySQLPort = 3306;
            while (CheckAvailableServerPort(mySQLPort) == false)
                mySQLPort++;
            //MessageBox.Show("port web is: " + mySQLPort.ToString());


        }

        public void changeHTTPDPort(string moodlePath, string rootPath1, int httpdPort)
        {
            //change config.php
            //string path = 
            //MessageBox.Show(moodlePath+ "\\server\\moodle\\config.php");

            try
            {
                //C:\moodleLocalhost\English07\server\apache\conf
                //string fileName = moodlePath + "\\server\\moodle\\config.php";
                string fileName = moodlePath + "\\server\\apache\\conf\\httpd.conf";

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
                        if (s.IndexOf("Listen ") == 0)
                            s = "Listen " + httpdPort.ToString();// + "\r\n";

                        if (s.IndexOf("ServerName localhost:") == 0)
                            s = "ServerName localhost:" + httpdPort.ToString();// + "\r\n";                        

                        //ServerName localhost:

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

            try
            {
                //C:\moodleLocalhost\English07\server\apache\conf
                string fileName = moodlePath + "\\server\\moodle\\config.php";
                //string fileName = moodlePath + "\\server\\apache\\conf\\httpd.conf";

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
                        if (s.IndexOf("$CFG->wwwroot   = 'http://localhost") >= 0)
                            s = "$CFG->wwwroot   = 'http://localhost:" + httpdPort.ToString() + "';";// + "\r\n";
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

        public void changeHTTPDListenPort(string moodlePath, string rootPath1, int httpdListenPort)
        {
            //change config.php
            //string path = 
            //MessageBox.Show(moodlePath+ "\\server\\moodle\\config.php");

            try
            {
                //C:\moodleLocalhost\English07\server\apache\conf
                //string fileName = moodlePath + "\\server\\moodle\\config.php";
                //C:\moodleLocalhost\English07\server\apache\conf\extra
                string fileName = moodlePath + "\\server\\apache\\conf\\extra\\httpd-ssl.conf";

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
                        if (s.IndexOf("Listen ") == 0)
                            s = "Listen " + httpdListenPort.ToString();// + "\r\n";

                        if (s.IndexOf("<VirtualHost _default_:") == 0)
                            s = "<VirtualHost _default_:" + httpdListenPort.ToString() + ">";// + "\r\n";                        

                        if (s.IndexOf("ServerName www.example.com:") == 0)
                            s = "ServerName www.example.com:" + httpdListenPort.ToString() ;// + "\r\n";                        
                        //

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

        public void changeMySqlPort(string moodlePath, string rootPath1, int mySqlPort)
        {
            //change config.php
            //string path = 
            //MessageBox.Show(moodlePath+ "\\server\\moodle\\config.php");

            try
            {
                //mysqli.default_port
                //C:\moodleLocalhost\English07\server\php
                string fileName = moodlePath + "\\server\\php\\php.ini";

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
                        if (s.IndexOf("mysqli.default_port") >= 0)
                            s = "mysqli.default_port = " + mySqlPort.ToString();// + "\r\n";

                        if (s.IndexOf("mysql.default_port") == 0)
                            s = "mysql.default_port=" + mySqlPort.ToString() ;// + "\r\n";                        

                        //if (s.IndexOf("ServerName www.example.com:") == 0)
                        //    s = "ServerName www.example.com:" + httpdListenPort.ToString();// + "\r\n";                        
                        //

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

            try
            {
                //mysqli.default_port
                //C:\moodleLocalhost\English07\server\php
                //C:\moodleLocalhost\English07\server\mysql\bin
                string fileName = moodlePath + "\\server\\mysql\\bin\\my.ini";

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
                        if (s.IndexOf("port		= ") >= 0)
                            s = "port		= " + mySqlPort.ToString();// + "\r\n";

                        //if (s.IndexOf("mysql.default_port") == 0)
                        //    s = "mysql.default_port=" + mySqlPort.ToString();// + "\r\n";                        

                        //if (s.IndexOf("ServerName www.example.com:") == 0)
                        //    s = "ServerName www.example.com:" + httpdListenPort.ToString();// + "\r\n";                        
                        //

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

        private int findHttpdPort()
        {
            //check used port
            int httpdPort = 80;
            while (CheckAvailableServerPort(httpdPort) == false)
                httpdPort++;
            return httpdPort;
        }

        private int findHttpdListenPort()
        {
            //check used port
            int httpdListenPort = 443;
            while (CheckAvailableServerPort(httpdListenPort) == false)
                httpdListenPort++;
            return httpdListenPort;
        }

        private int findMySqlPort()
        {
            //check used port
            int mySqlPort = 3306;
            while (CheckAvailableServerPort(mySqlPort) == false)
                mySqlPort++;
            return mySqlPort;
        }

        //private void OpenPort(int port)
        //{
        //    var powershell = PowerShell.Create();
        //    var psCommand = $"New-NetFirewallRule -DisplayName \"<rule description>\" -Direction Inbound -LocalPort {port} -Protocol TCP -Action Allow";
        //    powershell.Commands.AddScript(psCommand);
        //    powershell.Invoke();
        //}

        private void SetupFirewallAllowIncomingRule(string ruleName, string path, int port)
        {
            try
            {
                //MessageBox.Show("set rule for: " + path.ToString());
                //_log.Debug("Creating instance of Windows Firewall policy (HNetCfg.FwPolicy2)...");
                INetFwPolicy2 firewallPolicy = Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2")) as INetFwPolicy2;

                if (null == firewallPolicy)
                {
                    //_log.Error("HNetCfg.FwPolicy2 instance could not be created!");
                    return;
                }

                string name = "e-LearningHV Rule Port " + port.ToString();

                foreach (INetFwRule2 rule in firewallPolicy.Rules)
                {
                    if (name.Equals(rule.Name))
                    {
                        //_log.WarnFormat("Windows Firewall Rule ({0}) already exists. It will not be created again.", rule.Name);
                        return;
                    }
                }

                //_log.Debug("Creating new Windows Firewall Rule (HNetCfg.FWRule)...");
                INetFwRule firewallRule = Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule")) as INetFwRule;

                if (null == firewallRule)
                {
                    //_log.Error("HNetCfg.FWRule instance could not be created!");
                    return;
                }

                firewallRule.ApplicationName = path;// "Apache HTTP Server";// "//App Executable Path";
                firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                firewallRule.Enabled = true;
                firewallRule.InterfaceTypes = "All";
                firewallRule.Name = name;
                firewallRule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;

                //NOTE: Must do this after setting the Protocol!
                firewallRule.LocalPorts = port.ToString();

                //_log.DebugFormat("Adding Windows Firewall Rule {0}...", firewallRule.Name);

                firewallPolicy.Rules.Add(firewallRule);

                //_log.InfoFormat("Windows Firewall Rule {0} added.", firewallRule.Name);
            }
            catch (Exception ex3)
            {
                MessageBox.Show("Windows Firewall Rule could not be added for port " + port.ToString() + "!"+ ex3);
                //_log.Error("Windows Firewall Rule could not be added for port " + port.ToString() + "!", ex);
            }
        }
        public void setRuleFireWall(string ruleName,string path,string port)
        {
            //MessageBox.Show("set rule for: " + path.ToString());
            //allow firewall
            INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(
                Type.GetTypeFromProgID("HNetCfg.FWRule"));

            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
                Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            firewallRule.ApplicationName = path;// "Apache HTTP Server";// "//App Executable Path";

            firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            firewallRule.Description = "e-LearningHV";// "sample rule mera";
            firewallRule.Enabled = true;
            firewallRule.LocalPorts = port;
            firewallRule.InterfaceTypes = "All";
            firewallRule.Name = ruleName;// $"// App Name";


            firewallPolicy.Rules.Add(firewallRule);
        }

        public void deleteCacheStuffs(string path)
        {


            if (Directory.Exists(path))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(path);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
        }

        int kt = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //if (kt == 0)
            {
                splcapnhat.ShowWaitForm();
                kt = 1;
                foreach (var process in Process.GetProcessesByName("mysqld"))
                    process.Kill();
                foreach (var process in Process.GetProcessesByName("httpd"))
                    process.Kill();

                Thread.Sleep(2000);

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
                rootPath += "\\" + gridView1.GetFocusedDataRow()["courseName"].ToString();

                //delete moodle cache
                deleteCacheStuffs(rootPath + "\\server\\moodledata\\cache\\");

                int httpdPort = findHttpdPort();
                //if (httpdPort != 80)
                changeHTTPDPort(rootPath, rootPath, httpdPort);

                int httpdListenPort = findHttpdListenPort();
                changeHTTPDListenPort(rootPath, rootPath, httpdListenPort);

                int mySqlPort = findMySqlPort();



                //!!!MessageBox.Show("httpdPort:"+ httpdPort+ " \r\n httpdListenPort:"+ httpdListenPort+"\r\n mysql port: "+ Program.port_mysql);
                //MessageBox.Show("httpdPort:"+ httpdPort+ " httpdListenPort:"+ httpdListenPort);
                Program.port_http = httpdPort.ToString();
                Program.port_mysql = mySqlPort.ToString();
                //MessageBox.Show(gridView1.GetFocusedDataRow()["courseName"].ToString());


                //-- kiem tra courseName
                string kt_string_KT = capnhat_usages_id_re_GV_KT(gridView1.GetFocusedDataRow()["courseName"].ToString());
                string kt_string_gv = capnhat_usages_id_re_GV(gridView1.GetFocusedDataRow()["courseName"].ToString());
                lblStatus.Text = kt_string_gv;
                Program.Name_Courses = gridView1.GetFocusedDataRow()["courseName"].ToString();
                lblname.Text = Program.Name_Courses;
                Program.Name_Courses_GV = gridView1.GetFocusedDataRow()["courseName"].ToString();
                if (kt_string_KT != "0")
                {
                    if (File.Exists(rootPath + "\\server\\apache\\bin\\httpd.exe"))
                    {
                        SetupFirewallAllowIncomingRule($"Apache HTTP Server", rootPath + "\\server\\apache\\bin\\httpd.exe", httpdPort);

                        Process_Open(rootPath + "\\server\\apache\\bin\\httpd.exe", "");
                    }
                    if (File.Exists(rootPath + "\\server\\mysql\\bin\\mysqld.exe"))
                    {
                        SetupFirewallAllowIncomingRule($"mysqld", rootPath + "\\server\\mysql\\bin\\mysqld.exe", mySqlPort);

                        Process_Open(rootPath + "\\server\\mysql\\bin\\mysqld.exe", "");
                    }
                    while (findHttpdPort() == httpdPort)
                        Thread.Sleep(1000);
                    while (httpdListenPort == findHttpdListenPort())
                        Thread.Sleep(1000);
                    while (mySqlPort == findMySqlPort())
                        Thread.Sleep(1000);
                }
                else
                {
                    System.Diagnostics.Process.Start(rootPath + "\\starMoodle.bat");

                    while (findHttpdPort() == httpdPort)
                        Thread.Sleep(1000);
                    while (httpdListenPort == findHttpdListenPort())
                        Thread.Sleep(1000);
                    while (mySqlPort == findMySqlPort())
                        Thread.Sleep(1000);
                    // mo xong doan nay con chay doan cap nhat
                    //string luu = Name_Courses + gridView1.GetFocusedDataRow()["courseName"].ToString();
                    //luuxml("Config - Offline.xml", "Name_Courses", luu);
                    //kiemtrasoluongbai();
                    capnhat_Courses_GV_KT(gridView1.GetFocusedDataRow()["courseName"].ToString());
                    //-------------
                    foreach (var process in Process.GetProcessesByName("mysqld"))
                        process.Kill();
                    foreach (var process in Process.GetProcessesByName("httpd"))
                        process.Kill();
                    Thread.Sleep(2000);
                    if (File.Exists(rootPath + "\\server\\apache\\bin\\httpd.exe"))
                    {
                        SetupFirewallAllowIncomingRule($"Apache HTTP Server", rootPath + "\\server\\apache\\bin\\httpd.exe", httpdPort);

                        Process_Open(rootPath + "\\server\\apache\\bin\\httpd.exe", "");
                    }
                    if (File.Exists(rootPath + "\\server\\mysql\\bin\\mysqld.exe"))
                    {
                        SetupFirewallAllowIncomingRule($"mysqld", rootPath + "\\server\\mysql\\bin\\mysqld.exe", mySqlPort);

                        Process_Open(rootPath + "\\server\\mysql\\bin\\mysqld.exe", "");
                    }
                    while (findHttpdPort() == httpdPort)
                        Thread.Sleep(1000);
                    while (httpdListenPort == findHttpdListenPort())
                        Thread.Sleep(1000);
                    while (mySqlPort == findMySqlPort())
                        Thread.Sleep(1000);
                    //--------------------------
                }

                if (httpdPort != 80)
                    System.Diagnostics.Process.Start("http://localhost:" + httpdPort.ToString());
                else
                    System.Diagnostics.Process.Start("http://localhost");
                splcapnhat.CloseWaitForm();
            }

        }

        //void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    uploadMarks();
        //    //upload
        //}

        void kiemtrasoluongbai()
        {
            Name_Courses = duongdan(@"Config - Offline.xml", "Name_Courses");
        }
        private static string duongdan(string url, string name)
        {
            string _config = "";
            string server = "";
            XmlReader xmlReader;
            if (url.IndexOf("http") > 0)
            {
                xmlReader = XmlReader.Create(url);
            }
            else
            {
                xmlReader = new XmlTextReader(url);
            }

            try
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.Name == name)
                    {
                        _config = xmlReader.ReadElementString();
                    }
                    if (xmlReader.Name == "server")
                    {
                        server = xmlReader.ReadElementString();
                    }
                }
                xmlReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo lỗi!");
            }
            Cursor.Current = Cursors.Default;
            // su dung kiem tra port
            return _config;
        }
        void capnhat_usages_id(string Name_Courses)
        {
            DataTable dsmaxusages_id = new DataTable();
            dsmaxusages_id = clq.mdl_question_usages_max();
            luuxml("Config - Offline.xml", "usages_id", dsmaxusages_id.Rows[0][0].ToString());
            RegistryWriter rg = new RegistryWriter();
            rg.WriteKey(Name_Courses, dsmaxusages_id.Rows[0][0].ToString());
            Program.usages_id = dsmaxusages_id.Rows[0][0].ToString();
        }
        void capnhat_usages_id_GV(string Name_Courses)
        {
            int dsmaxusages_id = 0;
            dsmaxusages_id = clq.mdl_question_usages_DS_state_finished_();
            luuxml("Config - Offline.xml", "usages_id", dsmaxusages_id.ToString());
            RegistryWriter rg = new RegistryWriter();
            rg.WriteKey(Name_Courses + "_GV", dsmaxusages_id.ToString());
            Program.usages_id_Load = dsmaxusages_id.ToString();
        }
        void capnhat_Courses_GV_KT(string Name_Courses)
        {
            rg.WriteKey(Name_Courses + "_GV_KT", 1.ToString());
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
        string Name_Courses = "";
        void Process_Open(string program_name, string arg)
        {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();

            //strCommand is path and file name of command to run
            pProcess.StartInfo.FileName = program_name;

            //strCommandParameters are parameters to pass to program
            pProcess.StartInfo.Arguments = arg;

            pProcess.StartInfo.UseShellExecute = false;

            //Set output of program to be written to process output stream
            pProcess.StartInfo.RedirectStandardOutput = true;

            pProcess.StartInfo.RedirectStandardError = true;
            //Optional
            // pProcess.StartInfo.WorkingDirectory = strWorkingDirectory;
            // hide commandline
            pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
        }
        public static string capnhat_usages_id_re(string Name_Courses)
        {
            RegistryWriter rg = new RegistryWriter();
            string usages_id = "";
            usages_id = rg.valuekey(Name_Courses);
            Program.usages_id = usages_id;
            return usages_id;
        }
        public static string capnhat_usages_id_re_GV(string Name_Courses)
        {
            RegistryWriter rg = new RegistryWriter();
            string usages_id = "";
            usages_id = rg.valuekey(Name_Courses + "_GV");
            Program.usages_id_Load = usages_id;
            return usages_id;
        }
        public static string capnhat_usages_id_re_GV_KT(string Name_Courses)
        {
            RegistryWriter rg = new RegistryWriter();
            string usages_id = "";
            usages_id = rg.valuekey(Name_Courses + "_GV_KT");
            return usages_id;
        }
        public void uploadMarks()
        {
            //MessageBox.Show("init upload marks");
            //statusInfo1.Text = "Đang đồng bộ nội dung...";

            originalForm.kiemtrataikhoan();
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"Config - Offline.xml");
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            // MessageBox.Show(node.Name);
            foreach (XmlNode nodechild in node.ChildNodes)
            {
                //MessageBox.Show(nodechild.Name);
                if (nodechild.Name == "up_grade")
                {
                    nodechild.InnerText = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    Program.up_grade = nodechild.InnerText;
                }
            }
            //lblStatus.Text = "Develop by Hoàng Việt E-Learning. Nộp điểm gần nhất lúc: " + Program.up_grade;
            myXmlDocument.Save("Config - Offline.xml");
            if (Program.kieunopbai == "1")
            {
                //splcapnhat.ShowWaitForm();
                nopdiem_sql();
                nopdiem();
                //splcapnhat.CloseWaitForm();
            }
            else
            {
                //splcapnhat.ShowWaitForm();
                nopdiem();
                nopdiemquiz();
                //splcapnhat.CloseWaitForm();
            }

            //statusInfo1.Text = "Đã đồng bộ nội dung (" + DateTime.Now.ToString("dd/MM/yyyy HH:mm").ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            uploadMarks();
        }
        void nopdiemquiz()
        {
            batdau = DateTime.Now.ToString();
            DataTable ds_mdl_quiz_attempts = new DataTable();
            DataTable ds_mdl_quiz_grades = new DataTable();
            DataTable dsmdl_quiz_grades_KT = new DataTable();
            ds_mdl_quiz_grades = clqg.mdl_quiz_grades_DS(Program.id_user);
            protiendo.Value = 0;
            protiendo.Maximum = ds_mdl_quiz_grades.Rows.Count;
            for (int i = 0; i < ds_mdl_quiz_grades.Rows.Count; i++)
            {
                protiendo.Value++;
                protiendo.Refresh();
                dsmdl_quiz_grades_KT = clqg.mdl_quiz_grades_DS_quiz_userid(Int64.Parse(ds_mdl_quiz_grades.Rows[i][1].ToString()), Int64.Parse(ds_mdl_quiz_grades.Rows[i][2].ToString()));
                if (dsmdl_quiz_grades_KT.Rows.Count == 0)
                {
                    clqg.quiz = Int64.Parse(ds_mdl_quiz_grades.Rows[i][1].ToString());
                    clqg.userid = Int64.Parse(ds_mdl_quiz_grades.Rows[i][2].ToString());
                    clqg.grade = ds_mdl_quiz_grades.Rows[i][3].ToString();
                    clqg.timemodified = Int64.Parse(ds_mdl_quiz_grades.Rows[i][4].ToString());
                    clqg.mdl_quiz_grades_Them();
                }
                else
                {
                    if (dsmdl_quiz_grades_KT.Rows[0][3].ToString() != ds_mdl_quiz_grades.Rows[i][3].ToString())
                    {
                        clqg.id = Int64.Parse(dsmdl_quiz_grades_KT.Rows[0][0].ToString());
                        clqg.grade = ds_mdl_quiz_grades.Rows[i][3].ToString();
                        clqg.timemodified = Int64.Parse(ds_mdl_quiz_grades.Rows[i][4].ToString());
                        clqg.mdl_quiz_grades_Sua();
                    }
                }
            }
        }
        string batdau = "";
        string ketthuc = "";
        void nopdiem()
        {
            DataTable dsmdl_grade_grades = new DataTable();
            DataTable dsmdl_grade_grades_KT = new DataTable();

            dsmdl_grade_grades = clnd.mdl_grade_grades_ds_userid(int.Parse(Program.id_user));
            for (int i = 0; i < dsmdl_grade_grades.Rows.Count; i++)
            {
                dsmdl_grade_grades_KT = clnd.mdl_grade_grades_DS_Itemid_Userid(Int64.Parse(dsmdl_grade_grades.Rows[i]["itemid"].ToString()), Int64.Parse(dsmdl_grade_grades.Rows[i]["userid"].ToString()));
                if (dsmdl_grade_grades_KT.Rows.Count == 0)//them moi
                {
                    clnd.itemid = Int64.Parse(dsmdl_grade_grades.Rows[i]["itemid"].ToString());
                    clnd.userid = Int64.Parse(dsmdl_grade_grades.Rows[i]["userid"].ToString());
                    clnd.rawgrade = (dsmdl_grade_grades.Rows[i]["rawgrade"].ToString());
                    clnd.rawgrademax = (dsmdl_grade_grades.Rows[i]["rawgrademax"].ToString());
                    clnd.rawgrademin = (dsmdl_grade_grades.Rows[i]["rawgrademin"].ToString());
                    clnd.rawscaleid = (dsmdl_grade_grades.Rows[i]["rawscaleid"].ToString());
                    clnd.usermodified = (dsmdl_grade_grades.Rows[i]["usermodified"].ToString());
                    clnd.finalgrade = (dsmdl_grade_grades.Rows[i]["finalgrade"].ToString());
                    clnd.hidden = Int64.Parse(dsmdl_grade_grades.Rows[i]["hidden"].ToString());
                    clnd.locked = Int64.Parse(dsmdl_grade_grades.Rows[i]["locked"].ToString());
                    clnd.locktime = Int64.Parse(dsmdl_grade_grades.Rows[i]["locktime"].ToString());
                    clnd.exported = Int64.Parse(dsmdl_grade_grades.Rows[i]["exported"].ToString());
                    clnd.overridden = Int64.Parse(dsmdl_grade_grades.Rows[i]["overridden"].ToString());
                    clnd.excluded = Int64.Parse(dsmdl_grade_grades.Rows[i]["excluded"].ToString());
                    clnd.feedback = (dsmdl_grade_grades.Rows[i]["feedback"].ToString());
                    clnd.feedbackformat = Int64.Parse(dsmdl_grade_grades.Rows[i]["feedbackformat"].ToString());
                    clnd.information = (dsmdl_grade_grades.Rows[i]["information"].ToString());
                    clnd.informationformat = Int64.Parse(dsmdl_grade_grades.Rows[i]["informationformat"].ToString());
                    clnd.timecreated = (dsmdl_grade_grades.Rows[i]["timecreated"].ToString());
                    clnd.timemodified = (dsmdl_grade_grades.Rows[i]["timemodified"].ToString());
                    clnd.aggregationstatus = (dsmdl_grade_grades.Rows[i]["aggregationstatus"].ToString());
                    clnd.aggregationweight = (dsmdl_grade_grades.Rows[i]["aggregationweight"].ToString());
                    if (clnd.mdl_grade_grades_Them() == true)
                    {
                        //thong bao toi server khong nop diem duoc
                    }
                }
                else
                {//cap nhat
                    if (dsmdl_grade_grades.Rows[i]["rawgrade"].ToString() != dsmdl_grade_grades_KT.Rows[0]["rawgrade"].ToString())
                    {//co diem moi thi moi cap nhat
                        clnd.itemid = Int64.Parse(dsmdl_grade_grades.Rows[i]["itemid"].ToString());
                        clnd.userid = Int64.Parse(dsmdl_grade_grades.Rows[i]["userid"].ToString());
                        clnd.rawgrade = (dsmdl_grade_grades.Rows[i]["rawgrade"].ToString());
                        clnd.rawgrademax = (dsmdl_grade_grades.Rows[i]["rawgrademax"].ToString());
                        clnd.rawgrademin = (dsmdl_grade_grades.Rows[i]["rawgrademin"].ToString());
                        clnd.rawscaleid = (dsmdl_grade_grades.Rows[i]["rawscaleid"].ToString());
                        clnd.usermodified = (dsmdl_grade_grades.Rows[i]["usermodified"].ToString());
                        clnd.finalgrade = (dsmdl_grade_grades.Rows[i]["finalgrade"].ToString());
                        clnd.hidden = Int64.Parse(dsmdl_grade_grades.Rows[i]["hidden"].ToString());
                        clnd.locked = Int64.Parse(dsmdl_grade_grades.Rows[i]["locked"].ToString());
                        clnd.locktime = Int64.Parse(dsmdl_grade_grades.Rows[i]["locktime"].ToString());
                        clnd.exported = Int64.Parse(dsmdl_grade_grades.Rows[i]["exported"].ToString());
                        clnd.overridden = Int64.Parse(dsmdl_grade_grades.Rows[i]["overridden"].ToString());
                        clnd.excluded = Int64.Parse(dsmdl_grade_grades.Rows[i]["excluded"].ToString());
                        clnd.feedback = (dsmdl_grade_grades.Rows[i]["feedback"].ToString());
                        clnd.feedbackformat = Int64.Parse(dsmdl_grade_grades.Rows[i]["feedbackformat"].ToString());
                        clnd.information = (dsmdl_grade_grades.Rows[i]["information"].ToString());
                        clnd.informationformat = Int64.Parse(dsmdl_grade_grades.Rows[i]["informationformat"].ToString());
                        clnd.timecreated = (dsmdl_grade_grades.Rows[i]["timecreated"].ToString());
                        clnd.timemodified = (dsmdl_grade_grades.Rows[i]["timemodified"].ToString());
                        clnd.aggregationstatus = (dsmdl_grade_grades.Rows[i]["aggregationstatus"].ToString());
                        clnd.aggregationweight = (dsmdl_grade_grades.Rows[i]["aggregationweight"].ToString());
                        if (clnd.mdl_grade_grades_Sua_Itemid_Userid() == true)
                        {
                            //thong bao toi server khong nop diem duoc
                        }
                    }
                }
            }
        }
        void nopdiem_sql()
        {
            batdau = DateTime.Now.ToString();
            DataTable ds_mdl_quiz_attempts = new DataTable();
            DataTable ds_mdl_quiz_grades = new DataTable();
            DataTable dsmdl_quiz_grades_KT = new DataTable();
            ds_mdl_quiz_grades = clqg.mdl_quiz_grades_DS(Program.id_user);
            protiendo.Value = 0;
            protiendo.Maximum = ds_mdl_quiz_grades.Rows.Count;
            
            for (int i = 0; i < ds_mdl_quiz_grades.Rows.Count; i++)
            {
                protiendo.Value++;
                protiendo.Refresh();
                dsmdl_quiz_grades_KT = clqg.mdl_quiz_grades_DS_quiz_userid(Int64.Parse(ds_mdl_quiz_grades.Rows[i][1].ToString()), Int64.Parse(ds_mdl_quiz_grades.Rows[i][2].ToString()));
                if (dsmdl_quiz_grades_KT.Rows.Count == 0)
                {
                    clqg.quiz = Int64.Parse(ds_mdl_quiz_grades.Rows[i][1].ToString());
                    clqg.userid = Int64.Parse(ds_mdl_quiz_grades.Rows[i][2].ToString());
                    clqg.grade = ds_mdl_quiz_grades.Rows[i][3].ToString();
                    clqg.timemodified = Int64.Parse(ds_mdl_quiz_grades.Rows[i][4].ToString());
                    clqg.mdl_quiz_grades_Them();
                }
                else
                {
                    if (dsmdl_quiz_grades_KT.Rows[0][3].ToString() != ds_mdl_quiz_grades.Rows[i][3].ToString())
                    {
                        clqg.id = Int64.Parse(dsmdl_quiz_grades_KT.Rows[0][0].ToString());
                        clqg.grade = ds_mdl_quiz_grades.Rows[i][3].ToString();
                        clqg.timemodified = Int64.Parse(ds_mdl_quiz_grades.Rows[i][4].ToString());
                        clqg.mdl_quiz_grades_Sua();
                    }
                }
            }

            DataTable ds_mdl_question_usages = new DataTable();
            DataTable ds_mdl_question_attempts = new DataTable();
            ds_mdl_question_usages = clq.mdl_question_usages_DS();
            protiendo.Value = 0;
            protiendo.Maximum = ds_mdl_question_usages.Rows.Count;
            for (int i = 0; i < ds_mdl_question_usages.Rows.Count; i++)
            {
                protiendo.Value++;
                protiendo.Refresh();
                if (int.Parse(ds_mdl_question_usages.Rows[i][0].ToString()) > int.Parse(Program.usages_id))
                {
                    ds_mdl_question_attempts = clq.mdl_question_attempts_DS(ds_mdl_question_usages.Rows[i][0].ToString());
                    clq.contextid = ds_mdl_question_usages.Rows[i][1].ToString();
                    clq.component = ds_mdl_question_usages.Rows[i][2].ToString();
                    clq.preferredbehaviour = ds_mdl_question_usages.Rows[i][3].ToString();

                    ds_mdl_quiz_attempts = clqg.mdl_quiz_attempts_DS_uniqueid(ds_mdl_question_usages.Rows[i][0].ToString());
                    clq.mdl_question_usages_Them(ds_mdl_question_attempts, ds_mdl_quiz_attempts);
                    luuxml("Config - Offline.xml", "usages_id", ds_mdl_question_usages.Rows[i][0].ToString());
                    rg.WriteKey(Program.Name_Courses, ds_mdl_question_usages.Rows[i][0].ToString());
                    Program.usages_id = ds_mdl_question_usages.Rows[i][0].ToString();
                }
            }
            ketthuc = DateTime.Now.ToString();
        }
        RegistryWriter rg = new RegistryWriter();
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("mysqld"))
                process.Kill();
            foreach (var process in Process.GetProcessesByName("httpd"))
                process.Kill();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (kt != 2)
            {
                if (MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    foreach (var process in Process.GetProcessesByName("mysqld"))
                        process.Kill();
                    foreach (var process in Process.GetProcessesByName("httpd"))
                        process.Kill();
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Trong lúc tải bài không được tắt ứng dụng.", "Thông báo!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (kt == 1)
            {
                lbltiendo.ForeColor = Color.Red;
                Task.Run(() =>
                {
                    lbltiendo.Text = "Bắt đầu.";
                    taidiem();
                    lbltiendo.Text = "Kết thúc.";
                });

            }
        }
        void taidiem()
        {
            splcapnhat.ShowWaitForm();
            kt = 2;
            DataTable ds_mdl_question_usages = new DataTable();
            DataTable mdl_question_usages_max = new DataTable();
            DataTable ds_mdl_question_attempts = new DataTable();
            DataTable mdl_question_attempt_steps_questionattemptid = new DataTable();
            DataTable mdl_question_attempt_step = new DataTable();
            DataTable mdl_question_attempt_step_data = new DataTable();
            DataTable mdl_quiz_attempts = new DataTable();
            DataTable mdl_quiz_grades = new DataTable();
            mdl_quiz_grades = clq.mdl_quiz_grades_DS();
            clq.mdl_quiz_grades_Xoa_ID_1();
            for (int i = 0; i < mdl_quiz_grades.Rows.Count; i++)
            {
                lbltiendo.Text = "Đang Thực hiện tải điểm: " + i.ToString() + "/" + mdl_quiz_grades.Rows.Count.ToString();
                clq.mdl_quiz_grades_Them(mdl_quiz_grades.Rows[i][1].ToString(), mdl_quiz_grades.Rows[i][2].ToString(), mdl_quiz_grades.Rows[i][3].ToString(), mdl_quiz_grades.Rows[i][4].ToString());
            }
            //-- tải điểm
            //-- chi tiet cau hoi
            ds_mdl_question_usages = clq.mdl_question_usages_DS_sql();
           
            for (int i = int.Parse(Program.usages_id_Load); i < ds_mdl_question_usages.Rows.Count; i++)
            {
                lbltiendo.Text = "Đang Thực hiện tải chi tiết bài làm: " + i.ToString() + "/" + ds_mdl_question_usages.Rows.Count.ToString();
                if (int.Parse(ds_mdl_question_usages.Rows[i][0].ToString()) >= int.Parse(Program.usages_id_Load))
                {
                    {
                        clq.mdl_question_usages_Them(ds_mdl_question_usages.Rows[i][1].ToString(), ds_mdl_question_usages.Rows[i][2].ToString(), ds_mdl_question_usages.Rows[i][3].ToString());

                        mdl_question_usages_max = clq.mdl_question_usages_max();

                        mdl_quiz_attempts = clq.mdl_quiz_attempts_DS_uniqueid(ds_mdl_question_usages.Rows[i][0].ToString());

                        clq.mdl_quiz_attempts_Them(mdl_quiz_attempts.Rows[0][1].ToString(), mdl_quiz_attempts.Rows[0][2].ToString(), mdl_quiz_attempts.Rows[0][3].ToString(), mdl_question_usages_max.Rows[0][0].ToString(), mdl_quiz_attempts.Rows[0][5].ToString(), mdl_quiz_attempts.Rows[0][6].ToString(), mdl_quiz_attempts.Rows[0][7].ToString(), mdl_quiz_attempts.Rows[0][8].ToString(), mdl_quiz_attempts.Rows[0][9].ToString(), mdl_quiz_attempts.Rows[0][10].ToString(), mdl_quiz_attempts.Rows[0][11].ToString(), mdl_quiz_attempts.Rows[0][12].ToString(), mdl_quiz_attempts.Rows[0][13].ToString(), mdl_quiz_attempts.Rows[0][14].ToString());

                        ds_mdl_question_attempts = clq.mdl_question_attempts_DS_questionusage_id(ds_mdl_question_usages.Rows[i][0].ToString());
                        mdl_question_attempt_steps_questionattemptid.Clear();
                        mdl_question_attempt_steps_questionattemptid.Columns.Clear();
                        mdl_question_attempt_steps_questionattemptid.Columns.Add("id");
                    }
                    for (int ii = 0; ii < ds_mdl_question_attempts.Rows.Count; ii++)
                    {
                        lbltiendo.Text = "Đang Thực hiện tải chi tiết bài làm: " + i.ToString() + "/" + ds_mdl_question_usages.Rows.Count.ToString() + "/1/" + ii.ToString() + "/" + ds_mdl_question_attempts.Rows.Count.ToString();
                        clq.mmdl_question_attempts_Them(mdl_question_usages_max.Rows[0][0].ToString(), ds_mdl_question_attempts.Rows[ii][2].ToString(), ds_mdl_question_attempts.Rows[ii][3].ToString(), ds_mdl_question_attempts.Rows[ii][4].ToString(), ds_mdl_question_attempts.Rows[ii][5].ToString(), ds_mdl_question_attempts.Rows[ii][6].ToString(), ds_mdl_question_attempts.Rows[ii][7].ToString(), ds_mdl_question_attempts.Rows[ii][8].ToString(), ds_mdl_question_attempts.Rows[ii][9].ToString(), ds_mdl_question_attempts.Rows[ii][10].ToString(), ds_mdl_question_attempts.Rows[ii][11].ToString(), ds_mdl_question_attempts.Rows[ii][12].ToString(), ds_mdl_question_attempts.Rows[ii][13].ToString());
                        mdl_question_attempt_steps_questionattemptid.Rows.Add(clq.mdl_question_attempts_max());
                    }
                    for (int ii = 0; ii < ds_mdl_question_attempts.Rows.Count; ii++)
                    {
                        lbltiendo.Text = "Đang Thực hiện tải chi tiết bài làm: " + i.ToString() + "/" + ds_mdl_question_usages.Rows.Count.ToString() + "/2/" + ii.ToString() + "/" + ds_mdl_question_attempts.Rows.Count.ToString();
                        mdl_question_attempt_step = clq.mdl_question_attempt_steps_DS_questionattemptid_sequencenumber(ds_mdl_question_attempts.Rows[ii][0].ToString(), 0.ToString());
                        clq.mdl_question_attempt_steps_Them(mdl_question_attempt_steps_questionattemptid.Rows[ii][0].ToString(), mdl_question_attempt_step.Rows[0][2].ToString(), mdl_question_attempt_step.Rows[0][3].ToString(), mdl_question_attempt_step.Rows[0][5].ToString(), mdl_question_attempt_step.Rows[0][6].ToString());

                        mdl_question_attempt_step_data = clq.mdl_question_attempt_step_data_ds_id(mdl_question_attempt_step.Rows[0][0].ToString());
                        clq.mdl_question_attempt_step_data_Them(clq.mdl_question_attempt_steps_max(), mdl_question_attempt_step_data.Rows[0][2].ToString(), mdl_question_attempt_step_data.Rows[0][3].ToString());
                    }

                    for (int ii = 0; ii < ds_mdl_question_attempts.Rows.Count; ii++)
                    {
                        lbltiendo.Text = "Đang Thực hiện tải chi tiết bài làm: " + i.ToString() + "/" + ds_mdl_question_usages.Rows.Count.ToString() + "/3/" + ii.ToString() + "/" + ds_mdl_question_attempts.Rows.Count.ToString();
                        mdl_question_attempt_step = clq.mdl_question_attempt_steps_DS_questionattemptid_sequencenumber(ds_mdl_question_attempts.Rows[ii][0].ToString(), 1.ToString());
                        clq.mdl_question_attempt_steps_Them(mdl_question_attempt_steps_questionattemptid.Rows[ii][0].ToString(), mdl_question_attempt_step.Rows[0][2].ToString(), mdl_question_attempt_step.Rows[0][3].ToString(), mdl_question_attempt_step.Rows[0][5].ToString(), mdl_question_attempt_step.Rows[0][6].ToString());
                        mdl_question_attempt_step_data = clq.mdl_question_attempt_step_data_ds_id(mdl_question_attempt_step.Rows[0][0].ToString());
                        if (mdl_question_attempt_step_data.Rows.Count > 0)
                        {
                            clq.mdl_question_attempt_step_data_Them(clq.mdl_question_attempt_steps_max(), mdl_question_attempt_step_data.Rows[0][2].ToString(), mdl_question_attempt_step_data.Rows[0][3].ToString());
                        }
                    }
                    for (int ii = 0; ii < ds_mdl_question_attempts.Rows.Count; ii++)
                    {
                        lbltiendo.Text = "Đang Thực hiện tải chi tiết bài làm: " + i.ToString() + "/" + ds_mdl_question_usages.Rows.Count.ToString() + "/4/" + ii.ToString() + "/" + ds_mdl_question_attempts.Rows.Count.ToString();
                        mdl_question_attempt_step = clq.mdl_question_attempt_steps_DS_questionattemptid_sequencenumber(ds_mdl_question_attempts.Rows[ii][0].ToString(), 2.ToString());
                        if (mdl_question_attempt_step.Rows.Count > 0)
                        {
                            clq.mdl_question_attempt_steps__fraction_Them(mdl_question_attempt_steps_questionattemptid.Rows[ii][0].ToString(), mdl_question_attempt_step.Rows[0][2].ToString(), mdl_question_attempt_step.Rows[0][3].ToString(), mdl_question_attempt_step.Rows[0][4].ToString(), mdl_question_attempt_step.Rows[0][5].ToString(), mdl_question_attempt_step.Rows[0][6].ToString());
                            mdl_question_attempt_step_data = clq.mdl_question_attempt_step_data_ds_id(mdl_question_attempt_step.Rows[0][0].ToString());
                            if (mdl_question_attempt_step_data.Rows.Count > 0)
                            {
                                clq.mdl_question_attempt_step_data_Them(clq.mdl_question_attempt_steps_max(), mdl_question_attempt_step_data.Rows[0][2].ToString(), mdl_question_attempt_step_data.Rows[0][3].ToString());
                            }
                        }
                    }

                    int iii = int.Parse(Program.usages_id_Load);
                    iii = ++iii;
                    //luuxml("Config-usages-id.xml", "usages_id_Load", iii.ToString());
                    Program.usages_id_Load = iii.ToString();
                    RegistryWriter rg = new RegistryWriter();
                    rg.WriteKey(Program.Name_Courses_GV + "_GV", iii.ToString());
                    lblStatus.Text = iii.ToString();
                }
            }
            hoanthanhtacvu();
            kt = 1;
            splcapnhat.CloseWaitForm();
        }
        private void Request_ResponseReceived(Google.Apis.Drive.v3.Data.File obj)
        {
            if (obj != null)
            {
                MessageBox.Show("File was uploaded sucessfully--" + obj.Id);
            }
        }

        string textBox2 = "";
        private void Request_ProgressChanged(Google.Apis.Upload.IUploadProgress obj)
        {
            //!!textBox2.Text += obj.Status + " " + obj.BytesSent;
            textBox2 += obj.Status + " " + obj.BytesSent;
            //label2.Text = obj.BytesSent.ToString();


        }

        //public void updateStatusBar1(long bytes, string msg,string focusCourse)
        public void updateStatusBar1(long bytes, string msg)
        {
            if (InvokeRequired)
            {
                //Invoke(new Action<long, string,string>(updateStatusBar1), new object[] { bytes, msg, focusCourse });
                Invoke(new Action<long, string>(updateStatusBar1), new object[] { bytes, msg });
                return;
            }
            protiendo.Minimum = 0;
            protiendo.Maximum = 100;
            protiendo.Value = (int)bytes;
            //label2.Text = "Uploading...";
            //if (bytes == 100)
            //    label2.Text = "Done Upload";
            gridView1.FocusedRowHandle = focusRow;
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                string focusCourse = gridView1.GetFocusedDataRow()["courseName"].ToString();
                string courseI = ds.Rows[i]["courseName"].ToString();
                if (focusCourse == courseI)
                {
                    //ds.Rows[i]["status"] = "Zipping...";
                    //gridControl1.DataSource = ds;
                    gridView1.SetRowCellValue(i, "status", "uploading");
                    int percentR = (int)bytes;
                    gridView1.SetRowCellValue(i, "percent", percentR.ToString()+"%");//progressBar2.Value.ToString());//
                    gridView1.RefreshData();
                    break;
                }
            }
            //progressBar.Value = (int)bytes;
            //lblProgress.Text = msg;
            //lblProgress.Location = new Point(this.ClientRectangle.Width - lblProgress.Width - progressBar.Width - 20, 4);

        }

        //public Google.Apis.Drive.v3.Data.File uploadFile(DriveService _service, string _uploadFile, string _parent, listCoursesToRun parentForm,string focusCourse, string _descrp = "Uploaded with .NET!")
        public Google.Apis.Drive.v3.Data.File uploadFile(DriveService _service, string _uploadFile, string _parent, ListCoursesToRun_Teacherslist parentForm, string _descrp = "Uploaded with .NET!")
        {
            //label2.Text = "Uploading...";
            
            ListCoursesToRun_Teacherslist parent = parentForm;
            //parent.progressBar2.Visible = true;
            long totalSize = 100000;
            //long totalSize = 10000000000;
            if (System.IO.File.Exists(_uploadFile))
            {
                FileInfo fi = new FileInfo(_uploadFile);
                totalSize = fi.Length;

                Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                body.Name = System.IO.Path.GetFileName(_uploadFile);
                body.Description = _descrp;
                body.MimeType = GetMimeType(_uploadFile);
                body.Parents = new List<string> { _parent };// UN comment if you want to upload to a folder(ID of parent folder need to be send as paramter in above method)
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);//kiểm tra dung lượng file gửi lên tính % xem gửi được bao nhiêu % lên để hiện thị cho người dung
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.CreateMediaUpload request = _service.Files.Create(body, stream, GetMimeType(_uploadFile));
                    request.SupportsTeamDrives = true;
                    // You can bind event handler with progress changed event and response recieved(completed event)
                    request.ProgressChanged += Request_ProgressChanged;
                    request.ResponseReceived += Request_ResponseReceived;
                    request.ProgressChanged += (IUploadProgress progress) =>
                    {
                        switch (progress.Status)
                        {
                            case UploadStatus.Uploading:
                                {
                                    //parent.updateStatusBar1((progress.BytesSent * 100) / totalSize, "Uploading...", focusCourse);
                                    parent.updateStatusBar1((progress.BytesSent * 100) / totalSize, "Uploading...");
                                    System.Diagnostics.Debug.WriteLine(progress.BytesSent);
                                    break;
                                }
                            case UploadStatus.Completed:
                                {

                                    //parent.updateStatusBar1(100, "Upload complete.", focusCourse);
                                    parent.updateStatusBar1(100, "Upload complete.");
                                    System.Diagnostics.Debug.WriteLine("Upload complete.");
                                    if (File.Exists(_uploadFile) == true)
                                        File.Delete(_uploadFile);
                                    //parent.progressBar2.Visible = false;
                                    for (int i = 0; i < ds.Rows.Count; i++)
                                    {
                                        string focusCourse = gridView1.GetFocusedDataRow()["courseName"].ToString();
                                        string courseI = ds.Rows[i]["courseName"].ToString();
                                        if (focusCourse == courseI)
                                        {
                                            //ds.Rows[i]["status"] = "Zipping...";
                                            //gridControl1.DataSource = ds;
                                            gridView1.SetRowCellValue(i, "status", "Done");
                                            //int percentR = "100%";// (int)bytes;
                                            gridView1.SetRowCellValue(i, "percent", "100%");//progressBar2.Value.ToString());//
                                            gridView1.RefreshData();
                                            //progressBar2.Visible = false;

                                            //if (File.Exists(_uploadFile) == true)
                                            //    File.Delete(_uploadFile);
                                            break;
                                        }
                                    }

                                    break;
                                }
                            case UploadStatus.Failed:
                                {
                                    //parent.updateStatusBar(0, "Upload failed.");
                                    System.Diagnostics.Debug.WriteLine("Upload failed.");
                                    MessageBox.Show("File failed to upload!!!", "Upload Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //!Gtools.writeToFile(listCoursesToRun.errorLog, Environment.NewLine + DateTime.Now.ToString() +
                                    //!            Environment.NewLine + "Upload failed.\n");
                                    break;
                                }
                        }
                    };
                    request.Upload();
                    //label2.Text = "Done Upload";
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error Occured");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("The file does not exist.", "404");
                //label2.Text = "Done Upload";
                return null;
            }
            
            /*
            listCoursesToRun parent = parentForm;
            parent.updateStatusBar(0, "Uploading...");
            long totalSize = 100000;
            try
            {
                FileInfo fi = new FileInfo(_uploadFile);
                totalSize = fi.Length;

                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = _uploadFile
                };
                if (_parent != null)
                {
                    fileMetadata.Parents = new List<string>
                    {
                        _parent
                    };
                }
                FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(_uploadFile, System.IO.FileMode.Open))
                {
                    request = _service.Files.Create(
                        fileMetadata, stream, GetMimeType(_uploadFile));
                    request.ChunkSize = FilesResource.CreateMediaUpload.MinimumChunkSize;
                    request.ProgressChanged += (IUploadProgress progress) =>
                    {
                        switch (progress.Status)
                        {
                            case UploadStatus.Uploading:
                                {
                                    parent.updateStatusBar((progress.BytesSent * 100) / totalSize, "Uploading...");
                                    System.Diagnostics.Debug.WriteLine(progress.BytesSent);
                                    break;
                                }
                            case UploadStatus.Completed:
                                {

                                    parent.updateStatusBar(100, "Upload complete.");
                                    System.Diagnostics.Debug.WriteLine("Upload complete.");
                                    break;
                                }
                            case UploadStatus.Failed:
                                {
                                    parent.updateStatusBar(0, "Upload failed.");
                                    System.Diagnostics.Debug.WriteLine("Upload failed.");
                                    MessageBox.Show("File failed to upload!!!", "Upload Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //!Gtools.writeToFile(listCoursesToRun.errorLog, Environment.NewLine + DateTime.Now.ToString() +
                                    //!            Environment.NewLine + "Upload failed.\n");
                                    break;
                                }
                        }
                    };
                    request.Fields = "id";
                    request.Upload();
                }
                var file = request.ResponseBody;
                System.Diagnostics.Debug.WriteLine("File ID:{0} \n FileName {1} ", file.Id, file.Name);
                return file;
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message + " Upload file to Drive Error");
                MessageBox.Show(" Upload file to Drive Error");
                //!Gtools.writeToFile(frmMain.errorLog, Environment.NewLine + DateTime.Now.ToString() +
                //!    Environment.NewLine + exc.Message + " Upload file to Drive Error.\n");
                return null;
            }
            */
        }



        //!private void AuthorizeAndSendFile(string pathFile,string focusCourse)
        private void AuthorizeAndSendFile(string pathFile)
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
            //xác thực trên google
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
            //Long Operations like file uploads might timeout. 100 is just precautionary value, can be set to any reasonable value depending on what you use your service for  

            // team drive root https://drive.google.com/drive/folders/0AAE83zjNwK-GUk9PVA   

            //var respocne = uploadFile(service, textBox1.Text, "");
            //1HiuLTcwX2hdyWeN4zeUZ6kLOf17mFRR1
            //gửi file lên google
            Task.Run(() =>
            {
                //!var respocne = uploadFile(service, pathFile, "1HiuLTcwX2hdyWeN4zeUZ6kLOf17mFRR1", this, focusCourse);
                //string folderID = "1ULA06oJ3z9CTlcqN0BIxSnM42fM2P0R4";//grade-8
                string folderID = "";// "1HiuLTcwX2hdyWeN4zeUZ6kLOf17mFRR1";//grade-7
                string filename = Path.GetFileName(pathFile);
                folderID = getFolderIdFromCourseName(filename);
                var respocne = uploadFile(service, pathFile, folderID, this);// hàm gửi file
            });
            //var respocne = uploadFile(service, pathFile, "");// 1HiuLTcwX2hdyWeN4zeUZ6kLOf17mFRR1");
            // Third parameter is empty it means it would upload to root directory, if you want to upload under a folder, pass folder's id here.
            //!!MessageBox.Show("Process completed--- Response--" + respocne);

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
        // tries to figure out the mime type of the file.
        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        public void updateStatusBar(long bytes, string msg, string fileId)
        {

            if (InvokeRequired)
            {
                Invoke(new Action<long, string, string>(updateStatusBar), new object[] { bytes, msg, fileId });
                return;
            }
            //MessageBox.Show("hello");
            //label2.Text = bytes.ToString();
            //if (bytes == -1)
            //{
            //    //ds.Rows[rowId].va = "100";
            //    //gridControl1.s.SetRowCellValue(rowId, "status", "OK");
            //    //gridView1.SetRowCellValue(1, "status", "100%");
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //        if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
            //        {
            //            gridView1.SetRowCellValue(i, "status", "100%");
            //            gridView1.SetRowCellValue(i, "statusDU", "Done Download");
            //        }
            //    //MessageBox.Show("Course: " + msg + " is downloaded " + fileId);
            //}
            //else
            //{
            //    //progressBar.Value = (int)bytes; //20;// 
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //        if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
            //        {
            //            gridView1.SetRowCellValue(i, "status", bytes.ToString() + "%");
            //            gridView1.SetRowCellValue(i, "statusDU", "Downloading");
            //        }
            //    //if (progressBar.Value == 100)
            //    //    MessageBox.Show("Download Completed");
            //}
            //lblProgress.Text = msg;
            //lblProgress.Location = new Point(this.ClientRectangle.Width - lblProgress.Width - progressBar.Width - 20, 4);

        }

        private void CompressFolder(string folder, string targetFilename,ListCoursesToRun_Teacherslist parentForm)
        {
            ListCoursesToRun_Teacherslist lc = parentForm;
            //bool zipping = true;
            long size = Directory.GetFiles(folder).Select(o => new FileInfo(o).Length).Aggregate((a, b) => a + b);
            var fi = new FileInfo(targetFilename);
            //lc.updateStatusBar(fi.Length, "hello", "jldfsjf");
            //Task.Run(() =>
            //{
                //!ZipFile.CreateFromDirectory(folder, targetFilename, CompressionLevel.NoCompression, false);
            //  zipping = false;
            //});

            //int percentCompletedSoFar = 0;
            //while (zipping)
            //{
            //    if (File.Exists(targetFilename))
            //    {
            //        var fi = new FileInfo(targetFilename);
            //        System.Diagnostics.Debug.WriteLine($"Zip progress: {fi.Length}/{size}");
            //        lc.updateStatusBar(fi.Length, "hello","jfds");// = fi.Length.ToString();
            //    }
                
            //}
        }



        public int focusRow = 0;
        //bat dau nen va day khoa hoc
        void nen_upload()
        {
            //đóng tất cả tác vụ đang chạy tránh lỗi. tạo file nén tới 1885
            //kill all previous processes: mysqld, httpd
            foreach (var process in Process.GetProcessesByName("mysqld"))
                process.Kill();
            foreach (var process in Process.GetProcessesByName("httpd"))
                process.Kill();

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
                    break;
                }

            }

            //read rootPath
            //string rootPath = originalForm.readRootPath(originalForm.pathFileIni);
            rootPath += "\\" + gridView1.GetFocusedDataRow()["courseName"].ToString();

            //MessageBox.Show(rootPath);                        
            string partitionName = rootPath.Substring(0, rootPath.IndexOf(":") + 1);
            DirectoryInfo di = new DirectoryInfo(rootPath);

            string parentDir = di.Parent.FullName;
            //MessageBox.Show(di.Parent.FullName);
            DateTime dateTime = DateTime.UtcNow.Date;
            string dateTimeStr = DateTime.Now.ToString("_HHmm_MMddyyyy"); //dateTime.ToString("ddMMyyyy")+"_"+ dateTime.ToString("hhmm");
            //MessageBox.Show(dateTimeStr);

            
            string zipFile = parentDir + "\\" + gridView1.GetFocusedDataRow()["courseName"].ToString() + dateTimeStr + ".zip";

            zipFile = zipFile.Replace(".zip", "_NotYetConfirmed.zip");

            //zipFile = @"P:\\moodleLocalhost\\English06_1042_08282020_NotYetConfirmed.zip";
            
            if (File.Exists(zipFile) == true)
                File.Delete(zipFile);            
              
            //ZipFile.CreateFromDirectory(rootPath, zipFile);//, CompressionLevel.Fastest);

            //    Task.Run(() => {
            //        CompressFolder(rootPath, zipFile,this);
            //});
            //CreateTheZip(rootPath, zipFile);
            //zipping stuffs:

            string DirectoryToZip = rootPath;// folderBrowserDialog1.SelectedPath;
            string ZipFileToCreate = zipFile;// saveFileDialog1.FileName;

            //label2.Text = "Zipping...";
            //string rootPath = originalForm.readRootPath(originalForm.pathFileIni);
            //gridView1.GetFocusedDataRow()["courseName"].ToString();
            string focusCourse = "";
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                focusCourse = gridView1.GetFocusedDataRow()["courseName"].ToString();
                string courseI = ds.Rows[i]["courseName"].ToString();
                if (focusCourse == courseI)
                {
                    focusRow = i;
                    //MessageBox.Show(focusRow.ToString());
                    //ds.Rows[i]["status"] = "Zipping...";
                    //gridControl1.DataSource = ds;
                    gridView1.SetRowCellValue(i, "status", "zipping");
                    break;
                }
            }
            
            protiendo.Visible = true;
            
            using (ZipFile zip = new ZipFile())
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;//.None;//.Default;
                Task.Run(() => {
                    zip.SaveProgress += SaveProgress;
                });
                //zip.UseZip64WhenSaving = Zip64Option.Always;
                //zip.BufferSize = 65536 * 8;
                //!zip.StatusMessageTextWriter = System.Console.Out;
                zip.AddDirectory(DirectoryToZip); // recurses subdirectories
                zip.Save(ZipFileToCreate);

            }

            protiendo.Visible = false;
            //nén xong
            //MessageBox.Show("done zip");
            //label2.Text = "Done Zip";
            //Task.Run(() => {
            //    zipMyFile(DirectoryToZip, ZipFileToCreate, this);
            //});
            //Task.Run(() => {
            //    zipfile1(DirectoryToZip, ZipFileToCreate);
            //});

            //upload
            //Task.Run(() => {
            //!AuthorizeAndSendFile(zipFile, focusCourse);
            //ds.Rows[focusRow].Selected = true;

            //gridView1.set.Rows[focusRow].Cells[0].Selected = true;
            ///zipFile = @"L:\\moodleLocalhost\\English07_1014_08142020.zip";
            
            //zipFile = zipFile.Replace(".zip", "_NotYetConfirmed.zip");
            AuthorizeAndSendFile(zipFile);

            gridView1.FocusedRowHandle = focusRow;
            updateCoursesInfo(focusCourse, "courseName" + dateTimeStr);

            gridView1.FocusedRowHandle = focusRow;
            updateCoursesInfoInit();//up len gd
        }
        //---------------------------
        private void button6_Click(object sender, EventArgs e)
        {
            if (kt != 2)
                nen_upload();
        }

        public void updateCoursesInfo(string focusCourse, string fileName)
        {
            string[] words;
            string datetimeStr = "";
            words = fileName.Split('_');
            if (words.Length > 2)
            {
                //ds.Rows.Add(words[0], item.Name, false, item.Id);// i.ToString());
                //!ds.Rows.Add(words[0], "Time: " + words[2].Replace(".zip","") +" Date: " + words[1], item.Name, false, item.Id);// i.ToString());

                words[1] = words[1].Insert(2, ":"); 
                words[2] = words[2].Insert(2, "/");
                words[2] = words[2].Insert(5, "/");
                datetimeStr = words[1] + ", " + words[2];
                //update course info to xml file
                XmlDocument myXmlDocument = new XmlDocument();
                myXmlDocument.Load(@"coursesInfo.xml");
                XmlNode node;
                node = myXmlDocument.DocumentElement;
                // MessageBox.Show(node.Name);
                string newCourseName = "";
                //for (int i = 0; i < ds.Rows.Count; i++)
                //    if (ds.Rows[i]["Check"].ToString() != "")
                //        if (bool.Parse(ds.Rows[i]["Check"].ToString()) == true)
                {
                    newCourseName = focusCourse;// ds.Rows[i]["CourseName1"].ToString();
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
                        //XmlElement courseInfo = myXmlDocument.CreateElement(newCourseName);
                        //XmlElement bar = myXmlDocument.CreateElement("date");
                        //bar.InnerText = ds.Rows[i]["updatedDate"].ToString();
                        //courseInfo.AppendChild(bar);
                        //myXmlDocument.DocumentElement.AppendChild(courseInfo);
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
                                        nodechild1.InnerText = datetimeStr;
                                        Program.up_grade = nodechild.InnerText;
                                        break;
                                    }
                            }
                        }

                        /*
                        foreach (XmlNode nodechild in node.ChildNodes)
                        {
                            //MessageBox.Show(nodechild.Name);
                            if (nodechild.Name == newCourseName)
                            {
                                nodechild.Attributes.e("date").SetValue(outfile);
                                nodechild.InnerText = ds.Rows[i]["updatedDate"].ToString();
                                Program.up_grade = nodechild.InnerText;
                            }
                        }*/

                    }
                }
                //lblStatus.Text = "Develop by Hoàng Việt E-Learning. Nộp điểm gần nhất lúc: " + Program.up_grade;
                myXmlDocument.Save(@"coursesInfo.xml");
            }
        }

        public void SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_Started)
            {
                //!MessageBox.Show("Begin Saving: " + e.ArchiveName);
            }
            else if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
            {
                //label2.Text = "Writing: " + e.CurrentEntry.FileName + " (" + (e.EntriesSaved + 1) + "/" + e.EntriesTotal + ")";
                //label3.Text = "Filename:" + e.CurrentEntry.LocalFileName;

                protiendo.Maximum = e.EntriesTotal;
                protiendo.Value = e.EntriesSaved + 1;

                
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    string focusCourse = gridView1.GetFocusedDataRow()["courseName"].ToString();
                    string courseI = ds.Rows[i]["courseName"].ToString();
                    if (focusCourse == courseI)
                    {
                        //ds.Rows[i]["status"] = "Zipping...";
                        //gridControl1.DataSource = ds;
                        gridView1.SetRowCellValue(i, "status", "zipping");
                        int percentR = 100 * (e.EntriesSaved + 1) / e.EntriesTotal;
                        gridView1.SetRowCellValue(i, "percent",  percentR.ToString()+"%");//progressBar2.Value.ToString());//
                        gridView1.RefreshData();
                        break;
                    }
                }

                
            }
            else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
            {
                //progressBar1.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                //!MessageBox.Show("Done: " + e.ArchiveName);
            }
        }
        /*
        public void zipfile1(string DirectoryToZip, string ZipFileToCreate)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    // note: this does not recurse directories! 
                    String[] filenames = System.IO.Directory.GetFiles(DirectoryToZip);

                    // This is just a sample, provided to illustrate the DotNetZip interface.  
                    // This logic does not recurse through sub-directories.
                    // If you are zipping up a directory, you may want to see the AddDirectory() method, 
                    // which operates recursively. 
                    foreach (String filename in filenames)
                    {
                        Console.WriteLine("Adding {0}...", filename);
                        ZipEntry e = zip.AddFile(filename);
                        //zip.AddDirectory(DirectoryToZip);
                        e.Comment = "Added by Cheeso's CreateZip utility.";
                    }

                    zip.Comment = String.Format("This zip archive was created by the CreateZip example application on machine '{0}'",
                       System.Net.Dns.GetHostName());

                    zip.Save(ZipFileToCreate);
                }

            }
            catch (System.Exception ex1)
            {
                System.Console.Error.WriteLine("exception: " + ex1);
            }
        }

        public void updateStatusBarZipfile(long bytes, string msg, string fileId)
        {

            if (InvokeRequired)
            {
                Invoke(new Action<long, string, string>(updateStatusBarZipfile), new object[] { bytes, msg, fileId });
                return;
            }
            MessageBox.Show(bytes.ToString());
            //if (bytes == -1)
            //{
            //    //ds.Rows[rowId].va = "100";
            //    //gridControl1.s.SetRowCellValue(rowId, "status", "OK");
            //    //gridView1.SetRowCellValue(1, "status", "100%");
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //        if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
            //        {
            //            gridView1.SetRowCellValue(i, "status", "100%");
            //            gridView1.SetRowCellValue(i, "statusDU", "Done Download");
            //        }
            //    //MessageBox.Show("Course: " + msg + " is downloaded " + fileId);
            //}
            //else
            //{
            //    //progressBar.Value = (int)bytes; //20;// 
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //        if (gridView1.GetRowCellValue(i, "Id").ToString() == fileId)
            //        {
            //            gridView1.SetRowCellValue(i, "status", bytes.ToString() + "%");
            //            gridView1.SetRowCellValue(i, "statusDU", "Downloading");
            //        }
            //    //if (progressBar.Value == 100)
            //    //    MessageBox.Show("Download Completed");
            //}
            //lblProgress.Text = msg;
            //lblProgress.Location = new Point(this.ClientRectangle.Width - lblProgress.Width - progressBar.Width - 20, 4);

        }
        */
        /*
        public void zipMyFile(string DirectoryToZip, string ZipFileToCreate, listCoursesToRun lcr)
        {
            listCoursesToRun lc = lcr;
            
            using (ZipFile zip = new ZipFile())
            {
                lc.updateStatusBarZipfile(10, "dsf", "fds");
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                zip.SaveProgress += SaveProgress1;

                zip.StatusMessageTextWriter = System.Console.Out;
                zip.AddDirectory(DirectoryToZip); // recurses subdirectories
                zip.Save(ZipFileToCreate);
            }
        }
        */
        /*
        public void SaveProgress1(object sender, SaveProgressEventArgs e)//, listCoursesToRun lcr)
        {
            if (e.EventType == ZipProgressEventType.Saving_Started)
            {
                MessageBox.Show("Begin Saving: " + e.ArchiveName);
            }
            else if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
            {
                //label2.Text = "Writing: " + e.CurrentEntry.FileName + " (" + (e.EntriesSaved + 1) + "/" + e.EntriesTotal + ")";
                //labelFilename.Text = "Filename:" + e.CurrentEntry.LocalFileName;

                progressBar2.Maximum = e.EntriesTotal;
                progressBar2.Value = e.EntriesSaved + 1;
            }
            else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
            {
                progressBar1.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                MessageBox.Show("Done: " + e.ArchiveName);
            }
        }
        */

        /*
        int _numEntriesToAdd = 0;
        int _numEntriesAdded = 0;
        void AddProgressHandler(object sender, AddProgressEventArgs e)
        {
            switch (e.EventType)
            {
                case ZipProgressEventType.Adding_Started:
                    Console.WriteLine("Adding files to the zip...");
                    break;
                case ZipProgressEventType.Adding_AfterAddEntry:
                    _numEntriesAdded++;
                    Console.WriteLine(String.Format("Adding file {0}/{1} :: {2}",
                                             _numEntriesAdded, _numEntriesToAdd, e.CurrentEntry.FileName));
                    break;
                case ZipProgressEventType.Adding_Completed:
                    Console.WriteLine("Added all files");
                    break;
            }
        }

        void CreateTheZip(string DirToZip, string ZipFileToCreate)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddProgress += AddProgressHandler;
                //zip.AddDirectory(System.IO.Path.GetFileName(DirToZip));
                zip.AddDirectory(DirToZip);
                zip.Save(ZipFileToCreate);
            }
        }

        private async void ZipIt(string src, string dest)
        {
            await Task.Run(() =>
            {
                using (var zipFile = new ZipFile())
                {
                    // add content to zip here 
                    zipFile.AddDirectory(src);
                    // add content to zip here 
                    zipFile.SaveProgress +=
                        (o, args) =>
                        {
                            var percentage = (int)(1.0d / args.TotalBytesToTransfer * args.BytesTransferred * 100.0d);
                            Console.WriteLine("===========================" + percentage.ToString());
                            // report your progress
                        };
                    zipFile.Save();
                }
            });
        }
        private void CreateZip(string FilePath)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddProgress += Zip_AddProgress;
                zip.SaveProgress += Zip_SaveProgress;
                zip.CompressionMethod = Ionic.Zip.CompressionMethod.Deflate;
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;//.BestCompression;
                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                if (!string.IsNullOrEmpty(FilePath))
                {
                    zip.AddDirectory(FilePath, new DirectoryInfo(FilePath).Name);
                }
                var d = zip;

                if (File.Exists(@"txtDest.Txt"))
                {
                    File.Delete(@"txtDest.Txt");
                }
                zip.Save(@"txtDest.Txt");
            }
        }

        //////////////////////////////
        /// The events below occur 
        /// when there is a change 
        /// in the ZIP processing
        //////////////////////////////
        void Zip_AddProgress(object sender, AddProgressEventArgs e)
        {
            // Do we want to cancel?
            //if (ProgressForm.WantCancel)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            // Occurs when a file was added to the zip
            if (e.EventType == ZipProgressEventType.Adding_AfterAddEntry)
            {
                //appWorker.ReportProgress(-1, "Adding " + e.CurrentEntry.FileName);
                Console.WriteLine("Adding " + e.CurrentEntry.FileName);
            }
        }

        private void Zip_SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_Started)
                Console.WriteLine("Proccess Started Successfully");

            if (e.EventType == ZipProgressEventType.Saving_AfterSaveTempArchive)
                Console.WriteLine("Proccess Completed Successfully");


            if (e.BytesTransferred > 0 && e.TotalBytesToTransfer > 0)
            {
                int progress = (int)Math.Floor((decimal)((e.BytesTransferred * 100) / e.TotalBytesToTransfer));
                //pbPerFile.Value = progress;
                //lblPercentagePerFile.Text = Convert.ToString(progress) + "%";
                Console.WriteLine(Convert.ToString(progress) + "%");//
                //lblFileName.Text = "File Name: " + e.CurrentEntry.UncompressedSize;
                Console.WriteLine("File Name: " + e.CurrentEntry.UncompressedSize);
                Application.DoEvents();
            }

            if (e.EntriesSaved > 0 && e.EntriesTotal > 0)
            {
                int progress = (int)Math.Floor((decimal)((e.EntriesSaved * 100) / e.EntriesTotal));
                //pbTotalFile.Value = progress;
                Application.DoEvents();
                //lblTotal.Text = Convert.ToString(progress) + "%";
                Console.WriteLine(Convert.ToString(progress) + "%");
            }
        }
        */
        private void button7_Click(object sender, EventArgs e)
        {
            splcapnhat.ShowWaitForm();
            Program.GV = "2";//2 là giáo viên
            ListNewCoursesTeachers lnc1 = new ListNewCoursesTeachers(this);
            lnc1.Show();
            splcapnhat.CloseWaitForm();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            updateCoursesInfoInit();
        }

        //FormClosed
        //private void listCoursesToRun_Activated(object sender, EventArgs e)
        private void ListCoursesToRun_Teacherslist_Activated(object sender, EventArgs e)
        {
            MessageBox.Show("call updateCoursesInfoInit()");
            //justActive = true;
            updateCoursesInfoInit();
            //updateCoursesInfo();
            //MessageBox.Show("hello");
            //MessageBox.Show(justActive.ToString());
        }
        //bool justActive = true;
        private void listCoursesToRun_Deactivate(object sender, EventArgs e)
        {
            //justActive = false;
            //updateCoursesInfoInit();
            //MessageBox.Show(justActive.ToString());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ListCoursesToRun_Teacherslist_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void ListCoursesToRun_Teacherslist_MouseMove(object sender, MouseEventArgs e)
        {
            //updateCoursesInfoInit();
            try
            {
                if (gridView1.RowCount > 0)
                {
                    string courseSelected = gridView1.GetFocusedDataRow()["courseName"].ToString();
                    //if (courseSelected!= gridView1.GetSelectedRows())
                    //MessageBox.Show(courseSelected);
                    foreach (int i in gridView1.GetSelectedRows())
                    {
                        DataRow row = gridView1.GetDataRow(i);
                        //MessageBox.Show(row[0].ToString());
                        if (row[0].ToString() != courseSelected)
                            updateCoursesInfoInit();
                    }
                }
                else
                    updateCoursesInfoInit();
            }
            catch (System.Exception ex1)
            {
                System.Console.Error.WriteLine("exception: " + ex1);
            }
        }
        void hoanthanhtacvu()
        {
            DataTable mdl_course_modules_completion_DS = new DataTable();
            DataTable mdl_mdl_block_recentlyaccesseditems = new DataTable();
            mdl_course_modules_completion_DS = clnd.mdl_course_modules_completion_DS();
            string completion = rg.valuekey(Program.Name_Courses + "_completions");
            for (int i = int.Parse(completion); i < mdl_course_modules_completion_DS.Rows.Count; i++)
            {
                lbltiendo.Text = "Đang Thực hiện tải hoàn thành tác vụ: " + i.ToString() + "/" + mdl_course_modules_completion_DS.Rows.Count.ToString();

                if (clnd.mdl_course_modules_completion_MySql_Them(mdl_course_modules_completion_DS.Rows[i][1].ToString(), mdl_course_modules_completion_DS.Rows[i][2].ToString(), mdl_course_modules_completion_DS.Rows[i][3].ToString(), mdl_course_modules_completion_DS.Rows[i][4].ToString(), mdl_course_modules_completion_DS.Rows[i][5].ToString(), mdl_course_modules_completion_DS.Rows[i][6].ToString()) == true)
                {
                    int j = i + 1;
                    rg.WriteKey(Program.Name_Courses + "_completions", j.ToString());
                }
            }
        }
        private void btnhoanthanh_Click(object sender, EventArgs e)
        {
            hoanthanhtacvu();
        }

        private void btnmacdinh_Click(object sender, EventArgs e)
        {
            clmd.mdl_course_modules_completion_MacDinh();
            clmd.mdl_block_recentlyaccesseditems_MacDinh();
            clmd.mdl_question_usages_MacDinh();
            clmd.mdl_question_attempts_MacDinh();
            clmd.mdl_question_attempt_steps_MacDinh();
            clmd.mdl_question_attempt_step_data_MacDinh();
            clmd.mdl_quiz_grades_MacDinh();
            clmd.mdl_logstore_standard_log_MacDinh();
            clmd.mdl_sessions_MacDinh();
            clmd.mdl_user_lastaccess_data_MacDinh();
            clmd.mdl_quiz_attempts_MacDinh();
            clmd.mdl_quiz_feedback_MacDinh();
        }

        private void btnnen_Click(object sender, EventArgs e)
        {
            //đóng tất cả tác vụ
            foreach (var process in Process.GetProcessesByName("mysqld"))
                process.Kill();
            foreach (var process in Process.GetProcessesByName("httpd"))
                process.Kill();
            //lấy file tại vị trí nào
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
                    break;
                }

            }
            //--------------------
            //lấy môn học cần nén và đặt tên file
            rootPath += "\\" + gridView1.GetFocusedDataRow()["courseName"].ToString();
            string partitionName = rootPath.Substring(0, rootPath.IndexOf(":") + 1);
            DirectoryInfo di = new DirectoryInfo(rootPath);

            string parentDir = di.Parent.FullName;
            DateTime dateTime = DateTime.UtcNow.Date;
            string dateTimeStr = DateTime.Now.ToString("_HHmm_MMddyyyy"); 
            string zipFile = parentDir + "\\" + gridView1.GetFocusedDataRow()["courseName"].ToString() + dateTimeStr + ".zip";
            zipFile = zipFile.Replace(".zip", "_NotYetConfirmed.zip");
            //xóa file trung
            if (File.Exists(zipFile) == true)
                File.Delete(zipFile);
            string DirectoryToZip = rootPath;
            string ZipFileToCreate = zipFile;
            string focusCourse = "";
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                focusCourse = gridView1.GetFocusedDataRow()["courseName"].ToString();
                string courseI = ds.Rows[i]["courseName"].ToString();
                if (focusCourse == courseI)
                {
                    focusRow = i;
                    gridView1.SetRowCellValue(i, "status", "zipping");
                    break;
                }
            }
            protiendo.Visible = true;
            using (ZipFile zip = new ZipFile())
            {//bắt đầu nén và lưu
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                Task.Run(() => {
                    zip.SaveProgress += SaveProgress;
                });
                zip.AddDirectory(DirectoryToZip); 
                zip.Save(ZipFileToCreate);
            }
            protiendo.Visible = false;
        }
    }
}
