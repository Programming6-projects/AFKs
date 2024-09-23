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
    IsAvailable BOOLEAN DEFAULT TRUE
);

-- CREATE TABLE: Products
CREATE TABLE Products (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Weight DECIMAL(10, 2) NOT NULL
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
    OrderDate DATE NOT NULL,
    DeliveryDate DATE NOT NULL,
    Status VARCHAR(50) NOT NULL
);

-- CREATE TABLE: OrderItems
CREATE TABLE OrderItems (
    Id SERIAL PRIMARY KEY,
    OrderId INT REFERENCES Orders(Id),
    ProductId INT REFERENCES Products(Id),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL
);

-- INSERT SAMPLE DATA INTO Clients
INSERT INTO Clients (Name, Address, Region) VALUES
    ('John Doe', '1234 Elm Street', 'North'),
    ('Jane Smith', '4321 Oak Avenue', 'South'),
    ('Acme Corp', '100 Industrial Blvd', 'West');

-- INSERT SAMPLE DATA INTO Vehicles
INSERT INTO Vehicles (Type, Capacity, IsAvailable) VALUES
    ('truck', 5000.00, TRUE),
    ('van', 3000.00, FALSE),
    ('van', 2000.00, TRUE);

-- INSERT SAMPLE DATA INTO Products
INSERT INTO Products (Name, Price, Weight) VALUES
   ('Product A', 10.00, 2.50),
   ('Product B', 15.00, 1.75),
   ('Product C', 5.50, 0.50);

-- INSERT SAMPLE DATA INTO ProductStocks
INSERT INTO ProductStocks (QuantityOnHand, QuantitySold, QuantityReserved, ProductId) VALUES
    (100, 20, 10, 1),
    (150, 30, 5, 2),
    (50, 5, 2, 3);

-- INSERT SAMPLE DATA INTO Orders
INSERT INTO Orders (ClientId, VehicleId, TotalVolume, OrderDate, DeliveryDate, Status) VALUES
    (1, 1, 250.00, '2023-09-15', '2023-09-20', 'pending'),
    (2, 2, 150.00, '2023-09-16', '2023-09-21', 'completed'),
    (3, 3, 50.00, '2023-09-17', '2023-09-22', 'shipped');

-- INSERT SAMPLE DATA INTO OrderItems
INSERT INTO OrderItems (OrderId, ProductId, Quantity, UnitPrice) VALUES
    (1, 1, 10, 10.00),
    (1, 2, 5, 15.00),
    (2, 3, 20, 5.50),
    (3, 1, 2, 10.00);
