<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 700px;
            border: 1px solid #000000;
        }
        .auto-style3 {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />
    <table align="center" cellspacing="1" class="auto-style2" dir="rtl">
        <tr>
            <td class="auto-style3">نام و نام خانوادگی:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txt_name" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>ایمیل:</td>
            <td>
                <asp:TextBox ID="txt_email" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>موضوع پیام:</td>
            <td>
                <asp:TextBox ID="txt_title" runat="server" Width="200px" Height="116px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>پیغام شما:</td>
            <td>
                <asp:TextBox ID="txt_desc" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_contact" runat="server" Text="ارسال" OnClick="btn_contact_Click" />
            </td>
            <td>
                <asp:Label ID="lbl_contact" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

