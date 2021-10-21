using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapNhom_QLBH
{
    public partial class FrmNhanVien1 : Form
    {
        public FrmNhanVien1()
        {
            InitializeComponent();
        }
        ConnectDB connectDB = new ConnectDB();

        DataTable dta = new DataTable();

        private void BANG_NHANVIEN()
        {
            dta = connectDB.Lay_DulieuBang("SELECT * FROM nhanVien");
            DataGrid_NhanVien1.DataSource = dta;
        }
       

        private void HienThiDuLieu()
        {
            BANG_NHANVIEN();
            DataGrid_NhanVien1.Columns[0].HeaderText = "Mã Nhân Viên";
            DataGrid_NhanVien1.Columns[1].HeaderText = "Họ Tên Nhân Viên";
            DataGrid_NhanVien1.Columns[2].HeaderText = "Giới tính";
            DataGrid_NhanVien1.Columns[3].HeaderText = "Ngày sinh";
            DataGrid_NhanVien1.Columns[4].HeaderText = "Địa chỉ";
            DataGrid_NhanVien1.Columns[5].HeaderText = "Số điện thoại";
            DataGrid_NhanVien1.Columns[6].HeaderText = "Email";
            DataGrid_NhanVien1.Columns[0].Width = 150;
            DataGrid_NhanVien1.Columns[1].Width = 200;
            DataGrid_NhanVien1.Columns[2].Width = 80;
            DataGrid_NhanVien1.Columns[3].Width = 80;
            DataGrid_NhanVien1.Columns[4].Width = 250;
            DataGrid_NhanVien1.Columns[5].Width = 100;
            DataGrid_NhanVien1.Columns[6].Width = 250;
            DataGrid_NhanVien1.AllowUserToAddRows = false;
            DataGrid_NhanVien1.EditMode = DataGridViewEditMode.EditProgrammatically;
            /*txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", DataGrid_NhanVien1, "manv");

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", DataGrid_NhanVien1, "tennv");

            txtGioiTinh.DataBindings.Clear();
            txtGioiTinh.DataBindings.Add("Text", DataGrid_NhanVien1, "gioitinh");

            txtNgaySinh.DataBindings.Clear();
            txtNgaySinh.DataBindings.Add("Text", DataGrid_NhanVien1, "ngaysinh");

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", DataGrid_NhanVien1, "diachi");

            txtSdt.DataBindings.Clear();
            txtSdt.DataBindings.Add("Text", DataGrid_NhanVien1, "sdt");

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", DataGrid_NhanVien1, "email");*/
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql_them;
            sql_them = " INSERT INTO nhanVien VALUES ('" + txtMaNV.Text + "', '" + txtTenNV.Text + "', '" + txtGioiTinh.Text + "', '" + txtNgaySinh.Text + "','" + txtDiaChi.Text + "', '" + txtSdt.Text + "', '" + txtEmail.Text + "')";
            connectDB.ThucThi(sql_them);
            BANG_NHANVIEN();
        }

        private void FrmNhanVien1_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql_Sua;
            sql_Sua = "UPDATE nhanVien SET tennv =  '" + txtTenNV.Text + "', gioitinh = '" + txtGioiTinh.Text + "', ngaysinh =  '" + txtNgaySinh.Text + "', diachi =  '" + txtDiaChi.Text + "', sdt =  '" + txtSdt.Text + "', email =  '" + txtEmail.Text + "' WHERE manv = '" + txtMaNV.Text + "'";
            connectDB.ThucThi(sql_Sua);
            BANG_NHANVIEN();
        }

        private void DataGrid_NhanVien1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HienThiDuLieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql_Xoa;
            sql_Xoa = " DELETE nhanVien WHERE manv = '" + txtMaNV.Text + "' ";
            connectDB.ThucThi(sql_Xoa);
            BANG_NHANVIEN();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
