using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Categories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_cat_Click(object sender, EventArgs e)
    {
        CategoriesTableAdapters.tbl_categoriesTableAdapter cta = new CategoriesTableAdapters.tbl_categoriesTableAdapter();

        cta.InsertCat(txt_catname.Text);
        lbl_cat.Text = "موضوع با موفقیت ثبت گردید!";
        GridView1.DataBind();
        txt_catname.Text = "";
    }
}