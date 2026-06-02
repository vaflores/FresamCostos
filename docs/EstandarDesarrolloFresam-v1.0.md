# Estándar de Desarrollo Fresam v1.0

## 1. Objetivo

Definir las convenciones de desarrollo para el Sistema Integral para Control de Costos de Fresam con el fin de mantener consistencia, mantenibilidad y escalabilidad durante todo el ciclo de vida del proyecto.

---

# 2. Stack Tecnológico

## Backend

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* Dapper
* SQL Server 2022

## Frontend

* Angular 19
* TypeScript
* Bootstrap 5

## Control de Versiones

* Git
* GitHub

---

# 3. Arquitectura

Estructura inicial:

```text
backend/Fresam

├── Fresam.API
├── Fresam.Domain
├── Fresam.Application
```

Estructura futura:

```text
backend/Fresam

├── Fresam.API
├── Fresam.Domain
├── Fresam.Application
├── Fresam.Infrastructure
```

---

# 4. Convenciones de Nombres

## Clases

Utilizar PascalCase.

Ejemplos:

```text
Usuario
Rol
Permiso
Modulo
Pantalla
Empleado
```

---

## Propiedades

Utilizar PascalCase.

Ejemplos:

```text
UsuarioId
NombreUsuario
FechaCreacion
```

---

## Métodos

Utilizar PascalCase.

Ejemplos:

```text
ObtenerPorId
Guardar
Actualizar
Eliminar
```

---

# 5. Entidades

## Regla General

Las entidades deben nombrarse en singular.

Correcto:

```text
Usuario
Rol
Permiso
Agricultor
Recepcion
```

Incorrecto:

```text
Usuarios
Roles
Permisos
Agricultores
Recepciones
```

---

## Entidades Relacionales

Formato:

```text
EntidadOrigen + EntidadDestino
```

Ejemplos:

```text
UsuarioRol
RolPermiso
PantallaPermiso
```

---

# 6. Claves Primarias

Formato:

```text
NombreEntidad + Id
```

Ejemplos:

```text
UsuarioId
RolId
PermisoId
ModuloId
PantallaId
```

No utilizar:

```text
Id
id
usuario_id
```

---

# 7. Tablas SQL Server

Las tablas se nombrarán en plural.

Ejemplos:

```text
Usuarios
Roles
Permisos
Modulos
Pantallas
```

---

# 8. Auditoría

Todas las entidades persistentes deberán heredar de BaseEntity.

Campos obligatorios:

```text
FechaCreacion
UsuarioCreacion
FechaModificacion
UsuarioModificacion
```

Implementación:

```csharp
public abstract class BaseEntity
{
    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = string.Empty;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
```

---

# 9. Seguridad

## Usuarios

* Un usuario puede tener múltiples roles.
* Un usuario puede estar asociado a un empleado.
* La asociación con empleado es opcional.

## Roles

Los permisos se asignarán mediante roles.

## Permisos

Los permisos controlarán acceso a funcionalidades específicas.

Ejemplos:

```text
USUARIOS_VER
USUARIOS_CREAR
USUARIOS_EDITAR
USUARIOS_ELIMINAR
```

---

# 10. Menú Dinámico

El menú de Angular será generado desde base de datos mediante:

```text
Modulo
Pantalla
Permiso
```

Esto permitirá agregar opciones sin modificar código del frontend.

---

# 11. Control de Versiones

Rama principal:

```text
main
```

Convención de commits:

```text
feat: nueva funcionalidad
fix: corrección de error
docs: documentación
refactor: mejora interna
chore: tareas de mantenimiento
```

Ejemplos:

```text
feat: add user management
fix: correct login validation
docs: update development standards
```
