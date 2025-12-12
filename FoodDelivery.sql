CREATE DATABASE FoodDeliveryDB;
GO

USE FoodDeliveryDB;
GO

CREATE TABLE Restaurants (
    RestaurantID INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Phone VARCHAR(20),
    Status BIT DEFAULT 1,   -- 1 = active
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Menus (
    MenuID INT IDENTITY PRIMARY KEY,
    RestaurantID INT NOT NULL,
    ItemName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(500),
    Price DECIMAL(10,2) NOT NULL,
    IsAvailable BIT DEFAULT 1,

    FOREIGN KEY (RestaurantID) REFERENCES Restaurants(RestaurantID)
);

CREATE TABLE Customers (
    CustomerID INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(255),
    Phone VARCHAR(20),
    Address NVARCHAR(255)
);

CREATE TABLE Orders (
    OrderID INT IDENTITY PRIMARY KEY,
    CustomerID INT NOT NULL,
    RestaurantID INT NOT NULL,
    OrderTime DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2),
    PaymentMethod VARCHAR(20),  -- COD / Online
    Status VARCHAR(50),         -- pending, confirmed, delivering, completed, cancelled

    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (RestaurantID) REFERENCES Restaurants(RestaurantID)
);

CREATE TABLE Order_Items (
    OrderItemID INT IDENTITY PRIMARY KEY,
    OrderID INT NOT NULL,
    MenuID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2),

    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (MenuID) REFERENCES Menus(MenuID)
);

CREATE TABLE Shippers (
    ShipperID INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(255),
    Phone VARCHAR(20),
    VehicleNumber VARCHAR(20),
    Status VARCHAR(50)  -- available / busy / inactive
);

CREATE TABLE Deliveries (
    DeliveryID INT IDENTITY PRIMARY KEY,
    OrderID INT NOT NULL,
    ShipperID INT NOT NULL,
    AssignedAt DATETIME DEFAULT GETDATE(),
    PickupTime DATETIME,
    DeliveredTime DATETIME,
    Status VARCHAR(50),   -- assigned / picked / delivering / done

    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ShipperID) REFERENCES Shippers(ShipperID)
);

CREATE TABLE Delivery_Tracking (
    TrackingID INT IDENTITY PRIMARY KEY,
    DeliveryID INT NOT NULL,
    Latitude DECIMAL(10,6),
    Longitude DECIMAL(10,6),
    LoggedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (DeliveryID) REFERENCES Deliveries(DeliveryID)
);

CREATE TABLE Invoices (
    InvoiceID INT IDENTITY PRIMARY KEY,
    OrderID INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    PaymentStatus VARCHAR(50),  -- paid / unpaid
    PaymentTime DATETIME,

    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

CREATE TABLE Order_Status_Log (
    LogID INT IDENTITY PRIMARY KEY,
    OrderID INT NOT NULL,
    Status VARCHAR(50) NOT NULL,
    UpdatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);
