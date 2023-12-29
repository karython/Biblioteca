create database Biblioteca;
go
use Biblioteca;
go
create table Editora (
ID_Editora int primary key identity(1,1),
Nome_Editora varchar (80) not null
);

create table Autor (
ID_Autor int primary key identity(1,1),
Nome varchar (80) not null,
Nacionalidade varchar (30),
Genero varchar (15) not null
);

create table Livro (
ID_Livro int primary key identity(1,1),
Titulo varchar (80) not null,
Categoria Varchar (20) not null,
ID_Editora int
);

create table Autor_Livro (
ID int primary key identity(1,1),
DT_Publicacao date not null,
ID_Livro int,
ID_Autor int
);

alter table Livro
add constraint FK_Editora
foreign key (ID_Editora)
references Editora(ID_Editora) on delete cascade;

alter table Autor_Livro
add constraint FK_Livro
foreign key (ID_Livro)
references Livro(ID_Livro) on delete cascade;

alter table Autor_Livro
add constraint FK_Autor
foreign key (ID_Autor)
references Autor(ID_Autor) on delete cascade;