using Eshop.Models.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc;
using CaptchaMvc.HtmlHelpers;

namespace Eshop.Controllers
{
    public class UserController : Controller
    {
        // GET: User



        DataBase db = new DataBase();
        private Tbl_Filters_Products q2;

        public bool ProfilePic { get; private set; }
        public object Reguest { get; private set; }
        public object ProductID { get; private set; }

        public ActionResult Index()
        {
            if (Session["UserName"] != null)

                return View();

            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            Session["Access"] = null;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            if (Session["UserName"] != null)
            {
                string UserName = Session["UserName"].ToString();

                return View(db.Tbl_Users.Where(a => a.UserName.Equals(UserName)).SingleOrDefault());

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public ActionResult EditProfile(Tbl_Users t, HttpPostedFileBase ProfilePic)
        {

            if (Session["UserName"] != null)
            {
                string UserName = Session["UserName"].ToString();

                var q = db.Tbl_Users.Where(a => a.UserName.Equals(UserName)).SingleOrDefault();

                q.Address = t.Address;
                q.BankName = t.BankName;
                q.City = t.City;
                q.Name = t.Name;
                q.NatCode = t.NatCode;
                q.Password = t.Password;
                q.phone = t.phone;
                q.PostalCode = t.PostalCode;
                q.ShabaNo = t.ShabaNo;
                q.Shire = t.Shire;

                if (ProfilePic != null)
                {
                    if (ProfilePic.ContentLength > 512000)
                    {
                        ViewBag.Message = "حجم تصویر نباید بیشتر از 512 کیلوبایت باشد";
                        ViewBag.style = "color:red;";
                        return View(q);
                    }
                    if (ProfilePic.ContentType != "image/jpeg")
                    {
                        ViewBag.Message = "قالب تصویر باید jpg باشد";
                        ViewBag.style = "color:red;";
                        return View(q);
                    }
                    Random rnd = new Random();
                    string RndFileName = rnd.Next().ToString() + ".jpg";
                    ProfilePic.SaveAs(Path.Combine(Server.MapPath("~") + "Content/Pics/Users/" + RndFileName));
                    q.Image = RndFileName;
                }



                db.Tbl_Users.Attach(q);
                db.Entry(q).State = System.Data.Entity.EntityState.Modified;
                if (Convert.ToBoolean(db.SaveChanges()))
                {
                    ViewBag.Message = "با موفقیت ثبت شد";
                    ViewBag.style = "color:green;";
                    return View(q);

                }
                else
                {
                    ViewBag.Message = "متاسفانه ثبت نشد";
                    ViewBag.style = "color:red;";
                    return View(q);
                }


            }




            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public ActionResult InsertProduct()
        {
            if (Session["UserName"] == null)

                return RedirectToAction("Index", "Home");



            ////احراز هویت
            //if (Session["Access"].ToString()=="Seller")
            //{
            //    //این کد ها زمانی که دسترسی کاربر برابر
            //    //seller 
            //    //باشد




            //}
            //else
            //{
            //    return Content("شما به این قسمت دسترسی ندارید")
            //}


            return View();
        }
        [HttpPost]
        public ActionResult InsertProduct(Tbl_Products t, HttpPostedFileBase IndexPic, int[] FilterItem, HttpPostedFileBase[] Image, int Mozayde = 0)
        {
            if (Session["UserName"] == null)
                return RedirectToAction("Index", "Home");
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "تمامی فیلد ها را ب درستی پر نمایید";
                ViewBag.style = "color:red;";
                return View();
            }

            if (IndexPic == null)
            {
                ViewBag.Message = "تصویر شاخص را انتخاب نمایید";
                ViewBag.style = "color:red;";
                return View();
            }

            //foreach (var item in Image)
            //{
            //    // برسی Item از لحاظ حجم و قالب
            //    // پیش از اینکه داخل دیتابیس ثبت شوند
            //}

            t.Date = DateTime.Now;
            if (Mozayde == 1)
                t.DateEnd = t.Date.AddDays(3);

            string UserName = Session["UserName"].ToString();

            t.UserId = db.Tbl_Users.Where(a => a.UserName.Equals(UserName)).SingleOrDefault().ID;
            t.Visit = 0;
            Random rnd = new Random();
            // برسی IndexPic از لحاظ حجم و قالب
            t.Image = rnd.Next().ToString() + ".jpg";
            IndexPic.SaveAs(Server.MapPath("~") + "Content/Pics/ProductsPic/" + t.Image);

            db.Tbl_Products.Add(t);
            db.SaveChanges();

            int ProductID = db.Tbl_Products.OrderByDescending(a => a.ID).FirstOrDefault().ID;

            List<Tbl_ProductPics> lstPic = new List<Tbl_ProductPics>();
            foreach (var item in Image)
            {
                Tbl_ProductPics tp = new Tbl_ProductPics();
                tp.PicName = rnd.Next().ToString() + ".jpg";
                item.SaveAs(Path.Combine(Server.MapPath("~") + "Content/Pics/ProductsPic/" + tp.PicName));
                tp.ProductID = ProductID;
                lstPic.Add(tp);
            }

            db.Tbl_ProductPics.AddRange(lstPic.AsEnumerable());


            if (FilterItem != null)
            {
                List<Tbl_Filters_Products> LstFilter = new List<Tbl_Filters_Products>();

                foreach (var item in FilterItem)
                {
                    Tbl_Filters_Products tf = new Tbl_Filters_Products();
                    tf.FilterID = item;
                    tf.ProductID = ProductID;

                    LstFilter.Add(tf);
                }

                db.Tbl_Filters_Products.AddRange(LstFilter.AsEnumerable());

            }

            if (Convert.ToBoolean(db.SaveChanges()))
            {
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


        [HttpGet]

        public ActionResult EditProducts(int id)
        {
            try
            {

                if (Session["UserName"] == null)
                    return RedirectToAction("Index", "Home");

                string UserName = Session["UserName"].ToString();

                var q = db.Tbl_Products.Where(a => a.Tbl_Users.UserName.Equals(UserName) && a.ID.Equals(id)).SingleOrDefault();

                if (q != null)
                {

                    return View(q);

                }
                else
                {
                    return Content("مشکلی در اجرای درخواست شما پیش امد");
                }
            }
            catch
            {
                return Content("مشکلی در اجرای درخواست شما پیش امد");

            }
        }

        [HttpPost]
        public ActionResult EditProducts(Tbl_Products t, HttpPostedFileBase IndexPic, int[] FilterItem, HttpPostedFileBase[] Image)
        {
            try
            {
                if (Session["UserName"] == null)
                    return RedirectToAction("Index", "Home");

                if (!ModelState.IsValid)
                {
                    ViewBag.Message = "تمای فیلد ها را پر نمایید";
                    ViewBag.Style = "Color:red;";
                    return View(t);
                }

                string UserName = Session["UserName"].ToString();
                var q = db.Tbl_Products.Where(a => a.ID.Equals(t.ID) && a.Tbl_Users.UserName.Equals(UserName)).SingleOrDefault();
                Random rnd = new Random();
                if (q != null)
                {
                    q.Description = t.Description;
                    q.ExistCount = t.ExistCount;
                    q.Price = t.Price;
                    q.Text = t.Text;
                    q.Title = t.Title;
                    q.TopicID = t.TopicID;
                    q.Weight = t.Weight;

                    if (IndexPic != null)
                    {
                        // برسی IndexPic از لحاظ حجم و قالب
                        q.Image = rnd.Next().ToString() + ".jpg";
                        IndexPic.SaveAs(Server.MapPath("~") + "Content/Pics/ProductsPic/" + q.Image);
                    }

                    if (Image != null)
                    {
                        List<Tbl_ProductPics> lstPic = new List<Tbl_ProductPics>();
                        foreach (var item in Image)
                        {
                            // برسی Item از لحاظ حجم و قالب
                            Tbl_ProductPics tp = new Tbl_ProductPics();
                            tp.PicName = rnd.Next().ToString() + ".jpg";
                            item.SaveAs(Path.Combine(Server.MapPath("~") + "Content/Pics/ProductsPic/" + tp.PicName));
                            tp.ProductID = q.ID;
                            lstPic.Add(tp);
                        }

                        db.Tbl_ProductPics.AddRange(lstPic.AsEnumerable());
                    }

                    if (FilterItem != null)
                    {
                        List<Tbl_Filters_Products> LstFiletr = new List<Tbl_Filters_Products>();
                        foreach (var item in FilterItem)
                        {
                            Tbl_Filters_Products tf = new Tbl_Filters_Products();
                            tf.ProductID = q.ID;
                            tf.FilterID = item;

                            LstFiletr.Add(tf);
                        }

                        db.Tbl_Filters_Products.AddRange(LstFiletr.AsEnumerable());
                    }

                    db.Tbl_Products.Attach(q);
                    db.Entry(q).State = System.Data.Entity.EntityState.Modified;

                    if (Convert.ToBoolean(db.SaveChanges()))
                    {
                        return RedirectToAction("ManageProducts", "User");
                    }
                    else
                    {

                        ViewBag.Message = "متاسفانه ثبت نشد";
                        ViewBag.Style = "Color:red;";
                        return View(t);
                    }

                }
                else
                {
                    // کاربر عملیات هک را انجام داده است.
                    return RedirectToAction("ManageProducts", "User");
                }
            }
            catch
            {

                return Content("مشکلی در اجرای درخواست شما پیش آمد");
            }
        }






        [HttpPost]
        public ActionResult AddFilterForm(int TopicID)
        {

            if (Session["UserName"] == null)
                return RedirectToAction("Index", "Home");

            if (Request.IsAjaxRequest())
            {
                Tbl_Categoris t = new Tbl_Categoris();
                t.ID = TopicID;

                return PartialView("P_Filters", t);
            }
            else
            {
                return Content("درخواست بایذ به صورت ایجکس ارسال شود،لطقا جاوا اسکریپت را در مرورگر فعال کنید");
            }


        }

        [HttpGet]
        public ActionResult ManageProducts(int Page = 1)
        {
            try
            {
                if (Session["UserName"] == null)
                    return RedirectToAction("Index", "Home");

                string UserName = Session["UserName"].ToString();

                int take = 5;
                int Skip = (Page * take) - take;

                var q = (from a in db.Tbl_Products
                         where a.Tbl_Users.UserName.Equals(UserName)
                         select a).OrderByDescending(a => a.ID);
                ViewBag.CountPoduct = q.Count();
                ViewBag.Take = take;
                return View(q.Skip(Skip).Take(take));

            }
            catch
            {
                return Content("مشکلی در اجرای درخواست شما پیش امد");

            }
        }

        public ActionResult DelProducts(int id)
        {
            try
            {
                if (Session["UserName"] == null)
                    return RedirectToAction("Index", "Home");

                string UserName = Session["UserName"].ToString();

                var q = (from a in db.Tbl_Products
                         where a.Tbl_Users.UserName.Equals(UserName) && a.ID.Equals(id)
                         select a).SingleOrDefault();

                if (q != null)
                {

                    db.Tbl_Products.Remove(q);
                    db.SaveChanges();
                    return RedirectToAction("ManageProducts");

                }

                else
                {
                    return Content("مشکلی در اجرای درخواست شما پیش امد");

                }
            }
            catch
            {

                return Content("مشکلی در اجرای درخواست شما پیش امد");
            }
        }


        [HttpPost]
        public string DelFilter(int id, int ProductID)
        {
            try
            {
                if (Session["UserName"] == null)
                    return "";

                string UserName = Session["UserName"].ToString();

                var q = db.Tbl_Products.Where(a => a.Tbl_Users.UserName.Equals(UserName) && a.ID.Equals(ProductID)).SingleOrDefault();

                if (q != null)
                {
                    var q2 = q.Tbl_Filters_Products.Where(a => a.FilterID.Equals(id) && a.ProductID.Equals(ProductID)).SingleOrDefault();

                    db.Tbl_Filters_Products.Remove(q2);
                    db.SaveChanges();
                    string Template = "<ul>";
                    foreach (var item in q.Tbl_Filters_Products)
                    {
                        Template += "<li style='margin-top:10px;'><span>" + item.Tbl_Filters.Title + "</span><span style='background-color:red;'><a href='/User/DelFilter/" + item.FilterID + "?ProductID=" + ProductID + "' data-ajax-update='#Filters' data-ajax-mode='replace' data-ajax-method='POST' data-ajax-confirm='ایا مطمعن به حذف هستید؟' data-ajax='true'>X</a></span></li>";
                    }
                    Template += "</ul>";
                    return Template;
                }
                else
                {
                    return "مشکلی در اجرای درخواست شما پیش آمد";
                }

            }
            catch
            {

                return "مشکلی در اجرای درخواست شما پیش آمد";
            }
        }



        [HttpPost]
        public string DelPic(int id, int ProductID)
        {

            try
            {
                if (Session["UserName"] == null)
                    return "";

                string UserName = Session["UserName"].ToString();

                var q = (from a in db.Tbl_Products
                         where a.Tbl_Users.UserName.Equals(UserName) && a.ID.Equals(ProductID)
                         select a).SingleOrDefault();

                if (q != null)
                {
                    var q2 = q.Tbl_ProductPics.Where(a => a.ID.Equals(id)).SingleOrDefault();

                    db.Tbl_ProductPics.Remove(q2);
                    db.SaveChanges();

                    string Template = "<ul>";

                    foreach (var item in q.Tbl_ProductPics)
                    {
                        Template += "<li><span><img style='width:150px;height:150px;' src='/Content/Pics/ProductsPic/" + item.PicName + "' /></span><span><a href='/User/DelPic/" + item.ID + "?ProductID=" + ProductID + "' data-ajax-update='#Picture' data-ajax-mode='replace' data-ajax-method='POST' data-ajax-confirm='آیا مطمعن به حذف هستید؟' data-ajax='true'>X</a></span></li>";
                    }

                    Template += "</ul>";

                    return Template;
                }
                else
                {
                    return "مشکلی در اجرای درخواست شما پیش آمد";

                }
            }
            catch
            {

                return "مشکلی در اجرای درخواست شما پیش آمد";

            }
        }

        public ActionResult StartAuc(int id)
        {
            if (Session["UserName"] == null)

                return RedirectToAction("Index", "Home");

            string UserName = Session["UserName"].ToString();

            DateTime? dt = DateTime.Now;
            //var q = (from a in db.Tbl_Products
            //         //where a.Tbl_Users.Equals(UserName) //&& a.ID.Equals(id) //&& (a.DateEnd != null ? a.DateEnd < dt : 1 == 1)
            //         select a).SingleOrDefault();

            var q = db.Tbl_Products.Where(a => a.ID == id && a.Tbl_Users.UserName.Equals(UserName) && (a.DateEnd != null ? a.DateEnd < dt : 1 == 1)).SingleOrDefault();


            if (q != null)
            {
                q.Date = DateTime.Now;
                q.DateEnd = q.Date.AddDays(3);

                db.Tbl_Products.Attach(q);
                db.Entry(q).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageProducts", "User");

            }
            else
            {
                ViewBag.Message = "مشکلی در اجرای درخواست شما پیش آمد";
                ViewBag.Style = "Color:red";
                return RedirectToAction("ManageProducts", "User");

            }


        }

        public ActionResult ManageMessages(int Page=1)
        {
            if (Session["UserName"] == null)
                return RedirectToAction("Index", "Home");

            string UserName = Session["UserName"].ToString();

            int take = 5;
            int Skip = (Page * take) - take;

            var q = (from a in db.Tbl_Messages
                     where a.Tbl_Users.UserName.Equals(UserName)
                     orderby a.ID descending
                     select a).OrderBy(a => a.Read);

            ViewBag.CountPoduct = q.Count();
            ViewBag.Take = take;

            return View(q.Skip(Skip).Take(take));
        }

        [HttpPost]
        public JsonResult ValidUserName(string UserGet)
        {
            try
            {
                var q = db.Tbl_Users.Where(a => a.UserName.Equals(UserGet));

                if (q == null)

                    return Json(false);
                else

                    return Json(true);
            }
            catch 
            {
                return Json(false);
            }
        }

        [HttpGet]
        public ActionResult DetailsMessage(int id)
        {
            if (Session["UserName"] == null)
                return RedirectToAction("Index", "Home");

            string UserName = Session["UserName"].ToString();

            var q = (from a in db.Tbl_Messages
                    where a.ID.Equals(id) && a.Tbl_Users.UserName.Equals(UserName)
                    select a).SingleOrDefault();

            if (q == null)
               return RedirectToAction("ManageMessages", "User");
            else
            {
                q.Read = true;
                db.Tbl_Messages.Attach(q);
                db.Entry(q).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return View(q);
            }
               
            
        }

        public ActionResult DeleteMessage(int id)
        {
            if (Session["UserName"] == null)
                return RedirectToAction("Index", "Home");

            string UserName = Session["UserName"].ToString();

            var q = (from a in db.Tbl_Messages
                     where a.ID.Equals(id) && a.Tbl_Users.UserName.Equals(UserName)
                     select a).SingleOrDefault();

            if (q == null)
                return RedirectToAction("ManageMessages", "User");
            else
            {
                db.Tbl_Messages.Remove(q);
                db.SaveChanges();

                return RedirectToAction("ManageMessages", "User");

            }


        }

        [HttpGet]

        public ActionResult SendMessage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SendMessage(Tbl_Messages t, string UserNameGet)
        {

            if(ModelState.IsValid)
            {
                if (!this.IsCaptchaValid("Eror"))
                {
                    ViewBag.Message = "کد تصویر اشتباه است ";
                    ViewBag.Style = "Color:red;";

                    return View();
                }

            if (Session["UserName"] == null)
                return RedirectToAction("Index", "Home");

            string UserName = Session["UserName"].ToString();

            Tbl_Messages tm = new Tbl_Messages();


            tm.Message = t.Message;
            tm.Title = t.Title;
            tm.UserGet = db.Tbl_Users.Where(a => a.UserName.Equals(UserNameGet)).SingleOrDefault().ID;
            tm.Date = DateTime.Now;
            tm.Read = false;
            tm.UserSend= db.Tbl_Users.Where(a => a.UserName.Equals(UserName)).SingleOrDefault().ID;

            db.Tbl_Messages.Add(tm);


            if (Convert.ToBoolean(db.SaveChanges()))
            {
                ViewBag.Message = "پیام با موفقیت ارسال شد";
                ViewBag.Style = "Color:green;";

                    return RedirectToAction("ReadedMessage", "User");
            }
            else
            {
                ViewBag.Message = "متاسفانه پیام ارسال نشد ";
                ViewBag.Style = "Color:red;";

                return View();
            }

            }
            else
            {
                ViewBag.Message = "تمامی فیلد ها را با دقت پر نمایید";
                ViewBag.Style = "Color:red;";

                return View();

            }

        }

       




        [HttpGet]
        public ActionResult ReadedMessage()
        {

            if (Session["UserName"] == null)
                return RedirectToAction("Index", "Home");

            string UserName = Session["UserName"].ToString();

            var q = db.Tbl_Messages.Where(a => a.Tbl_Users1.UserName.Equals(UserName));


            return View(q);

        }
    }
}