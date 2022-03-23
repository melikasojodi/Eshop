<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="Link.aspx.cs" Inherits="Admin_Link" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Linkid" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="Linkid" HeaderText="Linkid" InsertVisible="False" ReadOnly="True" SortExpression="Linkid" />
            <asp:BoundField DataField="Linkname" HeaderText="Linkname" SortExpression="Linkname" />
            <asp:BoundField DataField="Linkurl" HeaderText="Linkurl" SortExpression="Linkurl" />
            <asp:BoundField DataField="Linkdesc" HeaderText="Linkdesc" SortExpression="Linkdesc" />
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteLink" InsertMethod="InsertLink" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataAllLink" TypeName="LinkTableAdapters.tbl_LinkTableAdapter" UpdateMethod="UpdateLink">
        <DeleteParameters>
            <asp:Parameter Name="Original_Linkid" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Linkname" Type="String" />
            <asp:Parameter Name="Linkurl" Type="String" />
            <asp:Parameter Name="Linkdesc" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Linkname" Type="String" />
            <asp:Parameter Name="Linkurl" Type="String" />
            <asp:Parameter Name="Linkdesc" Type="String" />
            <asp:Parameter Name="Original_Linkid" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
        </center>
    <br /><br />

    <table style="direction:rtl; font:12px tahoma; text-align:center; width:500px; margin:0 auto; border:1px solid black; padding:10px;">

    <tr>
          <td>عنوان پیوند:</td>
        <td>
            <asp:TextBox ID="txt_title" runat="server" Width="170px"></asp:TextBox></td>
      

    </tr>

    <tr>
        <td>آدرس پیوند:</td>
        <td>
            <asp:TextBox ID="txt_url" runat="server" Width="170px"></asp:TextBox></td>

    </tr>
           <tr>
        <td>توضیحات لینک:</td>
        <td>
            <asp:TextBox ID="txt_desc" runat="server" TextMode="MultiLine" Width="170px"></asp:TextBox></td>

    </tr>

         <tr>

        <td>
            <asp:Button ID="btn_link" runat="server" Text="ثبت" OnClick="btn_link_Click" /></td>
                     <td>
            <asp:Label ID="lbl_link" runat="server" Text=""></asp:Label></td>

    </tr>
          
          
    </table>

</asp:Content>

