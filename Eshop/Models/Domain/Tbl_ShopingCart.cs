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
    
    public partial class Tbl_ShopingCart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_ShopingCart()
        {
            this.Tbl_TempSales = new HashSet<Tbl_TempSales>();
        }
    
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string CookiNo { get; set; }
        public int UserID { get; set; }
        public System.DateTime Date { get; set; }
        public bool Status { get; set; }
        public int Count { get; set; }
    
        public virtual Tbl_Products Tbl_Products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_TempSales> Tbl_TempSales { get; set; }
        public virtual Tbl_Users Tbl_Users { get; set; }
    }
}