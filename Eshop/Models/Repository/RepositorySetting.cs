using Eshop.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshop.Models.Repository
{
    public class RepositorySetting
    {
        DataBase db = new DataBase();

        public string GetSiteTitle()
        {
            var q = (from a in db.Tbl_Setting
                     select a).FirstOrDefault().Title;
            return q;

        }
        public string GetSiteDescription()
        {
            var q = (from a in db.Tbl_Setting
                     select a).FirstOrDefault().Description;
            return q;

        }
    }
}