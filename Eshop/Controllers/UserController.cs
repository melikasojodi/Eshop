using Eshop.Models.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult InsertProduct(Tbl_Products t, HttpPostedFileBase IndexPic, int[] FilterItem, HttpPostedFileBase[] Image, int Mozayedeh = 0)
        {
            if (Session["UserName"] == null)
                return RedirectToAction("Index", "Home");
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "تمامی فیلد ها را پر نمایید";
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
            //    بررسی item  از لحاظ حجم و قالب
            //    پیش از اینکه داخل دیتابیس ثبت شوند
            //}


            t.Date = DateTime.Now;



            if (Mozayedeh == 1)

                t.DateEnd = t.Date.AddDays(3);



            string UserName = Session["UserName"].ToString();
            t.UserId = db.Tbl_Users.Where(a => a.UserName.Equals(UserName)).SingleOrDefault().ID;
            t.Visit = 0;

            Random rnd = new Random();

            //یررسی indexpic از لحاظ حجم و قالب

            t.Image = rnd.Next().ToString() + ".jpg";

            IndexPic.SaveAs(Server.MapPath("~") + "Content/Pics/ProductsPic/" + t.Image);
            t.Image = IndexPic.FileName;


            db.Tbl_Products.Add(t);
            db.SaveChanges();

            int ProductID = db.Tbl_Products.OrderByDescending(a => a.ID).FirstOrDefault().ID;


            List<Tbl_ProductPics> lstpic = new List<Tbl_ProductPics>();

            foreach (var item in Image)
            {
                Tbl_ProductPics tp = new Tbl_ProductPics();
                tp.PicName = rnd.Next().ToString() + ".jpg";
                item.SaveAs(Path.Combine(Server.MapPath("~") + "Content/Pics/ProductsPic/" + tp.PicName));
                tp.ProductID = ProductID;


                lstpic.Add(tp);

            }

            db.Tbl_ProductPics.AddRange(lstpic.AsEnumerable());


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

                if (q!=null)
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


        public ActionResult DelFilter(int id,int ProductID)
        {
            try
            {
                if (Session["UserName"] == null)
                    return RedirectToAction("Index","Home");

                string UserName = Session["UserName"].ToString();

                var q = db.Tbl_Products.Where(a => a.Tbl_Users.UserName.Equals(UserName) && a.ID.Equals(ProductID)).SingleOrDefault();

                if (q!=null)
                {
                    var q2 = q.Tbl_Filters_Products.Where(a => a.FilterID.Equals(id) && a.ProductID.Equals(ProductID)).SingleOrDefault();

                    db.Tbl_Filters_Products.Remove(q2);
                    db.SaveChanges();
                    return View();
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
           

    }
}