USE [Address_Book_Service]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [GetAllData]	
@City varchar(20),
@State varchar(20)
AS
BEGIN
	select * from CreateAddressBook where City=@City Or State=@State;	
	select CreateAddressBook.FirstName,LastName,Address,City,State,Zipcode,PhoneNumber,EmailId from CreateAddressBook; 
END
GO
