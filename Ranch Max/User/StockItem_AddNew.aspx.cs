using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class StockItem_AddNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Entities db = new Entities();
            var query = db.FeedConsumptions
                   .GroupBy(p => p.Formula_Id)
                   .Select(g => new { Formula_Id = g.Key, count = g.Count() });
            String temp = "";
            foreach (var row in query.ToList())
            {
                temp +=  row.Formula_Id + " " + row.count+"  ---  ";

            }
            Label1.Text = temp;
            Total_Quantity(0, 2);

        }
        public void Total_Quantity(int id, int count)
        {
            Entities db = new Entities();
            /*var query = db.FeedPreparings
                   //.GroupBy(p => p.Formula_Id)
                   .Where(f=> f.Formula_Id == id)
                   .Select(g => new { Formula_Id = g.Key, count = g.Count(),  });*/

            var q = from f in db.FeedPreparings
                    where f.Formula_Id == id
                    group f by f.Formula_Id into g
                    select new { formula_id = g.Key, stock_item_id = g.Select(x => x.StockItem_Id),
                        quantity_sum = g.Sum(x => x.Quantity * count) };
            var temp = "";
            foreach(var row in q)
            {
                temp += row.formula_id + " " + row.stock_item_id + row.quantity_sum +"  ---  ";
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
           //for per formula rate
            var perFormulaRate= db.FeedPreparings
                   .GroupBy(p => p.Formula_Id)
                   .Select(g => new { formula_Id = g.Key, rate = g.Sum(x => x.Rate) });

        }
    }
}