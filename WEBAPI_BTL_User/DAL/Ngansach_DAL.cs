using Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class Ngansach_DAL
    {
        private readonly string _connectionString;

        public Ngansach_DAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Ngansach> GetAllNganSach()
        {
            List<Ngansach> list = new List<Ngansach>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllNganSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Ngansach ns = new Ngansach
                    {
                        IdNganSach = Convert.ToInt32(reader["IdNganSach"]),
                        IdTaiKhoan = Convert.ToInt32(reader["IdTaiKhoan"]),
                        TenNganSach = reader["TenNganSach"].ToString(),
                        SoTienGioiHan = Convert.ToDecimal(reader["SoTienGioiHan"]),
                        MoTa = reader["MoTa"].ToString(),
                        NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                        TrangThai = Convert.ToBoolean(reader["TrangThai"])
                    };

                    list.Add(ns);
                }
            }

            return list;
        }
    }
}
