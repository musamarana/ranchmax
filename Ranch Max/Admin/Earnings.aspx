﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.master" AutoEventWireup="true" CodeBehind="Earnings.aspx.cs" Inherits="Ranch_Max.Earnings" %>
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
                    <div class=" col-sm-6" style="padding:2px 2px 2px 2px; padding-top:0px; width:20%;  background-color:#4285F4; margin:20px 5px 0px 50px; margin-top:10px; margin-left:300px;">
                        <div class="card card-common">
                            <div class="card-body">
                                <div class="auto-style1">
                                    <i class="fas fa-calculator fa-5x" style="padding-left:5px; padding-top:5px;"></i>
                                    <div class="text-right text-secondary">
                                        <h5 style="padding-right:5px; color:#ffffff;">Total Earning This Month</h5>
                                        <%--<h3>10</h3>--%>
                                        <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="White" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="card-footer text-secondary" style="background-color:#0d47a1;">
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
                                        <h5 style="padding-right:5px; color:#ffffff;">Profit This Month</h5>
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
                       </div>
                </div>
            </div>
            
      
    </div>

</asp:Content>
