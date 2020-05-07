<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Animal_View.aspx.cs" Inherits="Ranch_Max.Animal_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">



    <style>
        .gvAnimalEditRow input[type=text]{width:20px;}
        .gvAnimalEditRow select{width:20px;}
        .gvAnimalEditRow input[type=date]{width:30px;}

        .chart{
           margin-left:-750px;
           margin-top:30px;
           

       }

       .chart:hover{
           box-shadow:2px 3px 15px #999;
       }

       .chart2{
           margin-right: -750px;
           margin-top:30px;
          
       }

       .chart2:hover{
           box-shadow:2px 3px 15px #999;
       }

         </style>


      <div id="content">

          <asp:Label ID="Label1" runat="server" Text="Label">Search by:</asp:Label> 

          <asp:DropDownList ID="ddSearch" runat="server" AutoPostBack="True"
               OnSelectedIndexChanged="ddSearch_SelectedIndexChanged">
              <asp:ListItem>--Select--</asp:ListItem>
              <asp:ListItem>EarTag</asp:ListItem>
              <asp:ListItem>Breed</asp:ListItem>
              <asp:ListItem>Gender</asp:ListItem>
           </asp:DropDownList>

          <asp:DropDownList ID="ddSearchItems" runat="server" AutoPostBack="True" 
              OnSelectedIndexChanged="ddSearchItems_SelectedIndexChanged"></asp:DropDownList>
          <asp:Button ID="Button2" runat="server" style="  border-radius:5px; background:#3498db;
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px; margin-bottom:5px;" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

 
    <asp:GridView ID="gvAnimal" runat="server" AutoGenerateColumns="False"  class="table" AllowSorting="True" 
             DataKeyNames=" Animal_Id,Breed_Id " CellPadding="5" CellSpacing="1"
        OnRowCancelingEdit="gvAnimal_RowCancelingEdit" 
         OnRowEditing="gvAnimal_RowEditing" OnRowUpdating="gvAnimal_RowUpdating" >

                        <EditRowStyle  CssClass="gvAnimalEditRow"/>
 
    <Columns>

                        <%--EAR TAG--%>

                    <asp:TemplateField HeaderText="EarTag"   >
                         <ItemTemplate>
                           <%#Eval("EarTag") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                <asp:TextBox ID="txtETag" Text= '<%#Eval("EarTag") %>'  runat="server"></asp:TextBox><br />
             <asp:RequiredFieldValidator ID="rfETag" runat="server"
                    ErrorMessage="Required." ControlToValidate="txtETag" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                     </asp:TemplateField>

                      <%-- CATEGORY--%>

        
                    <asp:TemplateField HeaderText="Category"   >
                         <ItemTemplate>
                           <%#Eval("Category") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                       <asp:DropDownList ID="ddCat" runat="server" AutoPostBack="false"   SelectedValue='<%#Bind("Category")%>' >
                     <asp:ListItem Text="--Select--" Value="0"> 

                         </asp:ListItem> 
                    <asp:ListItem>Bull</asp:ListItem>
                    <asp:ListItem>Cow</asp:ListItem>
                    <asp:ListItem>Calve</asp:ListItem>

                          
                            </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rfCat" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddCat" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
       
                        </EditItemTemplate>
                     </asp:TemplateField>


                        <%--ORIGIN COUNTRY--%>

        
                    <asp:TemplateField HeaderText="Country"   >
                         <ItemTemplate>
                           <%#Eval("OriginCountry") %> 

                        </ItemTemplate  >

 
                        <EditItemTemplate>
                       <asp:DropDownList ID="ddCountry" runat="server" AutoPostBack="false" SelectedValue='<%#Bind("OriginCountry")%>'>
                    <asp:ListItem Text="--Select--" Value="0"> 

                         </asp:ListItem> 
                    <asp:ListItem>Pakistan</asp:ListItem>
                    <asp:ListItem>India</asp:ListItem>
                    <asp:ListItem>Australia</asp:ListItem>
                    <asp:ListItem>China</asp:ListItem>
                    <asp:ListItem>-France</asp:ListItem>
                    <asp:ListItem>Ethiopia</asp:ListItem>

                            </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="rfCountry" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddCountry" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator>
        
                        </EditItemTemplate>
                     </asp:TemplateField>

                    <%--Gender--%>

                     <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Gender") %>' runat="server" />
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
                            <asp:DropDownList ID="ddStatus"    runat="server" AutoPostBack="false" SelectedValue='<%#Bind("Status")%>'>
                              <asp:ListItem Text="--Select--" Value="0"> 

                         </asp:ListItem> 
                    <asp:ListItem>Active</asp:ListItem>
                    <asp:ListItem>Non-Active</asp:ListItem>
                    <asp:ListItem>Sold</asp:ListItem>

                            </asp:DropDownList>  
                        </EditItemTemplate>
                         </asp:TemplateField>
                     
        
                     <%--Breed--%>
                     <asp:TemplateField HeaderText="Breed">

                        <ItemTemplate>
                            <%#Eval("AnimalBreed.Breed") %>

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddBreed"    runat="server" AutoPostBack="true">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem> 
                         
                            </asp:DropDownList>  
                        </EditItemTemplate>
                         </asp:TemplateField>
                     
               <%--Lactation--%>
                     <asp:TemplateField HeaderText="Lact">
                         <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Lactation") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtLact" Text= '<%#Eval("Lactation") %>'  runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>
             

               <%--SIRE--%>
                     <asp:TemplateField HeaderText="Sire">
                         <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Sire") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtSire" Text= '<%#Eval("Sire") %>'  runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>
             



                    <%--INSERTION DATE--%>
                     <asp:TemplateField HeaderText="IDate">
                         <ItemTemplate>
                           <asp:Label Text='<%#DataBinder.Eval(Container.DataItem,"InsertionDate","{0:dd/MMM/yyyy}") %>'  runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtIDate" Text='<%# Bind("InsertionDate","{0:dd/MM/yyyy}") %>'   runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>
             

                    <%--Birth DATE--%>
                     <asp:TemplateField HeaderText="BDate">
                         <ItemTemplate>
                           <asp:Label Text='<%#DataBinder.Eval(Container.DataItem,"Birthdate","{0:dd/MMM/yyyy}") %>'  runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtBDate" Text='<%# Bind("Birthdate", "{0:dd/MM/yyyy}") %>'    runat="server"></asp:TextBox><br />

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
                    <%--Age--%>
                     <asp:TemplateField HeaderText="Age">
                         <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Age") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtAge" Text= '<%#Eval("Age") %>'  runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>
             
                            <%--price--%>
                     <asp:TemplateField HeaderText="Price">
                         <ItemTemplate>
                           <asp:Label Text= '<%#Eval("Price") %>' runat="server"/>

                        </ItemTemplate>
                        <EditItemTemplate>
                         <asp:TextBox ID="txtPrice" Text= '<%#Eval("Price") %>'  runat="server"></asp:TextBox><br />

                        </EditItemTemplate>
                        
                    </asp:TemplateField>



                          <%--OPTION--%>

                       <asp:TemplateField>

                         <ItemTemplate> 
                             <asp:LinkButton  ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit">Edit</asp:LinkButton>
                             <%--&nbsp;|&nbsp;
                             <asp:LinkButton  ID="lbDelete" runat="server" CommandName="Delete"
                                  OnClientClick="return  confirm('Are You Sure?')" ToolTip="Delete">Delete</asp:LinkButton>
                         --%></ItemTemplate>
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
 
           <asp:GridView ID="gvAni" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
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
