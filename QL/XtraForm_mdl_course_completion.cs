using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace unzipPackage.QL
{
    public partial class XtraForm_mdl_course_completion : DevExpress.XtraEditors.XtraForm
    {
        Class.cls_course clc = new Class.cls_course();
        Class.cls_mdl_quiz_grades clq = new Class.cls_mdl_quiz_grades();
        public XtraForm_mdl_course_completion()
        {
            InitializeComponent();
        }

        DataTable dscourse_course_GROUP_Khoi = new DataTable();
        DataTable dscourse_course_monhoc = new DataTable();
        private void XtraForm_mdl_course_completion_Load(object sender, EventArgs e)
        {
            khoi();
        }
        void khoi()
        {
            Program.Name_Courses = "moodle_offline_10";
            dscourse_course_GROUP_Khoi = clc.course_course_GROUP_Khoi();
            grikhoi.EditValue = null;
            grikhoi.Properties.DisplayMember = "Khoi";
            grikhoi.Properties.ValueMember = "Khoi";
            grikhoi.Properties.PopupFormSize = new Size(120, 90);
            grikhoi.Properties.DataSource = dscourse_course_GROUP_Khoi;
            if (dscourse_course_GROUP_Khoi.Rows.Count > 0)
                grikhoi.EditValue = dscourse_course_GROUP_Khoi.Rows[0]["Khoi"].ToString();
        }
        void monhoc(string monhoc)
        {
            Program.Name_Courses = "moodle_offline_10";
            dscourse_course_monhoc = clc.course_DS_MonHoc(monhoc);
            grimonhoc.EditValue = null;
            grimonhoc.Properties.DisplayMember = "MonHoc";
            grimonhoc.Properties.ValueMember = "MonHoc";
            grimonhoc.Properties.PopupFormSize = new Size(120, 90);
            grimonhoc.Properties.DataSource = dscourse_course_monhoc;
            if (dscourse_course_monhoc.Rows.Count > 0)
                grimonhoc.EditValue = dscourse_course_monhoc.Rows[0]["MonHoc"].ToString();
        }

        private void grikhoi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                monhoc(grikhoi.EditValue.ToString());
            }
            catch
            { }
        }

        private void btnxemdiem_Click(object sender, EventArgs e)
        {

        }
    }
}