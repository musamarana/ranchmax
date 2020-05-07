<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="AccessNotify.aspx.cs" Inherits="Ranch_Max.RoleNotify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <div id="content">
        <h1>Sorry <i class="fas fa-frown"></i> <%: Context.User.Identity.GetUserName()  %> You dont have rights to access this Page</h1>
        <br />
        
    </div>


</asp:Content>
