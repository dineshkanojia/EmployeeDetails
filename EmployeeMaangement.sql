USE [EmployeeLogin]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 15-04-2022 17:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](250) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [varchar](250) NOT NULL,
	[LastName] [varchar](250) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[Mobile] [varchar](15) NULL,
	[Address1] [varchar](250) NOT NULL,
	[Address2] [varchar](250) NULL,
	[Photo] [varchar](250) NULL,
	[Postcode] [varchar](25) NOT NULL,
	[Desgination] [varchar](250) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[Status] [int] NOT NULL,
	[Manager] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeLeave]    Script Date: 15-04-2022 17:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLeave](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[EmployeeName] [varchar](max) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[LeaveType] [varchar](50) NOT NULL,
	[RequestDate] [date] NOT NULL,
	[ApprovedDate] [date] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[ApprovedBy] [int] NOT NULL,
	[IsCancelled] [bit] NOT NULL,
	[Comments] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmployeeLeave] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMapping]    Script Date: 15-04-2022 17:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMapping](
	[RoleId] [int] NOT NULL,
	[UserId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 15-04-2022 17:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [UserName], [Password], [FirstName], [LastName], [Email], [Mobile], [Address1], [Address2], [Photo], [Postcode], [Desgination], [DOB], [IsDelete], [Status], [Manager]) VALUES (1, N'admin', N'admin123', N'Admin', N'Admni', N'admin@gmail.com', N'1478520369', N'Test', N'test', N'test', N'415236', N'Admin', CAST(N'1986-02-14T00:00:00.000' AS DateTime), 0, 1, NULL)
INSERT [dbo].[Employee] ([Id], [UserName], [Password], [FirstName], [LastName], [Email], [Mobile], [Address1], [Address2], [Photo], [Postcode], [Desgination], [DOB], [IsDelete], [Status], [Manager]) VALUES (4, N'dinesh', N'dinesh123', N'Dinesh', N'Kanojiya', N'dinesh@123', N'7418529630', N'Test 1', N'Test 1', N'Test 1', N'74185', N'Developer', CAST(N'2022-04-13T16:10:00.003' AS DateTime), 0, 1, NULL)
INSERT [dbo].[Employee] ([Id], [UserName], [Password], [FirstName], [LastName], [Email], [Mobile], [Address1], [Address2], [Photo], [Postcode], [Desgination], [DOB], [IsDelete], [Status], [Manager]) VALUES (5, N'dinesh', N'dinesh123', N'Dinesh', N'Kanojiya', N'dinesh@123', N'7418529630', N'Test 1', N'Test 1', N'Test 1', N'74185', N'Developer', CAST(N'2022-04-13T16:10:00.003' AS DateTime), 0, 1, NULL)
INSERT [dbo].[Employee] ([Id], [UserName], [Password], [FirstName], [LastName], [Email], [Mobile], [Address1], [Address2], [Photo], [Postcode], [Desgination], [DOB], [IsDelete], [Status], [Manager]) VALUES (6, N'teena', N'teena123', N'Teena', N'Kholi', N'teena@123', N'7418529630', N'Test 2', N'Test 3', N'Test 4', N'74185296', N'DevOps', CAST(N'2022-04-13T16:10:00.003' AS DateTime), 0, 1, NULL)
INSERT [dbo].[Employee] ([Id], [UserName], [Password], [FirstName], [LastName], [Email], [Mobile], [Address1], [Address2], [Photo], [Postcode], [Desgination], [DOB], [IsDelete], [Status], [Manager]) VALUES (7, N'teena', N'teena123', N'Teena', N'Kholi', N'teena111@123', N'7418529630', N'Test 2', N'Test 3', N'Test 4', N'74185296', N'DevOps', CAST(N'2022-04-13T16:10:00.003' AS DateTime), 0, 1, NULL)
INSERT [dbo].[Employee] ([Id], [UserName], [Password], [FirstName], [LastName], [Email], [Mobile], [Address1], [Address2], [Photo], [Postcode], [Desgination], [DOB], [IsDelete], [Status], [Manager]) VALUES (8, N'Nitin', N'nitin123', N'Nitin', N'Singh', N'nitin@123', N'7896321541', N'Address 1', N'Address 2', N'0', N'748596', N'Testing', CAST(N'2022-04-02T00:00:00.000' AS DateTime), 0, 1, NULL)
INSERT [dbo].[Employee] ([Id], [UserName], [Password], [FirstName], [LastName], [Email], [Mobile], [Address1], [Address2], [Photo], [Postcode], [Desgination], [DOB], [IsDelete], [Status], [Manager]) VALUES (9, N'Nandini', N'admin123', N'Nandini', N'Nandini', N'nandini@123', N'852963741', N'Add1', N'Add2', N'Dinesh Visa Passport.jpg', N'748596', N'Developer', CAST(N'2022-12-03T00:00:00.000' AS DateTime), 0, 1, NULL)
INSERT [dbo].[Employee] ([Id], [UserName], [Password], [FirstName], [LastName], [Email], [Mobile], [Address1], [Address2], [Photo], [Postcode], [Desgination], [DOB], [IsDelete], [Status], [Manager]) VALUES (10, N'test1', N'123456', N'Test', N'Test ', N'dfsdds1@123', N'7418529630', N'Test 2', N'Test 3', N'sample.jpg', N'74185296', N'DevOps', CAST(N'2022-04-13T16:10:00.003' AS DateTime), 0, 1, NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
INSERT [dbo].[RoleMapping] ([RoleId], [UserId]) VALUES (1, 1)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (2, N'Manager')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (3, N'Employee')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
ALTER TABLE [dbo].[EmployeeLeave]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeLeave_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeLeave] CHECK CONSTRAINT [FK_EmployeeLeave_Employee]
GO
ALTER TABLE [dbo].[RoleMapping]  WITH CHECK ADD  CONSTRAINT [FK_RoleMapping_Employee] FOREIGN KEY([UserId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[RoleMapping] CHECK CONSTRAINT [FK_RoleMapping_Employee]
GO
ALTER TABLE [dbo].[RoleMapping]  WITH CHECK ADD  CONSTRAINT [FK_RoleMapping_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[RoleMapping] CHECK CONSTRAINT [FK_RoleMapping_Roles]
GO
