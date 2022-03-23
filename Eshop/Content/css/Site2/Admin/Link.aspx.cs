using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Link : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_link_Click(object sender, EventArgs e)
    {

        LinkTableAdapters.tbl_LinkTableAdapter lta = new LinkTableAdapters.tbl_LinkTableAdapter();
        lta.InsertLink(txt_title.Text, txt_url.Text, txt_desc.Text);
        lbl_link.Text = "آفرین...موفقیت آمیز بود!";

        GridView1.DataBind();
        txt_title.Text = "";
        txt_url.Text = "";
        txt_desc.Text = "";

    }
}