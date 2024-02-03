<%@ Page Title="" Language="C#" MasterPageFile="~/webAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="manage_tags_edit.aspx.cs" Inherits="webAdmin_manage_tags_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid pt-4 px-4" style="width: 100%; position: relative; min-height: 100vh;">
        <div class="bg-light rounded h-100 p-4">
            <h6 class="mb-4">Update Tag</h6>

            <div class="row mb-3">
                <label for="inputEmail3" class="col-sm-2 col-form-label">Name</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtTagNameForUpdate"  runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

          

            <div class="row mb-3">
                <label class="col-sm-2 col-form-label">Created Date</label>
                <div class="col-sm-10">
                    <asp:Label ID="lblCreatedDate" runat="server" CssClass="list-group-item bg-transparent"></asp:Label>
                </div>
            </div>

            <div class="row mb-3">
                <label class="col-sm-2 col-form-label">Last Updated</label>
                <div class="col-sm-10">
                    <asp:Label ID="lblLastUpdated" runat="server" class="list-group-item bg-transparent"></asp:Label>
                </div>
            </div>
          
            <asp:Button ID="btnUpdateTag" runat="server" class="btn btn-primary" Text="Update Tag" OnClick="btnUpdateTag_Click" />
            <asp:Button ID="btnDeleteTag" runat="server" class="btn btn-secondary m-2" Text="Delete Tag" OnClick="btnDeleteTag_Click" />

        </div>
    </div>
</asp:Content>

