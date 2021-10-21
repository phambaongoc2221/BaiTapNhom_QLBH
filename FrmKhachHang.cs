using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BaiTapNhom_QLBH
{
    public partial class FrmKhachHang : Form
    {
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        ConnectDB connectDB = new ConnectDB();

        DataTable dta = new DataTable();

        private void BANG_KHACHHANG()
        {
            dta = connectDB.Lay_DulieuBang("SELECT * FROM khachHang");
            DataGrid_KhachHang.DataSource = dta;
        }

        private void HienThiDuLieu()
        {
            BANG_KHACHHANG();
            DataGrid_KhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            DataGrid_KhachHang.Columns[1].HeaderText = "Họ Tên Khách Hàng";
            DataGrid_KhachHang.Columns[2].HeaderText = "Số điện thoại";
            DataGrid_KhachHang.Columns[3].HeaderText = "Địa chỉ";
            DataGrid_KhachHang.Columns[0].Width = 200;
            DataGrid_KhachHang.Columns[1].Width = 250;
            DataGrid_KhachHang.Columns[2].Width = 250;
            DataGrid_KhachHang.Columns[3].Width = 350;
            DataGrid_KhachHang.AllowUserToAddRows = false;
            DataGrid_KhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
            /*txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", DataGrid_KhachHang, "makh");

            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", DataGrid_KhachHang, "tenkh");

            txtSdt.DataBindings.Clear();
            txtSdt.DataBindings.Add("Text", DataGrid_KhachHang, "sdt");

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", DataGrid_KhachHang, "diachi");*/
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql_them;
            sql_them = " INSERT INTO khachHang VALUES ('" + txtMaKH.Text + "', '" + txtTenKH.Text + "', '" + txtSdt.Text + "', '" + txtDiaChi.Text + "')";
            connectDB.ThucThi(sql_them);
            BANG_KHACHHANG();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql_Sua;
            sql_Sua = "UPDATE khachHang SET tenkh =  '" + txtTenKH.Text + "', sdt = '" + txtSdt.Text + "', diachi =  '" + txtDiaChi.Text + "' WHERE makh = '" + txtMaKH.Text + "'";
            connectDB.ThucThi(sql_Sua);
            BANG_KHACHHANG();
        }

        private void DataGrid_KhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HienThiDuLieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql_Xoa;
            sql_Xoa = " DELETE khachHang WHERE makh = '" + txtMaKH.Text + "' ";
            connectDB.ThucThi(sql_Xoa);
            BANG_KHACHHANG();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
