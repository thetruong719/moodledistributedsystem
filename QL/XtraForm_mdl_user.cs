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
    public partial class XtraForm_mdl_user : DevExpress.XtraEditors.XtraForm
    {
        Class.cls_mdl_user clu = new Class.cls_mdl_user();
        public XtraForm_mdl_user()
        {
            InitializeComponent();
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            DataTable ds = new DataTable();
            ds = clu.mdl_user_DS();
            gribang.DataSource = ds;
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            clu.mdl_user_Delete();
            DataTable ds = clu.mdl_user_DS_moodle();
            if (clu.mdl_user_Them(ds) != true) 
            {
                MessageBox.Show("Lỗi");
            }
        }
    }
}