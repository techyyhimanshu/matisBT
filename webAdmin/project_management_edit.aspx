<%@ Page Title="" Language="C#" MasterPageFile="~/webAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="project_management_edit.aspx.cs" Inherits="webAdmin_project_management_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid pt-4 px-4" style="width: 100%; position: relative; min-height: 100vh;">
        <div class="bg-light rounded h-100 p-4">
            
            <h6 class="mb-4">Edit Project</h6>
            <div class="form-floating mb-3">
                <asp:TextBox ID="txtProjName" runat="server" class="form-control" placeholder="Project name"></asp:TextBox>
                <label for="floatingInput">Project name</label>
            </div>

            <div class="form-floating mb-3">
                <asp:DropDownList ID="ddlProjectStatus" runat="server" class="form-select">

                    <asp:ListItem Text="development" Value="1" />
                    <asp:ListItem Text="release" Value="2" />
                    <asp:ListItem Text="stable" Value="3" />
                    <asp:ListItem Text="obsolete" Value="4" />
                </asp:DropDownList>
                <label for="floatingSelect">
                    Select Status
                </label>
            </div>

         
            <div class="form-floating mb-3">
                <asp:DropDownList ID="dlStatus" runat="server" class="form-select" >
                    <asp:ListItem Text="Public" Value="1" />
                    <asp:ListItem Text="Private" Value="2" />
                </asp:DropDownList>
                <label for="floatingSelect">
                    View Status
                </label>
            </div>
            <div class="form-floating mb-3">
                <asp:TextBox ID="txtDescription" runat="server" class="form-control" placeholder="Description" TextMode="MultiLine" Rows="8" Columns="60" Style="height: 200px"></asp:TextBox>
                <label for="floatingInput">Description</label>
            </div>
             <div class="mb-3 form-check" style="margin-left: -15px">
                <asp:CheckBox ID="chkEnabled" runat="server" />
                <label class="form-check-label" for="exampleCheck1">Enabled </label>
            </div>

            <asp:Button ID="btnUpdateProject" runat="server" Text="Update" class="btn btn-primary m-2" OnClick="btnUpdateProject_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-secondary m-2" OnClick="btnBack_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete project" class="btn btn-secondary m-2" Style="margin-right: 200px" OnClick="btnDelete_Click" />
            <br />
            <br />
            <h6 class="mb-4">Add Subprojects</h6>
            <asp:Button ID="btnCreateNewSubProject" runat="server" Text="Create New Subproject" CssClass="btn btn-primary m-2" OnClick="btnCreateNewSubProject_Click" />
            <br />
            <asp:Button ID="btnAddAsSubProject" runat="server" Text="Add as subproject" CssClass="btn btn-primary m-2" OnClick="btnAddAsSubProject_Click" />
            <div>

                <div class="col-sm-10" style="width: 224px">
                    <div class="form-floating mb-3" style="margin-left: 175px; margin-top: -46px; width: 140px">
                        <asp:DropDownList ID="dlProjectDetailsForSubprojectCreation" DataValueField="projectID" EnableViewState="true" runat="server" class="form-select" Style="height: 39px; padding-top: 8px">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <h6 class="mb-4">Subprojects</h6>
            <asp:GridView ID="gridShowSubprojects" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowCommand="gridSubProjects_Row" OnRowDeleting="gridSubProjects_RowDeleting" EmptyDataText="No subproject">
                <Columns>
                    <asp:BoundField DataField="projectName" HeaderText="Project Name" SortExpression="projectName" />
                    <asp:BoundField DataField="status" HeaderText="Status" SortExpression="Status" />
                    <asp:ImageField DataImageUrlField="isEnabled" HeaderText="Enabled"></asp:ImageField>
                    <%--<asp:BoundField DataField="isInheritCategory" HeaderText="Inherit Categories" SortExpression="isInheritCategory" />--%>
                    <asp:BoundField DataField="viewStatus" HeaderText="View Status" SortExpression="viewStatus" />
                    <asp:BoundField DataField="projectDescription" HeaderText="Description" SortExpression="Description" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnUnlink" runat="server" CommandName="unlink" CommandArgument='<%#Eval("projectID") %>' CssClass="btn btn-outline-danger m-2" Style="font-size: 10px">Unlink</asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <h6 class="mb-4">Manage Members</h6>
            <asp:GridView ID="gvMembers" runat="server" EmptyDataText="No member is included" CssClass="table" AutoGenerateColumns="False" RowStyle-VerticalAlign="Middle">
                <Columns>
                    <asp:BoundField DataField="userName" HeaderText="Username" />
                    <asp:BoundField DataField="userAccessLevel" HeaderText="Access Level" />
                    <asp:TemplateField HeaderText="Change To">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddmemberAccessLevel" runat="server" CssClass="form-select" Style="width: 200px">
                                <asp:ListItem Text="Viewer" Value="viewer"></asp:ListItem>
                                <asp:ListItem Text="Reporter" Value="reporter"></asp:ListItem>
                                <%--<asp:ListItem Text="Updater" Value="updater"></asp:ListItem>--%>
                                <asp:ListItem Text="Developer" Value="developer"></asp:ListItem>
                                <asp:ListItem Text="Manager" Value="manager"></asp:ListItem>
                                <%-- <asp:ListItem Text="Administrator" Value="administrator"></asp:ListItem>--%>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remove">
                        <ItemTemplate>
                            <asp:CheckBox ID="cbRemove" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnEditMembers" runat="server" Text="Apply Changes" CssClass="btn btn-primary m-2" OnClick="btnEditMembers_Click" />
            <br />
            <br />
            <h6 class="mb-4">Add user to project</h6>
            <div class="row mb-3">
                <label for="inputEmail3" class="col-sm-2 col-form-label">User</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddusersToAdd" runat="server" CssClass="form-select mb-3" DataValueField="userName" DataTextField="userName"></asp:DropDownList>
                </div>
            </div>
            <div class="row mb-3">
                <label for="inputEmail3" class="col-sm-2 col-form-label">Access Level</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="dduserAccessLevel" runat="server" CssClass="form-select mb-3">
                        <asp:ListItem Text="Viewer" Value="viewer"></asp:ListItem>
                        <asp:ListItem Text="Reporter" Value="reporter"></asp:ListItem>
                        <%--<asp:ListItem Text="Updater" Value="updater"></asp:ListItem>--%>
                        <asp:ListItem Text="Developer" Value="developer"></asp:ListItem>
                        <asp:ListItem Text="Manager" Value="manager"></asp:ListItem>
                    </asp:DropDownList>

                </div>
            </div>

            <asp:Button ID="btnAddUser" runat="server" CssClass="btn btn-primary m-2" Text="Add User" OnClick="btnAddUser_Click" />

        </div>
    </div>
</asp:Content>

