-- DROP TABLES IF THEY EXIST TO START FRESH
DROP TABLE IF EXISTS OrderItems;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS ProductStocks;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Vehicles;
DROP TABLE IF EXISTS Clients;

-- CREATE TABLE: Clients
CREATE TABLE Clients (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Address VARCHAR(255) NOT NULL,
    Region VARCHAR(100) NOT NULL
);

-- CREATE TABLE: Vehicles
CREATE TABLE Vehicles (
    Id SERIAL PRIMARY KEY,
    Type VARCHAR(255) NOT NULL,
    Capacity DECIMAL(10, 2) NOT NULL,
    UsedCapacity DECIMAL(10, 2) NOT NULL,
    NotUsedCapacity DECIMAL(10, 2) NOT NULL,
    IsAvailable BOOLEAN DEFAULT TRUE,
    CHECK (UsedCapacity < Capacity OR IsAvailable = FALSE)
);

-- CREATE TABLE: Products
CREATE TABLE Products (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Volume DECIMAL(10, 2) NOT NULL
);

-- CREATE TABLE: ProductStocks
CREATE TABLE ProductStocks (
    Id SERIAL PRIMARY KEY,
    QuantityOnHand INT NOT NULL,
    QuantitySold INT NOT NULL,
    QuantityReserved INT NOT NULL,
    ProductId INT REFERENCES Products(Id)
);

-- CREATE TABLE: Orders
CREATE TABLE Orders (
    Id SERIAL PRIMARY KEY,
    ClientId INT REFERENCES Clients(Id),
    VehicleId INT REFERENCES Vehicles(Id),
    TotalVolume DECIMAL(10, 2) NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    OrderDate DATE NOT NULL,
    DeliveryDate DATE NOT NULL,
    Status VARCHAR(50) NOT NULL
);

-- CREATE TABLE: OrderItems
CREATE TABLE OrderItems (
    Id SERIAL PRIMARY KEY,
    OrderId INT REFERENCES Orders(Id),
    ProductId INT REFERENCES Products(Id),
    Quantity INT NOT NULL
);

-- INSERT SAMPLE DATA INTO Clients
INSERT INTO Clients (Name, Address, Region) VALUES
    ('John Doe', '1234 Elm Street', 'North'),
    ('Jane Smith', '4321 Oak Avenue', 'South'),
    ('Acme Corp', '100 Industrial Blvd', 'West'),
    ('Bob Johnson', '5678 Pine Road', 'East'),
    ('Alice Brown', '8765 Maple Lane', 'North'),
    ('Charlie Davis', '3456 Cedar Street', 'South'),
    ('Diana Evans', '6543 Birch Avenue', 'West'),
    ('Edward Harris', '7890 Spruce Blvd', 'East'),
    ('Fiona Clark', '2345 Willow Drive', 'North'),
    ('George Lewis', '5432 Aspen Court', 'South'),
    ('Hannah Walker', '6789 Oak Street', 'West'),
    ('Ian Young', '1234 Pine Avenue', 'East'),
    ('Jackie King', '4321 Elm Road', 'North'),
    ('Kevin Wright', '8765 Maple Street', 'South'),
    ('Laura Scott', '3456 Cedar Lane', 'West');

-- INSERT SAMPLE DATA INTO Products
INSERT INTO Products (Name, Price, Weight) VALUES
   ('Coca-Cola 12oz', 1.50, 0.35),
   ('Pepsi 12oz', 1.50, 0.35),
   ('Sprite 12oz', 1.50, 0.35),
   ('Fanta Orange 12oz', 1.50, 0.35),
   ('Mountain Dew 12oz', 1.50, 0.35),
   ('Dr Pepper 12oz', 1.50, 0.35),
   ('7 Up 12oz', 1.50, 0.35),
   ('Gatorade 20oz', 2.00, 0.60),
   ('Red Bull 8.4oz', 2.50, 0.24),
   ('Monster Energy 16oz', 2.50, 0.48),
   ('Lipton Iced Tea 16oz', 1.75, 0.50),
   ('Arizona Green Tea 16oz', 1.00, 0.50),
   ('Snapple Apple 16oz', 1.75, 0.50),
   ('Vitamin Water 20oz', 2.00, 0.60),
   ('Powerade 20oz', 2.00, 0.60);

-- INSERT SAMPLE DATA INTO ProductStocks
INSERT INTO ProductStocks (QuantityOnHand, QuantitySold, QuantityReserved, ProductId) VALUES
  (1000, 200, 50, 1),
  (1200, 250, 60, 2),
  (1100, 220, 55, 3),
  (900, 180, 45, 4),
  (950, 190, 47, 5),
  (800, 160, 40, 6),
  (850, 170, 42, 7),
  (700, 140, 35, 8),
  (600, 120, 30, 9),
  (650, 130, 32, 10),
  (750, 150, 37, 11),
  (800, 160, 40, 12),
  (850, 170, 42, 13),
  (900, 180, 45, 14),
  (950, 190, 47, 15);
