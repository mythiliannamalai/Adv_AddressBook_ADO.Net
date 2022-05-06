USE [Address_Book_Service]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [Delete_Contact]
@FirstName varchar(50)
AS
BEGIN
	Delete CreateAddressBook where FirstName=@FirstName;
	   
END
GO
