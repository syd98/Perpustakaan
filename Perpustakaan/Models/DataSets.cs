using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Perpustakaan.Models
{
    public class DataSets
    {
        SqlConnection connect = new SqlConnection("Server=.\\;Database=TokoBukuDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
        public DataSet GetPenerbit()
        {
            SqlCommand com = new SqlCommand("Penerbits", connect);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
