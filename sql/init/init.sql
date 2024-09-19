-- DROP TABLES IF THEY EXIST TO START FRESH
DROP TABLE IF EXISTS order_items;
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS product_stocks;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS vehicles;
DROP TABLE IF EXISTS clients;

-- CREATE TABLE: Clients
CREATE TABLE clients (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    address VARCHAR(255) NOT NULL,
    region VARCHAR(100) NOT NULL
);

-- CREATE TABLE: Vehicles
CREATE TABLE vehicles (
    id SERIAL PRIMARY KEY,
    type VARCHAR(255) NOT NULL,
    capacity DECIMAL(10, 2) NOT NULL,
    is_available BOOLEAN DEFAULT TRUE
);

-- CREATE TABLE: Products
CREATE TABLE products (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    weight DECIMAL(10, 2) NOT NULL
);

-- CREATE TABLE: ProductStocks
CREATE TABLE product_stocks (
    id SERIAL PRIMARY KEY,
    quantity_on_hand INT NOT NULL,
    quantity_sold INT NOT NULL,
    quantity_reserved INT NOT NULL,
    product_id INT REFERENCES products(id)
);

-- CREATE TABLE: Orders
CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    client_id INT REFERENCES clients(id),
    vehicle_id INT REFERENCES vehicles(id),
    total_volume DECIMAL(10, 2) NOT NULL,
    order_date DATE NOT NULL,
    delivery_date DATE NOT NULL,
    status VARCHAR(50) NOT NULL
);

-- CREATE TABLE: OrderItems
CREATE TABLE order_items (
    id SERIAL PRIMARY KEY,
    order_id INT REFERENCES orders(id),
    product_id INT REFERENCES products(id),
    quantity INT NOT NULL,
    unit_price DECIMAL(10, 2) NOT NULL
);

-- INSERT SAMPLE DATA INTO Clients
INSERT INTO clients (name, address, region) VALUES
    ('John Doe', '1234 Elm Street', 'North'),
    ('Jane Smith', '4321 Oak Avenue', 'South'),
    ('Acme Corp', '100 Industrial Blvd', 'West');

-- INSERT SAMPLE DATA INTO Vehicles
INSERT INTO vehicles (type, capacity, is_available) VALUES
    ('truck', 5000.00, TRUE),
    ('van', 3000.00, FALSE),
    ('van', 2000.00, TRUE);

-- INSERT SAMPLE DATA INTO Products
INSERT INTO products (name, price, weight) VALUES
   ('Product A', 10.00, 2.50),
   ('Product B', 15.00, 1.75),
   ('Product C', 5.50, 0.50);

-- INSERT SAMPLE DATA INTO ProductStocks
INSERT INTO product_stocks (quantity_on_hand, quantity_sold, quantity_reserved, product_id) VALUES
    (100, 20, 10, 1),
    (150, 30, 5, 2),
    (50, 5, 2, 3);

-- INSERT SAMPLE DATA INTO Orders
INSERT INTO orders (client_id, vehicle_id, total_volume, order_date, delivery_date, status) VALUES
    (1, 1, 250.00, '2023-09-15', '2023-09-20', 'pending'),
    (2, 2, 150.00, '2023-09-16', '2023-09-21', 'completed'),
    (3, 3, 50.00, '2023-09-17', '2023-09-22', 'shipped');

-- INSERT SAMPLE DATA INTO OrderItems
INSERT INTO order_items (order_id, product_id, quantity, unit_price) VALUES
    (1, 1, 10, 10.00),
    (1, 2, 5, 15.00),
    (2, 3, 20, 5.50),
    (3, 1, 2, 10.00);
