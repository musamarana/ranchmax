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
    public partial class Expense_Detail : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947");
        string str, str2, str3, str4;
        SqlCommand comm;


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ShowExpense();
                ShowType();
                showDailyPurchase();
            }


            SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947");
            con.Open();
            str = "SELECT SUM(Amount) AS Total FROM Expenses WHERE DATEPART(m, Date) <= DATEPART(m, getdate())";
            comm = new SqlCommand(str, con);
            SqlDataReader reader = comm.ExecuteReader();

            reader.Read();
            Label1.Text = reader["Total"].ToString();


            reader.Close();
            con.Close();

            con.Open();
            str2 = "SELECT ISNULL(SUM(Rate),0) as Amount FROM StockAdd WHERE DATEPART(m, Expiry) <= DATEPART(m, getdate())";
            comm = new SqlCommand(str2, con);
            SqlDataReader reader2 = comm.ExecuteReader();
            reader2.Read();
            Label2.Text = reader2["Amount"].ToString();
            reader2.Close();
            con.Close();

            con.Open();
            str3 = "SELECT (SELECT ISNULL(SUM(Quantity * Rate),0) FROM MilkBuyer WHERE  DATEPART(m, DateTime) <= DATEPART(m, getdate())) + (SELECT ISNULL(SUM(Amount),0) FROM AnimalSale WHERE  DATEPART(m, Date) <= DATEPART(m, getdate())) as Amount";
            comm = new SqlCommand(str3, con);
            SqlDataReader reader3 = comm.ExecuteReader();
            reader3.Read();
            Label3.Text = reader3["Amount"].ToString();
            reader3.Close();
            con.Close();

            con.Open();
            str4 = "SELECT (SELECT ISNULL(SUM(Quantity * Rate),0) FROM MilkBuyer WHERE  DATEPART(m, DateTime) <= DATEPART(m, getdate())) + (SELECT ISNULL(SUM(Amount),0) FROM AnimalSale WHERE  DATEPART(m, Date) <= DATEPART(m, getdate())) - (SELECT SUM(Amount) FROM Expenses WHERE DATEPART(m, Date) <= DATEPART(m, getdate())) - (SELECT ISNULL(SUM(Rate), 0) FROM StockAdd WHERE DATEPART(m, Expiry) <= DATEPART(m, getdate())) as Amount";
            comm = new SqlCommand(str4, con);
            SqlDataReader reader4 = comm.ExecuteReader();
            reader4.Read();
            Label4.Text = reader4["Amount"].ToString();
            reader4.Close();
            con.Close();

        }

        void ShowExpense()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DATENAME(MONTH, Date), SUM(Amount) FROM Expenses GROUP BY DATENAME(MONTH, Date)", con);

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                con.Close();




            }

            String[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);

            }



            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Line;


        }

        void ShowType ()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT et.Type, SUM(Expenses.Amount) AS Total FROM Expense_Type et INNER JOIN Expenses ON et.Type_Id=Expenses.Type_Id GROUP BY et.Type", con);

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                con.Close();




            }

            String[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);

            }



            Chart2.Series[0].Points.DataBindXY(x, y);
            Chart2.Series[0].ChartType = SeriesChartType.Column;
        }

        void showDailyPurchase()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Expiry, ISNULL(SUM(Rate),0) FROM StockAdd GROUP BY (Expiry)", con);

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                con.Close();




            }

            String[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);

            }



            Chart3.Series[0].Points.DataBindXY(x, y);
            Chart3.Series[0].ChartType = SeriesChartType.Column;

        }
    }
}