USE [SGBank]
GO

/****** Object:  Table [dbo].[States]    Script Date: 3/5/2020 2:40:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[States](
	[StateAbbreviation] [nvarchar](2) NOT NULL,
	[state name] [nvarchar](50) NOT NULL,
	[tax rate] [decimal](15, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StateAbbreviation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

