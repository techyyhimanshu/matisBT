<%@ Page Title="" Language="C#" MasterPageFile="~/webAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="manage_category_edit.aspx.cs" Inherits="webAdmin_manage_category_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid pt-4 px-4" style="width: 100%; position: relative; min-height: 100vh;">
        <%--<div class="col-sm-12 col-xl-6">--%>
        <div class="bg-light rounded h-100 p-4">
            <h6 class="mb-4">Edit Project Category</h6>
            <div class="row mb-3">
                <label for="inputEmail3" class="col-sm-2 col-form-label">Category</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtCatName" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
           <%-- <div class="row mb-3">
                <label for="inputPassword3" class="col-sm-2 col-form-label">Assigned To</label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="dlAssignedToUsers" runat="server" CssClass="form-select mb-3"></asp:DropDownList>
                </div>
            </div>--%>
                <asp:Button ID="btnUpdateCat" runat="server" Text="Update Category" CssClass="btn btn-primary col-sm-2 " OnClick="btnUpdateCat_Click" style ="margin-left:17.5%"/>

        </div>
        <%--</div>--%>
    </div>
</asp:Content>

