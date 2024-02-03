<%@ Page Title="" Language="C#" MasterPageFile="~/webAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="project_management.aspx.cs" Inherits="webAdmin_project_management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid pt-4 px-4" style="width:100%; position: relative; min-height: 100vh;">
    <!-- Main Content start -->
     <asp:Panel ID="pnlAlertMessageForNewProject" runat="server" CssClass="alert alert-success" Visible="false" style ="width:1300px;margin-top:20px;margin-left:20px">
        <asp:Label ID="lblProjectCreated" runat="server"></asp:Label>
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

    <asp:Panel ID="pnlAddProj" runat="server" Visible="false">
        
            <div class="bg-light rounded h-100 p-4">
                <h6 class="mb-4">Project Details</h6>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtProjName" runat="server" class="form-control" placeholder="Project name"></asp:TextBox>
                    <label for="floatingInput">Project name</label>
                </div>
                 <%-- <div class="mb-3 form-check" style="margin-left: -20px" >
                    <asp:CheckBox ID="chkGlobalCategory" runat="server" />
                    <label class="form-check-label" for="exampleCheck1">Inherit global categories</label>
                </div>--%>
                <%-- <asp:Panel ID="pnlChkInheritCat" runat="server" Visible="false">
                    <div class="mb-3 form-check" style="margin-left: -20px">
                        <asp:CheckBox ID="chkInheritParentCategory" runat="server" />
                        <label class="form-check-label" for="exampleCheck1">Inherit parent categories</label>
                    </div>
                </asp:Panel>--%>
                <asp:DropDownList ID="ddlProjectStatus" runat="server" class="form-select">
                    <asp:ListItem Text="Select Status" Value="" />
                    <asp:ListItem Text="development" Value="1" />
                    <asp:ListItem Text="release" Value="2" />
                    <asp:ListItem Text="stable" Value="3" />
                    <asp:ListItem Text="obsolete" Value="4" />

                </asp:DropDownList>

                <br />
                <asp:DropDownList ID="dlStatus" runat="server" class="form-select" Style="height: 39px; padding-top: 8px; width: 115px">
                    <asp:ListItem Text="Public" Value="1" />
                    <asp:ListItem Text="Private" Value="2" />
                </asp:DropDownList>
                <br />
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtDescription" runat="server" class="form-control" placeholder="Description" TextMode="MultiLine" Rows="8" Columns="60" Style="height: 200px"></asp:TextBox>
                    <label for="floatingInput">Description</label>
                </div>

                <asp:Button ID="btnAddProject" runat="server" Text="Add" class="btn btn-primary m-2" OnClick="btnAddProject_Click" />
                <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-secondary m-2" OnClick="btnBack_Click" />
            </div>
        
    </asp:Panel>
    <asp:Panel ID="pnlShowAllProjects" runat="server" Visible="true">
        <asp:Panel ID="pnlHeading" runat="server">
            <h3 class="p-2 mb-2 bg-secondary text-white"># All projects:</h3>
        </asp:Panel>
        <asp:GridView ID="gridShowProjectDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-hover;bg-light rounded h-100 p-4">
            <Columns>
                <asp:TemplateField HeaderText="Project Name">
                    <ItemTemplate>
                       <a href='<%# "project_management_edit.aspx?id=" + Eval("projectID") %>' id="projName" class="hover-underline"><%# Eval("Project Name") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="Status" />
                <asp:ImageField DataImageUrlField="isEnabled" HeaderText="Enabled"></asp:ImageField>
                <asp:BoundField DataField="viewStatus" HeaderText="View Status" SortExpression="View Status" />
                <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Button ID="btnCreateProject" runat="server" Text="Create Project" class="btn btn-primary m-2" OnClick="btnCreateProject_Click" />
    <!-- Main Content end -->
        </div>
</asp:Content>

