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
    
    public partial class Tbl_Comment
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Text { get; set; }
        public System.DateTime Date { get; set; }
        public string Ip { get; set; }
        public bool Confirm_comm { get; set; }
    
        public virtual Tbl_Products Tbl_Products { get; set; }
    }
}
