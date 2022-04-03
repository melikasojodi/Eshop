using Eshop.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshop.Models.Repository
{
    public class RepositoryProduct
        

    {
        DataBase db = new DataBase();
        public IEnumerable<Tbl_Products> GetListproduct()

        { 
            var q = from a in db.Tbl_Products
                    where (a.DateEnd != null?a.DateEnd>DateTime.Now :1 == 1)&&
                    (a.DateEnd != null ? a.ExistCount>0 : 1 == 1)
                    select a;
            return q.AsEnumerable(); 
        }
    }
}