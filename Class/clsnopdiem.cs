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
    class clsnopdiem
    {
        //---mdl_course--
        public Int64 id { get; set; }
        public Int64 category { get; set; }
        public Int64 sortorder { get; set; }
        public string fullname { get; set; }
        public string shortname { get; set; }
        public Int64 idnumber { get; set; }
        public string summary { get; set; }
        public Int64 summaryformat { get; set; }
        public string format { get; set; }
        public int showgrades { get; set; }
        public int newsitems { get; set; }
        public Int64 startdate { get; set; }
        public Int64 enddate { get; set; }
        public int relativedatesmode { get; set; }
        public Int64 marker { get; set; }
        public Int64 maxbytes { get; set; }
        public Int64 legacyfiles { get; set; }
        public int showreports { get; set; }
        public bool visible { get; set; }
        public bool visibleold { get; set; }
        public int groupmode { get; set; }
        public int groupmodeforce { get; set; }
        public int defaultgroupingid { get; set; }
        public Int64 lang { get; set; }
        public Int64 calendartype { get; set; }
        public Int64 theme { get; set; }
        public string timecreated { get; set; }
        public string timemodified { get; set; }
        public bool requested { get; set; }
        public bool enablecompletion { get; set; }
        public bool completionnotify { get; set; }
        public Int64 cacherev { get; set; }

        //---mdl_grade_grades--
        //public Int64 id { get; set; }
        public Int64 itemid { get; set; }
        public Int64 userid { get; set; }
        public string rawgrade { get; set; }
        public string rawgrademax { get; set; }
        public string rawgrademin { get; set; }
        public string rawscaleid { get; set; }
        public string usermodified { get; set; }
        public string finalgrade { get; set; }
        public Int64 hidden { get; set; }
        public Int64 locked { get; set; }
        public Int64 locktime { get; set; }
        public Int64 exported { get; set; }
        public Int64 overridden { get; set; }
        public Int64 excluded { get; set; }
        public string feedback { get; set; }
        public Int64 feedbackformat { get; set; }
        public string information { get; set; }
        public Int64 informationformat { get; set; }
        //public Int64 timecreated { get; set; }
        //public Int64 timemodified { get; set; }
        public string aggregationstatus { get; set; }
        public string aggregationweight { get; set; }


        //---mdl_grade_grades--
        //public float id { get; set; }
        //public Int64 quiz { get; set; }
        //public Int64 userid { get; set; }
        //public Int64 grade { get; set; }
        //public Int64 timemodified { get; set; }
        //---------------------
        //---mdl_course_modules_completion
        public string coursemoduleid { get; set; }
        //public string userid { get; set; }
        public bool completionstate { get; set; }
        public bool viewed { get; set; }
        public string overrideby { get; set; }
        //public string timemodified { get; set; }
        //public string coursemoduleid { get; set; }
        //------------------------------
        //--mdl_block_recentlyaccesseditems
        public string courseid { get; set; }
        public string cmid { get; set; }
        //public string userid { get; set; }
        public string timeaccess { get; set; }
        //------------------------

        public DataTable mdl_course_ds_summaryformat()
        {
            string procname = "mdl_course_ds_summaryformat";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@summaryformat" + "", summaryformat);
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_nopdiem_DS_id( string id_)
        {
            string procname = "mdl_nopdiem_DS_id";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@id" + "", id_);
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_grade_grades_ds_userid(int userid)
        {
            string procname = @"select * from mdl_grade_grades WHERE userid=" + userid + " and finalgrade <>'' ";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_user_lastaccess_DS_Top1()
        {
            string procname = @"SELECT * FROM `mdl_user_lastaccess` ORDER by timeaccess DESC LIMIT 1";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_grade_grades_DS_Itemid_Userid(Int64 itemid_, Int64 userid_)
        {
            string procname = "mdl_grade_grades_DS_Itemid_Userid";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@itemid", itemid_);
            db.AddParameter("@userid", userid_);
            return db.ExecuteDataTable(procname);
        }
        public bool mdl_grade_grades_Them()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@itemid", itemid);
                db.AddParameter("@userid", userid);
                db.AddParameter("@rawgrade", rawgrade);
                db.AddParameter("@rawgrademax", rawgrademax);
                db.AddParameter("@rawgrademin", rawgrademin);
                db.AddParameter("@rawscaleid", rawscaleid);
                db.AddParameter("@usermodified", usermodified);
                db.AddParameter("@finalgrade", finalgrade);
                db.AddParameter("@hidden", hidden);
                db.AddParameter("@locked", locked);
                db.AddParameter("@locktime", locktime);
                db.AddParameter("@exported", exported);
                db.AddParameter("@overridden", overridden);
                db.AddParameter("@excluded", excluded);
                db.AddParameter("@feedback", feedback);
                db.AddParameter("@feedbackformat", feedbackformat);
                db.AddParameter("@information", information);
                db.AddParameter("@informationformat", informationformat);
                db.AddParameter("@timecreated", timecreated);
                db.AddParameter("@timemodified", timemodified);
                db.AddParameter("@aggregationstatus", aggregationstatus);
                db.AddParameter("@aggregationweight", aggregationweight);
                db.ExecuteNonQueryWithTransaction("mdl_grade_grades_Them");
                db.CommitTransaction();
                return true;
            }
            catch
            {
                db.RollbackTransaction();
                return false;
            }
        }
        public bool mdl_grade_grades_Sua_Itemid_Userid()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@itemid", itemid);
                db.AddParameter("@userid", userid);
                db.AddParameter("@rawgrade", rawgrade);
                db.AddParameter("@rawgrademax", rawgrademax);
                db.AddParameter("@rawgrademin", rawgrademin);
                db.AddParameter("@rawscaleid", rawscaleid);
                db.AddParameter("@usermodified", usermodified);
                db.AddParameter("@finalgrade", finalgrade);
                db.AddParameter("@hidden", hidden);
                db.AddParameter("@locked", locked);
                db.AddParameter("@locktime", locktime);
                db.AddParameter("@exported", exported);
                db.AddParameter("@overridden", overridden);
                db.AddParameter("@excluded", excluded);
                db.AddParameter("@feedback", feedback);
                db.AddParameter("@feedbackformat", feedbackformat);
                db.AddParameter("@information", information);
                db.AddParameter("@informationformat", informationformat);
                db.AddParameter("@timecreated", timecreated);
                db.AddParameter("@timemodified", timemodified);
                db.AddParameter("@aggregationstatus", aggregationstatus);
                db.AddParameter("@aggregationweight", aggregationweight);
                db.ExecuteNonQueryWithTransaction("mdl_grade_grades_Sua_Itemid_Userid");
                db.CommitTransaction();
                return true;
            }
            catch
            {
                db.RollbackTransaction();
                return false;
            }
        }
        public DataTable mdl_quiz_grades_DS_quiz_userid(Int64 quiz, Int64 userid_)
        {
            string procname = "mdl_quiz_grades_DS_quiz_userid";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@quiz", quiz);
            db.AddParameter("@userid", userid_);
            return db.ExecuteDataTable(procname);
        }

        public DataTable mdl_course_modules_completion_userid()
        {
            string procname = @"SELECT * FROM `mdl_course_modules_completion` WHERE completionstate=1 ORDER by timemodified ASC";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public bool mdl_course_modules_completion_recentlyaccesseditems_Them(DataTable ds_mdl_block_recentlyaccesseditems)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@coursemoduleid", coursemoduleid);
                db.AddParameter("@userid", userid);
                db.AddParameter("@completionstate", completionstate);
                db.AddParameter("@viewed", viewed);
                db.AddParameter("@timemodified", timemodified);
                db.ExecuteNonQueryWithTransaction("mdl_course_modules_completion_Them");
                db.CreateNewSqlCommand();
                db.AddParameter("@courseid", ds_mdl_block_recentlyaccesseditems.Rows[0][1].ToString());
                db.AddParameter("@cmid", ds_mdl_block_recentlyaccesseditems.Rows[0][2].ToString());
                db.AddParameter("@userid", ds_mdl_block_recentlyaccesseditems.Rows[0][3].ToString());
                db.AddParameter("@timeaccess", ds_mdl_block_recentlyaccesseditems.Rows[0][4].ToString());
                db.ExecuteNonQueryWithTransaction("mdl_block_recentlyaccesseditems_Them");
                db.CommitTransaction();
                return true;
            }
            catch
            {
                db.RollbackTransaction();
                return false;
            }
        }
        public bool mdl_course_modules_completion_Them()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@coursemoduleid", coursemoduleid);
                db.AddParameter("@userid", userid);
                db.AddParameter("@completionstate", completionstate);
                db.AddParameter("@viewed", viewed);
                db.AddParameter("@timemodified", timemodified);
                db.ExecuteNonQueryWithTransaction("mdl_course_modules_completion_Them");
                db.CommitTransaction();
                return true;
            }
            catch
            {
                db.RollbackTransaction();
                return false;
            }
        }

        public string mdl_logstore_standard_log_DS_Top1()
        {
            string procname = @"SELECT userid from mdl_logstore_standard_log ORDER BY mdl_logstore_standard_log.timecreated DESC LIMIT 0,1";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteData_string(procname);
        }
        public DataTable mdl_course_modules_completion_DS()
        {
            string procname = "mdl_course_modules_completion_DS";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_block_recentlyaccesseditems_DS_CMID_Userid(string cmid_, string userid_)
        {
            string procname = "mdl_block_recentlyaccesseditems_DS_CMID_Userid";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@cmid", cmid_);
            db.AddParameter("@userid", userid_);
            return db.ExecuteDataTable(procname);
        }
        public bool mdl_course_modules_completion_MySql_Them(string coursemoduleid_, string userid_, string completionstate_, string viewed_, string overrideby_, string timemodified_)
        {
            try
            {
                string procname = @"INSERT INTO `mdl_course_modules_completion`( `coursemoduleid`, `userid`, `completionstate`, `viewed`, `timemodified`) VALUES (" + coursemoduleid_ + "," + userid_ + "," + completionstate_ + "," + viewed_ + "," + timemodified_ + ")";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction_Text(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable mdl_block_recentlyaccesseditems_CMID(string CMID)
        {
            string procname = @"SELECT * FROM `mdl_block_recentlyaccesseditems` WHERE cmid=" + CMID + "";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
    }
}
