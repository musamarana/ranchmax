<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Ranch_Max.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <%--Default page--%>
    <%--<h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>--%>

    <%--About page--%>
       <style>
             body {
    background: linear-gradient(
      rgba(0, 0, 0, 0.75),
      rgba(0, 0, 0, 0.75)
    ),
     url('../img/dairyfarm.jpg') no-repeat center center fixed;
    background-size: cover;

        }
        #about{
            height:100vh;
            display:flex;
            justify-content:center;
            align-items:center;
        }

        #about h2{
            margin-bottom: 20px;
        }

        #about p{
            font-size:16px;
        }

        .img-wrap{
            width:100%;

        }

        .img-wrap img{
            width:100%;
            padding:10px;
            border-radius:50%;
            box-shadow: 0 0 10px #999;
        }
        h2{
            color:white;
            text-shadow: 2px 2px 4px white;
        }

        p{
            color:white;
            font-size:24px;
        }

    </style>
    <section id="about">
        <div class="container">
            <div class="row">
                <div class="col-sm-7">
                    <h2 class="text-center">
                        ABOUT US
                    </h2>
                    <p>We are catlle farmers that have been in this business for 30 plus years. With over 500 catlles of different breeds, sizes and origin, we aim to provide the best quality milk to our buyers. For this milk to be of the best quality we make sure that our animals are with premium quality of feed and are fed multiple times a day. Our milk yielding process is carried out with utmost safe and health precautions. Speaking of health, our cattles have timely checkups and vaccinations so they are promised a long and healthy life.
        We breed animals which have excellent characteristics to ensure healthy life of the offspring. 
    </p>

                </div>
                <div class="col-sm-5">
                    <div class="img-wrap">
                        <img  src="img/about-us-banner.jpg"/>

                    </div>

                </div>

            </div>

        </div>
    </section>



</asp:Content>
