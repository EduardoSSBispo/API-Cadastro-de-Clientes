CREATE DATABASE API_CADASTRO_CLIENTE

USE API_CADASTRO_CLIENTE

CREATE TABLE Cliente(
	Id int primary key,
	Nome varchar(100),
	Email varchar(100) unique not null,
	Logotipo varbinary(Max),
)

CREATE TABLE Logradouro(
	Id int identity(1,1) primary key,
	Nome varchar(100),
	ClienteId int not null 
	FOREIGN KEY (clienteId) REFERENCES Cliente(Id) ON DELETE CASCADE
)
-- Índice no campo ClienteId para otimizar JOINs e filtros
CREATE INDEX IX_Logradouro_ClienteId ON Logradouro (ClienteId);

CREATE TABLE Usuario(
	Id int identity(1,1) primary key,
	Nome varchar(100),
	Email varchar(100) unique not null,
	HashSenha varbinary(Max) not null,
	SaltSenha varbinary(Max) not null
)