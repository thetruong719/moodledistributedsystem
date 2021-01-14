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
    class cls_course
    {
        public Int64 id { get; set; }
        public string Khoi { get; set; }
        public string MonHoc { get; set; }
        public bool Hienthi { get; set; }
        public DataTable course_course_GROUP_Khoi()
        {
            string procname = "course_course_GROUP_Khoi";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            return db.ExecuteDataTable(procname);
        }
        public DataTable course_DS_MonHoc(string Khoi_)
        {
            string procname = "course_DS_MonHoc";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@Khoi", Khoi_);
            return db.ExecuteDataTable(procname);
        }
        public DataTable GiaoVien_MonHoc_DS_IDGV(int ID)
        {
            string procname = "GiaoVien_MonHoc_DS_IDGV";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@ID", ID);
            return db.ExecuteDataTable(procname);
        }
        public DataTable GiaoVien_DangNhap(string Email, string MatKhau)
        {
            string procname = "GiaoVien_DangNhap";
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            db.AddParameter("@Email", Email);
            db.AddParameter("@MatKhau", MatKhau);
            return db.ExecuteDataTable(procname);
        }   
    }
}
