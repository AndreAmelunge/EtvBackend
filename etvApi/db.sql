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
primary key(idUb),
foreign key (estadoUb) references estadoUb (idEstadoUb),
foreign key (idBlindador) references blindador (idBlindador),
foreign key (idModelo) references modelo (idModelo),
foreign key (idTipoUb) references tipoUb (idTipoUb)
)

create table tipoTrabajo(
idTipoTrabajo int identity (1,1) not null,
nombre nvarchar(50),
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
idOt int identity (1,1) not null,
trabajoSolicitado nvarchar(50)not null,
descripcion nvarchar(400) null,
precio money not null,
idUb int not null,
primary key (idOt),
foreign key (idOt) references ot (idOt),
foreign key (idUb) references ub (idUb),
)
--Scaffold-DbContext "Data Source=.;Initial Catalog=etv;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
select * from marca
insert into marca values('marca 2',1),('marca 3',1),('marca 4',1),
('marca 5',1),('marca 6',1),('marca 7',1),('marca 8',1),('marca 9',1),
('marca 10',1),('marca 11',1),('marca 12',1),('marca 13',1),('marca 14',1)

select * from ub

select * from persona

