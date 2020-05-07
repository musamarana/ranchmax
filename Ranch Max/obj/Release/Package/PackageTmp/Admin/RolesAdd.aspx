﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="RolesAdd.aspx.cs" Inherits="Ranch_Max.Users.RolesAdd" %>
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

    

    <div id="addRole">
        <h3 style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; text-align: center;" >
            ADD ROLE</h3>
        <br />
        <br />

        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-borderless">
            
                
                <tr>
                <td style="width: 197px"><asp:Label ID="lblRole" runat="server" Text="Role Name" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtRole" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtRole" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>


               
                 

      </table>
              
            </ContentTemplate>
            </asp:UpdatePanel>
                </div>

         <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />

                <asp:Button ID="Button1" runat="server" Text="ADD" CssClass="btn btn-default"
                    OnClick="Button1_Click" Width="143px" style="background:#3498db; color:white;
                    font-size:16px; padding:5px 5px 5px 5px;"/>

        <br />
        <br />
        <br />

        <br />
        <br />


        
    
    <asp:GridView ID="gvRole" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="Id" CellPadding="5" CellSpacing="1" OnRowDeleting="gvRole_RowDeleting"
         OnRowCancelingEdit="gvRole_RowCancelingEdit" OnRowEditing="gvRole_RowEditing" OnRowUpdating="gvRole_RowUpdating">

  
    <Columns>
                            <%--role--%>
                     <asp:TemplateField HeaderText="Role Name">
                         <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Name") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtName" Text= '<%#Eval("Name") %>'  runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>
             

                          <%--OPTION--%>

                       <asp:TemplateField>

                          <ItemTemplate> 
                             <asp:LinkButton  ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit">Edit</asp:LinkButton>
                             &nbsp;|&nbsp;
                             <asp:LinkButton  ID="lbDelete" runat="server" CommandName="Delete"
                                  OnClientClick="return  confirm('Are You Sure?')" ToolTip="Delete">Delete</asp:LinkButton>
                          </ItemTemplate>
                           <EditItemTemplate>
                                <asp:LinkButton  ID="lbUpdate" runat="server" CommandName="Update"  ValidationGroup="edit" >
                                    Update</asp:LinkButton>
                             &nbsp;|&nbsp;
                             <asp:LinkButton  ID="lbCancel" runat="server" CommandName="Cancel" ToolTip="Cancel"
                                  >Cancel</asp:LinkButton>
                           </EditItemTemplate>
                         
                     </asp:TemplateField>    
 

    </Columns>
 </asp:GridView>
       </div>
     

</asp:Content>
