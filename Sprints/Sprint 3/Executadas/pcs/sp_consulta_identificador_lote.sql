USE [JobSetup]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_identificador_lote]   Script Date: 09/02/2021 09:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_consulta_identificador_lote]
		@id_maquina int = NULL
AS
BEGIN
	SELECT top 1 vc_identificador_lote1
                FROM  [PCSPRODUCAO].[TrazabilidadBSBR].[dbo].[tbl_Hist_Lote] With (NOLOCK)
                where len([vc_Identificador_Lote1]) = 14 and [i_Fk_Maquina] = @id_maquina
                order by i_Pk_Lote desc;
	
END;
