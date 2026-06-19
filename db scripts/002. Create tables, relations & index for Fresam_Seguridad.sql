-- FRESAM SEGURIDAD V2
-- Script inicial de seguridad
use FresamCostos;


IF OBJECT_ID('dbo.RolesPantallasPermisos', 'U') IS NOT NULL DROP TABLE dbo.RolesPantallasPermisos;
IF OBJECT_ID('dbo.UsuariosRoles', 'U') IS NOT NULL DROP TABLE dbo.UsuariosRoles;
IF OBJECT_ID('dbo.PantallasPermisos', 'U') IS NOT NULL DROP TABLE dbo.PantallasPermisos;
IF OBJECT_ID('dbo.Pantallas', 'U') IS NOT NULL DROP TABLE dbo.Pantallas;
IF OBJECT_ID('dbo.Permisos', 'U') IS NOT NULL DROP TABLE dbo.Permisos;
IF OBJECT_ID('dbo.Roles', 'U') IS NOT NULL DROP TABLE dbo.Roles;
IF OBJECT_ID('dbo.Modulos', 'U') IS NOT NULL DROP TABLE dbo.Modulos;
IF OBJECT_ID('dbo.Usuarios', 'U') IS NOT NULL DROP TABLE dbo.Usuarios;

CREATE TABLE Usuarios(
 UsuarioId INT IDENTITY(1,1) PRIMARY KEY,
 EmpleadoId INT NULL,
 NombreUsuario VARCHAR(100) NOT NULL,
 NombreCompleto VARCHAR(200) NOT NULL,
 Correo VARCHAR(200) NOT NULL,
 PasswordHash VARCHAR(500) NOT NULL,
 Activo BIT NOT NULL DEFAULT(1),
 FechaCreacion DATETIME NOT NULL DEFAULT(GETDATE()),
 UsuarioCreacion VARCHAR(100) NOT NULL,
 FechaModificacion DATETIME NULL,
 UsuarioModificacion VARCHAR(100) NULL
);

CREATE TABLE Roles(
 RolId INT IDENTITY(1,1) PRIMARY KEY,
 Nombre VARCHAR(100) NOT NULL,
 Descripcion VARCHAR(250) NULL,
 Activo BIT NOT NULL DEFAULT(1),
 FechaCreacion DATETIME NOT NULL DEFAULT(GETDATE()),
 UsuarioCreacion VARCHAR(100) NOT NULL,
 FechaModificacion DATETIME NULL,
 UsuarioModificacion VARCHAR(100) NULL
);

CREATE TABLE Modulos(
 ModuloId INT IDENTITY(1,1) PRIMARY KEY,
 Nombre VARCHAR(100) NOT NULL,
 Descripcion VARCHAR(250) NULL,
 Icono VARCHAR(100) NULL,
 Orden INT NOT NULL DEFAULT(0),
 Activo BIT NOT NULL DEFAULT(1),
 FechaCreacion DATETIME NOT NULL DEFAULT(GETDATE()),
 UsuarioCreacion VARCHAR(100) NOT NULL,
 FechaModificacion DATETIME NULL,
 UsuarioModificacion VARCHAR(100) NULL
);

CREATE TABLE Pantallas(
 PantallaId INT IDENTITY(1,1) PRIMARY KEY,
 ModuloId INT NOT NULL,
 Nombre VARCHAR(100) NOT NULL,
 Ruta VARCHAR(250) NOT NULL,
 Descripcion VARCHAR(250) NULL,
 Icono VARCHAR(100) NULL,
 Orden INT NOT NULL DEFAULT(0),
 Activo BIT NOT NULL DEFAULT(1),
 FechaCreacion DATETIME NOT NULL DEFAULT(GETDATE()),
 UsuarioCreacion VARCHAR(100) NOT NULL,
 FechaModificacion DATETIME NULL,
 UsuarioModificacion VARCHAR(100) NULL,
 CONSTRAINT FK_Pantallas_Modulos FOREIGN KEY (ModuloId) REFERENCES Modulos(ModuloId)
);

CREATE TABLE Permisos(
 PermisoId INT IDENTITY(1,1) PRIMARY KEY,
 Codigo VARCHAR(100) NOT NULL,
 Descripcion VARCHAR(250) NULL,
 Activo BIT NOT NULL DEFAULT(1),
 FechaCreacion DATETIME NOT NULL DEFAULT(GETDATE()),
 UsuarioCreacion VARCHAR(100) NOT NULL,
 FechaModificacion DATETIME NULL,
 UsuarioModificacion VARCHAR(100) NULL
);

CREATE TABLE PantallasPermisos(
 PantallaPermisoId INT IDENTITY(1,1) PRIMARY KEY,
 PantallaId INT NOT NULL,
 PermisoId INT NOT NULL,
 Activo BIT NOT NULL DEFAULT(1),
 FechaCreacion DATETIME NOT NULL DEFAULT(GETDATE()),
 UsuarioCreacion VARCHAR(100) NOT NULL,
 FechaModificacion DATETIME NULL,
 UsuarioModificacion VARCHAR(100) NULL
 CONSTRAINT FK_PantallasPermisos_Pantallas FOREIGN KEY (PantallaId) REFERENCES Pantallas(PantallaId),
 CONSTRAINT FK_PantallasPermisos_Permisos FOREIGN KEY (PermisoId) REFERENCES Permisos(PermisoId),
 UNIQUE(PantallaId, PermisoId)
);

CREATE TABLE UsuariosRoles(
 UsuarioRolId INT IDENTITY(1,1) PRIMARY KEY,
 UsuarioId INT NOT NULL,
 RolId INT NOT NULL,
 Activo BIT NOT NULL DEFAULT(1),
 FechaCreacion DATETIME NOT NULL DEFAULT(GETDATE()),
 UsuarioCreacion VARCHAR(100) NOT NULL,
 FechaModificacion DATETIME NULL,
 UsuarioModificacion VARCHAR(100) NULL
 CONSTRAINT FK_UsuariosRoles_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
 CONSTRAINT FK_UsuariosRoles_Roles FOREIGN KEY (RolId) REFERENCES Roles(RolId)
);

CREATE TABLE RolesPantallasPermisos(
 RolPantallaPermisoId INT IDENTITY(1,1) PRIMARY KEY,
 RolId INT NOT NULL,
 PantallaPermisoId INT NOT NULL,
 Activo BIT NOT NULL DEFAULT(1),
 FechaCreacion DATETIME NOT NULL DEFAULT(GETDATE()),
 UsuarioCreacion VARCHAR(100) NOT NULL,
 FechaModificacion DATETIME NULL,
 UsuarioModificacion VARCHAR(100) NULL
 CONSTRAINT FK_RolesPantallasPermisos_Roles FOREIGN KEY (RolId) REFERENCES Roles(RolId),
 CONSTRAINT FK_RolesPantallasPermisos_PantallasPermisos FOREIGN KEY (PantallaPermisoId) REFERENCES PantallasPermisos(PantallaPermisoId),
 UNIQUE(RolId, PantallaPermisoId)
);

INSERT INTO Permisos (Codigo,Descripcion,Activo,UsuarioCreacion)
VALUES
('CONSULTAR','Permite consultar registros',1,'SYSTEM'),
('CREAR','Permite crear registros',1,'SYSTEM'),
('EDITAR','Permite editar registros',1,'SYSTEM'),
('ELIMINAR','Permite eliminar registros',1,'SYSTEM'),
('AUTORIZAR','Permite autorizar movimientos',1,'SYSTEM'),
('IMPRIMIR','Permite imprimir documentos',1,'SYSTEM'),
('EXPORTAR','Permite exportar información',1,'SYSTEM');
