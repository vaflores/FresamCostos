# Estándar de Desarrollo Fresam v1.0

## Arquitectura

- ASP.NET Core Web API
- Angular
- SQL Server
- Entity Framework Core
- Dapper
- xUnit
- Git

## Convenciones de Base de Datos

### Tablas

Singular + PascalCase

Ejemplos:

- Usuario
- Rol
- Permiso
- Pantalla
- Modulo

### Claves Primarias

- UsuarioId
- RolId
- PermisoId
- PantallaId
- ModuloId

### Auditoría

Todas las tablas incluirán:

- FechaCreacion
- UsuarioCreacion
- FechaModificacion
- UsuarioModificacion

## Convenciones API

Prefijo:

/api/v1

Ejemplos:

/api/v1/usuarios
/api/v1/roles
/api/v1/permisos

## Convenciones Git

feat:
fix:
refactor:
chore:

## Convenciones Angular

Componentes:

- usuarios-list
- usuarios-form
- roles-list
- roles-form