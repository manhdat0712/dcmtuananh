using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Bai22
{
    public partial class Page1 : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        String connectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            String query = "Select * from tblLoaisach";

            DataSet ds = GetData(query);
            if(ds.Tables.Count > 0)
            {
                gvBookType.DataSource = ds;
                gvBookType.DataBind();
            }
        }

        DataSet GetData(String queryString)
        {
            DataSet ds = new DataSet();

            try
            {
                // Connect to the database and run the query.
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

                // Fill the DataSet.
                adapter.Fill(ds);

            }
            catch (Exception ex)
            {

                // The connection failed. Display an error message
            }

            return ds;
        }
    }
 }


 