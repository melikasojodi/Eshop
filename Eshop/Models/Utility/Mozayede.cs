using Eshop.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public static class Mozayede
{
    public static void PayanMozayede()
    {
        DataBase db = new DataBase();

        var q = from a in db.Tbl_Products
                where a.DateEnd != null
                select a;

        List<Tbl_Sales> LstSales = new List<Tbl_Sales>();
        List<Tbl_Messages> LstMessage = new List<Tbl_Messages>();
        List<Tbl_Auctions> LstAuc = new List<Tbl_Auctions>();

        foreach (var item in q.Where(a => a.DateEnd < DateTime.Now))
        {
            var MaxPrice = item.Tbl_Auctions.OrderByDescending(a => a.Price).FirstOrDefault();
            if (MaxPrice != null)
            {

                Tbl_Sales ts = new Tbl_Sales();

                ts.CodeRahgiri = "";
                ts.Count = 1;
                ts.Date = DateTime.Now;
                ts.GroupNo = 0;
                ts.Payment = false;
                ts.Price = MaxPrice.Price;
                ts.ProductID = MaxPrice.ProductID;
                ts.StatusID = 1;
                ts.TransNo = 0;
                ts.UserID = MaxPrice.UserID;


                LstSales.Add(ts);
              

                foreach (var itemTemp in item.Tbl_Auctions)
                {
                    Tbl_Messages tm = new Tbl_Messages();
                    if (itemTemp.ID == MaxPrice.ID)
                        tm.Message = " با سلام. <br/> شما در مزایده برای محصول : " + item.Title + "برنده شدید لطفا سریع تر عملیات پرداخت را انجام دهید";

                    else
                        tm.Message = "سلام.<br/> شما در مزایده برای محصول : " + item.Title + "برنده نشدید";

                    tm.Date = DateTime.Now;
                    tm.Read = false;
                    tm.Title = "پیام سیستمی";
                    tm.UserGet = itemTemp.UserID;
                    tm.UserSend = null;

                    LstMessage.Add(tm);


                    LstAuc.Add(itemTemp);
                }

            }

        }
        db.Tbl_Sales.AddRange(LstSales.AsEnumerable());
        db.Tbl_Messages.AddRange(LstMessage.AsEnumerable());
        db.Tbl_Auctions.RemoveRange(LstAuc.AsEnumerable());

        db.SaveChanges();

        db = null;
        q = null;
    }

}
