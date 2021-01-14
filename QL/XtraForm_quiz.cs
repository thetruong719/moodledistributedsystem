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
    public partial class XtraForm_quiz : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm_quiz()
        {
            InitializeComponent();
        }
        Class.cls_mdl_quiz clq = new Class.cls_mdl_quiz();
        Class.clsnopdiem clsnd = new Class.clsnopdiem();
        private void btnxem_Click(object sender, EventArgs e)
        {
            gribang.DataSource = clq.mdl_quiz_DS();
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            DataTable ds_quiz_moodle = new DataTable();
            ds_quiz_moodle = clq.mdl_quiz_DS_moodle();
            clq.mdl_quiz_Delete();
            clq.mdl_quiz_them(ds_quiz_moodle);
        }

        private void XtraForm_quiz_Load(object sender, EventArgs e)
        {

        }
    }
}