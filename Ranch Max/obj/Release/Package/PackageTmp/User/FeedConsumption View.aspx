<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="FeedConsumption View.aspx.cs" Inherits="Ranch_Max.FeedConsumption_View" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">
    

    <style>
        .gvFeedConEditRow input[type=text]{width:70px;}
        .gvFeedConEditRow select{width:70px;}
         </style>


      <div id="content">

          <asp:Label ID="Label1" runat="server" Text="Label">Search by:</asp:Label> 

          <asp:DropDownList ID="ddSearch" runat="server" AutoPostBack="True"
               OnSelectedIndexChanged="ddSearch_SelectedIndexChanged">
              <asp:ListItem>--Select--</asp:ListItem>
              <asp:ListItem>Breed</asp:ListItem>
              <asp:ListItem>Formula</asp:ListItem>
              <asp:ListItem>User</asp:ListItem>
           </asp:DropDownList>

          <asp:DropDownList ID="ddSearchItems" runat="server" AutoPostBack="True" 
              OnSelectedIndexChanged="ddSearchItems_SelectedIndexChanged"></asp:DropDownList>
          <asp:Button ID="Button2" runat="server" style="  border-radius:5px; background:#3498db;
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px; margin-bottom:5px" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

 
    <asp:GridView ID="gvFeedCon" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="ConsumptionId,Formula_Id ,Animal_Id,User_Id" CellPadding="5" CellSpacing="1"
        OnRowCancelingEdit="gvFeedCon_RowCancelingEdit" OnRowDeleting="gvFeedCon_RowDeleting" 
         OnRowEditing="gvFeedCon_RowEditing" OnRowUpdating="gvFeedCon_RowUpdating" >

                        <EditRowStyle  CssClass="gvFeedConEditRow"/>


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


                        <%--Animal_ID--%>

        
                    <asp:TemplateField HeaderText="Breed"   >
                         <ItemTemplate>
                           <%#Eval("Animal.AnimalBreed.Breed") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                       <asp:DropDownList ID="ddBreed" runat="server" AutoPostBack="true"
                            >
                                <asp:ListItem Text="Select Breed" Value="0"></asp:ListItem>

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

        
                           
        
                     <%--Slot--%>
                     <asp:TemplateField HeaderText="Feed Slot">

                        <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Slot") %>' runat="server" />

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddSlot"    runat="server" AutoPostBack="false" SelectedValue='<%#Bind("Slot")%>'>
                                <asp:ListItem  Text="Select Unit" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Slot 1"></asp:ListItem>
                                <asp:ListItem Text="Slot 2"></asp:ListItem>
                                <asp:ListItem Text="Slot 3"></asp:ListItem>
                            </asp:DropDownList>  
                        </EditItemTemplate>
                         </asp:TemplateField>
                     
        
        
                    <%--DATE--%>
                     <asp:TemplateField HeaderText="Date"  >
                         <ItemTemplate>
                           <asp:Label ID="lblDate" Text='<%#DataBinder.Eval(Container.DataItem,"Date","{0:dd/MM/yyyy}") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>

                         <asp:TextBox ID="txtDate" Text='<%# Bind("Date" ,"{0:dd/MM/yyyy}") %>'   runat="server"></asp:TextBox><br />
<%--                         <asp:Calendar runat="server" ID="Calendar1" Height="126px" Width="206px"></asp:Calendar>--%>
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
