create database dbEmprestimo;
use dbEmprestimo;

create table tbUsuario(
CodUsu int primary key auto_increment,
NomeUsu varchar(50)
);

create table tbLivro(
CodLivro int primary key auto_increment,
NomeLivro varchar(50),
ImagemLivro varchar(255)
);

create table tbEmprestimo(
CodEmp int Primary key auto_increment,
DataEmp varchar(20),
DataDev varchar(20),
CodUsu int references tbUsuario(CodUsu)
);

create table tbItensEmp(
CodItem int primary key auto_increment,
CodEmp int references tbEmprestimo(CodEmp),
CodLivro int references tbLivro(CodLivro)
);

select * from tbItensEmp;

insert into tbUsuario values (default, 'Nilson'), (default, 'Bruno')