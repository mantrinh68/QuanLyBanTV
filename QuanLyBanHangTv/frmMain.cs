using Guna.UI2.WinForms;
using QuanLyBanHangTV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangTv
{
    public partial class frmMain : Form
    { 
        public frmMain()
        {
            InitializeComponent();
            frmDangNhap loginForm = new frmDangNhap();
            loginForm.LoginSuccess += LoginForm_LoginSuccess;
            loginForm.Close();
            this.Hide();
            string tentaikhoan = frmDangNhap.TenTaiKhoan;
            lbTenDangNhap.Text = tentaikhoan;
        }
        private void LoginForm_LoginSuccess(object sender, frmDangNhap.LoginEventArgs e)
        {
            this.Show();
        }

        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnMain.Controls.Add(childForm);
            pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
            lbMain.Text = btnNhanVien.Text;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnHSX_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHSX());
            lbMain.Text = btnHSX.Text;
        }

        private void btnHDban_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHDBan());
            lbMain.Text = btnHDban.Text;
        }

        private void btnHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHang());
            lbMain.Text = btnHang.Text;
        }
        private void btnKhach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
            lbMain.Text = btnKhach.Text;
        }

        private void btnCTHDBan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChiTietHoaDon());
            lbMain.Text = btnCTHDBan.Text;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            lbMain.Text = "TRANG CHỦ";
        }

        private void btnThuNho_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void picAVT_Click(object sender, EventArgs e)
        {
            menuAVT.Show(picAVT, new Point(0, picAVT.Height));
        }

        private void lbTenDangNhap_Click(object sender, EventArgs e)
        {
            
        }

        private void picAVT_Click_1(object sender, EventArgs e)
        {
            menuAVT.Show(picAVT, new Point(0, picAVT.Height));
        }

        private void DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?",
                                         "Đăng xuất",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Đóng Form hiện tại và mở lại màn hình đăng nhập
                this.Hide();
                frmDangNhap f = new frmDangNhap();
                f.Show();
            }
        }

        private void lbMain_Click(object sender, EventArgs e)
        {

        }
    }
}
