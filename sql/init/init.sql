DROP TABLE IF EXISTS OrderItem;
DROP TABLE IF EXISTS Request;
DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS Vehicle;
DROP TABLE IF EXISTS Client;

CREATE TABLE IF NOT EXISTS Client (
    Id INT PRIMARY KEY,
    Name CHAR(50) NOT NULL,
    Address CHAR(150) NOT NULL,
    Region CHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS Vehicle (
    Id INT PRIMARY KEY,
    VehicleType CHAR(50) NOT NULL,
    Capacity DECIMAL(10,2) NOT NULL
);

CREATE TABLE IF NOT EXISTS Product (
    Id INT PRIMARY KEY,
    Name CHAR(50) NOT NULL,
    QuantityOnHand INT NOT NULL,
    QuantitySold INT NOT NULL,
    QuantityReserved INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Volume DECIMAL(10,2) NOT NULL
);

CREATE TABLE IF NOT EXISTS Request (
    Id INT PRIMARY KEY,
    ClientId INT NOT NULL REFERENCES Client(Id) ON DELETE CASCADE,
    VehicleId INT NOT NULL REFERENCES Vehicle(Id) ON DELETE CASCADE,
    TotalVolume NUMERIC NOT NULL,
    OrderDate DATE NOT NULL,
    DeliveryDate DATE NOT NULL,
    Status CHAR(50) NOT NULL CHECK (Status IN ('Pending', 'Accepted', 'Rejected', 'Completed', 'Canceled'))
);

CREATE TABLE IF NOT EXISTS OrderItem (
    OrderItemId INT PRIMARY KEY,
    ProductId INT NOT NULL REFERENCES Product(Id),
    OrderId INT NOT NULL REFERENCES Request(Id),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL
);

INSERT INTO Client (Id, Name, Address, Region)
VALUES
    (1, 'María López', 'Avenida Central 555', 'Guadalajara'),
    (2, 'Pedro Gómez', 'Calle Secundaria 99', 'Monterrey');

INSERT INTO Vehicle (Id, VehicleType, Capacity)
VALUES (1, 'Truck', 10000);

INSERT INTO Product (Id, Name, QuantityOnHand, QuantitySold, QuantityReserved, Price, Volume)
VALUES (1, 'Manzana', 1000, 500, 200, 1.50, 0.2);

INSERT INTO Request (Id, ClientId, VehicleId, TotalVolume, OrderDate, DeliveryDate, Status)
VALUES (1, 1, 1, 5000, '2023-11-22', '2023-11-25', 'Pending');

INSERT INTO OrderItem (OrderItemId, ProductId, OrderId, Quantity, UnitPrice)
VALUES (1, 1, 1, 100, 1.50);


select * from Request;
