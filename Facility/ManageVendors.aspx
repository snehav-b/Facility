<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageVendors.aspx.cs" Inherits="Facility.ManageVendors" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Vendors</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Manage Vendors</h2>
            
            <!-- Your GridView or other controls here -->
            <asp:GridView ID="GridViewVendors" runat="server" AutoGenerateColumns="True">
            </asp:GridView>

        </div>
    </form>
</body>
</html>


