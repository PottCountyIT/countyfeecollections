USE [civilfeecollections]
GO

ALTER TABLE dbo.Defendant
ADD daysinjail int NULL,
bookingnumber varchar(20) NULL,
judgmentdate datetime NULL,
hasjudgmentfiled bit NULL,
judgmentfileddate datetime NULL,
inbankruptcy bit null,
bankruptcydatefiled datetime NULL,
bankruptcyenddate datetime NULL;
GO
