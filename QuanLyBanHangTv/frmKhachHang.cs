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

namespace QuanLyBanHangTv
{
    public partial class frmKhachHang : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\DoAn .Net\QuanLyBanHangTv\QuanLyBanHangTv\QuanLyBanTV.mdf"";Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        void loaddata(string searchText = "")
        {
            command = connection.CreateCommand();
            if (searchText.Trim() == "")
            {
                command.CommandText = "select * from tblKhach";
            }
            else
            {

                command.CommandText = "select * from tblKhach where MaKhach like '%" + searchText + "%'";
            }
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);
            dgvKhachHang.DataSource = dt;
        }
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmDanhMucKhachHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Chuỗi kết nối
            SqlConnection connection = new SqlConnection(str);
            connection.Open();

            string maKhach = txtMaKhach.Text;

            // Kiểm tra mã nhân viên đã tồn tại chưa
            string checkQuery = "SELECT COUNT(*) FROM tblKhach WHERE MaKhach = @maKhach";
            SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
            checkCmd.Parameters.AddWithValue("@maKhach", maKhach);

            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                // Nếu mã khách đã tồn tại
                MessageBox.Show("Mã khách này đã được thêm trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Thêm mới nếu không trùng lặp
                string insertQuery = "INSERT INTO tblKhach VALUES (@maKhach, @tenKhach,  @dienThoai, @diaChi)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);

                insertCmd.Parameters.AddWithValue("@maKhach", maKhach);
                insertCmd.Parameters.AddWithValue("@tenKhach", txtTenKhach.Text);
                insertCmd.Parameters.AddWithValue("@dienThoai", txtDienThoai.Text);
                insertCmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Khách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi hàm load dữ liệu (nếu có)
                loaddata();
            }

            connection.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update tblKhach set TenKhach = N'" + txtTenKhach.Text + "',  DiaChi = N'" + txtDiaChi.Text + "', DienThoai = '" + txtDienThoai.Text + "' where MaKhach = '" + txtMaKhach.Text + "' ";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            loaddata(searchText);
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvKhachHang.CurrentRow.Index;
            txtMaKhach.Text = dgvKhachHang.Rows[i].Cells[0].Value.ToString();
            txtTenKhach.Text = dgvKhachHang.Rows[i].Cells[1].Value.ToString();
            txtDienThoai.Text = dgvKhachHang.Rows[i].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.Rows[i].Cells[2].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from tblKhach where MaKhach ='" + txtMaKhach.Text + "'";
                command.ExecuteNonQuery();

                // Tải lại dữ liệu sau khi xóa thành công
                loaddata();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Kiểm tra lỗi có liên quan đến ràng buộc khóa ngoại hay không
                if (ex.Number == 547) // Lỗi ràng buộc khóa ngoại có số 547 trong SQL Server
                {
                    MessageBox.Show("Không thể xóa vì khách hàng này đang được tham chiếu ở bảng khác.",
                                    "Lỗi xóa",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }
    }
}
