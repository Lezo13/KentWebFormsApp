<%@ Page Title="CourseDetails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseDetails.aspx.cs" Inherits="KentWebForms.App.Pages.CourseDetails" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="page-course__details">
        <div class="course--left">
            <div class="course__header">
                <asp:Image ID="coverImg" runat="server" CssClass="course_banner"
                    AlternateText="CoverBanner" />
                <div class="header__panel">
                    <div class="header--left">
                        <asp:Image ID="displayImg" runat="server" CssClass="display-img"
                            AlternateText="DisplayImage" />
                        <div class="sub-details">
                            <h4><%= IsAdminLoggedIn ? adminCourse.Title : userCourse.Title %></h4>
                            <h6><%= IsAdminLoggedIn ? adminCourse.Category : userCourse.Category %></h6>
                        </div>
                    </div>
                    <div class="header--right">
                        <div class="course__btns">
                            <asp:Panel runat="server" ID="openBtns">
                                <asp:Button runat="server" CssClass="btn btn-success" ID="Button3" Text="Join course" OnClick="JoinCourse" />
                            </asp:Panel>

                            <asp:Panel runat="server" ID="joinedBtns" CssClass="action-btns">
                                <asp:Button runat="server" CssClass="btn btn-warning text-white" ID="doingBtn" Text="I am doing this!" Enabled="false" />
                                <asp:Button runat="server" CssClass="btn btn-danger" ID="leaveBtn" Text="Leave this course" OnClick="LeaveCourse" />
                            </asp:Panel>

                            <asp:Panel runat="server" ID="completedBtns">
                                <asp:Button runat="server" CssClass="btn btn-light" ID="Button5" Text="Course completed" Enabled="false" />
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>

            <div class="course__body" runat="server">
                <p class="<%= string.IsNullOrEmpty(userCourse?.Status) && !IsAdminLoggedIn ? "lock-content" : "" %>">
                    <%= IsAdminLoggedIn ? adminCourse.Description : userCourse.Description %>
                </p>
                <p runat="server" id="unlockLabel" class="unlock__label">
                    <i class="fa fa-lock" aria-hidden="true"></i>Unlock by joining the course
                </p>
                <div class="action-btns mt-5">
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-dark" Text="Go back" OnClick="BackToCourses" />
                    <asp:Button runat="server" ID="btnComplete" CssClass="btn btn-primary" Text="Completed?" OnClick="CompleteCourse" />
                </div>
            </div>
        </div>
        <% if (IsAdminLoggedIn)
            { %>
        <div class="course--right">
            <h4 class="user-section__title">USERS ENROLLED (<%= IsAdminLoggedIn ? adminCourse.TotalEnrolled : 0 %>)</h4>
            <asp:Repeater ID="userRepeater" runat="server">
                <ItemTemplate>
                    <div class="user-course__item">
                        <span class="text-nowrap">
                            <%# Eval("FirstName") + " " + Eval("LastName") %>

                        </span>
                        <span class="text-nowrap badge bg-primary course-status <%# GetStatusClass(Container.DataItem) %>">
                           <%# GetStatus(Container.DataItem) %>
                        </span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <% } %>
    </div>
</asp:Content>
