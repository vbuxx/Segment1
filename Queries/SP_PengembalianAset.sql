SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_PengembalianAset
	@unique varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @stockterakhir int, @stockawal int,	@karyawanid int, @asetid int;
    -- Insert statements for procedure here

	--Insert to aset_karyawan
	SELECT @karyawanid = karyawan_id, @asetid = aset_id FROM Peminjaman_Aset WHERE unique_key = @unique;

	UPDATE [dbo].[Peminjaman_Aset]
	   SET [tgl_kembali] = GETDATE(),
	   [unique_key] = 'X'+@unique
	 WHERE unique_key = @unique;



	--Cek stok terakhir
	SELECT TOP 1 @stockawal = stock_awal , @stockterakhir = stock_sekarang FROM Inventaris_Aset WHERE aset_id = @asetid ORDER BY tgl_update DESC;

	-- Insert to Inventaris_Aset

	UPDATE [dbo].[Inventaris_Aset]
	   SET [tgl_update] = GETDATE()
		  ,[stock_awal] = @stockawal
		  ,[stock_sekarang] = @stockterakhir+1
	 WHERE aset_id=@asetid;

	 SELECT * FROM Peminjaman_Aset;
	
END
GO

