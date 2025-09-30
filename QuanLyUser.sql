CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL
);

-- Thêm 1 user test
INSERT INTO Users (Username, Password)
VALUES (N'admin', N'123');

Select * From Users ;