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

namespace unzipPackage.Teacherslist
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        Class.cls_course clc = new Class.cls_course();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void txtUsername_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin tài khoản!");
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin mật khẩu!");
                txtPassword.Focus();
                return;
            }
            RegistryWriter rg = new RegistryWriter();
            if (chkluutaikhoan.Checked == true)
            {
                rg.WriteKey("user_client", txtUsername.Text);
            }
            Program.Name_Courses = "moodle_offline_10";
            DataTable dsdangnhap = new DataTable();
            dsdangnhap = clc.GiaoVien_DangNhap(txtUsername.Text, txtPassword.Text);
            if(dsdangnhap.Rows.Count>0)
            {
                this.Close();
                //luu thong tin dang nhap user
                Class.App.UserLogin = txtUsername.Text;
                Class.App.Username = txtUsername.Text;
                Class.App.FullName = dsdangnhap.Rows[0]["HoTenGV"].ToString();
                Class.App.Type = dsdangnhap.Rows[0]["HoTenGV"].ToString();
                Program.ID_GV = dsdangnhap.Rows[0]["id"].ToString();
            }
            else
            {
                MessageBox.Show("Tải khoản hoặc mật khẩu không đúng.","Thông báo!");
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            RegistryWriter rg = new RegistryWriter();
            string user = rg.valuekey("user_client");
            if (user != "null" & user != "")
            {
                txtUsername.Text = user;
                txtPassword.Focus();
            }
        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Class.App.UserLogin == null)
                Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}