using Bai21;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bai21
{
    public partial class b21 : System.Web.UI.Page
    {
        ConnectDb cnn = new ConnectDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drpDriver.DataSource = cnn.ExecuteQuery("Select * from Driver");
                drpDriver.DataValueField = "id";
                drpDriver.DataTextField = "name";
                drpDriver.DataBind();
            }
            rvDate.MaximumValue = DateTime.Today.ToShortDateString();
        }

        protected void drpDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rate = 0;
            int id = int.Parse(drpDriver.SelectedValue);
            string query = "Select * from Driver where id = " + id;
            DataTable dt = cnn.ExecuteQuery(query);

            foreach(DataRow row in dt.Rows)
            {
                rate = int.Parse(row["rate"].ToString());
            }
            
            if(rate == 0)
            {
                rdbRate.ClearSelection();
            }
            else
            {
                rdbRate.SelectedValue = rate.ToString();
            }
        }

        protected void btnExecute_Click(object sender, EventArgs e)
        {
            int rate = int.Parse(rdbRate.SelectedValue);
            int id = int.Parse(drpDriver.SelectedValue);
            string date = txtDate.Text;
            updateData(id, DateTime.Parse(date), rate);
        }
        
        public void updateData(int id, DateTime date, int rate)
        {
            int check = cnn.ExecuteNonQuery("Exec dbo.insertData @id , @date , @rate", new object[] { id, date, rate });

            if(check > 0)
            {
                Response.Write("Successfully");
                rdbRate.ClearSelection();
                drpDriver.SelectedIndex = 1;
                txtDate.Text = "";
            }
            else
            {
                Response.Write("Fail");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            rdbRate.ClearSelection();
            drpDriver.SelectedIndex = 1;
            txtDate.Text = "";
        }
    }
}