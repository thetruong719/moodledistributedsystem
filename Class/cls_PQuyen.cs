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
    class cls_PQuyen
    {
        public DataTable mdl_course_ds_summaryformat(string summaryformat)
        {
            string procname = "mdl_course_ds_summaryformat";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@summaryformat" + "", summaryformat);
            return db.ExecuteDataTable(procname);
        }
    }
}
