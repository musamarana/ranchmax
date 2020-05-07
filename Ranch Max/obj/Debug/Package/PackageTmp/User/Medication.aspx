<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Medication.aspx.cs" Inherits="Ranch_Max.Medication1" %>
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
            ENTER Medication</h3>
        <br />
        <br />
         
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-borderless">
            

                <%--Medicine name--%>
                 <tr>
                <td style="width: 197px"><asp:Label ID="lblname" runat="server" Text="Medicine Name" style="color:#6D7FCC; 
                font-size:18px;"></asp:Label></td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddMed" Width="180px" runat="server" AutoPostBack="true" >
<%--                        <asp:ListItem Text="Select Feed" Value="0"></asp:ListItem>--%>
                    </asp:DropDownList></td>
<%--                <td class="auto-style2">&nbsp;</td>--%>
                      <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddMed" InitialValue="--Select--" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
                
                <%--Animal breed--%>
                <tr>
                <td style="width: 197px"><asp:Label ID="lblanimal" runat="server" Text="Animal EarTag" style="color:#6D7FCC; 
                font-size:18px;"></asp:Label></td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddAnimal" Width="180px" runat="server" AutoPostBack="true" >
<%--                        <asp:ListItem Text="Select Feed" Value="0"></asp:ListItem>--%>
                    </asp:DropDownList></td>
<%--                <td class="auto-style2">&nbsp;</td>--%>
                      <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddAnimal" InitialValue="--Select--" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
                 
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
                    ErrorMessage="Required." ControlToValidate="ddUser" initialValue="--Entry User--" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>


                     <tr>
                <td style="width: 197px"><asp:Label ID="lblqty" runat="server" Text="Quantity" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtQty" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtQty" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
           
                         </tr>

                 
                
                <tr>
                <td style="width: 197px"><asp:Label ID="lblunit" runat="server" Text="Unit" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:DropDownList ID="ddUnit" Width="180px" runat="server" AutoPostBack="true" >
                         <asp:ListItem Text="--Select--" Value="0"> 

                         </asp:ListItem> 
                     <asp:ListItem>Pcs</asp:ListItem>
                     <asp:ListItem>mg</asp:ListItem>
                     <asp:ListItem>ml</asp:ListItem>

                    </asp:DropDownList> </td>                   
<%--                    <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddUnit" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>--%>
            </tr>

               <%----Method--%>
                <tr>
                <td style="width: 197px"><asp:Label ID="lblMethod" runat="server" Text="Method" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:DropDownList ID="ddMethod" Width="180px" runat="server" AutoPostBack="true" >
                         <asp:ListItem Text="--Select--" Value="0"> 

                         </asp:ListItem> 
                    <asp:ListItem>Inject</asp:ListItem>
                    <asp:ListItem>Oral</asp:ListItem>
                    <asp:ListItem>Inhalation</asp:ListItem>

                    </asp:DropDownList> </td>                   
                    <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddMethod" InitialValue="0" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>

                 <%--Date--%>
                <tr>
                <td style="width: 197px"><asp:Label ID="lbldate" runat="server" Text="Date" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtdate" runat="server" TextMode="Date" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtdate" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
 


                                <%--Time--%>
                <tr>
                <td style="width: 197px"><asp:Label ID="lbltime" runat="server" Text="Time" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txttime" runat="server" TextMode="Time" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <%--<td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ErrorMessage="Required." ControlToValidate="txttime" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>--%>
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
