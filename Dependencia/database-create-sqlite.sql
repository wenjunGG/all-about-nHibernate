create table Pessoa (
	id integer not null primary key autoincrement
	, tipo varchar(1) not null -- valores possiveis F ou J
	, cnpj varchar(14) null
	, cpf varchar(11) null	
	, razaoSocial varchar(255) null
	, nomeFantasia varchar(255) null
	, nome varchar(255) null
	, sobrenome varchar(255) null	
	, dataAbertura text null
	, dataNascimnento text null
	, sexo varchar(1) null
	, endereco text
);

create table Cidade(
	id integer not null primary key autoincrement
	, nome varchar(255)
	, uf varchar(2)
);

create table Estilo(
	id integer not null primary key autoincrement
	, descricao varchar(255)
);

create table Artista(
	id integer primary key autoincrement
	cidade_id integer not null
	, nome varchar(255) null
	, sobrenome varchar(255) null
	, datanascimento text null
	, foreign key(cidade_id) references Cidade(id)
);

create table EstiloArtista(
	artista_id int not null
	, estilo_id int not null
	, primary key(artista_id, estilo_id)
	, foreign key (artista_id) references Artista(id)
	, foreign key (estilo_id) references estilo(id)
);

create table Album(
	id integer not null primary key autoincrement
	, artista_id integer
	, titiulo varchar(255)
	, capa varchar(255)
	, dataLancamento text
	, avaliacao integer
	, foreign key (artista_id) references Artista(id)
);

create table Musica(
	id integer not null primary key autoincrement
	, album_id integer
	, titulo varchar(255)
	, avaliacao integer
	, duracaoSegudos integer
	, foreign key (album_id) references Album(id)
);