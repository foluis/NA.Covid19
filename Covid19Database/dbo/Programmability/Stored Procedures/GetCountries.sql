/*-- =============================================
EXEC GetCountries 
-- =============================================*/
CREATE PROCEDURE [dbo].[GetCountries]
AS
BEGIN
	
	SET NOCOUNT ON;
	
	SELECT DISTINCT Country_Region AS Country		
	FROM dbo.Details
	ORDER BY Country_Region

END