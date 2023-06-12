using NUnit.Framework;
using System.Data;
using System.Data.SqlClient;

namespace YourNamespace.Tests
{
    [TestFixture]
    public class AppTests
    {
        private const string ConnectionString = "Your_Connection_String";

        [Test]
        public void GetDeviceName_ValidAssetTag_ReturnsDeviceName()
        {
            // Arrange
            string assetTag = "ABC123";
            string expectedDeviceName = "Device 1";
            var app = new YourPage();

            // Act
            string deviceName = app.GetDeviceName(assetTag);

            // Assert
            Assert.AreEqual(expectedDeviceName, deviceName);
        }

        [Test]
        public void GetCheckedOutTo_ValidAssetTag_ReturnsCheckedOutTo()
        {
            // Arrange
            string assetTag = "ABC123";
            string expectedCheckedOutTo = "John Doe";
            var app = new YourPage();

            // Act
            string checkedOutTo = app.GetCheckedOutTo(assetTag);

            // Assert
            Assert.AreEqual(expectedCheckedOutTo, checkedOutTo);
        }

        [Test]
        public void GetRecentLocations_ValidAssetTag_ReturnsRecentLocations()
        {
            // Arrange
            string assetTag = "ABC123";
            int expectedLocationCount = 3;
            var app = new YourPage();

            // Act
            DataTable recentLocations = app.GetRecentLocations(assetTag);

            // Assert
            Assert.IsNotNull(recentLocations);
            Assert.AreEqual(expectedLocationCount, recentLocations.Rows.Count);
        }
    }
}
