USE [ManajemenAset]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[SP_PeminjamanAset]
		@karyawanid = 2,
		@asetid = 1

SELECT	'Return Value' = @return_value

GO
