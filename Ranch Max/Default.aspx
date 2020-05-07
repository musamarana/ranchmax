<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ranch_Max._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="StyleSlider.css" rel="stylesheet" />

    <script>
        $(document).ready(function () {
            $('.carousel').carousel({
                interval: 4000
            })
        });    
</script>

    <style>
         body {
    background: linear-gradient(
      rgba(0, 0, 0, 0.75),
      rgba(0, 0, 0, 0.75)
    ),
     url('../img/dairyfarm.jpg') no-repeat center center fixed;
    background-size: cover;

        }
        .jumbotron{
             background: linear-gradient(
      rgba(0, 0, 0, 0.5),
      rgba(0, 0, 0, 0.5)
    ),
     url('../img/10.jpg') no-repeat center center fixed;
    background-size: cover;
            color: white;
            /*background-repeat: no-repeat;*/
        }
        /*.card{
            background-color:black;
            transition: transform .2s;
            opacity:0.8;   
        }

        .card:hover{
            box-shadow:2px 3px 15px #999;
            opacity:1.0;
        }

        .card-title{
            color:#E9F1F6;
            font-size:20px;
            padding:5px 5px 5px 5px;
            text-shadow: 2px 2px 4px #000;
        }

        .card-text{
            color:#E9F1F6;
            padding: 5px 5px 5px 5px;
            font-size:16px;
        }*/

        @media only screen and (min-width: 480px){
            #image{
                background-image:none;
            }
        }

    </style>
    <div class="jumbotron">
  <h1 class="display-4" style="text-shadow: 2px 2px 4px white;">WAHEED CATTLE FARM</h1>
  <p class="lead"> </p>
  <p> </p>
</div>

     <%--<div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src="img/9.jpg" alt="...">
      <div class="carousel-caption">
        ...
      </div>
    </div>
    <div class="item">
      <img src="img/1.jpg" alt="...">
      <div class="carousel-caption">
        ...
      </div>
    </div>
    <div class="item">
      <img src="img/2.jpg" alt="...">
      <div class="carousel-caption">
        ...
      </div>
    </div>
  </div>

  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>--%>

    <%--<div class="row">
  <div class="col-sm-6">
    <div class="card">
        <img class="card-img-top" id="image" src="img/Cows_feeding_1-1024x557_3_570x180.jpg" alt="Card image cap">
      <div class="card-body">
        <h5 class="card-title">Premium Quality of Feed</h5>
        <p class="card-text">At our farm, we make sure that all our animals are given the best quality of feed and are fed on time.</p>
      </div>
    </div>
  </div>
  <div class="col-sm-6">
    <div class="card">
    <img class="card-img-top" src="img/h1_570x180.jpg" alt="Card image cap">
      <div class="card-body">
        <h5 class="card-title">No Hormonal Injections</h5>
        <p class="card-text">We do not use any injections that result in abnormal production of milk or any injections that may harm the animal's or your life.</p>
      </div>
    </div>
  </div>--%>
        <div class="carousel fade-carousel slide" data-ride="carousel" data-interval="4000" id="bs-carousel">
  <!-- Overlay -->
  <div class="overlay"></div>

  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#bs-carousel" data-slide-to="0" class="active"></li>
    <li data-target="#bs-carousel" data-slide-to="1"></li>
    <li data-target="#bs-carousel" data-slide-to="2"></li>
  </ol>
  
  <!-- Wrapper for slides -->
  <div class="carousel-inner">
    <div class="item slides active">
      <div class="slide-1"></div>
      <div class="hero">
        <hgroup>
            <h1>Premium Feed</h1>        
            <h3>Best quality of feed and are fed on time.</h3>
        </hgroup>
      </div>
    </div>
    <div class="item slides">
      <div class="slide-2"></div>
      <div class="hero">        
        <hgroup>
            <h1>No Injections</h1>        
            <h3>We do not use any injections for abnormal production of milk.</h3>
        </hgroup>       
      </div>
    </div>
    <div class="item slides">
      <div class="slide-3"></div>
      <div class="hero">        
        <hgroup>
            <h1>Best quality milk</h1>        
            <h3>Keeping standard</h3>
        </hgroup>
      </div>
    </div>
  </div> 
</div>


</asp:Content>
