create database ASN4 
use ASN4

--Ques 3
CREATE TABLE Students (
    id INT PRIMARY KEY,
    Sname VARCHAR(50)
);

CREATE TABLE Marks (
    Mid INT PRIMARY KEY,
    id INT FOREIGN KEY REFERENCES Students(Sid),
    Score INT
);

INSERT INTO Students (Sid, Sname) VALUES
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');

SELECT * FROM Students
SELECT * FROM Marks

INSERT INTO Marks (Mid, id, Score) VALUES
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);

CREATE SCHEMA abc

CREATE FUNCTION abc.GetStudentStatus (@id INT)
RETURNs VARCHAR(10)
AS
BEGIN
    DECLARE @Score INT;
	
    SELECT @Score = ISNULL(Score, 0)
    FROM Marks
    WHERE id = @id; 

    IF @Score >= 50
        RETURN 'Pass';
    ELSE
        RETURN 'Fail';
END;

--Ques 1
DECLARE @input INT = 5; 
DECLARE @factorial BIGINT; 

WITH FactorialCTE AS (
    SELECT 
        1 AS Number,
        1 AS Factorial
    UNION ALL
    SELECT 
        Number + 1,
        Factorial * (Number + 1)
    FROM 
        FactorialCTE
    WHERE 
        Number < @input
)
SELECT 
    Factorial
FROM 
    FactorialCTE
WHERE 
    Number = @input OPTION (MAXRECURSION 100);


--Ques 2
CREATE PROCEDURE GenerateMultiplicationTable
    @Number INT,
    @Limit INT
AS
BEGIN
    SET NOCOUNT ON;

    CREATE TABLE #MultiplicationTable (
        Multiplier INT,
        Result INT
    );

    DECLARE @i INT = 1;

    WHILE @i <= @Limit
    BEGIN
        INSERT INTO #MultiplicationTable (Multiplier, Result)
        VALUES (@i, @Number * @i);
        
        SET @i = @i + 1;
    END

    SELECT * FROM #MultiplicationTable;

    DROP TABLE #MultiplicationTable;
END






