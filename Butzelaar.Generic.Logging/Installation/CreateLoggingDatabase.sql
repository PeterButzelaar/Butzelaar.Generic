USE [Logging]
GO

/****** Object:  Table [dbo].[Log]    Script Date: 24-5-2013 22:30:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Log](
	[Id] [uniqueidentifier] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Thread] [nvarchar](255) NOT NULL,
	[Level] [nvarchar](50) NOT NULL,
	[Host] [nvarchar](50) NOT NULL,
	[Logger] [nvarchar](255) NOT NULL,
	[Message] [nvarchar](2000) NOT NULL,
	[Details] [nvarchar](4000) NULL,
	[Exception] [nvarchar](2000) NULL,
	[StackTrace] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Log] ADD  CONSTRAINT [DF_Log_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO


