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
    public partial class XtraForm_mdl_groups : DevExpress.XtraEditors.XtraForm
    {
        Class.cls_mdl_groups clg = new Class.cls_mdl_groups();
        public XtraForm_mdl_groups()
        {
            InitializeComponent();
        }

        private void btnxem_Click(object sender, EventArgs e)
        {

        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            DataTable ds_mdl_groups = new DataTable();
            DataTable ds_mdl_groups_members = new DataTable();
            ds_mdl_groups = clg.mdl_groups_DS();
            ds_mdl_groups_members = clg.mdl_groups_members_ds();
            clg.mdl_groups_delete();
            if (clg.mdl_groups_Them(ds_mdl_groups)!=true)
            {
                MessageBox.Show("Thêm mdl_groups bị lỗi");
            }
            clg.mdl_groups_members_delete();
            if(clg.mdl_groups_members_Them(ds_mdl_groups_members)!=true)
            {
                MessageBox.Show("Thêm mdl_groups_members bị lỗi");
            }
        }
    }
}