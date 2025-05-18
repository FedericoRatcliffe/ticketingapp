# 🎟️ TicketingApp

Aplicación web para la gestión de eventos, venta de entradas, validación QR y procesamiento de pagos con MercadoPago.  
Arquitectura basada en principios de **Clean Architecture**, desacoplando responsabilidades por capa y facilitando la escalabilidad y el testing.

---

## 📁 Estructura del Proyecto

TicketingApp.sln

- 📦 TicketingApp.API → Proyecto principal Web API (.NET Core)
- 📦 TicketingApp.Application → Lógica de aplicación (casos de uso, DTOs, validaciones)
- 📦 TicketingApp.Domain → Entidades, interfaces, lógica de dominio pura
- 📦 TicketingApp.Infrastructure → Acceso a datos (EF Core), MercadoPago, Email, QR
- 📦 TicketingApp.Persistence → Implementaciones de almacenamiento (EF Core, contexto DB)
- 📦 TicketingApp.Shared → Constantes, utilidades comunes, clases base, etc.
- 📦 TicketingApp.Tests → Tests unitarios y de integración

---

## 📦 Detalle por proyecto

### `TicketingApp.API` - Web API

- Punto de entrada HTTP
- Contiene controladores, middlewares, configuración Swagger, inyección de dependencias
- No tiene lógica de negocio ni acceso directo a la base de datos

**Carpetas comunes:**

- Controllers/
- Middlewares/
- Extensions/ → StartupExtensions.cs, SwaggerConfig.cs, etc.
- Filters/ → Autorización, validación
- Program.cs → .NET 6+



---

### `TicketingApp.Application` - Capa de aplicación

- Casos de uso como crear evento, comprar entrada, validar QR
- Contiene DTOs, validadores (FluentValidation), interfaces de servicios
- No conoce EF ni frameworks externos

**Carpetas comunes:**

- DTOs/
- Interfaces/ → ISendEmailService, IPaymentService
- UseCases/ → CreateEventHandler.cs, PurchaseTicketHandler.cs
- Validators/


---

### `TicketingApp.Domain` - Modelo de dominio

- Entidades puras como `Event`, `Ticket`, `User`, `Role`
- Value objects, enums y reglas de negocio internas
- Interfaces como `IEventRepository`, `ITicketValidator`

**Carpetas comunes:**

- Entities/
- ValueObjects/
- Enums/
- Interfaces/


---

### `TicketingApp.Infrastructure` - Servicios técnicos

- Implementaciones técnicas: Email, MercadoPago, QR, Logger, etc.
- Implementa interfaces de Domain y Application
- Puede contener repositorios que interactúan con EF Core o Dapper

**Carpetas comunes:**

- Services/ → EmailSender.cs, QRCodeGenerator.cs, MercadoPagoPaymentService.cs
- Repositories/
- Extensions/


---

### `TicketingApp.Persistence` - Acceso a datos (EF Core)

- Define `TicketingDbContext`
- Configuración con Fluent API
- Migrations
- Implementación de interfaces de repositorio

**Carpetas comunes:**

- DbContexts/
- Configurations/



---

### `TicketingApp.Shared` - Utilidades comunes

- Excepciones personalizadas: `BusinessException`, `NotFoundException`
- Helpers (fechas, validaciones)
- Constantes (roles, claims)
- Clases base reutilizables

---

### `TicketingApp.Tests` - Proyecto de tests

- Tests unitarios para Application y Domain
- Tests de integración para API e Infrastructure
- Uso de xUnit o NUnit, más Moq, FluentAssertions, etc.

---

## 🔁 Referencias entre proyectos

TicketingApp.API
- TicketingApp.Application
- TicketingApp.Domain
- TicketingApp.Infrastructure
- TicketingApp.Shared

TicketingApp.Application
- TicketingApp.Domain
- TicketingApp.Shared

TicketingApp.Infrastructure
- TicketingApp.Domain
- TicketingApp.Application
- TicketingApp.Shared

TicketingApp.Persistence
- TicketingApp.Domain
- TicketingApp.Infrastructure (o puede ser parte de ella)
- TicketingApp.Shared

TicketingApp.Tests
- Todos según lo que se testea



---

## 🛠️ Tecnologías utilizadas

- ASP.NET Core 8
- Entity Framework Core
- FluentValidation
- JWT (Json Web Token)
- MercadoPago SDK
- QRCoder
- MailKit / SendGrid
- xUnit + Moq + FluentAssertions

---

