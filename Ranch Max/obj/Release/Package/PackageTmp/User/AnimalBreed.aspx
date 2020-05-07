<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="AnimalBreed.aspx.cs" Inherits="Ranch_Max.AnimalBreed1" %>
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
            ENTER BREED NAME</h3>
        <br />
        <br />

        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-borderless">
            
                
                <tr>
                <td style="width: 197px"><asp:Label ID="lblBreed" runat="server" Text="Breed Name" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtBreed" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="rfbreed" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtBreed" ForeColor="Red" 
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

      
      <br />
        <br />

        
      <br />
        <br />

        
    
    <asp:GridView ID="gvBreed" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="Breed_Id" CellPadding="5" CellSpacing="1" OnRowDeleting="gvBreed_RowDeleting"
         OnRowCancelingEdit="gvBreed_RowCancelingEdit" OnRowEditing="gvBreed_RowEditing" OnRowUpdating="gvBreed_RowUpdating">

  
    <Columns>
                            <%--Breed--%>
                     <asp:TemplateField HeaderText="Breed Name">
                         <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Breed") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtBreed" Text= '<%#Eval("Breed") %>'  runat="server"></asp:TextBox><br />

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
