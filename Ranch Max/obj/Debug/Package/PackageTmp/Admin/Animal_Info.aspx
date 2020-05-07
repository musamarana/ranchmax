<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Animal_Info.aspx.cs" Inherits="Ranch_Max.User.Animal_Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">

<style>
       .card-common{
           box-shadow:1px 2px 5px #999;
           transition:all.4s;
       }

       .card-common:hover{
           box-shadow:2px 3px 15px #999;
       }
       .labelStyle{
           padding-right:5px;
           font-size:25px;
       }
        
        .auto-style1 {
            margin-left: 40px;
            margin-top:10px;
        }

        .TestCssStyle
            {
color:black;
background-color: #c5d4e6;
text-align:center;
font-size:30px;
font-weight:bold;
table-layout: auto;
border-collapse: separate;
border-right: gray thin solid;
border-top: gray thin solid;
border-left: gray thin solid;
border-bottom: gray thin solid;
}
   </style>

    <div id="content">
           
        <asp:Label ID="Label1" runat="server" Text="Label">Search:</asp:Label> 

          <asp:DropDownList ID="ddSearch" runat="server" AutoPostBack="True"
              OnSelectedIndexChanged="ddSearch_SelectedIndexChanged">
             <asp:ListItem>--Select--</asp:ListItem>
              <asp:ListItem>Animal</asp:ListItem>
           </asp:DropDownList>

          <asp:DropDownList ID="ddType" runat="server" AutoPostBack="True"
              OnSelectedIndexChanged="ddType_SelectedIndexChanged">
           </asp:DropDownList>
         <asp:Button ID="Button2" runat="server" style="  border-radius:5px; background:#3498db;
  text-decoration-color:white; padding:5px 5px 5px 5px; font-size:14px; margin-bottom:5px" Text="Refresh"
              class="btn btn-primary btn-sm" OnClick="Button2_Click" />

  

        <section>
        </section>

    <div class="container-fluid" style="margin-left:130px; margin-top:10px; width:100%;">
        <div class="row">
            <div class="col-lg-9" style="margin-left:auto; width:100%;">
            
                <div class="row" style="padding-top:3px; margin-top:3px; margin-bottom:5px;">

                     <div class="col-sm-6" style="padding:2px 2px 2px 2px; padding-top:0px; width:25%; background-color:lightslategrey; margin:20px 5px 0px 0px; margin-top:10px;">
                        <div class="card card-common">
                            <div class="card-body">
                                <div class="auto-style1">

                                     <i class= "fas fa-shopping-cart  fa-5x fa-fw" style="padding-left:5px; padding-top:5px;"></i> 
                                    <div class="text-right text-secondary">
                                        <h5 style="padding-right:5px; color:#ffffff;">Purchasing Amount</h5>
                                        <%--<h3>10</h3>--%>
                                        <asp:Label ID="Label4" runat="server"  ForeColor="White" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="card-footer text-secondary" style="background-color:#FF8800;">
                                <i class="fas fa-sync" style="margin-right:5px; padding-top:5px; padding-left:5px;"></i>
                                <span style="padding-left:5px;">Updated Now</span>
                            </div>--%>
                        </div> 
                        </div>


                    <div class=" col-sm-6" style="padding:2px 2px 2px 2px; width:25%;  background-color:lightseagreen; margin:20px 5px 0px 30px; margin-top:10px;">
                        <div class="card card-common">
                            <div class="card-body">
                                <div class="auto-style1">
                                   <i class="fa fa-refresh fa-spin fa-5x fa-fw" ></i>
                                    <span class="sr-only">Loading...</span>
                                     <div class="text-right text-secondary">
                                        <h5 style="padding-right:5px; color:#ffffff;">Expense on Animal</h5>
                                        <%--<h3>10</h3>--%>
                                        <asp:Label ID="Label3" runat="server"  ForeColor="White" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </div>
                            </div>
                           <%-- <div class="card-footer text-secondary" style="background-color:#0d47a1;">
                                <i class="fas fa-sync" style="margin-right:5px; padding-top:5px; padding-left:5px;"></i>
                                <span style="padding-left:5px;">Updated Now</span>
                            </div>--%>
                        </div>
                       
                        </div>
            <div class="col-sm-6" style="padding:2px 2px 2px 2px; width:25%; background-color:lightcoral; margin:20px 5px 0px 30px; margin-top:10px;">
                        <div class="card card-common">
                            <div class="card-body">
                                <div class="auto-style1">
                                     <i class= " fas fa-money  fa-5x fa-fw" style="padding-left:5px; padding-top:5px;"></i> 

<%--                                     <i class= "fas fa-comment-dollar  fa-5x fa-fw" style="padding-left:5px; padding-top:5px;"></i> --%>
                                    <div class="text-right text-secondary">
                                        <h5 style="padding-right:5px; color:#ffffff;">Selling Amount</h5>
                                        <%--<h3>10</h3>--%>
                                        <asp:Label ID="Label5" runat="server"  ForeColor="White" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="card-footer text-secondary" style="background-color:#FF8800;">
                                <i class="fas fa-sync" style="margin-right:5px; padding-top:5px; padding-left:5px;"></i>
                                <span style="padding-left:5px;">Updated Now</span>
                            </div>--%>
                        </div> 
                        </div>

                        </div>
                </div>
            </div>
            
      
    </div>
    


 
       <%-- <h3 style="font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; text-align:center;" >
           Per Formula Rate  </h3>--%>
        <br />
        <br />
      <asp:GridView ID="gvFormula" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
               class="table" BorderWidth="1px" CellPadding="4"
           caption='<table width="100%" class="TestCssStyle"><tr><td class="text_Title">Per Formula Rate</td></tr></table>' CaptionAlign="Top">
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
         
       <%--   <h3 style="font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; text-align:center;" >
            Feeding Consumption Per Animal </h3>--%>
        <br />
        <br />
        <asp:GridView ID="GvCon2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
               class="table" BorderWidth="1px" CellPadding="4"
            caption='<table width="100%" class="TestCssStyle"><tr><td class="text_Title">Feeding Expense For This Animal</td></tr></table>' 
            CaptionAlign="Top">

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
             <asp:Label ID="Label2" runat="server" style="color:#6D7FCC; 
                font-size:22px;font-weight:bold"  > </asp:Label> 
              </div>

         
         <%-- <h3 style="font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; text-align:center;" >
            Medical Consumption Per Animal </h3>--%>
        <br />
        <br />
        <asp:GridView ID="gvCon" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
               class="table" BorderWidth="1px" CellPadding="4"
            caption='<table width="100%" class="TestCssStyle"><tr><td class="text_Title">Medical Expense For This Animal</td></tr></table>' 
            CaptionAlign="Top">
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
           <asp:Label ID="Label22" runat="server" style="color:#6D7FCC; 
                font-size:22px;font-weight:bold"  > </asp:Label> 
                </div>
     </div>
</asp:Content>
