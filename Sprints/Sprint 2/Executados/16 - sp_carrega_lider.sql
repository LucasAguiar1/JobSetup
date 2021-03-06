USE [JobSetupPreprod]
GO
/****** Object:  StoredProcedure [dbo].[sp_carrega_lider]    Script Date: 22/01/2021 09:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_carrega_lider] (@departamento int)
as 
begin 
SElect distinct
			U.chrfirstname,
			Case When len(replace(FP.chrfunction,'JOBSETUP_LIDER','')) > 4 then ''
			else replace(FP.chrfunction,'JOBSETUP_LIDER','') End  as departamento
			,CAse When FP.chrfunction  like '%lider%' then 'LIDER'
			Else replace(FP.chrfunction,'JOBSETUP_','') end as Funcao
			,U.chrlogin as 'login'
			
			Into #Resultado

			FROM [HOM_SQL-BR-MSA\HOM01].[ISAC_1].[dbo].tblUser_Profile UP (NOLOCK)
								INNER JOIN [HOM_SQL-BR-MSA\HOM01].[ISAC_1].[dbo].tblProfile P (NOLOCK)			ON UP.intp_id = P.intp_id 
								INNER JOIN [HOM_SQL-BR-MSA\HOM01].[ISAC_1].[dbo].tblSystem_Profile SP (NOLOCK)	ON P.intp_id = SP.intp_id 
								INNER JOIN [HOM_SQL-BR-MSA\HOM01].[ISAC_1].[dbo].tblFunction_Profile FP  (NOLOCK) ON P.intp_id = FP.intp_id AND SP.ints_id = FP.ints_id
								inner join [HOM_SQL-BR-MSA\HOM01].[ISAC_1].[dbo].tblUser U (NOLOCK) on UP.chrlogin = U.chrlogin
	Where 	 
	UP.ints_id = 117
	and FP.chrfunction like '%lider%'
	

	SElect * from #Resultado where departamento = @departamento


end
/*
	select * from [HOM_SQL-BR-MSA\HOM01].[ISAC_1].[dbo].tblUser_Profile
	select * from [HOM_SQL-BR-MSA\HOM01].[ISAC_1].[dbo].tblUser
*/
