using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Data
{
    public class DataAccessLayer
    {
        private readonly IConfiguration configuration;

        public DataAccessLayer(IConfiguration conf)
        {
            configuration = conf;
        }

        string conString = "Data Source=DESKTOP-KPOV200;Initial Catalog=PhoneBookDB;Integrated Security=True;Encrypt=False";
        public DataTable ExecuteSelect(string query, Dictionary<string, object> parameter, bool isProcedure)
        {
            string connection_string = configuration.GetConnectionString("ConStr").ToString();
           
            SqlConnection con = new SqlConnection(connection_string);
            SqlCommand com = new SqlCommand(query, con);
            if (isProcedure == true)
                com.CommandType = CommandType.StoredProcedure;

            if (parameter != null)
            {
                foreach (var item in parameter)
                {
                    com.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            //execute Command
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            return dt;
        }

        public DataSet ExecuteSelectDataset(string query, Dictionary<string, object> parameter, bool isProcedure)
        {
            string connection_string = configuration.GetConnectionString("ConStr").ToString();

            SqlConnection con = new SqlConnection(conString);
            SqlCommand com = new SqlCommand(query, con);
            if (isProcedure == true)
                com.CommandType = CommandType.StoredProcedure;

            if (parameter != null)
            {
                foreach (var item in parameter)
                {
                    com.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            //execute Command
            SqlDataAdapter adapt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            return ds;
        }

        public int ExecuteDML(string query, Dictionary<string, object> parameter, bool isProcedure)
        {
            string connection_string = configuration.GetConnectionString("ConStr").ToString();

            SqlConnection con = new SqlConnection(conString);

            SqlCommand com = new SqlCommand(query, con);
            if (isProcedure == true)
                com.CommandType = CommandType.StoredProcedure;

            if (parameter != null)
            {
                foreach (var item in parameter)
                {
                    com.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            //execute Command
            con.Open();
            int no = com.ExecuteNonQuery();
            con.Close();

            return no;
        }
    }
}
