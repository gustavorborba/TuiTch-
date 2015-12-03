USE [TuiTche]
GO

INSERT INTO [dbo].[Usuario]
           ([Username],[NomeCompleto],[Email],[Senha],[IdSexoUsuario],[Foto])
     VALUES
           ('UsuarioA','João','ig@ig.com','senha',1,'link')
GO

INSERT INTO [dbo].[Usuario]
           ([Username],[NomeCompleto],[Email],[Senha],[IdSexoUsuario],[Foto])
     VALUES
           ('Usuariob','Maria','ig2@ig.com','senha',2,'link')
GO

INSERT INTO [dbo].[Usuario]
           ([Username],[NomeCompleto],[Email],[Senha],[IdSexoUsuario],[Foto])
     VALUES
           ('Usuarioc','Luiza','ig3@ig.com','senha',2,'link')
GO

INSERT INTO [dbo].[Usuario]
           ([Username],[NomeCompleto],[Email],[Senha],[IdSexoUsuario],[Foto])
     VALUES
           ('Usuariod','Pedro','ig4@ig.com','senha',1,'link')
GO

INSERT INTO [dbo].[Seguidores]
           ([IdSeguidor]
           ,[IdSeguindo])
     VALUES
           (1
           ,2)
GO

INSERT INTO [dbo].[Seguidores]
           ([IdSeguidor]
           ,[IdSeguindo])
     VALUES
           (1
           ,3)
GO

INSERT INTO [dbo].[Seguidores]
           ([IdSeguidor]
           ,[IdSeguindo])
     VALUES
           (1
           ,4)
GO

INSERT INTO [dbo].[Seguidores]
           ([IdSeguidor]
           ,[IdSeguindo])
     VALUES
           (2
           ,1)
GO