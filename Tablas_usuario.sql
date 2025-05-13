CREATE DATABASE DB_PR

USE DB_PR

--Se crea al usuario
CREATE TABLE usser(
IDU int IDENTITY(1,1) PRIMARY KEY NOT NULL,
Nombre varchar(50) NOT NULL,
Correo varchar(50) NOT NULL,
Pass varchar(max) NOT NULL,
Adm bit NOT NULL,
--Este es un dato booleano, ya que SQL no dispone de la variable booleana como tal, bit es 1 o 0
);

--Se crea la competencia
CREATE TABLE competencia(
Nombre_C varchar(50),
Comp int,
IDU int,
FOREIGN KEY(IDU) REFERENCES usser(IDU)
--Buscamos que la tabla de competencias se vincule a un usuario
);