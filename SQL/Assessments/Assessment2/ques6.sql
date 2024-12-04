
--question 6

CREATE PROCEDURE UpdateSalesSalary
AS
BEGIN
    UPDATE EMP
    SET sal = sal + 500
    FROM EMP
    INNER JOIN DEPT ON EMP.deptno = DEPT.deptno
    WHERE DEPT.dname = 'SALES' AND EMP.sal < 1500;
END;

EXEC UpdateSalesSalary;

SELECT * FROM EMP WHERE deptno = (SELECT deptno FROM DEPT WHERE dname = 'SALES');