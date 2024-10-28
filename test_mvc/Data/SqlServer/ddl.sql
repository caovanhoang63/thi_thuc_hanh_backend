DROP TABLE Categories;
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),  
    Name NVARCHAR(100) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME NULL,
    Status INT NOT NULL DEFAULT 1,
);

DROP TABLE Products;
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),   
    Name NVARCHAR(100) NOT NULL,        
    Price DECIMAL(18, 2) NOT NULL,
    Image VARCHAR(255),
    Description NVARCHAR(MAX),          
    CategoryId INT NOT NULL,            
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    Status INT NOT NULL DEFAULT 1,     
);

DROP TABLE Users;
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL, 
    UserName NVARCHAR(255) NOT NULL UNIQUE ,
    UserRole INT DEFAULT 0,
    Password NVARCHAR(255) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    Status INT NOT NULL DEFAULT 1
)

SELECT * FROM Products;

Insert INTO Products(name, price, image, description, categoryid) 
VALUES ('Thịt bò',1220000,'images.jpeg','Thịt bò thượng hạn',0),
('Thịt gà', 85000, 'images.jpeg', 'Thịt gà ta tươi ngon', 0),
('Thịt heo', 95000, 'images.jpeg', 'Thịt heo sạch từ trang trại', 0),
('Thịt vịt', 70000, 'images.jpeg', 'Thịt vịt đồng', 0),
('Thịt cừu', 150000, 'images.jpeg', 'Thịt cừu Úc chất lượng cao', 0),
('Thịt ngỗng', 135000, 'images.jpeg', 'Thịt ngỗng tươi, giàu dinh dưỡng', 0);