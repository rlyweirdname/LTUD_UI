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
    public partial class FrmDANGNHAP : Form
    {
        public FrmDANGNHAP()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmDANGNHAP_Load(object sender, EventArgs e)
        {

        }

        private void bttDN_Click(object sender, EventArgs e)
        {
            kn.KetNoi_Dulieu();
            try
            {
                string TK = txtTK.Text;
                string MK = txtMK.Text;
                string sql_login = "Select tendn, mk From DANGNHAP where tendn = '" + TK + "'and mk = '" + MK + "'";
                SqlCommand cmd = new SqlCommand(sql_login, kn.cnn);
                SqlDataReader datRED = cmd.ExecuteReader();
                if(datRED.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    FrmTrangchu frm1 = new FrmTrangchu();
                    frm1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hãy kiểm tra lại thông tin đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi kết nối với Cơ sở dữ liệu!");
            }
            
        }

        private void bttThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
