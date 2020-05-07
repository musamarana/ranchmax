<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Animal_Add.aspx.cs" Inherits="Ranch_Max.Animal_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">

    <style>

        .btn btn-default{
         border-radius:10px;
         background:#3498db;
         text-decoration-color:white;

        }
        .add{
            color: #0E8FEF;
            text-align: center;
            font-size: 22px;
            padding-bottom: 7px;
            
            
        }

        .table-borderless > tbody > tr > td,
        .table-borderless > tbody > tr > th,
        .table-borderless > tfoot > tr > td,
        .table-borderless > tfoot > tr > th,
        .table-borderless > thead > tr > td,
        .table-borderless > thead > tr > th {
            border: none;
        }


        .auto-style2 {
            width: 160px;
        }
        .auto-style3 {
            width: 136px;
        }


    </style>
    
    <div id="content">

    

    <div id="addFeed">
        <h3 style="font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; text-align:center;" >
            ADD ANIMAL</h3>
        <br />
        <br />

        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table class="table table-borderless">
            

                <%--EAR TAG--%>
            <tr>
                <td style="width: 197px"><asp:Label ID="lbltag" runat="server" Text="EarTag" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txttag" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="Required." ControlToValidate="txttag" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>

                   <%--CATEGORY--%>
            <tr>
                <td style="width: 197px"><asp:Label ID="lblcat" runat="server" Text="Category" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:DropDownList ID="ddCat" AppendDataBoundItems="true" Width="180px" runat="server" AutoPostBack="true" >
                         <asp:ListItem Text="--Select--" Value="0"> 

                         </asp:ListItem> 
                    <asp:ListItem>Bull</asp:ListItem>
                    <asp:ListItem>Cow</asp:ListItem>
                    <asp:ListItem>Calve</asp:ListItem>
                     </asp:DropDownList> </td>                   
                                      
            </tr>

                 <%--Origin Country--%>
                <tr>
                <td style="width: 197px"><asp:Label ID="lblorigin" runat="server" Text="OriginCountry" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:DropDownList ID="ddCountry" AppendDataBoundItems="true" Width="180px" runat="server" AutoPostBack="true" >
                         <asp:ListItem Text="--Select--" Value="0"> 

                         </asp:ListItem> 
                    <asp:ListItem>Pakistan</asp:ListItem>
                    <asp:ListItem>India</asp:ListItem>
                    <asp:ListItem>Australia</asp:ListItem>
                    <asp:ListItem>China</asp:ListItem>
                    <asp:ListItem>-France</asp:ListItem>
                    <asp:ListItem>Ethiopia</asp:ListItem>

                    </asp:DropDownList> </td>                   
                     
            </tr>

                <%--GENDER--%>
                <tr>
                <td style="width: 197px"><asp:Label ID="lblgender" runat="server" Text="Gender" style="color:#6D7FCC; 
                font-size:18px;"></asp:Label></td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddGender" Width="180px" runat="server" AutoPostBack="true" >
                       <asp:ListItem Text="--Select--" Value="0"></asp:ListItem> 
                        <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                    </asp:DropDownList></td>
                       <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddGender" InitialValue="0" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>

                 <%--Status--%>
                <tr>
                <td style="width: 197px"><asp:Label ID="lblstatus" runat="server" Text="Status" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:DropDownList ID="ddStatus" AppendDataBoundItems="true" Width="180px" runat="server" AutoPostBack="true" >
                         <asp:ListItem Text="--Select--" Value="0"> 

                         </asp:ListItem> 
                    <asp:ListItem>Active</asp:ListItem>
                    <asp:ListItem>Non-Active</asp:ListItem>
                    <asp:ListItem>Sold</asp:ListItem>

                    </asp:DropDownList> </td>                    
            </tr>


                <%--Animal breed--%>
                <tr>
                <td style="width: 197px"><asp:Label ID="lblbreed" runat="server" Text="Breed" style="color:#6D7FCC; 
                font-size:18px;"></asp:Label></td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddBreed" AppendDataBoundItems="true" Width="180px" runat="server" AutoPostBack="true" >
                         
                    </asp:DropDownList></td>
                     <td class="auto-style2"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Required." ControlToValidate="ddBreed" InitialValue="--Select--" ForeColor="Red" 
                    style="font-size:18px;"></asp:RequiredFieldValidator></td>
            </tr>

                       <%--Lactation --%>
              <tr>
                <td style="width: 197px"><asp:Label ID="lbllactation" runat="server" Text="Lactation" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtlact" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                 
            </tr>

                <%--sire --%>
              <tr>
                <td style="width: 197px"><asp:Label ID="lblsire" runat="server" Text="Sire" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtsire" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                 
            </tr>
                 <%--insertion date --%>
                    <tr>
                <td style="width: 197px">
                    <asp:Label ID="Label7" runat="server" Text="Insertion Date" style="color:#6D7FCC; font-size:18px;">

                    </asp:Label></td>
                    <td class="auto-style3"><asp:TextBox ID="txtIdate" TextMode="Date" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
            
                     
            </tr>


                  <%--birth date --%>
                    <tr>
                <td style="width: 197px">
                    <asp:Label ID="Label1" runat="server" Text="Birth Date" style="color:#6D7FCC; font-size:18px;">

                    </asp:Label></td>
                    <td class="auto-style3"><asp:TextBox ID="txtBdate" TextMode="Date" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
            
                      
            </tr>


                      <%--Age --%>
              <tr>
                <td style="width: 197px"><asp:Label ID="lblage" runat="server" Text="Age" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtage" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                 
            </tr>

                <%--weight --%>
              <tr>
                <td style="width: 197px"><asp:Label ID="lblweight" runat="server" Text="Weight" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtweight" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
                 
            </tr>
                             <%--price --%>
              <tr>
                <td style="width: 197px"><asp:Label ID="lblprice" runat="server" Text="Price" style="color:#6D7FCC; font-size:18px;"></asp:Label></td>
                <td class="auto-style3"><asp:TextBox ID="txtprice" runat="server" style="border-radius:10px;" AutoPostBack="true"></asp:TextBox></td>
 
    

 


      </table>
            </ContentTemplate>
            </asp:UpdatePanel>
              
                </div>

         <asp:Label ID="Label5" CssClass="add" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />

                <asp:Button ID="Button1" runat="server" Text="ADD" CssClass="btn btn-default"
                    OnClick="Button1_Click" Width="143px" style="background:#3498db; color:white;
                    font-size:16px; padding:5px 5px 5px 5px;"/>

        </div>


</asp:Content>
