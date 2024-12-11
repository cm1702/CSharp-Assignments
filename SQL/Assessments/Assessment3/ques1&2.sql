create database newdb5
use newdb5

CREATE TABLE CourseDetails (
   C_id VARCHAR(255) PRIMARY KEY,
   C_Name VARCHAR(255),
   Start_date DATE,
   End_date DATE,
   Fee INT
);
 
INSERT INTO CourseDetails (C_id, C_Name, Start_date, End_date, Fee) VALUES
('DN003', 'DotNet', '2018-02-01', '2018-02-28', 15000),
('DV004', 'DataVisualization', '2018-03-01', '2018-04-15', 15000),
('JA002', 'AdvancedJava', '2018-01-02', '2018-01-20', 10000),
('JC001', 'CoreJava', '2018-01-02', '2018-01-12', 3000);
 
 
--ques 1

CREATE OR ALTER FUNCTION Courseduration(
    @StartDate DATE,
    @EndDate DATE
)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(DAY, @StartDate, @EndDate)
END;
 
 
SELECT C_id,C_Name,Start_date,End_date,Fee, dbo.Courseduration(Start_date, End_date) AS Durationindays 
FROM CourseDetails;
 
 
-- ques 2
CREATE TABLE T_CourseInfo (
   CourseName VARCHAR(10),
   StartDate DATE
);
 
CREATE TRIGGER after_course_insert
ON CourseDetails
AFTER INSERT
AS
BEGIN
   INSERT INTO T_CourseInfo (CourseName, StartDate)
   SELECT C_Name, Start_date
   FROM inserted;
END;
 
 
INSERT INTO CourseDetails (C_id, C_Name, Start_date, End_date, Fee)
VALUES ('SQ005', 'SQL_TRAINING', '2023-01-01', '2023-02-01', 12000);
 
SELECT * FROM T_CourseInfo;