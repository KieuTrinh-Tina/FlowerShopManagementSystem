--Nhân viên
CREATE TABLE users (
    id INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    profile_image VARCHAR(MAX),
    role VARCHAR(100),
    status VARCHAR(100),
    date_signup DATE
);
UPDATE users
SET profile_image = 'C:\Images\default.jpg'
WHERE profile_image IS NULL OR profile_image = '';
SELECT * FROM users;

--Chương trình khuyến mãi
CREATE TABLE promotions
(
id INT PRIMARY KEY IDENTITY(1,1),
promo_id VARCHAR(MAX) NULL,
promo_name VARCHAR (MAX) NULL,
promo_image VARCHAR(MAX) NULL,
giamGia VARCHAR(MAX) NULL,
startDate DATE NULL,
endDate DATE NULL
);
SELECT * FROM promotions

--Khách hàng
CREATE TABLE KhachHang
(
 id INT PRIMARY KEY IDENTITY(1,1),
    KH_Name VARCHAR(255) NOT NULL,
    KH_diaChi VARCHAR(255) NOT NULL,
    KH_image VARCHAR(MAX),
    KH_sdt VARCHAR(100),
    KH_email VARCHAR(100),
);
SELECT*FROM KhachHang;

--Nhà cung cấp
CREATE TABLE suppliers
(
 id INT PRIMARY KEY IDENTITY(1,1),
    NCC_Name VARCHAR(255) NOT NULL,
    NCC_diaChi VARCHAR(255) NOT NULL,
    NCC_image VARCHAR(MAX),
    NCC_sdt VARCHAR(100),
    NCC_email VARCHAR(100),
);
SELECT * FROM suppliers;

-- Sản phẩm
CREATE TABLE SanPham( 
IDSanPham INT PRIMARY KEY IDENTITY (1,1),
TenSP NVARCHAR(100),
LoaiSP NVARCHAR(100),
GiaNhap FLOAT,
GiaBan FLOAT
);
ALTER TABLE SanPham ADD LoaiSP NVARCHAR(100)
--Xóa bảng cũ
DROP TABLE IF EXISTS SanPham;
CREATE TABLE SanPham( 
IDSanPham INT PRIMARY KEY IDENTITY (1,1),
TenSP NVARCHAR(100),
LoaiSP NVARCHAR(100),
GiaNhap FLOAT,
GiaBan FLOAT
);
-- Sp1
INSERT INTO SanPham (TenSP, LoaiSP, GiaNhap, GiaBan)
VALUES (N'Hoa hồng đỏ', N'Hoa tươi', 20000, 30000);
-- Sp 2 
INSERT INTO SanPham (TenSP, LoaiSP, GiaNhap, GiaBan)
VALUES (N'Hoa cúc trắng', N'Hoa tươi', 18000, 27000);
-- Sp 3 
INSERT INTO SanPham (TenSP, LoaiSP, GiaNhap, GiaBan)
VALUES (N'Hoa lan tím', N'Hoa tươi', 35000, 50000);
-- Sp 4 
INSERT INTO SanPham (TenSP, LoaiSP, GiaNhap, GiaBan)
VALUES (N'Hoa baby trắng', N'Hoa phụ kiện', 15000, 22000);
-- Sp 5 
INSERT INTO SanPham (TenSP, LoaiSP, GiaNhap, GiaBan)
VALUES (N'Hoa hướng dương', N'Hoa tươi', 28000, 40000);
SELECT * FROM SanPham;

--Bán hàng 
CREATE TABLE BanHang(
IDBanHang INT PRIMARY KEY IDENTITY(1,1),
IDSanPham INT,
NgayBan DATE,
SoLuong INT,
DonGia FLOAT,
FOREIGN KEY (IDSanPham) REFERENCES SanPham (IDSanPham)
);
--xóa bảng cũ
DROP TABLE IF EXISTS BanHang;
CREATE TABLE BanHang(
IDBanHang INT PRIMARY KEY IDENTITY(1,1),
IDSanPham INT,
NgayBan DATE,
SoLuong INT,
DonGia FLOAT,
FOREIGN KEY (IDSanPham) REFERENCES SanPham (IDSanPham)
);
SELECT * FROM BanHang;

--Tồn kho
CREATE TABLE KhoHang(
IDSanPham INT PRIMARY KEY,
SolUong INT NOT NULL DEFAULT 0,
FOREIGN KEY (IDSanPham) REFERENCES SanPham (IDSanPham)
);
--Xóa bảng cũ 
DROP TABLE IF EXISTS KhoHang;
CREATE TABLE KhoHang(
IDSanPham INT PRIMARY KEY,
SolUong INT NOT NULL DEFAULT 0,
FOREIGN KEY (IDSanPham) REFERENCES SanPham (IDSanPham)
);
--Xóa bảng cũ 
DROP TABLE IF EXISTS KhoHang;
CREATE TABLE KhoHang(
IDSanPham INT PRIMARY KEY,
SoLuong INT NOT NULL DEFAULT 0,
FOREIGN KEY (IDSanPham) REFERENCES SanPham (IDSanPham)
);
SELECT 
    sp.IDSanPham,
    sp.TenSP,
    sp.LoaiSP,
    kh.SoLuong,
    sp.GiaNhap
FROM 
    KhoHang kh
JOIN 
    SanPham sp ON kh.IDSanPham = sp.IDSanPham;
DELETE FROM KhoHang
WHERE NOT EXISTS (SELECT 1 FROM SanPham WHERE SanPham.IDSanPham = KhoHang.IDSanPham);
DELETE FROM KhoHang
WHERE IDSanPham IN (7, 10, 11);
ALTER TABLE KhoHang
ALTER COLUMN IDSanPham INT PRIMARY KEY IDENTITY(1,1);
-- Xóa bảng cũ
DROP TABLE IF EXISTS KhoHang;
CREATE TABLE KhoHang(
IDSanPham INT PRIMARY KEY,
SoLuong INT NOT NULL DEFAULT 0,
FOREIGN KEY (IDSanPham) REFERENCES SanPham (IDSanPham)
);
SELECT 
    sp.IDSanPham,
    sp.TenSP,
    sp.LoaiSP,
    kh.SoLuong,
    sp.GiaNhap
FROM 
    KhoHang kh
JOIN 
    SanPham sp ON kh.IDSanPham = sp.IDSanPham;
ALTER TABLE KhoHang
ADD TrangThaiKinhDoanh NVARCHAR(50) NULL;
INSERT INTO KhoHang (IDSanPham, SoLuong, TrangThaiKinhDoanh)
VALUES 
(1, 10, N'Còn hàng'),
(2, 5, N'Sắp hết hàng'),
(3, 0, N'Ngưng kinh doanh');
--Xóa bảng cũ 
DROP TABLE IF EXISTS KhoHang;
CREATE TABLE KhoHang(
IDSanPham INT PRIMARY KEY,
SoLuong INT NOT NULL DEFAULT 0,
FOREIGN KEY (IDSanPham) REFERENCES SanPham (IDSanPham)
);
SELECT 
    sp.IDSanPham,
    sp.TenSP,
    sp.LoaiSP,
    kh.SoLuong,
    sp.GiaNhap
FROM 
    KhoHang kh
JOIN 
    SanPham sp ON kh.IDSanPham = sp.IDSanPham;

SELECT * FROM KhoHang;

--Nhập hàng
CREATE TABLE NhapHang(
IDNhapHang INT PRIMARY KEY IDENTITY(1,1),
IDSanPham INT,
Soluong INT,
GiaNhap FLOAT,
FOREIGN KEY (IDSanPham) REFERENCES SanPham (IDSanPham)
);
-- xóa bảng cũ
DROP TABLE IF EXISTS NhapHang;
CREATE TABLE NhapHang (
    IDNhapHang INT PRIMARY KEY IDENTITY(1,1),
    IDSanPham INT,
    SoLuongNhap INT,
    GiaNhap FLOAT,
    NgayNhap DATE,
    FOREIGN KEY (IDSanPham) REFERENCES SanPham(IDSanPham)
);
ALTER TABLE NhapHang ADD Image VARCHAR (MAX);
ALTER TABLE NhapHang ADD TenSP VARCHAR (MAX);
ALTER TABLE NhapHang ADD Loai VARCHAR (MAX);
-- Sp 1 
INSERT INTO NhapHang (IDSanPham, SoLuongNhap, GiaNhap, NgayNhap, Image, TenSP, Loai)
VALUES (1, 100, 22000, '2025-05-10', 'image_hoa_hong.jpg', N'Hoa hồng đỏ', N'Hoa tươi');
-- Sản phẩm 2
INSERT INTO NhapHang (IDSanPham, SoLuongNhap, GiaNhap, NgayNhap, Image, TenSP, Loai)
VALUES (2, 80, 18000, '2025-05-10', 'image_hoa_cuc.jpg', N'Hoa cúc trắng', N'Hoa tươi');
-- Sản phẩm 3
INSERT INTO NhapHang (IDSanPham, SoLuongNhap, GiaNhap, NgayNhap, Image, TenSP, Loai)
VALUES (3, 60, 35000, '2025-05-10', 'image_hoa_lan.jpg', N'Hoa lan tím', N'Hoa tươi');
-- Sản phẩm 4
INSERT INTO NhapHang (IDSanPham, SoLuongNhap, GiaNhap, NgayNhap, Image, TenSP, Loai)
VALUES (4, 120, 15000, '2025-05-10', 'image_hoa_baby.jpg', N'Hoa baby trắng', N'Hoa phụ kiện');
-- Sản phẩm 5
INSERT INTO NhapHang (IDSanPham, SoLuongNhap, GiaNhap, NgayNhap, Image, TenSP, Loai)
VALUES (5, 90, 28000, '2025-05-10', 'image_hoa_huong_duong.jpg', N'Hoa hướng dương', N'Hoa tươi');

SELECT * FROM NhapHang;
-- Hóa đơn 
CREATE TABLE HoaDon (
    IDHoaDon INT PRIMARY KEY IDENTITY(1,1),
    NgayLap DATETIME,
    TenKH NVARCHAR(100),
    SDT VARCHAR(20),
    TongTien DECIMAL(18,2),
    TienKhachTra DECIMAL(18,2),
    TienThua DECIMAL(18,2),
    PhuongThucThanhToan NVARCHAR(50)
);
SELECT * FROM HoaDon;
-- Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    ID INT PRIMARY KEY IDENTITY(1,1),
    IDHoaDon INT FOREIGN KEY REFERENCES HoaDon(IDHoaDon),
    TenSP NVARCHAR(100),
    SoLuong INT,
    DonGia DECIMAL(18,2),
    ThanhTien DECIMAL(18,2)
);
SELECT * FROM ChiTietHoaDon;
