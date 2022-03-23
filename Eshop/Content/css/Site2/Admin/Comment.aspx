<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="Comment.aspx.cs" Inherits="Admin_Comment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:gridview runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Comid" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="Comid" HeaderText="Comid" InsertVisible="False" ReadOnly="True" SortExpression="Comid" />
            <asp:BoundField DataField="Comusername" HeaderText="Comusername" SortExpression="Comusername" />
            <asp:BoundField DataField="Comemail" HeaderText="Comemail" SortExpression="Comemail" />
            <asp:BoundField DataField="Comdate" HeaderText="Comdate" SortExpression="Comdate" />
            <asp:BoundField DataField="Comtext" HeaderText="Comtext" SortExpression="Comtext" />
            <asp:BoundField DataField="Newsid" HeaderText="Newsid" SortExpression="Newsid" />
            <asp:CheckBoxField DataField="Approved" HeaderText="Approved" SortExpression="Approved" />
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
    </asp:gridview>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteComment" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataAllCommentByDate" TypeName="CommentTableAdapters.tbl_CommentTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_Comid" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Comusername" Type="String" />
            <asp:Parameter Name="Comemail" Type="String" />
            <asp:Parameter Name="Comdate" Type="DateTime" />
            <asp:Parameter Name="Comtext" Type="String" />
            <asp:Parameter Name="Newsid" Type="Int32" />
            <asp:Parameter Name="Approved" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Comusername" Type="String" />
            <asp:Parameter Name="Comemail" Type="String" />
            <asp:Parameter Name="Comdate" Type="DateTime" />
            <asp:Parameter Name="Comtext" Type="String" />
            <asp:Parameter Name="Newsid" Type="Int32" />
            <asp:Parameter Name="Approved" Type="Boolean" />
            <asp:Parameter Name="Original_Comid" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4" DataKeyNames="Comid" DataSourceID="ObjectDataSource2" DefaultMode="Insert" ForeColor="#333333" GridLines="None" Height="50px" Width="125px">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="Comid" HeaderText="Comid" InsertVisible="False" ReadOnly="True" SortExpression="Comid" />
            <asp:BoundField DataField="Comusername" HeaderText="Comusername" SortExpression="Comusername" />
            <asp:BoundField DataField="Comemail" HeaderText="Comemail" SortExpression="Comemail" />
            <asp:BoundField DataField="Comdate" HeaderText="Comdate" SortExpression="Comdate" />
            <asp:BoundField DataField="Comtext" HeaderText="Comtext" SortExpression="Comtext" />
            <asp:BoundField DataField="Newsid" HeaderText="Newsid" SortExpression="Newsid" />
            <asp:CheckBoxField DataField="Approved" HeaderText="Approved" SortExpression="Approved" />
        </Fields>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataAllCommentByDate" TypeName="CommentTableAdapters.tbl_CommentTableAdapter">
        <InsertParameters>
            <asp:Parameter Name="Comusername" Type="String" />
            <asp:Parameter Name="Comemail" Type="String" />
            <asp:Parameter Name="Comdate" Type="DateTime" />
            <asp:Parameter Name="Comtext" Type="String" />
            <asp:Parameter Name="Newsid" Type="Int32" />
            <asp:Parameter Name="Approved" Type="Boolean" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:Button ID="btn_refresh" runat="server" Text="بروز رسانی صفحه" OnClick="btn_refresh_Click" />
</asp:Content>

