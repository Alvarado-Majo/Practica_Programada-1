
Create database Practica1
use Practica1

CREATE TABLE "CLIENTE" (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre varchar (30) NOT NULL,
    Apellido varchar (50)NOT NULL,
    Email varchar (30),
    FechaRegistro varchar DEFAULT CURRENT_TIMESTAMP

);

CREATE TABLE "TELEFONO" (
    Id_Telefono INT PRIMARY KEY IDENTITY(1,1),
    Numero varchar (15) NOT NULL,
    Tipo varchar DEFAULT (30),
    FKCLIENTE INTEGER NOT NULL,
    CONSTRAINT "FK_TELEFONO_CLIENTE" FOREIGN KEY(FKCLIENTE) REFERENCES "CLIENTE"(ID)
);

