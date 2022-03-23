<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

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
                        <div class="more">
                        <a href="<%# Eval("Newsid","shownews.aspx?nid={0}") %>" title="<%# Eval("Newstitle") %>" target="_blank">ادامه مطلب</a>
                         </div>
                    </div>
                    <div class="left_paien"></div>



          
        </ItemTemplate>
    </asp:datalist>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataAllNews" TypeName="NewsTableAdapters.tbl_NewsTableAdapter"></asp:ObjectDataSource>
</asp:Content>

