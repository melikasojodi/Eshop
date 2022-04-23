using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eshop.Models.Domain
{


    internal class MetaDataFilter
    {

        public int ID { get; set; }
        public int FilterGroupID { get; set; }


        [Display(Name = "عنوان")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "تعداد کاراکترها باید بین 3 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]

        public string Title { get; set; }
    }


    [MetadataType(typeof(MetaDataFilter))]
    public partial class Tbl_Filters
    { 
    
    }

    }