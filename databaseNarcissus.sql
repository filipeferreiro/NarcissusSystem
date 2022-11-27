DROP DATABASE IF EXISTS dbNarcissus;
CREATE DATABASE IF NOT EXISTS dbNarcissus;
USE dbNarcissus;
CREATE TABLE tbUsuario(
    UsuarioID INT PRIMARY KEY AUTO_INCREMENT,
    UsuNome VARCHAR(100) NOT NULL,
    Login VARCHAR(50) NOT NULL,
    Senha VARCHAR(100) NOT NULL
);
SELECT * FROM tbUsuario;
delimiter $$
create procedure spInsertUsuario(vUsuNome varchar(100) ,Login varchar (50), Senha varchar(100))
begin
insert into tbUsuario(UsuNome,Login,Senha)
    values(vUsuNome,Login,Senha);
End $$
delimiter $$
create procedure spSelectLogin(vLogin varchar(50))
begin
select Login from tbUsuario where Login = vLogin;
End $$
delimiter $$
create procedure spSelectUsuario(vLogin varchar(50))
begin
select * from tbUsuario where Login = vLogin;
End $$
delimiter $$
create procedure spUpdateSenha(vLogin varchar(50),vSenha varchar(100))
begin
update tbUsuario set Senha = vSenha where Login = vLogin;
End $$





-- byte




create table funcionario(
IDfunc int not null,
nomeFunc varchar(40) not null,
cpf bigint(14) not null,
rg bigint(14) not null,
nascimento date not null,
endereco varchar(100) not null,
cel varchar(11) not null,
email varchar(40) not null, 
cargo varchar(30) not null,
Primary key (IDfunc, cpf)

) DEFAULT CHARSET = utf8;

select * from Funcionario;

create table cliente(
nomeCliente varchar(40) not null,
cpf bigint(14) not null,
nascimento date not null,
email varchar(40) not null,
cel varchar(11) not null,
enderecocli varchar(100) not null,
primary key(cpf)

)DEFAULT CHARSET = utf8;

insert into cliente values("Leandro", "49965125678", '2004-10-11', "leofcb334@gmail.com", "11985476532", "Rua Caviuna, 05");

select * from cliente;

CREATE TABLE Procedimento (
IDProcedimento int PRIMARY KEY,
NomeProcedimento varchar(40) not null,
DataProcedimento datetime not null,
DescProcedimento mediumtext not null,
MetodoPgto varchar(20) not null,
ValorTotal varchar(15) not null
)DEFAULT CHARSET = utf8;

CREATE TABLE Especialista (
IDEspecialista int not null,
DataNascEspec datetime not null,
NomeEspec varchar(40) not null,
cpfEspec bigint(14) not null,
EmailEspec varchar(40) not null,
NumEspec varchar(11) not null,
Primary Key (cpfEspec, IDEspecialista)
)DEFAULT CHARSET = utf8;


select * from especialista;
select * from procedimento;
select * from funcionario;
select * from cliente;

truncate cliente;
truncate funcionario;
truncate procedimento;
truncate especialista;


insert into Especialista values('Vitor Ribeiro Augusto', '2004-10-11', '49931503858', 'leokurt4@gmail.com', '11985803670', '1');



select * from procedimento;


 