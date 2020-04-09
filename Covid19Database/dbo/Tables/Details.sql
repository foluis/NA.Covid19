CREATE TABLE [dbo].[Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Province_State] [varchar](200) NULL,
	[Country_Region] [varchar](100) NULL,
	[Last_Update] [datetime2](7) NOT NULL,
	[Latitude] [decimal](12, 8) NULL,
	[Longitude] [decimal](12, 8) NULL,
	[Confirmed] [int] NULL,
	[Deaths] [int] NULL,
	[Recovered] [int] NULL,
	[Active] [int] NULL,
	[DownloadId] [int] NOT NULL,
	[ReportDateName] [varchar](50) NULL,
 CONSTRAINT [PK_Details] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Details]  WITH CHECK ADD  CONSTRAINT [FK_Details_Downloads_DownloadId] FOREIGN KEY([DownloadId])
REFERENCES [dbo].[Downloads] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Details] CHECK CONSTRAINT [FK_Details_Downloads_DownloadId]
GO
