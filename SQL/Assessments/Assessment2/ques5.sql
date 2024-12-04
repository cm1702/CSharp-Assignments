use my_db

--question 5

CREATE TABLE Employee (
    empno INT PRIMARY KEY,
    ename VARCHAR(50),
    sal DECIMAL(10, 2),
    deptno INT
);

INSERT INTO Employee (empno, ename, sal, deptno) VALUES (1, 'A', 50000, 10);
INSERT INTO Employee (empno, ename, sal, deptno) VALUES (2, 'B', 60000, 20);
INSERT INTO Employee (empno, ename, sal, deptno) VALUES (3, 'C', 70000, 30);
INSERT INTO Employee (empno, ename, sal, deptno) VALUES (4, 'D', 80000, 20);

SELECT * FROM Employee;

CREATE SCHEMA abc;

CREATE FUNCTION abc.CalculateBonus (
    @sal DECIMAL(10, 2), 
    @deptno INT          
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @bonus DECIMAL(10, 2)

    IF @deptno = 10
        SET @bonus = @sal * 0.15;  
    ELSE IF @deptno = 20
        SET @bonus = @sal * 0.20;  
    ELSE
        SET @bonus = @sal * 0.05;  

    RETURN @bonus
END;

SELECT 
    empno,
    ename,
    sal,
    deptno,
    abc.CalculateBonus(deptno, sal) AS Bonus
FROM 
    Employee;