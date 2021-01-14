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
//using System.Management.Automation;

namespace unzipPackage.Students
{
    public partial class listCoursesToRun_Students : Form
    {
        Class.mdl_question clq = new Class.mdl_question();
        Class.cls_mdl_quiz_grades clqg = new Class.cls_mdl_quiz_grades();
        Class.clsnopdiem clnd = new Class.clsnopdiem();
        DataTable ds = new DataTable();
        Form1_student originalForm = new Form1_student();
        //string folderName = "moodleLocalhost";
        //string rootPath = "";
        //string pathFileIni = "appInfo.ini";

        public listCoursesToRun_Students()
        {
            InitializeComponent();
        }

        public void updateCoursesInfoInit()
        {
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
                    ds.Rows.Add(f.Name, "", "", "", "");
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
                                    //if (ds.Rows[i]["updatedDate"].ToString() == nodechild1.InnerText)
                                    //    ds.Rows.RemoveAt(i);

                                    ds.Rows.Add(f.Name, "", nodechild1.InnerText, "", "");
                                    //nodechild1.InnerText = ds.Rows[i]["updatedDate"].ToString();
                                    //Program.up_grade = nodechild.InnerText;
                                    break;
                                }
                        }
                    }

                }
            }
            gridControl1.DataSource = ds;
            myXmlDocument.Save(@"coursesInfo.xml");

            
        }

        private void listCoursesToRun_Load(object sender, EventArgs e)
        {
            kiemtraphienbanapp();
            gridView1.OptionsBehavior.Editable = false;
            //add columns paras to grid
            //ds.Columns.Add("Check", Type.GetType("System.Boolean"));            
            ds.Columns.Add("courseName");
            ds.Columns.Add("lastAccess");
            ds.Columns.Add("lastestUpdateVersion");
            ds.Columns.Add("status");
            ds.Columns.Add("percent");
            updateCoursesInfoInit();
            if (ds.Rows.Count == 0)
            {
                Teacherslist.ListNewCoursesTeachers lnc = new Teacherslist.ListNewCoursesTeachers();
                lnc.Show();
                lnc.Focus();
            }
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
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (ktstart == true)
            {
                lblthongbaoloi.Text = "lúc nộp bài không được chuyển môn học.";
            }
            else
            {
                splcapnhat.ShowWaitForm();
                //kill all previous processes: mysqld, httpd
                if (ktstart == true)//trong thao tác nộp điểm không cho chuyển môn.
                    return;
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
                //deleteCacheStuffs(rootPath + "\\server\\moodledata\\cache\\"); duy tri dang nhap

                //delete moodle cache
                deleteCacheStuffs(rootPath + "\\server\\moodledata\\cache\\");

                int httpdPort = findHttpdPort();
                //if (httpdPort != 80)
                changeHTTPDPort(rootPath, rootPath, httpdPort);

                int httpdListenPort = findHttpdListenPort();
                changeHTTPDListenPort(rootPath, rootPath, httpdListenPort);

                int mySqlPort = findMySqlPort();

                Program.port_http = httpdPort.ToString();
                Program.port_mysql = mySqlPort.ToString();
                //MessageBox.Show(gridView1.GetFocusedDataRow()["courseName"].ToString());


                //-- kiem tra courseName
                string kt_string = capnhat_usages_id_re(gridView1.GetFocusedDataRow()["courseName"].ToString());
                Program.Name_Courses = gridView1.GetFocusedDataRow()["courseName"].ToString();
                if (kt_string != "0")
                {
                    if (File.Exists(rootPath + "\\server\\apache\\bin\\httpd.exe"))
                    {
                        //!setRuleFireWall($"Apache HTTP Server", rootPath + "\\server\\apache\\bin\\httpd.exe", httpdPort.ToString());
                        SetupFirewallAllowIncomingRule($"Apache HTTP Server", rootPath + "\\server\\apache\\bin\\httpd.exe", httpdPort);

                        Process_Open(rootPath + "\\server\\apache\\bin\\httpd.exe", "");
                    }
                    if (File.Exists(rootPath + "\\server\\mysql\\bin\\mysqld.exe"))
                    {
                        //!setRuleFireWall($"mysqld", rootPath + "\\server\\mysql\\bin\\mysqld.exe", mySqlPort.ToString());
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

                    string luu = Name_Courses + gridView1.GetFocusedDataRow()["courseName"].ToString();
                    luuxml("Config - Offline.xml", "Name_Courses", luu);
                    kiemtrasoluongbai();
                    capnhat_usages_id(gridView1.GetFocusedDataRow()["courseName"].ToString());

                }
                if (httpdPort != 80)
                    System.Diagnostics.Process.Start("http://localhost:" + httpdPort.ToString());
                else
                    System.Diagnostics.Process.Start("http://localhost");

                // kiểm tra kiểu nộp bài.
                Program.id_user = clnd.mdl_logstore_standard_log_DS_Top1();
                if (kiemtraketnoimang() == true)
                {
                    kiemtrasoluongbai();
                    if (kiemtrakieunopbai() == true)
                        Program.kieunopbai = "1";//nop diem va chi tiet cau hoi
                    else
                        Program.kieunopbai = "0";//chi nop diem
                }
                else
                {
                    Program.kieunopbai = "3";// chu ket noi duoc mang khi nop bai kiem tra lai
                }
                //-- tự động nộp bài.
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = 30 * 1000;   //30s
                timer.Elapsed += timer_Elapsed;
                timer.Start();
                //---------------
                splcapnhat.CloseWaitForm();
            }
        }
        bool ktstart = false;
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
        bool kiemtrakieunopbai()
        {
            DataTable mdl_nopdiem = new DataTable();
            mdl_nopdiem = clnd.mdl_nopdiem_DS_id(1.ToString());
            if (mdl_nopdiem.Rows[0][0].ToString() == "0")
                return false;
            else
                return true;
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (kiemtraketnoimang() == true)//kiểm tra kết nối mạng. kết nối được tới máy chủ nộp điểm (SQL Server)
            {
                if (ktstart == false)
                {
                    if (Program.kieunopbai == "3")//nếu lần đầu tiên kiểm tra kết nối rớt thì trả về 3 
                    {
                        kiemtrasoluongbai();
                        if (kiemtrakieunopbai() == true)
                            Program.kieunopbai = "1";//nop diem va chi tiet cau hoi
                        else
                            Program.kieunopbai = "0";//chi nop diem
                        uploadMarks();
                        lblthongbao.Text = Program.usages_id;
                    }
                    else
                    {
                        uploadMarks();
                        lblthongbao.Text = Program.usages_id;
                    }
                }
            }
            else
            {
                lblthongbao.Text = "...";
            }
            //upload
        }
        bool kiemtraketnoimang()
        {
            try
            {
                string vernew = "0";
                vernew = version("http://e-learning.hoangviet.edu.vn:5052/HV_Elearning_Students/Config.xml");
                if (vernew != "")
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
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
            int dsmaxusages_id = 0;
            dsmaxusages_id = clq.mdl_question_usages_DS_state_finished_();
            luuxml("Config - Offline.xml", "usages_id", dsmaxusages_id.ToString());
            RegistryWriter rg = new RegistryWriter();
            rg.WriteKey(Name_Courses, dsmaxusages_id.ToString());
            Program.usages_id = dsmaxusages_id.ToString();
            DataTable ds_mdl_course_modules_completion = new DataTable();
            ds_mdl_course_modules_completion = clnd.mdl_course_modules_completion_userid();
            Program.completionstate = ds_mdl_course_modules_completion.Rows.Count.ToString();
            rg.WriteKey(Name_Courses + "_completionstate", Program.completionstate);
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
        public  string capnhat_usages_id_re(string Name_Courses)
        {
            RegistryWriter rg = new RegistryWriter();
            string usages_id = "";
            usages_id = rg.valuekey(Name_Courses);
            Program.usages_id = usages_id;
            lblthongbao.Text = usages_id;
            return usages_id;
        }

        public void uploadMarks()
        {
            ktstart = true;
            lblbatdau.Text = "Bắt đầu: " + DateTime.Now.ToString("HH:mm:ss");
            int ds_mdl_question_usages = 0; //20
            ds_mdl_question_usages = clq.mdl_question_usages_DS_state_finished_();
            if (ds_mdl_question_usages > int.Parse(Program.usages_id))
            {
                if (Program.kieunopbai == "1")
                {
                    nopdiem_sql();
                    nopdiem();
                }
                else
                {
                    nopdiem();
                    nopdiemquiz();
                }
                
            }
            hoanthanhtacvu();
            timesave();
            lblketthuc.Text = "Kết thúc: " + DateTime.Now.ToString("HH:mm:ss");
            ktstart = false;
        }
        void timesave()
        {
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
            myXmlDocument.Save("Config - Offline.xml");
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
           // protiendo.Value = 0;
           // protiendo.Maximum = ds_mdl_quiz_grades.Rows.Count;
            for (int i = 0; i < ds_mdl_quiz_grades.Rows.Count; i++)
            {
               // protiendo.Value++;
               //protiendo.Refresh();
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
            ktstart = false;
        }
        void nopdiem_sql()
        {
            batdau = DateTime.Now.ToString();
            DataTable ds_mdl_quiz_attempts = new DataTable();
            DataTable ds_mdl_quiz_grades = new DataTable();
            DataTable dsmdl_quiz_grades_KT = new DataTable();
            ds_mdl_quiz_grades = clqg.mdl_quiz_grades_DS(Program.id_user);
            //protiendo.Value = 0;
            //protiendo.Maximum = ds_mdl_quiz_grades.Rows.Count;
            
            for (int i = 0; i < ds_mdl_quiz_grades.Rows.Count; i++)
            {
                dsmdl_quiz_grades_KT = clqg.mdl_quiz_grades_DS_quiz_userid(Int64.Parse(ds_mdl_quiz_grades.Rows[i][1].ToString()), Int64.Parse(ds_mdl_quiz_grades.Rows[i][2].ToString()));
                if (dsmdl_quiz_grades_KT.Rows.Count == 0)// nop diem
                {// neu chua nop thi them moi
                    clqg.quiz = Int64.Parse(ds_mdl_quiz_grades.Rows[i][1].ToString());
                    clqg.userid = Int64.Parse(ds_mdl_quiz_grades.Rows[i][2].ToString());
                    clqg.grade = ds_mdl_quiz_grades.Rows[i][3].ToString();
                    clqg.timemodified = Int64.Parse(ds_mdl_quiz_grades.Rows[i][4].ToString());
                    clqg.mdl_quiz_grades_Them();
                }
                else
                {//neu nop roi thi sua diem 
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
            ds_mdl_question_usages = clq.mdl_question_usages_DS_state_finished();
            //protiendo.Value = 0;
            //protiendo.Maximum = ds_mdl_question_usages.Rows.Count;
            for (int i = int.Parse(Program.usages_id); i < ds_mdl_question_usages.Rows.Count; i++) 
            {//nop chi tiet dap an
                //protiendo.Value++;
                //protiendo.Refresh();
                if (i >= int.Parse(Program.usages_id))
                {
                    ds_mdl_question_attempts = clq.mdl_question_attempts_DS(ds_mdl_question_usages.Rows[i][0].ToString());
                    clq.contextid = ds_mdl_question_usages.Rows[i][1].ToString();
                    clq.component = ds_mdl_question_usages.Rows[i][2].ToString();
                    clq.preferredbehaviour = ds_mdl_question_usages.Rows[i][3].ToString();

                    ds_mdl_quiz_attempts = clqg.mdl_quiz_attempts_DS_uniqueid(ds_mdl_question_usages.Rows[i][0].ToString());
                    if (clq.mdl_question_usages_Them(ds_mdl_question_attempts, ds_mdl_quiz_attempts) == true)
                    {
                        int ii = int.Parse(Program.usages_id);
                        ii = ++ii;
                        luuxml("Config - Offline.xml", "usages_id", ii.ToString());
                        Program.usages_id = ii.ToString();
                        rg.WriteKey(Program.Name_Courses, ii.ToString());
                    }
                }
            }
            ketthuc = DateTime.Now.ToString();
        }
        RegistryWriter rg = new RegistryWriter();
        private void button3_Click(object sender, EventArgs e)
        {
            //kill all previous processes: mysqld, httpd
            foreach (var process in Process.GetProcessesByName("mysqld"))
                process.Kill();
            foreach (var process in Process.GetProcessesByName("httpd"))
                process.Kill();
            /*
            //read rootPath
            string rootPath = originalForm.readRootPath(originalForm.pathFileIni);
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string path = rootPath + "\\" + gridView1.GetRowCellValue(i, "courseName");//.ToString();
                
                //changeAllPath(rootPath);
                //MessageBox.Show(rootPath + "\\star.bat");
                System.Diagnostics.Process.Start(path + "\\stopMoodle.bat");
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ktstart == true)
            {
                lblthongbaoloi.Text = "Lúc nộp bài không thể tắt chương trình";
            }
            else
            {
                //kill all previous processes: mysqld, httpd
                foreach (var process in Process.GetProcessesByName("mysqld"))
                    process.Kill();
                foreach (var process in Process.GetProcessesByName("httpd"))
                    process.Kill();
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            taidiem();
        }
        void taidiem()
        {
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
            //protiendo.Value = 0;
            //protiendo.Maximum = mdl_quiz_grades.Rows.Count;
            for (int i = 0; i < mdl_quiz_grades.Rows.Count; i++)
            {
               //protiendo.Value++;
                //protiendo.Refresh();
                clq.mdl_quiz_grades_Them(mdl_quiz_grades.Rows[i][1].ToString(), mdl_quiz_grades.Rows[i][2].ToString(), mdl_quiz_grades.Rows[i][3].ToString(), mdl_quiz_grades.Rows[i][4].ToString());
            }
            //-- tải điểm
            //-- chi tiet cau hoi
            ds_mdl_question_usages = clq.mdl_question_usages_DS_sql();
            for (int i = 0; i < ds_mdl_question_usages.Rows.Count; i++)
            {
                if (int.Parse(ds_mdl_question_usages.Rows[i][0].ToString()) > int.Parse(Program.usages_id_Load))
                {
                    clq.mdl_question_usages_Them(ds_mdl_question_usages.Rows[i][1].ToString(), ds_mdl_question_usages.Rows[i][2].ToString(), ds_mdl_question_usages.Rows[i][3].ToString());

                    mdl_question_usages_max = clq.mdl_question_usages_max();

                    mdl_quiz_attempts = clq.mdl_quiz_attempts_DS_uniqueid(ds_mdl_question_usages.Rows[i][0].ToString());

                    clq.mdl_quiz_attempts_Them(mdl_quiz_attempts.Rows[0][1].ToString(), mdl_quiz_attempts.Rows[0][2].ToString(), mdl_quiz_attempts.Rows[0][3].ToString(), mdl_question_usages_max.Rows[0][0].ToString(), mdl_quiz_attempts.Rows[0][5].ToString(), mdl_quiz_attempts.Rows[0][6].ToString(), mdl_quiz_attempts.Rows[0][7].ToString(), mdl_quiz_attempts.Rows[0][8].ToString(), mdl_quiz_attempts.Rows[0][9].ToString(), mdl_quiz_attempts.Rows[0][10].ToString(), mdl_quiz_attempts.Rows[0][11].ToString(), mdl_quiz_attempts.Rows[0][12].ToString(), mdl_quiz_attempts.Rows[0][13].ToString(), mdl_quiz_attempts.Rows[0][14].ToString());

                    ds_mdl_question_attempts = clq.mdl_question_attempts_DS_questionusage_id(ds_mdl_question_usages.Rows[i][0].ToString());
                    mdl_question_attempt_steps_questionattemptid.Clear();
                    mdl_question_attempt_steps_questionattemptid.Columns.Clear();
                    mdl_question_attempt_steps_questionattemptid.Columns.Add("id");
                    for (int ii = 0; ii < ds_mdl_question_attempts.Rows.Count; ii++)
                    {
                        clq.mmdl_question_attempts_Them(mdl_question_usages_max.Rows[0][0].ToString(), ds_mdl_question_attempts.Rows[ii][2].ToString(), ds_mdl_question_attempts.Rows[ii][3].ToString(), ds_mdl_question_attempts.Rows[ii][4].ToString(), ds_mdl_question_attempts.Rows[ii][5].ToString(), ds_mdl_question_attempts.Rows[ii][6].ToString(), ds_mdl_question_attempts.Rows[ii][7].ToString(), ds_mdl_question_attempts.Rows[ii][8].ToString(), ds_mdl_question_attempts.Rows[ii][9].ToString(), ds_mdl_question_attempts.Rows[ii][10].ToString(), ds_mdl_question_attempts.Rows[ii][11].ToString(), ds_mdl_question_attempts.Rows[ii][12].ToString(), ds_mdl_question_attempts.Rows[ii][13].ToString());
                        mdl_question_attempt_steps_questionattemptid.Rows.Add(clq.mdl_question_attempts_max());
                    }
                    for (int ii = 0; ii < ds_mdl_question_attempts.Rows.Count; ii++)
                    {
                        mdl_question_attempt_step = clq.mdl_question_attempt_steps_DS_questionattemptid_sequencenumber(ds_mdl_question_attempts.Rows[ii][0].ToString(), 0.ToString());
                        clq.mdl_question_attempt_steps_Them(mdl_question_attempt_steps_questionattemptid.Rows[ii][0].ToString(), mdl_question_attempt_step.Rows[0][2].ToString(), mdl_question_attempt_step.Rows[0][3].ToString(), mdl_question_attempt_step.Rows[0][5].ToString(), mdl_question_attempt_step.Rows[0][6].ToString());

                        mdl_question_attempt_step_data = clq.mdl_question_attempt_step_data_ds_id(mdl_question_attempt_step.Rows[0][0].ToString());
                        clq.mdl_question_attempt_step_data_Them(clq.mdl_question_attempt_steps_max(), mdl_question_attempt_step_data.Rows[0][2].ToString(), mdl_question_attempt_step_data.Rows[0][3].ToString());
                    }

                    for (int ii = 0; ii < ds_mdl_question_attempts.Rows.Count; ii++)
                    {
                        mdl_question_attempt_step = clq.mdl_question_attempt_steps_DS_questionattemptid_sequencenumber(ds_mdl_question_attempts.Rows[ii][0].ToString(), 1.ToString());
                        clq.mdl_question_attempt_steps_Them(mdl_question_attempt_steps_questionattemptid.Rows[ii][0].ToString(), mdl_question_attempt_step.Rows[0][2].ToString(), mdl_question_attempt_step.Rows[0][3].ToString(), mdl_question_attempt_step.Rows[0][5].ToString(), mdl_question_attempt_step.Rows[0][6].ToString());
                        mdl_question_attempt_step_data = clq.mdl_question_attempt_step_data_ds_id(mdl_question_attempt_step.Rows[0][0].ToString());
                        clq.mdl_question_attempt_step_data_Them(clq.mdl_question_attempt_steps_max(), mdl_question_attempt_step_data.Rows[0][2].ToString(), mdl_question_attempt_step_data.Rows[0][3].ToString());
                    }
                    for (int ii = 0; ii < ds_mdl_question_attempts.Rows.Count; ii++)
                    {
                        mdl_question_attempt_step = clq.mdl_question_attempt_steps_DS_questionattemptid_sequencenumber(ds_mdl_question_attempts.Rows[ii][0].ToString(), 2.ToString());
                        clq.mdl_question_attempt_steps__fraction_Them(mdl_question_attempt_steps_questionattemptid.Rows[ii][0].ToString(), mdl_question_attempt_step.Rows[0][2].ToString(), mdl_question_attempt_step.Rows[0][3].ToString(), mdl_question_attempt_step.Rows[0][4].ToString(), mdl_question_attempt_step.Rows[0][5].ToString(), mdl_question_attempt_step.Rows[0][6].ToString());

                        mdl_question_attempt_step_data = clq.mdl_question_attempt_step_data_ds_id(mdl_question_attempt_step.Rows[0][0].ToString());
                        clq.mdl_question_attempt_step_data_Them(clq.mdl_question_attempt_steps_max(), mdl_question_attempt_step_data.Rows[0][2].ToString(), mdl_question_attempt_step_data.Rows[0][3].ToString());
                    }
                    luuxml("Config - Offline.xml", "usages_id_Load", ds_mdl_question_usages.Rows[i][0].ToString());
                    Program.usages_id_Load = ds_mdl_question_usages.Rows[i][0].ToString();
                }
            }
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
            progressBar2.Minimum = 0;
            progressBar2.Maximum = 100;
            progressBar2.Value = (int)bytes;
            label2.Text = "Uploading...";
            if (bytes == 100)
                label2.Text = "Done Upload";
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
        public Google.Apis.Drive.v3.Data.File uploadFile(DriveService _service, string _uploadFile, string _parent, listCoursesToRun_Students parentForm, string _descrp = "Uploaded with .NET!")
        {
            //label2.Text = "Uploading...";
            listCoursesToRun_Students parent = parentForm;
            long totalSize = 100000;
            if (System.IO.File.Exists(_uploadFile))
            {
                FileInfo fi = new FileInfo(_uploadFile);
                totalSize = fi.Length;

                Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                body.Name = System.IO.Path.GetFileName(_uploadFile);
                body.Description = _descrp;
                body.MimeType = GetMimeType(_uploadFile);
                body.Parents = new List<string> { _parent };// UN comment if you want to upload to a folder(ID of parent folder need to be send as paramter in above method)
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
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
        
        private void AuthorizeAndSendFile(string pathFile)
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
            

            service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
            //Long Operations like file uploads might timeout. 100 is just precautionary value, can be set to any reasonable value depending on what you use your service for  

            // team drive root https://drive.google.com/drive/folders/0AAE83zjNwK-GUk9PVA   

            //var respocne = uploadFile(service, textBox1.Text, "");
            //1HiuLTcwX2hdyWeN4zeUZ6kLOf17mFRR1
            Task.Run(() =>
            {
            //!var respocne = uploadFile(service, pathFile, "1HiuLTcwX2hdyWeN4zeUZ6kLOf17mFRR1", this, focusCourse);
            var respocne = uploadFile(service, pathFile, "1HiuLTcwX2hdyWeN4zeUZ6kLOf17mFRR1", this);//, focusCourse);
            });
            //var respocne = uploadFile(service, pathFile, "");// 1HiuLTcwX2hdyWeN4zeUZ6kLOf17mFRR1");
            // Third parameter is empty it means it would upload to root directory, if you want to upload under a folder, pass folder's id here.
            //!!MessageBox.Show("Process completed--- Response--" + respocne);

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
        }

        private void CompressFolder(string folder, string targetFilename,listCoursesToRun_Students parentForm)
        {
            listCoursesToRun_Students lc = parentForm;
            //bool zipping = true;
            long size = Directory.GetFiles(folder).Select(o => new FileInfo(o).Length).Aggregate((a, b) => a + b);
            var fi = new FileInfo(targetFilename);
          
        }

        public int focusRow = 0;
        private void button6_Click(object sender, EventArgs e)
        {
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(@"coursesInfo.xml");
            XmlNode node;
            //string rootPath = originalForm.readRootPath(originalForm.pathFileIni);
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

            string zipFile = parentDir + "\\" + gridView1.GetFocusedDataRow()["courseName"].ToString() + dateTimeStr+ ".zip";
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

            label2.Text = "Zipping...";
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
            label2.Text = "Done Zip";
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
            
            AuthorizeAndSendFile(zipFile);

            gridView1.FocusedRowHandle = focusRow;
            updateCoursesInfo(focusCourse, "courseName"+dateTimeStr);

            gridView1.FocusedRowHandle = focusRow;
            updateCoursesInfoInit();
            //});
        }

        public void updateCoursesInfo(string focusCourse, string fileName)
        {
            string[] words;
            string datetimeStr = "";
            words = fileName.Split('_');
            if (words.Length > 2)
            {
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
                    }
                }
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

                progressBar2.Maximum = e.EntriesTotal;
                progressBar2.Value = e.EntriesSaved + 1;

                
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (ktstart == true)
            {
                lblthongbaoloi.Text = "Đang nộp bài";
            }
            else
            {
                splcapnhat.ShowWaitForm();
                Program.GV = 1.ToString();//1 la hoc sinh
                ListNewCoursesStudents lnc = new ListNewCoursesStudents();
                lnc.Show();
                splcapnhat.CloseWaitForm();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            updateCoursesInfoInit();
        }

        private void listCoursesToRun_Activated(object sender, EventArgs e)
        {
            updateCoursesInfoInit();
            //MessageBox.Show(justActive.ToString());
        }
        void kiemtraphienbanapp()
        {

            string verht = version(@"Config.xml"); //Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblStatus.Text = "Developed by Hoang Viet E-Learning Group Ver. " + verht;
            string vernew = version("http://e-learning.hoangviet.edu.vn:5052/HV_Elearning_Students/Config.xml");
            //version("https://drive.google.com/uc?export=download&id=1iL8o-YLwayHmE0amRo-smx3nz10VLWD1");
            //version("http://e-learning.hoangviet.edu.vn:5052/HV_Elearning/Config.xml");

            Program.verht = vernew;
            if (vernew != "")
            {
                if (verht != vernew)
                {
                    if (MessageBox.Show("Phiên bản hiện tại của phần mềm: V." + verht + "\r\nHiện tại đã có phiên bản mới hơn: V." + vernew + "\r\n Nhấn YES tải phiên bản mới", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        Application.Exit();
                        return;
                    }
                    else
                    //-----tai phien ban moi ve
                    {
                        // xoa file update di, tai lai file update moi
                        if (System.IO.File.Exists(@"Update.exe"))
                            System.IO.File.Delete(@"Update.exe");

                        if (!System.IO.File.Exists(@"Update.exe"))
                        {
                            downloadData("Update.exe");
                            saveData("Update.exe");
                        }
                        /////
                        update = 1;
                        this.Close();
                    }
                    //-----------------
                }
            }

        }
        int update = 0;
        private byte[] downloadedData;
        //Connects to a URL and attempts to download the file
        int bytebuffer = 1024; //set cai nay de tang toc do down.
        private void saveData(string fileName)
        {
            if (downloadedData != null && downloadedData.Length != 0)
            {
                this.Text = "Saving Data...";
                Application.DoEvents();

                //Write the bytes to a file
                FileStream newFile = new FileStream(@fileName, FileMode.Create);
                newFile.Write(downloadedData, 0, downloadedData.Length);
                newFile.Close();
            }
        }
        private void downloadData(string url)
        {
            string Link = "http://e-learning.hoangviet.edu.vn:5052/HV_Elearning_Students/";
            url = Link + url;
            //progressBar1.Visible = true;
            //progressBar1.Value = 0;
            downloadedData = new byte[0];
            try
            {
                //Optional
                this.Text = "Connecting...";
                Application.DoEvents();

                //Get a data stream from the url
                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();

                //Download in chuncks
                byte[] buffer = new byte[bytebuffer]; // old [1024]

                //Get Total Size
                int dataLength = (int)response.ContentLength;

                //With the total data we can set up our progress indicators
                //progressBar1.Maximum = dataLength;
                //lbProgress.Text = "0/" + dataLength.ToString();

                this.Text = "Downloading...";
                Application.DoEvents();
                //Download to memory
                //Note: adjust the streams here to download directly to the hard drive
                MemoryStream memStream = new MemoryStream();
                while (true)
                {
                    //Try to read the data
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        ////Finished downloading
                        //progressBar1.Value = progressBar1.Maximum;
                        //lbProgress.Text = dataLength.ToString() + "/" + dataLength.ToString();

                        Application.DoEvents();
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);

                        //Update the progress bar
                        //if (progressBar1.Value + bytesRead <= progressBar1.Maximum)
                        //{
                        //    progressBar1.Value += bytesRead;
                        //    lbProgress.Text = progressBar1.Value.ToString() + "/" + dataLength.ToString();

                        //    progressBar1.Refresh();
                        //    Application.DoEvents();
                        //}
                    }
                }

                //Convert the downloaded stream to a byte array
                downloadedData = memStream.ToArray();

                //Clean up
                stream.Close();
                memStream.Close();
            }
            catch (Exception)
            {
                //May not be connected to the internet
                //Or the URL might not exist
                MessageBox.Show("Lỗi kết nối. không load được thư viện phần mềm");
                Application.Exit();
            }

            // txtData.Text = downloadedData.Length.ToString();
            //this.Text = "Download Data through HTTP";
        }
        private static string version(string url)
        {
            string _config = "";
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
                    if (xmlReader.Name == "version_Students")
                    {
                        _config = xmlReader.ReadElementString();
                    }
                }
                xmlReader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Cursor.Current = Cursors.Default;
            // su dung kiem tra port
            return _config;
        }

        private void listCoursesToRun_Students_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (update == 1)
            {
                Process.Start("Update.exe");
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (Program.kieunopbai == "3")
            {
                kiemtrasoluongbai();
                if (kiemtrakieunopbai() == true)
                    Program.kieunopbai = "1";//nop diem va chi tiet cau hoi
                else
                    Program.kieunopbai = "0";//chi nop diem
                uploadMarks();
                lblthongbao.Text = Program.usages_id;
            }
            else
            {
                uploadMarks();
                lblthongbao.Text = Program.usages_id;
            }
        }

        private void btnhoanthanh_Click(object sender, EventArgs e)
        {
            hoanthanhtacvu();
        }
        void hoanthanhtacvu()
        {
            DataTable ds_mdl_course_modules_completion = new DataTable();
            ds_mdl_course_modules_completion = clnd.mdl_course_modules_completion_userid();
            RegistryWriter rg = new RegistryWriter();
            string completionstate = rg.valuekey(Program.Name_Courses + "_completionstate");
            for (int i = int.Parse(completionstate); i < ds_mdl_course_modules_completion.Rows.Count; i++)
            {
                clnd.coursemoduleid = ds_mdl_course_modules_completion.Rows[i][1].ToString();
                clnd.userid = Int64.Parse(ds_mdl_course_modules_completion.Rows[i][2].ToString());
                clnd.completionstate = bool.Parse(ds_mdl_course_modules_completion.Rows[i][3].ToString());
                clnd.viewed = bool.Parse(ds_mdl_course_modules_completion.Rows[i][4].ToString());
                if (ds_mdl_course_modules_completion.Rows[i][5].ToString() == "")
                    clnd.overrideby = null;
                else
                    clnd.overrideby = ds_mdl_course_modules_completion.Rows[i][5].ToString();
                clnd.timemodified = ds_mdl_course_modules_completion.Rows[i][6].ToString();
                if (clnd.mdl_course_modules_completion_Them() == true)
                {
                    int j = i + 1;
                    rg.WriteKey(Program.Name_Courses + "_completionstate", j.ToString());
                }
            }
        }

        bool ktnopbai = false;
        private void btnnopdiem_Click(object sender, EventArgs e)
        {
            timer_Elapsed(null, null);
        }

        private void listCoursesToRun_Students_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ktstart == true)
            {
                MessageBox.Show("Đang nộp điểm không tắt chương trình vào lúc này.");
                e.Cancel = true;
            }
        }
    }
}
