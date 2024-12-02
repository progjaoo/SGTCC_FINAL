USE master;
GO

-- Altera o estado do banco de dados para OFFLINE
ALTER DATABASE [SGTCC] SET OFFLINE WITH ROLLBACK IMMEDIATE;
GO

-- Exclui o banco de dados
DROP DATABASE [SGTCC];
GO