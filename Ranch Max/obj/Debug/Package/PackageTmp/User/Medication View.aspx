<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Medication View.aspx.cs" Inherits="Ranch_Max.Medication_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">


    <style>
        .gvMedConEditRow input[type=text]{width:70px;}
        .gvMedConEditRow select{width:70px;}
         </style>


      <div id="content">

          <asp:Label ID="Label1" runat="server" Text="Label">Search by:</asp:Label> 

          <asp:DropDownList ID="ddSearch" runat="server" AutoPostBack="True"
               OnSelectedIndexChanged="ddSearch_SelectedIndexChanged">
              <asp:ListItem>--Select--</asp:ListItem>
              <asp:ListItem>Animal</asp:ListItem>
              <asp:ListItem>Medicine</asp:ListItem>
              <asp:ListItem>User</asp:ListItem>
           </asp:DropDownList>

          <asp:DropDownList ID="ddSearchItems" runat="server" AutoPostBack="True" 
              OnSelectedIndexChanged="ddSearchItems_SelectedIndexChanged"></asp:DropDownList>
          <asp:Button ID="Button2" runat="server" style="  border-radius:5px; background:#3498db;
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px; margin-bottom:5px" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

 
    <asp:GridView ID="gvMedCon" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="Medication_Id,StockItem_Id,Animal_Id,User_Id" CellPadding="5" CellSpacing="1"
        OnRowCancelingEdit="gvMedCon_RowCancelingEdit" OnRowDeleting="gvMedCon_RowDeleting" 
         OnRowEditing="gvMedCon_RowEditing" OnRowUpdating="gvMedCon_RowUpdating" >

                        <EditRowStyle  CssClass="gvMedConEditRow"/>


    <Columns>

                        <%--StockItem_ID--%>

                    <asp:TemplateField HeaderText="Medicine">
                         <ItemTemplate>
                           <%#Eval("StockItem.Name") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                       <asp:DropDownList ID="ddMName" runat="server" AutoPostBack="true"
                             >
                                <asp:ListItem Text="Select Medicine" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rfMed" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddMName" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                     </asp:TemplateField>


                        <%--Animal_ID--%>

        
                    <asp:TemplateField HeaderText="Animal EarTag"   >
                         <ItemTemplate>
                           <%#Eval("Animal.EarTag") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                       <asp:DropDownList ID="ddBreed" runat="server" AutoPostBack="true"
                            >
                                <asp:ListItem Text="Select Animal" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rfBreed" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddBreed" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                     </asp:TemplateField>

                    <%--NAME--%>

                     <asp:TemplateField HeaderText="User Name">
                        <ItemTemplate>
                            <%#Eval("AspNetUser.UserName") %> 

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddUName" runat="server" AutoPostBack="true"
                                  >
                                <asp:ListItem Text="Select User" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rfUser" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddUName" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                    </asp:TemplateField>

        

               <%--Quantity--%>
                     <asp:TemplateField HeaderText="Quantity">
                         <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Quantity") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtQty" Text= '<%#Eval("Quantity") %>'  runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>
             

        
                     <%--Unit--%>
                     <asp:TemplateField HeaderText="Unit">

                        <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Unit") %>' runat="server" />

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddUnit"    runat="server" AutoPostBack="false" SelectedValue='<%#Bind("Unit")%>'>
                                <asp:ListItem  Text="Select Unit" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Pcs"></asp:ListItem>
                                <asp:ListItem Text="mg"></asp:ListItem>
                                <asp:ListItem Text="ml"></asp:ListItem>
                            </asp:DropDownList>  
                        </EditItemTemplate>
                         </asp:TemplateField>
                     
        

        
                     <%--Method--%>
                     <asp:TemplateField HeaderText="Method">

                        <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Method") %>' runat="server" />

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddMethod"    runat="server" AutoPostBack="false" SelectedValue='<%#Bind("Method")%>'>
                                <asp:ListItem  Text="Select Method" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Inject"></asp:ListItem>
                                <asp:ListItem Text="Oral"></asp:ListItem>
                                <asp:ListItem Text="Inhalation"></asp:ListItem>
                            </asp:DropDownList>  
                        </EditItemTemplate>
                         </asp:TemplateField>
                     
        
        
                    <%--DATE--%>
                     <asp:TemplateField HeaderText="Date">
                         <ItemTemplate>
                           <asp:Label Text='<%#DataBinder.Eval(Container.DataItem,"Date","{0:dd/MMM/yyyy}") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtDate" Text='<%# Bind("Date", "{0:dd/MM/yyyy}") %>'   runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>
             


               <%--Time--%>
                     <asp:TemplateField HeaderText="Time">
                         <ItemTemplate>
                           <asp:Label Text='<%# Eval("Time" ) %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txttime" Text= '<%#Bind("Time","{0:hh:mm:ss tt}") %>'  TextMode="Time" runat="server"></asp:TextBox><br />

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
 
           <asp:GridView ID="gvCon" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
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
