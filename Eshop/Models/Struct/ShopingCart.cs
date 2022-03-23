using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshop.Models.Struct
{
    public class ShopingCart
    {
        public int GheymatKol { get; set; }
        public List<Tbl_Cart> LstCart { get; set; }
        public int Count { get; set; }
    }

    public class Tbl_Cart
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public string Count { get; set; }
        public string Price { get; set; }
    }
}