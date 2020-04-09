CREATE PROCEDURE [dbo].[GetHistoricalReport]	
	@Country_Region varchar(200) = null	
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @HistoricalReports TABLE
	(
		Id INT,
		Country VARCHAR(100)
		,LastUpdate DateTime
		,Confirmed INT
		,Deaths INT
		,Recovered INT
		,Active INT
	)
	
	INSERT INTO @HistoricalReports
	SELECT ROW_NUMBER() OVER(ORDER BY LastUpdate) AS Id, 
	Country, LastUpdate, ISNULL(SUM(Confirmed),0) Confirmed, ISNULL(SUM(Deaths),0) Deaths, ISNULL(SUM(Recovered),0) Recovered, ISNULL(SUM(Active),0) Active
	FROM (
		SELECT Country_Region AS Country
			,FORMAT(Last_Update, 'yyyy/MM/dd') as LastUpdate
			,Confirmed
			,Deaths
			,Recovered
			,Active
		FROM Details
	) Detail1	
	WHERE (Country = @Country_Region OR @Country_Region IS NULL)	
	GROUP BY Country,LastUpdate	

	SELECT Id,Country ,LastUpdate ,Confirmed ,Deaths ,Recovered ,Active 
	FROM @HistoricalReports
	ORDER BY Country,LastUpdate

END