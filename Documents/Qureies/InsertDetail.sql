

--SELECT * FROM information_schema.tables WHERE table_type = 'base table' AND table_schema='dbo';

DECLARE @Tables Table
(
	Id int PRIMARY KEY  IDENTITY NOT NULL,
	TableName Varchar(10) NOT NULL,
	DateTableName DATETIME NOT NULL
)

INSERT INTO @Tables
SELECT TABLE_NAME, CONVERT(datetime2,TABLE_NAME) 
FROM information_schema.tables 
WHERE table_type = 'base table' 
	AND table_schema='dbo'
	AND LEN(TABLE_NAME) = 10
ORDER BY CONVERT(datetime2,TABLE_NAME) 

--SELECT * FROM @Tables ORDER BY CONVERT(datetime2,DateTableName) 
/*
--Select * FROM [dbo].[Details]
--Select DISTINCT ReportDateName,CONVERT(datetime2,ReportDateName)  FROM [dbo].[Details] ORDER BY CONVERT(datetime2,ReportDateName) 
TRUNCATE TABLE [dbo].[Details]  
*/

DECLARE @Counter INT = 1
DECLARE @CurrentName Varchar(10)

DECLARE @sqlCommand Varchar(1000)

WHILE @Counter <= (SELECT COUNT(1) FROM @Tables)
BEGIN
	SET @CurrentName = (SELECT TableName FROM @Tables WHERE Id = @Counter)
	--PRINT @CurrentName

	SET @sqlCommand = 'INSERT INTO Details (Province_State,Country_Region,Last_Update,Latitude,Longitude,Confirmed,Deaths,Recovered,Active,DownloadId,ReportDateName) ' +
	'SELECT Province_State,Country_Region,Last_Update,null,null,Confirmed,Deaths,Recovered,null,(SELECT ID FROM Downloads WHERE DownloadedFileName = ''' + @CurrentName + '.CSV''),''' + @CurrentName + ''' ' +
	'from [dbo].[' + @CurrentName + ']'

	--PRINT @sqlCommand

	EXEC(@sqlCommand)

	SET @Counter = @Counter + 1
END






Select * FROM [dbo].[Details]





--INSERT INTO Details (Province_State,Country_Region,Last_Update,Latitude,Longitude,Confirmed,Deaths,Recovered,Active,DownloadId,ReportDateName)
--SELECT Province_State,Country_Region,Last_Update,null,null,Confirmed,Deaths,Recovered,null,(SELECT ID FROM Downloads WHERE DownloadedFileName = '01-22-2020.CSV'),'01-22-2020'
--from [dbo].[01-22-2020]





