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
    public partial class frmSinhVien : Form
    {
        private LopHocEntities database = new LopHocEntities();
        public frmSinhVien()
        {
            InitializeComponent();
            LoadThongTinSinhVien();
        }
        private void AddSinhVienBinding()
        {
            //Refresh lại
            txtMaSV.DataBindings.Clear();
            txtTenSV.DataBindings.Clear();
            txtTuoi.DataBindings.Clear();
            txtDiaChiSV.DataBindings.Clear();
            cmbLopHoc.DataBindings.Clear();
            //Add lại binding
            txtMaSV.DataBindings.Add("Text", dgvSinhVien.DataSource, "MaSV");
            txtTenSV.DataBindings.Add("Text", dgvSinhVien.DataSource, "TenSV");
            txtTuoi.DataBindings.Add("Text", dgvSinhVien.DataSource, "Tuoi");
            txtDiaChiSV.DataBindings.Add("Text", dgvSinhVien.DataSource, "DiaChi");
            cmbLopHoc.DataBindings.Add("Text", dgvSinhVien.DataSource, "TenLop");

        }        private void LoadThongTinSinhVien()
        {
            var dsLopHoc = from sv in database.SINHVIENs
                           select new
                           {
                               MaSV = sv.MASV,
                               TenSV = sv.TENSV,
                               DiaChi =
                          sv.DIACHI,
                               Tuoi = sv.TUOI,
                               TenLop = sv.LOPHOC.TENLOP
                           };
            dgvSinhVien.DataSource = dsLopHoc.ToList();
            cmbLopHoc.DataSource = database.LOPHOCs.ToList();
            cmbLopHoc.DisplayMember = "TenLop";
            //Add binding
            AddSinhVienBinding();
        }
        private void btnThemSV_Click(object sender, EventArgs e)
        {
            string MaSV = txtMaSV.Text;
            string TenSV = txtTenSV.Text;
            string TuoiSV = txtTuoi.Text;
            string DiaChi = txtDiaChiSV.Text;
            LOPHOC lop = cmbLopHoc.SelectedValue as LOPHOC;
            //Da xuat hien trong CSDL
            SINHVIEN sv = database.SINHVIENs.Where(s => s.MASV ==
           MaSV).SingleOrDefault();
            if (sv != null)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại");
                return;
            }
            else if (String.IsNullOrEmpty(MaSV) || String.IsNullOrEmpty(MaSV))
            {
                MessageBox.Show("Mã sinh viên hoặc Tên sinh viên không được để trống");
            return;
            }
            else
            {
                SINHVIEN sinhvien = new SINHVIEN();
                sinhvien.MASV = MaSV;
                sinhvien.TENSV = TenSV;
                sinhvien.DIACHI = DiaChi;
                sinhvien.TUOI = Convert.ToInt32(TuoiSV);
                sinhvien.LOPHOC = lop;
                database.SINHVIENs.Add(sinhvien);
                database.SaveChanges();
                LoadThongTinSinhVien();
                MessageBox.Show("Thêm mới sinh viên thành công");
            }
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lopHocDataSet.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Fill(this.lopHocDataSet.SINHVIEN);

        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            string MaSV = txtMaSV.Text;
            //Da xuat hien trong CSDL
            SINHVIEN sv = database.SINHVIENs.Where(s => s.MASV ==
           MaSV).SingleOrDefault();
            if (sv == null)
            {
                MessageBox.Show("Mã sinh viên không tồn tại");
                return;
            }
            else if (String.IsNullOrEmpty(MaSV))
            {
                MessageBox.Show("Mã sinh viên cần xóa không được để trống");
                return;
            }
            else
            {
                database.SINHVIENs.Remove(sv);
                database.SaveChanges();
                LoadThongTinSinhVien();
                MessageBox.Show("Xóa sinh viên thành công");
            }
        }
    }
}
