<%@ Page Language="C#"  AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="NetworkControl.aspx.cs" Inherits="InventoryTrackingApp.NetworkControl" %>
   
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="form-container">
            <asp:Label ID="lblAssetTag" runat="server" Text="Asset Tag:"></asp:Label>
            <asp:TextBox ID="txtAssetTag" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>
        <div id="deviceInfo" runat="server" visible="false">
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
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    

</asp:Content>

