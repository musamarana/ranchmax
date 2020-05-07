<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="RolesAssign.aspx.cs" Inherits="Ranch_Max.Admin.RolesAssign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">

    <style>

        .btn btn-default{
         border-radius:10px;
         background:#3498db;
         text-decoration-color:white;

        }
        .table-borderless > tbody > tr > td,
        .table-borderless > tbody > tr > th,
        .table-borderless > tfoot > tr > td,
        .table-borderless > tfoot > tr > th,
        .table-borderless > thead > tr > td,
        .table-borderless > thead > tr > th {
            border: none;
        }


        .auto-style2 {
            width: 160px;
        }
        .auto-style3 {
            width: 136px;
        }


    </style>
    
    <div id="content">

    

    <div id="">
        <h3 style="font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; text-align:center;" >
            ASSIGN ROLE</h3>
        <br />
        <br />

        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table class="table table-borderless">
            
                               <%--Username--%>
                    <tr>
                <td style="width: 197px"><asp:Label ID="lbluser" runat="server" Text="User" style="color:#6D7FCC; 
                font-size:18px;"></asp:Label></td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddUser" Width="180px" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="Id" >
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Entities1 %>" SelectCommand="SELECT [Id], [UserName], [Email] FROM [AspNetUsers]"></asp:SqlDataSource>
                        </td>
<%--                <td class="auto-style2">&nbsp;</td>--%>
                      <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddUser" InitialValue="--Entry User--" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
 

                <%--ROLE--%>
            <tr>
                <td style="width: 197px"><asp:Label ID="lblRole" runat="server" Text="Role" style="color:#6D7FCC; 
                font-size:18px;"></asp:Label></td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddRole" Width="180px" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Id" >
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Entities1 %>" SelectCommand="SELECT [Id], [Name] FROM [AspNetRoles]"></asp:SqlDataSource>
                    
                </td>
<%--                <td class="auto-style2">&nbsp;</td>--%>
                      <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddRole" InitialValue="--Select--" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
     
        
      </table>
            </ContentTemplate>
            </asp:UpdatePanel>
              
                </div>

         <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />

                <asp:Button ID="Button1" runat="server" Text="ASSIGN" CssClass="btn btn-default"
                    OnClick="Button1_Click" Width="143px" style="background:#3498db; color:white;
                    font-size:16px; padding:5px 5px 5px 5px;"/>

      <br />
       
 
        <br />
        <br />
      
        <div style="font-family:Arial">
            <asp:GridView ID="gvRole" runat="server" CellSpacing="1" CellPadding="3" GridLines="Both"  Width="500px" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" >
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />

            </asp:GridView>

 </div>
           </div>



</asp:Content>
