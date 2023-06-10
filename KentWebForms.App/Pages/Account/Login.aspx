<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KentWebForms.App.Pages.Account.Login" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="wrapper">
        <div class="logo">
            <asp:Image runat="server" CssClass="bg-warning" ImageUrl="~/content/images/login_logo.png" AlternateText="" />
        </div>
        <div class="text-center mt-4 name">
            Welcome
        </div>
        <div class="p-3 mt-3">
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-danger text-center">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
            <div class="form-field d-flex align-items-center">
                <span class="far fa-user"></span>
                <div class="col-md-12">
                    <asp:TextBox runat="server" ID="Username" TextMode="SingleLine" />
                </div>
            </div>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                CssClass="text-danger" ErrorMessage="The username field is required." />
            <div class="form-field d-flex align-items-center">
                <span class="fas fa-key"></span>
                <div class="col-md-12">
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                </div>
            </div>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger"
                ErrorMessage="The password field is required." />
            <div class="checkbox">
                <asp:CheckBox runat="server" ID="RememberMe" />
                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
            </div>
            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn mt-3" />
        </div>
        <div class="text-center fs-6">
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
        </div>
    </div>
</asp:Content>
