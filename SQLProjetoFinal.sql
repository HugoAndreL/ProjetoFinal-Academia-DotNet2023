CREATE DATABASE [Hospitalar_senhas];

USE [Hospitalar_senhas];

CREATE LOGIN [HospitalAdmin] WITH PASSWORD = 'admin';

CREATE USER [HospitalAdmin] FROM LOGIN [HospitalAdmin];

EXEC sp_addrolemember 'DB_ACCESSADMIN', 'HospitalAdmin';
EXEC sp_addrolemember 'DB_DATAREADER', 'HospitalAdmin';
EXEC sp_addrolemember 'DB_DATAWRITER', 'HospitalAdmin';
EXEC sp_addrolemember 'DB_DDLADMIN', 'HospitalAdmin';
EXEC sp_addrolemember 'DB_OWNER', 'HospitalAdmin';
EXEC sp_addrolemember 'DB_SECURITYADMIN', 'HospitalAdmin';