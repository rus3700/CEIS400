using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace InventoryTrackingApp
{
    public partial class NetworkControl : System.Web.UI.Page
    {
        private string connectionString = "Server=localhost;port=3306;Database=rayinventory;Uid=root;Pwd=devry123;";
        protected void Page_Load(object sender, EventArgs e)
        {
           
                
            
        }

        protected string GetDeviceType(string assetTag)
        {

            string deviceType = string.Empty;
            

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT deviceType FROM device WHERE assetTag = @AssetTag";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AssetTag", assetTag);
                        connection.Open();

                        MySqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            deviceType = reader["deviceType"].ToString();
                        }

                        reader.Close();
                    }
                }

                return deviceType;
            }
            catch(Exception ex)
            {
                lblStatus.Text = "Error connecting to the database: " + ex.Message;
                return "connection error";
            }
        
        }

        protected string GetMac(string assetTag)
        {

            string mac = string.Empty;


            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT wirelessMacAddress FROM device WHERE assetTag = @AssetTag";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AssetTag", assetTag);
                        connection.Open();

                        MySqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            mac = reader["wirelessMacAddress"].ToString();
                        }


                        reader.Close();
                       // return mac;
                    }
                }

                
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error connecting to the database: " + ex.Message;
                
            }

            return mac;
        }

        protected string GetCheckedOutTo(int userId)
        {
            // Perform the necessary database query to retrieve the checked-out information based on the asset tag
            // Replace the following placeholder code with your actual database query implementation
            string checkedOutTo = string.Empty;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT CONCAT(firstName,' ',lastName) AS FullName FROM users WHERE id = @userId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    connection.Open();
                    checkedOutTo = Convert.ToString(command.ExecuteScalar());
                    connection.Close();
                }
            }

            return checkedOutTo;
        }

        protected DataTable GetRecentLocations(string mac)
        {
            // Perform the necessary database query to retrieve the recent locations based on the asset tag
            // Replace the following placeholder code with your actual database query implementation
            DataTable recentLocations = new DataTable();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT location FROM networkdata WHERE wirelessMac = @mac";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@mac", mac);
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(recentLocations);
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex) { lblStatus.Text = "Error checking locations: " + ex.Message; }
            return recentLocations;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string assetTag = txtAssetTag.Text;

            
            string deviceType = GetDeviceType(assetTag);
            string macAddress = GetMac(assetTag); //find mac address
           //string checkedOutTo = GetCheckedOutTo(assetTag); //find user
           DataTable recentLocations = GetRecentLocations(macAddress);

            // Update the UI with the retrieved information
            lblDeviceName.Text = deviceType;
            //lblCheckedOutTo.Text = checkedOutTo;
            gvRecentLocations.DataSource = recentLocations;
            gvRecentLocations.DataBind();

            // Show the device information section
            deviceInfo.Visible = true;
        }
    }
}