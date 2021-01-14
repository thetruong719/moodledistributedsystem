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
    class cls_mdl_quiz
    {
        public float id { get; set; }
        public float course { get; set; }
        public string name { get; set; }
        public string intro { get; set; }
        public float introformat { get; set; }
        public float timeopen { get; set; }
        public float timeclose { get; set; }
        public float timelimit { get; set; }
        public string overduehandling { get; set; }
        public float graceperiod { get; set; }
        public string preferredbehaviour { get; set; }
        public float canredoquestions { get; set; }
        public int attempts { get; set; }
        public float attemptonlast { get; set; }
        public float grademethod { get; set; }
        public float decimalpoints { get; set; }
        public float questiondecimalpoints { get; set; }
        public int reviewattempt { get; set; }
        public int reviewcorrectness { get; set; }
        public int reviewmarks { get; set; }
        public int reviewspecificfeedback { get; set; }
        public int reviewgeneralfeedback { get; set; }
        public int reviewrightanswer { get; set; }
        public int reviewoverallfeedback { get; set; }
        public float questionsperpage { get; set; }
        public string navmethod { get; set; }
        public string shuffleanswers { get; set; }
        public float sumgrades { get; set; }
        public float grade { get; set; }
        public float timecreated { get; set; }
        public float timemodified { get; set; }
        public string password { get; set; }
        public string subnet { get; set; }
        public string browsersecurity { get; set; }
        public float delay1 { get; set; }
        public float delay2 { get; set; }
        public float showuserpicture { get; set; }
        public float showblocks { get; set; }
        public bool completionattemptsexhausted { get; set; }
        public bool completionpass { get; set; }
        public bool allowofflineattempts { get; set; }

        public bool mdl_quiz_them(DataTable dsquiz)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                for (int i = 0; i < dsquiz.Rows.Count; i++)
                {

                    db.CreateNewSqlCommand();
                    id = float.Parse(dsquiz.Rows[i]["id"].ToString());
                    course = float.Parse(dsquiz.Rows[i]["course"].ToString());
                    name = dsquiz.Rows[i]["name"].ToString();
                    intro = dsquiz.Rows[i]["intro"].ToString();
                    introformat = float.Parse(dsquiz.Rows[i]["introformat"].ToString());
                    timeopen = float.Parse(dsquiz.Rows[i]["timeopen"].ToString());
                    timeclose = float.Parse(dsquiz.Rows[i]["timeclose"].ToString());
                    timelimit = float.Parse(dsquiz.Rows[i]["timelimit"].ToString());
                    overduehandling = dsquiz.Rows[i]["overduehandling"].ToString();
                    graceperiod = float.Parse(dsquiz.Rows[i]["graceperiod"].ToString());
                    preferredbehaviour = dsquiz.Rows[i]["preferredbehaviour"].ToString();
                    canredoquestions = float.Parse(dsquiz.Rows[i]["canredoquestions"].ToString());
                    attempts = int.Parse(dsquiz.Rows[i]["attempts"].ToString());
                    attemptonlast = float.Parse(dsquiz.Rows[i]["attemptonlast"].ToString());
                    grademethod = float.Parse(dsquiz.Rows[i]["grademethod"].ToString());
                    decimalpoints = float.Parse(dsquiz.Rows[i]["decimalpoints"].ToString());
                    questiondecimalpoints = float.Parse(dsquiz.Rows[i]["questiondecimalpoints"].ToString());
                    reviewattempt = int.Parse(dsquiz.Rows[i]["reviewattempt"].ToString());
                    reviewcorrectness = int.Parse(dsquiz.Rows[i]["reviewcorrectness"].ToString());
                    reviewmarks = int.Parse(dsquiz.Rows[i]["reviewmarks"].ToString());
                    reviewspecificfeedback = int.Parse(dsquiz.Rows[i]["reviewspecificfeedback"].ToString());
                    reviewgeneralfeedback = int.Parse(dsquiz.Rows[i]["reviewgeneralfeedback"].ToString());
                    reviewrightanswer = int.Parse(dsquiz.Rows[i]["reviewrightanswer"].ToString());
                    reviewoverallfeedback = int.Parse(dsquiz.Rows[i]["reviewoverallfeedback"].ToString());
                    questionsperpage = float.Parse(dsquiz.Rows[i]["questionsperpage"].ToString());
                    navmethod = dsquiz.Rows[i]["navmethod"].ToString();
                    shuffleanswers = dsquiz.Rows[i]["shuffleanswers"].ToString();
                    sumgrades = float.Parse(dsquiz.Rows[i]["sumgrades"].ToString());
                    grade = float.Parse(dsquiz.Rows[i]["grade"].ToString());
                    timecreated = float.Parse(dsquiz.Rows[i]["timecreated"].ToString());
                    timemodified = float.Parse(dsquiz.Rows[i]["timemodified"].ToString());
                    password = dsquiz.Rows[i]["password"].ToString();
                    subnet = dsquiz.Rows[i]["subnet"].ToString();
                    browsersecurity = dsquiz.Rows[i]["browsersecurity"].ToString();
                    delay1 = float.Parse(dsquiz.Rows[i]["delay1"].ToString());
                    delay2 = float.Parse(dsquiz.Rows[i]["delay2"].ToString());
                    showuserpicture = float.Parse(dsquiz.Rows[i]["showuserpicture"].ToString());
                    showblocks = float.Parse(dsquiz.Rows[i]["showblocks"].ToString());
                    completionattemptsexhausted = bool.Parse(dsquiz.Rows[i]["completionattemptsexhausted"].ToString());
                    completionpass = bool.Parse(dsquiz.Rows[i]["completionpass"].ToString());
                    allowofflineattempts = bool.Parse(dsquiz.Rows[i]["allowofflineattempts"].ToString());

                    db.AddParameter("@id", id);
                    db.AddParameter("@course", course);
                    db.AddParameter("@name", name);
                    db.AddParameter("@intro", intro);
                    db.AddParameter("@introformat", introformat);
                    db.AddParameter("@timeopen", timeopen);
                    db.AddParameter("@timeclose", timeclose);
                    db.AddParameter("@timelimit", timelimit);
                    db.AddParameter("@overduehandling", overduehandling);
                    db.AddParameter("@graceperiod", graceperiod);
                    db.AddParameter("@preferredbehaviour", preferredbehaviour);
                    db.AddParameter("@canredoquestions", canredoquestions);
                    db.AddParameter("@attempts", attempts);
                    db.AddParameter("@attemptonlast", attemptonlast);
                    db.AddParameter("@grademethod", grademethod);
                    db.AddParameter("@decimalpoints", decimalpoints);
                    db.AddParameter("@questiondecimalpoints", questiondecimalpoints);
                    db.AddParameter("@reviewattempt", reviewattempt);
                    db.AddParameter("@reviewcorrectness", reviewcorrectness);
                    db.AddParameter("@reviewmarks", reviewmarks);
                    db.AddParameter("@reviewspecificfeedback", reviewspecificfeedback);
                    db.AddParameter("@reviewgeneralfeedback", reviewgeneralfeedback);
                    db.AddParameter("@reviewrightanswer", reviewrightanswer);
                    db.AddParameter("@reviewoverallfeedback", reviewoverallfeedback);
                    db.AddParameter("@questionsperpage", questionsperpage);
                    db.AddParameter("@navmethod", navmethod);
                    db.AddParameter("@shuffleanswers", shuffleanswers);
                    db.AddParameter("@sumgrades", sumgrades);
                    db.AddParameter("@grade", grade);
                    db.AddParameter("@timecreated", timecreated);
                    db.AddParameter("@timemodified", timemodified);
                    db.AddParameter("@password", password);
                    db.AddParameter("@subnet", subnet);
                    db.AddParameter("@browsersecurity", browsersecurity);
                    db.AddParameter("@delay1", delay1);
                    db.AddParameter("@delay2", delay2);
                    db.AddParameter("@showuserpicture", showuserpicture);
                    db.AddParameter("@showblocks", showblocks);
                    db.AddParameter("@completionattemptsexhausted", completionattemptsexhausted);
                    db.AddParameter("@completionpass", completionpass);
                    db.AddParameter("@allowofflineattempts", allowofflineattempts);
                    db.ExecuteNonQueryWithTransaction("mdl_quiz_them");
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

        public DataTable mdl_quiz_Delete()
        {
            string procname = "mdl_quiz_Delete";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_quiz_DS()
        {
            string procname = "mdl_quiz_DS";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_quiz_DS_moodle()
        {
            string procname = @"SELECT * FROM `mdl_quiz`";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
    }
}
