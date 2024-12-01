USE [products]
GO
CREATE TABLE [dbo].[Clients](
	
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Phone] [varchar](255) NULL,
	[Mail] [varchar](255) NULL,
	
	PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)	
	WITH 
	(
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	) ON [PRIMARY]

) ON [PRIMARY]
GO

