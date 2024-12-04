create database assessment2sqlserver

--question 3

use assessment2sqlserver

CREATE TABLE DEPT (
    deptno INT PRIMARY KEY,
    dname VARCHAR(50),
    loc VARCHAR(50)
);

CREATE TABLE EMP (
    empno INT PRIMARY KEY,
    ename VARCHAR(50),
    job VARCHAR(50),
    mgr_id INT,
    hiredate DATE,
    sal DECIMAL(10, 2),
    comm DECIMAL(10, 2),
    deptno INT,
    FOREIGN KEY (deptno) REFERENCES DEPT(deptno)
);


INSERT INTO DEPT (deptno, dname, loc) VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

INSERT INTO EMP (empno, ename, job, mgr_id, hiredate, sal, comm, deptno) VALUES
(7369, 'SMITH', 'CLERK', 7902, '2022-12-17', 800, 0, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '2020-04-02', 2975, 0, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '2017-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, 0, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, 0, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, 0, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, 0, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, 0, 20),
(7900, 'JAMES', 'CLERK', 7698, '2019-12-03', 950, 0, 30),
(7902, 'FORD', 'ANALYST', 7566, '2020-12-03', 3000, 0, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, 0, 10);


SELECT * FROM EMP
WHERE DATEDIFF(YEAR, hiredate, GETDATE())>=5
AND MONTH(hiredate) = MONTH(GETDATE())