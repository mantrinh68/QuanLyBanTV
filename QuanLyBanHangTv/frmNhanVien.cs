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
    public partial class frmNhanVien : Form
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
                command.CommandText = "select * from tblNhanVien";
            }
            else
            {
                
                command.CommandText = "select * from tblNhanVien where MaNhanVien like '%" + searchText + "%'";
            }
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);
            dgvNhanVien.DataSource = dt;
        }
        public frmNhanVien()
        {
            InitializeComponent();
        }

    

        private void frmDanhMucNhanVien_Load(object sender, EventArgs e)
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

            string maNhanVien = txtMaNhanVien.Text;

            // Kiểm tra mã nhân viên đã tồn tại chưa
            string checkQuery = "SELECT COUNT(*) FROM tblNhanVien WHERE MaNhanVien = @maNV";
            SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
            checkCmd.Parameters.AddWithValue("@maNV", maNhanVien);

            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                // Nếu mã nhân viên đã tồn tại
                MessageBox.Show("Mã nhân viên này đã được thêm trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Thêm mới nếu không trùng lặp
                string insertQuery = "INSERT INTO tblNhanVien VALUES (@maNV, @tenNV, @ngaySinh, @gioiTinh, @dienThoai, @diaChi)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);

                insertCmd.Parameters.AddWithValue("@maNV", maNhanVien);
                insertCmd.Parameters.AddWithValue("@tenNV", txtTenNhanVien.Text);
                insertCmd.Parameters.AddWithValue("@ngaySinh", dtmNgaySinh.Value);
                insertCmd.Parameters.AddWithValue("@gioiTinh", cboGioiTinh.Text);
                insertCmd.Parameters.AddWithValue("@dienThoai", txtDienThoai.Text);
                insertCmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);

                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi hàm load dữ liệu (nếu có)
                loaddata();
            }

            connection.Close();
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from tblNhanVien where MaNhanVien ='" + txtMaNhanVien.Text + "'";
                command.ExecuteNonQuery();

                // Tải lại dữ liệu sau khi xóa thành công
                loaddata();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Kiểm tra lỗi có liên quan đến ràng buộc khóa ngoại hay không
                if (ex.Number == 547) // Lỗi ràng buộc khóa ngoại có số 547 trong SQL Server
                {
                    MessageBox.Show("Không thể xóa vì nhân viên này đang được tham chiếu ở bảng khác.",
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


        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvNhanVien.CurrentRow.Index;
            txtMaNhanVien.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            txtTenNhanVien.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
            dtmNgaySinh.Text = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
            cboGioiTinh.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
            txtDienThoai.Text = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update tblNhanVien set TenNhanVien = N'" + txtTenNhanVien.Text + "', NgaySinh = '"+dtmNgaySinh.Value+ "', GioiTinh = N'"+cboGioiTinh.Text+ "', DiaChi = N'"+txtDiaChi.Text+ "', DienThoai = '"+txtDienThoai.Text+"' where MaNhanVien = '"+txtMaNhanVien.Text+"' ";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            dtmNgaySinh.Text = "1/1/1900";
            cboGioiTinh.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim(); 
            loaddata(searchText); 
        }
    }
}
