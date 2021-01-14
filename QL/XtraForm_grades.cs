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
using System.IO;
using System.ComponentModel.Design;
using System.Drawing.Design;
using DevExpress.Data;
using DevExpress.Data.Utils;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Colors;
using DevExpress.Utils.Controls;
using DevExpress.Utils.Design;
using DevExpress.Utils.Editors;
using DevExpress.Utils.Serializing;
using DevExpress.XtraEditors.Design;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace unzipPackage.QL
{
    public partial class XtraForm_grades : DevExpress.XtraEditors.XtraForm
    {
        Class.cls_course clc = new Class.cls_course();
        Class.cls_mdl_quiz_grades clq = new Class.cls_mdl_quiz_grades();
        public XtraForm_grades()
        {
            InitializeComponent();
        }
        DataTable dscourse_course_GROUP_Khoi = new DataTable();
        DataTable dscourse_course_monhoc = new DataTable();
        private void XtraForm_grades_Load(object sender, EventArgs e)
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
            splacapnhat.ShowWaitForm();
            Program.Name_Courses = grimonhoc.EditValue.ToString();
            grichon.Columns.Clear();
            DataTable dscot = new DataTable();
            DataTable mdl_quiz_Diem = new DataTable();
            mdl_quiz_Diem = clq.mdl_quiz_Diem();
            mdl_quiz_Diem.Columns.Add("Color");
            mdl_quiz_Diem.Columns.Add("TongDiem");
            dscot = clq.mdl_quiz_DScot();
            KhoitaoCotDong(dscot);
            gribang.DataSource = mdl_quiz_Diem;
            for (int i = 0; i < mdl_quiz_Diem.Rows.Count; i++)
            {
                int t;
                t = (i + 1) % 2;
                mdl_quiz_Diem.Rows[i]["Color"] = t;
                float TongDiem = 0;
                for (int j = 4; j < mdl_quiz_Diem.Columns.Count - 2; j++)
                {
                    if (mdl_quiz_Diem.Rows[i][j].ToString() != "")
                    {
                        string diem = mdl_quiz_Diem.Rows[i][j].ToString();
                        TongDiem = TongDiem + float.Parse(diem);
                    }
                }
                mdl_quiz_Diem.Rows[i]["TongDiem"] = TongDiem.ToString();
            }
            splacapnhat.CloseWaitForm();
        }
        void KhoitaoCotDong( DataTable dscot)
        {
            grichon.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Caption = "Userid",
                Name = "userid",
                FieldName = "userid",
                VisibleIndex = grichon.Columns.Count,
                Width = 60,
                UnboundType = DevExpress.Data.UnboundColumnType.Bound,
                MinWidth = 50
            });
            grichon.Columns["userid"].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count,  "userid", "{0}")});
            grichon.Columns["userid"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grichon.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Caption = "User Name",
                Name = "username",
                FieldName = "username",
                VisibleIndex = grichon.Columns.Count,
                Width = 140,
                UnboundType = DevExpress.Data.UnboundColumnType.Bound,
                MinWidth = 50
            });
            grichon.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Caption = "Họ tên",
                Name = "HoTen",
                FieldName = "HoTen",
                VisibleIndex = grichon.Columns.Count,
                Width = 200,
                UnboundType = DevExpress.Data.UnboundColumnType.Bound,
                MinWidth = 50
            });
            grichon.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Caption = "Lớp",
                Name = "Lop",
                FieldName = "Lop",
                VisibleIndex = grichon.Columns.Count,
                Width = 100,
                UnboundType = DevExpress.Data.UnboundColumnType.Bound,
                MinWidth = 50
            });
            if (dscot != null)
            {
                bool ktCot = false;
                for (int i = 0; i < dscot.Rows.Count; i++)
                {
                    ktCot = false;
                    for (int c = 0; c < grichon.Columns.Count; c++)
                    {
                        if (grichon.Columns[c].Caption.ToString() == dscot.Rows[i]["name"].ToString())
                        {
                            ktCot = true;
                            break;
                        }
                    }
                    if (!ktCot)
                    {
                        grichon.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
                        {
                            Caption = dscot.Rows[i]["name"].ToString(),
                            Name = "col" + dscot.Rows[i]["name"].ToString(),
                            FieldName= dscot.Rows[i]["name"].ToString(),
                            VisibleIndex = grichon.Columns.Count,
                            Width = 70,
                            UnboundType = DevExpress.Data.UnboundColumnType.Bound,
                            MinWidth = 50,
                        });
                        grichon.Columns[dscot.Rows[i]["name"].ToString()].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, dscot.Rows[i]["name"].ToString(), "{0}")});
                        grichon.Columns[dscot.Rows[i]["name"].ToString()].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        grichon.Columns[dscot.Rows[i]["name"].ToString()].Tag = "autoColumn";
                    }
                }
            }
            grichon.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            {
                Caption = "Tổng điểm",
                Name = "TongDiem",
                FieldName = "TongDiem",
                VisibleIndex = grichon.Columns.Count,
                Width = 70,
                UnboundType = DevExpress.Data.UnboundColumnType.Bound,
                MinWidth = 50
            });
            grichon.Columns["TongDiem"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void mnxuatexcle_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gribang.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gribang.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gribang.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gribang.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gribang.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gribang.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }
                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void grichon_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
        }
    }
}