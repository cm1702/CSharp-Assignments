create database mvc_cc_1
use mvc_cc_1

USE MoviesDB;

CREATE TABLE Movie
(
    Mid INT PRIMARY KEY IDENTITY(1,1), 
    MovieName NVARCHAR(20) NOT NULL, 
    DateOfRelease DATE NOT NULL 
);

INSERT INTO Movie (MovieName, DateOfRelease) VALUES 
('Life of pie', '2010-07-16'),
('The Dark Knight Rises', '2008-07-18'),
('The Goodfellas', '2014-11-07'),
('Terminator', '1972-03-24'),
('Lagaan', '2001-10-14'),
('Aparichit', '2005-09-23'),
('Pushpa 2', '2024-07-06');



