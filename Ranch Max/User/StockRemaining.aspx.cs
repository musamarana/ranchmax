using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class StockRemaining : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Entities db = new Entities();

            //////////////////// Remaining Stock for Medication  //////////////////

            //FOR TOTAL MEDICAL CONSUMPTION//
            var total_con_med = db.Medications
                   .GroupBy(p => p.StockItem_Id)
                   .Select(g => new { med_stock_Id = g.Key, Qty_Out = g.Sum(x => x.Quantity) });
            //FOR MEDICATION ID//
            var med_id = from a in db.StockItems where a.StockType.TypeName == "Medicine" select new { med_item_id = a.StockItem_Id };


            //FOR SHOWING MEDICINE NAME AND  ITS CONSUMPTION//
            var med_result = from a in total_con_med
                             join b in db.StockItems
                             on a.med_stock_Id equals b.StockItem_Id
                             select new
                             {
                                 medStockId = a.med_stock_Id,
                                 itemName = b.Name,
                                 totalConsumption = a.Qty_Out
                                 //remaining = b.Qty_In - a.total_consumption
                             };

            //SEPARATE MEDICINE STOCK IN DIFFERENT TABLE FRON STOCK TABLE//
            var med_in_total_table = from a in db.StockAdds
                                     join b in med_id
                                     on a.StockItem_Id equals b.med_item_id
                                     select new
                                     {
                                         medStockId = b.med_item_id,
                                         quantity = a.Quantity
                                         //remaining = b.Qty_In - a.total_consumption
                                     };

            //FOR TOTAL IN OF MEDICATIONS//
            var med_total_in = med_in_total_table
                   .GroupBy(p => p.medStockId)
                   .Select(g => new { med_id = g.Key, Qty_In = g.Sum(x => x.quantity) });

            //FOR SHOWING NAME,TOTAL IN ,CONSUMPTION AND REMAINING STOCK//
            var med_in_total_result = from a in med_total_in
                                      join b in med_result
                                     on a.med_id equals b.medStockId
                                      select new
                                      {
                                          Item_Name = b.itemName,
                                          Total_In = a.Qty_In,
                                          Total_Consumption = b.totalConsumption,
                                          Remaining = a.Qty_In - b.totalConsumption
                                      };
            gvMedication.DataSource = med_in_total_result.ToList();
            gvMedication.DataBind();


            ////////////////////////// Remaining Stock for feeding/////////////////////

            //for finding formula count//
            var query = db.FeedConsumptions
                   .GroupBy(p => p.Formula_Id)
                   .Select(g => new { Formula_Id = g.Key, count = g.Count() });

            List<dynamic> myQueryResults = new List<dynamic>();
            foreach (var row in query.ToList())
            {
                myQueryResults.Add(Total_Quantity(row.Formula_Id, row.count));

            }
            //for finding item consumption per formula//
            List<dynamic> myItemConsResults = new List<dynamic>();
            foreach (var q in myQueryResults)
            {
                foreach (var row in q)
                {
                    myItemConsResults.Add(row);
                }
            }
            //for finding per item total consumption//
            var perItemSum = myItemConsResults.GroupBy(r => r.stock_item_id).Select(grp => new { stock_item_id = grp.Key, total_consumption = grp.Sum(g => g.quantity_sum) }).ToList();


            //////total in//////////
            ///

            //FOR feed ID//
            var feed_id = from a in db.StockItems where a.StockType.TypeName == "Feed" select new { feed_item_id = a.StockItem_Id };
            //SEPARATE feed STOCK IN DIFFERENT TABLE FRON STOCK TABLE//
            var feed_in_total_table = from a in db.StockAdds
                                      join b in feed_id
                                      on a.StockItem_Id equals b.feed_item_id
                                      select new
                                      {
                                          feedStockId = b.feed_item_id,
                                          quantity = a.Quantity
                                      };

            //FOR TOTAL IN OF feed//
            var feed_total_in = feed_in_total_table
                   .GroupBy(p => p.feedStockId)
                   .Select(g => new { feed_id = g.Key, Qty_In = g.Sum(x => x.quantity) });

            // for finding feed stock id , total in ,consumption and remaining/// 
            var result = (from a in perItemSum
                          join b in feed_total_in
                          on a.stock_item_id equals b.feed_id
                          select new
                          {
                              ItemId = b.feed_id,
                              totalIn = b.Qty_In,
                              totalConsumption = a.total_consumption,
                              remaining = b.Qty_In - a.total_consumption
                          });

            //for finding feed stock name , total in ,consumption and remaining 

            var result1 = (from a in result
                           join b in db.StockItems
                           on a.ItemId equals b.StockItem_Id
                           select new
                           {
                               Item_Name = b.Name,
                               Total_In = a.totalIn,
                               Total_Consumption = a.totalConsumption,
                               Remaining = a.remaining
                           });




            //var result1 = from b in total_in
            //             join a in perItemSum
            //              on b.stockItemId equals a.stock_item_id
            //              into temp
            //             from a in temp.DefaultIfEmpty()
            //             select new
            //             {
            //                 ItemId = b.stockItemId,
            //                 totalIn = b != null ? b.Qty_In : 0,
            //                 totalConsumption = a != null ? a.total_consumption : 0

            //             };

            gvBalance1.DataSource = result1.ToList();
            gvBalance1.DataBind();

        }


        public dynamic Total_Quantity(int id, int count)
        {
            Entities db = new Entities();

            var q = from f in db.FeedPreparings
                    where f.Formula_Id == id
                    group f by f.StockItem_Id into g
                    select new
                    {
                        stock_item_id = g.Key,
                        formula_id = g.Select(x => x.Formula_Id),
                        quantity_sum = g.Sum(x => x.Quantity * count)
                    };
            return q;


        }

    }
}