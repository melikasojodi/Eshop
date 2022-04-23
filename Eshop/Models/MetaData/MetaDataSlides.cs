using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eshop.Models.Domain
{
    internal class MetaDataSlides
    {
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "تعداد کاراکترها باید بین 3 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        public string Title { get; set; }


        [Display(Name = "تصویر")]
    
        public string Image { get; set; }


        [Display(Name = "لینک")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "تعداد کاراکترها باید بین 3 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]
        public string Link { get; set; }

        [Display(Name = "ترتیب")]
        
        public int Sort { get; set; }

        [Display(Name = "وضعیت")]
        
        public bool Enable { get; set; }
    }

    [MetadataType(typeof(MetaDataSlides))]
    public partial class Tbl_Slides
    {
      
    }
}