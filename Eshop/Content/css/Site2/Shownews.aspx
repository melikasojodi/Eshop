<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Shownews.aspx.cs" Inherits="_Shownews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title><%# Eval("Newstitle") %></title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:datalist runat="server" DataKeyField="Newsid" DataSourceID="ObjectDataSource1">
        <ItemTemplate>

            <div class="left_bala"><a href="<%# Eval("Newsid","shownews.aspx?nid={0}") %>" title="<%# Eval("Newstitle") %>" target="_blank"><%# Eval("Newstitle") %></a></div>


                    <div class="left_vasat">
                        <br />
                        <img src="<%# Eval("Newsimage","img/{0}") %>" alt="" title="" width="450px" height="200px" />
                        <br /> <br />
                         
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Newsdesc") %>' />
                    <br /> <br />

                       <div style="background-color:#cccccc; border-radius:4px; direction:rtl; padding:10px;">
                           تاریخ:
            <asp:Label ID="NewsdateLabel" runat="server" Text='<%# Eval("Newsdate") %>' />
            &nbsp&nbsp&nbsp|&nbsp&nbsp&nbsp
                           بازدید:
            <asp:Label ID="NewsvisitedLabel" runat="server" Text='<%# Eval("Newsvisited") %>' />
             &nbsp&nbsp&nbsp|&nbsp&nbsp&nbsp
                           
                           نویسنده:
            <asp:Label ID="NewswriterLabel" runat="server" Text='<%# Eval("Newswriter") %>' />
                        
                    </div>
                    <div class="left_paien"></div>



           
            <br />
          
            <br />
<br />
        </ItemTemplate>
    </asp:datalist>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByNewsiD" TypeName="NewsTableAdapters.tbl_NewsTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="Newsid" QueryStringField="nid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
    <center>

       

    <asp:DataList ID="DataList4" runat="server" DataKeyField="Comid" DataSourceID="ObjectDataSource2">
        <ItemTemplate>
            <div style=" background-color:pink;  border-top-right-radius:8px; ">
             <div style="width:720px; height:30px; background-color:pink; border-top-right-radius:8px; text-align:right; padding:5px;   direction:rtl;"><h3><%# Eval("Comusername") %></h3></div>
             <div style="width:720px; height:20px; background-color:pink;  text-align:right; padding:5px;   direction:rtl;"><%# Eval("Comdate") %></div>
            </div>
             <div  style="width:720px;height:200px;direction:rtl; padding:5px; background-color:antiquewhite"><%# Eval("Comtext") %></div>
        
            </center>
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataAllCommentByNewsiD" TypeName="CommentTableAdapters.tbl_CommentTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="Newsid" QueryStringField="nid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
    <center>
      <table style="direction:rtl; font:12px tahoma; text-align:center; width:720px; margin:0 auto; border:1px solid black; padding:10px;">
        
          <tr>
              <td>نام:</td>
              <td><asp:TextBox ID="txt_name" runat="server" Width="300px" ></asp:TextBox></td>
          </tr>

                 <tr>
              <td>ایمیل:</td>
              <td><asp:TextBox ID="txt_email" runat="server" Width="300px"></asp:TextBox></td>
          </tr>

                 <tr>
              <td>دیدگاه:</td>
              <td><asp:TextBox ID="txt_comment" runat="server" Width="300px" TextMode="MultiLine"></asp:TextBox></td>
          </tr>

                 <tr>
              <td><asp:Button ID="btn_submitcm" runat="server" Text="ثبت" OnClick="btn_submitcm_Click" Width="150px"></asp:Button></td>
              <td><asp:Label ID="lbl_comment" runat="server" Text=""></asp:Label></td>
          </tr>
          
    </table>
        </center>
</asp:Content>

