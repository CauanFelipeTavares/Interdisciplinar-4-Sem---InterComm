USE [InterComm]
GO

INSERT INTO [dbo].[Locais]
           ([LocalNomeFantasia]
           ,[LocalRazaoSocial]
           ,[CNPJ]
           ,[TipoLocal]
           ,[ANTT]
           ,[IE]
           ,[CEP]
           ,[Logradouro]
           ,[Bairro]
           ,[Cidade]
           ,[Estado]
           ,[Numero]
           ,[Complemento])
    VALUES
    (
		'Agilicom'
        ,'Agilicom LTDA'
        ,'00004444333312'
        ,3
        ,'12340000777723'
        ,'123456789'
        ,'15054120'
        ,'Rua Cherubini'
        ,'Nazareth'
        ,'Rio Preto'
        ,'SP'
        , 110
        ,'Opa'
	)
GO

USE [InterComm]
GO

INSERT INTO [dbo].[Contratos]
           ([CodLocal]
           ,[CodCommodity]
		   ,[DataInicio]
           ,[Volume]
           ,[VolumeAtual]
           ,[VolumePendente]
		   ,[ValorUnitario]
           ,[Status])
     VALUES
    (
		1
        ,0
		,'2023-10-26'
        ,100
        ,default
        ,default
		,4.20
        ,default
	)
GO





