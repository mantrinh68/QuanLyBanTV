using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using QuanLyBanHangTv;

namespace QuanLyBanHangTV
{
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }
        public bool checkedAccount(string ac)//check tài khoản và mật khẩu 
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }
        public bool isValidEmail(string email) //check gmail
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        private void DangKy_Load(object sender, EventArgs e)
        {

        }
        Modify modify = new Modify();//Khai báo đối tượng trong lớp Modify
       


        private void btnDangKy_Click_1(object sender, EventArgs e)
        {
            string tentk = txtTK.Text;
            string matkhau = txtMK.Text;
            string email = txtEmail.Text;
            string xacnhanmk = txtNhapLaiMK.Text;
            if (!checkedAccount(tentk)) { MessageBox.Show("Vui lòng nhập tên tài khoản dài 6-24 ký tự với các ký tự số hoa và chữ thường!"); return; };
            if (!checkedAccount(matkhau)) { MessageBox.Show("Vui lòng nhập mật khẩu dài 6-24 ký tự với các ký tự số hoa và chữ thường!"); return; };
            if (xacnhanmk != matkhau) { MessageBox.Show("Vui lòng xác nhận lại mật khẩu !"); return; };
            //if (!checkedAccount(email)) { MessageBox.Show("Vui lòng nhập đúng định dạng email "); return; };
            if (modify.TaiKhoans("select * from TaiKhoan where Email = '" + email + "' ").Count != 0) { MessageBox.Show("Email này đã được đăng ký!"); return; };
            try
            {
                string query = "Insert into TaiKhoan values ('" + tentk + "','" + matkhau + "','" + email + "')";
                modify.Command(query);
                if (MessageBox.Show("Đăng ký thành công! Bạn có muốn đăng nhập liền không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                    frmDangNhap f = new frmDangNhap();
                    f.Show();
                }

            }
            catch
            {
                MessageBox.Show("Tên tài khoản đã được đăng ký , vui lòng đăng ký tên tài khoản khác!");
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

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDangKy_Click_1(sender, e);
            }
        }

     
    }
}
