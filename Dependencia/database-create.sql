--create database ESTUDONH

use ESTUDONH
--drop database ESTUDONH

go
begin tran -- commit rollback

create table Pessoa (
	id int not null primary key identity
	, tipo char not null -- valores possiveis F ou J
	, cnpj varchar(14) null
	, cpf varchar(11) null	
	, razaoSocial varchar(255) null
	, nomeFantasia varchar(255) null
	, nome varchar(255) null
	, sobrenome varchar(255) null	
	, dataAbertura date null
	, dataNascimnento date null
	, sexo char(1) null
)

create table Contato(
	pessoa_id int not null primary key -- vai ser o id do artista
	, celular varchar(10)
	, fone varchar(10)
	, email varchar (255)
	, site varchar(255)
	, foreign key (pessoa_id) references Pessoa(id)
)

create table Usuario(
	pessoa_id int primary key
	,login varchar(255) not null
	, senha varchar(12) not null
	, ultimoAcesso Date null
	, foreign key(pessoa_id) references Pessoa(id)
)

create table Produtor(
	pessoa_id int primary key
	, cargo varchar(255) null
	, comissao money null
	, salario money null
	, tipo varchar(15)
	, foreign key(pessoa_id) references Pessoa(id)
)

create table Artista(
	pessoa_id int primary key
	, cache money null
	, nomeArtistico varchar(255) null
)

create table Estilo(
	id int not null primary key identity
	, descricao varchar(255)
)

create table EstiloArtista(
	artista_id int not null
	, estilo_id int not null
	, primary key(artista_id, estilo_id)
	, foreign key (artista_id) references Artista(pessoa_id)
	, foreign key (estilo_id) references estilo(id)
)

create table Album(
	id int not null primary key identity
	, artista_id int
	, titiulo varchar(255)
	, capa varchar(255)
	, dataLancamento DateTime
	, avaliacao int
	, foreign key (artista_id) references Artista(pessoa_id)
)

create table Musica(
	id int not null primary key identity
	, album_id int
	, titulo varchar(255)
	, avaliacao int
	, duracaoSegudos int
	, foreign key (album_id) references Album(id)
)