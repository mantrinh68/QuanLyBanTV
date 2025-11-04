using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangTv
{
    internal class Modify
    {
        public Modify()
        {

        }
        SqlCommand sqlCommand; //Truy van cac cau lenh them sua xoa
        SqlDataReader dataReader; // Dung de doc du lieu trong bang
        public List<TaiKhoan> TaiKhoans(string query) //check tài khoản
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();

            using (SqlConnection sqlConnection = connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
                }

                sqlConnection.Close();
            }
            return taiKhoans;
        }
        public void Command(string query)//Dùng để đăng ký tài khoản
        {
            using (SqlConnection sqlconnection = connection.GetSqlConnection())
            {
                sqlconnection.Open();
                sqlCommand = new SqlCommand(query, sqlconnection);
                sqlCommand.ExecuteNonQuery();// thực thi câu truy vấn
                sqlconnection.Close();
            }
        }
    }
}
