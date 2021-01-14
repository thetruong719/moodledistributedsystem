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
    class cls_mdl_quiz_grades
    {        //---mdl_grade_grades--
        public Int64 id { get; set; }
        public Int64 quiz { get; set; }
        public Int64 userid { get; set; }
        public string grade { get; set; }
        public Int64 timemodified { get; set; }

        //----mdl_quiz_attempts
        //public Int64 id { get; set; }
        //public Int64 quiz { get; set; }
        //public Int64 userid { get; set; }
        public int attempt { get; set; }
        public Int64 uniqueid { get; set; }
        public string layout { get; set; }
        public Int64 currentpage { get; set; }
        public int preview { get; set; }
        public string state { get; set; }
        public Int64 timestart { get; set; }
        public Int64 timefinish { get; set; }
        //public Int64 timemodified { get; set; }
        public Int64 timemodifiedoffline { get; set; }
        public string timecheckstate { get; set; }
        public string sumgrades { get; set; }
        //----------------------------
        public DataTable mdl_quiz_grades_DS(string userid)
        {
            string procname = @"select * from mdl_quiz_grades where userid=" + userid + "";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public bool mdl_quiz_grades_Them()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@quiz", quiz);
                db.AddParameter("@userid", userid);
                db.AddParameter("@grade", grade);
                db.AddParameter("@timemodified", timemodified);
                db.ExecuteNonQueryWithTransaction("mdl_quiz_grades_Them");
                db.CommitTransaction();
                return true;
            }
            catch
            {
                db.RollbackTransaction();
                return false;
            }
        }
        public bool mdl_quiz_grades_Sua()
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@id", id);
                db.AddParameter("@grade", grade);
                db.AddParameter("@timemodified", timemodified);
                db.ExecuteNonQueryWithTransaction("mdl_quiz_grades_Sua");
                db.CommitTransaction();
                return true;
            }
            catch
            {
                db.RollbackTransaction();
                return false;
            }
        }
        public DataTable mdl_quiz_attempts_DS(string userid)
        {
            string procname = @"select * from mdl_quiz_attempts where userid=" + userid + "";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_quiz_attempts_DS_uniqueid(string uniqueid_)
        {
            string procname = @"select * from mdl_quiz_attempts where uniqueid=" + uniqueid_ + "";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public bool mdl_quiz_attempts_Them(string quiz_, string userid_, string attempt_, string uniqueid_, string layout_, string currentpage_, string preview_, string state_, string timestart_, string timefinish_, string timemodified_, string timemodifiedoffline_, string timecheckstate_, string sumgrades_)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@quiz", quiz_);
                db.AddParameter("@userid", userid_);
                db.AddParameter("@attempt", attempt_);
                db.AddParameter("@uniqueid", uniqueid_);
                db.AddParameter("@layout", layout_);
                db.AddParameter("@currentpage", currentpage_);
                db.AddParameter("@preview", preview_);
                db.AddParameter("@state", state_);
                db.AddParameter("@timestart", timestart_);
                db.AddParameter("@timefinish", timefinish_);
                db.AddParameter("@timemodified", timemodified_);
                db.AddParameter("@timemodifiedoffline", timemodifiedoffline_);
                db.AddParameter("@timecheckstate", timecheckstate_);
                db.AddParameter("@sumgrades", sumgrades_);
                db.ExecuteNonQueryWithTransaction("mdl_quiz_attempts_Them");
                db.CommitTransaction();
                return true;
            }
            catch
            {
                db.RollbackTransaction();
                return false;
            }
        }
        public bool mdl_quiz_attempts_Them_uniqueid(string quiz_, string userid_, string attempt_, string uniqueid_, string layout_, string currentpage_, string preview_, string state_, string timestart_, string timefinish_, string timemodified_, string timemodifiedoffline_, string timecheckstate_, string sumgrades_)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@quiz", quiz_);
                db.AddParameter("@userid", userid_);
                db.AddParameter("@attempt", attempt_);
                db.AddParameter("@uniqueid", uniqueid_);
                db.AddParameter("@layout", layout_);
                db.AddParameter("@currentpage", currentpage_);
                db.AddParameter("@preview", preview_);
                db.AddParameter("@state", state_);
                db.AddParameter("@timestart", timestart_);
                db.AddParameter("@timefinish", timefinish_);
                db.AddParameter("@timemodified", timemodified_);
                db.AddParameter("@timemodifiedoffline", timemodifiedoffline_);
                db.AddParameter("@timecheckstate", timecheckstate_);
                db.AddParameter("@sumgrades", sumgrades_);
                db.ExecuteNonQueryWithTransaction("mdl_quiz_attempts_Them");
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
        public DataTable mdl_quiz_Diem()
        {
            string procname = "mdl_quiz_Diem";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_quiz_DScot()
        {
            string procname = "mdl_quiz_DScot";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
    }
}
