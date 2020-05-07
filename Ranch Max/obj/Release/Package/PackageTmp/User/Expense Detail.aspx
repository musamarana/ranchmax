<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Expense Detail.aspx.cs" Inherits="Ranch_Max.Expense_Detail" %>
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

        .chart{
           margin-left:200px;
           margin-top:50px;
           resize:horizontal;

       }

       .chart:hover{
           box-shadow:2px 3px 15px #999;
       }


         .auto-style1 {
             margin-left: 40px;
         }
         </style>

    <div class="container-fluid" style="margin-left:130px; margin-top:10px; width:100%;">
        <div class="row">
            <div class="col-lg-9" style="margin-left:auto; width:100%;">
            
                <div class="row" style="padding-top:3px; margin-top:3px; margin-bottom:5px;">
                    <div class=" col-sm-6" style="padding:2px 2px 2px 2px; padding-top:0px; width:20%;  background-color:#E70E0E; margin:20px 5px 0px 50px; margin-top:10px;">
                        <div class="card card-common">
                            <div class="card-body">
                                <div class="auto-style1">
                                    <i class="fas fa-calculator fa-5x" style="padding-left:5px; padding-top:5px;"></i>
                                    <div class="text-right text-secondary">
                                        <h5 style="padding-right:5px; color:#ffffff;">Total Expense This Month</h5>
                                        <%--<h3>10</h3>--%>
                                        <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="White" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="card-footer text-secondary" style="background-color:#DC1010;">
                                <i class="fas fa-sync" style="margin-right:5px; padding-top:5px; padding-left:5px;"></i>
                                <span style="padding-left:5px;">Updated Now</span>
                            </div>
                        </div>
                       
                        </div>
                     <div class="col-sm-6" style="padding:2px 2px 2px 2px; width:20%; background-color:#ffbb33; margin:20px 5px 0px 30px; margin-top:10px;">
                        <div class="card card-common">
                            <div class="card-body">
                                <div class="auto-style1">
                                    <i class="fas fa-calculator fa-5x" style="padding-left:5px; padding-top:5px;"></i>
                                    <div class="text-right text-secondary">
                                        <h5 style="padding-right:5px; color:#ffffff;">Purchasing this Month</h5>
                                        <%--<h3>10</h3>--%>
                                        <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="White" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="card-footer text-secondary" style="background-color:#FF8800;">
                                <i class="fas fa-sync" style="margin-right:5px; padding-top:5px; padding-left:5px;"></i>
                                <span style="padding-left:5px;">Updated Now</span>
                            </div>
                        </div> 
                        </div>

                    <div class="col-sm-6" style="padding:2px 2px 2px 2px; width:20%; background-color:#00C851; margin-left:30px; margin-top:10px;">
                        <div class="card card-common">
                            <div class="card-body">
                                <div class="auto-style1">
                                    <i class="fas fa-calculator fa-5x" style="padding-left:5px; padding-top:5px;"></i>
                                    <div class="text-right text-secondary">
                                        <h5 style="padding-right:5px; color:#ffffff">Total Earnings This Month</h5>
                                         <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="White" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="card-footer text-secondary" style="background-color:#007E33;">
                                <i class="fas fa-sync" style="margin-right:5px; padding-top:5px; padding-left:5px;"></i>
                                <span style="padding-left:5px;">Updated Now</span>
                            </div>
                        </div>
                        </div>
                    <div class="col-sm-6" style="padding:2px 2px 2px 2px; width:20%; background-color:#4285F4; margin-left:30px; margin-top:10px;">
                        <div class="card card-common">
                            <div class="card-body">
                                <div class="auto-style1">
                                    <i class="fas fa-calculator fa-5x" style="padding-left:5px; padding-top:5px;"></i>
                                    <div class="text-right text-secondary">
                                        <h5 style="padding-right:5px; color:#ffffff">Profit Made This Month</h5>
                                         <asp:Label ID="Label4" runat="server" Text="Label" ForeColor="White" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="card-footer text-secondary" style="background-color:#0d47a1;">
                                <i class="fas fa-sync" style="margin-right:5px; padding-top:5px; padding-left:5px;"></i>
                                <span style="padding-left:5px;">Updated Now</span>
                            </div>
                        </div>
                        </div>
                       </div>
                </div>
            </div>
            
      
    </div>

    <asp:Chart ID="Chart1" CssClass="chart" runat="server" Height="353px" Width="937px">
        <Series>
            <asp:Series Name="Amount" ChartType="Line"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
        <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" Name="Milk_Detail">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Font="Microsoft Sans Serif, 20pt" Name="Title1" Text="Expense Analysis">
                </asp:Title>
                </Titles>
    </asp:Chart>
    <asp:Chart ID="Chart2" CssClass="chart" runat="server" Width="937px" Height="328px">
        <Series>
            <asp:Series Name="Amount" Legend="Legend1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1" Alignment="Center" Docking="Bottom">
            </asp:Legend>
        </Legends>
        <Titles>
                <asp:Title Font="Microsoft Sans Serif, 20pt" Name="Title1" Text="Type Wise Expense">
                </asp:Title>
                </Titles>
    </asp:Chart>

    <asp:Chart ID="Chart3" CssClass="chart" runat="server" Width="959px">
        <Series>
            <asp:Series Name="Amount" Legend="Legend1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1" Alignment="Center" Docking="Bottom">
            </asp:Legend>
        </Legends>
        <Titles>
                <asp:Title Font="Microsoft Sans Serif, 20pt" Name="Title1" Text="Daily Purchasing">
                </asp:Title>
                </Titles>
    </asp:Chart>

</asp:Content>
