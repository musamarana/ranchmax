<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="FeedPrepairing View.aspx.cs" Inherits="Ranch_Max.FeedPrepairing_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">

    <style>
        .gvFeedPreEditRow input[type=text]{width:70px;}
        .gvFeedPreEditRow select{width:70px;}
         </style>


      <div id="content">

          <asp:Label ID="Label1" runat="server" Text="Label">Search by:</asp:Label> 

          <asp:DropDownList ID="ddSearch" runat="server" AutoPostBack="True"
               OnSelectedIndexChanged="ddSearch_SelectedIndexChanged">
              <asp:ListItem>--Select--</asp:ListItem>
               <asp:ListItem>Formula</asp:ListItem>
              <asp:ListItem>Item</asp:ListItem>
           </asp:DropDownList>

          <asp:DropDownList ID="ddSearchItems" runat="server" AutoPostBack="True" 
              OnSelectedIndexChanged="ddSearchItems_SelectedIndexChanged"></asp:DropDownList>
          <asp:Button ID="Button2" runat="server" style="  border-radius:5px; background:#3498db;
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px; margin-bottom:5px" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

 
    <asp:GridView ID="gvFeedPre" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="Id,Formula_Id ,StockItem_Id" CellPadding="5" CellSpacing="1"
        OnRowCancelingEdit="gvFeedPre_RowCancelingEdit" OnRowDeleting="gvFeedPre_RowDeleting" 
         OnRowEditing="gvFeedPre_RowEditing" OnRowUpdating="gvFeedPre_RowUpdating" >

                        <EditRowStyle  CssClass="gvFeedPreEditRow"/>


    <Columns>

                        <%--Formula_ID--%>

                    <asp:TemplateField HeaderText="Formula Name"   >
                         <ItemTemplate>
                           <%#Eval("FeedFormula.FormulaName") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                       <asp:DropDownList ID="ddFName" runat="server" AutoPostBack="true"
                             >
                                <asp:ListItem Text="Select Formula" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rfFormula" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddFName" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                     </asp:TemplateField>

         
                    <%--StockItem--%>

                     <asp:TemplateField HeaderText="Item Name">
                        <ItemTemplate>
                            <%#Eval("StockItem.Name") %> 

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddIName" runat="server" AutoPostBack="true"
                                  >
                                <asp:ListItem Text="Select Item" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rfItem" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddIName" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                    </asp:TemplateField>

        
                           
        
                      <%--quantity--%>
                     <asp:TemplateField HeaderText="Quantity">
<%--                        <HeaderTemplate>Emp_ID</HeaderTemplate>--%>
                        <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Quantity") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtQ" Text= '<%#Eval("Quantity") %>'  runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                         
                    </asp:TemplateField>



        <%--UNIT--%>
                     <asp:TemplateField HeaderText="Unit">

                        <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Unit") %>' runat="server" />

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddUnit"    runat="server" AutoPostBack="false" SelectedValue='<%#Bind("Unit")%>'>
                                <asp:ListItem  Text="Select Unit" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Kg"></asp:ListItem>
                                <asp:ListItem Text="Pcs"></asp:ListItem>
                                <asp:ListItem Text="Ltr"></asp:ListItem>
                            </asp:DropDownList>  
                        </EditItemTemplate>
                         </asp:TemplateField>
                     
                     <%--RATE--%>
                     <asp:TemplateField HeaderText="Rate">
<%--                        <HeaderTemplate>Emp_ID</HeaderTemplate>--%>
                        <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Rate") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtRate" Text= '<%#Eval("Rate") %>'  runat="server"></asp:TextBox><br />

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
 
           <asp:GridView ID="gvFPre" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
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
