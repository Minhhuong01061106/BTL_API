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
        public Ngansach GetNganSachById(int id)
        {
            Ngansach ns = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Getngansachid", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ns = new Ngansach
                    {
                        IdNganSach = Convert.ToInt32(reader["IdNganSach"]),
                        IdTaiKhoan = Convert.ToInt32(reader["IdTaiKhoan"]),
                        TenNganSach = reader["TenNganSach"].ToString(),
                        SoTienGioiHan = Convert.ToDecimal(reader["SoTienGioiHan"]),
                        MoTa = reader["MoTa"].ToString(),
                        NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                        TrangThai = Convert.ToBoolean(reader["TrangThai"])
                    };
                }
            }

            return ns;
        }
        public bool Themngansach(Ngansach ns)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemNgansach", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdTaiKhoan",ns. IdTaiKhoan);
                cmd.Parameters.AddWithValue("@TenNganSach", ns.TenNganSach);
                cmd.Parameters.AddWithValue("@SoTienGioiHan", ns.SoTienGioiHan);
                cmd.Parameters.AddWithValue("@MoTa", ns.MoTa);
                cmd.Parameters.AddWithValue("@TrangThai", ns.TrangThai);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

    }
}
