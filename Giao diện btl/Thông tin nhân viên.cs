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
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        
        KetNoi kn = new KetNoi();
        
        private void HIENTHI_NV()
        {
            txtManv.DataBindings.Clear();
            txtManv.DataBindings.Add("Text", dataGrid_NV.DataSource, "manv");

            txtHoten.DataBindings.Clear();
            txtHoten.DataBindings.Add("Text", dataGrid_NV.DataSource, "hoten");

            txtCV.DataBindings.Clear();
            txtCV.DataBindings.Add("Text", dataGrid_NV.DataSource, "chucvu");
        }

        private void BANG_NV()
        {
            DataTable dta = new DataTable();
            dta = kn.Lay_Dulieu("Select * From NHANVIEN");
            dataGrid_NV.DataSource = dta;
            HIENTHI_NV();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            BANG_NV();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtManv.Text = "";
            txtHoten.Text = "";
            txtCV.Text = "";
        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            string sqlthem = "Insert Into NHANVIEN Values('" + txtManv.Text + "','" + txtHoten.Text + "','" + txtCV.Text + "')";
            kn.ThucThi(sqlthem);
            BANG_NV();
        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            string sqlsua = "Update NHANVIEN set hoten = '" + txtHoten.Text + "', chucvu = '" + txtCV.Text + "' where manv = '" + txtManv.Text + "'";
            kn.ThucThi(sqlsua);
            BANG_NV();
        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            kn.ThucThi("Delete NHANVIEN where manv = '" + txtManv.Text + "'");
            BANG_NV();
        }
    }
}
