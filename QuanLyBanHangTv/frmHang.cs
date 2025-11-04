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
    public partial class frmHang : Form
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
                command.CommandText = "select * from tblHang";
            }
            else
            {

                command.CommandText = "select * from tblHang where MaHang like '%" + searchText + "%'";
            }
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);
            dgvHang.DataSource = dt;
        }
        public frmHang()
        {
            InitializeComponent();
            LoadMaHSX();
        }

        private void frmHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }
        private void LoadMaHSX()
        {
            string query = "SELECT MaHSX FROM tblHSX";
            List<string> maHSXList = new List<string>();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\DoAn .Net\\QuanLyBanHangTv\\QuanLyBanHangTv\\QuanLyBanTV.mdf\";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        maHSXList.Add(reader["MaHSX"].ToString());
                    }
                }
            }

            cboMaHSX.DataSource = maHSXList;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            txtGhiChu.Text = "";
            cboMaHSX.Text = "";
            txtSoLuong.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Chuỗi kết nối
            SqlConnection connection = new SqlConnection(str);
            connection.Open();

            string maHang = txtMaHang.Text;

            // Kiểm tra mã hàng đã tồn tại chưa
            string checkQuery = "SELECT COUNT(*) FROM tblHang WHERE MaHang = @maHang";
            SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
            checkCmd.Parameters.AddWithValue("@maHang", maHang);

            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                // Nếu mã hàng đã tồn tại
                MessageBox.Show("Mã hàng này đã được thêm trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Thêm mới nếu không trùng lặp
                string insertQuery = "INSERT INTO tblHang VALUES (@maHang, @tenHang, @maHSX, @soLuong, @donGN, @donGB, @ghiChu)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);

                insertCmd.Parameters.AddWithValue("@maHang", maHang);
                insertCmd.Parameters.AddWithValue("@tenHang", txtTenHang.Text);
                insertCmd.Parameters.AddWithValue("@maHSX", cboMaHSX.Text);
                insertCmd.Parameters.AddWithValue("@soLuong", txtSoLuong.Text);
                insertCmd.Parameters.AddWithValue("@donGN", txtDonGiaNhap.Text);
                insertCmd.Parameters.AddWithValue("@donGB", txtDonGiaBan.Text);
                insertCmd.Parameters.AddWithValue("@ghiChu", txtGhiChu.Text);

                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Thêm hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi hàm load dữ liệu (nếu có)
                loaddata();
            }

            connection.Close();
        }

        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHang.CurrentRow.Index;
            txtMaHang.Text = dgvHang.Rows[i].Cells[0].Value.ToString();
            txtTenHang.Text = dgvHang.Rows[i].Cells[1].Value.ToString();
            cboMaHSX.Text = dgvHang.Rows[i].Cells[2].Value.ToString();
            txtSoLuong.Text = dgvHang.Rows[i].Cells[3].Value.ToString();
            txtDonGiaNhap.Text = dgvHang.Rows[i].Cells[4].Value.ToString();
            txtDonGiaBan.Text = dgvHang.Rows[i].Cells[5].Value.ToString();
            txtGhiChu.Text = dgvHang.Rows[i].Cells[6].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update tblHang set TenHang = N'" + txtTenHang.Text + "', MaHSX = '" + cboMaHSX.Text + "', SoLuong = N'" + txtSoLuong.Text + "', DonGiaNhap = N'" + txtDonGiaNhap.Text + "', DonGiaBan = '" + txtDonGiaBan.Text + "',GhiChu = N'" + txtGhiChu.Text + "' where MaHang = '" + txtMaHang.Text + "' ";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from tblHang where MaHang ='" + txtMaHang.Text + "'";
                command.ExecuteNonQuery();

                // Tải lại dữ liệu sau khi xóa thành công
                loaddata();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Kiểm tra lỗi có liên quan đến ràng buộc khóa ngoại hay không
                if (ex.Number == 547) // Lỗi ràng buộc khóa ngoại có số 547 trong SQL Server
                {
                    MessageBox.Show("Không thể xóa vì hàng này đang được tham chiếu ở bảng khác.",
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            loaddata(searchText);
        }
    }
}
