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
    
    public partial class Tbl_Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Products()
        {
            this.Tbl_Comment = new HashSet<Tbl_Comment>();
            this.Tbl_ProductPics = new HashSet<Tbl_ProductPics>();
            this.Tbl_Sales = new HashSet<Tbl_Sales>();
            this.Tbl_Auctions = new HashSet<Tbl_Auctions>();
            this.Tbl_ShopingCart = new HashSet<Tbl_ShopingCart>();
            this.Tbl_Filters_Products = new HashSet<Tbl_Filters_Products>();
        }
    
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int ExistCount { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Visit { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public int Weight { get; set; }
        public int TopicID { get; set; }
        public string Description { get; set; }
    
        public virtual Tbl_Categoris Tbl_Categoris { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Comment> Tbl_Comment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_ProductPics> Tbl_ProductPics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Sales> Tbl_Sales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Auctions> Tbl_Auctions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_ShopingCart> Tbl_ShopingCart { get; set; }
        public virtual Tbl_Users Tbl_Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Filters_Products> Tbl_Filters_Products { get; set; }
    }
}