

CREATE DATABASE FoodDelivery;
GO

USE FoodDelivery;
GO

-- ===============================
-- 1. Bảng LoaiTaiKhoan (CHA)
-- ===============================
CREATE TABLE LoaiTaiKhoan (
    IdLoaiTaiKhoan INT IDENTITY(1,1) PRIMARY KEY,
    TenLoaiTaiKhoan NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255),
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

-- ===============================
-- 2. Bảng UserInfo
-- ===============================
CREATE TABLE UserInfo (
    IdUser INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(20),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(255),
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

-- ===============================
-- 3. Bảng Restaurant
-- ===============================
CREATE TABLE Restaurant (
    IdRestaurant INT IDENTITY(1,1) PRIMARY KEY,
    TenRestaurant NVARCHAR(150) NOT NULL,
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(20),
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

-- ===============================
-- 4. Bảng Shipper
-- ===============================
CREATE TABLE Shipper (
    IdShipper INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(20),
    BienSoXe NVARCHAR(20),
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

-- ===============================
-- 5. Bảng MenuItem
-- ===============================
CREATE TABLE MenuItem (
    IdMenuItem INT IDENTITY(1,1) PRIMARY KEY,
    IdRestaurant INT NOT NULL,
    TenMon NVARCHAR(150) NOT NULL,
    Gia DECIMAL(18,2) NOT NULL,
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_MenuItem_Restaurant
        FOREIGN KEY (IdRestaurant)
        REFERENCES Restaurant(IdRestaurant)
);
GO

-- ===============================
-- 6. Bảng TaiKhoan
-- ===============================
CREATE TABLE TaiKhoan (
    IdTaiKhoan INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(100) NOT NULL UNIQUE,
    MatKhau NVARCHAR(255) NOT NULL,
    IdLoaiTaiKhoan INT NOT NULL,
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_TaiKhoan_LoaiTaiKhoan
        FOREIGN KEY (IdLoaiTaiKhoan)
        REFERENCES LoaiTaiKhoan(IdLoaiTaiKhoan)
);
GO

-- ===============================
-- 7. Bảng Orders
-- ===============================
CREATE TABLE Orders (
    IdOrder INT IDENTITY(1,1) PRIMARY KEY,
    IdUser INT NOT NULL,
    IdRestaurant INT NOT NULL,
    TongTien DECIMAL(18,2) NOT NULL,
    PhiVanChuyen DECIMAL(18,2),
    TrangThai NVARCHAR(50),
    DiaChiGiao NVARCHAR(255),
    NgayDat DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Orders_User
        FOREIGN KEY (IdUser)
        REFERENCES UserInfo(IdUser),
    CONSTRAINT FK_Orders_Restaurant
        FOREIGN KEY (IdRestaurant)
        REFERENCES Restaurant(IdRestaurant)
);
GO

-- ===============================
-- 8. Bảng OrderItems
-- ===============================
CREATE TABLE OrderItems (
    IdOrderItem INT IDENTITY(1,1) PRIMARY KEY,
    IdOrder INT NOT NULL,
    IdMenuItem INT NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    ThanhTien DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_OrderItems_Order
        FOREIGN KEY (IdOrder)
        REFERENCES Orders(IdOrder),
    CONSTRAINT FK_OrderItems_MenuItem
        FOREIGN KEY (IdMenuItem)
        REFERENCES MenuItem(IdMenuItem)
);
GO

-- ===============================
-- 9. Bảng Deliveries
-- ===============================
CREATE TABLE Deliveries (
    IdDelivery INT IDENTITY(1,1) PRIMARY KEY,
    IdOrder INT NOT NULL,
    IdShipper INT NOT NULL,
    ThoiGianNhanHang DATETIME,
    ThoiGianDuKien DATETIME,
    TrangThai NVARCHAR(50),
    CONSTRAINT FK_Deliveries_Order
        FOREIGN KEY (IdOrder)
        REFERENCES Orders(IdOrder),
    CONSTRAINT FK_Deliveries_Shipper
        FOREIGN KEY (IdShipper)
        REFERENCES Shipper(IdShipper)
);
GO

-- ===============================
-- 10. Bảng Invoices
-- ===============================
CREATE TABLE Invoices (
    IdInvoice INT IDENTITY(1,1) PRIMARY KEY,
    IdOrder INT NOT NULL,
    SoTien DECIMAL(18,2) NOT NULL,
    PhuongThucThanhToan NVARCHAR(50),
    TrangThai BIT DEFAULT 1,
    NgayThanhToan DATETIME,
    CONSTRAINT FK_Invoices_Order
        FOREIGN KEY (IdOrder)
        REFERENCES Orders(IdOrder)
);
GO
INSERT INTO Shipper (HoTen, SoDienThoai, BienSoXe, TrangThai)
VALUES 
('Nguyen Van A', '0901234567', '29A-12345', 1),
('Tran Thi B', '0912345678', '30B-54321', 1),
('Le Van C', '0923456789', '31C-67890', 1),
('Pham Thi D', '0934567890', '32D-98765', 1),
('Hoang Van E', '0945678901', '33E-11223', 1);
