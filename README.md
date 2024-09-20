# AFKs Team
- Isaias Rojas Condarco
- Diego Michel Roca
- Santiago Quiroga Salazar

## Project Overview
The Project is an API-driven solution designed to streamline the operations of a beverage distribution company. It manages inventory, processes customer orders, and handles delivery logistics using a fleet of trucks and vans. The system ensures efficient order handling, vehicle allocation, and real-time status updates for customers.

## Features
- **Order Management**
  - Customers can place orders for multiple beverages.
  - Track the status of each order in real time.
  - Reject orders if insufficient vehicle capacity is available.
- **Vehicle Management**
  - Manage a fleet of trucks and vans with varying capacities.
  - Allocate vehicles based on order size and availability.
  - Ensure each order is delivered by a single vehicle.
- **Inventory Management**
  - Maintain up-to-date records of beverage stock in the warehouse.
- **User Notifications**
  - Inform customers about the status of their orders.
- **Data Persistence**
  - Store all relevant information in a reliable database.
- **Continuous Integration**
  - Automated builds and tests to ensure code quality.
- **Unit Testing**
  - Comprehensive tests with over 80% code coverage.

## Technologies Used
- **Backend Framework:** [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet)
- **Data Access:** [Dapper](https://www.learndapper.com/)
- **Database:** PostgreSQL.
- **Version Control:** Git.
- **Continuous Integration:** GitHub Actions.
- **Testing Framework:** xUnit.

## Architecture
- **API Layer:** Handles HTTP requests and responses.
- **Core Layer:** Contains business logic for order and vehicle management.
- **Infrastructure Layer:** Interacts with the database using Dapper.
- **Database:** Stores all persistent data including orders, vehicles, and inventory.

## Installation

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) installed
- PostgreSQL
- Docker
- Git

### Steps
- **Clone the Repository**
   ```bash
   git clone https://github.com/Programming6-projects/AFKs.git
   ```
- **Clean Docker (If Necessary)**
    ```bash
    docker container ls -a 
    docker container rm <container id>
    docker image ls -a
    docker image rm <image id>
    docker volume ls
    docker volume rm <volume id>
    ```
- **Run Database Migrations**
   ```bash
   docker compose up
   ```
- **Start the Application**
   ```bash
   dotnet run --project Pepsi.API
   ```
   
## API Documentation

## Base URL
```
http://localhost:5225/swagger/index.html
```

## Endpoints

### Orders
- **POST** 
    - **Request Body:**
    ```json
    {
      "clientId": 0,
      "client": {
        "name": "string",
        "address": "string",
        "region": "string"
      },
      "vehicleId": 0,
      "vehicle": {
        "type": "string",
        "capacity": 0,
        "isAvailable": true
      },
      "items": [
        {
          "orderId": 0,
          "productId": 0,
          "product": {
            "name": "string",
            "price": 0,
            "weight": 0
          },
          "quantity": 0,
          "unitPrice": 0
        }
      ],
      "totalVolume": 0,
      "orderDate": "2024-09-19T23:19:04.463Z",
      "deliveryDate": "2024-09-19T23:19:04.463Z",
      "status": 0
    }
    ```
  - **Responses:**
    - `201 Created` – Order successfully created.
    - `400 Bad Request` – Invalid input.
    - `409 Conflict` – No available vehicles.
- **GET** 
    - **Responses:**
        - `200 OK` – Returns order status.
        - `404 Not Found` – Order does not exist.
        - `500 internal Server Error` 

### Clients
- **POST** 
    - **Request Body:**
    
    ```json
    {
      "name": "string",
      "address": "string",
      "region": "string"
    }
    ```
    - **Responses:**
        - `201 Created` – Order successfully created.
        - `400 Bad Request` – Invalid input.
        - `409 Conflict` – No available vehicles.
- **GET** 
    - **Responses:**
        - `200 OK` – List of available vehicles.

## Additional Endpoints
- **Order Per Client ID**

## Database
- **Entities:**
  - **Clients:** Stores customer information.
  - **Orders:** Stores order details.
  - **OrderItem:** Stores products within an order.
  - **Vehicles:** Stores vehicle details and availability.
  - **Products:** Stores product information.
  - **ProductStocks:** Tracks stock levels.
- **Initialization:**
  - On application start, the system reads the vehicle data file `.json` to populate the `Vehicles` table for the day (if it was already loaded, then it does nothing).

## Testing
- **Running Tests:**
  ```bash
  dotnet test
  dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:Threshold=80
  ```

## Continuous Integration
- **Setup:**
  - CI is configured using GitHub Actions.
- **Pipeline Steps:**
  - Restore dependencies
  - Check code.
  - Run tests.
  - Build the application.

## Design Principles & Patterns
- **SOLID Principles**: Ensures maintainable and scalable code by following:
  - **Single Responsibility Principle (SRP)**
  - **Open/Closed Principle (OCP)**
  - **Liskov Substitution Principle (LSP)**
  - **Interface Segregation Principle (ISP)**
  - **Dependency Inversion Principle (DIP)**
- **KISS (Keep It Simple, Stupid)**: Encourages simplicity in design to avoid unnecessary complexity.
- **DRY (Don’t Repeat Yourself)**: Avoids code duplication by centralizing logic to make the system easier to maintain and extend.
- **YAGNI (You Ain’t Gonna Need It)**: Prevents overengineering by focusing only on current requirements instead of future speculation.
- **Repository Pattern**: Abstracts data access logic, providing a clean separation between business logic and data layer, making the system easier to maintain and test.
- **Factory Pattern**: Provides a way to create objects without specifying the exact class of object that will be created, promoting flexibility and decoupling.
- **Dependency Injection**: Facilitates testing and loose coupling by injecting dependencies into components rather than creating them inside, improving flexibility and code reusability.
- **Singleton Pattern**: Ensures a class has only one instance, useful for managing shared resources or global configurations.
