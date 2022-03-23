using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_newssend_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            if (!checktype(FileUpload1.FileName))
            {
                lbl_newssend.Text = "فرمت مورد نظر پشتیبانی نمی شود!!!";

            }
            else
            {
                NewsTableAdapters.tbl_NewsTableAdapter nta = new NewsTableAdapters.tbl_NewsTableAdapter();
                DateTime dt = DateTime.Now;
                string imgname = FileUpload1.FileName;
                nta.InsertNews(txt_title.Text, txt_desc.Text, dt, 0, int.Parse(txt_catid.SelectedValue), txt_writer.Text, imgname);
                lbl_newssend.Text = "ارسال با موفقیت انجام شد";

                FileUpload1.SaveAs(
                    MapPath("~/img/" + FileUpload1.FileName));
                GridView1.DataBind();
                txt_title.Text = "";
                txt_desc.Text = "";
                txt_writer.Text = "";
            }
        }

    }

    public Boolean checktype(string a)
    {
        string ext = Path.GetExtension(a);
        switch (ext.ToLower())
        {
            case ".gif": return true;
            case ".jpg": return true;
            case ".jpeg": return true;
            case ".png": return true;
            case ".bmp": return true;
            default: return false;
        }
    }
    }