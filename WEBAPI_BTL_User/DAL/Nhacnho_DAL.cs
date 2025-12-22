using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Models;

namespace DAL
{
    public class Nhacnho_DAL
    {
        private readonly string _connectionString;

        public Nhacnho_DAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Nhacnho> GetAllNhacNho()
        {
            List<Nhacnho> list = new List<Nhacnho>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Gettnhacnho", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Nhacnho nn = new Nhacnho
                    {
                        IdNhacNho = Convert.ToInt32(rd["IdNhacNho"]),
                        IdTaiKhoan = Convert.ToInt32(rd["IdTaiKhoan"]),
                        IdLoaiNhacNho = Convert.ToInt32(rd["IdLoaiNhacNho"]),
                        NoiDung = rd["NoiDung"].ToString(),

                        SoTienNhacNho = rd["SoTienNhacNho"] == DBNull.Value
                                        ? 0
                                        : Convert.ToDecimal(rd["SoTienNhacNho"]),

                        ChuKyNhacNho = rd["ChuKyNhacNho"] == DBNull.Value ? null: rd["ChuKyNhacNho"].ToString(),

                        NgayKetThuc = rd["NgayKetThuc"] == DBNull.Value? (DateTime?)null: Convert.ToDateTime(rd["NgayKetThuc"]),

                        MoTa = rd["MoTa"] == DBNull.Value? null: rd["MoTa"].ToString(),

                        TrangThai = Convert.ToBoolean(rd["TrangThai"])
                    };

                    list.Add(nn);
                }

                rd.Close();
            }

            return list;
        }
        public Nhacnho Getbyidnhacnho(int idnhacnho)
        {
            Nhacnho nn = null;
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Getnhacnhobyid", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdNhacNho", idnhacnho);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    nn = new Nhacnho
                    {
                        IdNhacNho = Convert.ToInt32(rd["IdNhacNho"]),
                        IdTaiKhoan = Convert.ToInt32(rd["IdTaiKhoan"]),
                        IdLoaiNhacNho = Convert.ToInt32(rd["IdLoaiNhacNho"]),
                        NoiDung = rd["NoiDung"].ToString(),
                        SoTienNhacNho = rd["SoTienNhacNho"] == DBNull.Value? 0: Convert.ToDecimal(rd["SoTienNhacNho"]),

                        ChuKyNhacNho = rd["ChuKyNhacNho"] == DBNull.Value? null: rd["ChuKyNhacNho"].ToString(),

                        NgayKetThuc = rd["NgayKetThuc"] == DBNull.Value ? (DateTime?)null: Convert.ToDateTime(rd["NgayKetThuc"]),

                        MoTa = rd["MoTa"] == DBNull.Value? null: rd["MoTa"].ToString(),

                        TrangThai = Convert.ToBoolean(rd["TrangThai"])
                    };
                }

                rd.Close();
            }

            return nn;
        }
        
    }
}
