using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Comment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/Comment.aspx");
    }
}