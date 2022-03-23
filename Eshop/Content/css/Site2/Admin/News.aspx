<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="Admin_News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Newsid" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="Newsid" HeaderText="Newsid" InsertVisible="False" ReadOnly="True" SortExpression="Newsid" />
            <asp:BoundField DataField="Newstitle" HeaderText="Newstitle" SortExpression="Newstitle" />
            <asp:BoundField DataField="Newsdesc" HeaderText="Newsdesc" SortExpression="Newsdesc" />
            <asp:BoundField DataField="Newsdate" HeaderText="Newsdate" SortExpression="Newsdate" />
            <asp:BoundField DataField="Newsvisited" HeaderText="Newsvisited" SortExpression="Newsvisited" />
            <asp:BoundField DataField="Newscat" HeaderText="Newscat" SortExpression="Newscat" />
            <asp:BoundField DataField="Newswriter" HeaderText="Newswriter" SortExpression="Newswriter" />
            <asp:BoundField DataField="Newsimage" HeaderText="Newsimage" SortExpression="Newsimage" />
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteNews" InsertMethod="InsertNews" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataAllNews" TypeName="NewsTableAdapters.tbl_NewsTableAdapter" UpdateMethod="UpdateNews">
        <DeleteParameters>
            <asp:Parameter Name="Original_Newsid" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Newstitle" Type="String" />
            <asp:Parameter Name="Newsdesc" Type="String" />
            <asp:Parameter Name="Newsdate" Type="DateTime" />
            <asp:Parameter Name="Newsvisited" Type="Int32" />
            <asp:Parameter Name="Newscat" Type="Int32" />
            <asp:Parameter Name="Newswriter" Type="String" />
            <asp:Parameter Name="Newsimage" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Newstitle" Type="String" />
            <asp:Parameter Name="Newsdesc" Type="String" />
            <asp:Parameter Name="Newsdate" Type="DateTime" />
            <asp:Parameter Name="Newsvisited" Type="Int32" />
            <asp:Parameter Name="Newscat" Type="Int32" />
            <asp:Parameter Name="Newswriter" Type="String" />
            <asp:Parameter Name="Newsimage" Type="String" />
            <asp:Parameter Name="Original_Newsid" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <br/>
     <table style="direction:rtl; font: 12px tahoma; line-height: 15px; text-align:center; width:500px; margin:0 auto; border:1px solid black; padding:5px;">
        <tr>
             <td>عنوان مطلب:</td>
            <td>
                <asp:textbox id="txt_title" runat="server" Width="170px"></asp:textbox>
            </td>
           
        </tr>

            <tr>
             <td>متن مطلب:</td>
            <td>
                <asp:textbox id="txt_desc" runat="server" Height="79px" TextMode="MultiLine" Width="231px"></asp:textbox>
            </td>
           
        </tr>

            <tr>
             <td>موضوع مطلب:</td>
            <td>
                <asp:DropDownList ID="txt_catid" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Catname" DataValueField="Catid"></asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataallCategories" TypeName="CategoriesTableAdapters.tbl_categoriesTableAdapter"></asp:ObjectDataSource>
            </td>
           
        </tr>

            <tr>
             <td>نویسنده مطلب:</td>
            <td>
                <asp:textbox id="txt_writer" runat="server" Width="170px"></asp:textbox>
            </td>
           
        </tr>
            <tr>
             <td>تصویر مطلب:</td>
            <td>
                <asp:fileupload id="FileUpload1" runat="server"></asp:fileupload>
            </td>
           
        </tr>

            <tr>
          
            <td>
                <asp:button id="btn_newssend" runat="server" text="ارسال مطلب" style="height: 26px" OnClick="btn_newssend_Click" />
            </td>
                <td>
                    <asp:label id="lbl_newssend" runat="server" text=""></asp:label>
                </td>
           
        </tr>
        
    </table>


</asp:Content>

