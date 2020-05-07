using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace Ranch_Max
{
    public partial class Milk_Detail : System.Web.UI.Page
    {

        ////private SqlConnection con;
        ////private SqlCommand com;
        ////private string constr, query;
        ////private void connection()
        ////{
        ////    constr = ConfigurationManager.ConnectionStrings[@"Data Source=ALEE-PC\SQLEXPRESS;Initial Catalog=fyp;Integrated Security=True"].ToString();
        ////    con = new SqlConnection(constr);
        ////    con.Open();

        ////}

        SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947");
        string str, str2, str3,str4;

        protected void Chart1_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Chart2.Visible = true;
            Chart1.Visible = false;
            Chart3.Visible = false;
            showChart2();
            try
            {
                int var = int.Parse(txtAnimal.Text);
            }
            catch (Exception eu)
            {
                Label4.Text = "Ear Tag not entered.";
            }
            con.Open();
            str4 = "SELECT SUM(Amount_Ltr)  as 'Total' FROM Milking AS m INNER JOIN Animal AS a " +
               "ON m.Animal_Id=a.Animal_Id WHERE a.EarTag=" + txtAnimal.Text + "";
            comm = new SqlCommand(str4, con);
            SqlDataReader reader3 = comm.ExecuteReader();

            reader3.Read();
            Label4.Text = reader3["Total"].ToString();


            reader3.Close();
            con.Close();
            txtAnimal.Text = "";
        }

        SqlCommand comm;

        protected void Page_Load(object sender, EventArgs e)
        {
            Chart2.Visible = false;
            if (!IsPostBack)
            {
                showChart();
                showChart3();
            }

            con.Open();
            str = "SELECT ISNULL(SUM(Amount_Ltr),0)  as 'Total' FROM Milking";
            comm = new SqlCommand(str, con);
            SqlDataReader reader = comm.ExecuteReader();

            reader.Read();
            Label1.Text = reader["Total"].ToString();


            reader.Close();
            con.Close();

            con.Open();

            str2 = "SELECT COUNT(Animal_Id) as 'Dry' FROM DryPeriod WHERE EndDate IS NULL";
            //str2 = "SELECT COUNT(DryPeriod) as 'Dry' FROM Animal WHERE dry_period = 'no'; ";
            comm = new SqlCommand(str2, con);
            SqlDataReader reader1 = comm.ExecuteReader();

            reader1.Read();
            Label2.Text = reader1["Dry"].ToString();
            reader1.Close();
            con.Close();

            con.Open();
            str3 = "SELECT ISNULL(SUM(Amount_Ltr),0) as 'Amount' FROM Milking WHERE Date >= CAST(GETDATE() as date)";
            comm = new SqlCommand(str3, con);
            SqlDataReader reader2 = comm.ExecuteReader();

            reader2.Read();
            Label3.Text = reader2["Amount"].ToString();
            reader2.Close();
            con.Close();
            
            

        }

        void showChart()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Date, SUM(Amount_Ltr) FROM Milking GROUP BY (Date)  ", con);
                  
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


            //String[] u = new string[dt.Columns.Count];
            //int[] v = new int[dt.Columns.Count];

            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    u[i] = dt.Columns[i].ToString();
            //    v[i] = Convert.ToInt32(dt.Columns[i]);

            //}



            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.StackedColumn;

        }

        void showChart3()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DATENAME(MONTH, Date), ISNULL(SUM(Amount_Ltr),0) FROM Milking GROUP BY DATENAME(MONTH, Date)", con);

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


            //String[] u = new string[dt.Columns.Count];
            //int[] v = new int[dt.Columns.Count];

            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    u[i] = dt.Columns[i].ToString();
            //    v[i] = Convert.ToInt32(dt.Columns[i]);

            //}



            Chart3.Series[0].Points.DataBindXY(x, y);
            Chart3.Series[0].ChartType = SeriesChartType.StackedColumn;


        }


        void showChart2()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand( "SELECT Date, ISNULL(SUM(Amount_Ltr),0)  FROM Milking AS m INNER JOIN Animal AS a " +
                "ON m.Animal_Id=a.Animal_Id WHERE a.EarTag=" + txtAnimal.Text +" GROUP BY Date", con);

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
            Chart2.Series[0].ChartType = SeriesChartType.StackedColumn;

        }


    }
}



//private void Bindchart()
//{
//       // DataTable dt = new DataTable();
//        //using (SqlConnection con = new SqlConnection(@"Data Source=SUBHAN-PC\SQLEXPRESS;Initial Catalog=DefaultConnection;Integrated Security=True"))
//        {
//            //con.Open();
//            ////SqlCommand cmd = new SqlCommand("SELECT SUM(Amount_Ltr) FROM Milking WHERE GROUP BY (Date)   ", con);
//            //SqlCommand cmd = new SqlCommand("SELECT Date, (Amount_Ltr)" +
//            //   " as 'Amount' FROM Milking", con);
//            //SqlDataAdapter adpt = new SqlDataAdapter(cmd);
//            //adpt.Fill(dt);
//            //con.Close();




//        }

//        DataTable ChartData = new DataTable();
//        using (SqlConnection con = new SqlConnection(@"Data Source=ALEE-PC\SQLEXPRESS;Initial Catalog=fyp;Integrated Security=True"))
//        {
//            comm = new SqlCommand("SELECT Date, (Amount_Ltr)" +
//          " as 'Amount' FROM Milking", con);
//            //  comm.CommandType = CommandType.StoredProcedure;
//            SqlDataAdapter da = new SqlDataAdapter(comm);
//            //     DataSet ds = new DataSet();
//            da.Fill(ChartData);

//        }

//    //storing total rows count to loop on each Record  
//    string[] XPointMember = new string[ChartData.Rows.Count];
//    double[] YPointMember = new double[ChartData.Rows.Count];

//    for (int count = 0; count < ChartData.Rows.Count; count++)
//    {
//        //storing Values for X axis  
//        XPointMember[count] = ChartData.Rows[count]["Date"].ToString();
//        //storing values for Y Axis  
//        YPointMember[count] = Convert.ToDouble(ChartData.Rows[count]["Amount_Ltr "]);


//    }
//    //binding chart control  
//    Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);

//    //Setting width of line  
//    Chart1.Series[0].BorderWidth = 10;
//    //setting Chart type   
//    Chart1.Series[0].ChartType = SeriesChartType.Column;
//    //Chart1.Series[0].ChartType = SeriesChartType.StackedColumn;  

//    //Hide or show chart back GridLines  
//    Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
//    Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

//    //Enabled 3D  
//    //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;  
//    con.Close();

//}


//}











/// <summary>
/// /////////////////////EXTRA MATERIAL///////////////////////////
/// </summary>


//void showChart()
//{
//    DataTable dt = new DataTable();
//    /*using (Entities db = new Entities()) {

//        var  query = db.Milkings.SqlQuery("SELECT Date, (Amount_Ltr) " +
//            "as 'Amount' FROM Milking").ToList<Milking>();
//        SqlCommand cmd  = new SqlCommand(query);
//     }

//    String[] x = new string[dt.Rows.Count];
//    int[] y = new int[dt.Rows.Count];

//    for (int i = 0; i < dt.Rows.Count; i++)
//    {
//        x[i] = dt.Rows[i][0].ToString();
//        y[i] = Convert.ToInt32(dt.Rows[i][1]);

//    }*/

//    //Chart1.Series[0].Points.DataBindXY(x, y);
//    //Chart1.Series[0].ChartType = SeriesChartType.StackedColumn;

//    using (SqlConnection con = new SqlConnection(@"Data Source=ALEE-PC\SQLEXPRESS;Initial Catalog=fyp;Integrated Security=True"))
//    {
//        con.Open();
//        SqlCommand cmd = new SqlCommand("SELECT Date, (Amount_Ltr)" +
//            " as 'Amount' FROM Milking", con);
//        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
//        adpt.Fill(dt);
//        con.Close();
//    }

//    String[] x = new string[dt.Rows.Count];
//    int[] y = new int[dt.Rows.Count];

//    for (int i = 0; i < dt.Rows.Count; i++)
//    {
//        x[i] = dt.Rows[i][0].ToString();
//        y[i] = Convert.ToInt32(dt.Rows[i][1]);

//    }

//    //Chart1.Series[0].Points.DataBindXY(x, y);
//    //Chart1.Series[0].ChartType = SeriesChartType.StackedColumn;

//    /*using (Entities db = new Entities())
//    {
//        var query = db.Milkings
//           .GroupBy(p => p.Date)
//           .Select(g => new { Milking_Date = g.Key, count = g.Count() });

//        String temp = "";
//        string temp1 = "";
//        dynamic query1;
//        ArrayList l = new ArrayList();
//        foreach (var row in query.ToList())
//        {
//            temp += DateTime.Parse(row.Milking_Date.ToString()) + " " + row.count + "  ---  ";
//            query1 = db.Milkings
//           .Where(m => m.Date == row.Milking_Date)
//           .Select(m => new { amount_ltr = m.Amount_Ltr, date = m.Date });
//            //temp1 += query1.amount_ltr + " " + query1.date + "----";

//            l.Add(l);

//        }
//        foreach(var l_query in l)
//        {

//        }
//    }*/









