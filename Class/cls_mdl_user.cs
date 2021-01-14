using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;
using System.IO.Compression;
using System.Collections;
using System.Security;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace unzipPackage.Class
{
    class cls_mdl_user
    {
        public Int64 id { get; set; }
        public string auth { get; set; }
        public bool confirmed { get; set; }
        public bool policyagreed { get; set; }
        public bool deleted { get; set; }
        public bool suspended { get; set; }
        public Int64 mnethostid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string idnumber { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public bool emailstop { get; set; }
        public string icq { get; set; }
        public string skype { get; set; }
        public string yahoo { get; set; }
        public string aim { get; set; }
        public string msn { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string institution { get; set; }
        public string department { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string lang { get; set; }
        public string calendartype { get; set; }
        public string theme { get; set; }
        public string timezone { get; set; }
        public Int64 firstaccess { get; set; }
        public Int64 lastaccess { get; set; }
        public Int64 lastlogin { get; set; }
        public Int64 currentlogin { get; set; }
        public string lastip { get; set; }
        public string secret { get; set; }
        public string picture { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public int descriptionformat { get; set; }
        public bool mailformat { get; set; }
        public bool maildigest { get; set; }
        public int maildisplay { get; set; }
        public bool autosubscribe { get; set; }
        public bool trackforums { get; set; }
        public string timecreated { get; set; }
        public string timemodified { get; set; }
        public string trustbitmask { get; set; }
        public string imagealt { get; set; }
        public string lastnamephonetic { get; set; }
        public string firstnamephonetic { get; set; }
        public string middlename { get; set; }
        public string alternatename { get; set; }

        public DataTable mdl_user_DS()
        {
            string procname = "mdl_user_DS";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_user_Delete()
        {
            string procname = "mdl_user_Delete";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_user_DS_moodle()
        {
            string procname = @"SELECT * FROM `mdl_user`";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public bool mdl_user_Them(DataTable dsuser)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                for (int i = 0; i < dsuser.Rows.Count; i++)
                {

                    id = Int64.Parse(dsuser.Rows[i]["id"].ToString());
                    auth = (dsuser.Rows[i]["auth"].ToString());
                    confirmed = bool.Parse(dsuser.Rows[i]["confirmed"].ToString());
                    policyagreed = bool.Parse(dsuser.Rows[i]["policyagreed"].ToString());
                    deleted = bool.Parse(dsuser.Rows[i]["deleted"].ToString());
                    suspended = bool.Parse(dsuser.Rows[i]["suspended"].ToString());
                    mnethostid = Int64.Parse(dsuser.Rows[i]["mnethostid"].ToString());
                    username = dsuser.Rows[i]["username"].ToString();
                    password = dsuser.Rows[i]["password"].ToString();
                    idnumber = dsuser.Rows[i]["idnumber"].ToString();
                    firstname = dsuser.Rows[i]["firstname"].ToString();
                    lastname = dsuser.Rows[i]["lastname"].ToString();
                    email = dsuser.Rows[i]["email"].ToString();
                    emailstop = bool.Parse(dsuser.Rows[i]["emailstop"].ToString());
                    icq = dsuser.Rows[i]["icq"].ToString();
                    skype = dsuser.Rows[i]["skype"].ToString();
                    yahoo = dsuser.Rows[i]["yahoo"].ToString();
                    aim = dsuser.Rows[i]["aim"].ToString();
                    msn = dsuser.Rows[i]["msn"].ToString();
                    phone1 = dsuser.Rows[i]["phone1"].ToString();
                    phone2 = dsuser.Rows[i]["phone2"].ToString();
                    institution = dsuser.Rows[i]["institution"].ToString();
                    department = dsuser.Rows[i]["department"].ToString();
                    address = dsuser.Rows[i]["address"].ToString();
                    city = dsuser.Rows[i]["city"].ToString();
                    country = dsuser.Rows[i]["country"].ToString();
                    lang = dsuser.Rows[i]["lang"].ToString();
                    calendartype = dsuser.Rows[i]["calendartype"].ToString();
                    theme = dsuser.Rows[i]["theme"].ToString();
                    timezone = dsuser.Rows[i]["timezone"].ToString();
                    firstaccess = Int64.Parse(dsuser.Rows[i]["firstaccess"].ToString());
                    lastaccess = Int64.Parse(dsuser.Rows[i]["lastaccess"].ToString());
                    lastlogin = Int64.Parse(dsuser.Rows[i]["lastlogin"].ToString());
                    currentlogin = Int64.Parse(dsuser.Rows[i]["currentlogin"].ToString());
                    lastip = dsuser.Rows[i]["lastip"].ToString();
                    secret = dsuser.Rows[i]["secret"].ToString();
                    picture = dsuser.Rows[i]["picture"].ToString();
                    url = dsuser.Rows[i]["url"].ToString();
                    description = dsuser.Rows[i]["description"].ToString();
                    if (dsuser.Rows[i]["descriptionformat"].ToString() != "")
                        descriptionformat = int.Parse(dsuser.Rows[i]["descriptionformat"].ToString());
                    else
                        descriptionformat = 0;
                    if (dsuser.Rows[i]["mailformat"].ToString() != "")
                        mailformat = bool.Parse(dsuser.Rows[i]["mailformat"].ToString());
                    else
                        mailformat = false;
                    if (dsuser.Rows[i]["maildigest"].ToString() != "")
                        maildigest = bool.Parse(dsuser.Rows[i]["maildigest"].ToString());
                    else
                        maildigest = false;
                    if (dsuser.Rows[i]["maildisplay"].ToString() != "")
                        maildisplay = int.Parse(dsuser.Rows[i]["maildisplay"].ToString());
                    else
                        maildisplay = 0;
                    if (dsuser.Rows[i]["autosubscribe"].ToString() != "")
                        autosubscribe = bool.Parse(dsuser.Rows[i]["autosubscribe"].ToString());
                    else
                        autosubscribe = false;
                    if (dsuser.Rows[i]["trackforums"].ToString() != "")
                        trackforums = bool.Parse(dsuser.Rows[i]["trackforums"].ToString());
                    else
                        trackforums = false;
                    timecreated = dsuser.Rows[i]["timecreated"].ToString();
                    timemodified = dsuser.Rows[i]["timemodified"].ToString();
                    trustbitmask = dsuser.Rows[i]["trustbitmask"].ToString();
                    imagealt = dsuser.Rows[i]["imagealt"].ToString();
                    lastnamephonetic = dsuser.Rows[i]["lastnamephonetic"].ToString();
                    firstnamephonetic = dsuser.Rows[i]["firstnamephonetic"].ToString();
                    middlename = dsuser.Rows[i]["middlename"].ToString();
                    alternatename = dsuser.Rows[i]["alternatename"].ToString();

                    db.CreateNewSqlCommand();
                    db.AddParameter("@id", id);
                    db.AddParameter("@auth", auth);
                    db.AddParameter("@confirmed", confirmed);
                    db.AddParameter("@policyagreed", policyagreed);
                    db.AddParameter("@deleted", deleted);
                    db.AddParameter("@suspended", suspended);
                    db.AddParameter("@mnethostid", mnethostid);
                    db.AddParameter("@username", username);
                    db.AddParameter("@password", password);
                    db.AddParameter("@idnumber", idnumber);
                    db.AddParameter("@firstname", firstname);
                    db.AddParameter("@lastname", lastname);
                    db.AddParameter("@email", email);
                    db.AddParameter("@emailstop", emailstop);
                    db.AddParameter("@icq", icq);
                    db.AddParameter("@skype", skype);
                    db.AddParameter("@yahoo", yahoo);
                    db.AddParameter("@aim", aim);
                    db.AddParameter("@msn", msn);
                    db.AddParameter("@phone1", phone1);
                    db.AddParameter("@phone2", phone2);
                    db.AddParameter("@institution", institution);
                    db.AddParameter("@department", department);
                    db.AddParameter("@address", address);
                    db.AddParameter("@city", city);
                    db.AddParameter("@country", country);
                    db.AddParameter("@lang", lang);
                    db.AddParameter("@calendartype", calendartype);
                    db.AddParameter("@theme", theme);
                    db.AddParameter("@timezone", timezone);
                    db.AddParameter("@firstaccess", firstaccess);
                    db.AddParameter("@lastaccess", lastaccess);
                    db.AddParameter("@lastlogin", lastlogin);
                    db.AddParameter("@currentlogin", currentlogin);
                    db.AddParameter("@lastip", lastip);
                    db.AddParameter("@secret", secret);
                    db.AddParameter("@picture", picture);
                    db.AddParameter("@url", url);
                    db.AddParameter("@description", description);
                    db.AddParameter("@descriptionformat", descriptionformat);
                    db.AddParameter("@mailformat", mailformat);
                    db.AddParameter("@maildigest", maildigest);
                    db.AddParameter("@maildisplay", maildisplay);
                    db.AddParameter("@autosubscribe", autosubscribe);
                    db.AddParameter("@trackforums", trackforums);
                    db.AddParameter("@timecreated", timecreated);
                    db.AddParameter("@timemodified", timemodified);
                    db.AddParameter("@trustbitmask", trustbitmask);
                    db.AddParameter("@imagealt", imagealt);
                    db.AddParameter("@lastnamephonetic", lastnamephonetic);
                    db.AddParameter("@firstnamephonetic", firstnamephonetic);
                    db.AddParameter("@middlename", middlename);
                    db.AddParameter("@alternatename", alternatename);
                    db.ExecuteNonQueryWithTransaction("mdl_user_Them");
                }
                db.CommitTransaction();
                return true;
            }
            catch
            {
                db.RollbackTransaction();
                return false;
            }
        }
    }
}
