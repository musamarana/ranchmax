<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="StockRemaining.aspx.cs" Inherits="Ranch_Max.StockRemaining" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">

    <div id="content">

          
        <h3 style="font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; text-align:center;" >
            FEEDING STOCK </h3>
        <br />
        <br />
      <asp:GridView ID="gvBalance1" runat="server" class="table" AllowSorting="True" CellPadding="5" CellSpacing="1"></asp:GridView>
        <br />
        <br />

          <h3 style="font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; text-align:center;" >
            MEDICATION STOCK </h3>
        <br />
        <br />
     <asp:GridView ID="gvMedication" runat="server" class="table" AllowSorting="True" CellPadding="5" CellSpacing="1"></asp:GridView>
           
        </div>

</asp:Content>
