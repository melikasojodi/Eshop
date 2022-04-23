using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eshop.Models.Domain
{
    internal class MetaDataGroupFilter
    {
        public int ID { get; set; }
        public Nullable<int> ParentID { get; set; }

        [Display(Name = "عنوان")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "تعداد کاراکترها باید بین 3 تا 100 کاراکتر باشد")]
        [DataType(DataType.Text)]

        public string Title { get; set; }
    }

    [MetadataType(typeof(MetaDataGroupFilter))]
    public partial class Tbl_GroupFilters
    {

    }

}