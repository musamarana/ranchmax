<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Milk_Sale View.aspx.cs" Inherits="Ranch_Max.Milk_Sale_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">
    <style>
        .gvSaleEditRow input[type=text]{width:70px;}
        .gvSaleEditRow select{width:70px;}

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
              <asp:ListItem>Buyer</asp:ListItem>
               
           </asp:DropDownList>

          <asp:DropDownList ID="ddSearchItems" runat="server" AutoPostBack="True" 
              OnSelectedIndexChanged="ddSearchItems_SelectedIndexChanged"></asp:DropDownList>
          <asp:Button ID="Button2" runat="server" style="  border-radius:5px; background:#3498db;
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px;" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

 
    <asp:GridView ID="gvSale" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="MilkBuyer_Id,Buyer_Id" CellPadding="5" CellSpacing="1"
        OnRowCancelingEdit="gvSale_RowCancelingEdit" OnRowDeleting="gvSale_RowDeleting" 
         OnRowEditing="gvSale_RowEditing" OnRowUpdating="gvSale_RowUpdating" >

                        <EditRowStyle  CssClass="gvSaleEditRow"/>


    <Columns>

                        <%--Buyer_ID--%>

                    <asp:TemplateField HeaderText="Name"   >
                         <ItemTemplate>
                           <%#Eval("Buyer.Name") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                       <asp:DropDownList ID="ddBuyer" runat="server" AutoPostBack="true"
                             >
                                <asp:ListItem Text="Select Name" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rfBuyer" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddBuyer" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                     </asp:TemplateField>

                       <%--QTY--%>
                     <asp:TemplateField HeaderText="Quantity">
                         <ItemTemplate>
                           <asp:Label Text='<%# Eval("Quantity") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtQty" Text='<%# Bind("Quantity") %>' runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>
         


         
                   <%--Rate--%>
                     <asp:TemplateField HeaderText="Rate">
                         <ItemTemplate>
                           <asp:Label Text='<%# Eval("Rate") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtRate" Text='<%# Bind("Rate") %>' runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>
         

                    <%--DATE--%>
                     <asp:TemplateField HeaderText="DateTime">
                         <ItemTemplate>
                           <asp:Label Text='<%# Eval("DateTime", "{0:dd/MMM/yyyy}") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtDate" Text='<%# Bind("DateTime", "{0:dd/MM/yyyy}") %>'    runat="server"></asp:TextBox><br />

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
          <br />

          <div>
                         <asp:Label ID="Label22" runat="server" style="color:#6D7FCC; 
                font-size:22px;font-weight:bold"  > </asp:Label> 

          </div>
          <br />
          <br />

            <asp:GridView ID="gvSale2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
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
          <br />
    
          <div>
                         <asp:Label ID="Label23" runat="server" style="color:#6D7FCC; 
                font-size:22px;font-weight:bold"  > </asp:Label> 

          </div>
          <br />
          <br />

          <asp:Chart ID="Chart1" CssClass="chart" runat="server" Width="773px">
              <Series>
                  <asp:Series Name="Quantity in Litres" Legend="Legend1"></asp:Series>
              </Series>
              <ChartAreas>
                  <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
              </ChartAreas>
              <Legends>
                  <asp:Legend Name="Legend1" Docking="Bottom"  Alignment="Center">
                  </asp:Legend>
              </Legends>
              <Titles>
                <asp:Title Font="Microsoft Sans Serif, 20pt" Name="Title1" Text="Daily Milk Sold">
                </asp:Title>
            </Titles>
          </asp:Chart>
       </div>

</asp:Content>
