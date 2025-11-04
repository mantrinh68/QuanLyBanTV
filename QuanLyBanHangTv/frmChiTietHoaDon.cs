using System;
using System.Collections;
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
    public partial class frmChiTietHoaDon : Form
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
                command.CommandText = "select * from tblChiTietHDBan";
            }
            else
            {

                command.CommandText = "select * from tblChiTietHDBan where MaHD like '%" + searchText + "%'";
            }
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);
            dgvChiTietHD.DataSource = dt;
        }
        public frmChiTietHoaDon()
        {
            InitializeComponent();
            LoadMaHD();
            LoadMaHang();
            LoadTenHang();


        }

        private void LoadMaHD()
        {
            string query = "SELECT MaHDBan FROM tblHDBan";
            List<string> maHDList = new List<string>();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\DoAn .Net\\QuanLyBanHangTv\\QuanLyBanHangTv\\QuanLyBanTV.mdf\";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        maHDList.Add(reader["MaHDBan"].ToString());
                    }
                }
            }

            cbMaHD.DataSource = maHDList;
        }

        private void LoadMaHang()
        {
            string query = "SELECT MaHang FROM tblHang";
            List<string> maHangList = new List<string>();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\DoAn .Net\\QuanLyBanHangTv\\QuanLyBanHangTv\\QuanLyBanTV.mdf\";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        maHangList.Add(reader["MaHang"].ToString());
                    }
                }
            }

            cbMaHang.DataSource = maHangList;
        }
        private void LoadTenHang()
        {

            string selectedMaHang = cbMaHang.SelectedItem.ToString();

            string query1 = "SELECT TenHang FROM tblHang WHERE MaHang = @MaHang";
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\DoAn .Net\\QuanLyBanHangTv\\QuanLyBanHangTv\\QuanLyBanTV.mdf\";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query1, connection);
                command.Parameters.AddWithValue("@MaHang", selectedMaHang);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        txtTenHang.Text = result.ToString();
                    }
                    else
                    {
                        txtTenHang.Text = "Không tìm thấy!";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbMaHD.Text = "";
            cbMaHang.Text = "";
            txtSoLuong.Text = "0";
            txtTenHang.Text = "";
            txtDonGia.Text = "";
            txtGiamGia.Text = "";
            txtThanhTien.Text = "";
        }
        private void LoadSoLuong()
        {

            string selectedMaHang = cbMaHang.SelectedItem.ToString();


            string query1 = "SELECT TenHang FROM tblHang WHERE MaHang = @MaHang";
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\DoAn .Net\\QuanLyBanHangTv\\QuanLyBanHangTv\\QuanLyBanTV.mdf\";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query1, connection);
                command.Parameters.AddWithValue("@MaHang", selectedMaHang);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        txtSoLuong.Text = result.ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        public int LaySoLuong(string maHang)
        {
            int soLuongTonKho = 0;
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\DoAn .Net\\QuanLyBanHangTv\\QuanLyBanHangTv\\QuanLyBanTV.mdf\";Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT SoLuong FROM tblHang WHERE MaHang = @MaHang", conn))
                {
                    cmd.Parameters.AddWithValue("@MaHang", maHang);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            soLuongTonKho = (int)reader["SoLuong"];
                        }
                    }
                }
            }

            return soLuongTonKho;
        }
        private double TinhGiamGia(int soLuong)
        {
            try
            {
                if (soLuong > 10)
                {
                    return 0.1;
                }
                else if (soLuong >= 5)
                {
                    return 0.05;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính giảm giá: " + ex.Message);
                return 0;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã hóa đơn và mã hàng trước khi thêm
            SqlCommand checkCommand = connection.CreateCommand();
            checkCommand.CommandText = "SELECT COUNT(*) FROM tblChiTietHDBan WHERE MaHD = @MaHD AND MaHang = @MaHang";
            checkCommand.Parameters.AddWithValue("@MaHD", cbMaHD.Text);
            checkCommand.Parameters.AddWithValue("@MaHang", cbMaHang.Text);

            int count = Convert.ToInt32(checkCommand.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show("Mã hóa đơn và mã hàng này đã tồn tại trong cơ sở dữ liệu. Không thể thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm dữ liệu nếu không trùng
            SqlCommand insertCommand = connection.CreateCommand();
            insertCommand.CommandText = "INSERT INTO tblChiTietHDBan (MaHD, MaHang, TenHang, SoLuong, DonGia, ThanhTien, GiamGia) " +
                                        "VALUES (@MaHD, @MaHang, @TenHang, @SoLuong, @DonGia, @ThanhTien, @GiamGia)";
            insertCommand.Parameters.AddWithValue("@MaHD", cbMaHD.Text);
            insertCommand.Parameters.AddWithValue("@MaHang", cbMaHang.Text);
            insertCommand.Parameters.AddWithValue("@TenHang", txtTenHang.Text);
            insertCommand.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text);
            insertCommand.Parameters.AddWithValue("@DonGia", txtDonGia.Text);
            insertCommand.Parameters.AddWithValue("@ThanhTien", txtThanhTien.Text);
            insertCommand.Parameters.AddWithValue("@GiamGia", txtGiamGia.Text);

            try
            {
                insertCommand.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void TinhThanhTien()
        {
            try
            {
                string MaHD = cbMaHD.Text;
                string MaHang = cbMaHang.SelectedItem.ToString();
                int SoLuongNhap = int.Parse(txtSoLuong.Text);
                int SoLuongTon = LaySoLuong(MaHang);

                if (SoLuongNhap > SoLuongTon)
                {
                    MessageBox.Show("Ko đủ số lượng sản phẩm để bán!");
                }
                else
                {
                    if (SoLuongNhap <= 3)
                    {
                        int Giam = 0;
                        txtGiamGia.Text = Giam.ToString();
                    }
                    else if (SoLuongNhap > 3 && SoLuongNhap <= 6)
                    {
                        int Giam = 10;
                        txtGiamGia.Text = Giam.ToString();
                    }
                    else
                    {
                        int Giam = 20;
                        txtGiamGia.Text = Giam.ToString();
                    }

                }
                double donGia = double.Parse(txtDonGia.Text);
                int soLuong = int.Parse(txtSoLuong.Text);
                double giamGia = double.Parse(txtGiamGia.Text);

                double thanhTien = donGia * soLuong * (1 - giamGia / 100);
                txtThanhTien.Text = thanhTien.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void LoadDonGia()
        {

            string selectedMaHang = cbMaHang.SelectedItem.ToString();

            string query1 = "SELECT DonGiaBan FROM tblHang WHERE MaHang = @MaHang";
            
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\DoAn .Net\\QuanLyBanHangTv\\QuanLyBanHangTv\\QuanLyBanTV.mdf\";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query1, connection);
                command.Parameters.AddWithValue("@MaHang", selectedMaHang);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        txtDonGia.Text = result.ToString();
                    }
                    else
                    {
                        txtDonGia.Text = "Không tìm thấy!";
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"loi: {ex.Message}");
                }
            }
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
                connection = new SqlConnection(str);
                connection.Open();
                loaddata();
        }

        private void cbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTenHang();
            LoadDonGia();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void dgvChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvChiTietHD.CurrentRow.Index;
            cbMaHD.Text = dgvChiTietHD.Rows[i].Cells[0].Value.ToString();
            cbMaHang.Text = dgvChiTietHD.Rows[i].Cells[1].Value.ToString();
            txtTenHang.Text = dgvChiTietHD.Rows[i].Cells[2].Value.ToString();
            txtDonGia.Text = dgvChiTietHD.Rows[i].Cells[4].Value.ToString();
            txtGiamGia.Text = dgvChiTietHD.Rows[i].Cells[6].Value.ToString();
            txtThanhTien.Text = dgvChiTietHD.Rows[i].Cells[5].Value.ToString();
            txtSoLuong.Text =  dgvChiTietHD.Rows[i].Cells[3].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from tblChiTietHDBan where MaHD ='" + cbMaHD.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            loaddata(searchText);
        }
    }
}
