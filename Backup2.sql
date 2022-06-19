CREATE DATABASE BackCup2
GO

USE BackCup2
GO

--Table
CREATE TABLE TableFood
(
  id_TableFood int IDENTITY(1,1)  PRIMARY KEY not null,
  TableFood_name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
  TableFood_status NVARCHAR(100) NOT NULL DEFAULT N'Trống'
)
GO

-- Account
CREATE TABLE Account
(
  Account_UserName NVARCHAR(100) PRIMARY KEY NOT NULL,
  Account_DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Group_5',
  Account_PassWork NVARCHAR(1000)  NOT NULL DEFAULT 0,
  Account_Type INT  NOT NULL DEFAULT 0  --1: Admin ỏ 0: staff
)
GO

--Foodcategory
CREATE TABLE FoodMenu
(
  id_FoodMenu int IDENTITY(1,1)  PRIMARY KEY NOT NULL,
  FoodMenu_name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

--Food
CREATE TABLE Food
(
  id_Food int IDENTITY(1,1)  PRIMARY KEY NOT NULL,
  Food_name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
  Food_idMenu INT NOT NULL,
  Food_price FLOAT NOT NULL DEFAULT 0

  FOREIGN KEY (Food_idMenu) REFERENCES dbo.FoodMenu(id_FoodMenu)
)
GO

-- Bill
CREATE TABLE Bill
(
  id_Bill INT IDENTITY PRIMARY KEY NOT NULL,
  Bill_DayCheckIn Date NOT NULL DEFAULT GETDATE(),
  Bill_DayCheckOut Date NULL,
  Bill_idTable INT NOT NULL,
  Bill_status INT NOT NULL,   -- 1: ĐÃ thanh toán 0: CHƯA thanh toán
  Bill_Discount INT NULL,
  Bill_totalPrice FLOAT NULL
  FOREIGN KEY (Bill_idTable) REFERENCES dbo.TableFood(id_TableFood)
)
GO

-- BillInfo
CREATE TABLE BillInfo
(
  id_BillInfo INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
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
            N'a', --Username
			N'a',  --DisplayName
			N'1', --Password
			1         --Type
          )
GO
-- TRUE
CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS
BEGIN
     SELECT * FROM dbo.Account Where Account_UserName = @userName
END
GO
-- TRUE
CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
     SELECT * FROM dbo.Account Where Account_UserName = @userName AND Account_PassWork = @passWord
END
GO
-- TRUE
CREATE PROC USP_GetTableList
AS SELECT * FROM DBO.TableFood
GO
-- Them table
DECLARE @i INT = 1
WHILE @i <= 30
BEGIN 
     INSERT dbo.TableFood (TableFood_name) VALUES ( N'Bàn ' + CAST(@i as nvarchar(100)))
	SET @i = @i + 1
END
GO

-- Them meunu 
INSERT INTO dbo.FoodMenu
          (FoodMenu_name)
VALUES    (N'Cà Phê Pha Phin') -- ID = 1

INSERT INTO dbo.FoodMenu
          (FoodMenu_name)
VALUES    (N'Cà Phê ESPRESSO') -- ID = 2

INSERT INTO dbo.FoodMenu
          (FoodMenu_name)
VALUES    (N'Trà') -- ID = 3

INSERT INTO dbo.FoodMenu
          (FoodMenu_name)
VALUES    (N'Freeze') -- ID = 4

INSERT INTO dbo.FoodMenu
          (FoodMenu_name)
VALUES    (N'Thức Uống Khác') -- ID = 5

INSERT INTO dbo.FoodMenu
          (FoodMenu_name)
VALUES    (N'Bánh') -- ID = 6

INSERT INTO dbo.FoodMenu
          (FoodMenu_name)
VALUES    (N'Bánh Mì') -- ID = 7

-- Them Mon An:
-- IDMENU = 1
INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Phin sữa đá', 1, 29000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Phin đen đá', 1, 29000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Bạc xỉu đá', 1, 29000)
-- IDMENU = 2
INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Espresso/ Americano', 2, 35000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Cappuccino/ Latte', 2, 55000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Mocha/ Caramel Macchiato', 2, 59000)
-- IDMENU = 3
INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Trà sen vàng', 3, 39000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Trà thạch đào', 3, 39000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Trà thạch vải', 3, 39000)
-- IDMENU = 4
INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Freeze trà xanh', 4, 49000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Freeze sô-cô-la', 4, 49000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Freeze dâu', 4, 49000)
-- IDMENU = 5
INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Chanh đá xay/ Đá viên', 5, 39000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Chanh dây đá viên', 5, 39000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Tắc/ Quất đá viên', 5, 39000)
-- IDMENU = 6
INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Tiramisu', 6, 19000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Bông lan trứng muối', 6, 39000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Mousse cacao', 6, 29000)
-- IDMENU = 7
INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Gà xé', 7, 19000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Cá ngừ', 7, 19000)

INSERT INTO dbo.Food
          (Food_name, Food_idMenu, Food_price)
VALUES    (N'Nấm', 7, 19000)
GO
-----------------TRUE----------
CREATE PROC [dbo].[USP_InsertBill]
@idTable INT
AS
BEGIN
	INSERT dbo.Bill 
	        ( Bill_DayCheckIn ,
	          Bill_DayCheckOut ,
	          Bill_idTable ,
	          Bill_status,
	          Bill_discount
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @idTable , -- idTable - int
	          0,  -- status - int
	          0
	        )
END
GO
----------TRUE-------------
ALTER PROC [dbo].[USP_InsertBillInfo]
@idBill INT, @idFood INT, @count INT
AS
BEGIN

	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT 
	
	SELECT @isExitsBillInfo = id_BillInfo, @foodCount = b.BillInfo_count 
	FROM dbo.BillInfo AS b 
	WHERE BillInfo_idBill = @idBill AND BillInfo_idFood = @idFood

	IF (@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo	SET BillInfo_count = @foodCount + @count WHERE BillInfo_idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE BillInfo_idBill = @idBill AND BillInfo_idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT	dbo.BillInfo
        ( BillInfo_idBill, BillInfo_idFood, BillInfo_count )
		VALUES  ( @idBill, -- idBill - int
          @idFood, -- idFood - int
          @count  -- count - int
          )
	END
END
GO
-- TRUE
CREATE TRIGGER UTG_UpdateTable
ON dbo.TableFood FOR UPDATE
AS 
BEGIN
     DECLARE @idTable INT
	 DECLARE @status NVARCHAR(100)

	 SELECT @idTable = id_TableFood FROM Inserted

	 DECLARE @idBill INT
	 SELECT @idBill = id_Bill From dbo.Bill WHERE Bill_idTable = @idTable AND Bill_status = 0

	 DECLARE @countBillInfo INT
	 SELECT @countBillInfo = COUNT(*) FROM dbo.BillInfo WHERE BillInfo_idBill = @idBill

	 IF(@countBillInfo > 0 AND @status <> N'Có người')
	    UPDATE dbo.TableFood SET TableFood_status = N'Có người' WHERE id_TableFood = @idTable
     ELSE IF(@countBillInfo < 0 AND @status <> N'Trống')
	    UPDATE dbo.TableFood SET TableFood_status = N'Trống' WHERE id_TableFood = @idTable
END 
GO
--
CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
     DECLARE @idBill INT

	 SELECT @idBill = id_Bill FROM Inserted

	 DECLARE @idTable INT

	 SELECT @idTable = Bill_idTable FROM dbo.Bill WHERE id_Bill = @idBill

	 DECLARE @count int = 0

	 SELECT @count = COUNT(*) FROM dbo.Bill WHERE Bill_idTable = @idTable AND Bill_status = 0

     IF(@count = 0)
	    UPDATE dbo.TableFood SET TableFood_status = N'Trống' WHERE id_TableFood = @idTable
END
GO
-- TRUE
CREATE PROC [dbo].[USP_SwitchTable]
@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSeconrdBill INT
	
	DECLARE @isFirstTablEmty INT = 1
	DECLARE @isSecondTablEmty INT = 1
	
	
	SELECT @idSeconrdBill = id_Bill FROM dbo.Bill WHERE Bill_idTable = @idTable2 AND Bill_status = 0
	SELECT @idFirstBill = id_Bill FROM dbo.Bill WHERE Bill_idTable = @idTable1 AND Bill_status = 0
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idFirstBill IS NULL)
	BEGIN
		PRINT '0000001'
		INSERT dbo.Bill
		        ( Bill_DayCheckIn ,
		          Bill_DayCheckOut ,
		          Bill_idTable ,
		          Bill_status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0  -- status - int
		        )
		        
		SELECT @idFirstBill = MAX(id_Bill) FROM dbo.Bill WHERE Bill_idTable = @idTable1 AND Bill_status = 0
		
	END
	
	SELECT @isFirstTablEmty = COUNT(*) FROM dbo.BillInfo WHERE BillInfo_idBill = @idFirstBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idSeconrdBill IS NULL)
	BEGIN
		PRINT '0000002'
		INSERT dbo.Bill
		        ( Bill_DayCheckIn ,
		          Bill_DayCheckOut ,
		          Bill_idTable ,
		          Bill_status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0  -- status - int
		        )
		SELECT @idSeconrdBill = MAX(id_Bill) FROM dbo.Bill WHERE Bill_idTable = @idTable2 AND Bill_status = 0
		
	END
	
	SELECT @isSecondTablEmty = COUNT(*) FROM dbo.BillInfo WHERE BillInfo_idBill = @idSeconrdBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'

	SELECT id_BillInfo INTO IDBillInfoTable FROM dbo.BillInfo WHERE BillInfo_idBill = @idSeconrdBill
	
	UPDATE dbo.BillInfo SET BillInfo_idBill = @idSeconrdBill WHERE BillInfo_idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET BillInfo_idBill = @idFirstBill WHERE id_BillInfo IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable
	
	IF (@isFirstTablEmty = 0)
		UPDATE dbo.TableFood SET TableFood_status = N'Trống' WHERE id_TableFood = @idTable2
		
	IF (@isSecondTablEmty= 0)
		UPDATE dbo.TableFood SET TableFood_status = N'Trống' WHERE id_TableFood = @idTable1
END
GO
---------- TRUE----------------
ALTER PROC [dbo].[USP_GetListBillByDate]
@checkIn DATE, @checkOut DATE
AS
BEGIN
     SELECT t.TableFood_name as [Tên bàn], b.Bill_totalPrice as [Tổng tiền], Bill_DayCheckIn as [Ngày vào], Bill_DayCheckOut as [Ngày ra], Bill_Discount as [Giảm giá]
     FROM dbo.Bill b, dbo.TableFood t
      WHERE Bill_DayCheckIn >= @checkIn AND Bill_DayCheckOut <= @checkOut AND b.Bill_status = 1
      AND t.id_TableFood = b.id_Bill 
END 
GO
-- TRUE
CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
     DECLARE @isRightPass INT = 0

	 SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE Account_UserName = @userName AND Account_PassWork = @password

	 IF(@isRightPass = 1)
	 BEGIN
	      IF(@newPassword = null OR @newPassword = ' ')
		  BEGIN
		      UPDATE dbo.Account SET Account_DisplayName = @displayName WHERE Account_UserName = @userName
		  END
		  ELSE
		      UPDATE dbo.Account SET Account_DisplayName = @displayName, Account_PassWork = @newPassword WHERE Account_UserName = @userName
	 END
END
GO
-- TRUE
CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS
BEGIN
     DECLARE @idBillInfo INT
	 DECLARE @idBill INT
	 SELECT @idBillInfo = id_BillInfo, @idBill = Deleted.BillInfo_idBill FROM Deleted

	 DECLARE @idTable INT
	 SELECT @idTable = Bill_idTable FROM dbo.Bill WHERE id_Bill = @idBill

	 DECLARE @count INT = 0

	 SELECT @count = COUNT(*) FROM dbo.BillInfo bi, dbo.Bill b WHERE b.id_Bill = bi.id_BillInfo AND b.id_Bill = @idBill AND b.Bill_status = 0

	 IF(@count = 0)
	   UPDATE DBO.TableFood SET TableFood_status = N'Trống' WHERE id_TableFood = @idTable
END
GO
------True---------------
CREATE FUNCTION [dbo].[unikey](@inputVar NVARCHAR(MAX) )
RETURNS NVARCHAR(MAX)
AS
BEGIN    
    IF (@inputVar IS NULL OR @inputVar = '')  RETURN ''
   
    DECLARE @RT NVARCHAR(MAX)
    DECLARE @SIGN_CHARS NCHAR(256)
    DECLARE @UNSIGN_CHARS NCHAR (256)
 
    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' + NCHAR(272) + NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
 
    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
   
    SET @COUNTER = 1
    WHILE (@COUNTER <= LEN(@inputVar))
    BEGIN  
        SET @COUNTER1 = 1
        WHILE (@COUNTER1 <= LEN(@SIGN_CHARS) + 1)
        BEGIN
            IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@inputVar,@COUNTER ,1))
            BEGIN          
                IF @COUNTER = 1
                    SET @inputVar = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)-1)      
                ELSE
                    SET @inputVar = SUBSTRING(@inputVar, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)- @COUNTER)
                BREAK
            END
            SET @COUNTER1 = @COUNTER1 +1
        END
        SET @COUNTER = @COUNTER +1
    END
    -- SET @inputVar = replace(@inputVar,' ','-')
    RETURN @inputVar
END
GO
-----TRUE-----
CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
     DECLARE @idBill INT

	 SELECT @idBill = BillInfo_idBill FROM Inserted

	 DECLARE @idTable INT

	 SELECT @idTable = Bill_idTable FROM dbo.Bill WHERE id_Bill = @idBill AND Bill_status = 0
     
	 DECLARE @count INT
	 SELECT @count = COUNT(*) FROM dbo.BillInfo WHERE BillInfo_idBill = @idBill

	 IF(@count > 0)
	 UPDATE dbo.TableFood SET TableFood_status = N'Có người' WHERE id_TableFood = @idTable   
	 ELSE
	 UPDATE dbo.TableFood SET TableFood_status = N'Trống' WHERE id_TableFood = @idTable
END
GO
--
select * from dbo.Bill;