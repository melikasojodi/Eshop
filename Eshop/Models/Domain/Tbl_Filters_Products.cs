//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eshop.Models.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Filters_Products
    {
        public int ID { get; set; }
        public int FilterID { get; set; }
        public int ProductID { get; set; }
    
        public virtual Tbl_Filters Tbl_Filters { get; set; }
        public virtual Tbl_Products Tbl_Products { get; set; }
    }
}
