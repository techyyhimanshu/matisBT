<%@ Page Title="" Language="C#" MasterPageFile="~/webUsers/MasterPage.master" AutoEventWireup="true" CodeFile="Changelog.aspx.cs" Inherits="webUsers_Changelog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"><div class="container-fluid pt-4 px-4">
        <div class="col-sm-12 col-xl-6" style="width: 100%">
    <div class="bg-light rounded h-100 p-4">
        <h1>Project Version History</h1>
        <ul>
            <li>Version 0.0.1:
                <ul>
                    <li>Created 4 tables today:</li>
                    <ol>
                        <li>tbl_users</li>
                        <li>tbl_bug</li>
                        <li>tbl_project</li>
                        <li>tbl_activities</li>
                    </ol>
                </ul>
            </li>
            <li>Version 0.0.2:
                <ol>
                    <li>Created admin login page</li>
                    <li>Started working on admin dashboard page</li>
                </ol>
            </li>
            <li>Version 0.0.3:
                <ol>
                    <li>Created category section.</li>
                    <li>Created project add section.</li>
                    <li>Created normal user signup and login forms.</li>
                    <li>Started working on add issue section</li>
                </ol>
            </li>
            <li>Version 0.0.4:
                <ul>
                    <li>Worked on fetch all project details for admin</li>
                    <li>Created form for reporting a new issue</li>
                </ul>
            </li>
            <li>Version 0.0.5:
                <ol>
                    <li>Created Manage User Page by admin</li>
                    <li>Created add new user and select access role of user page</li>
                    <li>Created user dashboard page</li>
                    <li>Created report issue page</li>
                </ol>
            </li>
            <li>Version 0.0.6:
                <ol>
                    <li>Worked on manage user (update, delete user) by admin</li>
                    <li>Worked on view a particular issue by a user</li>
                </ol>
            </li>
            <li>Version 0.0.7:
                <ol>
                    <li>Worked on add user to project.</li>
                    <li>Worked on Search a particular user.</li>
                    <li>Worked on Activities section.</li>
                    <li>Created “Add a note” section</li>
                </ol>
            </li>
            <li>Version 0.0.8:
                <ul>
                    <li>Worked on “Add user to project”</li>
                    <li>Add some fields to “create new project”</li>
                    <li>Worked on “Clone issue” section</li>
                </ul>
            </li>
            <li>Version 0.0.9:
                <ol>
                    <li>Added features on manage account section (isEnabled, isProtected, createdDate, lastVisited)</li>
                    <li>Completed “Clone an issue” section</li>
                </ol>
            </li>
            <li>Version 0.0.10:
                <ol>
                    <li>Worked on the relationship between issues</li>
                    <li>Started working on Monitoring issue</li>
                    <li>Worked on project features (isEnabled, inheritGlobalCategories, chkSymbol)</li>
                    <li>Worked on project update section</li>
                </ol>
            </li>
            <li>Version 0.0.11:
                <ol>
                    <li>Completed Monitor project section</li>
                    <li>Worked on filters section</li>
                    <li>Completed category section (Add, update, delete, Assign To User)</li>
                    <li>Worked on subprojects</li>
                </ol>
            </li>
            <li>Version 0.0.12:
                <p>Adding features to subproject</p>
            </li>
            <li>Version 0.0.13:
                <p>Completed subproject section</p>
            </li>
            <li>Version 0.0.14:
                <ol>
                    <li>Started working on tag section</li>
                    <li>Learned about store procedures</li>
                </ol>
            </li>
            <li>Version 0.0.15:
                <p>Worked on store procedure on manageProject page and login function</p>
            </li>
            <li>Version 0.0.16:
                <ol>
                    <li>Completed manageProject class using store procedure</li>
                    <li>Worked on manageUsersByAdmin class using store procedure</li>
                </ol>
            </li>
            <li>Version 0.0.17:
                <p>Completed tag section</p>
            </li>
            <li>Version 0.0.18:
                <ol>
                    <li>Add protected and enabled sign on user section</li>
                    <li>Completed profile section</li>
                </ol>
            </li>
            <li>Version 0.0.19:
                <ol>
                    <li>Setup database and code</li>
                    <li>Started working on BCA student</li>
                </ol>
            </li>
        </ul>
    </div>
</div>


</asp:Content>

