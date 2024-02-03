<%@ Page Title="" Language="C#" MasterPageFile="~/webAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="manage_user.aspx.cs" Inherits="webAdmin_manage_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlAlertMessageForNewUser" runat="server" CssClass="alert alert-success" Visible="false" Style="width: 1300px; margin-top: 20px; margin-left: 20px">
        <asp:Label ID="lblCreatedUser" runat="server"></asp:Label>
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
    <asp:Panel ID="pnlPopupForDeleteUser" runat="server" CssClass="alert alert-danger" Visible="false" Style="width: 1300px; margin-top: 20px; margin-left: 20px">
        <asp:Label ID="lblUserDeleted" runat="server"></asp:Label>
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

    <asp:Panel ID="pnlPopupForProtectedUserDeletion" runat="server" CssClass="alert alert-primary" Visible="false" Style="width: 1300px; margin-top: 20px; margin-left: 20px">
        <asp:Label ID="lblProtectedUserDeletionMessage" runat="server"></asp:Label>
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
    <div class="container-fluid pt-4 px-4" style="width: 100%; position: relative; min-height: 100vh;">

        <h3 class="p-2 mb-2 bg-secondary text-white"># Manage Accounts:</h3>
        <asp:Button ID="btnCreateNewUser" runat="server" Text="Create New Account" CssClass="btn btn-dark m-2" OnClick="btnCreateNewUser_Click" />
        <asp:Panel ID="pnlViewAllUsers" runat="server" Visible="true" DefaultButton="btnApplyFilter">
            <asp:GridView ID="gridViewUserDetails" runat="server" OnRowCommand="gridUserDetails_Row" OnRowDeleting="gridUserDetails_RowDeleting" DataKeyNames="userName" CssClass="table table-striped;bg-light rounded h-100 p-4">
                <Columns>
                    <asp:BoundField DataField="userName" HeaderText="Username" ReadOnly="True" SortExpression="userName" />
                    <asp:BoundField DataField="userRealName" HeaderText="Real Name" SortExpression="userRealName" />
                    <asp:BoundField DataField="userEmail" HeaderText="Email" SortExpression="userEmail" />
                    <asp:BoundField DataField="userAccessLevel" HeaderText="Access Level" SortExpression="userAccessLevel" />
                    <asp:BoundField DataField="createdDate" HeaderText="Created Date" SortExpression="createdDate" />
                    <asp:ImageField DataImageUrlField="isEnabled" HeaderText="Enabled" HeaderStyle-HorizontalAlign="Left"></asp:ImageField>
                    <asp:ImageField DataImageUrlField="isProtected" HeaderText="Protected" HeaderStyle-HorizontalAlign="Left"></asp:ImageField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandName="delete" CommandArgument='<%#Eval("userName") %>' OnClientClick="return confirmDelete()">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandName="update" CommandArgument='<%#Eval("userName") %>'>Update</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <script type="text/javascript">
                function confirmDelete() {
                    return confirm('Do you want to delete this user?');
                }
            </script>
        </asp:Panel>
        <asp:Panel ID="pnlViewSpecificUser" runat="server" Visible="false">
            <asp:GridView ID="gridViewSpecificUserDetailss" runat="server" AutoGenerateColumns="False" OnRowCommand="gridSpecificUserDetails_Row" OnRowDeleting="gridSpecificUserDetails_RowDeleting" DataKeyNames="userName" CssClass="table table-striped;bg-light rounded h-100 p-4">
                <Columns>
                    <asp:BoundField DataField="userName" HeaderText="Username" ReadOnly="True" SortExpression="userName" />
                    <asp:BoundField DataField="userRealName" HeaderText="Real Name" SortExpression="userRealName" />
                    <asp:BoundField DataField="userEmail" HeaderText="Email" SortExpression="userEmail" />
                    <asp:BoundField DataField="userAccessLevel" HeaderText="Access Level" SortExpression="userAccessLevel" />
                    <asp:BoundField DataField="createdDate" HeaderText="Created Date" SortExpression="createdDate" />
                    <asp:ImageField DataImageUrlField="isEnabled" HeaderText="Enabled" HeaderStyle-HorizontalAlign="Left"></asp:ImageField>
                    <asp:ImageField DataImageUrlField="isProtected" HeaderText="Protected" HeaderStyle-HorizontalAlign="Left"></asp:ImageField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandName="delete" CommandArgument='<%#Eval("userName") %>'>Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandName="update" CommandArgument='<%#Eval("userName") %>'>Update</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </asp:Panel>

        <asp:Panel ID="tempPnl" runat="server" DefaultButton="btnApplyFilter">


            <%--<div style="margin-right: -3200px">
                <asp:CheckBox ID="chkShowDisabled" runat="server" />
                <label style="margin-right: 5px">Show Disabled</label>
                <asp:TextBox ID="txtSearchUser" runat="server" Style="height: 35px; width: 189px" placeholder="Email or Username"></asp:TextBox>
                <asp:Button ID="btnApplyFilter" runat="server" Text="Apply Filter" CssClass="btn btn-dark m-2" OnClick="btnApplyFilter_Click" />

            </div>--%>
            <div class="row">
                <div class="col-sm-2" style="margin-right:-85px">
                    <asp:CheckBox ID="chkShowDisabled" runat="server" />
                    <label  style="padding-left: -150px">Show Disabled</label>
                </div>
                <div class="col-sm-3" style="margin-top:-7px;margin-right:-26px">
                    <asp:TextBox ID="txtSearchUser" runat="server" CssClass="form-control" placeholder="Email or Username"></asp:TextBox>
                   
                </div>
                <div class="col-sm-1" style="margin-top:-15px">
                     <asp:Button ID="btnApplyFilter" runat="server" Text="Apply Filter" CssClass="btn btn-dark m-2 " OnClick="btnApplyFilter_Click" />
                </div>

            </div>
        </asp:Panel>
    </div>
</asp:Content>

