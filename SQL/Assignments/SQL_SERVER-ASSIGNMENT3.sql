use sql_db_2
--1.
SELECT DISTINCT ename
FROM EMP
WHERE job = 'MANAGER';
--2.
SELECT ename, sal
FROM EMP
WHERE sal > 1000;

-- 3.
SELECT ename, sal
FROM EMP
WHERE ename <> 'JAMES';

-- 4.
SELECT *
FROM EMP
WHERE ename LIKE 'S%';

-- 5. 
SELECT ename
FROM EMP
WHERE ename LIKE '%A%';

-- 6.
SELECT ename
FROM EMP
WHERE ename LIKE '__L%';

-- 7. 
SELECT sal / 30 AS daily_salary
FROM EMP
WHERE ename = 'JONES';

-- 8. 
SELECT SUM(sal) AS total_monthly_salary
FROM EMP;

-- 9. 
SELECT AVG(sal) * 12 AS average_annual_salary
FROM EMP;

-- 10. 
SELECT ename, job, sal, deptno
FROM EMP
WHERE deptno = 30 AND job <> 'SALESMAN';

-- 11. 
SELECT DISTINCT deptno
FROM EMP;

--12.
SELECT ename AS Employee, sal AS Monthly_Salary
FROM EMP
WHERE sal > 1500 AND deptno IN (10, 30);

-- 13. 
SELECT ename, job, sal
FROM EMP
WHERE (job = 'MANAGER' OR job = 'ANALYST') AND sal NOT IN (1000, 3000, 5000);

--14.
SELECT ename, sal, comm
FROM EMP
WHERE comm > (sal * 1.1);

--15.
SELECT ename
FROM EMP
WHERE (ename LIKE '%L%L%' AND deptno = 30) OR mgr_id = 7782;

--16.
SELECT COUNT(*) AS total_employees
FROM EMP
WHERE DATEDIFF(YEAR, hiredate, GETDATE()) > 30
  AND DATEDIFF(YEAR, hiredate, GETDATE()) < 40;

-- 17. 
SELECT d.dname, e.ename
FROM DEPT d
JOIN EMP e ON d.deptno = e.deptno
ORDER BY d.dname ASC, e.ename DESC;

-- 18. 
SELECT DATEDIFF(YEAR, hiredate, GETDATE()) AS experience
FROM EMP
WHERE ename = 'MILLER';



