<%@ Page Title="" Language="C#" MasterPageFile="~/webUsers/MasterPage.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="webUsers_dashboard" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlAlertMessageForLoginSuccess" runat="server" CssClass="alert alert-success" Visible="false" Style="width: 1300px; margin-top: 20px; margin-left: 20px">
        <asp:Label ID="loginSuccess" runat="server"></asp:Label>
        <script>
            $(document).ready(function () {
                // Check if the alert element is present on the page
                var $alert = $(".alert");

                if ($alert.length > 0) {
                    // Set a timeout to fade out and slide up the alert after a delay
                    window.setTimeout(function () {
                        $alert.fadeTo(500, 0).slideUp(500, function () {
                            $(this).remove();
                        });
                    }, 3000);
                }
            });
        </script>
    </asp:Panel>
    <asp:Panel ID="pnlAlertForNewIssue" runat="server" CssClass="alert alert-success" Visible="false" Style="width: 1300px; margin-top: 20px; margin-left: 20px">
        Issue created
        <script>
            $(document).ready(function () {
                // Check if the alert element is present on the page
                var $alert = $(".alert");

                if ($alert.length > 0) {
                    // Set a timeout to fade out and slide up the alert after a delay
                    window.setTimeout(function () {
                        $alert.fadeTo(500, 0).slideUp(500, function () {
                            $(this).remove();
                        });
                    }, 3000);
                }
            });
        </script>
    </asp:Panel>

    <div class="container-fluid pt-4 px-4" style="width: 100%">
        <div class="row g-4" style="width: 102%">
            <div class="col-sm-12 col-xl-6" style="width: 50%">
                <%--Unassigned Issues--%>
                <div class="col-sm-12 col-md-6 col-xl-4" style="width: 100%">
                    <div class="h-100 bg-light rounded p-4">
                        <div class="d-flex align-items-center justify-content-between mb-2">
                            <h6 class="mb-0" style="text-decoration: underline">Unassigned</h6>
                        </div>
                        <hr style="margin-bottom: 0px" />
                        <asp:DataList ID="dlUnassigned" runat="server" Width="100%">
                            <ItemTemplate>
                                <div class="d-flex align-items-center border-bottom py-3" style="height: 60px;">
                                    <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' style='color: <%# GetLinkColor(Eval("bugPriority").ToString()) %>'><%#Eval("bugID") %></a>

                                    <%--<img class="rounded-circle flex-shrink-0" src="img/user.jpg" alt="" style="width: 40px; height: 40px;">--%>
                                    <div class="w-100 ms-3" style="width: 100%">
                                        <div class="d-flex w-100 justify-content-between">
                                            <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' class="mb-0"><%#Eval("bugSummary") %></a>
                                        </div>
                                        <span><%# Eval("catName") %> - <%# Convert.ToDateTime(Eval("bugUpdatedDate")).ToString("dd-MMM-yyyy hh:mm tt") %> - <%#Eval("DayDifference") %></span>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <br />
                <%--reported by me--%>
                <div class="col-sm-12 col-md-6 col-xl-4" style="width: 100%">
                    <div class="h-100 bg-light rounded p-4">
                        <div class="d-flex align-items-center justify-content-between mb-2">
                            <h6 class="mb-0" style="text-decoration: underline">Reported By Me</h6>
                        </div>
                        <hr style="margin-bottom: 0px" />
                        <asp:DataList ID="dlByMe" runat="server" Width="100%">
                            <ItemTemplate>
                                <div class="d-flex align-items-center border-bottom py-3" style="height: 60px">
                                    <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' style='color: <%# GetLinkColor(Eval("bugPriority").ToString()) %>'><%#Eval("bugID") %></a>
                                    <%--<img class="rounded-circle flex-shrink-0" src="img/user.jpg" alt="" style="width: 40px; height: 40px;">--%>
                                    <div class="w-100 ms-3">
                                        <div class="d-flex w-100 justify-content-between">
                                            <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' class="mb-0"><%#Eval("bugSummary") %></a>
                                        </div>
                                        <span><%# Eval("catName") %> - <%# Convert.ToDateTime(Eval("bugUpdatedDate")).ToString("dd-MMM-yyyy hh:mm tt") %> - <%#Eval("DayDifference") %></span>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <br />
                <%--resolved--%>
                <div class="col-sm-12 col-md-6 col-xl-4" style="width: 100%">
                    <div class="h-100 bg-light rounded p-4">
                        <div class="d-flex align-items-center justify-content-between mb-2">
                            <h6 class="mb-0" style="text-decoration: underline">Resolved</h6>
                        </div>
                        <hr style="margin-bottom: 0px" />
                        <asp:DataList ID="dlResolved" runat="server" Width="100%">
                            <ItemTemplate>
                                <div class="d-flex align-items-center border-bottom py-3" style="height: 60px">
                                    <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' style='color: <%# GetLinkColor(Eval("bugPriority").ToString()) %>'><%#Eval("bugID") %></a>
                                    <%--<img class="rounded-circle flex-shrink-0" src="img/user.jpg" alt="" style="width: 40px; height: 40px;">--%>
                                    <div class="w-100 ms-3">
                                        <div class="d-flex w-100 justify-content-between">
                                            <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' class="mb-0"><%#Eval("bugSummary") %></a>
                                        </div>
                                        <span><%# Eval("catName") %> - <%# Convert.ToDateTime(Eval("bugUpdatedDate")).ToString("dd-MMM-yyyy hh:mm tt") %> - <%#Eval("DayDifference") %></span>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <br />
                <%--recently modified--%>
                <div class="col-sm-12 col-md-6 col-xl-4" style="width: 100%">
                    <div class="h-100 bg-light rounded p-4">
                        <div class="d-flex align-items-center justify-content-between mb-2">
                            <h6 class="mb-0" style="text-decoration: underline">Recently Modified (Last 30 days)</h6>
                        </div>
                        <hr style="margin-bottom: 0px" />
                        <asp:DataList ID="dlRecently" runat="server" Width="100%">
                            <ItemTemplate>
                                <div class="d-flex align-items-center border-bottom py-3" style="height: 60px">
                                    <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' style='color: <%# GetLinkColor(Eval("bugPriority").ToString()) %>'><%#Eval("bugID") %></a>
                                    <%--<img class="rounded-circle flex-shrink-0" src="img/user.jpg" alt="" style="width: 40px; height: 40px;">--%>
                                    <div class="w-100 ms-3">
                                        <div class="d-flex w-100 justify-content-between">
                                            <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' class="mb-0"><%#Eval("bugSummary") %></a>
                                        </div>
                                        <span><%# Eval("catName") %> - <%# Convert.ToDateTime(Eval("bugUpdatedDate")).ToString("dd-MMM-yyyy hh:mm tt") %> - <%#Eval("DayDifference") %></span>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <br />
                <%--monitored by me--%>
                <div class="col-sm-12 col-md-6 col-xl-4" style="width: 100%">
                    <div class="h-100 bg-light rounded p-4">
                        <div class="d-flex align-items-center justify-content-between mb-2">
                            <h6 class="mb-0" style="text-decoration: underline">Monitored by me</h6>
                        </div>
                        <hr style="margin-bottom: 0px" />
                        <asp:DataList ID="dlMonitoredByMe" runat="server" Width="100%">
                            <ItemTemplate>
                                <div class="d-flex align-items-center border-bottom py-3" style="height: 60px;">
                                    <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' style='color: <%# GetLinkColor(Eval("bugPriority").ToString()) %>'><%#Eval("bugID") %></a>
                                    <%--<img class="rounded-circle flex-shrink-0" src="img/user.jpg" alt="" style="width: 40px; height: 40px;">--%>
                                    <div class="w-100 ms-3">
                                        <div class="d-flex w-100 justify-content-between">
                                            <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' class="mb-0"><%#Eval("bugSummary") %></a>
                                        </div>
                                        <span><%# Eval("catName") %> - <%# Convert.ToDateTime(Eval("bugUpdatedDate")).ToString("dd-MMM-yyyy hh:mm tt") %> - <%#Eval("DayDifference") %></span>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <br />

                <%--assigned to me--%>
                <asp:Panel ID="pnlAssignedToMe" runat="server">
                    <div class="col-sm-12 col-md-6 col-xl-4" style="width: 100%">
                        <div class="h-100 bg-light rounded p-4">
                            <div class="d-flex align-items-center justify-content-between mb-2">
                                <h6 class="mb-0" style="text-decoration: underline">Assigned To Me</h6>
                            </div>
                            <hr style="margin-bottom: 0px" />
                            <asp:DataList ID="dlAssignedToMe" runat="server" Width="100%">
                                <ItemTemplate>
                                    <div class="d-flex align-items-center border-bottom py-3" style="height: 60px;">
                                        <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' style='color: <%# GetLinkColor(Eval("bugPriority").ToString()) %>'><%#Eval("bugID") %></a>
                                        <%--<img class="rounded-circle flex-shrink-0" src="img/user.jpg" alt="" style="width: 40px; height: 40px;">--%>
                                        <div class="w-100 ms-3">
                                            <div class="d-flex w-100 justify-content-between">
                                                <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' class="mb-0"><%#Eval("bugSummary") %></a>
                                            </div>
                                            <span><%# Eval("catName") %> - <%# Convert.ToDateTime(Eval("bugUpdatedDate")).ToString("dd-MMM-yyyy hh:mm tt") %> - <%#Eval("DayDifference") %></span>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                </asp:Panel>
                <br />
            </div>
            <%--Timeline--%>
            <div class="col-sm-12 col-xl-6" style="width: 50%">
                <div class="col-sm-12 col-md-6 col-xl-4" style="width: 100%">
                    <div class="h-100 bg-light rounded p-4">
                        <div class="d-flex align-items-center justify-content-between mb-2">
                            <h6 class="mb-0" style="text-decoration: underline">Timeline</h6>
                        </div>
                        <hr style="margin-bottom: 0px" />
                        <asp:DataList ID="dlTimeLine" runat="server" Width="100%">
                            <ItemTemplate>
                                <div class="d-flex align-items-center border-bottom py-3" style="height: 60px;">
                                    <asp:Image ID="imgUser" runat="server" CssClass="rounded-circle flex-shrink-0" ImageUrl='<%#Eval("userPicPath") %>' Style="width: 40px; height: 40px;" />
                                    <div class="w-100 ms-3">
                                        <div class="d-flex w-100" style="column-gap: 4px; margin-top: 12px">
                                            <%#GetTimeLineItem(Eval("userName").ToString(), Eval("action").ToString(), Eval("object").ToString()) %>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

