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
    
    public partial class Tbl_Categoris
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Categoris()
        {
            this.Tbl_Categoris1 = new HashSet<Tbl_Categoris>();
            this.Tbl_GroupFilters_Categories = new HashSet<Tbl_GroupFilters_Categories>();
            this.Tbl_Products = new HashSet<Tbl_Products>();
        }
    
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Title { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Categoris> Tbl_Categoris1 { get; set; }
        public virtual Tbl_Categoris Tbl_Categoris2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_GroupFilters_Categories> Tbl_GroupFilters_Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Products> Tbl_Products { get; set; }
    }
}