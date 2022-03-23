<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="Admin_Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Catid" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="Catname" HeaderText="Catname" SortExpression="Catname" />
            <asp:BoundField DataField="Catid" HeaderText="Catid" InsertVisible="False" ReadOnly="True" SortExpression="Catid" />
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
        </center>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteCatByCatiD" InsertMethod="InsertCat" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataallCategories" TypeName="CategoriesTableAdapters.tbl_categoriesTableAdapter" UpdateMethod="UpdateCatByCatiD">
        <DeleteParameters>
            <asp:Parameter Name="Original_Catid" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Catname" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Catname" Type="String" />
            <asp:Parameter Name="Original_Catid" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <br /><br />

    <table style="direction:rtl; font:12px tahoma; text-align:center; width:500px; margin:0 auto; border:1px solid black; padding:10px;">
        <tr>
            <td>نام موضوع:</td>
            <td>
                <asp:TextBox ID="txt_catname" runat="server"></asp:TextBox></td>

        </tr>

              <tr>
            <td>
                <asp:Button ID="btn_cat" runat="server" Text="ثبت" OnClick="btn_cat_Click" /></td>
            <td>
                <asp:Label ID="lbl_cat" runat="server" Text=""></asp:Label></td>

        </tr>



    </table>

</asp:Content>

