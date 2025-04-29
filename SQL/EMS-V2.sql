-- Step 1: Create Database if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'EMSDB')
BEGIN
    CREATE DATABASE EMSDB;
END
GO

-- Use the newly created database
USE EMSDB;
GO

-- Step 2: Create Tables in the correct order

-- Create Roles table
IF OBJECT_ID('Roles', 'U') IS NULL
BEGIN
    CREATE TABLE Roles (
        RoleID INT PRIMARY KEY IDENTITY(1,1),
        RoleName VARCHAR(20) NOT NULL UNIQUE,
        Description VARCHAR(255),
        Permission VARCHAR(255) NOT NULL
    );
END
GO

-- Create Users table
IF OBJECT_ID('Users', 'U') IS NULL
BEGIN
    CREATE TABLE Users (
        UserID INT PRIMARY KEY IDENTITY(1,1),
        Username VARCHAR(60) NOT NULL,
        Password VARCHAR(255) NOT NULL, 
        Email VARCHAR(100) NOT NULL UNIQUE,
        Role INT, -- Renamed for consistency
        CreatedAt DATETIME DEFAULT GETDATE(),
        IsDeleted BIT DEFAULT 0,
        FOREIGN KEY (Role) REFERENCES Roles(RoleID)
    );
END
GO

-- Create Departments table (before Employees to avoid FK error)
IF OBJECT_ID('Departments', 'U') IS NULL
BEGIN
    CREATE TABLE Departments (
        DepartmentID INT PRIMARY KEY IDENTITY(1,1),
        DepartmentName VARCHAR(50) NOT NULL UNIQUE,
        Description TEXT,
        IsDeleted BIT DEFAULT 0,
        ManagerID INT NULL -- FK added later after Employees table is created
    );
END
GO

-- Create Employees table (after Departments)
IF OBJECT_ID('Employees', 'U') IS NULL
BEGIN
    CREATE TABLE Employees (
        EmployeeID INT PRIMARY KEY IDENTITY(1,1),
        FirstName VARCHAR(50) NOT NULL,
        LastName VARCHAR(50) NOT NULL,
        Email VARCHAR(100) NOT NULL UNIQUE,
        DateOfBirth DATE NULL,
        DepartmentID INT NULL,
        EmploymentDate DATE NULL,
        UserID INT NULL,
        SalaryBeforeTax DECIMAL(10, 2) NULL,
        TaxAmount DECIMAL(10, 2) NULL,
        SalaryAfterTax AS (SalaryBeforeTax - TaxAmount) PERSISTED, 
        IsDeleted BIT DEFAULT 0,
        FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
    );
END
GO

-- Create Attendance table
IF OBJECT_ID('Attendance', 'U') IS NULL
BEGIN
    CREATE TABLE Attendance (
        AttendanceID INT PRIMARY KEY IDENTITY(1,1), -- Fixed AUTO_INCREMENT
        EmployeeID INT NOT NULL,
        CheckIn DATETIME DEFAULT GETDATE(),
        CheckOut DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE
    );
END
GO

-- Step 3: Add foreign key constraint for ManagerID in Departments table (now Employees exists)
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
    WHERE CONSTRAINT_TYPE = 'FOREIGN KEY' AND TABLE_NAME = 'Departments' AND CONSTRAINT_NAME = 'FK_Departments_Employees'
)
BEGIN
    ALTER TABLE Departments 
    ADD CONSTRAINT FK_Departments_Employees FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID);
END
GO

-- DBCC CHECKIDENT('Roles', RESEED, 0);
-- DBCC CHECKIDENT('Users', RESEED, 0);
-- DBCC CHECKIDENT('Departments', RESEED, 0);
-- DBCC CHECKIDENT('Employees', RESEED, 0);
-- DBCC CHECKIDENT('Attendance', RESEED, 0);

-- GO

INSERT INTO Roles 
(RoleName, Description, Permission) VALUES 
    ('Admin', 'Administrator with full access', 'ALL'),
    ('HR', 'HR with managerial access', 'HR'),
    ('Employee', 'Regular Employee', 'EMPLOYEE'),
    ('Account', 'Accounting', 'ACCOUNTANT'),
    ('Guest', 'Guest', 'NONE');

-- Verify inserted roles
SELECT * FROM Roles;