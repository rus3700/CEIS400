<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="NetworkTracking.aspx.cs" Inherits="InventoryTrackingApp.NetworkTracking" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .form-container {
            width: 400px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .form-container label {
            display: block;
            margin-bottom: 5px;
        }

        .form-container input[type="text"] {
            width: 100%;
            padding: 5px;
            margin-bottom: 10px;
        }

        .form-container input[type="submit"] {
            padding: 5px 10px;
            background-color: #4CAF50;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        #device-info {
            display: none;
            margin-top: 20px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        #device-info h2 {
            margin-top: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <asp:Label ID="lblAssetTag" runat="server" Text="Asset Tag:"></asp:Label>
            <asp:TextBox ID="txtAssetTag" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>
        <div id="Div1" runat="server" visible="false">
            <h2>Device Information</h2>
            <p>Device Name: <asp:Label ID="lblDeviceName" runat="server" Text=""></asp:Label></p>
            <p>Checked Out To: <asp:Label ID="lblCheckedOutTo" runat="server" Text=""></asp:Label></p>
            <p>Recent Locations:</p>
            <asp:GridView ID="gvRecentLocations" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

