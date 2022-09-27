--Scaffold-DbContext "Data Source=.;Initial Catalog=etv;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data
--con doker
--Scaffold-DbContext "Data Source=.,15000;Initial Catalog=etv;User ID=sa;Password=Control123+" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data1
use master
go

create database etv
go

use etv
go

Create table cargo(
idCargo int identity(1,1) not null,
nombre nvarchar(50) not null,
estado bit not null,
primary key (idCargo)
)

create table persona(
idPersona int identity(1,1) not null,
nombre nvarchar(50)not null,
aPaterno nvarchar(50),
aMaterno nvarchar(50),
estado bit not null,
idCargo int not null,
primary key (idPersona),
foreign key (idCargo) references cargo (idCargo)
)

create table rol(
idRol int identity (1,1) not null,
Nombre nvarchar(50)not null,
estado bit not null,
primary key (idRol)
)

create table sucursal(
idSucursal int identity (1,1) not null,
nombre nvarchar(20)not null,
sigla nvarchar(4)not null,
estado bit not null,
primary key (idSucursal)
)

Create table usuario(
idPersona int not null,
nombre nvarchar(50) not null,
contrasena nvarchar(250) not null,
idRol int not null,
idSucursal int not null,
estado bit not null,
primary key (idPersona),
foreign key (idPersona) references Persona (idPersona),
foreign key (idrol) references rol (idrol),
foreign key (idSucursal) references sucursal (idSucursal),
)

--create table permiso(
--idPermiso int identity(1,1) not null,
--nombre nvarchar(50),
--primary key (idPermiso)
--)

--create table permiso_rol(
--idPermisoRol int identity(1,1) not null,
--idPermiso int not null references permiso (idPermiso),
--idRol int not null,
--primary key (idPermisoRol),
--foreign key (idrol) references rol (idrol)
--)



create table estadoUb(
idEstadoUb int identity (1,1) not null,
nombre nvarchar(50) not null,
estado bit not null,
primary key (idEstadoUb)
)

create table marca(
idMarca int identity (1,1) not null,
nombre nvarchar(50) not null,
estado bit not null,
primary key (idMarca)
)

create table modelo(
idModelo int identity (1,1) not null,
nombre nvarchar(50) not null,
estado bit not null,
idMarca int not null,
primary key (idModelo),
foreign key (idMarca) references marca (idMarca)
)

create table tipoUb(
idTipoUb int identity (1,1) not null,
nombre nvarchar(25)not null,
estado bit not null,
primary key (idTipoUb),
)

create table blindador(
idBlindador int identity (1,1) not null,
nombre nvarchar(25)not null,
estado bit not null,
primary key (idBlindador),
)

create table ub(
idUb int identity (1,1) not null,
codigo nvarchar(10)not null,
placa nvarchar(10)not null,
tarjetaOperativa nvarchar(8),
idTipoUb int not null,
ano nvarchar(4),
idBlindador int not null,
idModelo int not null,
estadoUb int not null,
estado bit not null,
primary key(idUb),
foreign key (estadoUb) references estadoUb (idEstadoUb),
foreign key (idBlindador) references blindador (idBlindador),
foreign key (idModelo) references modelo (idModelo),
foreign key (idTipoUb) references tipoUb (idTipoUb)
)

create table tipoTrabajo(
idTipoTrabajo int identity (1,1) not null,
nombre nvarchar(50),
estado bit not null,
primary key (idTipoTrabajo)
)

create table ot(
idOt int identity (1,1) not null,
codigo nvarchar(8)not null,
fechaSolicitud datetime not null,
precioTotal money not null,
idSucursal int not null,
idTipoTrabajo int not null,
idPersona int not null,
primary key (idOt),
foreign key (idSucursal) references sucursal (idSucursal),
foreign key (idTipoTrabajo) references tipoTrabajo (idTipoTrabajo),
foreign key (idPersona) references persona (idPersona)
)

create table otDetalle(
idOt int not null,
trabajoSolicitado nvarchar(max)not null,
descripcion nvarchar(400) null,
precio money not null,
idUb int not null,
primary key (idOt),
foreign key (idOt) references ot (idOt) on update cascade on delete cascade,
foreign key (idUb) references ub (idUb) on update cascade on delete cascade,
)

select * from marca
insert into marca values('marca 2',1),('marca 3',1),('marca 4',1),
('marca 5',1),('marca 6',1),('marca 7',1),('marca 8',1),('marca 9',1),
('marca 10',1),('marca 11',1),('marca 12',1),('marca 13',1),('marca 14',1)

select * from modelo 
insert into modelo values ('modelo 1',1,1),('modelo 2',1,2),('modelo 3',1,3)

select * from blindador
insert into blindador values ('blindador 1',1),('blindador 2',1),('blindador 3',1),('blindador 4',1)

select * from estadoUb
insert into estadoUb values ('Estado ub 1',1),('Estado ub 2',1),('Estado ub 3',1),('Estado ub 4',1)

select * from tipoUb
insert into tipoUb values ('Tipo ub 1',1),('Tipo ub 2',1),('Tipo ub 3',1),('Tipo ub 4',1)

select * from ub
insert into ub values ('891-WRD','895-EFD','Tarje',1,'2022',1,1,1,1)
insert into ub values ('456-QAZ','462-FVG','1 Tarje',1,'2021',1,1,1,1)

select * from cargo
insert into cargo values ('Cargo 1',1),('Cargo 2',1),('Cargo 3',1)

select * from rol
insert into rol values ('Adm',1),('Chuquisaca',1),('La Paz',1),('Cochabamba',1)
,('Oruro',1),('Potosí',1),('Tarija',1),('Santa Cruz',1),('Beni',1),('Pando',1)

select * from sucursal
insert into sucursal values ('Chuquisaca','CH',1),('La Paz','LP',1),('Cochabamba','CB',1)
,('Oruro','OR',1),('Potosí','PT',1),('Tarija','TJ',1),('Santa Cruz','SC',1),('Beni','BE',1),('Pando','PD',1)

select * from persona
insert into persona values ('pepe','rios','ortega',1,1)
insert into persona values ('juan','perez','rios',1,1)

select * from usuario
insert into usuario values (1,'pepe','123',1,1,1)
insert into usuario values (2,'juan','123',2,3,1)

select * from tipoTrabajo
insert into tipoTrabajo values ('Trabajo 1',1),('Trabajo 2',1),('Trabajo 3',1)
delete from ot where idOt=4

select * from ot
insert into ot values ('RFF-7',getdate(),50,1,1,1)
insert into ot values ('DFC-4',getdate(),40,2,3,2)

select * from ub
select * from otDetalle
insert into otDetalle values (1,'Transporte','transporte privado',10,1)
insert into otDetalle values (2,'Transporte','transporte privado',20,1)

select * from tipoTrabajo
update tipoTrabajo set nombre='www' where idTipoTrabajo=3

select * from usuario
update usuario set estado=1 