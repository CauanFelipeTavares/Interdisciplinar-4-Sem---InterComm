----- Criação do Banco -----

CREATE DATABASE InterComm
GO

USE InterComm
GO

----- Criaçãoo das Tabelas -----

-------------------------------------------------------

CREATE TABLE Locais (
	IdLocal				int		primary key		identity,
	LocalNomeFantasia	varchar(60),
	LocalRazaoSocial	varchar(60)		not null,
	CNPJ				varchar(20)		not null, -- conferir quantos caracteres depois
	TipoLocal			int				not null,
	ANTT				varchar(30),	
	IE					varchar(30),
	CEP					varchar(8),
	Logradouro			varchar(30)		not null,
	Bairro				varchar(30),
	Cidade				varchar(30)		not null,
	Estado				varchar(30)		not null,
	Numero				int,
	Complemento			varchar(30),
)

CREATE TABLE Motoristas (
	IdMotorista		int		primary key		identity,
	CodMotorista	int		foreign key		references Locais(IdLocal),
	NomeMotorista	varchar(60) not null,
	CPF				varchar(60),
	CNH				varchar(60) not null,
)

CREATE TABLE Conjuntos (
	IdConjunto		int		primary key		identity, -- verificar campos e rela��es depois
	CodMotorista	int		foreign key 	references Motoristas(IdMotorista),
	PlacaA			varchar(7)	not null,
	PlacaB			varchar(7),
	PlacaC			varchar(7),
)

CREATE TABLE Contratos (
	IdContrato		int		primary key		identity,
	CodLocal		int		foreign key references Locais(IdLocal) not null,
	CodCommodity	int		not null,
	Volume			float	not null,
	VolumeAtual		float	default 0,
	VolumePendente	float	default 0,
	Status			int		default 0
)

CREATE TABLE OrdensDeCarregamento (
	IdOrdem				int		primary key		identity,
	CodMotorista		int		foreign key references Motoristas(IdMotorista) not null,
	CodConjunto			int		foreign key references Conjuntos(IdConjunto) not null,
	CodContrato			int		foreign key references Contratos(IdContrato) not null,
	CodTransportadora	int		foreign key references Locais(IdLocal) not null,
	CodDestino			int 	foreign key references Locais(IdLocal)	not null,
	Status				int		default 0,
)

CREATE TABLE NotaFiscal (
	IdNota		int		primary key		identity,
	CodOrdem	int		foreign key references OrdensDeCarregamento(IdOrdem) not null
)


----- Tabelas Complementares -----

-------------------------------------------------------
CREATE TABLE Responsaveis (
	IdResponsavel	int		primary key		identity,
	CodLocal		int		foreign key		references	Locais(IdLocal),
	Responsavel		varchar(60)	not null
)

CREATE TABLE Telefones (
	IdResponsavel	int		primary key		identity,
	CodLocal		int		foreign key		references	Locais(IdLocal),
	Telefone		varchar(11)	not null
)

CREATE TABLE Emails (
	IdResponsavel	int		primary key		identity,
	CodLocal		int		foreign key		references	Locais(IdLocal),
	Email			varchar(60)	not null
)


----- Cria��o das Views -----

-- CREATE VIEW vwOrdem
-- as
-- 	select 
-- 	M.MotoristaNome, M.CNH, Cont.Status, 
-- 	Cont.Volume, Cont.VolumeAtual, Cont.VolumePendente,
-- 	T.TransportadoraNomeFantasia, T.TransportadoraRazaoSocial,
	
-- 		from Motorista M, Conjunto Conj, Contrato Cont, Transportadora T, Usuario U

CREATE VIEW vw_Contrato
as
	select 
		Contratos.IdContrato, Contratos.CodCommodity, Contratos.Volume, Contratos.VolumeAtual, Contratos.VolumePendente, Contratos.Status,
		Locais.Rua, Locais.Bairro, Locais.Cidade, Locais.Estado, Locais.Numero, Locais.Complemento
	from
		Contratos
	inner join Locais ON Contratos.CodLocal = Locais.IdLocal

select * from vwContrato