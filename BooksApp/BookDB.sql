USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'BooksDB')
BEGIN
    ALTER DATABASE BooksDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE BooksDB;
END
GO

-- Create the database
CREATE DATABASE BooksDB;
GO

-- Use the created database
USE BooksDB;
GO

-- Create Author table
CREATE TABLE Author (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Surname NVARCHAR(255) NOT NULL
);
GO

-- Create Genre table
CREATE TABLE Genre (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL
);
GO

-- Create Role table
CREATE TABLE Role (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL
);
GO

-- Create User table
CREATE TABLE [User] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    RoleId INT NOT NULL,
    CONSTRAINT FK_User_Role FOREIGN KEY (RoleId) REFERENCES Role(Id)
);
GO

-- Create Book table
CREATE TABLE Book (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    NumberOfPages SMALLINT NULL,
    PublishDate DATETIME NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    IsTopSeller BIT NOT NULL DEFAULT 0,
    AuthorId INT NOT NULL,
    CONSTRAINT FK_Book_Author FOREIGN KEY (AuthorId) REFERENCES Author(Id)
);
GO

-- Create BookGenre table
CREATE TABLE BookGenre (
    Id INT PRIMARY KEY IDENTITY(1,1),
    BookId INT NOT NULL,
    GenreId INT NOT NULL,
    CONSTRAINT FK_BookGenre_Book FOREIGN KEY (BookId) REFERENCES Book(Id) ON DELETE CASCADE,
    CONSTRAINT FK_BookGenre_Genre FOREIGN KEY (GenreId) REFERENCES Genre(Id)
);
