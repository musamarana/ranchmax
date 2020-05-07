<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Milk_Buyer View.aspx.cs" Inherits="Ranch_Max.Milk_Buyer_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">

    <style>
        .gvBuyEditRow input[type=text]{width:70px;}
        .gvBuyEditRow select{width:70px;}
         </style>


      <div id="content">

          <asp:Label ID="Label1" runat="server" Text="Label">Search by:</asp:Label> 

          <asp:DropDownList ID="ddSearch" runat="server" AutoPostBack="True"
               OnSelectedIndexChanged="ddSearch_SelectedIndexChanged">
              <asp:ListItem>--Select--</asp:ListItem>
              <asp:ListItem>Name</asp:ListItem>
               
           </asp:DropDownList>

          <asp:DropDownList ID="ddSearchItems" runat="server" AutoPostBack="True" 
              OnSelectedIndexChanged="ddSearchItems_SelectedIndexChanged"></asp:DropDownList>
          <asp:Button ID="Button2" runat="server" style="  border-radius:5px; background:#3498db;
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px;" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

 
    <asp:GridView ID="gvBuy" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="Buyer_Id" CellPadding="5" CellSpacing="1"
        OnRowCancelingEdit="gvBuy_RowCancelingEdit" OnRowDeleting="gvBuy_RowDeleting" 
         OnRowEditing="gvBuy_RowEditing" OnRowUpdating="gvBuy_RowUpdating" >

                        <EditRowStyle  CssClass="gvBuyEditRow"/>


    <Columns>

                        <%--NAME--%>

                    <asp:TemplateField HeaderText="Name"   >
                         <ItemTemplate>
                           <%#Eval("Name") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                <asp:TextBox ID="txtName" Text= '<%#Eval("Name") %>'  runat="server"></asp:TextBox><br />
             <asp:RequiredFieldValidator ID="rfName" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtName" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                     </asp:TemplateField>

                       <%--CNIC--%>
                     <asp:TemplateField HeaderText="CNIC">
                         <ItemTemplate>
                           <asp:Label Text='<%# Eval("CNIC") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtCNIC" Text='<%# Bind("CNIC") %>' runat="server"></asp:TextBox><br />
                              <asp:RegularExpressionValidator  runat="server"  ID="rexcnic"  ControlToValidate="txtCNIC"
                       ValidationExpression ="^[0-9]{5}-[0-9]{7}-[0-9]$"  ErrorMessage="CNIC No must follow the XXXXX-XXXXXXX-X format!"></asp:RegularExpressionValidator>
                        
                        </EditItemTemplate>
                        
                    </asp:TemplateField>
         


         
                   <%--PHONE--%>
                     <asp:TemplateField HeaderText="Phone">
                         <ItemTemplate>
                           <asp:Label Text='<%# Eval("Phone") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtPhone" Text='<%# Bind("Phone") %>' runat="server"></asp:TextBox><br />
                            <asp:RegularExpressionValidator  runat="server"  ID="rexPhn"  ControlToValidate="txtPhone"
                       ValidationExpression ="^[0-9]{4}-[0-9]{7}$"  ErrorMessage="CELL NO. must follow the XXXX-XXXXXXX format!"></asp:RegularExpressionValidator>
                       
                        </EditItemTemplate>
                        
                    </asp:TemplateField>
         

                    <%--Address--%>
                     <asp:TemplateField HeaderText="Address">
                         <ItemTemplate>
                           <asp:Label Text='<%# Eval("Address") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtAdd" Text='<%# Bind("Address") %>'   runat="server"></asp:TextBox><br />

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
            <asp:GridView ID="gvBuy2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
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
