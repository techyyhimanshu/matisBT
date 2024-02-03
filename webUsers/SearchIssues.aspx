<%@ Page Title="" Language="C#" MasterPageFile="~/webUsers/MasterPage.master" AutoEventWireup="true" CodeFile="SearchIssues.aspx.cs" Inherits="webUsers_SearchIssues" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--FILTERS--%>
    <div class="container-fluid pt-4 px-4">
        <div class="row g-4">
            <div class="col-sm-12 col-xl-6" style="width: 100%">
                <div class="bg-light rounded h-100 p-4">
                    <h6 class="mb-4" style="text-decoration: underline">Filters</h6>
                    <div class="row">
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Reporter</label>
                            <asp:DropDownList ID="ddReporters" runat="server" CssClass="form-select form-select-sm mb-3" DataValueField="bugReporter" DataTextField="bugReporter" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Assigned To</label>
                            <asp:DropDownList ID="ddAssignedTo" runat="server" CssClass="form-select form-select-sm mb-3" DataValueField="bugAssignedTo" DataTextField="bugAssignedTo" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Monitored By</label>
                            <asp:DropDownList ID="ddMonitoredBy" runat="server" CssClass="form-select form-select-sm mb-3" DataValueField="userName" DataTextField="userName" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Note By</label>
                            <asp:DropDownList ID="ddNoteBy" runat="server" CssClass="form-select form-select-sm mb-3" DataValueField="userName" DataTextField="userName" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Priority</label>
                            <asp:DropDownList ID="ddPriority" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="none" Value="none"></asp:ListItem>
                                <asp:ListItem Text="low" Value="low"></asp:ListItem>
                                <asp:ListItem Text="normal" Value="normal"></asp:ListItem>
                                <asp:ListItem Text="high" Value="high"></asp:ListItem>
                                <asp:ListItem Text="urgent" Value="urgent"></asp:ListItem>
                                <asp:ListItem Text="immediate" Value="immediate"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Severity</label>
                            <asp:DropDownList ID="ddSeverity" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="feature" Value="feature"></asp:ListItem>
                                <asp:ListItem Text="trivial" Value="trivial"></asp:ListItem>
                                <asp:ListItem Text="text" Value="text"></asp:ListItem>
                                <asp:ListItem Text="tweak" Value="tweak"></asp:ListItem>
                                <asp:ListItem Text="minor" Value="minor"></asp:ListItem>
                                <asp:ListItem Text="major" Value="major"></asp:ListItem>
                                <asp:ListItem Text="crash" Value="crash"></asp:ListItem>
                                <asp:ListItem Text="block" Value="block"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">View Status</label>
                            <asp:DropDownList ID="ddViewStatus" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="public" Value="public"></asp:ListItem>
                                <asp:ListItem Text="private" Value="private"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Relationships</label>
                            <asp:DropDownList ID="ddRelationships" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                <asp:ListItem Text="none" Value="none"></asp:ListItem>
                                <asp:ListItem Text="parent of" Value="parent of"></asp:ListItem>
                                <asp:ListItem Text="child of" Value="child of"></asp:ListItem>
                                <asp:ListItem Text="duplicate of" Value="duplicate of"></asp:ListItem>
                                <asp:ListItem Text="has duplicate" Value="has duplicate"></asp:ListItem>
                                <asp:ListItem Text="related to" Value="related to"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%--<div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Show Sticky Issues</label>
                            <asp:DropDownList ID="ddShowStickyIssues" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="yes" Value="yes"></asp:ListItem>
                                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>
                    </div>
                    <div class="row">
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Category</label>
                            <asp:DropDownList ID="ddCategory" runat="server" CssClass="form-select form-select-sm mb-3" DataValueField="CatID" DataTextField="CatName" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Hide Status</label>
                            <asp:DropDownList ID="ddHideStatus" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="none" Value="none"></asp:ListItem>
                                <asp:ListItem Text="new" Value="new"></asp:ListItem>
                                <asp:ListItem Text="feedback" Value="feedback"></asp:ListItem>
                                <asp:ListItem Text="acknowledged" Value="acknowledged"></asp:ListItem>
                                <asp:ListItem Text="confirmed" Value="confirmed"></asp:ListItem>
                                <asp:ListItem Text="assigned" Value="assigned"></asp:ListItem>
                                <asp:ListItem Text="resolved" Value="resolved"></asp:ListItem>
                                <asp:ListItem Text="closed" Value="closed"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Status</label>
                            <asp:DropDownList ID="ddStatus" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="open" Value="open"></asp:ListItem>
                                <asp:ListItem Text="acknowledged" Value="acknowledged"></asp:ListItem>
                                <asp:ListItem Text="resolved" Value="resolved"></asp:ListItem>
                                <asp:ListItem Text="closed" Value="closed"></asp:ListItem>
                                <asp:ListItem Text="reopend" Value="reopened"></asp:ListItem>
                                <asp:ListItem Text="suspended" Value="suspended"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Match Type</label>
                            <asp:DropDownList ID="ddMatchType" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                <asp:ListItem Text="all conditions" Value="AND"></asp:ListItem>
                                <asp:ListItem Text="any conditions" Value="OR"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%-- <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Resolution</label>
                            <asp:DropDownList ID="ddResolution" runat="server" CssClass="form-select form-select-sm mb-3" DataValueField="CatID" DataTextField="CatName" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="any" Value="any"></asp:ListItem>
                                <asp:ListItem Text="open" Value="open"></asp:ListItem>
                                <asp:ListItem Text="fixed" Value="fixed"></asp:ListItem>
                                <asp:ListItem Text="reopen" Value="reopen"></asp:ListItem>
                                <asp:ListItem Text="unable to reproduce" Value="unable to reproduce"></asp:ListItem>
                                <asp:ListItem Text="not fixable" Value="not fixable"></asp:ListItem>
                                <asp:ListItem Text="duplicate" Value="duplicate"></asp:ListItem>
                                <asp:ListItem Text="no change required" Value="no change required"></asp:ListItem>
                                <asp:ListItem Text="suspended" Value="suspended"></asp:ListItem>
                                <asp:ListItem Text="won't fix" Value="wont fix"></asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>
                    </div>
                    <div class="row">
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Filter By Date Submitted</label>
                            <%--<asp:CheckBox ID="cbFilterDateSubmit" runat="server" EnableTheming="true" Style="margin-left: 2%;" />--%>
                            <div class="row">
                                <div class="col-auto" style="width: 45%">
                                    <asp:TextBox ID="txtSubmitDate1" runat="server" CssClass="form-control" Style="height: 31px; font-size: 14px;" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-auto" style="width: 10%; margin-left: -1%">
                                    <label class="form-label">to</label>
                                </div>
                                <div class="col-auto" style="width: 45%">
                                    <asp:TextBox ID="txtSubmitDate2" runat="server" CssClass="form-control" Style="height: 31px; font-size: 14px;" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Filter By Last Update Date</label>
                            <%--<asp:CheckBox ID="cbFilterLastUpdate" runat="server" EnableTheming="true" Style="margin-left: 2%;" />--%>
                            <div class="row">
                                <div class="col-auto" style="width: 45%">
                                    <asp:TextBox ID="txtLastUpdate1" runat="server" CssClass="form-control" Style="height: 31px; font-size: 14px;" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-auto" style="width: 10%; margin-left: -1%">
                                    <label class="form-label">to</label>
                                </div>
                                <div class="col-auto" style="width: 45%">
                                    <asp:TextBox ID="txtLastUpdate2" runat="server" CssClass="form-control" Style="height: 31px; font-size: 14px;" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-auto" style="width: 50%">
                            <label for="exampleInputEmail1" class="form-label">Sort By</label>
                            <div class="row">
                                <div class="col-auto" style="width: 50%">
                                    <asp:DropDownList ID="ddSortBy" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                        <asp:ListItem Text="priority" Value="priority"></asp:ListItem>
                                        <asp:ListItem Text="issue ID" Value="issueID"></asp:ListItem>
                                        <asp:ListItem Text="category" Value="category"></asp:ListItem>
                                        <asp:ListItem Text="severity" Value="severity"></asp:ListItem>
                                        <asp:ListItem Text="status" Value="status"></asp:ListItem>
                                        <asp:ListItem Text="updated" Value="updated"></asp:ListItem>
                                        <asp:ListItem Text="summary" Value="summary"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-auto" style="width: 50%">
                                    <asp:DropDownList ID="ddSortOrder" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                        <asp:ListItem Text="ascending" Value="asc"></asp:ListItem>
                                        <asp:ListItem Text="descending" Value="desc"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <%-- <div class="col-auto" style="width: 25%">
                                    <asp:DropDownList ID="ddSortBy2" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="priority" Value="priority"></asp:ListItem>
                                        <asp:ListItem Text="issue ID" Value="issue ID"></asp:ListItem>
                                        <asp:ListItem Text="category" Value="category"></asp:ListItem>
                                        <asp:ListItem Text="severity" Value="severity"></asp:ListItem>
                                        <asp:ListItem Text="status" Value="status"></asp:ListItem>
                                        <asp:ListItem Text="updated" Value="updated"></asp:ListItem>
                                        <asp:ListItem Text="summary" Value="summary"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-auto" style="width: 25%">
                                    <asp:DropDownList ID="ddSortBy2order" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDowns_SelectedIndexChanged">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="ascending" Value="asc"></asp:ListItem>
                                        <asp:ListItem Text="descending" Value="desc"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>--%>
                            </div>
                        </div>
                        <%-- <div class="col-auto" style="width: 25%">
                            <label for="exampleInputEmail1" class="form-label">Show</label>
                            <asp:TextBox ID="txtShow" runat="server" Text="50" CssClass="form-control" TextMode="Number" Style="height: 31px; font-size: 14px"></asp:TextBox>
                        </div>--%>
                    </div>

                    <div class="row">
                        <label for="exampleInputEmail1" class="form-label">Tags</label>
                        <div class="col-auto" style="width: 75%">
                            <asp:TextBox ID="txtTags" runat="server" CssClass="form-control" Style="height: 31px"></asp:TextBox>
                        </div>
                        <div class="col-auto" style="width: 25%">
                            <asp:DropDownList ID="ddExistingTags" runat="server" CssClass="form-select form-select-sm mb-3" OnSelectedIndexChanged="dropDownss_SelectedIndexChanged" DataTextField="tagName" DataValueField="tagID"  AutoPostBack="true">
                            </asp:DropDownList>
                            
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-auto" style="width: 75%">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Style="height: 31px; font-size: 14px" placeholder="Search"></asp:TextBox>
                        </div>
                        <div class="col-auto" style="width: 25%">
                            <asp:Button ID="btnApplyFilter" runat="server" CssClass="btn btn-primary" Style="width: 100%; height: 31px; text-emphasis-position: above; padding-top: 3px;" Text="Apply Filter" OnClick="btnApplyFilter_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
            <%--Issue GridView--%>
            <div class="col-sm-12 col-xl-6" style="width: 100%">
                <div class="bg-light rounded h-100 p-4">
                    <h6 class="mb-4">Viewing Issues</h6>
                    <asp:GridView ID="gvIssues" runat="server" AutoGenerateColumns="False" DataKeyNames="bugID" DataSourceID="SqlDataSource1" CssClass="table table-hover" PageSize="50" AllowPaging="true" EmptyDataText="No issue found">
                        <Columns>
                            <asp:BoundField DataField="bugPriority" HeaderText="Priority" SortExpression="bugPriority" />
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <a href="ViewIssue.aspx?mn=<%#Eval("bugID") %>" style='color: <%# GetLinkColor(Eval("bugPriority").ToString()) %>'><%#Eval("bugID") %></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="noteCount" HeaderText="Notes" ReadOnly="True" SortExpression="noteCount" />
                            <asp:BoundField DataField="CatName" HeaderText="Category" SortExpression="CatName" />
                            <asp:BoundField DataField="bugSeverity" HeaderText="Severity" SortExpression="bugSeverity" />
                            <asp:BoundField DataField="bugStatus" HeaderText="Status" SortExpression="bugStatus" />
                            <asp:BoundField DataField="bugUpdate" HeaderText="Last Update" ReadOnly="True" SortExpression="bugUpdate" DataFormatString="{0:dd-MM-yyyy}" />
                            <asp:TemplateField HeaderText="Summary">
                                <ItemTemplate>
                                    <a href="ViewIssue.aspx?mn=<%#Eval("bugID") %>"><%#Eval("bugSummary") %></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MantisBtConString %>"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>

