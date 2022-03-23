using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Shownews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        NewsTableAdapters.tbl_NewsTableAdapter ntb = new NewsTableAdapters.tbl_NewsTableAdapter();
        string nid = Request.QueryString["nid"];
        string nn = ntb.NumberOfNewsVisited(int.Parse(nid)).ToString();
        ntb.Nvu(int.Parse(nn),int.Parse(nid));



    }

    protected void btn_submitcm_Click(object sender, EventArgs e)
    {

        CommentTableAdapters.tbl_CommentTableAdapter cta = new CommentTableAdapters.tbl_CommentTableAdapter();
        string nid = Request.QueryString["nid"];
        if (string.IsNullOrEmpty(txt_name.Text) || string.IsNullOrWhiteSpace(txt_name.Text) && txt_name.Text.Length>0)
        {
            cta.InsertComment("ناشناس", txt_email.Text, DateTime.Now, txt_comment.Text.Trim(), int.Parse(nid), true);

        }
        else
        {
            cta.InsertComment(txt_name.Text.Trim(), txt_email.Text, DateTime.Now, txt_comment.Text.Trim(), int.Parse(nid), true);
        }
        DataList4.DataBind();
        txt_comment.Text = "";
        txt_email.Text = "";
        txt_name.Text = "";
        lbl_comment.Text = "با موفقیت ثبت گردید";
  
    }
}