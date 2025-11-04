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
    public partial class frmHDBan : Form
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
                command.CommandText = "select * from tblHDBan";
            }
            else
            {

                command.CommandText = "select * from tblHDBan where MaHDBan like '%" + searchText + "%'";
            }
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);
            dgvHDBan.DataSource = dt;
        }


        public frmHDBan()
        {
            InitializeComponent();
            LoadMaNV();
            LoadMaKhach();
        }
        private void LoadMaKhach()
        {
            string query = "SELECT MaKhach FROM tblKhach";
            List<string> maKhachList = new List<string>();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\DoAn .Net\\QuanLyBanHangTv\\QuanLyBanHangTv\\QuanLyBanTV.mdf\";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        maKhachList.Add(reader["MaKhach"].ToString());
                    }
                }
            }

            cboMaKhach.DataSource = maKhachList;
        }
        private void LoadMaNV()
        {
            string query = "SELECT MaNhanVien FROM tblNhanVien";
            List<string> maNVList = new List<string>();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\DoAn .Net\\QuanLyBanHangTv\\QuanLyBanHangTv\\QuanLyBanTV.mdf\";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        maNVList.Add(reader["MaNhanVien"].ToString());
                    }
                }
            }

            cboMaNV.DataSource = maNVList;
        }



        private void frmHDBan_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dgvHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHDBan.CurrentRow.Index;
            txtMaHDBan.Text = dgvHDBan.Rows[i].Cells[0].Value.ToString();
            cboMaNV.Text = dgvHDBan.Rows[i].Cells[1].Value.ToString();
            dtmBan.Text = dgvHDBan.Rows[i].Cells[2].Value.ToString();
            cboMaKhach.Text = dgvHDBan.Rows[i].Cells[3].Value.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboMaKhach.Text = "";
            cboMaNV.Text = "";
            dtmBan.Text = "1/1/2000";
            txtMaHDBan.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Chuỗi kết nối
            SqlConnection connection = new SqlConnection(str);
            connection.Open();

            string maHDBan = txtMaHDBan.Text;

            // Kiểm tra mã hóa đơn đã tồn tại chưa
            string checkQuery = "SELECT COUNT(*) FROM tblHDBan WHERE MaHDBan = @maHDBan";
            SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
            checkCmd.Parameters.AddWithValue("@maHDBan", maHDBan);

            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                // Nếu mã hóa đơn đã tồn tại
                MessageBox.Show("Mã hóa đơn này đã được thêm trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Thêm mới nếu không trùng lặp
                string insertQuery = "INSERT INTO tblHDBan VALUES (@maHDBan, @maNVBan, @ngayBan,  @maKhach)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);

                insertCmd.Parameters.AddWithValue("@maHDBan", maHDBan);
                insertCmd.Parameters.AddWithValue("@maNVBan", cboMaNV.Text);
                insertCmd.Parameters.AddWithValue("@ngayBan", dtmBan.Text);
                insertCmd.Parameters.AddWithValue("@maKhach", cboMaKhach.Text);
                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi hàm load dữ liệu (nếu có)
                loaddata();
            }

            connection.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update tblHDBan set MaNhanVien = N'" + cboMaNV.Text + "', NgayBan = '" + dtmBan.Value + "', MaKhach = '" + cboMaKhach.Text + "' where MaHDBan = '" + txtMaHDBan.Text + "' ";
            command.ExecuteNonQuery();
            loaddata();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            try
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from tblHDBan where MaHDBan ='" + txtMaHDBan.Text + "'";
                command.ExecuteNonQuery();

                // Tải lại dữ liệu sau khi xóa thành công
                loaddata();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Kiểm tra lỗi có liên quan đến ràng buộc khóa ngoại hay không
                if (ex.Number == 547) // Lỗi ràng buộc khóa ngoại có số 547 trong SQL Server
                {
                    MessageBox.Show("Không thể xóa vì hóa đơn này đang được tham chiếu ở bảng khác.",
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
