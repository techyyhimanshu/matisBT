<%@ Page Title="" Language="C#" MasterPageFile="~/webAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="account_page.aspx.cs" Inherits="webAdmin_account_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid pt-4 px-4" style="width: 100%; position: relative; min-height: 100vh;">
        <div class="col-sm-12 col-xl-6" style="width: 100%">
            <div class="bg-light rounded h-100 p-4">
                <h6 class="mb-4">Edit Account</h6>
                <asp:Panel ID="pnlUpdateAccountInfo" runat="server">
                    <div class="row mb-3">
                        <asp:Image ID="imgUser" runat="server" CssClass="rounded-circle me-lg-2;" Style="width: 160px; height: 140px; margin-left: -15px" />
                        <div class="col-sm-3" style="margin-left: 65px; margin-top: 90px">

                            <asp:FileUpload ID="profileImageUpload" runat="server" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label">Username</label>
                        <div class="col-sm-10">
                            <asp:Label ID="lblUsername" runat="server" class="form-control"></asp:Label>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label">Access Level</label>
                        <div class="col-sm-10">
                            <asp:Label ID="lblAccessLevel" runat="server" class="form-control"></asp:Label>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label">Real name</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtRealNameForUpdate" runat="server" class="form-control" required></asp:TextBox>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label">Email</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtEmailForUpdate" runat="server" class="form-control" required></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailForUpdate"
                                ErrorMessage="Please enter valid email" ForeColor="Red" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9._%+-]+@(gmail\.com|outlook\.com|hotmail\.com|yahoo\.com)$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <asp:Button ID="btnUpdateUser" runat="server" Text="Update User" class="btn btn-primary" OnClick="btnUpdateUser_Click" />
                    <asp:Button ID="btnChangePassVisible" runat="server" Text="Change password" class="btn btn-outline-secondary m-2" OnClick="btnChangePassVisible_Click"></asp:Button>
                </asp:Panel>

                <asp:Panel ID="pnlChangePassword" runat="server" Visible="false">
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label">Current Password</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtCurrentPass" runat="server" class="form-control" TextMode="Password" required></asp:TextBox>

                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label">New Password</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtNewPass" runat="server" class="form-control" TextMode="Password" required></asp:TextBox>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label">Confirm Password</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtConfirmPass" runat="server" class="form-control" TextMode="Password" required></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="btnChangePassword" runat="server" Text="Update Password" class="btn btn-primary" OnClick="btnChangePassword_Click" />
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

