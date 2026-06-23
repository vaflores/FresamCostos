
# Fresam Context v2.1
## Documento Maestro del Proyecto

### Propósito
Este documento es la referencia principal para la continuidad del proyecto Fresam.

---

# 1. Resumen Ejecutivo

Nombre: Fresam - Sistema Integral para Control de Costos

Objetivo:
Centralizar la administración, captura, procesamiento y análisis de costos operativos de Fresam mediante una plataforma web moderna.

Estado actual:
Módulo Seguridad en desarrollo avanzado.

---

# 2. Visión del Proyecto

Construir una plataforma escalable que permita controlar:
- Seguridad
- Administración
- Materiales
- Producción
- Recepciones
- Nómina
- Mantenimiento
- Costos
- Reportes

Beneficios:
- Información centralizada
- Seguridad basada en roles y permisos
- Menor dependencia de Excel
- Escalabilidad
- Mantenibilidad

---

# 3. Stack Tecnológico Definitivo

## Backend
- ASP.NET Core 8
- Dapper
- SQL Server 2022
- JWT Authentication
- Authorization Policies
- xUnit

## Frontend
- Angular 19
- Angular Material
- Reactive Forms
- RxJS
- Standalone Components

## Infraestructura
- IIS
- GitHub
- Windows Server

---

# 4. Arquitectura General

Angular Material
-> Angular
-> API REST
-> Application Layer
-> Repositories
-> SQL Server

---

# 5. Arquitectura Backend

## Fresam.API
- Controllers
- JWT
- Authorization
- Swagger

## Fresam.Application
- DTOs
- Interfaces
- Servicios
- Reglas de negocio

## Fresam.Domain
- Entidades

## Fresam.Infrastructure
- Repositories
- Dapper
- SQL Server

---

# 6. Decisiones Arquitectónicas

ADR-001
Dapper seleccionado sobre Entity Framework.

Motivos:
- Mayor control SQL
- Rendimiento
- Simplicidad operacional

ADR-002
Angular Material seleccionado como estándar visual.

ADR-003
JWT para autenticación.

ADR-004
IIS para hosting.

---

# 7. Estándares de Desarrollo

## Backend
- Async/Await obligatorio
- DTO separado de Entidad
- Repository Pattern
- Service Layer
- Dependency Injection
- Dapper

## Frontend
- Standalone Components
- Angular Material
- Reactive Forms
- Guards
- Interceptors

---

# 8. Módulo Seguridad

## Entidades

Usuarios
Roles
Modulos
Pantallas
Permisos
UsuarioRol
PantallaPermiso
RolPantallaPermiso

## JWT

Claims:
- UsuarioId
- UsuarioNombre
- Permisos

Formato de permisos:

PantallaId.PermisoCodigo

Ejemplos:
1.Consultar
1.Crear
1.Modificar
1.Eliminar

## Componentes Implementados

- PermissionRequirement
- PermissionAuthorizationHandler
- PermissionPolicyProvider

## PerfilSeguridadUsuario

Estructura:

Usuario
-> Modulos
-> Pantallas
-> Permisos

Base para menú dinámico Angular.

---

# 9. Estado Actual Backend

Completado:

Semana 1
- Arquitectura solución
- Repositories
- Services
- Dapper

Semana 2
- CRUD Create
- CRUD Read

Semana 3
- Login
- JWT
- Claims

Semana 4
- PerfilSeguridadUsuario

Semana 5
- Policies dinámicas

Semana 6
- IIS
- Swagger
- CORS

---

# 10. Estado Actual Frontend

Completado:

- Angular 19
- Routing
- HttpClient
- AuthService
- Login Component
- Angular Material
- Reactive Forms
- Spinner
- Mensajes visuales de error
- Integración Angular -> API
- Recepción JWT

---

# 11. Infraestructura y Despliegue

Desarrollo:

Angular
http://localhost:8080

API
http://localhost:5001

Producción objetivo:

https://fresam

https://fresam/api

IIS:
- Application Pool dedicado
- SQL Server autenticación SQL
- Publicación Framework Dependent

---

# 12. Cronograma Histórico

Fase Seguridad

Semana 1
Arquitectura y solución

Semana 2
Catálogos base

Semana 3
Autenticación

Semana 4
Perfil de seguridad

Semana 5
Autorización dinámica

Semana 6
Angular + IIS

---

# 13. Backlog Seguridad

Frontend:
- TokenService
- Persistencia JWT
- Logout
- PerfilSeguridad Angular
- Menú dinámico
- AuthGuard
- AuthInterceptor
- PermissionService

Backend:

Usuarios
- Update
- Delete

Roles
- Update
- Delete

Modulos
- Update
- Delete

Pantallas
- Update
- Delete

Permisos
- Update
- Delete

UsuarioRol
- Delete

PantallaPermiso
- Delete

RolPantallaPermiso
- Delete

---

# 14. Roadmap Próximo

1. TokenService
2. Guardar JWT
3. Logout
4. PerfilSeguridad Angular
5. Menú dinámico
6. AuthGuard
7. AuthInterceptor
8. PermissionService
9. CRUD Update/Delete Seguridad

---

# 15. Convenciones Git

Commits tipo:

feat(security):
feat(ui):
fix(api):
docs(project):

Git es la fuente de verdad.

---

# 16. Continuidad

Para retomar en un nuevo chat:

"Continuemos Fresam. Usa FresamContext-v2.1 como documento maestro."

Este documento debe actualizarse al cierre de cada hito importante.
