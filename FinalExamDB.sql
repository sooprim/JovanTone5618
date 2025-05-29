IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'FinalExamDB')
BEGIN
    CREATE DATABASE FinalExamDB;
END
GO

USE FinalExamDB;
GO


IF OBJECT_ID('dbo.Clients', 'U') IS NOT NULL
    DROP TABLE dbo.Clients;
IF OBJECT_ID('dbo.Books', 'U') IS NOT NULL
    DROP TABLE dbo.Books;
GO

CREATE TABLE Books (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IBAN NVARCHAR(50) NOT NULL,
    Name NVARCHAR(200) NOT NULL,
    Author NVARCHAR(200) NOT NULL,
    Publisher NVARCHAR(200) NOT NULL,
    Year INT NOT NULL,
    NumberOfCopies INT NOT NULL
);
GO

CREATE TABLE Clients (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(200) NOT NULL,
    DateOfBirth DATETIME NOT NULL,
    Address NVARCHAR(400) NOT NULL,
    MembershipCardNumber NVARCHAR(50) NOT NULL,
    MembershipCardValidityDate DATETIME NOT NULL,
    LoanDate DATETIME NULL,
    ReturnDate DATETIME NULL,
    BookId INT NULL,
    CONSTRAINT FK_Clients_Books FOREIGN KEY (BookId) REFERENCES Books(Id)
);
GO

INSERT INTO Books (IBAN, Name, Author, Publisher, Year, NumberOfCopies) VALUES
('978-0-7475-3269-9', 'The Great Gatsby', 'F. Scott Fitzgerald', 'Scribner', 1925, 5),
('978-0-7475-3849-3', 'To Kill a Mockingbird', 'Harper Lee', 'J. B. Lippincott & Co.', 1960, 3),
('978-0-439-55499-5', 'The Hobbit', 'J.R.R. Tolkien', 'Allen & Unwin', 1937, 4),
('978-0-618-57498-4', 'The Lord of the Rings', 'J.R.R. Tolkien', 'Allen & Unwin', 1954, 2),
('978-0-553-10354-8', '1984', 'George Orwell', 'Penguin Books', 1949, 3);
GO

INSERT INTO Clients (
    FirstName, 
    LastName, 
    DateOfBirth, 
    Address, 
    MembershipCardNumber, 
    MembershipCardValidityDate, 
    LoanDate, 
    ReturnDate, 
    BookId
) VALUES
(
    'Jovan',
    'Tone',
    '2004-04-28',
    'Street 21, Temecula',
    'MC001',
    '2024-12-31',
    '2024-01-15',
    '2024-02-15',
    1
),
(
    'Vangel',
    'Tone',
    '2000-10-16',
    'Street 21, Temecula',
    'MC002',
    '2024-12-31',
    '2024-01-20',
    '2024-02-20',
    2
),
(
    'Nikola',
    'Macovski',
    '2002-09-02',
    'Ulica 17, Skopje',
    'MC003',
    '2024-12-31',
    '2024-01-20',
    '2024-02-20',
    3
),
(
    'Hristo',
    'Macovski',
    '2004-04-10',
    'Ulica 17, Skopje',
    'MC004',
    '2024-12-31',
    '2024-01-25',
    '2024-02-25',
    4
);
GO 