-- Script Microsoft SQL

CREATE DATABASE Practica1;
GO

USE Practica1;
GO

CREATE TABLE CLIENTE (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(30) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Email VARCHAR(30),
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE TELEFONO (
    Id_Telefono INT PRIMARY KEY IDENTITY(1,1),
    Numero VARCHAR(15) NOT NULL,
    Tipo VARCHAR(30),
    FKCLIENTE INT NOT NULL,
    CONSTRAINT FK_TELEFONO_CLIENTE 
        FOREIGN KEY (FKCLIENTE) REFERENCES CLIENTE(ID)
);
GO


-- Datos de prueba

INSERT INTO CLIENTE (Nombre, Apellido, Email)
VALUES 
('Javier', 'Mendez', 'javier@gmail.com'),
('Ana', 'Lopez', 'ana@gmail.com'),
('Carlos', 'Ramirez', 'carlos@gmail.com'),
('Maria', 'Fernandez', 'maria@gmail.com');


INSERT INTO TELEFONO (Numero, Tipo, FKCLIENTE)
VALUES
('8888-1111', 'Movil', 1),
('2222-3333', 'Casa', 1),
('7777-4444', 'Movil', 2),
('6666-5555', 'Trabajo', 3),
('9999-8888', 'Movil', 3),
('5555-0000', 'Casa', 4);