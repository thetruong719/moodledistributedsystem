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
    class mdl_question
    {
        Class.cls_mdl_quiz_grades clqg = new cls_mdl_quiz_grades();
        //---mdl_question_usages--
        public Int64 id { get; set; }
        public string contextid { get; set; }
        public string component { get; set; }
        public string preferredbehaviour { get; set; }
        //------------------------
        //---mdl_question_attempts
        //public Int64 id { get; set; }
        public string questionusageid { get; set; }
        public string slot { get; set; }
        public string behaviour { get; set; }
        public string questionid { get; set; }
        public string variant { get; set; }
        public string maxmark { get; set; }
        public string minfraction { get; set; }
        public string maxfraction { get; set; }
        public string flagged { get; set; }
        public string questionsummary { get; set; }
        public string rightanswer { get; set; }
        public string responsesummary { get; set; }
        public string timemodified { get; set; }
        //------------------------
        public DataTable mdl_question_usages_DS()
        {
            string procname = @"select * from mdl_question_usages";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_question_usages_DS_state_finished()
        {
            string procname = @"SELECT mdl_question_usages.id, mdl_question_usages.contextid, mdl_question_usages.component, mdl_question_usages.preferredbehaviour, mdl_quiz_attempts.timefinish FROM mdl_question_usages INNER JOIN mdl_quiz_attempts ON mdl_question_usages.id = mdl_quiz_attempts.uniqueid WHERE (mdl_quiz_attempts.state = 'finished') ORDER BY mdl_quiz_attempts.timefinish ASC";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public int mdl_question_usages_DS_state_finished_()
        {
            string procname = @"SELECT mdl_question_usages.id, mdl_question_usages.contextid, mdl_question_usages.component, mdl_question_usages.preferredbehaviour FROM mdl_question_usages INNER JOIN mdl_quiz_attempts ON mdl_question_usages.id = mdl_quiz_attempts.uniqueid WHERE mdl_quiz_attempts.state='finished'";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.Execute_int(procname);
        }
        public DataTable mdl_question_attempts_DS(string questionusage_id)
        {
            string procname = @"SELECT * FROM mdl_question_attempts WHERE questionusageid=" + questionusage_id + "";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_question_attempt_steps_DS(string questionattempt_id, string sequencenumber_)
        {
            string procname = @"SELECT * FROM `mdl_question_attempt_steps` WHERE questionattemptid=" + questionattempt_id + " AND sequencenumber=" + sequencenumber_ + "";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_question_attempt_step_data_DS(string attemptstep_id)
        {
            string procname = @"SELECT * FROM `mdl_question_attempt_step_data` WHERE attemptstepid=" + attemptstep_id + "";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        DataTable ds_mdl_question_attempt_steps = new DataTable();
        DataTable ds_mdl_question_attempt_step_data = new DataTable();
        DataTable ds_questionattempt_id = new DataTable();
        int attemptstep_id;
        int questionattempt_id;
        public bool mdl_question_usages_Them(DataTable ds_mdl_question_attempts, DataTable ds_mdl_quiz_attempts)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                db.CreateNewSqlCommand();
                db.AddParameter("@contextid", contextid);
                db.AddParameter("@component", component);
                db.AddParameter("@preferredbehaviour", preferredbehaviour);
                int questionusage_id = db.ExecuteScalarWithTransaction("mdl_question_usages_Them");
                //------------------
                ds_questionattempt_id.Clear();
                ds_questionattempt_id.Columns.Clear();
                ds_questionattempt_id.Columns.Add("questionusage_id");
                //------------------
                db.CreateNewSqlCommand();
                db.AddParameter("@quiz", ds_mdl_quiz_attempts.Rows[0][1].ToString());
                db.AddParameter("@userid", ds_mdl_quiz_attempts.Rows[0][2].ToString());
                db.AddParameter("@attempt", ds_mdl_quiz_attempts.Rows[0][3].ToString());
                db.AddParameter("@uniqueid", questionusage_id.ToString());
                db.AddParameter("@layout", ds_mdl_quiz_attempts.Rows[0][5].ToString());
                db.AddParameter("@currentpage", ds_mdl_quiz_attempts.Rows[0][6].ToString());
                db.AddParameter("@preview", ds_mdl_quiz_attempts.Rows[0][7].ToString());
                db.AddParameter("@state", ds_mdl_quiz_attempts.Rows[0][8].ToString());
                db.AddParameter("@timestart", ds_mdl_quiz_attempts.Rows[0][9].ToString());
                db.AddParameter("@timefinish", ds_mdl_quiz_attempts.Rows[0][10].ToString());
                db.AddParameter("@timemodified", ds_mdl_quiz_attempts.Rows[0][11].ToString());
                db.AddParameter("@timemodifiedoffline", ds_mdl_quiz_attempts.Rows[0][12].ToString());
                db.AddParameter("@timecheckstate", ds_mdl_quiz_attempts.Rows[0][13].ToString());
                db.AddParameter("@sumgrades", ds_mdl_quiz_attempts.Rows[0][14].ToString());
                db.ExecuteNonQueryWithTransaction("mdl_quiz_attempts_Them");

                //---------
                for (int i = 0; i < ds_mdl_question_attempts.Rows.Count; i++)
                {
                    db.CreateNewSqlCommand();
                    db.AddParameter("@questionusageid", questionusage_id);
                    db.AddParameter("@slot", ds_mdl_question_attempts.Rows[i][2].ToString());
                    db.AddParameter("@behaviour", ds_mdl_question_attempts.Rows[i][3].ToString());
                    db.AddParameter("@questionid", ds_mdl_question_attempts.Rows[i][4].ToString());
                    db.AddParameter("@variant", ds_mdl_question_attempts.Rows[i][5].ToString());
                    db.AddParameter("@maxmark", ds_mdl_question_attempts.Rows[i][6].ToString());
                    db.AddParameter("@minfraction", ds_mdl_question_attempts.Rows[i][7].ToString());
                    db.AddParameter("@maxfraction", ds_mdl_question_attempts.Rows[i][8].ToString());
                    db.AddParameter("@flagged", bool.Parse(ds_mdl_question_attempts.Rows[i][9].ToString()));
                    db.AddParameter("@questionsummary", ds_mdl_question_attempts.Rows[i][10].ToString());
                    db.AddParameter("@rightanswer", ds_mdl_question_attempts.Rows[i][11].ToString());
                    db.AddParameter("@responsesummary", ds_mdl_question_attempts.Rows[i][12].ToString());
                    db.AddParameter("@timemodified", ds_mdl_question_attempts.Rows[i][13].ToString());
                    questionattempt_id = db.ExecuteScalarWithTransaction("mdl_question_attempts_Them");

                    //--------------todo
                    ds_mdl_question_attempt_steps = mdl_question_attempt_steps_DS(ds_mdl_question_attempts.Rows[i][0].ToString(), 0.ToString());
                    db.CreateNewSqlCommand();
                    db.AddParameter("@questionattemptid", questionattempt_id.ToString());
                    ds_questionattempt_id.Rows.Add(questionattempt_id.ToString());
                    db.AddParameter("@sequencenumber", ds_mdl_question_attempt_steps.Rows[0][2].ToString());
                    db.AddParameter("@state", ds_mdl_question_attempt_steps.Rows[0][3].ToString());
                    if ((ds_mdl_question_attempt_steps.Rows[0][4].ToString()) == "")
                        db.AddParameter("@fraction", DBNull.Value);
                    else
                        db.AddParameter("@fraction", (ds_mdl_question_attempt_steps.Rows[0][4].ToString()));
                    db.AddParameter("@timecreated", ds_mdl_question_attempt_steps.Rows[0][5].ToString());
                    db.AddParameter("@userid", ds_mdl_question_attempt_steps.Rows[0][6].ToString());
                    attemptstep_id = db.ExecuteScalarWithTransaction("mdl_question_attempt_steps_Them");
                    ds_mdl_question_attempt_step_data = mdl_question_attempt_step_data_DS(ds_mdl_question_attempt_steps.Rows[0][0].ToString());//_order
                    db.CreateNewSqlCommand();
                    db.AddParameter("@attemptstepid", attemptstep_id.ToString());
                    db.AddParameter("@name", ds_mdl_question_attempt_step_data.Rows[0][2].ToString());
                    db.AddParameter("@value", ds_mdl_question_attempt_step_data.Rows[0][3].ToString());
                    db.ExecuteNonQueryWithTransaction("mdl_question_attempt_step_data_Them");
                }
                for (int i = 0; i < ds_mdl_question_attempts.Rows.Count; i++)
                {
                    //--------------complete
                    ds_mdl_question_attempt_steps = mdl_question_attempt_steps_DS(ds_mdl_question_attempts.Rows[i][0].ToString(), 1.ToString());//complete
                    db.CreateNewSqlCommand();
                    db.AddParameter("@questionattemptid", ds_questionattempt_id.Rows[i][0].ToString());
                    db.AddParameter("@sequencenumber", ds_mdl_question_attempt_steps.Rows[0][2].ToString());
                    db.AddParameter("@state", ds_mdl_question_attempt_steps.Rows[0][3].ToString());
                    if ((ds_mdl_question_attempt_steps.Rows[0][4].ToString()) == "")
                        db.AddParameter("@fraction", DBNull.Value);
                    else
                        db.AddParameter("@fraction", (ds_mdl_question_attempt_steps.Rows[0][4].ToString()));
                    db.AddParameter("@timecreated", ds_mdl_question_attempt_steps.Rows[0][5].ToString());
                    db.AddParameter("@userid", ds_mdl_question_attempt_steps.Rows[0][6].ToString());
                    attemptstep_id = db.ExecuteScalarWithTransaction("mdl_question_attempt_steps_Them");
                    ds_mdl_question_attempt_step_data = mdl_question_attempt_step_data_DS(ds_mdl_question_attempt_steps.Rows[0][0].ToString());//_order
                    db.CreateNewSqlCommand();
                    db.AddParameter("@attemptstepid", attemptstep_id.ToString());
                    db.AddParameter("@name", ds_mdl_question_attempt_step_data.Rows[0][2].ToString());
                    db.AddParameter("@value", ds_mdl_question_attempt_step_data.Rows[0][3].ToString());
                    db.ExecuteNonQueryWithTransaction("mdl_question_attempt_step_data_Them");
                }
                for (int i = 0; i < ds_mdl_question_attempts.Rows.Count; i++)
                {
                    //--------------grade
                    ds_mdl_question_attempt_steps = mdl_question_attempt_steps_DS(ds_mdl_question_attempts.Rows[i][0].ToString(), 2.ToString());
                    if (ds_mdl_question_attempt_steps.Rows.Count > 0) 
                    {
                        db.CreateNewSqlCommand();
                        db.AddParameter("@questionattemptid", ds_questionattempt_id.Rows[i][0].ToString());
                        db.AddParameter("@sequencenumber", ds_mdl_question_attempt_steps.Rows[0][2].ToString());
                        db.AddParameter("@state", ds_mdl_question_attempt_steps.Rows[0][3].ToString());
                        if ((ds_mdl_question_attempt_steps.Rows[0][4].ToString()) == "")
                            db.AddParameter("@fraction", DBNull.Value);
                        else
                            db.AddParameter("@fraction", (ds_mdl_question_attempt_steps.Rows[0][4].ToString()));
                        db.AddParameter("@timecreated", ds_mdl_question_attempt_steps.Rows[0][5].ToString());
                        db.AddParameter("@userid", ds_mdl_question_attempt_steps.Rows[0][6].ToString());
                        attemptstep_id = db.ExecuteScalarWithTransaction("mdl_question_attempt_steps_Them");
                        ds_mdl_question_attempt_step_data = mdl_question_attempt_step_data_DS(ds_mdl_question_attempt_steps.Rows[0][0].ToString());//_order
                        db.CreateNewSqlCommand();
                        db.AddParameter("@attemptstepid", attemptstep_id.ToString());
                        db.AddParameter("@name", ds_mdl_question_attempt_step_data.Rows[0][2].ToString());
                        db.AddParameter("@value", ds_mdl_question_attempt_step_data.Rows[0][3].ToString());
                        db.ExecuteNonQueryWithTransaction("mdl_question_attempt_step_data_Them");
                    }
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
        public Int64 usages_ID { get; set; }
        public bool mdl_question_usages_Them(string context_id, string compone_nt, string preferredbehavio_ur)
        {
            try
            {
                string procname = @"INSERT INTO `mdl_question_usages`( `contextid`, `component`, `preferredbehaviour`) VALUES ('80','mod_quiz','deferredfeedback')";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction_Text(procname);
                db.CommitTransaction();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable mdl_question_attempts_DS()
        {
            string procname = @"SELECT * FROM mdl_question_attempts";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_question_usages_max()
        {
            string procname = @"SELECT max(id) FROM `mdl_question_usages`";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_question_usages_DS_ID()
        {
            string procname = "mdl_question_usages_DS_ID";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@id", usages_ID);
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_question_usages_DS_sql()
        {
            string procname = "mdl_question_usages_DS";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_quiz_grades_DS()
        {
            string procname = "mdl_quiz_grades_DS";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public void mdl_quiz_grades_Xoa_ID_1()
        {
            string procname = @"DELETE FROM `mdl_quiz_grades` WHERE 1;ALTER TABLE `mdl_quiz_grades` AUTO_INCREMENT = 1";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            db.ExecuteNonQueryWithTransaction_Text(procname);
        }
        public string mdl_quiz_grades_ID_1()
        {
            string procname = @"ALTER TABLE `mdl_quiz_grades` AUTO_INCREMENT = 1";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteData_string(procname);
        }
        public void mdl_quiz_grades_Them(string quiz_,string userid_,string grade_,string timemodified_)
        {
            string procname = @"INSERT INTO `mdl_quiz_grades`(`quiz`, `userid`, `grade`, `timemodified`) VALUES (" + quiz_ + "," + userid_ + "," + grade_ + "," + timemodified_ + ")";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            db.ExecuteNonQueryWithTransaction_Text(procname);
        }

        public DataTable mdl_quiz_attempts_DS_uniqueid(string uniqueid_)
        {
            string procname = "mdl_quiz_attempts_DS_uniqueid";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@uniqueid", uniqueid_);
            return db.ExecuteDataTable(procname);
        }

        public DataTable mdl_question_attempts_DS_questionusage_id(string questionusage_id)
        {
            string procname = "mdl_question_attempts_DS_questionusageid";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@questionusageid", questionusage_id);
            return db.ExecuteDataTable(procname);
        }

        public bool mdl_quiz_attempts_Them(string quiz_, string userid_, string attempt_, string uniqueid_, string layout_, string currentpage_, string preview_, string state_, string timestart_, string timefinish_, string timemodified_, string timemodifiedoffline_, string timecheckstate_, string sumgrades_)
        {
            try
            {
                string procname = @"INSERT INTO `mdl_quiz_attempts`(`quiz`, `userid`, `attempt`, `uniqueid`, `layout`, `currentpage`, `preview`, `state`, `timestart`, `timefinish`, `timemodified`, `timemodifiedoffline`, `timecheckstate`, `sumgrades`) VALUES (" + quiz_ + "," + userid_ + "," + attempt_ + "," + uniqueid_ + ",'" + layout_ + "'," + currentpage_ + "," + preview_ + ",'" + state_ + "'," + timestart_ + "," + timefinish_ + "," + timemodified_ + "," + timemodifiedoffline_ + "," + timecheckstate_ + "," + sumgrades_ + ")";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction_Text(procname);
                db.CommitTransaction();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool mmdl_question_attempts_Them(string questionusage_id, string slot_, string behaviour_, string questionid_, string variant_, string maxmark_, string minfraction_, string maxfraction_, string flagged_, string questionsummary_, string rightanswer_, string responsesummary_, string timemodified_)
        {
            try
            {
                string procname = @"INSERT INTO `mdl_question_attempts`(`questionusageid`, `slot`, `behaviour`, `questionid`, `variant`, `maxmark`, `minfraction`, `maxfraction`, `flagged`, `questionsummary`, `rightanswer`, `responsesummary`, `timemodified`) VALUES (" + questionusage_id + "," + slot_ + ",'" + behaviour_ + "'," + questionid_ + "," + variant_ + "," + maxmark_ + "," + minfraction_ + "," + maxfraction_ + "," + flagged_ + ",'" + questionsummary_ + "','" + rightanswer_ + "','" + responsesummary_ + "'," + timemodified_ + ")";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction_Text(procname);
                db.CommitTransaction();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string mdl_question_attempts_max()
        {
            string procname = @"SELECT max(id) FROM `mdl_question_attempts` WHERE 1";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteData_string(procname);
        }
        public DataTable mdl_question_attempt_steps_DS_questionattemptid_sequencenumber(string questionattempt_id, string sequencenumber_)
        {
            string procname = "mdl_question_attempt_steps_DS_questionattemptid_sequencenumber";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@questionattemptid", questionattempt_id);
            db.AddParameter("@sequencenumber", sequencenumber_);
            return db.ExecuteDataTable(procname);
        }

        public bool mdl_question_attempt_steps_Them(string questionattemptid_, string sequencenumber_, string state_, string timecreated_, string userid_)
        {
            try
            {
                string procname = @"INSERT INTO `mdl_question_attempt_steps`(`questionattemptid`, `sequencenumber`, `state`, `timecreated`, `userid`) VALUES (" + questionattemptid_ + "," + sequencenumber_ + ",'" + state_ + "'," + timecreated_ + "," + userid_ + ")";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction_Text(procname);
                db.CommitTransaction();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool mdl_question_attempt_steps__fraction_Them(string questionattemptid_, string sequencenumber_, string state_, string fraction_, string timecreated_, string userid_)
        {
            try
            {
                string procname = @"INSERT INTO `mdl_question_attempt_steps`(`questionattemptid`, `sequencenumber`, `state`, `fraction`, `timecreated`, `userid`) VALUES (" + questionattemptid_ + "," + sequencenumber_ + ",'" + state_ + "'," + fraction_ + "," + timecreated_ + "," + userid_ + ")";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction_Text(procname);
                db.CommitTransaction();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string mdl_question_attempt_steps_max()
        {
            string procname = @"SELECT max(id) FROM `mdl_question_attempt_steps` WHERE 1";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteData_string(procname);
        }
        public DataTable mdl_question_attempt_step_data_ds_id(string id_)
        {
            string procname = "mdl_question_attempt_step_data_ds_id";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@id", id_);
            return db.ExecuteDataTable(procname);
        }
        public bool mdl_question_attempt_step_data_Them(string attemptstepid_, string name_, string value_)
        {
            try
            {
                string procname = @"INSERT INTO `mdl_question_attempt_step_data`(`attemptstepid`, `name`, `value`) VALUES (" + attemptstepid_ + ",'" + name_ + "','" + value_ + "')";
                DbAccessMySqlOffline db = new DbAccessMySqlOffline();
                db.CreateNewSqlCommand_Text();
                db.ExecuteNonQueryWithTransaction_Text(procname);
                db.CommitTransaction();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
