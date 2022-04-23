using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eshop.Models.Domain
{
    internal class MetaDataMenus
    {
       
        public int ID { get; set; }

        [Display(Name = "عنوان")]

        public string Title { get; set; }

        [Display(Name = "ترتیب")]
        public int Sort { get; set; }

        [Display(Name = "لینک")]
        public string Link { get; set; }
    }

    [MetadataType(typeof(MetaDataMenus))]
    public partial class Tbl_Menu
    {
      
    }
}


