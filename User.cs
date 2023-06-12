public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    // Add more properties as needed

    public void CheckOutDevice(Device device)
    {
        // Code logic for checking out a device
    }

    public void ReturnDevice(Device device)
    {
        // Code logic for returning a device
    }
}