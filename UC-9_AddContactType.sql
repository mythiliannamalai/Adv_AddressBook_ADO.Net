USE [Address_Book_Service]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AddContactType]
AS
BEGIN
	Alter table CreateAddressBook add ContactType varchar(20);	 
END
GO


