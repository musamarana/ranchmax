<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Ranch_Max.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <%--Default Contact Page--%>
    <%--<h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>--%>


    <%--New Contact Page--%>
        <style>
             body {
    background: linear-gradient(
      rgba(0, 0, 0, 0.75),
      rgba(0, 0, 0, 0.75)
    ),
     url('../img/dairyfarm.jpg') no-repeat center center fixed;
    background-size: cover;

        }
        .mapouter{
            position:relative;
            text-align:right;
            height:500px;
            width:600px;
        }
        .gmap_canvas{
            overflow:hidden;
            background:none!important;
            height:500px;
            width:600px;

        }
    </style>
    <h2 style="color:white;">Get in touch with us!</h2>
    <address style="color:white;">
        Gujjar Cattle Farm<br />
        Karachi, Pakistan<br />
        <abbr title="Phone" style="color:white;">Mobile:</abbr>
        +92321.1234.567
    </address>

    <div class="mapouter">
        <div class="gmap_canvas">
            <iframe width="600" height="500" id="gmap_canvas" src="https://maps.google.com/maps?q=Gujjar%20dairy%20and%20cattle%20farm&t=&z=13&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe>
            <a href="https://www.embedgooglemap.net/blog/booking.com-coupon/"></a>

        </div>
    </div>

</asp:Content>
