USE DB_PR
GO

--BUSCADOR

--Estas funciones buscan permitirnos encontrar un usuario o competencia en específico, con los cuales nos sea posible editar su información

--Buscar Admins o Usuarios; exclusivo del Owner
CREATE PROCEDURE Buscar(
@IDU int
)
AS BEGIN(
SELECT
u.IDU,
u.Nombre,
u.Correo,
u.Pass,
u.Adm
FROM usser u WHERE @IDU=IDU
)
END
GO

--Buscar competencias
CREATE PROCEDURE BuscarC(
@IDC int
)AS BEGIN(
SELECT 
c.IDC,
c.Nombre_C,
c.Comp
FROM competencia c WHERE @IDC=IDC
)
END
GO

--REGISTRO

CREATE PROCEDURE RegistraU(
@Nombre varchar(50),
@Correo varchar(50),
@Pass varchar(max),
@Adm bit,
@Own bit
)
AS BEGIN
INSERT INTO usser(Nombre,Correo,Pass, Adm,Own)
VALUES
(
@Nombre,
@Correo,
@Pass,
@Adm,
@Own
)END
GO
--Este procedimiento nos permitirá guardar los usuarios, sean admins o no

CREATE PROCEDURE RegistraC(
@Nombre_C varchar(50),
@Comp int,
@IDU int
)
AS BEGIN
INSERT INTO competencia(Nombre_C,Comp,IDU)
VALUES
(
@Nombre_C,
@Comp,
@IDU
)END
GO
--En este procedimiento habremos registrado las competencias de los usuarios y su nivel de competencia

CREATE PROCEDURE RegistraAU(
@Nombre varchar(50),
@Correo varchar(50),
@Pass varchar(max),
@Adm bit,
@Own bit
)
AS
BEGIN
INSERT INTO usser(Nombre,Correo,Pass,Adm,Own)
VALUES
(
@Nombre,
@Correo,
@Pass,
@Adm,
@Own
)END
GO

--Con este procedimiento, el owner podrá registrar nuevos admins o usuarios si así lo desea, pero no otro owner

--Ahora, vamos a incorportar las listas de usuarios para su visualización

--LISTADO
CREATE PROCEDURE ListarU
AS BEGIN
SELECT
u.IDU,
u.Nombre,
u.Correo
FROM usser u
WHERE u.Adm=0;
END
GO
--En este script, se permitirá visualizar la información del usuario, ignorando por completo a los que son Admins

CREATE PROCEDURE ListarC
(
@IDU int
)
AS BEGIN
SELECT
c.IDU,
c.Nombre_C,
c.Comp
FROM competencia c WHERE @IDU = IDU
END
GO
--En este script se mostrará las competencias relacionadas al usuario, se conserva la muestra del ID para identificar facilmente al usuario
CREATE PROCEDURE ListarAU
AS BEGIN
SELECT
u.IDU,
u. Nombre,
u.Correo,
u.Adm
FROM usser u WHERE u.Own=0
END
GO
--En este script, el owner podrá ver a todos los usuarios, sean admins o no
--Lo siguiente es la opción de editar, la cual debería ejecutarse en base a un id

--Crearemos las opciones para editar usser

CREATE PROCEDURE EditaU
(
@IDU int,
@Nombre varchar(50),
@Correo varchar (50)
)
AS BEGIN
UPDATE usser SET
Nombre = @Nombre,
Correo = @Correo
WHERE IDU= @IDU
END
GO
--Con esta opción, los admins podrán cambiar el nombre y correo de un usuario en específico

CREATE PROCEDURE EditaC
(
@IDC int,
@Nombre_C varchar(50),
@Comp int
)
AS BEGIN
UPDATE competencia SET
Nombre_C = @Nombre_C,
Comp = @Comp
WHERE IDC= @IDC
END
GO
--Esta opción nos permitirá editar las competencias del usuario

CREATE PROCEDURE EditaAU
(
@IDU int,
@Nombre varchar(50),
@Correo varchar(50),
@Adm bit
)
AS BEGIN
UPDATE usser SET
Nombre = @Nombre,
Correo = @Correo,
Adm = @Adm
WHERE IDU= @IDU
END
GO
--Este procedimiento solo estará disponible para el owner, el cual podrá editar a los usuarios, sean admin o no
--También dispone de la opción de cambiar las credenciales de los mismos o de otorgar o eliminar el admin

--Por ultimo, se creará la opción de eliminar usuarios

--ELIMINAR

CREATE PROCEDURE Elimina(
@IDU int
)
AS BEGIN
DELETE FROM competencia WHERE IDU = @IDU
DELETE FROM usser WHERE IDU = @IDU

END 
GO
--Este procedimiento permitirá al owner eliminar al usuario sea admin o no, incluyendo sus competencias
