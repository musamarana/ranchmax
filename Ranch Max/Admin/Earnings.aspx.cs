using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace Ranch_Max
{
    public partial class Earnings : System.Web.UI.Page
    {
        string str, str2, str3, str4;
        SqlCommand comm;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947");
            con.Open();
            str = "SELECT (SELECT ISNULL(SUM(Quantity * Rate),0) FROM MilkBuyer WHERE  DATEPART(m, DateTime) <= DATEPART(m, getdate())) + (SELECT ISNULL(SUM(Amount),0) FROM Animal_Sale WHERE  DATEPART(m, Date) <= DATEPART(m, getdate())) as Total";
            comm = new SqlCommand(str, con);
            SqlDataReader reader = comm.ExecuteReader();

            reader.Read();
            Label1.Text = reader["Total"].ToString();


            reader.Close();
            con.Close();

            con.Open();
            str2 = "SELECT (SELECT ISNULL(SUM(Quantity * Rate),0) FROM MilkBuyer WHERE  DATEPART(m, DateTime) <= DATEPART(m, getdate())) + (SELECT ISNULL(SUM(Amount),0) FROM Animal_Sale WHERE  DATEPART(m, Date) <= DATEPART(m, getdate())) - (SELECT SUM(Amount) FROM Expenses WHERE DATEPART(m, Date) <= DATEPART(m, getdate())) as Amount";
            comm = new SqlCommand(str2, con);
            SqlDataReader reader2 = comm.ExecuteReader();
            reader2.Read();
            Label2.Text = reader2["Amount"].ToString();
            reader2.Close();
            con.Close();

        }


    }
}