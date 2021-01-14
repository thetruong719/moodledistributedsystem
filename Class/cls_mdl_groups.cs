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
    class cls_mdl_groups
    {
        public Int64 id { get; set; }

        public Int64 courseid { get; set; }

        public string idnumber { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int descriptionformat { get; set; }

        public string enrolmentkey { get; set; }

        public int picture { get; set; }

        public bool hidepicture { get; set; }

        public Int64 timecreated { get; set; }

        public Int64 timemodified { get; set; }
        //-------------------
        //public Int64 id { get; set; }
        public Int64 groupid { get; set; }
        public Int64 userid { get; set; }
        public Int64 timeadded { get; set; }
        public string component { get; set; }
        public Int64 itemid { get; set; }
        //--------------------------
        public DataTable mdl_groups_DS()
        {
            string procname = @"SELECT * FROM `mdl_groups`";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_groups_members_ds()
        {
            string procname = @"SELECT * FROM `mdl_groups_members`";
            DbAccessMySqlOffline db = new DbAccessMySqlOffline();
            db.CreateNewSqlCommand_Text();
            return db.ExecuteDataTable(procname);
        }
        public bool mdl_groups_Them(DataTable ds_mdl_groups)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                for (int i = 0; i < ds_mdl_groups.Rows.Count; i++)
                {

                    id = Int64.Parse(ds_mdl_groups.Rows[i]["id"].ToString());
                    courseid = Int64.Parse(ds_mdl_groups.Rows[i]["courseid"].ToString());
                    idnumber = (ds_mdl_groups.Rows[i]["idnumber"].ToString());
                    name = (ds_mdl_groups.Rows[i]["name"].ToString());
                    description = (ds_mdl_groups.Rows[i]["description"].ToString());
                    descriptionformat = int.Parse(ds_mdl_groups.Rows[i]["descriptionformat"].ToString());
                    enrolmentkey = (ds_mdl_groups.Rows[i]["enrolmentkey"].ToString());
                    picture = int.Parse(ds_mdl_groups.Rows[i]["picture"].ToString());
                    hidepicture = bool.Parse(ds_mdl_groups.Rows[i]["hidepicture"].ToString());
                    timecreated = Int64.Parse(ds_mdl_groups.Rows[i]["timecreated"].ToString());
                    timemodified = Int64.Parse(ds_mdl_groups.Rows[i]["timemodified"].ToString());

                    db.CreateNewSqlCommand();
                    db.AddParameter("@id", id);
                    db.AddParameter("@courseid", courseid);
                    db.AddParameter("@idnumber", idnumber);
                    db.AddParameter("@name", name);
                    db.AddParameter("@description", description);
                    db.AddParameter("@descriptionformat", descriptionformat);
                    db.AddParameter("@enrolmentkey", enrolmentkey);
                    db.AddParameter("@picture", picture);
                    db.AddParameter("@hidepicture", hidepicture);
                    db.AddParameter("@timecreated", timecreated);
                    db.AddParameter("@timemodified", timemodified);
                    db.ExecuteNonQueryWithTransaction("mdl_groups_Them");
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
        public DataTable mdl_groups_delete()
        {
            string procname = "mdl_groups_delete";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable mdl_groups_members_delete()
        {
            string procname = "mdl_groups_members_delete";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public bool mdl_groups_members_Them(DataTable ds_mdl_groups_members)
        {
            DbAccess db = new DbAccess();
            db.BeginTransaction();
            try
            {
                for (int i = 0; i < ds_mdl_groups_members.Rows.Count; i++)
                {

                    id = Int64.Parse(ds_mdl_groups_members.Rows[i]["id"].ToString());
                    groupid = Int64.Parse(ds_mdl_groups_members.Rows[i]["groupid"].ToString());
                    userid = Int64.Parse(ds_mdl_groups_members.Rows[i]["userid"].ToString());
                    timeadded = Int64.Parse(ds_mdl_groups_members.Rows[i]["timeadded"].ToString());
                    component = (ds_mdl_groups_members.Rows[i]["component"].ToString());
                    itemid = Int64.Parse(ds_mdl_groups_members.Rows[i]["itemid"].ToString());

                    db.CreateNewSqlCommand();
                    db.AddParameter("@id", id);
                    db.AddParameter("@groupid", groupid);
                    db.AddParameter("@userid", userid);
                    db.AddParameter("@timeadded", timeadded);
                    db.AddParameter("@component", component);
                    db.AddParameter("@itemid", itemid);
                    db.ExecuteNonQueryWithTransaction("mdl_groups_members_Them");
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
