CREATE DATABASE DB_PR

USE DB_PR
--Se crea al usuario
CREATE TABLE usser(
IDU int IDENTITY(1,1) PRIMARY KEY NOT NULL,
Nombre varchar(50) NOT NULL,
Correo varchar(50) NOT NULL,
Pass varchar(max) NOT NULL,
Adm bit NOT NULL,
Own bit NOT NULL,
--Este es un dato booleano, ya que SQL no dispone de la variable booleana como tal, bit es 1 o 0
);
--También se incluye la opción de Own, la cual destaca a un usuario en específico como el owner del sistema, 
--lo que le permite proporcionar el admin a usuarios así como quitarselo, sin embargo esto no se le puede hacer al owner
--Se crea la competencia
CREATE TABLE competencia(
IDC int IDENTITY(1,1) PRIMARY KEY NOT NULL,
Nombre_C varchar(50) NOT NULL,
Comp int NOT NULL,
IDU int NOT NULL,
FOREIGN KEY(IDU) REFERENCES usser(IDU)
--Buscamos que la tabla de competencias se vincule a un usuario
);


