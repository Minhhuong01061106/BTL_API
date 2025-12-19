using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class Loainhacnho_DAL
    {
        private readonly string _connectionString;

        public Loainhacnho_DAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Loainhacnho> GetAllLoaiNhacNho()
        {
            List<Loainhacnho> list = new List<Loainhacnho>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllLoaiNhacNho", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Loainhacnho lnn = new Loainhacnho
                    {
                        IdLoaiNhacNho = Convert.ToInt32(rd["IdLoaiNhacNho"]),
                        TenLoaiNhacNho = rd["TenLoaiNhacNho"].ToString(),
                        MoTa = rd["MoTa"].ToString(),
                        TrangThai = Convert.ToBoolean(rd["TrangThai"]),
                        NgayTao = Convert.ToDateTime(rd["NgayTao"])
                    };

                    list.Add(lnn);
                }

                rd.Close();
            }

            return list;
        }

        public Loainhacnho GetLoaiNhacNhoById(int idLoaiNhacNho)
        {
            Loainhacnho lnn = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetLoaiNhacNhoById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Truyền tham số cho Stored Procedure
                cmd.Parameters.AddWithValue("@IdLoaiNhacNho", idLoaiNhacNho);

                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    lnn = new Loainhacnho
                    {
                        IdLoaiNhacNho = Convert.ToInt32(rd["IdLoaiNhacNho"]),
                        TenLoaiNhacNho = rd["TenLoaiNhacNho"].ToString(),
                        MoTa = rd["MoTa"].ToString(),
                        TrangThai = Convert.ToBoolean(rd["TrangThai"]),
                        NgayTao = Convert.ToDateTime(rd["NgayTao"])
                    };
                }

                rd.Close();
            }

            return lnn;
        }

    }
}
