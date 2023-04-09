using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giao_diện_btl
{
    public partial class FrmTTBN : Form
    {
        public FrmTTBN()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        private void HIENTHI_BENHNHAN()
        {
            txtMaBN.DataBindings.Clear();
            txtMaBN.DataBindings.Add("Text", dataGrid_Benhnhan.DataSource, "mabn");

            txtHoTenBN.DataBindings.Clear();
            txtHoTenBN.DataBindings.Add("Text", dataGrid_Benhnhan.DataSource, "hoten");

            txtGioitinh.DataBindings.Clear();
            txtGioitinh.DataBindings.Add("Text", dataGrid_Benhnhan.DataSource, "gioitinh");

            txtNgaysinh.DataBindings.Clear();
            txtNgaysinh.DataBindings.Add("Text", dataGrid_Benhnhan.DataSource, "ngaysinh");

            txtDiachi.DataBindings.Clear();
            txtDiachi.DataBindings.Add("Text", dataGrid_Benhnhan.DataSource, "diachi");

            txtDoituong.DataBindings.Clear();
            txtDoituong.DataBindings.Add("Text", dataGrid_Benhnhan.DataSource, "doituong");
        }

        private void BANG_BENHNHAN()
        {
            DataTable dta = new DataTable();
            dta = kn.Lay_Dulieu("Select * from BENHNHAN");
            dataGrid_Benhnhan.DataSource = dta;
            HIENTHI_BENHNHAN();

        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            string sqlthem = "Insert Into BENHNHAN Values('" + txtMaBN.Text + "','" + txtHoTenBN.Text + "','" + txtGioitinh.Text + "','" + txtNgaysinh.Text + "','" + txtDiachi.Text + "','" + txtDoituong + "')";
            kn.ThucThi(sqlthem);
            BANG_BENHNHAN();
        }

        private void FrmTTBN_Load(object sender, EventArgs e)
        {
            BANG_BENHNHAN();
        }

        private void bttNhaplai_Click(object sender, EventArgs e)
        {
            txtMaBN.Text = "";
            txtHoTenBN.Text = "";
            txtGioitinh.Text = "";
            txtNgaysinh.Text = "";
            txtDiachi.Text = "";
            txtDoituong.Text = "";
        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            string sqlsua = "Update BENHNHAN set hoten = '" + txtHoTenBN.Text + "'";
            sqlsua = sqlsua + ", gioitinh = '" + txtGioitinh.Text + "', ngaysinh = '" + txtNgaysinh.Text + "', diachi = '" + txtDiachi.Text + "', doituong = '" + txtDoituong.Text + "' where mabn = '" + txtMaBN.Text + "'";
            kn.ThucThi(sqlsua);
            BANG_BENHNHAN();
        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            kn.ThucThi("Delete BENHNHAN where mabn = '" + txtMaBN.Text + "'");
            BANG_BENHNHAN();
        }
    }
}
