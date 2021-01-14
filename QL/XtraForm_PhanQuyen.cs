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
    public partial class XtraForm_PhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        Class.cls_PQuyen clpq = new Class.cls_PQuyen();
        public XtraForm_PhanQuyen()
        {
            InitializeComponent();
        }

        private void XtraForm_PhanQuyen_Load(object sender, EventArgs e)
        {

        }
    }
}