 USE [Address_Book_Service]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Add_Contacte]
@FirstName varchar(50),
@LastName varchar(50),
@Address varchar(50),
@City varchar(50),
@State varchar(50),
@Zipcode varchar(20),
@PhoneNumber varchar(20),
@EmailId varchar(20)
AS
BEGIN
SET NOCOUNT ON;	
insert into CreateAddressBook(FirstName,LastName,Address,City,State,Zipcode,PhoneNumber,EmailId) values
(@FirstName,@LastName,@Address,@City,@State,@Zipcode,@PhoneNumber,@EmailId);    
END
GO
select * from CreateAddressBook;
