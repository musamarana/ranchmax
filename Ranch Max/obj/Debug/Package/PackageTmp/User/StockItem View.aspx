<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="StockItem View.aspx.cs" Inherits="Ranch_Max.Users.StockItem_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">




      <style>
        .gvStockEditRow input[type=text]{width:70px;}
        .gvStockEditRow select{width:70px;}
         </style>


      <div id="content">

          <asp:Label ID="Label1" runat="server" Text="Label">Search:</asp:Label> 

          <asp:DropDownList ID="ddType" runat="server" AutoPostBack="True"
              OnSelectedIndexChanged="ddType_SelectedIndexChanged">
              <asp:ListItem>--Select--</asp:ListItem>
              <asp:ListItem>Feed</asp:ListItem>
              <asp:ListItem>Medicine</asp:ListItem>
              <asp:ListItem>Semon</asp:ListItem>
               
               
              
          </asp:DropDownList>

         
          <asp:Button ID="Button2" runat="server" style="  border-radius:5px; background:#3498db;
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px; margin-bottom:5px" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

 
    <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="StockItem_Id,StockType_Id" CellPadding="5" CellSpacing="1" OnRowCancelingEdit="gvStock_RowCancelingEdit"
        OnRowDeleting="gvStock_RowDeleting" OnRowEditing="gvStock_RowEditing" OnRowUpdating="gvStock_RowUpdating" >

                        <EditRowStyle  CssClass="gvStockEditRow"/>


    <Columns>
                        <%--Item type--%>

                    <asp:TemplateField HeaderText="Item Type"   >
                         <ItemTemplate>
                            <%#Eval("StockType.TypeName") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddIName" runat="server" AutoPostBack="true" >
                                <asp:ListItem Text="Select Type" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="rfType" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddIName" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                      
                    </asp:TemplateField>

         
                     <%--item name--%>
                     <asp:TemplateField HeaderText="Name">
                         <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Name ") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtName" Text= '<%#Eval("Name") %>'  runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                         
                    </asp:TemplateField>

                    <%--brand--%>
                     <asp:TemplateField HeaderText="Brand">
                         <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Brand") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtBrand" Text= '<%#Eval("Brand") %>'  runat="server"></asp:TextBox><br />

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
 
 
          <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
              class="table" BorderWidth="1px" CellPadding="4">
              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
              <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
              <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
              <RowStyle BackColor="White" ForeColor="#003399" />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
          </asp:GridView>
       </div>
 



</asp:Content>
