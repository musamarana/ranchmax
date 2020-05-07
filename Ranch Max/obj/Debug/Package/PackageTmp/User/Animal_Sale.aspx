<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Animal_Sale.aspx.cs" Inherits="Ranch_Max.Animal_Sale" %>
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
            Sale Animal </h3>
        <br />
        <br />

        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-borderless">
            
                         <%--EAR TAG--%>
            <tr>
                <td style="width: 197px"><asp:Label ID="lblETag" runat="server" Text="Animal" style="color:#6D7FCC; 
                font-size:18px;"></asp:Label></td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddETag" Width="180px" runat="server" AutoPostBack="true" ></asp:DropDownList>
                     </td>
<%--                <td class="auto-style2">&nbsp;</td>--%>
                      <td class="auto-style2"><asp:RequiredFieldValidator ID="rftag" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddETag" InitialValue="--Select--" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
       <%--Amount--%>
                
                <tr>
                <td style="width: 197px"><asp:Label ID="lblAmnt" runat="server" Text="Amount" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtAmnt" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="rfAmnt" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtAmnt" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
                
             
               
                 <%--dateTime--%>
               <tr>
                <td style="width: 197px"><asp:Label ID="lbldate" runat="server" Text="Date" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtdate" runat="server" TextMode="Date" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
             
            </tr>

 
                
                 <%--Buyer--%>

                <tr>
                <td style="width: 197px"><asp:Label ID="lblBuyer" runat="server" Text="Buyer Name" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtBuyer" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                 
            </tr>
                   <%--Buyer CNIC--%>

                <tr>
                <td style="width: 197px"><asp:Label ID="lblCNIC" runat="server"  Text="Buyer CNIC" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtCNIC" placeholder="12345-1234567-1" runat="server"  style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                 <td class="auto-style2"> <asp:RegularExpressionValidator  runat="server"  ID="rexcnic"  ControlToValidate="txtCNIC"
                       ValidationExpression ="^[0-9]{5}-[0-9]{7}-[0-9]$"  ErrorMessage="CNIC No must follow the XXXXX-XXXXXXX-X format!"></asp:RegularExpressionValidator>
                       </td>
            </tr>
                 
     

      </table>
              </ContentTemplate>
            </asp:UpdatePanel>
                </div>

         <asp:Label ID="Label5" CssClass="add" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />

                <asp:Button ID="btnSale" runat="server" Text="ADD" CssClass="btn btn-default"
                    OnClick="Button1_Click" Width="143px" style="background:#3498db; color:white;
                    font-size:16px; padding:5px 5px 5px 5px;"/>

        </div>
</asp:Content>
