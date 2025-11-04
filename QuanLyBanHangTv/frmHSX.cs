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
    public partial class frmHSX : Form
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
                command.CommandText = "select * from tblHSX";
            }
            else
            {

                command.CommandText = "select * from tblHSX where MaHSX like '%" + searchText + "%'";
            }
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);
            dgvHSX.DataSource = dt;
        }
        public frmHSX()
        {
            InitializeComponent();
        }

        private void frmHSX_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Chuỗi kết nối
            SqlConnection connection = new SqlConnection(str);
            connection.Open();

            string maHSX = txtMaHSX.Text;

            // Kiểm tra mã hãng đã tồn tại chưa
            string checkQuery = "SELECT COUNT(*) FROM tblHSX WHERE MaHSX = @maHSX";
            SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
            checkCmd.Parameters.AddWithValue("@maHSX", maHSX);

            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                // Nếu mã hãng đã tồn tại
                MessageBox.Show("Mã hãng này đã được thêm trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Thêm mới nếu không trùng lặp
                string insertQuery = "INSERT INTO tblHSX VALUES (@maHSX, @tenHSX)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);

                insertCmd.Parameters.AddWithValue("@maHSX", maHSX);
                insertCmd.Parameters.AddWithValue("@tenHSX", txtTenHSX.Text);

                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Thêm hãng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi hàm load dữ liệu (nếu có)
                loaddata();
            }

            connection.Close();
        }

        private void dgvHSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHSX.CurrentRow.Index;
            txtMaHSX.Text = dgvHSX.Rows[i].Cells[0].Value.ToString();
            txtTenHSX.Text = dgvHSX.Rows[i].Cells[1].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update tblHSX set TenHSX = N'" + txtTenHSX.Text + "' where MaHSX = '"+ txtMaHSX.Text +"' ";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from tblHSX where MaHSX ='" + txtMaHSX.Text + "'";
                command.ExecuteNonQuery();

                // Tải lại dữ liệu sau khi xóa thành công
                loaddata();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Kiểm tra lỗi có liên quan đến ràng buộc khóa ngoại hay không
                if (ex.Number == 547) // Lỗi ràng buộc khóa ngoại có số 547 trong SQL Server
                {
                    MessageBox.Show("Không thể xóa vì hãng này đang được tham chiếu ở bảng khác.",
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHSX.Text = "";
            txtTenHSX.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            loaddata(searchText);
        }
    }
}
