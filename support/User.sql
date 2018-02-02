Use [dotnet-core];
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'dcservice')
BEGIN
	CREATE USER [dcservice] FOR LOGIN [dcservice]
	EXEC sp_addrolemember N'db_owner', N'dcservice'
END;
GO