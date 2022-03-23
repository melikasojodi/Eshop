<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Admin_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Conid" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="Conid" HeaderText="Conid" InsertVisible="False" ReadOnly="True" SortExpression="Conid" />
            <asp:BoundField DataField="Conusername" HeaderText="Conusername" SortExpression="Conusername" />
            <asp:BoundField DataField="Conemail" HeaderText="Conemail" SortExpression="Conemail" />
            <asp:BoundField DataField="Contitle" HeaderText="Contitle" SortExpression="Contitle" />
            <asp:BoundField DataField="Context" HeaderText="Context" SortExpression="Context" />
            <asp:BoundField DataField="Condate" HeaderText="Condate" SortExpression="Condate" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteContact" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataAllContact" TypeName="ContactTableAdapters.tbl_ContactTableAdapter">
        <DeleteParameters>
            <asp:Parameter Name="Original_Conid" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>

