<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Animal_Sale View.aspx.cs" Inherits="Ranch_Max.Animal_Sale_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">
      <style>
        .gvAniSaleEditRow input[type=text]{width:70px;}
        .gvAniSaleEditRow select{width:70px;}
          .chart{
           margin-left:50px;
           margin-top:50px;

       }

       .chart:hover{
           box-shadow:2px 3px 15px #999;
       }
         </style>


      <div id="content">

          <asp:Label ID="Label1" runat="server" Text="Label">Search by:</asp:Label> 

          <asp:DropDownList ID="ddSearch" runat="server" AutoPostBack="True"
               OnSelectedIndexChanged="ddSearch_SelectedIndexChanged">
              <asp:ListItem>--Select--</asp:ListItem>
              <asp:ListItem>Animal</asp:ListItem>
               
           </asp:DropDownList>

          <asp:DropDownList ID="ddSearchItems" runat="server" AutoPostBack="True" 
              OnSelectedIndexChanged="ddSearchItems_SelectedIndexChanged"></asp:DropDownList>
          <asp:Button ID="Button2" runat="server" style="  border-radius:5px; background:#3498db;
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px;" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

 
    <asp:GridView ID="gvAniSale" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="AnimalSale_Id,Animal_Id" CellPadding="5" CellSpacing="1"
        OnRowCancelingEdit="gvAniSale_RowCancelingEdit" OnRowDeleting="gvAniSale_RowDeleting" 
         OnRowEditing="gvAniSale_RowEditing" OnRowUpdating="gvAniSale_RowUpdating" >

                        <EditRowStyle  CssClass="gvAniSaleEditRow"/>


    <Columns>

                        <%--Animal_ID--%>

                    <asp:TemplateField HeaderText="Animal"   >
                         <ItemTemplate>
                           <%#Eval("Animal.EarTag") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                       <asp:DropDownList ID="ddETag" runat="server" AutoPostBack="true"
                             >
                                <asp:ListItem Text="Select Animal" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rfTag" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddETag" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                     </asp:TemplateField>

                       <%--Amnt--%>
                     <asp:TemplateField HeaderText="Amount">
                         <ItemTemplate>
                           <asp:Label Text='<%# Eval("Amount") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtAmnt" Text='<%# Bind("Amount") %>' runat="server"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="rfAmnt" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtAmnt" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                        
                    </asp:TemplateField>
         

                    <%--DATE--%>
                     <asp:TemplateField HeaderText="Date">
                         <ItemTemplate>
                           <asp:Label Text='<%#DataBinder.Eval(Container.DataItem,"Date","{0:dd/MMM/yyyy}") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtDate" Text='<%# Bind("Date", "{0:dd/MM/yyyy}") %>'    runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>
             




         
                   <%--Buyer NAME--%>
                     <asp:TemplateField HeaderText="Buyer Name">
                         <ItemTemplate>
                           <asp:Label Text='<%# Eval("BuyerName") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtBuyer" Text='<%# Bind("BuyerName") %>' runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>
         

                  <%--Buyer cnic--%>
                     <asp:TemplateField HeaderText="Buyer CNIC">
                         <ItemTemplate>
                           <asp:Label Text='<%# Eval("CNIC") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtBuyerNIC" Text='<%# Bind("CNIC") %>' runat="server"></asp:TextBox><br />

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
            <asp:GridView ID="gvAniSale2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
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
          <asp:Chart ID="Chart1" CssClass="chart" runat="server" Width="874px" Height="307px">
              <Series>
                  <asp:Series Name="No. of Animals Sold" Legend="Legend1"></asp:Series>
              </Series>
              <ChartAreas>
                  <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
              </ChartAreas>
              <Legends>
                  <asp:Legend Name="Legend1" Docking="Bottom"  Alignment="Center">
                  </asp:Legend>
              </Legends>
              <Titles>
                <asp:Title Font="Microsoft Sans Serif, 20pt" Name="Title1" Text="Monthly Animals Sold">
                </asp:Title>
            </Titles>
          </asp:Chart>

       </div>

</asp:Content>
