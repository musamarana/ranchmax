<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Breeding.aspx.cs" Inherits="Ranch_Max.Breeding1" %>
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
            ADD BREEDING</h3>
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
                    <asp:DropDownList ID="ddAnimal" Width="180px" runat="server" AutoPostBack="true" >
<%--                        <asp:ListItem Text="Select Feed" Value="0"></asp:ListItem>--%>
                    </asp:DropDownList></td>
<%--                <td class="auto-style2">&nbsp;</td>--%>
                      <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddAnimal" InitialValue="--Select--" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
     

                <%--EAR TAG MALE--%>
            <tr>
                <td style="width: 197px"><asp:Label ID="lblETag_M" runat="server" Text="Male Animal" style="color:#6D7FCC; 
                font-size:18px;"></asp:Label></td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddAnimal_M" Width="180px" runat="server" AutoPostBack="true" >
<%--                        <asp:ListItem Text="Select Feed" Value="0"></asp:ListItem>--%>
                    </asp:DropDownList></td>            
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
                    ErrorMessage="Required." ControlToValidate="ddUser" InitialValue="--Select--" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>
 
                 <%--Type--%>
                <tr>
                <td style="width: 197px"><asp:Label ID="lblType" runat="server" Text="Type" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:DropDownList ID="ddType" AppendDataBoundItems="true" Width="180px" runat="server" AutoPostBack="true" >
                         <asp:ListItem Text="--Select--" Value="0"> 

                         </asp:ListItem> 
                    <asp:ListItem>Natural</asp:ListItem>
                    <asp:ListItem>Artificial</asp:ListItem>
 
                    </asp:DropDownList> </td>                    
                      <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddType" InitialValue="0" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
 
                    </tr>
                  
                  
                 
                  
                 <%--Date --%>
                    <tr>
                <td style="width: 197px">
                    <asp:Label ID="Label7" runat="server" Text="Date" style="color:#6D7FCC; font-size:18px;">

                    </asp:Label></td>
                    <td class="auto-style3"><asp:TextBox ID="txtdate" TextMode="Date" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                                 <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtdate" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
 
                     
            </tr>
                  
                 
                <%--Dose --%>
              <tr>
                <td style="width: 197px"><asp:Label ID="lblDose" runat="server" Text="Dose" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtDose" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                 
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
