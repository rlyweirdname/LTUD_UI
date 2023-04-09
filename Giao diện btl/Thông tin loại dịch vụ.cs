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
    public partial class FrmLoaiDV : Form
    {
        public FrmLoaiDV()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();
        
        private void HIENTHI_LOAIDV()
        {
            txtMaLoaiDV.DataBindings.Clear();
            txtMaLoaiDV.DataBindings.Add("Text", dtaGrid_LoaiDV.DataSource, "maloaidv");

            txtTenloaiDV.DataBindings.Clear();
            txtTenloaiDV.DataBindings.Add("Text", dtaGrid_LoaiDV.DataSource, "tenloaidv");
        }

        private void BANG_LOAIDV()
        {
            DataTable dta = new DataTable();
            dta = kn.Lay_Dulieu("Select * from LOAIDICHVU");
            dtaGrid_LoaiDV.DataSource = dta;
            HIENTHI_LOAIDV();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmLoaiDV_Load(object sender, EventArgs e)
        {
            BANG_LOAIDV();
        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            string sqlthem = "Insert Into LOAIDICHVU Values('" + txtMaLoaiDV.Text + "','" + txtTenloaiDV.Text + "')";
            kn.ThucThi(sqlthem);
            BANG_LOAIDV();
        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            string sqlsua = "Update LOAIDICHVU set tenloaidv = '" + txtTenloaiDV.Text + "' where maloaidv = '" + txtMaLoaiDV.Text + "'";
            kn.ThucThi(sqlsua);
            BANG_LOAIDV();
        }

        private void bttNhaplai_Click(object sender, EventArgs e)
        {
            txtMaLoaiDV.Text = "";
            txtTenloaiDV.Text = "";
        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            string sqlxoa = "Delete LOAIDICHVU where maloaidv = '" + txtMaLoaiDV.Text + "'";
            kn.ThucThi(sqlxoa);
            BANG_LOAIDV();
        }
    }
}
