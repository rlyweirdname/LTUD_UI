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
    public partial class FrmDichvu : Form
    {
        public FrmDichvu()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        private void HIENTHI_DV()
        {
            txtMaDV.DataBindings.Clear();
            txtMaDV.DataBindings.Add("Text", dtaGrid_DV.DataSource, "madv");

            cboMaloaiDV.DataBindings.Clear();
            cboMaloaiDV.DataBindings.Add("Text", dtaGrid_DV.DataSource, "maloaidv");

            txtTenDV.DataBindings.Clear();
            txtTenDV.DataBindings.Add("Text", dtaGrid_DV.DataSource, "tendv");

            txtGia.DataBindings.Clear();
            txtGia.DataBindings.Add("Text", dtaGrid_DV.DataSource, "gia");

            txtDonvi.DataBindings.Clear();
            txtDonvi.DataBindings.Add("Text", dtaGrid_DV.DataSource, "donvi");

            txtGhichu.DataBindings.Clear();
            txtGhichu.DataBindings.Add("Text", dtaGrid_DV.DataSource, "ghichu");

        }

        private void BANG_DV()
        {
            DataTable dta = new DataTable();
            dta = kn.Lay_Dulieu("Select * from DICHVU");
            dtaGrid_DV.DataSource = dta;
            HIENTHI_DV();
        }

        private void CBO_Maloaidv()
        {
            DataTable dta =  kn.Lay_Dulieu("Select maloaidv from LOAIDICHVU");
            cboMaloaiDV.DataSource = dta;
            cboMaloaiDV.DisplayMember = "maloaidv";
            cboMaloaiDV.ValueMember = "maloaidv";

        }
        private void dropMenu()
        {
            panelBacSiSubMenu.Visible = false;

        }

        private void hideSubMenu()
        {
            if (panelBacSiSubMenu.Visible == true)
                panelBacSiSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false; 
        }

        private void button10_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBacSiSubMenu);
        }

        private void FrmDichvu_Load(object sender, EventArgs e)
        {
            CBO_Maloaidv();
            BANG_DV();
        }

        private void cboMaloaiDV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMaDV_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttNhaplai_Click(object sender, EventArgs e)
        {
            txtMaDV.Text = "";
            txtTenDV.Text = "";
            cboMaloaiDV.Text = "";
            txtGia.Text = "";
            txtDonvi.Text = "";
            txtGhichu.Text = "";
        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            string sqlthem = "Insert Into DICHVU Values('" + txtMaDV.Text + "','" + cboMaloaiDV.Text + "','" + txtTenDV.Text + "','" + txtGia.Text + "','" + txtDonvi.Text + "','" + txtGhichu.Text + "')";
            kn.ThucThi(sqlthem);
            BANG_DV();
        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            string sqlsua = "Update DICHVU set maloaidv = '" + cboMaloaiDV.Text + "', tendv = '" + txtTenDV.Text + "', gia = '" + txtGia.Text + "', donvi = '" + txtDonvi.Text + "', ghichu = '" + txtGhichu.Text + "' where madv = '" + txtMaDV.Text + "'";
            kn.ThucThi(sqlsua);
            BANG_DV();
        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            kn.ThucThi("Delete DICHVU where madv = '" + txtMaDV.Text + "'");
            BANG_DV();
        }
    }
}
