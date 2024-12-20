USE master
GO

CREATE DATABASE Equipments2024DB

GO
USE Equipments2024DB
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 2/29/2024 9:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Email] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[Birthday] [datetime] NULL,
	[Status] [nvarchar](10) NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipments]    Script Date: 2/29/2024 9:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipments](
	[EqID] [int] NOT NULL,
	[EqCode] [nvarchar](50) NOT NULL,
	[EqName] [nvarchar](150) NULL,
	[Description] [nvarchar](200) NULL,
	[Model] [nvarchar](50) NULL,
	[SupplierName] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Quantity] [int] NULL,
	[Status] [int] NULL,
	[RoomID] [int] NULL,
 CONSTRAINT [PK_Equipments] PRIMARY KEY CLUSTERED 
(
	[EqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 2/29/2024 9:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomID] [int] NOT NULL,
	[RoomName] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](150) NULL,
	[Status] [nvarchar](10) NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Accounts] ([Email], [UserName], [Password], [FullName], [Birthday], [Status], [RoleID]) VALUES (N'admin@fe.com', N'admin', N'@5', N'Admin', CAST(N'1990-09-16T00:00:00.000' AS DateTime), N'active', 1)
INSERT [dbo].[Accounts] ([Email], [UserName], [Password], [FullName], [Birthday], [Status], [RoleID]) VALUES (N'manager@fe.com', N'manager', N'@5', N'Manager', CAST(N'1980-12-12T00:00:00.000' AS DateTime), N'active', 3)
INSERT [dbo].[Accounts] ([Email], [UserName], [Password], [FullName], [Birthday], [Status], [RoleID]) VALUES (N'staff@fe.com', N'staff', N'@5', N'Staff', CAST(N'1970-10-10T00:00:00.000' AS DateTime), N'active', 2)
INSERT [dbo].[Accounts] ([Email], [UserName], [Password], [FullName], [Birthday], [Status], [RoleID]) VALUES (N'student@fe.com', N'student', N'@5', N'Student', CAST(N'1989-11-11T00:00:00.000' AS DateTime), N'active', 4)
GO
INSERT [dbo].[Equipments] ([EqID], [EqCode], [EqName], [Description], [Model], [SupplierName], [CreatedAt], [UpdatedAt], [Quantity], [Status], [RoomID]) VALUES (1, N'MQ001', N'Maqueen Robot', N'Robot', N'MX2023', N'HShop', CAST(N'2021-02-27T00:00:00.000' AS DateTime), CAST(N'2024-02-27T00:00:00.000' AS DateTime), 2, 1, 1)
INSERT [dbo].[Equipments] ([EqID], [EqCode], [EqName], [Description], [Model], [SupplierName], [CreatedAt], [UpdatedAt], [Quantity], [Status], [RoomID]) VALUES (2, N'TA001', N'Table', N'Table', N'TA2024', N'HoaPhat', CAST(N'2022-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime), 35, 1, 1)
INSERT [dbo].[Equipments] ([EqID], [EqCode], [EqName], [Description], [Model], [SupplierName], [CreatedAt], [UpdatedAt], [Quantity], [Status], [RoomID]) VALUES (3, N'M001', N'Monitor', N'Monitor', N'LG008', N'LG', CAST(N'2022-01-02T00:00:00.000' AS DateTime), CAST(N'2022-01-02T00:00:00.000' AS DateTime), 1, 1, 1)
INSERT [dbo].[Equipments] ([EqID], [EqCode], [EqName], [Description], [Model], [SupplierName], [CreatedAt], [UpdatedAt], [Quantity], [Status], [RoomID]) VALUES (4, N'MQ002', N'Maqueen Robot', N'Robot', N'MX2023', N'HShop', CAST(N'2023-02-27T00:00:00.000' AS DateTime), CAST(N'2024-02-27T00:00:00.000' AS DateTime), 2, 1, 2)
INSERT [dbo].[Equipments] ([EqID], [EqCode], [EqName], [Description], [Model], [SupplierName], [CreatedAt], [UpdatedAt], [Quantity], [Status], [RoomID]) VALUES (5, N'TA002', N'Table', N'Table', N'TA2024', N'HoaPhat', CAST(N'2024-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-01T00:00:00.000' AS DateTime), 20, 1, 2)
INSERT [dbo].[Equipments] ([EqID], [EqCode], [EqName], [Description], [Model], [SupplierName], [CreatedAt], [UpdatedAt], [Quantity], [Status], [RoomID]) VALUES (6, N'M002', N'Monitor', N'Monitor', N'LG008', N'LG', CAST(N'2024-01-02T00:00:00.000' AS DateTime), CAST(N'2024-01-02T00:00:00.000' AS DateTime), 1, 1, 2)
INSERT [dbo].[Equipments] ([EqID], [EqCode], [EqName], [Description], [Model], [SupplierName], [CreatedAt], [UpdatedAt], [Quantity], [Status], [RoomID]) VALUES (7, N'MQ003', N'Maqueen Robot', N'Robot', N'MX2023', N'HShop', CAST(N'2024-02-27T00:00:00.000' AS DateTime), CAST(N'2024-02-27T00:00:00.000' AS DateTime), 4, 1, 3)
INSERT [dbo].[Equipments] ([EqID], [EqCode], [EqName], [Description], [Model], [SupplierName], [CreatedAt], [UpdatedAt], [Quantity], [Status], [RoomID]) VALUES (8, N'TA003', N'Table', N'Table', N'TA2024', N'HoaPhat', CAST(N'2024-02-28T00:00:00.000' AS DateTime), CAST(N'2024-02-28T00:00:00.000' AS DateTime), 10, 1, 3)
INSERT [dbo].[Equipments] ([EqID], [EqCode], [EqName], [Description], [Model], [SupplierName], [CreatedAt], [UpdatedAt], [Quantity], [Status], [RoomID]) VALUES (9, N'M003', N'Monitor', N'Monitor', N'LG008', N'LG', CAST(N'2024-02-29T00:00:00.000' AS DateTime), CAST(N'2024-02-29T00:00:00.000' AS DateTime), 1, 1, 3)
INSERT [dbo].[Equipments] ([EqID], [EqCode], [EqName], [Description], [Model], [SupplierName], [CreatedAt], [UpdatedAt], [Quantity], [Status], [RoomID]) VALUES (10, N'MQ003', N'Maqueen Robot', N'Robot', N'MX2023', N'HShop', CAST(N'2024-03-01T00:00:00.000' AS DateTime), CAST(N'2024-03-01T00:00:00.000' AS DateTime), 3, 1, 4)
INSERT [dbo].[Equipments] ([EqID], [EqCode], [EqName], [Description], [Model], [SupplierName], [CreatedAt], [UpdatedAt], [Quantity], [Status], [RoomID]) VALUES (11, N'TA003', N'Table', N'Table', N'TA2024', N'HoaPhat', CAST(N'2024-03-02T00:00:00.000' AS DateTime), CAST(N'2024-03-02T00:00:00.000' AS DateTime), 40, 1, 4)
INSERT [dbo].[Equipments] ([EqID], [EqCode], [EqName], [Description], [Model], [SupplierName], [CreatedAt], [UpdatedAt], [Quantity], [Status], [RoomID]) VALUES (12, N'M003', N'Monitor', N'Monitor', N'LG008', N'LG', CAST(N'2024-03-03T00:00:00.000' AS DateTime), CAST(N'2024-03-03T00:00:00.000' AS DateTime), 1, 1, 5)
GO
INSERT [dbo].[Rooms] ([RoomID], [RoomName], [Location], [Status]) VALUES (1, N'C605', N'NVH', N'active')
INSERT [dbo].[Rooms] ([RoomID], [RoomName], [Location], [Status]) VALUES (2, N'C601', N'NVH', N'active')
INSERT [dbo].[Rooms] ([RoomID], [RoomName], [Location], [Status]) VALUES (3, N'C407', N'NVH', N'active')
INSERT [dbo].[Rooms] ([RoomID], [RoomName], [Location], [Status]) VALUES (4, N'C416', N'NVH', N'active')
INSERT [dbo].[Rooms] ([RoomID], [RoomName], [Location], [Status]) VALUES (5, N'C611', N'NVH', N'active')
GO
ALTER TABLE [dbo].[Equipments]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Equipments] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Rooms] ([RoomID])
GO
ALTER TABLE [dbo].[Equipments] CHECK CONSTRAINT [FK_Rooms_Equipments]
GO
