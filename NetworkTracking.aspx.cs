using System;
using System.Data;
using System.Data.SqlClient;

public partial class YourPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string assetTag = txtAssetTag.Text;

            // Perform the database operation and retrieve the device information
            string deviceName = GetDeviceName(assetTag);
            string checkedOutTo = GetCheckedOutTo(assetTag);
            DataTable recentLocations = GetRecentLocations(assetTag);

            // Update the UI with the retrieved information
            lblDeviceName.Text = deviceName;
            lblCheckedOutTo.Text = checkedOutTo;
            gvRecentLocations.DataSource = recentLocations;
            gvRecentLocations.DataBind();

            // Show the device information section
            deviceInfo.Visible = true;
        }
    }

    protected string GetDeviceName(string assetTag)
    {
        
        // Perform the necessary database query to retrieve the device name based on the asset tag
        // Replace the following placeholder code with your actual database query implementation
        string deviceName = string.Empty;
        using (SqlConnection connection = new SqlConnection("Your_Connection_String"))
        {
            string query = "SELECT DeviceName FROM Devices WHERE AssetTag = @AssetTag";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AssetTag", assetTag);
                connection.Open();
                deviceName = Convert.ToString(command.ExecuteScalar());
                connection.Close();
            }
        }

        return deviceName;
    }

    protected string GetCheckedOutTo(string assetTag)
    {
        // Perform the necessary database query to retrieve the checked-out information based on the asset tag
        // Replace the following placeholder code with your actual database query implementation
        string checkedOutTo = string.Empty;
        using (SqlConnection connection = new SqlConnection("Your_Connection_String"))
        {
            string query = "SELECT CheckedOutTo FROM Checkouts WHERE AssetTag = @AssetTag";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AssetTag", assetTag);
                connection.Open();
                checkedOutTo = Convert.ToString(command.ExecuteScalar());
                connection.Close();
            }
        }

        return checkedOutTo;
    }

    protected DataTable GetRecentLocations(string assetTag)
    {
        // Perform the necessary database query to retrieve the recent locations based on the asset tag
        // Replace the following placeholder code with your actual database query implementation
        DataTable recentLocations = new DataTable();
        using (SqlConnection connection = new SqlConnection("Your_Connection_String"))
        {
            string query = "SELECT Location FROM Locations WHERE AssetTag = @AssetTag ORDER BY Date DESC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AssetTag", assetTag);
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(recentLocations);
                }
                connection.Close();
            }
        }

        return recentLocations;
    }
}
