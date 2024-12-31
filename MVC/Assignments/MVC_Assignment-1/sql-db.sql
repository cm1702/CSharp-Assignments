CREATE DATABASE ContactManagement;
USE ContactManagement;  

CREATE TABLE Contacts (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY, 
    FirstName NVARCHAR(20) NOT NULL,   
    LastName NVARCHAR(20) NOT NULL,     
    Email NVARCHAR(50) NOT NULL UNIQUE   
);

INSERT INTO Contacts (FirstName, LastName, Email) VALUES 
('A', 'B', 'a.b@example.com'),
('C', 'D', 'c.d@example.com'),
('E', 'F', 'e.f@example.com');

