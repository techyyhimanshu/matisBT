<%@ Page Title="" Language="C#" MasterPageFile="~/webAdmin/MasterPage.master" AutoEventWireup="true" CodeFile="manage_category.aspx.cs" Inherits="webAdmin_addCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid pt-4 px-4" style="width:100%; position: relative; min-height: 100vh;">
    <div class="col-sm-12 col-xl-6" style="width: 100%; border-radius: 16px !important;">
        <div class="bg-light rounded h-100 p-4">
            <h6 class="mb-4">Category Details</h6>
            <div class="form-floating mb-3">
                <div class="row">
                    <div class="col-10">
                        <asp:TextBox ID="txtCatName" runat="server" CssClass="form-control" placeholder="Category name" required></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <asp:Button ID="btnAddCat" runat="server" Text="Add" CssClass="btn btn-dark" Width="100%" OnClick="btnAddCat_Click" />
                    </div>
                </div>
                
                <br />

                <asp:GridView ID="gridShowCategories" runat="server" AutoGenerateColumns="False" DataKeyNames="CatID"  OnRowCommand="gridCatDetails_Row" OnRowDeleting="gridCatDetails_RowDeleting" DataSourceID="SqlDataSource1" CssClass="table table-hover" AllowPaging="true" PageSize="10" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#252526" HeaderStyle-ForeColor="White" RowStyle-VerticalAlign="Middle">
            <Columns>
                <asp:BoundField DataField="CatName" HeaderText="CatName" SortExpression="CatName" />
                <%--<asp:BoundField DataField="assignedToUser" HeaderText="Assigned To" InsertVisible="False" ReadOnly="True" SortExpression="assignedToUser" />--%>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>  
                        <a href='<%# "manage_category_edit.aspx?id=" + Eval("CatID") %>' id="catName" class="btn btn-outline-primary m-2"  style="font-size:10px">Update</a>
                        <%--<asp:LinkButton ID="btnDeleteCat" runat="server" CommandName="delete" CommandArgument='<%#Eval("CatID") %>' CssClass="btn btn-outline-danger m-2" style="font-size:10px" >Delete</asp:LinkButton>--%>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
            </div>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MantisBtConString %>" SelectCommand="SELECT * FROM [tbl_Category]"></asp:SqlDataSource>
        </div>
    </div>
    <div style="border: 0px solid black; width: 482px; background-color: #F3F6F9 !important; margin-top: 20px">
        <%--<asp:GridView ID="gridShowCategories" runat="server" AutoGenerateColumns="False" DataKeyNames="CatID"  OnRowCommand="gridCatDetails_Row" OnRowDeleting="gridCatDetails_RowDeleting" DataSourceID="SqlDataSource1" CssClass="table table-hover" AllowPaging="true" PageSize="5" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="CatName" HeaderText="CatName" SortExpression="CatName" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>  
                        <a href='<%# "manage_category_edit.aspx?id=" + Eval("CatID") %>' id="catName" class="btn btn-outline-primary m-2"  style="font-size:10px">Update</a>
                        <asp:LinkButton ID="btnDeleteCat" runat="server" CommandName="delete" CommandArgument='<%#Eval("CatID") %>' CssClass="btn btn-outline-danger m-2" style="font-size:10px" >Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>--%>
    </div>
        </div>
</asp:Content>

