<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Breeding_View.aspx.cs" Inherits="Ranch_Max.Breeding_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">

 
<style>
        .gvbreedEditRow input[type=text]{width:70px;}
        .gvbreedEditRow select{width:70px;}

        .chart{
           margin-left:50px;
           margin-top:50px;
           resize:horizontal;

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
              <asp:ListItem>F_Animal</asp:ListItem>
              <asp:ListItem>M_Animal</asp:ListItem>
              <asp:ListItem>Type</asp:ListItem>
              <asp:ListItem>User</asp:ListItem>
           </asp:DropDownList>

          <asp:DropDownList ID="ddSearchItems" runat="server" AutoPostBack="True" 
              OnSelectedIndexChanged="ddSearchItems_SelectedIndexChanged"></asp:DropDownList>
          <asp:Button ID="Button2" runat="server" style="  border-radius:5px; background:#3498db;
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px; margin-bottom:5px" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

 
    <asp:GridView ID="gvbreed" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="Breeding_Id,Animal_Id,Animal_Id_M,User_Id" CellPadding="5" CellSpacing="1"
        OnRowCancelingEdit="gvbreed_RowCancelingEdit" OnRowDeleting="gvbreed_RowDeleting" 
         OnRowEditing="gvbreed_RowEditing" OnRowUpdating="gvbreed_RowUpdating" >

                        <EditRowStyle  CssClass="gvbreedEditRow"/>


    <Columns>
         
                        <%--Animal_ID female--%>

        
                    <asp:TemplateField HeaderText="F_Animal"   >
                         <ItemTemplate>
                           <%#Eval("Animal.EarTag") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                       <asp:DropDownList ID="ddTag" runat="server" AutoPostBack="true" >
                                <asp:ListItem Text="Select Animal" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rfTag" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddTag" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                     </asp:TemplateField>

                        <%--Animal_ID male--%>

        
                    <asp:TemplateField HeaderText="M_Animal"   >
                         <ItemTemplate>
                           <%#Eval("Animal1.EarTag") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                       <asp:DropDownList ID="ddTag1" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
                                <asp:ListItem Text="Select Animal" Value="0"></asp:ListItem>

                            </asp:DropDownList>
        <%--                  <asp:RequiredFieldValidator ID="rfTag1" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddTag1" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        --%>
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

                           
            <%--TYPE--%>
             <asp:TemplateField HeaderText="Type">

                        <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Type") %>' runat="server" />

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddtype"    runat="server" AutoPostBack="false" SelectedValue='<%#Bind("Type")%>'>
                              <asp:ListItem Text="--Select--" Value="0"> 

                         </asp:ListItem> 
                     <asp:ListItem>Natural</asp:ListItem>
                    <asp:ListItem>Artificial</asp:ListItem>
                     
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


                <%--DOSE--%>
                     <asp:TemplateField HeaderText="Dose">
                         <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Dose") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtdose" Text= '<%#Eval("Dose") %>'  runat="server"></asp:TextBox><br />

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
 
           <asp:GridView ID="gvbreed2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
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
          <asp:Chart ID="Chart1" CssClass="chart" runat="server" Height="350px" Width="800px">
              <Series>
                  <asp:Series Name="No. of Animals Bred" Legend="Legend1"></asp:Series>
              </Series>
              <ChartAreas>
                  <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
              </ChartAreas>
              <Legends>
                  <asp:Legend Name="Legend1" Alignment="Center" Docking="Bottom">
                  </asp:Legend>
              </Legends>
              <Titles>
                <asp:Title Font="Microsoft Sans Serif, 20pt" Name="Title1" Text="Breedings Each Month">
                </asp:Title>
                </Titles>
          </asp:Chart>

       </div>
  


</asp:Content>
