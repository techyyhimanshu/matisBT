<%@ Page Title="" Language="C#" MasterPageFile="~/webUsers/MasterPage.master" AutoEventWireup="true" CodeFile="ViewIssue.aspx.cs" Inherits="webUsers_ViewIssue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid pt-4 px-4">
        <div class="row g-4">
            <div class="col-sm-12 col-xl-6" style="width: 100%">
                <div class="bg-light rounded h-100 p-4">
                    <h5 class="text-primary">View Issue Details</h5>
                    <dl class="row mb-0">
                        <hr />
                        <dl class="row">
                            <dt class="col-sm-3" style="color: black">ID</dt>
                            <dt class="col-sm-3" style="color: black">Project</dt>
                            <dt class="col-sm-3" style="color: black">Category</dt>
                            <dt class="col-sm-3" style="color: black">View Status</dt>
                        </dl>
                        <dl class="row">
                            <dd class="col-sm-3">
                                <asp:Label ID="lbID" runat="server" CssClass="text-primary"></asp:Label></dd>
                            <dd class="col-sm-3">
                                <asp:Label ID="lbProject" runat="server" CssClass="text-primary"></asp:Label></dd>
                            <dd class="col-sm-3">
                                <asp:Label ID="lbCategory" runat="server" CssClass="text-primary"></asp:Label></dd>
                            <dd class="col-sm-3">
                                <asp:Label ID="lbViewStatus" runat="server" CssClass="text-primary"></asp:Label></dd>
                        </dl>
                        <hr />
                        <dl class="row">
                            <dt class="col-sm-6" style="color: black">Date Submitted</dt>
                            <dt class="col-sm-6" style="color: black">Last Update</dt>
                        </dl>
                        <dl class="row">
                            <dd class="col-sm-6">
                                <asp:Label ID="lbDateSubmitted" runat="server" CssClass="text-primary"></asp:Label></dd>
                            <dd class="col-sm-6">
                                <asp:Label ID="lbLastUpdate" runat="server" CssClass="text-primary"></asp:Label></dd>
                        </dl>
                        <hr />
                        <dl class="row">
                            <dt class="col-sm-2" style="color: black">Reporter</dt>
                            <dd class="col-sm-4">
                                <asp:Label ID="lbReporter" runat="server" CssClass="text-primary"></asp:Label></dd>
                            <dt class="col-sm-2" style="color: black">Assigned To</dt>
                            <dd class="col-sm-4">
                                <asp:Label ID="lbAssignedTo" runat="server" CssClass="text-primary"></asp:Label></dd>
                        </dl>
                        <hr />
                        <dl class="row">
                            <dt class="col-sm-2" style="color: black">Priority</dt>
                            <dd class="col-sm-4">
                                <asp:Label ID="lbPriority" runat="server" CssClass="text-primary"></asp:Label></dd>
                            <dt class="col-sm-2" style="color: black">Severity</dt>
                            <dd class="col-sm-4">
                                <asp:Label ID="lbSeverity" runat="server" CssClass="text-primary"></asp:Label></dd>

                        </dl>
                        <hr />
                        <dl class="row">
                            <dt class="col-sm-2" style="color: black">Status</dt>
                            <dd class="col-sm-4">
                                <asp:Label ID="lbStatus" runat="server" CssClass="text-primary"></asp:Label></dd>
                            <dt class="col-sm-2" style="color: black">Reproducibility</dt>
                            <dd class="col-sm-4">
                                <asp:Label ID="lbReproducibility" runat="server" CssClass="text-primary"></asp:Label></dd>
                        </dl>
                        <hr />
                        <%--<dl class="row">
                            <dt class="col-sm-2" style="color: black">Target Version</dt>
                            <dd class="col-sm-4">-</dd>
                            <dt class="col-sm-2" style="color: black">Fixed in Version</dt>
                            <dd class="col-sm-4">-</dd>
                        </dl>
                        <hr />--%>
                        <dl class="row">
                            <dt class="col-sm-2" style="color: black">Summary</dt>
                            <dd class="col-sm-10">
                                <asp:Label ID="lbSummary" runat="server" CssClass="text-primary"></asp:Label></dd>
                        </dl>
                        <hr />
                        <dl class="row">
                            <dt class="col-sm-2" style="color: black">Description</dt>
                            <dd class="col-sm-10">
                                <asp:Label ID="lbDescription" runat="server" CssClass="text-primary"></asp:Label></dd>
                        </dl>
                        <hr />
                        <dl class="row">
                            <dt class="col-sm-2" style="color: black">Steps To Reproduce</dt>
                            <dd class="col-sm-10">
                                <asp:Label ID="lbStepsToReproduce" runat="server" CssClass="text-primary"></asp:Label></dd>
                        </dl>
                        <hr />
                        <dl class="row">
                            <dt class="col-sm-2" style="color: black">Additional Information</dt>
                            <dd class="col-sm-10">
                                <asp:Label ID="lbAdditionalInfo" runat="server" CssClass="text-primary"></asp:Label></dd>
                        </dl>
                       
                        
                        <hr />
                        <dl class="row" style="margin-left: 25%; margin-right: 25%">
                            <asp:Image ID="imgBug" runat="server" Width="500px" />
                        </dl>
                    </dl>
                    <br />
                    <div class="row">
                        <asp:Button ID="btnMonitor" runat="server" CssClass="btn btn-primary col-sm-2" Text="Monitor" Style="margin-left: 1%" OnClick="btnMonitor_Click" />
                        <asp:Button ID="btnClone" runat="server" CssClass="btn btn-primary col-sm-2" Text="Clone" OnClick="btnClone_Click" Style="margin-left: 1%" />
                        <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary col-sm-2" Text="Edit" OnClick="btnEdit_Click" Style="margin-left: 1%" Visible="false" />

                        <asp:Button ID="btnAcknowledge" runat="server" CssClass="btn btn-primary col-sm-2" Text="Acknowledge" OnClick="btnAcknowledge_Click" Style="margin-left: 1%" Visible="false" />
                        <asp:Button ID="btnResolved" runat="server" CssClass="btn btn-primary col-sm-2" Text="Resolve" OnClick="btnResolved_Click" Style="margin-left: 1%" Visible="false" />
                        <asp:Button ID="btnClose" runat="server" CssClass="btn btn-primary col-sm-2" Text="Close" OnClick="btnClose_Click" Style="margin-left: 1%" Visible="false" />
                        <asp:Button ID="btnReopen" runat="server" CssClass="btn btn-primary col-sm-2" Text="Reopen" OnClick="btnReopen_Click" Style="margin-left: 1%" Visible="false" />
                        <asp:Button ID="btnSuspend" runat="server" CssClass="btn btn-primary col-sm-2" Text="Suspend" OnClick="btnSuspend_Click" Style="margin-left: 1%" Visible="false" />
                    </div>
                    <div class="row" style="margin-top: 1%">
                        <asp:Button ID="btnAssignTo" runat="server" CssClass="btn btn-primary col-sm-2" Text="Assign To :" OnClick="btnAssignTo_Click" Style="margin-left: 1%" Visible="false" />
                        <div class="col">
                            <asp:DropDownList ID="ddAssignedTo" runat="server" CssClass="form-select" DataValueField="userName" DataTextField="userName" Style="width: 42.75%" Visible="false"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <%--Relationships--%>
            <div class="col-sm-12 col-xl-6" style="width: 100%">
                <div class="bg-light rounded h-100 p-4">
                    <h5 class="text-primary">Relationships</h5>
                    <dl class="row mb-0">
                        <hr />
                        <asp:DataList ID="dlRelationships" runat="server">
                            <ItemTemplate>
                                <div class="row" style="margin-left: 5px">
                                    <dd class="col-sm-3"><%#Eval("relation") %></dd>
                                    <a href='ViewIssue.aspx?mn=<%#Eval("bugID") %>' class="col-sm-2"><%#Eval("originalIssue") %></a>
                                    <dd class="col-sm-2"></dd>
                                    <dd class="col-sm-5"><%#Eval("bugSummary") %></dd>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </dl>
                </div>
            </div>
            <br />
            <%--ACTIVITIES--%>
            <div class="col-sm-12 col-md-6 col-xl-4" style="width: 100%">
                <div class="h-100 bg-light rounded p-4">
                    <div class="d-flex align-items-center justify-content-between mb-2">
                        <h5 class="text-primary">Activities</h5>
                    </div>
                    <hr style="margin-top: -5px" />
                    <asp:DataList ID="dlIssues" runat="server">
                        <ItemTemplate>
                            <div class="d-flex border-bottom py-3">
                                <asp:Image ID="imgUser" runat="server" CssClass="rounded-circle flex-shrink-0" Style="width: 40px; height: 40px;" ImageUrl='<%#Eval("userPicPath") %>' />
                                <div class="w-100 ms-3">
                                    <div class="d-flex w-100 justify-content-lg-start">
                                        <div style="width: 140px">
                                            <h6 class="mb-0"><%#Eval("userName") %></h6>
                                            <p><%#Eval("noteCreatedDateTime") %></p>
                                            <%--<p style="margin-top: -18px"><%#Eval("userRole") %></p>--%>
                                        </div>
                                        <div style="width: 775px; border-left: ridge">
                                            <p style="margin-left: 20px"><%#Eval("noteDescription") %></p>
                                            <asp:Image ID="imgNote" runat="server" ImageUrl='<%#Eval("noteImage") %>' Width="500px" Style="margin-left: 20px" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
            <br />
            <%--ADD NOTE--%>
            <div class="col-sm-12 col-xl-6" style="width: 100%">
                <div class="bg-light rounded h-100 p-4">
                    <h5 class="text-primary">Add Note</h5>
                    <hr style="margin-top: 0px; margin-bottom: 25px" />
                    <div>
                        <div class="row mb-3">
                            <legend class="col-form-label col-sm-2 pt-0">View Status</legend>
                            <div class="col-sm-10">
                                <div class="form-check">
                                    <asp:CheckBox ID="cbPrivateNote" runat="server" CssClass="form-check-label" Text="Private" Style="margin-left: -22px" />
                                    <%--<label class="form-check-label" for="gridCheck1">Private</label>--%>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <label for="inputPassword3" class="col-sm-2 col-form-label">Note</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtNote" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <label for="inputEmail3" class="col-sm-2 col-form-label">Upload File</label>
                            <div class="col-sm-10">
                                <asp:FileUpload ID="fuNoteFile" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <asp:Button ID="btnAddNote" runat="server" CssClass="btn btn-primary" Text="Add Note" OnClick="btnAddNote_Click" />
                    </div>
                </div>
            </div>
        </div>
        <br />
    </div>
</asp:Content>
