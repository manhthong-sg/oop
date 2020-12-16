using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLLopHoc.DAL;

namespace QLLopHoc
{
    public partial class frmLopHoc : Form
    {
        private LopHocEntities database = new LopHocEntities();

        public frmLopHoc()
        {
            InitializeComponent();
            LoadThongTinLop();
            ChangeGridViewHeaderName();        }
        private void ChangeGridViewHeaderName()
        {
            dgvLopHoc.Columns[0].HeaderText = "Mã Lớp";
            dgvLopHoc.Columns[1].HeaderText = "Tên Lớp";
        }        private void AddLopHocBinding()
        {
            //Refresh lại
            txtMaLop.DataBindings.Clear();
            txtTenLop.DataBindings.Clear();
            //Add lại binding
            txtMaLop.DataBindings.Add("Text", dgvLopHoc.DataSource, "MaLop");
            txtTenLop.DataBindings.Add("Text", dgvLopHoc.DataSource, "TenLop");
        }        private void LoadThongTinLop()
        {
            var dsLopHoc = from lop in database.LOPHOCs
                           select new { MaLop = lop.MALOP, TenLop = lop.TENLOP };
            dgvLopHoc.DataSource = dsLopHoc.ToList();
            //Add binding
            AddLopHocBinding();
        }


        private void frmLopHoc_Load(object sender, EventArgs e)
        {

        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            string MaLop = txtMaLop.Text;
            string TenLop = txtTenLop.Text;
            //Da xuat hien trong CSDL
            LOPHOC lop = database.LOPHOCs.Where(l => l.MALOP ==
           MaLop).SingleOrDefault();
            if (lop != null)
            {
                MessageBox.Show("Mã lớp học đã tồn tại");
                return;
            }
            else if (String.IsNullOrEmpty(MaLop) || String.IsNullOrEmpty(TenLop))
            {
                MessageBox.Show("Mã lớp hoặc Tên lớp không được để trống");
                return;
            }
            else
            {
                lop = new LOPHOC();
                lop.MALOP = MaLop;
                lop.TENLOP = TenLop;
                database.LOPHOCs.Add(lop);
                database.SaveChanges();
                LoadThongTinLop();
                MessageBox.Show("Thêm mới lớp học thành công");
            }

        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            string MaLop = txtMaLop.Text;
            string TenLop = txtTenLop.Text;
            //Da xuat hien trong CSDL
            LOPHOC lop = database.LOPHOCs.Where(l => l.MALOP ==
           MaLop).SingleOrDefault();
            if (lop == null)
            {
                MessageBox.Show("Mã lớp học không tồn tại");
                return;
            }
            else if (String.IsNullOrEmpty(MaLop))
            {
                MessageBox.Show("Mã lớp cần xóa không được để trống");
                return;
            }
            else
            {
                if (lop.SINHVIENs.Count > 0)
                {
                    MessageBox.Show("Hãy xóa sinh viên trong lớp trước");
                    return;
                }
                database.LOPHOCs.Remove(lop);
                database.SaveChanges();
                LoadThongTinLop();
                MessageBox.Show("Xóa lớp học thành công");
            }
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            string MaLop = txtMaLop.Text;
            string TenLop = txtTenLop.Text;
            //Da xuat hien trong CSDL
            LOPHOC lop = database.LOPHOCs.Where(l => l.MALOP ==
           MaLop).SingleOrDefault();
            if (lop == null)
            {
                MessageBox.Show("Mã lớp học không tồn tại");
                return;
            }
            else if (String.IsNullOrEmpty(MaLop))
            {
                MessageBox.Show("Mã lớp cần sửa không được để trống");
                return;
            }
            else
            {
                lop.TENLOP = TenLop;
                database.SaveChanges();
                LoadThongTinLop();
                MessageBox.Show("Cập nhật thông tin lớp học thành công");
            }
            }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSinhVien formSV = new frmSinhVien();
            formSV.ShowDialog();
            formSV = null;
            this.Show();
        }
    }
}
