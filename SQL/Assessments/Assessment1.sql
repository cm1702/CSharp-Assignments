use my_db

CREATE TABLE Books (
    id INT PRIMARY KEY,
    title NVARCHAR(100) NOT NULL,
    author_name NVARCHAR(30) NOT NULL,
    isbn NVARCHAR(20) UNIQUE NOT NULL,
    publish_date DATE
);

INSERT INTO Books (id, title, author_name, isbn, publish_date) VALUES
(1, 'My First SQL Book', 'Mary Parker', '981483029127', '2012-02-22'),
(2, 'My Second SQL Book', 'John Mayor', '857300923713', '1972-07-03'),
(3, 'My Third SQL Book', 'Cary flint','53120967812','2015-10-18');


CREATE TABLE Reviews (
    id INT PRIMARY KEY,
    book_id INT NOT NULL,
    reviewer_name NVARCHAR(255) NOT NULL,
    content NVARCHAR(MAX) NOT NULL,
    rating INT , 
    publish_date DATE,
    FOREIGN KEY (book_id) REFERENCES Books(id) 
);

INSERT INTO Reviews (id, book_id, reviewer_name, content, rating, publish_date) VALUES
(1, 1, 'John Smith', 'My first review', 4, '2017-12-10'),
(2, 2, 'John Smith', 'My second review', 5, '2017-10-13'),
(3, 3, 'Alice Walker', 'Another review', 1, '2017-10-22');

SELECT *
FROM Books
WHERE author_name LIKE '%er';


SELECT 
    B.title AS Title,
    B.author_name AS Author,
    R.reviewer_name AS ReviewerName
FROM 
    Books B
JOIN 
    Reviews R ON B.id = R.book_id;


SELECT reviewer_name
FROM Reviews
GROUP BY reviewer_name
HAVING COUNT(book_id) > 1;



CREATE TABLE Customers (
    id INT PRIMARY KEY,
    ename NVARCHAR(100),
    age INT,
    eaddress NVARCHAR(255),
    salary DECIMAL(10, 2)
);

INSERT INTO Customers (id, ename, age, eaddress, salary) VALUES
(1, 'Ramesh', 32 , 'Ahmedabad' , 2000),
(2, 'Khilan', 25 , 'Delhi' , 1500),
(3, 'Kaushik', 23 , 'Kolkata' , 2000),
(4, 'Chaitali', 25 , 'Mumbai' , 6500),
(5, 'Hardik', 27 , 'Bhopal' , 8500),
(6, 'Komal', 22 , 'MP' , 4500),
(7, 'Muffy', 24 , 'Indore' , 10000);

SELECT ename
FROM Customers
WHERE eaddress LIKE '%o%';

CREATE TABLE Orders (
    oid INT ,
    odate DATE,
    cust_id INT,
    amount DECIMAL(10, 2)
);

INSERT INTO Orders(oid, odate, cust_id, amount ) VALUES
(102, '2009-10-08' , 3 , 3000 ),
(100, '2009-10-08' , 3 , 1500 ),
(101, '2009-11-20' , 2 , 1560 ),
(103, '2008-05-20' , 4 , 2000 );


SELECT odate, COUNT(DISTINCT cust_id) AS total_customers
FROM Orders
GROUP BY odate;

CREATE TABLE Workers (
    id INT PRIMARY KEY,
    ename NVARCHAR(100),
    age INT,
    eaddress NVARCHAR(255),
    salary DECIMAL(10, 2)
);

INSERT INTO Workers(id, ename, age, eaddress, salary) VALUES
(1, 'Ramesh', 32 , 'Ahmedabad' , 2000),
(2, 'Khilan', 25 , 'Delhi' , 1500),
(3, 'Kaushik', 23 , 'Kolkata' , 2000),
(4, 'Chaitali', 25 , 'Mumbai' , 6500),
(5, 'Hardik', 27 , 'Bhopal' , 8500),
(6, 'Komal', 22 , 'MP' , NULL),
(7, 'Muffy', 24 , 'Indore' , NULL);

SELECT ename AS employee_name
FROM Workers
WHERE salary IS NULL;

CREATE TABLE Studentdetails (
    registerno INT ,
    sname NVARCHAR(100),
    age INT,
	qualification NVARCHAR(100),
    mobileno BIGINT,
    email NVARCHAR(100),
    loc NVARCHAR(100),
	gender NVARCHAR(2)
);

INSERT INTO Studentdetails VALUES 
(2, 'Sai', 22, 'BE', 9952836777, 'Sai@gmail.com', 'Chennai', 'M'),
(3, 'Kumar', 20, 'BSC', 9952836777, 'Kumar@gmail.com', 'Madurai', 'M'),
(4, 'Selvi', 22, 'BTECH', 9952836777, 'Selvi@gmail.com', 'Selam', 'F'),
(5, 'Nisha', 25, 'ME', 9952836777, 'Nisha@gmail.com', 'Theni', 'F'),
(6, 'SaiSaran', 23, 'BA', 9952836777, 'SaiSaran@gmail.com', 'Madurai', 'F'),
(7, 'Tom', 21, 'BCA', 9952836777, 'Tom@gmail.com', 'Pune', 'M');

SELECT gender, COUNT(*) AS total_count
FROM Studentdetails
GROUP BY gender;