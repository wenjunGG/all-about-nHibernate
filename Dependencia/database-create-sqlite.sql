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

create table Contato(
	pessoa_id integer not null primary key 
	, celular varchar(10)
	, fone varchar(10)
	, email varchar (255)
	, site varchar(255)
	, foreign key (pessoa_id) references Pessoa(id)
);

create table Usuario(
	pessoa_id integer primary key
	,login varchar(255) not null
	, senha varchar(12) not null
	, ultimoAcesso text null
	, foreign key(pessoa_id) references Pessoa(id)
);

create table Produtor(
	pessoa_id integer primary key
	, cargo varchar(255) null
	, comissao numeric null
	, salario numeric null
	, tipo varchar(15)
	, foreign key(pessoa_id) references Pessoa(id)
);

create table Artista(
	pessoa_id integer primary key
	, cache money null
	, nomeArtistico varchar(255) null
);

create table Estilo(
	id integer not null primary key autoincrement
	, descricao varchar(255)
);

create table EstiloArtista(
	artista_id integer not null
	, estilo_id integer not null
	, primary key(artista_id, estilo_id)
	, foreign key (artista_id) references Artista(pessoa_id)
	, foreign key (estilo_id) references estilo(id)
);

create table Album(
	id integer not null primary key autoincrement
	, artista_id integer
	, titiulo varchar(255)
	, capa varchar(255)
	, dataLancamento text
	, avaliacao integer
	, foreign key (artista_id) references Artista(pessoa_id)
);

create table Musica(
	id integer not null primary key autoincrement
	, album_id integer
	, titulo varchar(255)
	, avaliacao integer
	, duracaoSegudos integer
	, foreign key (album_id) references Album(id)
);