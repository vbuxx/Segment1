SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_TambahPeminjamanAset 
	@karyawanid int,
	@asetid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @stockterakhir int, @stockawal int;
    -- Insert statements for procedure here


	--Insert to aset_karyawan
	INSERT INTO Peminjaman_Aset VALUES (@asetid,@karyawanid,GETDATE(),NULL);
	
	--Cek stok terakhir
	SELECT TOP 1 @stockawal = stock_awal , @stockterakhir = stock_sekarang FROM Inventaris_Aset WHERE aset_id = @asetid ORDER BY tgl_update DESC;

	-- Insert to Inventaris_Aset
	INSERT INTO Inventaris_Aset VALUES (@asetid,GETDATE(),@stockawal,@stockterakhir-1);
	SELECT * FROM Inventaris_Aset;
END
GO
