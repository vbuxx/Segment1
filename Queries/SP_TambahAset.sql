
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_TambahAset
	@name varchar(25),
	@detail varchar(50),
	@stock int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	DECLARE @asetid int;

	

	INSERT INTO Aset
	VALUES (@name,@detail);

	SELECT @asetid = Max(id) FROM Aset;

	INSERT INTO Inventaris_Aset
	VALUES (@asetid+1, GETDATE(), @stock, @stock);


    -- Insert statements for procedure here
	SELECt * FROM Aset;
	SELECT * FROM Inventaris_Aset;
END
GO
