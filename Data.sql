CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO

--Table
CREATE TABLE TableFood
(
  id_TableFood int IDENTITY  PRIMARY KEY,
  TableFood_name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
  TableFood_status NVARCHAR(100) NOT NULL DEFAULT N'Trống'
)
GO

-- Account
CREATE TABLE Account
(
  Account_UserName NVARCHAR(100) PRIMARY KEY,
  Account_DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Group_5',
  Account_PassWork NVARCHAR(1000)  NOT NULL DEFAULT 0,
  Account_Type INT  NOT NULL DEFAULT 0  --1: Admin ỏ 0: staff
)
GO

--Foodcategory
CREATE TABLE FoodMenu
(
  id_FoodMenu int IDENTITY  PRIMARY KEY,
  FoodMenu_name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

--Food
CREATE TABLE Food
(
  id_Food int IDENTITY  PRIMARY KEY,
  Food_name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
  Food_idMenu INT NOT NULL,
  Food_price FLOAT NOT NULL DEFAULT 0

  FOREIGN KEY (Food_idMenu) REFERENCES dbo.FoodMenu(id_FoodMenu)
)
GO

-- Bill
CREATE TABLE Bill
(
  id_Bill INT IDENTITY PRIMARY KEY,
  Bill_DayCheckIn Date NOT NULL DEFAULT GETDATE(),
  Bill_DayCheckOut Date,
  Bill_idTable INT NOT NULL,
  Bill_status INT NOT NULL   -- 1: ĐÃ thanh toán 0: CHƯA thanh toán

  FOREIGN KEY (Bill_idTable) REFERENCES dbo.TableFood(id_TableFood)
)
GO

-- BillInfo
CREATE TABLE BillInfo
(
  id_BillInfo INT IDENTITY PRIMARY KEY,
  BillInfo_idBill INT NOT NULL,
  BillInfo_idFood INT NOT NULL,
  BillInfo_count INT NOT NULL DEFAULT 0

  FOREIGN KEY(BillInfo_idBill) REFERENCES dbo.Bill(id_Bill),
  FOREIGN KEY(BillInfo_idFood) REFERENCES dbo.Food(id_Food)
)
GO

-- 
INSERT INTO dbo.Account
          ( Account_UserName,
		    Account_DisplayName,
			Account_PassWork,
			Account_Type
		  )
VALUES    (
            N'Toan', --Username
			N'Toan',  --DisplayName
			N'12345', --Password
			1         --Type
          )
--
INSERT INTO dbo.Account
          ( Account_UserName,
		    Account_DisplayName,
			Account_PassWork,
			Account_Type
		  )
VALUES    (
            N'Thanh', --Username
			N'Thanh',  --DisplayName
			N'12345', --Password
			0         --Type
          )
GO

--
CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS
BEGIN
     SELECT * FROM dbo.Account Where Account_UserName = @userName
END
GO

