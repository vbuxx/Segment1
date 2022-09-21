SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_PeminjamanAset 
	@karyawanid int,
	@asetid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @stockterakhir int, @stockawal int,@unique varchar(50);
    -- Insert statements for procedure here
	SET @unique =replace(convert(varchar, getdate(),108),':','')+ CAST(@asetid AS VARCHAR(5)) +CAST(@karyawanid AS VARCHAR(5));
	--@unique = CONCAT(CONVERT(varchar(10),@asetid),CONVERT(varchar(10),@karyawanid)) ;

	--Insert to aset_karyawan
	INSERT INTO Peminjaman_Aset VALUES (@unique,@asetid,@karyawanid,GETDATE(),NULL);
	
	--Cek stok terakhir
	SELECT TOP 1 @stockawal = stock_awal , @stockterakhir = stock_sekarang FROM Inventaris_Aset WHERE aset_id = @asetid ORDER BY tgl_update DESC;

	-- Insert to Inventaris_Aset
	UPDATE [dbo].[Inventaris_Aset]
	SET [tgl_update] = GETDATE()
		  ,[stock_awal] = @stockawal
		  ,[stock_sekarang] = @stockterakhir-1
	 WHERE aset_id=@asetid;
	SELECT * FROM Inventaris_Aset;
END
GO
