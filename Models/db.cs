using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UCP1_PAW_097_C.Controllers;


namespace UCP1_PAW_097_C.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=tanahKavling;Integrated Security=True");
        public int LoginCheck(Ad_login ad)
        {
            SqlCommand com = new SqlCommand("Sp_Login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Admin_id", ad.Admin_id);
            com.Parameters.AddWithValue("@Password", ad.Ad_Password);

            SqlParameter obLogin = new SqlParameter();
            obLogin.ParameterName = "@Isvalid";
            obLogin.SqlDbType = SqlDbType.Bit;
            obLogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(obLogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(obLogin.Value);
            con.Close();
            return res;
        }

        public IFormFile file { get; set; }
        public string Tanah { get; set; }
    }
}
