CREATE DATABASE PhanMemHeCan;
GO
USE PhanMemHeCan
GO

--TABLE


--TABLE GROUP
CREATE TABLE [Group] (
GroupID INT IDENTITY(1,1) PRIMARY KEY,
[GroupName] nvarchar(100) UNIQUE,
IsManagementUser bit default 0,
IsManagementGroup bit default 0
)
GO


--TABLE USER
CREATE TABLE [User] (
UserID INT IDENTITY(1,1) PRIMARY KEY,
FullName NVARCHAR(100),
Username VARCHAR(100) UNIQUE NOT NULL,
[Password] VARCHAR(100) default 'leanway',
GroupID int,
-- neu xoa group thi xoa luon user
FOREIGN KEY (GroupID) REFERENCES [Group](GroupID) On Delete CASCADE 
)
GO

--TABLE TRANSPORT
CREATE TABLE Transport (
TransportID INT IDENTITY(1,1) PRIMARY KEY,
ProductName NVARCHAR(100),
Customer nvarchar(100),
ProductWeight FLOAT,
CarWeight FLOAT,
TotalWeight FLOAT,
NumberPlates varchar(100),
ImagePath text,
UsernamePerformer varchar(100),
CreateAt DateTime Default GetDate()
)
GO




--TABLE CAR
CREATE TABLE Car(
CarID INT IDENTITY(1,1) PRIMARY KEY,
NumberPlates varchar(100),
DriverName NVARCHAR(100),
CarWeight FLOAT
)
GO



--------------------PROC---------------------------
--PROC Transport
-- Thêm Transport
CREATE PROC AddTransport @ProductName nvarchar(100), @Customer nvarchar(100), @ProductWeight FLOAT, @CarWeight FLOAT, @TotalWeight FLOAT, @NumberPlates varchar(100), @ImagePath text, @UsernamePerformer varchar(100)
as begin
Insert into [Transport](ProductName,Customer,ProductWeight,CarWeight,TotalWeight,NumberPlates,[ImagePath],UsernamePerformer) 
values (@ProductName,@Customer,@ProductWeight,@CarWeight,@TotalWeight,@NumberPlates,@ImagePath,@UsernamePerformer);
end
GO
-- Delete Transport by id
CREATE PROC DeleteTransportFromID @TransportID Int
as begin
Delete FROM [Transport] WHERE [Transport].TransportID = @TransportID;
end
GO









--PROC Paganition Transport
--Không chọn tên nhiên nhiệu, không chọn ngày, không chọn cân nặng sản phẩm
CREATE PROC Count_NoProductName_NoDate_NoProductWeight 
as begin 
select count(*) from Transport;
end
GO

CREATE PROC Pagination_NoProductName_NoDate_NoProductWeight (@page int ,@NUM_ELM int)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY TransportID desc) as row FROM Transport ) 
a WHERE a.row > @start and a.row <= @end;
end
GO


/*CẢ 3*/
--Chọn tên nhiên liệu, chọn ngày, chọn khoảng cân nặng sản phẩm
CREATE PROC Count_YesProductName_YesDate_YesProductWeight
(@ProductName nvarchar(100), @TimeStart Datetime , @TimeEnd Datetime,
@ProductWeightStart FLOAT, @ProductWeightEnd FLOAT)
as begin 
select count(*) from Transport where 
(Transport.ProductName = @ProductName)
and (Transport.CreateAt BETWEEN @TimeStart AND @TimeEnd)
and (Transport.ProductWeight between @ProductWeightStart and @ProductWeightEnd) 

end
GO

CREATE PROC Pagination_YesProductName_YesDate_YesProductWeight (@page int ,@NUM_ELM int, @ProductName nvarchar(100), @TimeStart Datetime , @TimeEnd Datetime,
@ProductWeightStart FLOAT, @ProductWeightEnd FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY TransportID desc) as row FROM Transport 
where (Transport.ProductName = @ProductName)
and (Transport.CreateAt BETWEEN @TimeStart AND @TimeEnd)
and (Transport.ProductWeight between @ProductWeightStart and @ProductWeightEnd)) 
a WHERE a.row > @start and a.row <= @end;
end
GO




--Từng chỉ số

--có tên nhiên liệu, không có ngày, không có cân nặng sản phẩm
CREATE PROC Count_YesProductName_NoDate_NoProductWeight
(@ProductName nvarchar(100))
as begin 
select count(*) from Transport where 
Transport.ProductName = @ProductName 

end
GO

CREATE PROC Pagination_YesProductName_NoDate_NoProductWeight (@page int ,@NUM_ELM int, @ProductName nvarchar(100))
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY TransportID desc) as row FROM Transport 
where Transport.ProductName = @ProductName) 
a WHERE a.row > @start and a.row <= @end;
end
GO


--không có tên nhiên liệu, có ngày, không có cân nặng sản phẩm
CREATE PROC Count_NoProductName_YesDate_NoProductWeight
(@TimeStart Datetime , @TimeEnd Datetime)
as begin 
select count(*) from Transport where 
Transport.CreateAt BETWEEN @TimeStart AND @TimeEnd 
end
GO

CREATE PROC Pagination_NoProductName_YesDate_NoProductWeight (@page int ,@NUM_ELM int, @TimeStart Datetime , @TimeEnd Datetime)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY TransportID desc) as row FROM Transport 
where Transport.CreateAt BETWEEN @TimeStart AND @TimeEnd) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--không có tên nhiên liệu, không có ngày, có cân nặng sản phẩm
CREATE PROC Count_NoProductName_NoDate_YesProductWeight
(@ProductWeightStart FLOAT, @ProductWeightEnd FLOAT)
as begin 
select count(*) from Transport where 
Transport.ProductWeight between @ProductWeightStart and @ProductWeightEnd
end
GO

CREATE PROC Pagination_NoProductName_NoDate_YesProductWeight (@page int ,@NUM_ELM int, @ProductWeightStart FLOAT, @ProductWeightEnd FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY TransportID desc) as row FROM Transport 
where Transport.ProductWeight between @ProductWeightStart and @ProductWeightEnd) 
a WHERE a.row > @start and a.row <= @end;
end
GO




--2 loại
--có product name, có date, không có cân nặng product
CREATE PROC Count_YesProductName_YesDate_NoProductWeight
(@ProductName nvarchar(100), @TimeStart Datetime , @TimeEnd Datetime)
as begin 
select count(*) from Transport where 
(Transport.ProductName = @ProductName)
and (Transport.CreateAt BETWEEN @TimeStart AND @TimeEnd) 

end
GO

CREATE PROC Pagination_YesProductName_YesDate_NoProductWeight (@page int ,@NUM_ELM int, @ProductName nvarchar(100), @TimeStart Datetime , @TimeEnd Datetime)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY TransportID desc) as row FROM Transport 
where (Transport.ProductName = @ProductName)
and (Transport.CreateAt BETWEEN @TimeStart AND @TimeEnd)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--có product name, không có date, có cân nặng
CREATE PROC Count_YesProductName_NoDate_YesProductWeight
(@ProductName nvarchar(100), @ProductWeightStart FLOAT, @ProductWeightEnd FLOAT)
as begin 
select count(*) from Transport where 
(Transport.ProductName = @ProductName)
and (Transport.ProductWeight between @ProductWeightStart and @ProductWeightEnd) 

end
GO

CREATE PROC Pagination_YesProductName_NoDate_YesProductWeight (@page int ,@NUM_ELM int, @ProductName nvarchar(100), @ProductWeightStart FLOAT, @ProductWeightEnd FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY TransportID desc) as row FROM Transport 
where (Transport.ProductName = @ProductName)
and (Transport.ProductWeight between @ProductWeightStart and @ProductWeightEnd)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

-- không product name, có date, có cân nặng product
CREATE PROC Count_NoProductName_YesDate_YesProductWeight
(@TimeStart Datetime , @TimeEnd Datetime,
@ProductWeightStart FLOAT, @ProductWeightEnd FLOAT)
as begin 
select count(*) from Transport where 
(Transport.CreateAt BETWEEN @TimeStart AND @TimeEnd)
and (Transport.ProductWeight between @ProductWeightStart and @ProductWeightEnd) 

end
GO

CREATE PROC Pagination_NoProductName_YesDate_YesProductWeight (@page int ,@NUM_ELM int, @TimeStart Datetime , @TimeEnd Datetime,
@ProductWeightStart FLOAT, @ProductWeightEnd FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY TransportID desc) as row FROM Transport 
where (Transport.CreateAt BETWEEN @TimeStart AND @TimeEnd)
and (Transport.ProductWeight between @ProductWeightStart and @ProductWeightEnd)) 
a WHERE a.row > @start and a.row <= @end;
end
GO














--PROC CAR
-- Thêm Car
CREATE PROC AddCar @NumberPlates varchar(100), @DriverName nvarchar(100), @CarWeight FLOAT 
as begin
Insert into [Car] values (@NumberPlates,@DriverName,@CarWeight);
end
GO
--Cap nhat Car
CREATE PROC UpdateCar @CarID int,@NumberPlates varchar(100), @DriverName nvarchar(100), @CarWeight FLOAT
as begin
Update [Car] SET NumberPlates = @NumberPlates, DriverName = @DriverName, CarWeight = @CarWeight
where CarID = @CarID
end
GO
--Xóa Car
CREATE PROC DeleteCar @CarID Int
as begin
Delete FROM [Car] WHERE [Car].CarID = @CarID;
end
GO
--Lấy car từ id
CREATE PROC GetCarFromID @CarID Int
as begin
Select * from Car where CarID = @CarID
end
GO





-- PROC Group
-- Thêm Group
CREATE PROC AddGroup @GroupName nvarchar(100), @IsManagementUser bit, @IsManagementGroup bit
as begin
Insert into [Group] values (@GroupName,@IsManagementUser, @IsManagementGroup);
end
GO

--Cap nhat thong tin quyền
CREATE PROC UpdateGroup @GroupID int,@GroupName nvarchar(100), @IsManagementUser bit, @IsManagementGroup bit
as begin
Update [Group] SET [GroupName] = @GroupName, IsManagementUser = @IsManagementUser, IsManagementGroup = @IsManagementGroup
where GroupID = @GroupID
end
GO

--Xóa quyền
CREATE PROC DeleteGroup @GroupID Int
as begin
Delete FROM [Group] WHERE [Group].GroupID = @GroupID;
end
GO

--Lấy quyền từ id
CREATE PROC GetGroupFromID @GroupID Int
as begin
Select * from [Group] where GroupID = @GroupID
end
GO

--Tìm kiếm group với tên bất kỳ
CREATE PROC FindGroupByName @GroupName nvarchar(100)
as begin 
Select * From [Group] Where [Group].GroupName like '%'+@GroupName+'%';
end
GO




-------PROC USER------------

--Proc User
--Tìm kiếm nhân viên theo tên tài khoản
CREATE PROC FindUserByUsername @Username varchar(100)
as begin 
Select * From [User] Where Username = @Username;
end
GO

--Tìm kiếm nhân viên theo MaNV
CREATE PROC GetUserFromID @UserID int
as begin 
Select * From [User] Where [User].UserID = @UserID;
end
GO



--Tìm kiếm nhân viên với họ tên bất kỳ
CREATE PROC FindUserByFullNameOrUsername @Name nvarchar(100)
as begin 
Select * From [User] Where [User].FullName like '%'+@Name+'%' OR [User].Username like '%'+@Name+'%';
end
GO

-- Thêm nhân viên
CREATE PROC AddUser @FullName nvarchar(100), @Username VARCHAR(100) , @Password VARCHAR(100) , @GroupID INT
as begin
Insert into [User] values (@FullName,@Username,@Password,@GroupID);
end
GO

--Cap nhat thong tin nhan vien
CREATE PROC UpdateUser @UserID INT, @FullName nvarchar(100), @Username VARCHAR(100) , @Password varchar(100), @GroupID INT
as begin
Update [User] SET FullName = @FullName, Username = @Username, [User].[Password] = @Password, GroupID = @GroupID
where [User].UserID = @UserID
end
GO


--Xóa tài khoản nhân viên theo Username
CREATE PROC DeleteUser @UserID INT
as begin
Delete FROM [User] WHERE [User].UserID = @UserID;
end
GO








exec AddGroup 'Admin',1,1;
exec AddUser N'Đỗ Văn Xuân','admin','123',1;
exec AddCar '29H9-99999', N'Đỗ Văn B', 800;
exec AddTransport N'Đá','LeanWay Co.',700,300,1000,'30N-9850','abc/abc.jpg','admin'
