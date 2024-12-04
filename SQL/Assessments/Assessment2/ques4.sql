use sql_db_2

--question 4

CREATE TABLE Employee (
    empno INT PRIMARY KEY,
    ename VARCHAR(50),
    sal DECIMAL(10, 2),
    doj DATE
);

BEGIN TRANSACTION;

INSERT INTO Employee (empno, ename, sal, doj) VALUES (1, 'A', 50000, '2022-01-01');
INSERT INTO Employee (empno, ename, sal, doj) VALUES (2, 'B', 60000, '2022-02-01');
INSERT INTO Employee (empno, ename, sal, doj) VALUES (3, 'C', 70000, '2022-03-01');

UPDATE Employee SET sal = sal * 1.15 WHERE empno = 2;

DELETE FROM Employee WHERE empno = 1;

SELECT * FROM Employee;

COMMIT TRANSACTION;


SELECT * FROM Employee;