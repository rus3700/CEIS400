CREATE TABLE IF NOT EXISTS User (
    UserId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL
    -- Add more columns as needed
);

CREATE TABLE IF NOT EXISTS Device (
    DeviceId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    AssetTag VARCHAR(20) NOT NULL
    -- Add more columns as needed
);