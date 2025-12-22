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

        public bool Themloainhacnho (Loainhacnho lnn)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("Themloainhacnho", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenLoaiNhacNho", lnn.TenLoaiNhacNho);
                cmd.Parameters.AddWithValue("@MoTa", lnn.MoTa);
                cmd.Parameters.AddWithValue("@TrangThai", lnn.TrangThai);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public bool Sualoainhacnho(Loainhacnho lnn) 
        {
            using (SqlConnection conn = new SqlConnection(_connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("Sualoainhacnho", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdLoaiNhacNho", lnn.IdLoaiNhacNho);
                cmd.Parameters.AddWithValue("@TenLoaiNhacNho", lnn.TenLoaiNhacNho);
                cmd.Parameters.AddWithValue("@MoTa",lnn.MoTa);
                cmd.Parameters.AddWithValue("@TrangThai", lnn.TrangThai);
                conn.Open() ;
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public bool Xoaloainhacnho(int idloainn)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString)) 
            { 
                SqlCommand cmd  = new SqlCommand("Xoaloainhacnho", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdLoaiNhacNho", idloainn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}
