CREATE DATABASE RailRes_A;
USE RailRes_A;


CREATE TABLE Admins (
    AdminId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(20) NOT NULL,
    Password NVARCHAR(20) NOT NULL
);




CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(20) NOT NULL,
    Password NVARCHAR(20) NOT NULL
);




CREATE TABLE Trains (
    TrainId INT IDENTITY(1,1) PRIMARY KEY,
    TrainName NVARCHAR(10) NOT NULL,
    Source NVARCHAR(20) NOT NULL,
    Destination NVARCHAR(20) NOT NULL,
    TotalSeats INT NOT NULL,
    AvailableSeats INT NOT NULL,
    DateOfJourney DATE NOT NULL
);




CREATE TABLE Bookings (
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    TrainId INT FOREIGN KEY REFERENCES Trains(TrainId) ON DELETE CASCADE,
    UserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,
    PassengerName NVARCHAR(20) NOT NULL,
    SeatNumber INT NOT NULL,
    BookingDate DATETIME DEFAULT GETDATE()
);



INSERT INTO Admins (Username, Password)
VALUES ('admin1', 'adminpass'), ('admin2', 'admin123');



INSERT INTO Users (Username, Password)
VALUES ('user1', 'userpass'), ('user2', 'user123');



INSERT INTO Trains (TrainName, Source, Destination, TotalSeats, AvailableSeats, DateOfJourney)
VALUES 
('T1', 'Jaipur', 'Udaipur', 100, 100, '2024-12-20'),
('T2', 'Hyderabad', 'Ahmedabad', 120, 120, '2024-12-22'),
('T3', 'Chennai', 'Mysore', 90, 90, '2024-12-24'),
('T4', 'Bombay', 'Pune', 120, 120, '2024-12-19'),
('T5', 'New Delhi', 'Srinagar', 220, 220, '2024-12-11');




CREATE PROCEDURE AddTrain
    @TrainName NVARCHAR(20),
    @Source NVARCHAR(20),
    @Destination NVARCHAR(20),
    @TotalSeats INT,
    @DateOfJourney DATE
AS
BEGIN
    INSERT INTO Trains (TrainName, Source, Destination, TotalSeats, AvailableSeats, DateOfJourney)
    VALUES (@TrainName, @Source, @Destination, @TotalSeats, @TotalSeats, @DateOfJourney);
END;




CREATE PROCEDURE GetAllTrains
AS
BEGIN
    SELECT * FROM Trains;
END;


CREATE PROCEDURE BookTicket
    @TrainId INT,
    @UserId INT,
    @PassengerName NVARCHAR(20),
    @SeatNumber INT
AS
BEGIN
    DECLARE @AvailableSeats INT;

    SELECT @AvailableSeats = AvailableSeats FROM Trains WHERE TrainId = @TrainId;

    IF (@AvailableSeats > 0)
    BEGIN
        INSERT INTO Bookings (TrainId, UserId, PassengerName, SeatNumber)
        VALUES (@TrainId, @UserId, @PassengerName, @SeatNumber);

        UPDATE Trains
        SET AvailableSeats = AvailableSeats - 1
        WHERE TrainId = @TrainId;
    END
    ELSE
    BEGIN
        PRINT 'No seats available!';
    END;
END;




CREATE PROCEDURE GetUserBookings
    @UserId INT
AS
BEGIN
    SELECT b.BookingId, t.TrainName, b.PassengerName, b.SeatNumber, t.DateOfJourney
    FROM Bookings b
    INNER JOIN Trains t ON b.TrainId = t.TrainId
    WHERE b.UserId = @UserId;
END;




CREATE PROCEDURE AuthenticateUser
    @Username NVARCHAR(10),
    @Password NVARCHAR(20),
    @Table NVARCHAR(50)
AS
BEGIN
    DECLARE @Count INT;
    DECLARE @Query NVARCHAR(MAX);

    SET @Query = 'SELECT @Count = COUNT(*) FROM ' + @Table + ' WHERE Username = @Username AND Password = @Password';
    EXEC sp_executesql @Query, N'@Username NVARCHAR(50), @Password NVARCHAR(50), @Count INT OUTPUT', @Username, @Password, @Count OUTPUT;

    SELECT @Count AS Result;
END;




CREATE PROCEDURE GetUserId
    @Username NVARCHAR(10),
    @Password NVARCHAR(20)
AS
BEGIN
    SELECT UserId FROM Users WHERE Username = @Username AND Password = @Password;
END;


CREATE PROCEDURE DeleteTrain
    @TrainId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Trains
    WHERE TrainId = @TrainId;

	RETURN @@ROWCOUNT;
END;


CREATE PROCEDURE UpdateTrain
    @TrainId INT,
    @TrainName NVARCHAR(20) = NULL,
    @Source NVARCHAR(20) = NULL,
    @Destination NVARCHAR(20) = NULL,
    @TotalSeats INT = NULL,
    @DateOfJourney DATE = NULL
AS
BEGIN
    UPDATE Trains
    SET 
        TrainName = ISNULL(@TrainName, TrainName),
        Source = ISNULL(@Source, Source),
        Destination = ISNULL(@Destination, Destination),
        TotalSeats = ISNULL(@TotalSeats, TotalSeats),
        AvailableSeats = CASE 
                            WHEN @TotalSeats IS NOT NULL THEN @TotalSeats - (TotalSeats - AvailableSeats)
                            ELSE AvailableSeats
                         END,
        DateOfJourney = ISNULL(@DateOfJourney, DateOfJourney)
    WHERE TrainId = @TrainId;
END;




EXEC AddTrain 'T4', 'Bombay', 'Pune', 220, '2024-12-19';


EXEC GetAllTrains;


EXEC BookTicket @TrainId = 1, @UserId = 1, @PassengerName = 'John Doe', @SeatNumber = 15;


EXEC GetUserBookings @UserId = 1;


EXEC AuthenticateUser @Username = 'admin1', @Password = 'adminpass', @Table = 'Admins';

EXEC DeleteTrain @TrainId = 1;

EXEC UpdateTrain @TrainId = 1, @TrainName = 'T9' , @Source = 'Kolkata', @Destination = 'Indore', @TotalSeats = 234 , @DateOfJourney = '2025-12-29';