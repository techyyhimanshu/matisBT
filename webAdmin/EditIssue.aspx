<%@ Page Title="" Language="C#" MasterPageFile="~/webAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="EditIssue.aspx.cs" Inherits="webAdmin_EditIssue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row g-4">
        <div class="col-sm-12 col-xl-6" style="width: 96%; margin-left: 2%">
            <br />
            <div class="bg-light rounded h-100 p-4">
                <h6 class="mb-4" style="text-decoration: underline">Edit Issue Details</h6>

                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">ID</label>
                    <div class="col-sm-10">
                        <asp:Label ID="lblID" runat="server" CssClass="text-primary"></asp:Label>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Project</label>
                    <div class="col-sm-10">
                        <asp:Label ID="lblProject" runat="server" CssClass="text-primary"></asp:Label>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Date Submitted</label>
                    <div class="col-sm-10">
                        <asp:Label ID="lblDateSubmit" runat="server" CssClass="text-primary"></asp:Label>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Last Update</label>
                    <div class="col-sm-10">
                        <asp:Label ID="lblLastUpdate" runat="server" CssClass="text-primary"></asp:Label>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Category</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddCategory" runat="server" CssClass="form-select" aria-label="Floating label select example" DataTextField="CatName" DataValueField="CatID" required></asp:DropDownList>
                    </div>
                </div>
                <%--<div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Status</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddStatus" runat="server" CssClass="form-select" aria-label="Floating label select example" required>
                            <asp:ListItem Text="open" Value="open"></asp:ListItem>
                            <asp:ListItem Text="acknowledged" Value="acknowledged"></asp:ListItem>
                            <asp:ListItem Text="resolved" Value="resolved"></asp:ListItem>
                            <asp:ListItem Text="closed" Value="closed"></asp:ListItem>
                            <asp:ListItem Text="reopend" Value="reopened"></asp:ListItem>
                            <asp:ListItem Text="not fixable" Value="not fixable"></asp:ListItem>
                            <asp:ListItem Text="suspended" Value="suspended"></asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>--%>

                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Reproducibility</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddReproducibility" runat="server" CssClass="form-select" aria-label="Floating label select example" required>
                            <asp:ListItem Text="always" Value="always"></asp:ListItem>
                            <asp:ListItem Text="sometimes" Value="sometimes"></asp:ListItem>
                            <asp:ListItem Text="random" Value="random"></asp:ListItem>
                            <asp:ListItem Text="have not tried" Value="have not tried"></asp:ListItem>
                            <asp:ListItem Text="unable to reproduce" Value="unable to reproduce"></asp:ListItem>
                            <asp:ListItem Text="n/a" Value="na"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Severity</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddSeverity" runat="server" CssClass="form-select" aria-label="Floating label select example" required>
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
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Priority</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddPriority" runat="server" CssClass="form-select" aria-label="Floating label select example" required>
                            <asp:ListItem Text="none" Value="none"></asp:ListItem>
                            <asp:ListItem Text="low" Value="low"></asp:ListItem>
                            <asp:ListItem Text="normal" Value="normal"></asp:ListItem>
                            <asp:ListItem Text="high" Value="high"></asp:ListItem>
                            <asp:ListItem Text="urgent" Value="urgent"></asp:ListItem>
                            <asp:ListItem Text="immediate" Value="immediate"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Assigned To</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddAssignedTo" runat="server" CssClass="form-select" DataValueField="userName" DataTextField="userName"></asp:DropDownList>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Summary</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control" required></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Description</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Steps to reproduce</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtStepsToReproduce" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Additional Info</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtAdditionalInformation" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    </div>
                </div>

                <dl class="row mb-3">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <dl class="row mb-3">
                                <asp:Label ID="lbTags" runat="server" CssClass="col-sm-2 col-form-label">Tags</asp:Label>
                                <asp:DataList ID="dlTags" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="col-sm-10" Style="margin-top: 4px"
                                    OnItemCommand="dlTags_ItemCommand">
                                    <ItemTemplate>
                                        
                                        <div class="alert alert-primary  fade show" role="alert" style="height: 32px; float: left; margin-left: 10px; padding-top: 4px;">

                                            <asp:Label ID="lblTagName" runat="server"><%#Eval("tagName") %></asp:Label>
                                            <asp:Button ID="btnRemoveTag" runat="server" class="btn-close"  Style="margin-bottom: -3px; font-size: 11px"
                                                OnClick="btnRemoveTag_Click" CommandName="RemoveTag" CommandArgument='<%#Eval("tagName") %>'/>
                                        </div>
                                    </ItemTemplate>
                                    
                                </asp:DataList>
                            </dl>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </dl>

                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Attach Tags</label>
                    <div class="col-sm-7">
                        <div class="row">
                            <div class="col-3" style="width: 19%">
                                <label class="col-sm-0 col-form-label">Separated by (,)</label>
                            </div>
                            <div class="col-6">
                                <asp:TextBox ID="txtTags" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-2">
                                <asp:DropDownList ID="ddlTags" runat="server" DataTextField="tagName" DataValueField="tagID" CssClass="form-select" onchange="updateTextBox()"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <script type="text/javascript">
                    function updateTextBox() {
                        // Get the selected items from the DropDownList
                        var ddl = document.getElementById('<%= ddlTags.ClientID %>');
                        var selectedItems = Array.from(ddl.selectedOptions).map(option => option.text);

                        // Get the current value of the TextBox
                        var currentText = document.getElementById('<%= txtTags.ClientID %>').value;

                        // Combine the current value and the selected items, separated by a comma
                        var newText = (currentText ? currentText + ', ' : '') + selectedItems.join(', ');

                        // Update the TextBox with the combined text
                        document.getElementById('<%= txtTags.ClientID %>').value = newText;
    }
                </script>
                <%--<div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Upload File</label>
                    <div class="col-sm-10">
                        <asp:FileUpload ID="fuAttachment" runat="server" CssClass="form-control" />
                    </div>
                </div>--%>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">View Status</label>
                    <div class="col-sm-10">
                        <asp:RadioButtonList ID="rbViewStatus" runat="server" CssClass="form-check-label" RepeatDirection="Horizontal" required>
                            <asp:ListItem Text="Public" Value="public"></asp:ListItem>
                            <asp:ListItem Text="Private" Value="private"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <%--cloning panel--%>
                <%--<asp:Panel ID="pnlClone" runat="server" Visible="false">
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label">Relationship with the parent issue</label>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="ddRelationship" runat="server" CssClass="form-select" aria-label="Floating label select example">
                                <asp:ListItem Text="none" Value="none"></asp:ListItem>
                                <asp:ListItem Text="parent of" Value="parent of"></asp:ListItem>
                                <asp:ListItem Text="child of" Value="child of"></asp:ListItem>
                                <asp:ListItem Text="duplicate of" Value="duplicate of"></asp:ListItem>
                                <asp:ListItem Text="has duplicate" Value="has duplicate"></asp:ListItem>
                                <asp:ListItem Text="related to" Value="related to"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:Label ID="lblRelatedTo" runat="server" CssClass="col-sm-4 col-form-label" Text="issue 625104"></asp:Label>
                    </div>
                    <div class="row mb-3">
                        <label class="col-form-label col-sm-2 pt-0">Copy extended data from parent issue</label>
                        <div class="col-sm-2">
                            <asp:CheckBox ID="cbCopyNotes" runat="server" CssClass="form-check-label" Text="Copy issue notes" />
                        </div>
                        <div class="col-sm-2">
                            <asp:CheckBox ID="cbCopyAttachments" runat="server" CssClass="form-check-label" Text="Copy attachments" />
                            <asp:Image ID="issueImage" runat="server" Visible="false" />
                        </div>
                    </div>
                </asp:Panel>--%>
                <%--cloning panel end--%>
                <%--<div class="row mb-3">
                    <label class="col-form-label col-sm-2 pt-0">Report Stay</label>
                    <div class="col-sm-10">
                        <asp:CheckBox ID="cbReportStay" runat="server" CssClass="form-check-label" Text="check to report more issues" />
                    </div>
                </div>--%>
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnUpdate_Click"></asp:Button>

            </div>
        </div>
    </div>

    <br />
    <br />
</asp:Content>

