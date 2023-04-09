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

namespace Giao_diện_btl
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();

        private void Hienthi_BANG()
        {
            txtMbs.DataBindings.Clear();
            txtMbs.DataBindings.Add("Text", dataGridView_Bacsi.DataSource, "mabs");

            txtHoten.DataBindings.Clear();
            txtHoten.DataBindings.Add("Text", dataGridView_Bacsi.DataSource, "hoten");

            txtTrinhdo.DataBindings.Clear();
            txtTrinhdo.DataBindings.Add("Text", dataGridView_Bacsi.DataSource, "trinhdo");

            txtChuyenmon.DataBindings.Clear();
            txtChuyenmon.DataBindings.Add("Text", dataGridView_Bacsi.DataSource, "chuyenmon");

            txtChucvu.DataBindings.Clear();
            txtChucvu.DataBindings.Add("Text", dataGridView_Bacsi.DataSource, "chucvu");

            txtPhongkham.DataBindings.Clear();
            txtPhongkham.DataBindings.Add("Text", dataGridView_Bacsi.DataSource, "tenphongkham");
        }

        private void BANG_BACSI()
        {
            DataTable dta = new DataTable();
            dta = kn.Lay_Dulieu("select * from BACSI");
            dataGridView_Bacsi.DataSource = dta;
            Hienthi_BANG();
        }

        


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            BANG_BACSI();
        }

        private void bttNhaplai_Click(object sender, EventArgs e)
        {
            txtMbs.Text = "";
            txtHoten.Text = "";
            txtTrinhdo.Text = "";
            txtChucvu.Text = "";
            txtChuyenmon.Text = "";
            txtPhongkham.Text = "";
        }

        private void bttThem_Click(object sender, EventArgs e)
        {
            string sqlthem = "Insert Into BACSI Values('" + txtMbs.Text + "','" + txtHoten.Text + "','" + txtTrinhdo.Text + "','" + txtChuyenmon.Text + "','" + txtChucvu.Text + "','" + txtPhongkham.Text + "' )" ;
            kn.ThucThi(sqlthem);
            BANG_BACSI();
        }

        private void bttSua_Click(object sender, EventArgs e)
        {
            string sqlsua = "Update BACSI set hoten = '" + txtHoten.Text + "'";
            sqlsua = sqlsua + ",trinhdo = '" + txtTrinhdo.Text + "', chuyenmon = '" + txtChuyenmon.Text + "', chucvu = '" + txtChucvu.Text + "', tenphongkham = '" + txtPhongkham.Text + "' where mabs ='" + txtMbs.Text + "'";
            kn.ThucThi(sqlsua);
            BANG_BACSI();
        }

        private void bttXoa_Click(object sender, EventArgs e)
        {
            kn.ThucThi("DELETE BACSI where mabs = '" + txtMbs.Text + "'");
            BANG_BACSI();
        }
    }
}
