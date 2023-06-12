public class Device
{
    public int DeviceId { get; set; }
    public string Name { get; set; }
    public string AssetTag { get; set; }
    // Add more properties as needed

    public void AddUser(User user)
    {
        // Code logic for assigning a user to the device
    }

    public void RemoveUser(User user)
    {
        // Code logic for removing a user from the device
    }
}