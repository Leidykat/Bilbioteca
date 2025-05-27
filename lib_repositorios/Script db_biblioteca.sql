CREATE DATABASE db_Biblioteca;
GO

USE db_Biblioteca;
GO


CREATE TABLE [Editoriales] (
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[nombre] NVARCHAR(50) UNIQUE NOT NULL,
	[correo] NVARCHAR(50) NOT NULL,
	
);
GO

CREATE TABLE [Generos] (
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[nombre] NVARCHAR(50) UNIQUE NOT NULL,
	[descripcion] NVARCHAR(255) NOT NULL,
);
GO

CREATE TABLE [Autores] (
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[nombre] NVARCHAR(50) NOT NULL,
	[apellido] NVARCHAR(50) NOT NULL,
);
GO

CREATE TABLE [Roles] (
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[nombre] NVARCHAR(50) UNIQUE NOT NULL,
	[descripcion] NVARCHAR(255) NOT NULL,
);
GO

CREATE TABLE [Usuarios] (
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[nombre] NVARCHAR(50) NOT NULL,
	[apellido] NVARCHAR(255) NOT NULL,
	[correo] NVARCHAR(50) NOT NULL,
	[telefono] VARCHAR(50) NOT NULL,
	[id_roles] INT NOT NULL REFERENCES [Roles] ([id])
);
GO

CREATE TABLE [Libros] (
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[titulo] NVARCHAR(50) NOT NULL,
	[imagen] NVARCHAR(MAX),
	[cantidad] INT NOT NULL,
	[estado] NVARCHAR(50) NOT NULL,
	[año_publicacion] VARCHAR(20) NOT NULL,
	[id_editoriales] INT NOT NULL REFERENCES [Editoriales] ([id])
);
GO


CREATE TABLE [Prestamos] (
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[codigo] NVARCHAR(50) NOT NULL,
	[fecha_prestamo] SMALLDATETIME NOT NULL,
	[fecha_devolucion] SMALLDATETIME NOT NULL,
	[id_usuarios] INT NOT NULL REFERENCES [Usuarios] ([id])
);
GO


CREATE TABLE [Prestamos_Libros] (
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[fecha_devolucion] SMALLDATETIME NOT NULL,
	[id_libros] INT NOT NULL REFERENCES [Libros] ([id]),
	[id_prestamos] INT NOT NULL REFERENCES [Prestamos] ([id])
);
GO

CREATE TABLE [Libros_Autores] (
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[id_libros] INT NOT NULL REFERENCES [Libros] ([id]),
	[id_Autores] INT NOT NULL REFERENCES [Autores] ([id])
);
GO

CREATE TABLE [Libros_Generos] (
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[id_libros] INT NOT NULL REFERENCES [Libros] ([id]),
	[id_Generos] INT NOT NULL REFERENCES [Generos] ([id])
);
GO

CREATE TABLE [Auditorias] (
	[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[fecha] DATETIME NOT NULL DEFAULT GETDATE(),
	[tabla] NVARCHAR(50) NOT NULL,
	[accion] NVARCHAR(50) NOT NULL,
);
GO

INSERT INTO [Editoriales] ([nombre], [correo]) 
VALUES ('Bloomsbury', 'bloomsbury@gmail.com');
INSERT INTO [Editoriales] ([nombre], [correo]) 
VALUES ('Minotauro', 'minotauro@gmail.com');
GO

INSERT INTO [Generos] ([nombre], [descripcion]) 
VALUES ('Acción', 'Género lleno de emociones, enfrentamientos y desafíos intensos');
INSERT INTO [Generos] ([nombre], [descripcion]) 
VALUES ('Fantasía', 'Mundo imaginario con magia, criaturas y aventuras sobrenaturales');
GO

INSERT INTO [Autores] ([nombre], [apellido]) 
VALUES ('Joanne', 'Rowling');
INSERT INTO [Autores] ([nombre], [apellido]) 
VALUES ('John Ronald', 'Tolkien');
GO

INSERT INTO [Roles] ([nombre], [descripcion]) 
VALUES ('Estudiante', 'Estudiante de la organición');
INSERT INTO [Roles] ([nombre], [descripcion]) 
VALUES ('Personal Administrativo', 'Personal administrativo que trabaja en la organización');
GO


INSERT INTO [Usuarios] ([nombre], [apellido], [correo], [telefono],	[id_roles]) 
VALUES ('Ramiro', 'Sanchez', 'ramiro123@gmail.com', '12345', 1 );
INSERT INTO [Usuarios] ([nombre], [apellido], [correo], [telefono],	[id_roles]) 
VALUES ('Isabela', 'Perez', 'Isabelita@gmail.com', '67890', 2);
GO

INSERT INTO [Libros] ([titulo], [cantidad], [estado], [año_publicacion], [id_editoriales]) 
VALUES ('Harry Potter y el prisionero de Azkaban', 8, 'Disponible', '1999', 1 );
INSERT INTO [Libros] ([titulo], [cantidad], [estado], [año_publicacion], [id_editoriales]) 
VALUES ('El señor de los anillos', 4, 'Disponible', '1954', 2);
GO

INSERT INTO [Prestamos] ([codigo], [fecha_prestamo], [fecha_devolucion], [id_usuarios]) 
VALUES ('Ax1', GETDATE(), '2025-03-03' , 1 );
INSERT INTO [Prestamos] ([codigo], [fecha_prestamo], [fecha_devolucion], [id_usuarios]) 
VALUES ('Ax1', GETDATE(), '2025-03-05', 1 );
INSERT INTO [Prestamos] ([codigo], [fecha_prestamo], [fecha_devolucion], [id_usuarios]) 
VALUES ('Ax2', GETDATE(), '2025-03-25', 2);
GO

INSERT INTO [Prestamos_Libros] ([fecha_devolucion], [id_libros], [id_prestamos]) 
VALUES ('2025-03-03', 1, 1);
INSERT INTO [Prestamos_Libros] ([fecha_devolucion], [id_libros], [id_prestamos]) 
VALUES ('2025-02-24', 2, 2);
GO

INSERT INTO [Libros_Autores] ([id_libros],	[id_Autores]) 
VALUES ( 1, 1);
INSERT INTO [Libros_Autores] ([id_libros],	[id_Autores]) 
VALUES ( 2, 2);
GO

INSERT INTO [Libros_Generos] ([id_libros],	[id_Generos]) 
VALUES ( 1, 1);
INSERT INTO [Libros_Generos] ([id_libros],	[id_Generos]) 
VALUES ( 2, 2);
GO

