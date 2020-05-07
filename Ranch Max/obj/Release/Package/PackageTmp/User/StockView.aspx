<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="StockView.aspx.cs" Inherits="Ranch_Max.StockView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">


      <style>
        .gvStockEditRow input[type=text]{width:70px;}
        .gvStockEditRow select{width:70px;}
         </style>


      <div id="content">

          <asp:Label ID="Label1" runat="server" Text="Label">Search by Type:</asp:Label> 

          <asp:DropDownList ID="ddType" runat="server" AutoPostBack="True"
              OnSelectedIndexChanged="ddType_SelectedIndexChanged">
              <asp:ListItem>--Select--</asp:ListItem>
              <asp:ListItem>Feed</asp:ListItem>
              <asp:ListItem>Medicine</asp:ListItem>
              <asp:ListItem>Semon</asp:ListItem>
               
               
              
          </asp:DropDownList>

          <asp:DropDownList ID="ddTypeItems" runat="server" AutoPostBack="True" 
              OnSelectedIndexChanged="ddTypeItems_SelectedIndexChanged"></asp:DropDownList>
          <asp:Button ID="Button2" runat="server" style="  border-radius:5px; background:#3498db;
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px; margin-bottom:5px" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

 
    <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="StockAdd_Id,StockItem_Id,User_Id" CellPadding="5" CellSpacing="1" OnRowCancelingEdit="gvStock_RowCancelingEdit"
        OnRowDeleting="gvStock_RowDeleting" OnRowEditing="gvStock_RowEditing" OnRowUpdating="gvStock_RowUpdating" >

                        <EditRowStyle  CssClass="gvStockEditRow"/>


    <Columns>
                        <%--Item Name--%>

                    <asp:TemplateField HeaderText="Item Name"   >
<%--                        <HeaderTemplate>Emp_ID</HeaderTemplate>--%>
                        <ItemTemplate>
                            <%#Eval("StockItem.Name") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddIName" runat="server" AutoPostBack="true"
                           OnSelectedIndexChanged="ddIName_SelectedIndexChanged"  >
                                <asp:ListItem Text="Select Item" Value="0"></asp:ListItem>

                            </asp:DropDownList>
<%--                         <asp:TextBox ID="txtIName" Text= '<%#Eval("Name") %>'  runat="server"></asp:TextBox><br />--%>
                            <asp:RequiredFieldValidator ID="rfItem" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddIName" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                      
                    </asp:TemplateField>

                    <%--User NAME--%>

                     <asp:TemplateField HeaderText="User Name">
<%--                        <HeaderTemplate>Emp_ID</HeaderTemplate>--%>
                        <ItemTemplate>
                            <%#Eval("AspNetUser.UserName") %> 

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddUName" runat="server" AutoPostBack="true"
                               OnSelectedIndexChanged="ddUName_SelectedIndexChanged"    >
                                <asp:ListItem Text="Select User" Value="0"></asp:ListItem>

                            </asp:DropDownList>


<%--                         <asp:TextBox ID="txtUName" Text= '<%#Eval("UserName") %>'  runat="server"></asp:TextBox><br />--%>
                            <asp:RequiredFieldValidator ID="rfUser" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddUName" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                    </asp:TemplateField>


                     <%--Total Bags--%>
                     <asp:TemplateField HeaderText="TotalBags/Packs">
<%--                        <HeaderTemplate>Emp_ID</HeaderTemplate>--%>
                        <ItemTemplate>
                           <asp:Label Text= '<%#Eval("TotalBags_Packs ") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtTBags" Text= '<%#Eval("TotalBags_Packs") %>'  runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                         
                    </asp:TemplateField>

                    <%--bagsize--%>
                     <asp:TemplateField HeaderText="BagSize/PackSize">
<%--                        <HeaderTemplate>Emp_ID</HeaderTemplate>--%>
                        <ItemTemplate>
                           <asp:Label Text= '<%#Eval("BagSize_PackSize") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtBSize" Text= '<%#Eval("BagSize_PackSize") %>'  runat="server"></asp:TextBox><br />

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


                    <%--DATE--%>
                     <asp:TemplateField HeaderText="Expiry">
<%--                        <HeaderTemplate>Emp_ID</HeaderTemplate>--%>
                        <ItemTemplate>
                           <asp:Label Text='<%#DataBinder.Eval(Container.DataItem,"Expiry","{0:dd/MMM/yyyy}") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtDate" Text= '<%#Bind("Expiry", "{0:dd/MM/yyyy}") %>'   runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>
               

                                     <%--Unit--%>
                     <asp:TemplateField HeaderText="Unit">

                        <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Unit") %>' runat="server" />

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddUnit"    runat="server" AutoPostBack="false"  >
                                <asp:ListItem  Text="Select Unit" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Kg"></asp:ListItem>
                                <asp:ListItem Text="Pcs"></asp:ListItem>
                                <asp:ListItem Text="mg"></asp:ListItem>
                                <asp:ListItem Text="ml"></asp:ListItem>
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
 
<%--        <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-md" Text="Download PDF" style="  border-radius:10px; background:#3498db; text-decoration-color:white; padding:5px 5px 5px 5px; width:150px; font-size:18px;" OnClick="Button1_Click"/>--%>

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
