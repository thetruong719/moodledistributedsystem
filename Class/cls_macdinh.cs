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
    class cls_macdinh
    {
        public bool mdl_course_modules_completion_MacDinh()
        {
            try
            {
                string procname = @"DELETE FROM `mdl_course_modules_completion`;ALTER TABLE `mdl_course_modules_completion` AUTO_INCREMENT = 1;";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool mdl_block_recentlyaccesseditems_MacDinh()
        {
            try
            {
                string procname = @"DELETE FROM `mdl_block_recentlyaccesseditems`;ALTER TABLE `mdl_block_recentlyaccesseditems` AUTO_INCREMENT = 1;";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool mdl_question_usages_MacDinh()
        {
            try
            {
                string procname = @"DELETE FROM `mdl_question_usages`;ALTER TABLE `mdl_question_usages` AUTO_INCREMENT = 1;";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool mdl_question_attempts_MacDinh()
        {
            try
            {
                string procname = @"DELETE FROM `mdl_question_attempts`;ALTER TABLE `mdl_question_attempts` AUTO_INCREMENT = 1;";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool mdl_question_attempt_steps_MacDinh()
        {
            try
            {
                string procname = @"DELETE FROM `mdl_question_attempt_steps`;ALTER TABLE `mdl_question_attempt_steps` AUTO_INCREMENT = 1;";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool mdl_question_attempt_step_data_MacDinh()
        {
            try
            {
                string procname = @"DELETE FROM `mdl_question_attempt_step_data`;ALTER TABLE `mdl_question_attempt_step_data` AUTO_INCREMENT = 1;";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool mdl_quiz_grades_MacDinh()
        {
            try
            {
                string procname = @"DELETE FROM `mdl_quiz_grades`;ALTER TABLE `mdl_quiz_grades` AUTO_INCREMENT = 1;";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool mdl_logstore_standard_log_MacDinh()
        {
            try
            {
                string procname = @"DELETE FROM `mdl_logstore_standard_log`;ALTER TABLE `mdl_logstore_standard_log` AUTO_INCREMENT = 1;";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool mdl_sessions_MacDinh()
        {
            try
            {
                string procname = @"DELETE FROM `mdl_sessions`;ALTER TABLE `mdl_sessions` AUTO_INCREMENT = 1;";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool mdl_user_lastaccess_data_MacDinh()
        {
            try
            {
                string procname = @"DELETE FROM `mdl_user_lastaccess`;ALTER TABLE `mdl_user_lastaccess` AUTO_INCREMENT = 1;";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool mdl_quiz_attempts_MacDinh()
        {
            try
            {
                string procname = @"DELETE FROM `mdl_quiz_attempts`;ALTER TABLE `mdl_quiz_attempts` AUTO_INCREMENT = 1;";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool mdl_quiz_feedback_MacDinh()
        {
            try
            {
                string procname = @"DELETE FROM `mdl_quiz_feedback`;ALTER TABLE `mdl_quiz_feedback` AUTO_INCREMENT = 1;";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction(procname);

                return true;
            }
            catch
            {
                return false;
            }
        }
        #region "Transaction"

        #endregion
    }
}
