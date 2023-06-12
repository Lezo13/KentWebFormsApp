<%@ Page Title="Courses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="KentWebForms.App.Pages.Courses" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container body-content">
        <div class="row row-cols-1 row-cols-md-2 g-4">
            <asp:Repeater ID="cardRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-lg-3">
                        <div class="card course__item">
                            <asp:Image ID="Image1" runat="server" CssClass="card-img-top"
                                ImageUrl='<%# "data:image/png;base64," + Eval("DisplayImgBase64") %>'
                                AlternateText="Image description" />
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Title") %></h5>
                                <p class="card-text"><%# Eval("Category") %></p>
                            </div>

                            <div class="card-body__right">
                                <% if (!IsAdminLoggedIn)
                                    { %>
                                <span class="badge bg-primary course-status <%# GetStatusClass(Container.DataItem) %>">
                                    <%# GetStatus(Container.DataItem) %>
                                </span>
                                <% }
                                    else
                                    { %>
                                   <span class="badge bg-primary course-status <%# GetCountStatusClass(Container.DataItem) %>">
                                       <i class="fa fa-users me-2" aria-hidden="true"></i> <%# GetTotalEnrolled(Container.DataItem) %>
                                </span>
                          
                                <% } %>
                            </div>

                            <asp:LinkButton ID="btnPanel" runat="server" Text="" CssClass="course__link"
                                OnClick="ViewCourse" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
