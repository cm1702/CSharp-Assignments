create database RRS;
use RRS

CREATE TABLE Trains (
    TrainId INT IDENTITY(1,1) PRIMARY KEY,
    TrainName NVARCHAR(30) NOT NULL,
    Source NVARCHAR(20) NOT NULL,
    Destination NVARCHAR(20) NOT NULL,
    TotalSeats INT NOT NULL,
    AvailableSeats INT NOT NULL,
    Date DATETIME NOT NULL
);


CREATE TABLE Bookings (
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    TrainId INT NOT NULL,
    PassengerName NVARCHAR(30) NOT NULL,
    SeatNumber INT NOT NULL,
    BookingDate DATETIME NOT NULL,
    FOREIGN KEY (TrainId) REFERENCES Trains(TrainId)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);


INSERT INTO Trains (TrainName, Source, Destination, TotalSeats, AvailableSeats, Date)
VALUES 
('Express 1', 'A', 'B', 200, 200, GETDATE()),
('Express 2', 'C', 'D', 110, 110, GETDATE()),
('Express 3', 'E', 'F', 245, 245, GETDATE()),
('Express 4', 'Y', 'Z', 500, 500, GETDATE());

INSERT INTO Bookings (TrainId, PassengerName, SeatNumber, BookingDate)
VALUES
(1, 'AA', 1, GETDATE()),
(2, 'BB', 1, GETDATE()),
(3, 'CC', 1, GETDATE());

SELECT * FROM Trains;

SELECT * FROM Bookings WHERE TrainId = 1;

SELECT b.BookingId, b.PassengerName, b.SeatNumber, b.BookingDate, t.TrainName, t.Source, t.Destination
FROM Bookings b
JOIN Trains t ON b.TrainId = t.TrainId
WHERE b.BookingId = 1;

UPDATE Trains
SET AvailableSeats = AvailableSeats - 1
WHERE TrainId = 1;

DELETE FROM Bookings
WHERE BookingId = 1;

CREATE PROCEDURE AddTrain
    @TrainName NVARCHAR(50),
    @Source NVARCHAR(50),
    @Destination NVARCHAR(50),
    @TotalSeats INT,
    @AvailableSeats INT,
    @Date DATETIME
AS
BEGIN
    INSERT INTO Trains (TrainName, Source, Destination, TotalSeats, AvailableSeats, Date)
    VALUES (@TrainName, @Source, @Destination, @TotalSeats, @AvailableSeats, @Date);
END;


CREATE PROCEDURE BookTicket
    @TrainId INT,
    @PassengerName NVARCHAR(50),
    @SeatNumber INT
AS
BEGIN
    INSERT INTO Bookings (TrainId, PassengerName, SeatNumber, BookingDate)
    VALUES (@TrainId, @PassengerName, @SeatNumber, GETDATE());

    UPDATE Trains
    SET AvailableSeats = AvailableSeats - 1
    WHERE TrainId = @TrainId;
END;


CREATE PROCEDURE CancelTicket
    @BookingId INT
AS
BEGIN
    DECLARE @TrainId INT;

    SELECT @TrainId = TrainId
    FROM Bookings
    WHERE BookingId = @BookingId;

    DELETE FROM Bookings
    WHERE BookingId = @BookingId;

    IF @TrainId IS NOT NULL
    BEGIN
        UPDATE Trains
        SET AvailableSeats = AvailableSeats + 1
        WHERE TrainId = @TrainId;
    END;
END;

SELECT * FROM Trains;
SELECT * FROM Bookings;








