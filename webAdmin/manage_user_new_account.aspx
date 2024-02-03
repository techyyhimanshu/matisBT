<%@ Page Title="" Language="C#" MasterPageFile="~/webAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="manage_user_new_account.aspx.cs" Inherits="webAdmin_manage_user_new_account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid pt-4 px-4" style="width: 100%; position: relative; min-height: 100vh;">
        <asp:Panel ID="pnlCreateNewUser" runat="server" Visible="true">
            <div class="bg-light rounded h-100 p-4">
                <h6 class="mb-4">Create New User</h6>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Username</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtUserName" runat="server" class="form-control" required></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Real name</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtRealName" runat="server" class="form-control" pattern="[A-Za-z ]+" title="Only alphabets and spaces are allowed" required></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Email</label>
                    <div class="col-sm-10">

                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" type="email" title="Enter a valid email address" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Please enter valid email" ForeColor="Red" Display="Dynamic"  ValidationExpression="^[a-zA-Z0-9._%+-]+@(gmail\.com|outlook\.com|hotmail\.com|yahoo\.com)$"></asp:RegularExpressionValidator>
                    </div>
                </div>



                <div class="row mb-3">
                    <label for="userAccessLevel" class="col-sm-2 col-form-label">Access Level</label>
                    <div class="col-sm-10">

                        <asp:DropDownList ID="ddlUserAccessLevel" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Viewer" Value="1" />
                            <asp:ListItem Text="Administrator" Value="2" />
                            <asp:ListItem Text="Manager" Value="3" />
                            <%--<asp:ListItem Text="Updater" Value="4" />--%>
                            <asp:ListItem Text="Developer" Value="5" />
                            <asp:ListItem Text="Reporter" Value="5" />
                        </asp:DropDownList>
                    </div>

                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label" style="padding-top: 0px">Enabled</label>
                    <div class="col-sm-10" style="width: 294px">
                        <asp:CheckBox ID="chkEnabled" runat="server" />
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label" style="padding-top: 0px">Protected</label>
                    <div class="col-sm-10" style="width: 294px">
                        <asp:CheckBox ID="chkProtected" runat="server" Style="margin-top: 12px" />
                    </div>
                </div>
                <asp:Button ID="btnAddUser" runat="server" Text="Create User" class="btn btn-primary" OnClick="btnAddUser_Click" />
            </div>
        </asp:Panel>
        .
    <asp:Panel ID="pnlSuccess" runat="server" Visible="false">
        <div class="col-sm-12 col-xl-6" style="width: 1000px">
            <div class="bg-light text-center rounded p-4">
                <div class="d-flex align-items-center justify-content-between mb-4">
                    <h6 class="mb-0" style="padding-top: 26px; padding-left: 362px">Account Successfully created</h6>
                </div>
                <asp:Button ID="btnProceed" runat="server" Text="Proceed" CssClass="btn btn-outline-secondary m-2" OnClick="btnProceed_Click" />
            </div>

        </div>
    </asp:Panel>
    </div>
</asp:Content>
