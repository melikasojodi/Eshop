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
    
    public partial class Tbl_Setting
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte CountProductInPage { get; set; }
        public string Email { get; set; }
        public string EmailPass { get; set; }
        public string SMTP { get; set; }
    }
}
