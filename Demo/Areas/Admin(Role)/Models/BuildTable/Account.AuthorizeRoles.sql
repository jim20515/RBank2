CREATE TABLE [dbo].[Account.AuthorizeRoles](
	[RoleId] [nvarchar](128) NOT NULL,
	[ControllerName] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Account.AuthorizeRoles_1] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[ControllerName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Account.AuthorizeRoles]  WITH CHECK ADD  CONSTRAINT [FK_Account.AuthorizeRoles_Account.ControllerName] FOREIGN KEY([ControllerName])
REFERENCES [dbo].[Account.ControllerName] ([ControllerName])
GO

ALTER TABLE [dbo].[Account.AuthorizeRoles] CHECK CONSTRAINT [FK_Account.AuthorizeRoles_Account.ControllerName]
GO

ALTER TABLE [dbo].[Account.AuthorizeRoles]  WITH CHECK ADD  CONSTRAINT [FK_Account.AuthorizeRoles_AspNetRoles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO

ALTER TABLE [dbo].[Account.AuthorizeRoles] CHECK CONSTRAINT [FK_Account.AuthorizeRoles_AspNetRoles]
GO


