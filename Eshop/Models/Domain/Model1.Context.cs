﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=DataBase")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Categoris> Tbl_Categoris { get; set; }
        public virtual DbSet<Tbl_Comment> Tbl_Comment { get; set; }
        public virtual DbSet<Tbl_ConfEmail> Tbl_ConfEmail { get; set; }
        public virtual DbSet<Tbl_ConfMobile> Tbl_ConfMobile { get; set; }
        public virtual DbSet<Tbl_GroupFilters> Tbl_GroupFilters { get; set; }
        public virtual DbSet<Tbl_GroupFilters_Categories> Tbl_GroupFilters_Categories { get; set; }
        public virtual DbSet<Tbl_Menu> Tbl_Menu { get; set; }
        public virtual DbSet<Tbl_Payments> Tbl_Payments { get; set; }
        public virtual DbSet<Tbl_ProductPics> Tbl_ProductPics { get; set; }
        public virtual DbSet<Tbl_Products> Tbl_Products { get; set; }
        public virtual DbSet<Tbl_Sales> Tbl_Sales { get; set; }
        public virtual DbSet<Tbl_Setting> Tbl_Setting { get; set; }
        public virtual DbSet<Tbl_Slides> Tbl_Slides { get; set; }
        public virtual DbSet<Tbl_StatusType> Tbl_StatusType { get; set; }
        public virtual DbSet<Tbl_Auctions> Tbl_Auctions { get; set; }
        public virtual DbSet<Tbl_ShopingCart> Tbl_ShopingCart { get; set; }
        public virtual DbSet<Tbl_TempSales> Tbl_TempSales { get; set; }
        public virtual DbSet<Tbl_ContactUs> Tbl_ContactUs { get; set; }
        public virtual DbSet<Tbl_Users> Tbl_Users { get; set; }
        public virtual DbSet<Tbl_Filters> Tbl_Filters { get; set; }
        public virtual DbSet<Tbl_Filters_Products> Tbl_Filters_Products { get; set; }
        public virtual DbSet<Tbl_Messages> Tbl_Messages { get; set; }
    }
}
