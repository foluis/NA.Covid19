CREATE TABLE [dbo].[FileDetail]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Province_State] VARCHAR(50) NOT NULL, 
    [Country_Region] VARCHAR(50) NOT NULL, 
    [Last_Update] DATETIME2 NOT NULL, 
    [Lat] DECIMAL(13, 7) NOT NULL, 
    [Long] DECIMAL(13, 7) NOT NULL, 
    [Confirmed] INT NOT NULL, 
    [Deaths] INT NOT NULL, 
    [Recovered] INT NOT NULL, 
    [Active] INT NOT NULL, 
    [FileId] INT NOT NULL,
    CONSTRAINT[FK_FileDetail_FileId] FOREIGN KEY ([FileId])REFERENCES [FileDownloadInfo] (Id)
);
