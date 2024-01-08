CREATE DATABASE [HospitalDB];

USE [HospitalDB];

CREATE LOGIN [HospitalAdmin] WITH PASSWORD = 'admin';

CREATE USER [HospitalAdmin] FROM LOGIN [HospitalAdmin];

EXEC sp_addrolemember 'DB_ACCESSADMIN', 'HospitalAdmin';
EXEC sp_addrolemember 'DB_DATAREADER', 'HospitalAdmin';
EXEC sp_addrolemember 'DB_DATAWRITER', 'HospitalAdmin';
EXEC sp_addrolemember 'DB_DDLADMIN', 'HospitalAdmin';
EXEC sp_addrolemember 'DB_OWNER', 'HospitalAdmin';
EXEC sp_addrolemember 'DB_SECURITYADMIN', 'HospitalAdmin';

-- Valores para poder entrar no software
INSERT INTO [Cargos] VALUES (
  'Programador'
);

INSERT INTO [TiposAreasAtendimento] VALUES (
  'Escritório'
);

INSERT INTO [AreasAtendimento] VALUES (
  '01',
  1
);

INSERT INTO [Logins] VALUES (
  'admin',
  '12345',
  '',
  1
);

INSERT INTO [Usuarios] VALUES (
  'Hugo André Lucena',
  'hugo.lucena@ufn.edu.br',
  '12345',
  1,
  1
);