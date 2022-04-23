using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Models.Domain
{
    internal class MetaDataTypeStatus
    {
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "ترتیب")]
        public int Sort { get; set; }
    }

    [MetadataType(typeof(MetaDataTypeStatus))]
    public partial class Tbl_StatusType
    {

    }
}