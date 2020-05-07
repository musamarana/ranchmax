<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="StockAdd.aspx.cs" Inherits="Ranch_Max.StockAdd1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">


    <style>

        .btn btn-default{
         border-radius:10px;
         background:#3498db;
         text-decoration-color:white;

        }
        .add{
            color: #0E8FEF;
            text-align: center;
            font-size: 22px;
            padding-bottom: 7px;
            
            
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

    

    <div id="addFeed">
        <h3 style="font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; text-align:center;" >
            ENTER STOCK</h3>
        <br />
        <br />

        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-borderless">
            
                 <tr>
                <td style="width: 197px"><asp:Label ID="Label1" runat="server" Text="Item Name" style="color:#6D7FCC; 
                font-size:18px;"></asp:Label></td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddIName" Width="180px" runat="server" AutoPostBack="true" >
<%--                        <asp:ListItem Text="Select Feed" Value="0"></asp:ListItem>--%>
                    </asp:DropDownList></td>
<%--                <td class="auto-style2">&nbsp;</td>--%>
                      <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddIName" InitialValue="--Item--" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
                

                <tr>
                <td style="width: 197px"><asp:Label ID="Label4" runat="server" Text="User" style="color:#6D7FCC; 
                font-size:18px;"></asp:Label></td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddUser" Width="180px" runat="server" AutoPostBack="true" >
<%--                        <asp:ListItem Text="Select Feed" Value="0"></asp:ListItem>--%>
                    </asp:DropDownList></td>
<%--                <td class="auto-style2">&nbsp;</td>--%>
                      <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddUser" InitialValue="--Entry User--" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>

                <tr>
                <td style="width: 197px"><asp:Label ID="Label2" runat="server" Text="Total Bags/Packs" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="TBags" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
               <%-- <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Required." ControlToValidate="TBags" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>--%>
            </tr>


               

                <tr>
                <td style="width: 197px"><asp:Label ID="Label6" runat="server" Text="Bag/Pack Size" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="BSize" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <%--<td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ErrorMessage="Required." ControlToValidate="BSize" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>--%>
            </tr>


                <tr>
                <td style="width: 197px"><asp:Label ID="Label3" runat="server" Text="Quantity" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtQty" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <%--<td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtQty" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>--%>
            </tr>

                 <tr>
                <td style="width: 197px">
                    <asp:Label ID="Label7" runat="server" Text="Expiry" style="color:#6D7FCC; font-size:18px;">

                    </asp:Label></td>
                    <td class="auto-style3"><asp:TextBox ID="txtExp" TextMode="Date" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
            
                    <%-- <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtExp" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>--%>
            </tr>

                
                <tr>
                <td style="width: 197px"><asp:Label ID="Label8" runat="server" Text="Unit" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:DropDownList ID="ddUnit" Width="180px" runat="server" AutoPostBack="true" >
                         <asp:ListItem Text="--Select--" Value="0"> 

                         </asp:ListItem> 
                    <asp:ListItem>Kg</asp:ListItem>
                    <asp:ListItem>Pcs</asp:ListItem>
                    <asp:ListItem>Ltr</asp:ListItem>
                    <asp:ListItem>ml</asp:ListItem>
                    <asp:ListItem>mg</asp:ListItem>
                    </asp:DropDownList> </td>                   
                    <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddUnit" InitialValue="0" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>


                
                <tr>
                <td style="width: 197px"><asp:Label ID="Label9" runat="server" Text="Rate" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtRate" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtRate" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>



      </table>
              </ContentTemplate>
            </asp:UpdatePanel>
                </div>

         <asp:Label ID="Label5" CssClass="add" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />

                <asp:Button ID="Button1" runat="server" Text="ADD" CssClass="btn btn-default"
                    OnClick="Button1_Click" Width="143px" style="background:#3498db; color:white;
                    font-size:16px; padding:5px 5px 5px 5px;"/>

        </div>




</asp:Content>
