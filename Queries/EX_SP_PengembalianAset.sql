USE [ManajemenAset]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[SP_PengembalianAset]
		@unique = N'08110012'

SELECT	'Return Value' = @return_value

GO
