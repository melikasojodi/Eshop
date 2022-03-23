using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshop.Models.Domain
{
    internal class MetaDataContactUs
    {
        public int ID { get; set; }


        [Display(Name="عنوان")]
        [Required(ErrorMessage ="عنوان را وارد نمایید",AllowEmptyStrings =false)]
        [StringLength(100,MinimumLength =5,ErrorMessage ="تعداد حروف عنوان باید بین 5 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]

        public string Title { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "تعداد حروف نام باید بین 2 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "ایمیل را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "تعداد حروف ایمیل باید بین 5 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$",ErrorMessage ="غالب ایمیل را به درستی وارد نمایید")]


        public string Email { get; set; }

        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "متن نظر را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "تعداد حروف عنوان باید بین 5 تا 100 کاراکتر باشد")]
        [DataType(DataType.MultilineText)]
        //[AllowHtml]

        public string Text { get; set; }

       
        public string IP { get; set; }
        public System.DateTime Date { get; set; }
        public bool Read { get; set; }
    }

    [MetadataType(typeof(MetaDataContactUs))]
    public partial class Tbl_ContactUs
    {

    }

}