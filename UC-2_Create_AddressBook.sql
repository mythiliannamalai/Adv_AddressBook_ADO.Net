USE [Address_Book_Service]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Create_AddressBook]	
AS
BEGIN
	create table CreateAddressBook(
FirstName varchar(50),
LastName varchar(50),
Address varchar(100),
City varchar(20),
State varchar(20),
Zipcode varchar(20),
PhoneNumber varchar(20),
EmailId varchar(20)  
);
END
GO

