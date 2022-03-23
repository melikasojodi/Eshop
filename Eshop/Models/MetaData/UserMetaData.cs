using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshop.Models.Domain
{
    internal class UserMetaData
    {
        public int ID { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "نام کاربری را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "تعداد حروف نام کاربری باید بین 6 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        [Remote("DuplicateUserName", "Home", HttpMethod = "Post", ErrorMessage = "نام کاربری تکراری است")]


        public string UserName { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "کلمه عبور را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "تعداد حروف کلمه عبور باید بین 6 تا 100 کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "ایمیل را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "تعداد حروف ایمیل باید بین 6 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$", ErrorMessage = "غالب ایمیل را به درستی وارد نمایید")]
        [Remote("DuplicateEmail", "Home", HttpMethod = "Post", ErrorMessage = "ایمیل تکراری است")]


        public string Email { get; set; }

        public string Access { get; set; }


        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "تعداد حروف نام  باید بین 2 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "تصویر پروفایل")]

        public string Image { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "شماره موبایل را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "تعداد حروف شماره موبایل  باید بین 10 تا 12 کاراکتر باشد")]
        [Remote("DuplicateMobile","Home",HttpMethod ="Post",ErrorMessage ="شماره موبایل تکراری است")]

        public string Mobile { get; set; }

        [Display(Name = "نام بانک")]
        //[Required(ErrorMessage = "نام بانک را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "تعداد حروف نام بانک باید بین 2 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]


        public string BankName { get; set; }


        [Display(Name = "شماره شبا")]
        //[Required(ErrorMessage = "شماره شبا را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "تعداد حروف شماره شبا باید بین 5 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        // نمی تواند تکراری باشد


        public string ShabaNo { get; set; }

        [Display(Name = "آدرس")]
        //[Required(ErrorMessage = "آدرس را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "تعداد حروف آدرس باید بین 2 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]



        public string Address { get; set; }

        [Display(Name = "اسنان")]

        public string Shire { get; set; }


        [Display(Name = "شهر")]


        public string City { get; set; }



        [Display(Name = "کد پستی")]
        //[Required(ErrorMessage = "کد پستی را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "تعداد حروف کد پستی باید بین 2 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        public string PostalCode { get; set; }



        [Display(Name = "شماره تلفن")]
        //[Required(ErrorMessage = "شماره تلفن را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "تعداد حروف شماره تلفن باید بین 10 تا 12 کاراکتر باشد")]
        [DataType(DataType.Text)]


        public string phone { get; set; }


        [Display(Name = "کد ملی")]
        //[Required(ErrorMessage = "کد ملی را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "تعداد حروف کد ملی باید بین 2 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        public string NatCode { get; set; }
        public bool Status { get; set; }
        public System.DateTime Date { get; set; }
    }


    [MetadataType(typeof(UserMetaData))]
    public partial class Tbl_Users
    {
        internal object SingleOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}