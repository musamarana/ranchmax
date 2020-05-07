<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="AccessNotify.aspx.cs" Inherits="Ranch_Max.RoleNotify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">


    <div id="content">
        <h1>Sorry Mr.<%: Context.User.Identity.GetUserName()  %> You dont have rights to access this Page</h1>
        <img alt="Sorry" src="" style="width: 100px; height: 100px" />
    </div>


</asp:Content>
