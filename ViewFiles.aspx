<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewFiles.aspx.cs" Inherits="ClassPracticalActivity.ViewFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Files:"></asp:Label><br />
    <asp:DropDownList ID="ddlFileType" OnSelectedIndexChanged="ddlFileType_SelectedIndexChanged" runat="server">
        <asp:ListItem Text="Files"></asp:ListItem>
        <asp:ListItem Text="Videos"></asp:ListItem>
        <asp:ListItem Text="Pictures"></asp:ListItem>
    </asp:DropDownList><br />
    <asp:Button ID="btnView" OnClick="btnView_Click" runat="server" Text="Button" /><br />
    <asp:ListBox ID="lbFiles" runat="server"></asp:ListBox><br />
</asp:Content>
