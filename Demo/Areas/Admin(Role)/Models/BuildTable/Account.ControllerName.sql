CREATE TABLE [dbo].[Account.ControllerName](
	[ControllerName] [nvarchar](128) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Type] [int] NOT NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_Account.ControllerName] PRIMARY KEY CLUSTERED 
(
	[ControllerName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Account.ControllerName]  WITH CHECK ADD  CONSTRAINT [FK_Account.ControllerName_Account.SideBarType] FOREIGN KEY([Type])
REFERENCES [dbo].[Account.SideBarType] ([Type])
GO

ALTER TABLE [dbo].[Account.ControllerName] CHECK CONSTRAINT [FK_Account.ControllerName_Account.SideBarType]
GO


