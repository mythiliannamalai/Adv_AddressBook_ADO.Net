USE [Address_Book_Service]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetDataIn_alphabeticalOrder]
@City varchar(20)
AS
BEGIN
select * from CreateAddressBook where City=@City order by FirstName asc; 
select CreateAddressBook.FirstName,LastName,Address,City,State,Zipcode,PhoneNumber,EmailId from CreateAddressBook; 
END
GO
