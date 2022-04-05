using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bai21
{
    public class ConnectDb
    {
        public DataTable ExecuteQuery(string query, object[] parameter = null)//excutequery return data lines
        {
            DataTable data = new DataTable();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ToString()))//release data
            {
                cnn.Open();//open connection

                SqlCommand cmd = new SqlCommand(query, cnn);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(data); 

                cnn.Close();
            }

            return data;
        }


        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ToString()))//using release data
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(query, cnn);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();//ExecuteNonQuery() return affected data just for del, update, insert
                cnn.Close();
            }

            return data;
        }
    }
}