CREATE DATABASE API_CADASTRO_CLIENTE

USE API_CADASTRO_CLIENTE

CREATE TABLE Cliente(
	Id int primary key,
	Nome varchar(100),
	Email varchar(100) unique,
	Logotipo varbinary(Max),
)

CREATE TABLE Logradouro(
	Id int identity(1,1) primary key,
	Nome varchar(100),
	ClienteId int FOREIGN KEY (clienteId) REFERENCES Cliente(Id) ON DELETE CASCADE
)

CREATE TABLE Usuario(
	Id int identity(1,1) primary key,
	Nome varchar(100),
	Email varchar(100) unique,
	HashSenha varbinary(Max),
	SaltSenha varbinary(Max)
)

drop table Logradouro
drop table Cliente
drop table Usuario

delete from Cliente
delete from Logradouro
delete from Usuario

select * from Cliente
select * from Logradouro
select * from Usuario