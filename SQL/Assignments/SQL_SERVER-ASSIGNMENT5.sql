use ASN4

--Ques 1
CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY,
    Salary DECIMAL(18, 2) NOT NULL,
    EmployeeName NVARCHAR(100) NOT NULL
);

INSERT INTO Employees (EmployeeId, Salary, EmployeeName) VALUES
(1, 50000.00, 'John Doe'),
(2, 60000.00, 'Jane Smith'),
(3, 55000.00, 'Alice Johnson'),
(4, 70000.00, 'Bob Brown'),
(5, 75000.00, 'Carol Davis'),
(6, 48000.00, 'David Wilson'),
(7, 52000.00, 'Eve Taylor'),
(8, 64000.00, 'Frank Thomas'),
(9, 72000.00, 'Grace Lee'),
(10, 68000.00, 'Hank Anderson');

CREATE PROCEDURE GeneratePayslip 
 @EmployeeId INT
AS
BEGIN
    DECLARE @Salary DECIMAL(18, 2);
    DECLARE @HRA DECIMAL(18, 2);
    DECLARE @DA DECIMAL(18, 2);
    DECLARE @PF DECIMAL(18, 2);
    DECLARE @IT DECIMAL(18, 2);
    DECLARE @Deductions DECIMAL(18, 2);
    DECLARE @GrossSalary DECIMAL(18, 2);
    DECLARE @NetSalary DECIMAL(18, 2);
    DECLARE @EmployeeName NVARCHAR(100);

    SELECT 
        @Salary = Salary,
        @EmployeeName = EmployeeName
    FROM Employees
    WHERE EmployeeId = @EmployeeId;

    IF (@Salary IS NULL)
    BEGIN
        RAISERROR('Employee with ID %d not found.', 16, 1, @EmployeeId);
        RETURN;
    END

    SET @HRA = @Salary * 0.10; 
    SET @DA = @Salary * 0.20;  
    SET @PF = @Salary * 0.08;
    SET @IT = @Salary * 0.05;   
     
    SET @Deductions = @PF + @IT;              
    SET @GrossSalary = @Salary + @HRA + @DA;  
    SET @NetSalary = @GrossSalary - @Deductions; 

    SELECT 
        @EmployeeId AS EmployeeId,
        @EmployeeName AS EmployeeName,
        @Salary AS Salary,
        @HRA AS HRA,
        @DA AS DA,
        @PF AS PF,
        @IT AS IT,
        @Deductions AS Deductions,
        @GrossSalary AS GrossSalary,
        @NetSalary AS NetSalary;
END

CREATE PROCEDURE PrintAllPayslips
AS
BEGIN
    DECLARE @EmployeeId INT;

    DECLARE employee_cursor CURSOR FOR
    SELECT EmployeeId FROM Employees;

    OPEN employee_cursor;

    FETCH NEXT FROM employee_cursor INTO @EmployeeId;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        EXEC GeneratePayslip @EmployeeId;

        FETCH NEXT FROM employee_cursor INTO @EmployeeId;
    END

    CLOSE employee_cursor;
    DEALLOCATE employee_cursor;
END

EXEC PrintAllPayslips;



--Ques 2
CREATE TABLE EMP (
    EmployeeId INT PRIMARY KEY,
    EmployeeName VARCHAR(100) NOT NULL,
    Salary DECIMAL(10, 2) NOT NULL,
    Department VARCHAR(50),
    DateOfJoining DATE
);

INSERT INTO EMP (EmployeeId, EmployeeName, Salary, Department, DateOfJoining) VALUES 
(1, 'Alice Johnson', 60000.00, 'HR', '2020-01-15'),
(2, 'Bob Smith', 75000.00, 'IT', '2018-03-10'),
(3, 'Charlie Brown', 55000.00, 'Sales', '2021-06-01'),
(4, 'Daisy Miller', 50000.00, 'Marketing', '2022-07-20'),
(5, 'Eva Green', 72000.00, 'IT', '2019-08-25');


CREATE TABLE Holidays (
    Holiday_Date DATE PRIMARY KEY,
    Holiday_Name VARCHAR(255) NOT NULL
);


INSERT INTO Holidays (Holiday_Date, Holiday_Name) VALUES
('2023-07-04', 'Independence Day'),
('2023-10-24', 'Diwali'),
('2023-12-25', 'Christmas'),
('2023-01-01', 'New Year''s Day');

CREATE TRIGGER trg_1
ON EMP
INSTEAD OF INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @HolidayName VARCHAR(255);
    DECLARE @CurrentDate DATE = CAST(GETDATE() AS DATE); 

    SELECT TOP 1 @HolidayName = Holiday_Name
    FROM Holidays
    WHERE Holiday_Date = @CurrentDate;

    IF @HolidayName IS NOT NULL
    BEGIN
        RAISERROR('Due to %s, you cannot manipulate data.', 16, 1, @HolidayName);
        ROLLBACK; 
        RETURN; 
    END

END;


INSERT INTO EMP (EmployeeId, Salary, EmployeeName) VALUES (1, 50000.00, 'Test Employee');

SELECT * FROM Holidays
SELECT * FROM EMP
