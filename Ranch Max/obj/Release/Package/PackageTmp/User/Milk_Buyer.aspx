<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Milk_Buyer.aspx.cs" Inherits="Ranch_Max.Milk_Buyer" %>
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
            Enter Milk Buyer Details</h3>
        <br />
        <br />

        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-borderless">
            
                
                <tr>
                <td style="width: 197px"><asp:Label ID="lblName" runat="server" Text="Name" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtName" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtName" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>

                <tr>
                <td style="width: 197px"><asp:Label ID="lblCNIC" runat="server" Text="CNIC" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtcnic"  placeholder="12345-1234567-1" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                     ErrorMessage="Required."  ControlToValidate="txtcnic" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
                    <td class="auto-style2"> <asp:RegularExpressionValidator  runat="server"  ID="rexcnic"  ControlToValidate="txtcnic"
                       ValidationExpression ="^[0-9]{5}-[0-9]{7}-[0-9]$"  ErrorMessage="CNIC No must follow the XXXXX-XXXXXXX-X format!"></asp:RegularExpressionValidator>
                       </td>
            </tr>

                <tr>
                <td style="width: 197px"><asp:Label ID="lblPhn" runat="server" Text="Phone" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtphone"  placeholder="0300-1234567" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtphone" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
                    <td class="auto-style2"> <asp:RegularExpressionValidator  runat="server"  ID="rexPhn"  ControlToValidate="txtphone"
                       ValidationExpression ="^[0-9]{4}-[0-9]{7}$"  ErrorMessage="CELL NO. must follow the XXXX-XXXXXXX format!"></asp:RegularExpressionValidator>
                       </td>
            </tr>

<%--                <tr>
                <td style="width: 197px"><asp:Label ID="lblemail" runat="server" Text="Email" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtemail" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                 
            </tr>--%>

                <tr>
                <td style="width: 197px"><asp:Label ID="lbladd" runat="server" Text="Address" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtadd" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtadd" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>

               
                 

      </table>

            </ContentTemplate>
            </asp:UpdatePanel>
              
                </div>

         <asp:Label ID="Label5" CssClass="add" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />

                <asp:Button ID="btnBuyer" runat="server" Text="ADD" CssClass="btn btn-default"
                    OnClick="Button1_Click" Width="143px" style="background:#3498db; color:white;
                    font-size:16px; padding:5px 5px 5px 5px;"/>

        </div>



</asp:Content>
