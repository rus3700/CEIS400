USE rayinventory;

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE,
    email VARCHAR(100) UNIQUE,
    firstName VARCHAR(50),
    lastName VARCHAR(50),
    role VARCHAR(50)
);

CREATE TABLE deviceStatus (
    statusId INT PRIMARY KEY,
    statusDescription VARCHAR(20)
);

INSERT INTO deviceStatus (statusId, statusDescription)
VALUES
    (1, 'holding'),
    (2, 'available'),
    (3, 'checked Out'),
    (4, 'lost'),
    (5, 'salvaged'),
    (6, 'retired');
    
    CREATE TABLE networkData (
    wirelessMac VARCHAR(50),
    connectionDate DATETIME,
    location VARCHAR(50),
    PRIMARY KEY (wirelessMac, connectionDate)
);

CREATE TABLE device (
  deviceId INT PRIMARY KEY,
  deviceType VARCHAR(10),
  wirelessMacAddress VARCHAR(50),
  deviceStatus INT,
  userId INT,
  assetTag VARCHAR(10),
  FOREIGN KEY (deviceStatus) REFERENCES deviceStatus(statusId),
  FOREIGN KEY (userId) REFERENCES users(id)
);

INSERT INTO users (username, email, firstName, lastName, role)
VALUES
    ('jamess', 'stuart.james@rayschools.org', 'Stuart', 'James', 'admin'),
    ('powells', 'sarah.powell@rayschools.org', 'Sarah', 'Powell', 'technician'),
    ('lewisk', 'kim.lewis@rayschools.org', 'Kimberly', 'Lewis', 'secretary'),
    ('madisonm', 'madlen.madison@rayschools.org', 'Madlen', 'Madison', 'teacher'),
    ('massurat', 'thomas.massura@rayschools.org', 'Thomas', 'Massura', 'technician'),
    ('andersenp', 'peter.andersen@rayschools.org', 'Peter', 'Andersen', 'technician');
    
    select * from users;
    select * from devicestatus;

