<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="ManageUsers" %>

<!DOCTYPE html>
<html>
<head>
    <title>Manage Users</title>
</head>
<body>
    <h1>Manage Users</h1>
     <form id="form1" runat="server">
    <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" OnRowEditing="GridViewUsers_RowEditing" 
        OnRowDeleting="GridViewUsers_RowDeleting" OnRowCancelingEdit="GridViewUsers_RowCancelingEdit" 
        OnRowUpdating="GridViewUsers_RowUpdating">
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="User ID" ReadOnly="True" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="Username" HeaderText="Username" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
         

    <h2>Add New User</h2>
    <asp:TextBox ID="txtFirstName" runat="server" Placeholder="First Name"></asp:TextBox>
    <asp:TextBox ID="txtLastName" runat="server" Placeholder="Last Name"></asp:TextBox>
    <asp:TextBox ID="txtUsername" runat="server" Placeholder="Username"></asp:TextBox>
    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox>
    <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" />
         </form>
</body>
</html>

