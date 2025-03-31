USE [EMSDB]
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

INSERT INTO Users
    (Username, Password, EMAIL, Role, IsDeleted)
VALUES
    ('admin', 'admin', 'admin@example.com', 1, 0),
    ('hr', 'hr', 'hr@example.com', 2,0),
    ('employee', 'employee', 'employee@example.com', 3, 0),
    ('account', 'account', 'account@example.com', 4,0),
    ('guest', 'guest', 'accguestount@example.com', 5,0);

SELECT *
FROM Users;


INSERT INTO Departments
    (DepartmentName, Description)
VALUES
    ('Communication', 'Communication Department'),
    ('IT', 'Information Technology Department'),
    ('Finance', 'Finance Department');

SELECT *
FROM Departments;

GO


