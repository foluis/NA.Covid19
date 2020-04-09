--Select * from [dbo].[Downloads]
--DELETE [dbo].[Downloads] 

--INSERT INTO Downloads (DownloadedDate,DownloadedFileName)
--VALUES
-- (GETDATE(),'02-29-2020.csv')

DECLARE @Counter INT = 1
DECLARE @FileName Varchar(50)
DECLARE @DayNumber Varchar(2)

DECLARE @Month Varchar(2) = '01'
DECLARE @MaxDays int = 31

WHILE @Counter <= 7
BEGIN

	IF(@Counter <= 9)
	BEGIN
		SET @DayNumber = '0' + CONVERT(VARCHAR(1),@Counter)
	END
	ELSE
	BEGIN
		SET @DayNumber = CONVERT(VARCHAR(2),@Counter)
	END
	
	SET @FileName = '04-' + @DayNumber + '-2020.csv'

	INSERT INTO [Downloads]
	(DownloadedDate,DownloadedFileName)
	VALUES
		(GETDATE(),@FileName)

	SET @Counter = @Counter + 1

END

--Select * from [dbo].[Downloads]