using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshop.Models.Domain
{
    internal class MetaDataMessage
    {

        public int ID { get; set; }

        [Display(Name = "دریافت کننده")]
        [Required(ErrorMessage = "نام کاربری دریافت کننده را وارد نمایید", AllowEmptyStrings = false)]
        //[StringLength(100, MinimumLength =3, ErrorMessage = "تعداد حروف  باید بین 3 تا 100 کاراکتر باشد")]
        [Remote("ValidUserName", "User",ErrorMessage ="نام کاربری معتبر نیست",HttpMethod ="POST")]

        public int UserGet { get; set; }

        [Display(Name = "ارسال کننده")]
        //[StringLength(100, MinimumLength = 3, ErrorMessage = "تعداد حروف  باید بین 3 تا 100 کاراکتر باشد")]
        //[DataType(DataType.Text)]


        public Nullable<int> UserSend { get; set; }


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "عنوان را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "تعداد حروف  باید بین 3 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]


        public string Title { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "متن را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "تعداد حروف  باید بین 5 تا 500 کاراکتر باشد")]
        [DataType(DataType.MultilineText)]


        public string Message { get; set; }

        public bool Read { get; set; }

        [Display(Name = "تاریخ")]

        public System.DateTime Date { get; set; }
    }


    [MetadataType(typeof(MetaDataMessage))]

    public partial class Tbl_Messages
    {
    
    }

    }