using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_contact_Click(object sender, EventArgs e)
    {
        ContactTableAdapters.tbl_ContactTableAdapter cta =new ContactTableAdapters.tbl_ContactTableAdapter();
        cta.InsertContact(txt_name.Text, txt_email.Text, txt_title.Text, txt_desc.Text, DateTime.Now);
        lbl_contact.Text = "نظر با موفقیت ثبت شد";
        txt_name.Text = "";
        txt_title.Text = "";
        txt_email.Text = "";
        txt_desc.Text = "";
    }
}