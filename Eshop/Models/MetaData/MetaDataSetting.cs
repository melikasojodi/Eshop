using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eshop.Models.Domain
{
    internal class MetaDataSetting
    {
        public int ID { get; set; }

        [Display(Name ="عنوان سایت")]
        [StringLength(100,MinimumLength =3,ErrorMessage ="تعداد کاراکترها باید بین 3 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        public string Title { get; set; }


        [Display(Name = "توضیحات سایت")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "تعداد کاراکترها باید بین 3 تا 100 کاراکتر باشد")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [Display(Name = "تعداد در صفحه")]
        
        public byte CountProductInPage { get; set; }


        [Display(Name = "ایمیل سایت")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "تعداد کاراکترها باید بین 3 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)] 

        public string Email { get; set; }

        [Display(Name = "پسورد ایمیل")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "تعداد کاراکترها باید بین 3 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        public string EmailPass { get; set; }


        [Display(Name = "پروتکل ارسال ایمیل سایت")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "تعداد کاراکترها باید بین 3 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        public string SMTP { get; set; }
    }

    [MetadataType(typeof(MetaDataSetting))]
    public partial class Tbl_Setting
    {

    }
}