using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangTV
{
    public partial class frmQuenMatKhau : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\DoAn .Net\QuanLyBanHangTv\QuanLyBanHangTv\QuanLyBanTv.mdf"";Integrated Security=True";

        public frmQuenMatKhau()
        {
            InitializeComponent();
        }
        private (string, string) GetUsernameAndPasswordByEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                email = txtEmail.Text;
                string sql = "SELECT TenTaiKhoan,MatKhau FROM TaiKhoan WHERE Email = '" + email + "'";


                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string username = reader["TenTaiKhoan"].ToString();
                    string password = reader["MatKhau"].ToString();
                    return (username, password); // Trả về tên đăng nhập và mật khẩu
                }
                else
                {
                    return ("", ""); // Trả về chuỗi rỗng nếu không tìm thấy email
                }
            }
        }
        private bool SendEmail(string username, string pass, string email)
        {
            try
            {
                string to = txtEmail.Text;
                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress("trinhman007@gmail.com");
                mail.Subject = "Khôi phục mật khẩu";
                mail.Body = $"Tin nhắn tự động: Khôi phục tài khoản của bạn với Tên tài khoản: {username}\nMật khẩu: {pass}\n\n Vui lòng đăng nhập để đổi mật khẩu.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("trinhman007@gmail.com", "eely eirc plfj tkqu");
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi mail!", ex.Message);
                return false;
            }
        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {

        }

        

        private void btnLayMatKhau_Click_1(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email!");
                return;
            }
            (string username, string password) = GetUsernameAndPasswordByEmail(email);
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(username))
            {
                if (SendEmail(username, password, email))
                {
                    MessageBox.Show("Đã gửi thông tin tài khoản qua gmail đã nhập!");
                    frmDangNhap f = new frmDangNhap();  
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi khi gửi email");
                }
            }
            else
            {
                MessageBox.Show("Không tồn tại email trong hệ thống");
            }
        }

      

        private void btnThuNho_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            f.Show();
            this.Close();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
