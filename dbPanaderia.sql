CREATE DATABASE dbPanaderia;
GO

USE dbPanaderia;
GO

CREATE TABLE Panaderia (
  id INT IDENTITY(1,1) PRIMARY KEY,
  nombre VARCHAR(100),
  categoria VARCHAR(50),
  descripcion VARCHAR(255),
  precio DECIMAL(10, 2),
  disponibilidad BIT,
  ingredientes VARCHAR(255),
  alergenos VARCHAR(100),
  tamano VARCHAR(50),
  valor_nutricional VARCHAR(100),
  imagen VARCHAR(255),
);
GO

select* from Panaderia
GO