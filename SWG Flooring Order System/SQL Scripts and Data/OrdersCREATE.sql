USE [SGBank]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 3/5/2020 2:41:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[orderNumber] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [date] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[state] [nvarchar](2) NOT NULL,
	[productID] [int] NOT NULL,
	[area] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[orderNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_OrderProductID_ProductsProductID] FOREIGN KEY([productID])
REFERENCES [dbo].[Products] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_OrderProductID_ProductsProductID]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_OrderState_StatesState] FOREIGN KEY([state])
REFERENCES [dbo].[States] ([StateAbbreviation])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_OrderState_StatesState]
GO

