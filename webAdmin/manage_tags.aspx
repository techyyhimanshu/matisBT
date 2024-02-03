<%@ Page Title="" Language="C#" MasterPageFile="~/webAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="manage_tags.aspx.cs" Inherits="webAdmin_manage_tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid pt-4 px-4" style="width: 100%; position: relative; min-height: 100vh;">
            <div class="bg-light rounded h-100 p-4">
                <h6 class="mb-4">Create Tag</h6>

                <div class="row mb-3">
                    <label class="col-sm-2 col-form-label">Name</label>
                    <div class="col-sm-3">
                        <asp:TextBox ID="txtTagName" pattern="^[A-Za-z0-9]+$" title="Only alphabets and numbers are allowed" runat="server" class="form-control" required></asp:TextBox>
                    </div>
                </div>
              
                <div class="row">
                    <div class="col-2"></div>
                    <div class="col-4">
                <asp:Button ID="btnCreateTag" runat="server" class="btn btn-primary" Text="Create Tag" OnClick="btnCreateTag_Click"/>
                        </div>
                    </div>
                <br />
                <h6 class="mb-4">Existing Tags</h6>
                <asp:GridView ID="gridShowAllTags" runat="server" AutoGenerateColumns="False" DataKeyNames="tagName" CssClass="table" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <a href='<%# "manage_tags_edit.aspx?tag_id=" + Eval("tagID") %>' class="hover-underline"><%# Eval("tagName") %></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:BoundField DataField="tagCreatedDate" HeaderText="Created Date" SortExpression="tagCreatedDate" />
                        <asp:BoundField DataField="tagLastUpdated" HeaderText="Last Updated" SortExpression="tagLastUpdated" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>

