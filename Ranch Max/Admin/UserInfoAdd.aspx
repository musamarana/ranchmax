<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="UserInfoAdd.aspx.cs" Inherits="Ranch_Max.Admin.UserInfoAdd" %>
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

    

    <div id="addFeed">
        <h3 style="font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; text-align:center;" >
            User Personal Information </h3>
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
                    <asp:DropDownList ID="ddUser" Width="180px" runat="server" AutoPostBack="true" >
<%--                        <asp:ListItem Text="Select Feed" Value="0"></asp:ListItem>--%>
                    </asp:DropDownList></td>
<%--                <td class="auto-style2">&nbsp;</td>--%>
                      <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddUser" InitialValue="--Entry User--" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
 
              <%-- NAME --%>
 <tr>
                <td style="width: 197px"><asp:Label ID="lblName" runat="server" Text="Name" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtName" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtName" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
                
                     <%-- FNAME --%>
 <tr>
                <td style="width: 197px"><asp:Label ID="lblFName" runat="server" Text="Father Name" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtFName" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtFName" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
             
      
                    <%--user CNIC--%>

                <tr>
                <td style="width: 197px"><asp:Label ID="lblCNIC" runat="server"  Text="Buyer CNIC" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtCNIC" placeholder="12345-1234567-1" runat="server"  style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                 <td class="auto-style2"> <asp:RegularExpressionValidator  runat="server"  ID="rexcnic"  ControlToValidate="txtCNIC"
                       ValidationExpression ="^[0-9]{5}-[0-9]{7}-[0-9]$"  ErrorMessage="CNIC No must follow the XXXXX-XXXXXXX-X format!"></asp:RegularExpressionValidator>
                       </td>
            </tr>
                 
         <%--user address--%>
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

         <asp:Label ID="Label5"  runat="server" Text="Label" Visible="false"></asp:Label>
        <br />

                <asp:Button ID="btn" runat="server" Text="ADD" CssClass="btn btn-default"
                    OnClick="Button1_Click" Width="143px" style="background:#3498db; color:white;
                    font-size:16px; padding:5px 5px 5px 5px;"/>

        </div>

</asp:Content>
