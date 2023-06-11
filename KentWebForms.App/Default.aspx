<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KentWebForms.App._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container body-content">
        <div class="text-center">
                <asp:Image runat="server" CssClass="home__banner" ImageUrl="~/content/images/home_banner.jpg" AlternateText="" />
        </div>

        <div class="jumbotron">
            <h1 class="text-center">KENT'S EDUCATIONAL HUB</h1>
            <p class="lead">Welcome to our exceptional educational hub, where the world of learning awaits you.
                Discover a wealth of opportunities to expand your knowledge, sharpen your skills, 
                and unlock your potential. Our diverse range of courses, taught by 
                industry experts, ensures a high-quality learning experience. 
                Explore interactive learning materials, engage with a supportive community, 
                and embrace cutting-edge technology. Join us on this transformative journey of 
                growth and empowerment as you embark on your path to success. 
                Experience the joy of learning with us, where education knows no limits.</p>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <h2>LEARN</h2>
                <p>
                    Discover the incredible value of our learning courses. 
                    Our meticulously designed programs offer a wealth of benefits to help you excel. 
                    Gain structured knowledge, expert guidance, and a comprehensive learning experience. 
                    Unlock new skills, enhance expertise, and stay competitive. 
                    Our courses provide practical applications, networking opportunities, and certifications, 
                    empowering your career growth and personal development. 
                    Invest in your future and experience the exceptional value of our transformative learning journeys.
                </p>
            </div>
        </div>
    </div>
</asp:Content>
