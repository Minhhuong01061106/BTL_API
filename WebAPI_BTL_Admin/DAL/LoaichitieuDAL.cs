using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
namespace DAL
{
    internal class LoaichitieuDAL
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-C9F3CER\\SQLEXPRESS;Database=BTL_API;Trusted_Connection=True;");

        public List<LoaichitieuDTO> Getall()
        {
            List<LoaichitieuDTO> allct = new List<LoaichitieuDTO>();
            string query = "Select*from Loaichitieu";
            SqlCommand cmd = new SqlCommand(query, con);
            
               
        }
    }
}
