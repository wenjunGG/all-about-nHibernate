create database ESTUDONH

create table Estilo(
	id int not null primary key identity
	, descricao varchar(255)
)

create table Artista(
	id int not null primary key identity
	, estilo_id int
	, nome varchar(255)
	, sobrebnome varchar(255)
	, sexo char(1)
	, dataNascimento DateTime
)

create table EstiloArtista(
	artista_id int not null
	, estilo_id int not null
	, primary key(artista_id, estilo_id)
	, foreign key (artista_id) references artista(id)
	, foreign key (estilo_id) references estilo(id)
)

create table Contato(
	id int not null -- vai ser o id do artista
	, celular varchar(10)
	, fone varchar(10)
	, email varchar (255)
	, site varchar(255)
)

create table Album(
	id int not null primary key identity
	, artista_id int
	, titiulo varchar(255)
	, capa varchar(255)
	, dataLancamento DateTime
	, avaliacao int
)

create table Musica(
	id int not null primary key identity
	, album_id int
	, titulo varchar(255)
	, avaliacao int
	, duracaoSegudos int
)