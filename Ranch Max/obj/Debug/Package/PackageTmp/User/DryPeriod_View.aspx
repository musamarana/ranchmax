<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="DryPeriod_View.aspx.cs" Inherits="Ranch_Max.DryPeriod_View" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">

 <style>
        .gvDryEditRow input[type=text]{width:70px;}
        .gvDryEditRow select{width:70px;}
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

 
    <asp:GridView ID="gvDry" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames="Dry_Id,Animal_Id " CellPadding="5" CellSpacing="1"
        OnRowCancelingEdit="gvDry_RowCancelingEdit" OnRowDeleting="gvDry_RowDeleting" 
         OnRowEditing="gvDry_RowEditing" OnRowUpdating="gvDry_RowUpdating" >

                        <EditRowStyle  CssClass="gvDryEditRow"/>


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

                           
         
        
                    <%--START DATE--%>
                     <asp:TemplateField HeaderText="Start Date">
                         <ItemTemplate>
                           <asp:Label Text='<%#DataBinder.Eval(Container.DataItem,"StartDate","{0:dd/MMM/yyyy}") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtSDate" Text='<%# Bind("StartDate", "{0:dd/MM/yyyy}") %>'   runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>


        
                    <%--END DATE--%>
                     <asp:TemplateField HeaderText="End Date">
                         <ItemTemplate>
                           <asp:Label Text='<%#DataBinder.Eval(Container.DataItem,"EndDate","{0:dd/MMM/yyyy}") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtEDate" Text='<%# Bind("EndDate", "{0:dd/MM/yyyy}") %>'    runat="server"></asp:TextBox><br />

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
 
           <asp:GridView ID="gvDry2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
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

          <asp:Chart ID="Chart1" runat="server">
        <Series>
            <asp:Series Name="No. of Animals" Legend="Legend1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1"  Alignment="Center" Docking="Bottom">
            </asp:Legend>
        </Legends>
        <Titles>
                <asp:Title Font="Microsoft Sans Serif, 20pt" Name="Title1" Text="Cows in Dry Period each Month">
                </asp:Title>
            </Titles>
    </asp:Chart>
       </div>
  
    

</asp:Content>
