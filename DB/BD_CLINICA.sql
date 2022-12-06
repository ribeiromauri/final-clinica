CREATE DATABASE CLINICA
USE CLINICA
GO

CREATE TABLE TIPO_USUARIO(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TIPO VARCHAR(20) UNIQUE NOT NULL,
	ESTADO BIT NOT NULL
)

CREATE TABLE ADM_USUARIOS(
	ID_USUARIO INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	TIPO_USUARIO INT NOT NULL FOREIGN KEY REFERENCES TIPO_USUARIO(ID),
	DNI_USUARIO VARCHAR(20) NOT NULL UNIQUE, 
	CONTRASE�A VARCHAR(50) NOT NULL
)

CREATE TABLE RECEPCIONISTA(
	ID INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES ADM_USUARIOS(ID_USUARIO),
	CONTRASE�A VARCHAR(50) NOT NULL,
	NOMBRES VARCHAR(50) NOT NULL,
	APELLIDOS VARCHAR(50) NOT NULL,
	DNI VARCHAR(20) NOT NULL UNIQUE,
	EMAIL VARCHAR(50) NOT NULL,
	ESTADO BIT NOT NULL
)

CREATE TABLE MEDICOS(
	ID INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES ADM_USUARIOS(ID_USUARIO),
	CONTRASE�A VARCHAR(50) NOT NULL,
	NOMBRES VARCHAR(50) NOT NULL,
	APELLIDOS VARCHAR(50) NOT NULL,
	DNI VARCHAR(20) NOT NULL UNIQUE,
	MATRICULA INT NOT NULL UNIQUE,
	EMAIL VARCHAR(50) NOT NULL,
	ESTADO BIT NOT NULL
)

CREATE TABLE PACIENTES(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	NOMBRES VARCHAR(50) NOT NULL,
	APELLIDOS VARCHAR(50) NOT NULL,
	DNI VARCHAR(20) NOT NULL UNIQUE,
	DOMICILIO VARCHAR(50) NOT NULL,
	EMAIL VARCHAR(50) NOT NULL,
	FECHA_NACIMIENTO DATE NOT NULL,
	ESTADO BIT NOT NULL
)

CREATE TABLE ESPECIALIDADES(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	NOMBRE VARCHAR(50) NOT NULL,
	ESTADO BIT NOT NULL
)

CREATE TABLE DIAS(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	DIA VARCHAR(10) NOT NULL,
)

CREATE TABLE ESPECIALIDAD_X_MEDICO(
	ID_MEDICO INT FOREIGN KEY REFERENCES MEDICOS(ID) NOT NULL,
	ID_ESPECIALIDAD INT FOREIGN KEY REFERENCES ESPECIALIDADES(ID) NOT NULL,
	PRIMARY KEY(ID_MEDICO, ID_ESPECIALIDAD)
)

CREATE TABLE HORARIOS_TRABAJO(
	ID_MEDICO INT FOREIGN KEY REFERENCES MEDICOS (ID) NOT NULL,
	DIA VARCHAR(10) NOT NULL CHECK(DIA = 'Lunes' OR DIA = 'Martes' OR DIA = 'Miercoles' OR DIA = 'Mi�rcoles' OR DIA = 'Jueves' OR DIA = 'Viernes' OR DIA = 'S�bado' OR DIA = 'Sabado' OR DIA = 'Domingo'),
	H_ENTRADA INT NOT NULL CHECK (H_ENTRADA > 0),
	H_SALIDA INT NOT NULL CHECK (H_SALIDA > 0),
	LIBRE BIT NOT NULL,
	PRIMARY KEY (DIA, ID_MEDICO)
)

CREATE TABLE TURNOS(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_MEDICO INT FOREIGN KEY REFERENCES MEDICOS(ID) NOT NULL,
	ID_PACIENTE INT FOREIGN KEY REFERENCES PACIENTES(ID) NOT NULL,
	ID_ESPECIALIDAD INT FOREIGN KEY REFERENCES ESPECIALIDADES(ID) NOT NULL,
	ENTRADA INT NOT NULL CHECK (ENTRADA > 0),
	FECHA DATE NOT NULL,
	OBSERVACIONES VARCHAR(200),
	ESTADO BIT NOT NULL
)

--TIPO DE USUARIOS--
INSERT INTO TIPO_USUARIO (TIPO, ESTADO) VALUES ('ADMIN', 1)
INSERT INTO TIPO_USUARIO (TIPO, ESTADO) VALUES ('RECEPCIONISTA', 1)
INSERT INTO TIPO_USUARIO (TIPO, ESTADO) VALUES ('MEDICO', 1)

--ESPECIALIDADES--
INSERT INTO ESPECIALIDADES (NOMBRE, ESTADO) VALUES ('Cardiologia', 1)
INSERT INTO ESPECIALIDADES (NOMBRE, ESTADO) VALUES ('Cirugia', 1)
INSERT INTO ESPECIALIDADES (NOMBRE, ESTADO) VALUES ('Gastroenterologia', 1)
INSERT INTO ESPECIALIDADES (NOMBRE, ESTADO) VALUES ('Oftalmologia', 1)
INSERT INTO ESPECIALIDADES (NOMBRE, ESTADO) VALUES ('Otorrinolaringologia', 1)
INSERT INTO ESPECIALIDADES (NOMBRE, ESTADO) VALUES ('Pediatria', 1)
INSERT INTO ESPECIALIDADES (NOMBRE, ESTADO) VALUES ('Ginecologia', 1)
INSERT INTO ESPECIALIDADES (NOMBRE, ESTADO) VALUES ('Obstetricia', 1)
INSERT INTO ESPECIALIDADES (NOMBRE, ESTADO) VALUES ('Neumonologia', 1)
INSERT INTO ESPECIALIDADES (NOMBRE, ESTADO) VALUES ('Traumatologia', 1)
INSERT INTO ESPECIALIDADES (NOMBRE, ESTADO) VALUES ('Dermatologia', 1)
INSERT INTO ESPECIALIDADES (NOMBRE, ESTADO) VALUES ('Neurologia', 1)

--PACIENTES--
Set Dateformat 'DMY'
INSERT INTO PACIENTES (NOMBRES, APELLIDOS, DNI, DOMICILIO, EMAIL, FECHA_NACIMIENTO, ESTADO) VALUES ('Facundo', 'Marcati', 43182968, 'Bogota 542', 'facumarcati99@gmail.com', '04/01/2001', 1)
INSERT INTO PACIENTES (NOMBRES, APELLIDOS, DNI, DOMICILIO, EMAIL, FECHA_NACIMIENTO, ESTADO) VALUES ('Pablo', 'P�rez', 32524543, 'Chaco 125', 'pablitoperez@hotmail.com', '20/11/1992', 1)
INSERT INTO PACIENTES (NOMBRES, APELLIDOS, DNI, DOMICILIO, EMAIL, FECHA_NACIMIENTO, ESTADO) VALUES ('Mariano', 'Closs', 38345394, 'Corrientes 912', 'clossmariano90@gmail.com', '09/12/1990', 1)

--DIAS--
INSERT INTO DIAS VALUES ('Lunes')
INSERT INTO DIAS VALUES ('Martes')
INSERT INTO DIAS VALUES ('Mi�rcoles')
INSERT INTO DIAS VALUES ('Jueves')
INSERT INTO DIAS VALUES ('Viernes')
INSERT INTO DIAS VALUES ('S�bado')
INSERT INTO DIAS VALUES ('Domingo')

--SP PARA DAR DE ALTA UN MEDICO
GO
CREATE PROCEDURE SP_ALTA_MEDICO(
	@NOMBRE VARCHAR(50),
	@APELLIDO VARCHAR(50),
	@MATRICULA INT, 
	@DNI VARCHAR(20),
	@EMAIL VARCHAR(50),
	@CONTRASE�A VARCHAR(50)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO ADM_USUARIOS(TIPO_USUARIO, DNI_USUARIO, CONTRASE�A) VALUES (3, @DNI, @CONTRASE�A)

			DECLARE @ID_MEDICO INT
			SET @ID_MEDICO = @@IDENTITY --Guarda el n�mero del �ltimo registro insertado

			INSERT INTO MEDICOS(ID, CONTRASE�A, NOMBRES, APELLIDOS, DNI, MATRICULA, EMAIL, ESTADO)
			VALUES (@ID_MEDICO, @CONTRASE�A, @NOMBRE, @APELLIDO, @DNI, @MATRICULA, @EMAIL, 1)
		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		RAISERROR('No se pudo dar de alta el registro', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END

GO
--SP PARA DAR DE ALTA UN RECEPCIONISTA
CREATE PROCEDURE SP_ALTA_RECEPCIONISTA(
	@NOMBRE VARCHAR(50),
	@APELLIDO VARCHAR(50),
	@DNI VARCHAR(20),
	@EMAIL VARCHAR(50),
	@CONTRASE�A VARCHAR(50)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO ADM_USUARIOS(TIPO_USUARIO, DNI_USUARIO, CONTRASE�A) VALUES (2, @DNI, @CONTRASE�A)

			DECLARE @ID_RP INT
			SET @ID_RP = @@IDENTITY --Guarda el n�mero del �ltimo registro insertado

			INSERT INTO RECEPCIONISTA(ID, CONTRASE�A, NOMBRES, APELLIDOS, DNI, EMAIL, ESTADO)
			VALUES (@ID_RP, @CONTRASE�A, @NOMBRE, @APELLIDO, @DNI, @EMAIL, 1)
		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		RAISERROR('No se pudo dar de alta el registro', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END
GO

--SP PARA DAR DE ALTA UN PACIENTE
CREATE PROCEDURE SP_ALTA_PACIENTE(
	@Nombre varchar(50),
	@Apellido varchar(50),
	@DNI varchar(20),
	@Domicilio varchar(50),
	@Email varchar(50),
	@FechaNacimiento date
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO PACIENTES VALUES(@Nombre, @Apellido, @DNI, @Domicilio, @Email, @FechaNacimiento, 1)

		COMMIT TRANSACTION
	END TRY
	
	BEGIN CATCH
		RAISERROR('No se pudo dar de alta el registro', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END
GO

CREATE PROCEDURE SP_ALTA_MEDICO(
	@NOMBRE VARCHAR(50),
	@APELLIDO VARCHAR(50),
	@MATRICULA INT, 
	@DNI VARCHAR(20),
	@EMAIL VARCHAR(50),
	@CONTRASE�A VARCHAR(50)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO ADM_USUARIOS(TIPO_USUARIO, DNI_USUARIO, CONTRASE�A) VALUES (3, @DNI, @CONTRASE�A)

			DECLARE @ID_MEDICO INT
			SET @ID_MEDICO = @@IDENTITY --Guarda el n�mero del �ltimo registro insertado

			INSERT INTO MEDICOS(ID, CONTRASE�A, NOMBRES, APELLIDOS, DNI, MATRICULA, EMAIL, ESTADO)
			VALUES (@ID_MEDICO, @CONTRASE�A, @NOMBRE, @APELLIDO, @DNI, @MATRICULA, @EMAIL, 1)
		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		RAISERROR('No se pudo dar de alta el registro', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END

EXECUTE SP_ALTA_MEDICO 'Mauricio', 'Ribeiro', 1337, 41079285, 'mauri@gmail.com', 'mauri123'
EXECUTE SP_ALTA_MEDICO 'Facundo', 'Marcati', 2448, 43182968, 'facu@gmail.com', 'facu123'
GO

CREATE PROCEDURE SP_MODIFICAR_PACIENTE(
	@Nombre varchar(50),
	@Apellido varchar(50),
	@DNI varchar(20),
	@Domicilio varchar(50),
	@Email varchar(50),
	@FechaNacimiento date,
	@ID int
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE PACIENTES SET NOMBRES = @Nombre, APELLIDOS = @Apellido, DNI = @DNI, DOMICILIO = @Domicilio, EMAIL = @Email, FECHA_NACIMIENTO = @FechaNacimiento
			WHERE ID = @ID

		COMMIT TRANSACTION
	END TRY
	
	BEGIN CATCH
		RAISERROR('No se pudo modificar el registro', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END
GO

CREATE PROCEDURE SP_MODIFICAR_RECEPCIONISTA(
	@Nombre varchar(50),
	@Apellido varchar(50),
	@DNI varchar(20),
	@Email varchar(50),
	@Contrasenia varchar(50),
	@ID int
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE RECEPCIONISTA SET NOMBRES = @Nombre, APELLIDOS = @Apellido, DNI = @DNI, EMAIL = @Email
			WHERE ID = @ID
			UPDATE ADM_USUARIOS SET DNI_USUARIO = @DNI, CONTRASE�A = @Contrasenia
			WHERE ID_USUARIO = @ID

		COMMIT TRANSACTION
	END TRY
	
	BEGIN CATCH
		RAISERROR('No se pudo modificar el registro', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END
GO

CREATE PROCEDURE SP_ELIMINAR_RECEPCIONISTA(
	@ID int
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE RECEPCIONISTA WHERE ID = @ID
			DELETE ADM_USUARIOS WHERE ID_USUARIO = @ID

		COMMIT TRANSACTION
	END TRY
	
	BEGIN CATCH
		RAISERROR('No se pudo eliminar el registro', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END
GO


CREATE PROCEDURE SP_ELIMINAR_MEDICO(
	@ID int
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE ESPECIALIDAD_X_MEDICO WHERE ID_MEDICO = @ID
			DELETE HORARIOS_TRABAJO WHERE ID_MEDICO = @ID
			DELETE MEDICOS WHERE ID = @ID
			DELETE ADM_USUARIOS WHERE ID_USUARIO = @ID

		COMMIT TRANSACTION
	END TRY
	
	BEGIN CATCH
		RAISERROR('No se pudo eliminar el registro', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END
GO

CREATE PROCEDURE SP_MODIFICAR_MEDICO(
	@ID int,
	@Contrase�a varchar(50),
	@Nombres varchar(50),
	@Apellidos varchar(50),
	@DNI varchar(20),
	@Matricula int,
	@Email varchar(50)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE MEDICOS SET NOMBRES = @Nombres, APELLIDOS = @Apellidos, DNI = @DNI, MATRICULA = @Matricula, EMAIL = @Email
			WHERE ID = @ID
			UPDATE ADM_USUARIOS SET DNI_USUARIO = @DNI, CONTRASE�A = @Contrase�a
			WHERE ID_USUARIO = @ID

		COMMIT TRANSACTION
	END TRY
	
	BEGIN CATCH
		RAISERROR('No se pudo eliminar el registro', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END
GO

CREATE PROCEDURE SP_ELIMINAR_ESPECIALIDADxMEDICO(
	@ID int
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE ESPECIALIDAD_X_MEDICO WHERE ID_MEDICO = @ID

		COMMIT TRANSACTION
	END TRY
	
	BEGIN CATCH
		RAISERROR('No se pudo eliminar el registro', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END
GO

CREATE PROCEDURE SP_ELIMINAR_HORARIOSxMEDICO(
	@ID int
)
AS
BEGIN
	BEGIN TRY
		DELETE HORARIOS_TRABAJO WHERE ID_MEDICO = @ID
	END TRY
	BEGIN CATCH
		RAISERROR('No se pudo eliminar el registro', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END
GO

CREATE PROCEDURE SP_ALTA_TURNO(
	@IDMedico int,
	@IDPaciente int,
	@IDEspecialidad int,
	@HoraEntrada int,
	@Fecha date,
	@Observaciones varchar(200)
)
AS
BEGIN
	BEGIN TRY
		INSERT INTO TURNOS VALUES (@IDMedico, @IDPaciente, @IDEspecialidad, @HoraEntrada, @Fecha, @Observaciones, 1)
	END TRY
	BEGIN CATCH
		RAISERROR('No se pudo agregar el turno', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END
GO

CREATE PROCEDURE SP_MODIFICAR_TURNO(
	@ID int,
	@IDMedico int,
	@IDPaciente int,
	@IDEspecialidad int,
	@HoraEntrada int,
	@Fecha date,
	@Observaciones varchar(200)
)
AS
BEGIN
	BEGIN TRY
		UPDATE TURNOS SET ID_MEDICO = @IDMedico, ID_PACIENTE = @IDPaciente, ID_ESPECIALIDAD = @IDEspecialidad, ENTRADA = @HoraEntrada, FECHA = @Fecha, OBSERVACIONES = @Observaciones
		WHERE ID = @ID
	END TRY
	BEGIN CATCH
		RAISERROR('No se pudo modificar el turno', 16, 1)
		ROLLBACK TRANSACTION
	END CATCH
END
GO