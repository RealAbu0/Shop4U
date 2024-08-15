/* USER QUERY */

CREATE PROC GetAllUsers_sp
AS
BEGIN
SELECT * FROM tbl_users
END

EXEC GetAllUsers_sp

CREATE PROC CreateUser_sp
@Username VARCHAR(50),
@Password VARCHAR(50),
@Firstname VARCHAR(50),
@Lastname VARCHAR(50),
@Email VARCHAR(50),
@Token VARCHAR(350),
@Role VARCHAR(50)
AS
BEGIN
INSERT INTO tbl_users (Username, Password, Firstname, Lastname, Email) VALUES(@Username, @Password, @Firstname, @Lastname, @Email)
END

CREATE PROC GetOneUser_sp
@ID int
AS
BEGIN
SELECT * FROM tbl_users WHERE ID=@ID
END

CREATE PROC UpdateUser_sp
@Username VARCHAR(50),
@Password VARCHAR(50),
@Firstname VARCHAR(50),
@Lastname VARCHAR(50),
@Email VARCHAR(50),
@Role VARCHAR(50)
AS
BEGIN
UPDATE tbl_users SET Username=@Username, Password=@Password, Firstname=@Firstname, Lastname=@Lastname, Email=@Email, Role=@Role
END

CREATE PROC CheckEmailExist_sp
@Email VARCHAR(50)
AS
IF EXISTS (SELECT * FROM tbl_users WHERE Email=@Email)
BEGIN
SELECT 'The Email Already Exist!'
END

CREATE PROC CheckUsernameExist_sp
@Username VARCHAR(50)
AS
IF EXISTS(SELECT * FROM tbl_users WHERE Username=@Username)
BEGIN
SELECT 'The Username Already Exists!'
END

CREATE PROC DeleteUser_sp
@ID int
AS
BEGIN
DELETE tbl_users WHERE ID=@ID
END

CREATE PROC AuthenticateUser_sp
@Username VARCHAR(50),
@Password VARCHAR(50)
AS
BEGIN
DECLARE @ID INT = 0
SELECT ID=@ID FROM tbl_users
WHERE Username=@Username AND Password=@Password
IF(@ID > 0)
BEGIN
SELECT ID, Username, Password FROM tbl_users
WHERE ID=@ID
END 
END


/* PRODUCT QUERY */

CREATE PROC GetAllRandomProducts
AS
BEGIN
SELECT TOP 20 ID, * FROM tbl_items ORDER BY NEWID (); 
END


CREATE PROC GetOneItem_sp
@ItemId VARCHAR(50)
AS
BEGIN
SELECT * FROM tbl_items WHERE ItemId=@ItemId
END


/* CART QUERY */

CREATE PROC GetCartByUserId_sp
@UserId INT
AS
BEGIN
SELECT * FROM tbl_cart WHERE UserId=@UserId
END


CREATE PROC GetAllCart_sp
AS
BEGIN
SELECT * FROM tbl_cart
END

CREATE PROC AddToCart_sp
@UserId INT,
@ProductId VARCHAR(50),
@ProductName VARCHAR(50),
@ProductImage VARCHAR(MAX),
@ProductQuantity INT,
@ProductPrice INT
AS
BEGIN
INSERT INTO tbl_cart (UserId, ProductId, ProductName, ProductImage, ProductQuantity, ProductPrice) VALUES (@UserId, @ProductId, @ProductName, @ProductImage, @ProductQuantity, @ProductPrice)
END

CREATE PROC GetProductById_sp
@ItemId VARCHAR(50)
AS
BEGIN
SELECT * FROM tbl_items WHERE ItemId=@ItemId
END


CREATE PROC DeleteCartById_sp
@CartId INT
AS
BEGIN
DELETE FROM tbl_cart WHERE CartId=@CartId
END

CREATE PROC DeleteAllCart_sp
@UserId INT
AS
BEGIN
DELETE FROM tbl_cart WHERE UserId=@UserId
END


/*  Pages Sp*/
CREATE PROC CreateContactUs_sp
@IssueId int,
@Username VARCHAR(50),
@Email VARCHAR(50),
@Category VARCHAR(50),
@Message VARCHAR(MAX)
AS
BEGIN
INSERT INTO tbl_contactus (IssueId, Username, Email, Category, Message) VALUES (@IssueId, @Username, @Email, @Category, @Message)
END



