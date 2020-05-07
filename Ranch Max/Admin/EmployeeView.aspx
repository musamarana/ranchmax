<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="EmployeeView.aspx.cs" Inherits="Ranch_Max.Users.EmployeeView1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">

    
 <style>
        .gvEmpEditRow input[type=text]{width:70px;}
        .gvEmpEditRow select{width:70px;}
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
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px; margin-bottom:5px" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

 
    <asp:GridView ID="gvEmp" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="InfoId,Id" CellPadding="5" CellSpacing="1"
        OnRowCancelingEdit="gvEmp_RowCancelingEdit" OnRowDeleting="gvEmp_RowDeleting" 
         OnRowEditing="gvEmp_RowEditing" OnRowUpdating="gvEmp_RowUpdating" >

                        <EditRowStyle  CssClass="gvEmpEditRow"/>


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


        
                        <%--FNAME--%>

              <asp:TemplateField HeaderText="F_Name"   >
                         <ItemTemplate>
                           <%#Eval("Fname") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                <asp:TextBox ID="txtFname" Text= '<%#Eval("Fname") %>'  runat="server"></asp:TextBox><br />
             <asp:RequiredFieldValidator ID="rfFname" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtFname" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                     </asp:TemplateField>



                        <%--CNIC--%>

        
                    <asp:TemplateField HeaderText="CNIC"   >
                         <ItemTemplate>
                           <%#Eval("Cnic") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                        <asp:TextBox ID="txtCNIC" Text='<%# Bind("Cnic") %>' runat="server"></asp:TextBox><br />

                          <asp:RequiredFieldValidator ID="rfcnic" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtCNIC" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                     </asp:TemplateField>

                    <%--address--%>
        
        
                    <asp:TemplateField HeaderText="Address"   >
                         <ItemTemplate>
                           <%#Eval("Address") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                        <asp:TextBox ID="txtadd" Text='<%# Bind("Address") %>' runat="server"></asp:TextBox><br />

                          <asp:RequiredFieldValidator ID="rfadd" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtadd" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                     </asp:TemplateField>
        
         <%--userNAME--%>

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
          <%--email--%>

                     <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <%#Eval("AspNetUser.Email") %> 

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddEmail" runat="server" AutoPostBack="true"
                                  >
                                <asp:ListItem Text="Select Email" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rfEmail" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddEmail" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                    </asp:TemplateField>

 
                           <%--phone--%>
        
        
                    <asp:TemplateField HeaderText="Phone"   >
                         <ItemTemplate>
                           <%#Eval("AspNetUser.PhoneNumber") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                        <asp:TextBox ID="txtph" Text='<%# Bind("AspNetUser.PhoneNumber") %>' runat="server"></asp:TextBox>
                            <br />

                          <asp:RequiredFieldValidator ID="rfph" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtph" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
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
 
           <asp:GridView ID="gvEmp2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
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
