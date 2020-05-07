<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Med_Report.aspx.cs" Inherits="Ranch_Max.Med_Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedMaster" runat="server">

<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js"></script>
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

       }

       .chart:hover{
           box-shadow:2px 3px 15px #999;
       }


        .auto-style1 {
            margin-left: 40px;
            margin-top:10px;
        }


   </style>
    
    <section>
    <div class="container-fluid" style="margin-left:130px; margin-top:10px; width:100%;">
        <div class="row">
            <div class="col-lg-9" style="margin-left:auto; width:100%;">
            
                <div class="row" style="padding-top:3px; margin-top:3px; margin-bottom:5px;">
                    <div class=" col-sm-6" style="padding:2px 2px 2px 2px; width:25%;  background-color:#4285F4; margin:5px 5px 0px 5px;">
                        <div class="card card-common">
                            <div class="card-body">
                                <div class="auto-style1">
                                    <i class="fas fa-flask fa-5x" style="padding-left:5px; padding-top:5px;"></i>
                                    <div class="text-right text-secondary">
                                        <h5 style="padding-right:5px; color:#ffffff;">Total Milk in Litres</h5>
                                        <%--<h3>10</h3>--%>
                                        <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="White" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </div>
                            </div>
                           <%-- <div class="card-footer text-secondary" style="background-color:#0d47a1;">
                                <i class="fas fa-sync" style="margin-right:5px; padding-top:5px; padding-left:5px;"></i>
                                <span style="padding-left:5px;">Updated Now</span>
                            </div>--%>
                        </div>
                       
                        </div>
                    <div class="col-sm-6" style="padding:2px 2px 2px 2px; width:25%; background-color:#ffbb33; margin:5px 5px 0px 50px;">
                        <div class="card card-common">
                            <div class="card-body">
                                <div class="auto-style1">
                                    <i class="fas fa-band-aid fa-5x" style="padding-left:5px; padding-top:5px;"></i>
                                    <div class="text-right text-secondary">
                                        <h5 style="padding-right:5px; color:#ffffff;">Cows in Dry Period</h5>
                                        <%--<h3>10</h3>--%>
                                        <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="White" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="card-footer text-secondary" style="background-color:#FF8800;">
                                <i class="fas fa-sync" style="margin-right:5px; padding-top:5px; padding-left:5px;"></i>
                                <span style="padding-left:5px;">Updated Now</span>
                            </div>--%>
                        </div> 
                        </div>

                    <div class="col-sm-6" style="padding:2px 2px 2px 2px; width:25%; background-color:#00C851; margin-left:50px; margin-top:5px;">
                        <div class="card card-common">
                            <div class="card-body">
                                <div class="auto-style1">
                                    <i class="fas fa-flask fa-5x" style="padding-left:5px; padding-top:5px;"></i>
                                    <div class="text-right text-secondary">
                                        <h5 style="padding-right:5px; color:#ffffff">Total Milk Collected Today</h5>
                                         <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="White" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="card-footer text-secondary" style="background-color:#007E33;">
                                <i class="fas fa-sync" style="margin-right:5px; padding-top:5px; padding-left:5px;"></i>
                                <span style="padding-left:5px;">Updated Now</span>
                            </div>--%>
                        </div>
                        </div>

                </div>
                </div>
            </div>
            
      
    </div>
        </section>

    <div>
        <%--<asp:Chart ID="Chart1" runat="server" CssClass="chart" Width="1000px" Height="500px" Palette="None" PaletteCustomColors="DarkTurquoise" OnLoad="Chart1_Load">
            <Series>
                <asp:Series Name="MILK IN LITRES" Legend="Milk_Detail"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" Name="Milk_Detail">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Font="Microsoft Sans Serif, 20pt" Name="Title1" Text="Day Wise Milk Yielding">
                </asp:Title>
            </Titles>
        </asp:Chart>--%>



    </div>


</asp:Content>
