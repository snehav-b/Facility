<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="YourProjectNamespace.AdminDashboard" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Admin Dashboard</title>
    <link rel="stylesheet" href="styles.css"> <!-- Add your styles here -->
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-container">
            <h1>Welcome to Admin Dashboard</h1>
            <div class="menu">
                <ul>
                    <li><a href="ManageUsers.aspx">Manage Users</a></li>
                    <li><a href="ManageVendors.aspx">Manage Vendors</a></li>
                    <li><a href="ManageServices.aspx">Manage Services</a></li>
                    <li><a href="ViewBookings.aspx">View Bookings</a></li>
                    <li><a href="ManageReviews.aspx">Manage Reviews</a></li>
                    <li><a href="ProfileSettings.aspx">Profile Settings</a></li>
                    <li><a href="Logout.aspx">Logout</a></li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>

