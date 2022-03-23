using Eshop.Models.Domain;
using Eshop.Models.Repository;
using Eshop.Models.Struct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshop
{
    public class HomeController : Controller
    {
        // GET: Home
        DataBase db = new DataBase();
        UtilityFuncs utility = new UtilityFuncs();

        RepositoryProduct Rep_Product = new RepositoryProduct();

        public object FirstOrDefault { get; private set; }
        public int UserName { get; private set; }

        public ActionResult Index()

        {
            ViewBag.LoginMessage = TempData["LoginMessage"] != null ? TempData["LoginMessage"].ToString() : "";
            ViewBag.LoginStyle = TempData["LoginStyle"] != null ? TempData["LoginStyle"].ToString() : "";

            //Session["UserName"] = "Seller";
            return View(Rep_Product.GetListproduct());
        }


        public ActionResult SearchByTitle(string Title = "", int page = 1)
        {

            if (Title == "")
            {
                return RedirectToAction("index");
            }
            var q = from a in db.Tbl_Products
                    where a.Title.Contains(Title)
                    select a;
            // paging

            return View(q);
        }

        public ActionResult Search(List<int> FilterItem, decimal MinPrice = 0, decimal MaxPrice = 0, int TopicId = 0, int page = 1)
        {
            List<Tbl_Products> LstProducts = new List<Tbl_Products>();
            if (TopicId == 0)
                return RedirectToAction("Index");




            if (/*FilterItem.Count() > 0 &&*/ FilterItem != null)
            {

                var q = (from a in db.Tbl_Products
                         join b in db.Tbl_Filters_Products on a.ID equals b.ProductID
                         where a.TopicID == TopicId
                         select b).ToList();

                foreach (var item in FilterItem)
                {
                    var q2 = (from a in q
                              where a.FilterID == item
                              select a);
                    if (q2 != null)
                        foreach (var item2 in q2)
                        {
                            if (!LstProducts.Contains(item2.Tbl_Products))
                                LstProducts.Add(item2.Tbl_Products);
                        }

                }

            }
            else
            {
                var q = from a in db.Tbl_Products
                        where a.TopicID == TopicId
                        select a;
                LstProducts.AddRange(q);
            }


            if (MinPrice > 100 && MaxPrice > 1000)
            {
                List<Tbl_Products> Lstp = new List<Tbl_Products>();
                Lstp.AddRange(from a in LstProducts
                              where a.Price >= MinPrice && a.Price <= MaxPrice
                              select a);


                LstProducts.Clear();
                LstProducts.AddRange(Lstp);
            }

            ViewBag.TopicID = TopicId;
            ViewBag.MinPrice = MinPrice <= 0 ? "1000" : MinPrice.ToString();
            ViewBag.MaxPrice = MaxPrice <= 0 ? "" : MaxPrice.ToString();
            ViewBag.FilterItem = FilterItem == null ? new List<int> { 0 } : FilterItem;



            int Take = db.Tbl_Setting.Select(a => a.CountProductInPage).FirstOrDefault();

            int Countproduct = LstProducts.Count;

            int skip = (Take * page) - Take;

            ViewBag.CountProduct = Countproduct;
            ViewBag.Take = Take;

            return View(LstProducts.OrderBy(a => a.ID).Skip(skip).Take(Take));
        }
        public ActionResult Products(int ID)
        {
            var q = from a in db.Tbl_Products
                    where a.ID == ID
                    select a;

            return View(q.SingleOrDefault());
        }

        [HttpPost]
        public ActionResult InsertComment(Tbl_Comment t)
        {
            try
            {

                t.Confirm_comm = false;
                t.Date = DateTime.Now;
                t.Ip = Request.UserHostAddress.ToString();

                t.ParentID = t.ParentID == 0 ? 1 : t.ParentID;

                db.Tbl_Comment.Add(t);
                db.SaveChanges();


                if (t.ParentID == 0)
                {
                    var q = (from a in db.Tbl_Comment
                             orderby a.ID descending
                             select a).FirstOrDefault();


                    q.ParentID = q.ID;
                    db.Tbl_Comment.Attach(q);
                    db.Entry(q).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }



                return RedirectToAction("Products", t.ProductID);

            }
            catch (Exception e)
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            if (Session["UserName"] == null)
            {


                var q = (from a in db.Tbl_Users
                         where a.UserName.Equals(UserName) && a.Password.Equals(Password) && a.Access.Equals("Seller") && a.Status == true
                         select a).SingleOrDefault();

                if (q != null)
                {
                    Session["UserName"] = q.UserName;
                    Session["Access"] = q.Access;

                    return RedirectToAction("index", "User");
                }
                else
                {
                    TempData["LoginMessage"] = "نام کاربری یا کلمه عبور اشتباه است";
                    TempData["LoginStyle"] = "color:red";

                    return RedirectToAction("index");
                }

            }
            else
            {
                return RedirectToAction("Index", "User");

            }
        }
        [HttpPost]
        public string Offer(int Price, int ProductID)
        {
            if (Session["UserName"] != null)
            {
                string UserName = Session["UserName"].ToString();
                var q = (from a in db.Tbl_Auctions
                         where a.ProductID.Equals(ProductID) && a.Tbl_Users.UserName.Equals(UserName)
                         select a).SingleOrDefault();


                if (q != null)
                {
                    //در حالتی که کاربر قبلا پیشنهاد ثیت کرده
                    var qMax = db.Tbl_Auctions.Where(a => a.ProductID.Equals(ProductID)).OrderByDescending(a => a.Price).FirstOrDefault().Price;

                    if (qMax < Price)
                    {
                        q.Price = Price;
                        db.Tbl_Auctions.Attach(q);
                        db.Entry(q).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                else
                {
                    //در حالتی که کاربر پیشنهاد ثبت نکرده
                    var qPrice = db.Tbl_Products.Where(a => a.ID.Equals(ProductID)).SingleOrDefault();

                    if (Price > qPrice.Price)

                    {
                        Tbl_Auctions t = new Tbl_Auctions();
                        t.Confirm_Price = false;
                        t.Price = Price;
                        t.ProductID = ProductID;
                        t.UserID = db.Tbl_Users.Where(a => a.UserName.Equals(UserName)).SingleOrDefault().ID;
                        db.Tbl_Auctions.Add(t);
                        db.SaveChanges();

                    }
                }

                string li = "";
                var qOfferList = from a in db.Tbl_Auctions
                                 where a.ProductID.Equals(ProductID)
                                 orderby a.Price descending
                                 select a;
                foreach (var item in qOfferList)
                {
                    li += "<li>" + item.Price + "<li>";

                }
                return li;
            }

            return "";

        }

        [HttpPost]

        public JsonResult AddToCart(int ProductID = 0, int count = 1)
        {
            if (Session["UserName"] != null)
            {

                if (ProductID == 0)
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }
                string UserName = Session["UserName"].ToString();

                Tbl_ShopingCart t = new Tbl_ShopingCart();

                t.Count = count;
                t.Date = DateTime.Now;
                t.ProductID = ProductID;
                t.UserID = db.Tbl_Users.Where(a => a.UserName.Equals(UserName)).SingleOrDefault().ID;

                db.Tbl_ShopingCart.Add(t);
                db.SaveChanges();

                var q = from a in db.Tbl_ShopingCart
                        where a.Tbl_Users.UserName.Equals(UserName) && a.Status == false
                        select a;





                ShopingCart c = new ShopingCart();
                c.Count = q.Count();
                foreach (var item in q)
                {
                    c.GheymatKol += item.Tbl_Products.Price * item.Count;
                }

                List<Tbl_Cart> LstCart = new List<Tbl_Cart>();
                foreach (var item in q)
                {
                    Tbl_Cart tc = new Tbl_Cart();
                    tc.id = item.ID;
                    tc.Count = item.Count.ToString();
                    tc.Price = (item.Count * item.Tbl_Products.Price).ToString();
                    tc.ProductName = item.Tbl_Products.Title;
                    LstCart.Add(tc);
                }

                c.LstCart = LstCart;



                return Json(c, JsonRequestBehavior.AllowGet);

            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetCart()
        {
            if (Session["UserName"] != null)
            {
                string UserName = Session["UserName"].ToString();
                var q = from a in db.Tbl_ShopingCart
                        where a.Tbl_Users.UserName.Equals(UserName) && a.Status == false
                        select a;


                ShopingCart c = new ShopingCart();
                c.Count = q.Count();
                foreach (var item in q)
                {
                    c.GheymatKol += item.Tbl_Products.Price * item.Count;
                }

                List<Tbl_Cart> LstCart = new List<Tbl_Cart>();
                foreach (var item in q)
                {
                    Tbl_Cart tc = new Tbl_Cart();
                    tc.id = item.ID;
                    tc.Count = item.Count.ToString();
                    tc.Price = (item.Count * item.Tbl_Products.Price).ToString();
                    tc.ProductName = item.Tbl_Products.Title;
                    LstCart.Add(tc);
                }

                c.LstCart = LstCart;



                return Json(c, JsonRequestBehavior.AllowGet);
            }
            return Json("");

        }

        public JsonResult DeleteCart(int id)
        {

            if (Session["UserName"] != null)
            {

                string UserName = Session["UserName"].ToString();

                db.Tbl_ShopingCart.Remove(db.Tbl_ShopingCart.Where(a => a.ID.Equals(id) && a.Tbl_Users.UserName.Equals(UserName)).SingleOrDefault());
                db.SaveChanges();

                var q = from a in db.Tbl_ShopingCart
                        where a.Tbl_Users.UserName.Equals(UserName) && a.Status == false
                        select a;


                ShopingCart c = new ShopingCart();
                c.Count = q.Count();
                foreach (var item in q)
                {
                    c.GheymatKol += item.Tbl_Products.Price * item.Count;
                }

                List<Tbl_Cart> LstCart = new List<Tbl_Cart>();
                foreach (var item in q)
                {
                    Tbl_Cart tc = new Tbl_Cart();
                    tc.id = item.ID;
                    tc.Count = item.Count.ToString();
                    tc.Price = (item.Count * item.Tbl_Products.Price).ToString();
                    tc.ProductName = item.Tbl_Products.Title;
                    LstCart.Add(tc);
                }

                c.LstCart = LstCart;



                return Json(c, JsonRequestBehavior.AllowGet);
            }

            return Json("");
        }

        public ActionResult Payment()
        {
            if (Session["UserName"] != null)
            {
                string UserName = Session["UserName"].ToString();
                var q = from a in db.Tbl_ShopingCart
                        where a.Status == false && a.Tbl_Users.UserName.Equals(UserName)
                        select a;

                double Price = 0;
                foreach (var item in q)
                {
                    Price += (item.Tbl_Products.Price * item.Count);
                }

                if (Price >= 1000)
                {
                    PayLine Pay = new PayLine();
                    double amount = Price;
                    string result = Pay.Send("https://payline.ir/payment-test/gateway-send", "adxcv-zzadq-polkjsad-opp13opoz-1sdf455aadzmck1244567", amount, "http://localhost:44355/Home/PaymentComplete");
                    if (int.Parse(result) > 0)
                    {
                        List<Tbl_TempSales> LstTempShoping = new List<Tbl_TempSales>();
                        foreach (var item in q)
                        {
                            Tbl_TempSales t = new Tbl_TempSales();
                            t.ShopingCart_ProductID = item.ID;
                            t.BankGetNo = result;
                            t.Date = DateTime.Now;
                            t.Status = false;
                            LstTempShoping.Add(t);

                        }
                        db.Tbl_TempSales.AddRange(LstTempShoping.AsEnumerable());
                        db.SaveChanges();

                        //انتقال کاربر به صفحه پرداخت
                        Response.Redirect("https://payline.ir/payment-test/gateway-" + result);
                    }
                    else
                    {
                        //if -1 or -2 or -3 or -4 
                        //Can use swich case For Reports
                        Response.Write("Not Valid");

                    }
                }

                else
                {

                }

            }
            else
            {
                //پیغام مبنی بر لاگین نبودن کاربر
                return View();

            }

            return View();

        }
        [HttpPost]
        public ActionResult PaymentComplete(string trans_id, string id_get)
        {
            if (Session["UserName"] != null)
            {

                string UserName = Session["UserName"].ToString();

                PayLine GetPayline = new PayLine();

                //GetPayline.Get(url,"Your-API", trans_id, id_get)
                string result = GetPayline.Get("https://payline.ir/payment-test/gateway-result-second", "adxcv-zzadq-polkjsad-opp13opoz-1sdf455aadzmck1244567", trans_id, id_get);
                if (int.Parse(result) > 0)
                {

                    //ثبت محصولات بعد از پرداخت کامل

                    var q = from a in db.Tbl_TempSales
                            where a.BankGetNo.Equals(id_get)
                            select a;

                    foreach (var item in q)
                    {
                        item.Status = true;
                        db.Tbl_TempSales.Attach(item);
                        db.Entry(item).State = System.Data.Entity.EntityState.Modified;

                    }

                    db.SaveChanges();
                    List<Tbl_Sales> LstSalest = new List<Tbl_Sales>();
                    foreach (var item in q)
                    {
                        Tbl_Sales t = new Tbl_Sales();
                        t.CodeRahgiri = "";
                        t.Count = item.Tbl_ShopingCart.Count;
                        t.Date = DateTime.Now;
                        t.GroupNo = 0;
                        t.Payment = true;
                        t.Price = (item.Tbl_ShopingCart.Tbl_Products.Price * item.Tbl_ShopingCart.Count);
                        t.ProductID = item.Tbl_ShopingCart.ProductID;
                        t.StatusID = 1;
                        //t.TransNo= trans_id;
                        t.UserID = item.Tbl_ShopingCart.UserID;
                        LstSalest.Add(t);
                    }


                    db.Tbl_Sales.AddRange(LstSalest.AsEnumerable());
                    db.SaveChanges();

                    List<int> LstShopingCartID = new List<int>();

                    foreach (var item in q)
                    {
                        //db.Tbl_ShopingCart.Remove(item.Tbl_ShopingCart);
                        LstShopingCartID.Add(item.ShopingCart_ProductID);
                        //db.Tbl_TempSales.Remove(item);
                        //db.Tbl_TempSales.RemoveRange(db.Tbl_TempSales.Where(a => a.Status == false && a.Tbl_ShopingCart.Tbl_Users.UserName.Equals(UserName)));
                        //db.SaveChanges();


                    }

                    foreach (var item in LstShopingCartID)
                    {
                        db.Tbl_ShopingCart.Remove(db.Tbl_ShopingCart.Where(a => a.ID.Equals(item)).SingleOrDefault());
                        //db.Tbl_TempSales.Remove(item);
                        db.SaveChanges();


                    }



                    var qSales = db.Tbl_Sales.Where(a => a.TransNo.Equals(trans_id));
                    return View(qSales);

                }
                else
                {
                    //زمانی که کاربر لاگین نکرده
                    return View();
                }
            }
            else
            {
                //خطا در صورنی که متغیر ها ولید نباشند
            }
            return View();

        }

        [HttpGet]

        public ActionResult ContactUs()
        {
            return View();

        }


        [HttpPost]

        public ActionResult ContactUs(Tbl_ContactUs t)
        {
            if (ModelState.IsValid)
            {
                t.Date = DateTime.Now;
                t.IP = Request.UserHostAddress;
                t.Read = false;

                db.Tbl_ContactUs.Add(t);
                if (Convert.ToBoolean(db.SaveChanges()))
                {

                    ViewBag.Message = "با موفقیت ثبت شد";
                    ViewBag.style = "color:green;";
                    return View();
                }
                else
                {
                    ViewBag.Message = "ثبت نشد";
                    ViewBag.style = "color:red;";
                    return View();
                }


            }

            else
            {
                ViewBag.Message = "نمامی فیلد ها را به درستی وارد نمایید";
                ViewBag.style = "color:red;";
                return View();
            }

        }
        [HttpGet]
        public ActionResult Register()
        {


            if (Session["UserName"] == null)

                return View();
            else

                return RedirectToAction("Index", "User");

        }

        [HttpPost]

        public ActionResult Register(Tbl_Users t, HttpPostedFileBase ProfileImage)
        {
            if (Session["UserName"] == null)
            {
                t.Access = "Seller";
                t.Date = DateTime.Now;
                t.Status = false;
                if (ModelState.IsValid)
                {
                    if (ProfileImage != null)
                    {
                        if (ProfileImage.ContentLength > 512000)
                        {
                            ViewBag.Message = "حجم تصویر نباید بیشتر از 512 کیلوبایت باشد";
                            ViewBag.style = "color:red;";
                            return View();
                        }
                        if (ProfileImage.ContentType != "image/jpeg")
                        {
                            ViewBag.Message = "قالب تصویر باید jpg باشد";
                            ViewBag.style = "color:red;";
                            return View();
                        }
                        Random rnd = new Random();
                        string RndFileName = rnd.Next().ToString() + ".jpg";
                        ProfileImage.SaveAs(Path.Combine(Server.MapPath("~") + "Content/Pics/Users/" + RndFileName));
                        t.Image = RndFileName; 
                    }

                    db.Tbl_Users.Add(t);

                   

                    if (Convert.ToBoolean(db.SaveChanges()))

                    {
                        Tbl_ConfEmail confEmail = new Tbl_ConfEmail();
                        confEmail.UserID = db.Tbl_Users.OrderByDescending(a => a.ID).FirstOrDefault().ID;
                        confEmail.Date = DateTime.Now;
                        confEmail.DateExpire = confEmail.Date.AddDays(3);
                        db.Tbl_ConfEmail.Add(confEmail);


                        Tbl_ConfMobile tm = new Tbl_ConfMobile();
                        tm.Date = DateTime.Now;
                        tm.DateExpire = DateTime.Now.AddDays(3);
                        tm.Status = false;
                        tm.UserID= db.Tbl_Users.OrderByDescending(a => a.ID).FirstOrDefault().ID;
                        db.Tbl_ConfMobile.Add(tm);


                        db.SaveChanges();

                        //ارسال ایمیل به کاربر
                       utility.SendEmail(db.Tbl_Setting.FirstOrDefault().SMTP, db.Tbl_Setting.FirstOrDefault().Email, db.Tbl_Setting.FirstOrDefault().EmailPass, t.Email, "تایید حساب در سایت شبه ایسام", "برای تایید حساب در سایت از لینک زیر استفاده نمایید: <br/> <a href='https://localhost:44355/Home/confEmail?code=" + db.Tbl_ConfEmail.OrderByDescending(a => a.ID).FirstOrDefault().ID + "'>لینک فعال سازی</a>");

                        // ارسال sms  به کاربر

                        utility.SendSms(t.Mobile, "کد فعال سازی در سایت شبه ایسام:" + db.Tbl_ConfEmail.OrderByDescending(a => a.ID).FirstOrDefault().ID,"09394001118","377096","377096");

                        ViewBag.Message = "با موفقیت ثبت شد";
                        ViewBag.style = "color:green;";
                        return View();
                    }
                    else
                    {
                        ViewBag.Message = "متاسفانه ثبت نشد";
                        ViewBag.style = "color:red;";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "تمامی فیلد ها را به درستی وارد نمایید";
                    ViewBag.style = "color:red;";
                    return View();
                }

            }

            else
                return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public JsonResult DuplicateUserName(string UserName)
        {
            try
            {

                var q = from a in db.Tbl_Users
                        where a.UserName.Equals(UserName)
                        select a;

                if (q.SingleOrDefault() != null)
                    return Json(false, JsonRequestBehavior.DenyGet);

                else
                    return Json(true, JsonRequestBehavior.DenyGet);


            }
            catch
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public JsonResult DuplicateEmail(string Email)
        {
            try
            {

                var q = from a in db.Tbl_Users
                        where a.Email.Equals(Email)
                        select a;

                if (q.SingleOrDefault() != null)
                    return Json(false, JsonRequestBehavior.DenyGet);

                else
                    return Json(true, JsonRequestBehavior.DenyGet);


            }
            catch
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }



        public JsonResult DuplicateMobile(string Mobile)
        {
            try
            {

                var q = from a in db.Tbl_Users
                        where a.Mobile.Equals(Mobile)
                        select a;

                if (q.SingleOrDefault() != null)
                    return Json(false, JsonRequestBehavior.DenyGet);

                else
                    return Json(true, JsonRequestBehavior.DenyGet);


            }
            catch
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult confEmail(int code=0)
        {
            if (code == 0)
                return RedirectToAction("Index", "Home");

            DateTime DtNow = DateTime.Now;
            var q = (from a in db.Tbl_Users
                    join b in db.Tbl_ConfEmail on a.ID equals b.UserID
                    where b.ID.Equals(code) && b.Date < b.DateExpire && a.Status==false
                    select b).SingleOrDefault();

            if(q==null)
                return RedirectToAction("Index", "Home");

            else
            {
                q.Status = true;

                db.Tbl_ConfEmail.Attach(q);
                db.Entry(q).State = System.Data.Entity.EntityState.Modified;

                var qMobile= (from a in db.Tbl_Users
                         join b in db.Tbl_ConfMobile on a.ID equals b.UserID
                         where b.Status==true
                         select b).SingleOrDefault();

                if (qMobile !=null)
                {

                    var qUser = (from a in db.Tbl_Users
                             join b in db.Tbl_ConfEmail on a.ID equals b.UserID
                             where b.ID.Equals(code) && b.Date < b.DateExpire && a.Status == false
                             select a).SingleOrDefault();

                    qUser.Status = true;
                    db.Tbl_Users.Attach(qUser);
                    db.Entry(qUser).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
                ViewBag.Message = "با موفقیت فعال شد";
                ViewBag.style = "color:green;";
                return View();
            }

        }
        [HttpGet]
        public ActionResult ConfMobile()
        {
            return View();
        }

        [HttpPost]

        public ActionResult ConfMobile(int Code = 0)
        {
            if (Code == 0)
                return RedirectToAction("Index", "Home");
            DateTime DtNow = DateTime.Now;
            var q = (from a in db.Tbl_Users
                     join b in db.Tbl_ConfMobile on a.ID equals b.UserID
                     where b.ID.Equals(Code) && b.Date < b.DateExpire && a.Status == false
                     select b).SingleOrDefault();


            if (q == null)
                return RedirectToAction("Index", "Home");
            else
            {
                q.Status = true;
                db.Tbl_ConfMobile.Attach(q);
                db.Entry(q).State = System.Data.Entity.EntityState.Modified;

                var qEmail = (from a in db.Tbl_Users
                              join b in db.Tbl_ConfEmail on a.ID equals b.UserID
                              where b.Status == true
                              select b).SingleOrDefault();

                if (qEmail != null)
                {
                    var qUser = (from a in db.Tbl_Users
                                 join b in db.Tbl_ConfMobile on a.ID equals b.UserID
                                 where b.ID.Equals(Code) && b.Date < b.DateExpire && a.Status == false
                                 select a).SingleOrDefault();
                    qUser.Status = true;
                    db.Tbl_Users.Attach(qUser);
                    db.Entry(qUser).State = System.Data.Entity.EntityState.Modified;

                }

                db.SaveChanges();
                ViewBag.Message = "با موفقیت فعال شد";
                ViewBag.style = "color:green;";
                return View();
            }
        }

    }

}
