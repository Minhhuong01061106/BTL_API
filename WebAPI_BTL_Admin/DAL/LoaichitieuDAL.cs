using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
namespace DAL
{
    public class LoaichitieuDAL
    {
        private readonly string _connectionString;

        public LoaichitieuDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<LoaichitieuModel> getall()
        {
            List<LoaichitieuModel> list = new List<LoaichitieuModel>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                
                string query = "SELECT * FROM Loaichitieu";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LoaichitieuModel item = new LoaichitieuModel
                            {
                                Idloaichitieu = reader.GetInt32(0),
                                Tenloaichitieu = reader.GetString(1),
                                Mota = reader.GetString(2),
                                Trangthai = reader.GetBoolean(3),
                                Ngaytao = reader.GetDateTime(4)
                                
                            };
                            list.Add(item);
                        }
                    } 
                }
                con.Close();
            }
            return list;
        }
        public bool Create(LoaichitieuModel model)
        {
            using(SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = @"INSERT INTO Loaichitieu 
                        (Tenloaichitieu, Mota, Trangthai) 
                        VALUES (@Tenloaichitieu, @Mota, @Trangthai)";
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Tenloaichitieu", model.Tenloaichitieu);
                    cmd.Parameters.AddWithValue("@Mota", model.Mota);
                    cmd.Parameters.AddWithValue("@Trangthai", model.Trangthai);

                    int ketqua = cmd.ExecuteNonQuery();
                    return ketqua > 0;
                }
            }
        }
    }
    
}
