<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ShowCats.aspx.cs" Inherits="ShowCats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:DataList ID="DataList1" runat="server" DataKeyField="Newsid" DataSourceID="ObjectDataSource1">
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
        </ItemTemplate>
    </asp:DataList>


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataNewsByCatiD" TypeName="NewsTableAdapters.tbl_NewsTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="Newscat" QueryStringField="cid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>


</asp:Content>

