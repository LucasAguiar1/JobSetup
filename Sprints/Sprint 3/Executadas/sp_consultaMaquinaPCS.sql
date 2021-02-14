USE [JobSetupPREPROD]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_maquinas]    Script Date: 05/02/2021 07:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC sp_consultaMaquinaPCS 'Banb'
CREATE PROCEDURE [dbo].[sp_consultaMaquinaPCS]
		@DESCRICAO NVARCHAR(MAX)
AS
BEGIN
	
	Select 
	i_Pk_Maquina
	,vc_Descripcion 
	from [PCSPRODUCAO].Trazabilidadbsbr.dbo.tbl_maquina 
	where vc_Descripcion like '%'+@DESCRICAO+'%' 

END;

