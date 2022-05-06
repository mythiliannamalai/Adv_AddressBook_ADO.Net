USE [Address_Book_Service]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AddContact_Bothtype]
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
	insert into CreateAddressBook(FirstName,LastName,Address,City,State,Zipcode,PhoneNumber,EmailId,ContactType) values
(@FirstName,@LastName,@Address,@City,@State,@Zipcode,@PhoneNumber,@EmailId,'Family Contact'),
(@FirstName,@LastName,@Address,@City,@State,@Zipcode,@PhoneNumber,@EmailId,'Friends Contact');    
END
GO
