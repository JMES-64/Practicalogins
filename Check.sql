USE DB_PR
--Este query es para insertar información de prueba y verificar los datos en las tablas, será un query de debug

--Sección dedicada a crear la información inicial
INSERT INTO usser(Nombre,Correo,Pass,Adm,Own)
VALUES('Jean','Sapo@hotmail.com','A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3',1,1)

INSERT INTO usser(Nombre,Correo,Pass,Adm,Own)
VALUES('Pier','Sapo2@hotmail.com','A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3',1,0)

INSERT INTO usser(Nombre,Correo,Pass,Adm,Own)
VALUES('Juan','Sapo3@hotmail.com','A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3',0,0)

INSERT INTO competencia(Nombre_C,Comp,IDU)
VALUES('Smash',3,3)
INSERT INTO competencia(Nombre_C,Comp,IDU)
VALUES('Splatoon',4,3)
INSERT INTO competencia(Nombre_C,Comp,IDU)
VALUES('Pokemon',5,3)


--Sección dedicada a revisar las tablas
SELECT * FROM usser
SELECT * FROM competencia

EXEC ListarU
EXEC ListarC
EXEC ListarAU
EXEC Buscar 
EXEC Elimina 2016
EXEC Log_In 'Sapo@hotmail.com','A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3'