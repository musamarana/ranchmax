<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Calving_View.aspx.cs" Inherits="Ranch_Max.Calving_View" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">


<style>
        .gvCalveEditRow input[type=text]{width:70px;}
        .gvCalveEditRow select{width:70px;}

           .chart{
           margin-left:100px;
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
              <asp:ListItem>Animal</asp:ListItem>
            </asp:DropDownList>

          <asp:DropDownList ID="ddSearchItems" runat="server" AutoPostBack="True" 
              OnSelectedIndexChanged="ddSearchItems_SelectedIndexChanged"></asp:DropDownList>
          <asp:Button ID="Button2" runat="server" style="  border-radius:5px; background:#3498db;
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px; margin-bottom:5px" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

 
    <asp:GridView ID="gvCalve" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="Calving_Id,Animal_Id " CellPadding="5" CellSpacing="1"
        OnRowCancelingEdit="gvCalve_RowCancelingEdit" OnRowDeleting="gvCalve_RowDeleting" 
         OnRowEditing="gvCalve_RowEditing" OnRowUpdating="gvCalve_RowUpdating" >

                        <EditRowStyle  CssClass="gvCalveEditRow"/>


    <Columns>
         
                        <%--Animal_ID--%>

        
                    <asp:TemplateField HeaderText="Animal EarTag"   >
                         <ItemTemplate>
                           <%#Eval("Animal.EarTag") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                       <asp:DropDownList ID="ddTag" runat="server" AutoPostBack="true"
                            >
                                <asp:ListItem Text="Select Animal" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rfTag" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddTag" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
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


        
                    <%--Gender--%>

                     <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <%#Eval("Gender") %> 

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddGender" runat="server" AutoPostBack="false" SelectedValue='<%#Bind("Gender")%>'>
                     <asp:ListItem Text="--Select--" Value="0"></asp:ListItem> 
                        <asp:ListItem>M</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>
                   
                            </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rfGender" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddGender" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                    </asp:TemplateField>

        
                           
        
                     <%--STATUS--%>
                     <asp:TemplateField HeaderText="Status">

                        <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Status") %>' runat="server" />

                        </ItemTemplate>
                        <EditItemTemplate>
                       <asp:DropDownList ID="ddStatus"   runat="server" AutoPostBack="false" SelectedValue='<%#Bind("Status")%>'>
                       <asp:ListItem Text="--Select--" Value="0"> 

                         </asp:ListItem> 
                    <asp:ListItem>Alive</asp:ListItem>
                    <asp:ListItem>Dead</asp:ListItem> 
                            </asp:DropDownList>  
                        </EditItemTemplate>
                         </asp:TemplateField>
                     
               <%--Weight--%>
                     <asp:TemplateField HeaderText="Weight">
                         <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Weight") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtWeight" Text= '<%#Eval("Weight") %>'  runat="server"></asp:TextBox><br />

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
 
           <asp:GridView ID="gvCalve2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
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

          <asp:Chart ID="Chart1" CssClass="chart" runat="server" Height="337px" Width="623px">
              <Series>
                  <asp:Series Name="Number of Calves" Legend="Legend1"></asp:Series>
              </Series>
              <ChartAreas>
                  <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
              </ChartAreas>
              <Legends>
                  <asp:Legend Name="Legend1" Alignment="Center" Docking="Bottom">
                  </asp:Legend>
              </Legends>
              <Titles>
                <asp:Title Font="Microsoft Sans Serif, 20pt" Name="Title1" Text="Calves Born Monthly">
                </asp:Title>
            </Titles>
          </asp:Chart>

          <asp:Chart ID="Chart2" CssClass="chart" runat="server" Height="383px" Width="412px">
              <Series>
                  <asp:Series Name="Series1" ChartType="Pie" Legend="Legend1"></asp:Series>
              </Series>
              <ChartAreas>
                  <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
              </ChartAreas>
              <Legends>
                  <asp:Legend Name="Legend1" Alignment="Center" Docking="Bottom">
                  </asp:Legend>
              </Legends>
              <Titles>
                <asp:Title Font="Microsoft Sans Serif, 20pt" Name="Title1" Text="Calve Status Breakdown">
                </asp:Title>
            </Titles>
          </asp:Chart>
       </div>
  


</asp:Content>
