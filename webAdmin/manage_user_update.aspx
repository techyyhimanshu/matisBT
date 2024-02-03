<%@ Page Title="" Language="C#" MasterPageFile="~/webAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="manage_user_update.aspx.cs" Inherits="webAdmin_manage_user_update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid pt-4 px-4" style="width: 100%; position: relative; min-height: 100vh;">
        <div class="bg-light rounded h-100 p-4">
            <h6 class="mb-4">Update user details</h6>
            <div class="row mb-3">
                <label class="col-sm-2 col-form-label">Username</label>
                <div class="col-sm-10">
                    <asp:Label ID="txtUserName" runat="server" class="form-control"></asp:Label>
                </div>
            </div>
            <div class="row mb-3">
                <label class="col-sm-2 col-form-label">Real name</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtRealName" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label class="col-sm-2 col-form-label">Email</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Please enter valid email" ForeColor="Red"  ValidationExpression="^[a-zA-Z0-9._%+-]+@(gmail\.com|outlook\.com|hotmail\.com|yahoo\.com)$"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3">
                <label for="userAccessLevel" class="col-sm-2 col-form-label">Access Level</label>
                <div class="col-sm-10">
                    <div class="form-floating mb-3">
                        <asp:DropDownList ID="ddlUserAccessLevel" runat="server" class="form-select" Style="height: 39px; padding-top: 8px">
                            <asp:ListItem Text="Viewer" Value="1" />
                            <asp:ListItem Text="Administrator" Value="2" />
                            <asp:ListItem Text="Manager" Value="3" />
                            <asp:ListItem Text="Updater" Value="4" />
                            <asp:ListItem Text="Developer" Value="5" />
                            <asp:ListItem Text="Reporter" Value="6" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row mb-3">
                    <label class="col-sm-2 col-form-label" style="padding-top:0px">Enabled</label>
                    <div class="col-sm-10" style="width: 294px">
                       <asp:CheckBox ID="chkEnabled" runat="server"/>
                    </div>
                </div>
                 <div class="row mb-3">
                    <label class="col-sm-2 col-form-label" style="padding-top:0px">Protected</label>
                    <div class="col-sm-10" style="width: 294px">
                      <asp:CheckBox ID="chkProtected" runat="server" style ="margin-top:12px" />
                    </div>
                </div>
            <asp:Button ID="btnUpdateUser" runat="server" Text="Update User" class="btn btn-primary col-2" OnClick="btnUpdateUser_Click" />
           <%-- <asp:Button ID="btnDeleterUser" runat="server" Text="Delete User" class="btn btn-secondary col-2" OnClick="btnDeleterUser_Click" />--%>
            <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-secondary col-2" OnClick="btnBack_Click" />
        </div>
    </div>

   <%-- <div class="col-sm-12 col-xl-6" style="padding-top: 80px; width: 983px">
        <div class="bg-light rounded h-100 p-4">
            <h6 class="mb-4">Add user to project</h6>
            <div class="row mb-3">
                <label class="col-sm-2 col-form-label">Assigned projects: </label>
                <div class="col-sm-10" style="width: 294px">
                    <asp:DropDownList ID="dlAssignedProjects" runat="server" class="form-select" Style="height: 39px; padding-top: 8px;width:202px;margin-left:12px">

                </asp:DropDownList>
                </div>
            </div>
            <div class="row mb-3">
                <label class="col-sm-2 col-form-label">Unassigned project:</label>
                <asp:DropDownList ID="dlUnassignedProjects" runat="server" class="form-select" Style="height: 39px; padding-top: 8px;width:202px;margin-left:12px">

                </asp:DropDownList>
            </div>

            <div class="row mb-3">
                <label for="userAccessLevel" class="col-sm-2 col-form-label">Access Level</label>
                <div class="col-sm-10" style="width: 224px">
                    <div class="form-floating mb-3">
                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-select" Style="height: 39px; padding-top: 8px">
                            <asp:ListItem Text="Viewer" Value="1" />
                            <asp:ListItem Text="Administrator" Value="2" />
                            <asp:ListItem Text="Manager" Value="3" />
                            <asp:ListItem Text="Updater" Value="4" />
                            <asp:ListItem Text="Developer" Value="5" />
                            <asp:ListItem Text="Reporter" Value="5" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnAssignedProject" runat="server" Text="Assign" class="btn btn-primary" OnClick="btnAssignedProject_Click" />
        </div>
    </div>--%>
</asp:Content>

