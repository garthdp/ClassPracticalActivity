<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadFiles.aspx.cs" Inherits="ClassPracticalActivity.UploadFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Choose a file to upload:"></asp:Label><br />
    <asp:DropDownList ID="ddlFileUploadType" runat="server">
        <asp:ListItem Text="Files"></asp:ListItem>
        <asp:ListItem Text="Videos"></asp:ListItem>
        <asp:ListItem Text="Pictures"></asp:ListItem>
    </asp:DropDownList>
    <asp:FileUpload ID="FileUpload" runat="server" /><br />
    <asp:Button ID="btnUpload" OnClick="btnUpload_Click" runat="server" Text="Upload" />
</asp:Content>
