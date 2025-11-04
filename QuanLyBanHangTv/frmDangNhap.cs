
using QuanLyBanHangTv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangTV
{
    public partial class frmDangNhap : Form
    {
        public static string TenTaiKhoan { get; set; } // Biến static để lưu tên người dùng

        public event EventHandler<LoginEventArgs> LoginSuccess;

        public class LoginEventArgs : EventArgs
        {
            public string TenTaiKhoan { get; set; }
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\DoAn .Net\QuanLyBanHangTv\QuanLyBanHangTv\QuanLyBanTv.mdf"";Integrated Security=True");
   


       
        private string TenTK(string tentk)
        {
            string tenTaiKhoan = "";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\DoAn .Net\QuanLyBanHangTv\QuanLyBanHangTv\QuanLyBanTv.mdf"";Integrated Security=True");
            con.Open();
            string query = "SELECT TenTaiKhoan FROM TaiKhoan WHERE TenTaiKhoan = @username";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@username", tentk);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    tenTaiKhoan = reader["TenTaiKhoan"].ToString();
                }
                reader.Close();
            }
            return tenTaiKhoan;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\DoAn .Net\QuanLyBanHangTv\QuanLyBanHangTv\QuanLyBanTv.mdf"";Integrated Security=True");
            con.Open();
            string tk = txtTK.Text;
            string mk = txtMK.Text;


            string sql = "SELECT * FROM TaiKhoan WHERE TenTaiKhoan = '" + tk + "' AND MatKhau = '" + mk + "'";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read())
            {
                TenTaiKhoan = TenTK(tk);
                LoginSuccess?.Invoke(this, new LoginEventArgs { TenTaiKhoan = TenTaiKhoan });
                MessageBox.Show("Đăng nhập thành công");
                frmMain f = new frmMain();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public frmDangNhap()
        {
            InitializeComponent();
            
        }
        
        /*private void btnDangNhap_Click(object sender, EventArgs e)
        {
            String TenTK = txtTK.Text;
            String MatKhau = txtMK.Text;
            
            if (TenTK.Trim() == "") { MessageBox.Show("Vui nhập tên tài khoản!"); }
            else if (MatKhau.Trim() == "") { MessageBox.Show("Vui nhập mật khẩu!"); }
            else
            {
                string query = "Select * from TaiKhoan where TenTaiKhoan = '" + TenTK + "' and MatKhau = '" + MatKhau + "'";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    frmMain f = new frmMain();
                    f.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }*/
        
        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void lbQuenMK_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQuenMatKhau quenMatKhau = new frmQuenMatKhau();
            quenMatKhau.Show();
            this.Hide();
        }

        private void lbDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy dangKy = new frmDangKy();
            dangKy.Show();
            this.Hide();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThuNho_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtMK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
