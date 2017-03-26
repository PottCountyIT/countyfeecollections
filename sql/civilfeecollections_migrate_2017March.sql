USE [civilfeecollections]
GO

ALTER TABLE dbo.Defendant
ADD daysinjail int NULL,
bookingnumber varchar(20) NULL,
judgmentdate datetime NULL;
GO
