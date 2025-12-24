
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.Data.SqlClient;
namespace DAL
{
    public class LoaithunhapDAL
    {
        private readonly string _connectionString;

        public LoaithunhapDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}
