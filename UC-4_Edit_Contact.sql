USE [Address_Book_Service]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [Edit_Contact] 
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
	update CreateAddressBook set LastName=@LastName where FirstName=@FirstName;	
	update CreateAddressBook set Address=@Address where FirstName=@FirstName;	
	update CreateAddressBook set City=@City where FirstName=@FirstName;	
	update CreateAddressBook set State=@State where FirstName=@FirstName;		
	update CreateAddressBook set Zipcode=@Zipcode where FirstName=@FirstName;	
	update CreateAddressBook set PhoneNumber=@PhoneNumber where FirstName=@FirstName;	
	update CreateAddressBook set EmailId=@EmailId where FirstName=@FirstName;	
	select CreateAddressBook.FirstName,LastName,Address,City,State,Zipcode,PhoneNumber,EmailId from CreateAddressBook;
END
GO

select * from CreateAddressBook