using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshop.Models.Domain
{
    internal class MetaDataProduct
    {
        public int ID { get; set; }
        public int UserId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "عنوان را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "تعداد حروف عنوان باید بین 5 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        public string Title { get; set; }


        [Display(Name = " توضیحات")]
        [Required(ErrorMessage = "توضیحات را وارد نمایید", AllowEmptyStrings = false)]
        //[StringLength(100, MinimumLength = 5, ErrorMessage = "تعداد حروف عنوان باید بین 5 تا 100 کاراکتر باشد")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]

        public string Text { get; set; }

        [Display(Name = "تعداد موجودی")]
        [Required(ErrorMessage = "تعداد موجودی را وارد نمایید", AllowEmptyStrings = false)]
        //[StringLength(100, MinimumLength = 5, ErrorMessage = "تعداد حروف تعداد موجودی باید بین 5 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]

        public int ExistCount { get; set; }

        [Display(Name = "نصویر شاخص")]
        [Required(ErrorMessage = "نصویر شاخص را وارد نمایید", AllowEmptyStrings = false)]
        //[StringLength(100, MinimumLength = 5, ErrorMessage = "تعداد حروف تعداد موجودی باید بین 5 تا 100 کاراکتر باشد")]
        //[DataType(DataType.ImageUrl)]

        public string Image { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "قیمت را وارد نمایید", AllowEmptyStrings = false)]
        //[StringLength(100, MinimumLength = 5, ErrorMessage = "تعداد حروف تعداد موجودی باید بین 5 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]


        public int Price { get; set; }
        public int Visit { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }

        [Display(Name = "وزن")]
        [Required(ErrorMessage = "وزن را وارد نمایید", AllowEmptyStrings = false)]
        //[StringLength(100, MinimumLength = 5, ErrorMessage = "تعداد حروف تعداد موجودی باید بین 5 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        public int Weight { get; set; }
        public int TopicID { get; set; }

        [Display(Name = "چکیده توضیحات")]
        [Required(ErrorMessage = "چکیده توضیحات را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "تعداد حروف چکیده توضیحات باید بین 5 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]

        public string Description { get; set; }

    }

    [MetadataType(typeof(MetaDataProduct))]
    public partial class Tbl_Products
    {

    }
}