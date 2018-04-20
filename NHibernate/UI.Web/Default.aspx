<%@ Page Title="Home" 
    Language="C#" 
    MasterPageFile="~/MasterPageMain.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="UI.Web.Default" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="ContentMidleContent" ContentPlaceHolderID="cphMidleContent" runat="server">
    <p style=" text-align: center; color: Blue; font-size: 40px;">Welcome to the NHibernate Application</p>
</asp:Content>
