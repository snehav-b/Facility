<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageVendor.aspx.cs" Inherits="Facility.ManageVendor" %>

<!DOCTYPE html>
<html>
<head>
    <title>Manage Vendors</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Manage Vendors</h2>
        <asp:GridView ID="GridViewVendors" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridViewVendors_RowDeleting">
            <Columns>
                <asp:BoundField DataField="VendorID" HeaderText="Vendor ID" />
                <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                <asp:BoundField DataField="Email" HeaderText="Email " />
                <asp:BoundField DataField="ContactInfo" HeaderText="Contact Number" />
                <asp:ButtonField Text="Delete" CommandName="Delete" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>

