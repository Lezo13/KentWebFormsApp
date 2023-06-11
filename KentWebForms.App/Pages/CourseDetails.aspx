<%@ Page Title="CourseDetails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseDetails.aspx.cs" Inherits="KentWebForms.App.Pages.CourseDetails" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="page-course__details">
        <div class="course__header">
            <asp:Image ID="coverImg" runat="server" CssClass="course_banner"
                AlternateText="CoverBanner" />
            <div class="header__panel">
                <div class="header--left">
                    <asp:Image ID="displayImg" runat="server" CssClass="display-img"
                        AlternateText="DisplayImage" />
                    <div class="sub-details">
                        <h4><%= course.Title %></h4>
                        <h6><%= course.Category %></h6>
                    </div>
                </div>
                <div class="header--right">
                    <div class="course__btns">
                        <asp:Panel runat="server" ID="openBtns">
                            <asp:Button runat="server" CssClass="btn btn-success" ID="Button3" Text="Join course" />
                        </asp:Panel>

                        <asp:Panel runat="server" ID="joinedBtns" CssClass="action-btns">
                            <asp:Button runat="server" CssClass="btn btn-warning text-white" ID="doingBtn" Text="I am doing this!" Enabled="false" />
                            <asp:Button runat="server" CssClass="btn btn-danger" ID="leaveBtn" Text="Leave this course" />
                        </asp:Panel>

                        <asp:Panel runat="server" ID="completedBtns">
                            <asp:Button runat="server" CssClass="btn btn-warning" ID="Button5" Text="Course completed" Enabled="false" />
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>

        <div class="course__body" runat="server">
            <p class="<%= string.IsNullOrEmpty(course.Status) ? "lock-content" : "" %>">
                <%= course.Description %>
            </p>
            <p runat="server" id="unlockLabel" class="unlock__label">
                <i class="fa fa-lock" aria-hidden="true"></i> Unlock by joining the course
            </p>
            <div class="action-btns">
                <asp:Button runat="server" ID="btnComplete" CssClass="btn btn-primary" Text="Completed?" />
            </div>
        </div>
    </div>
</asp:Content>
