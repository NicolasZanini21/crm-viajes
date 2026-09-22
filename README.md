ViajeYa - CRM para Agencia de Viajes

Proyecto personal de portfolio: un CRM interno pensado para el personal de una agencia de viajes chica, que vende principalmente paquetes armados (destino, fechas y servicios con cupo y precio definidos). No es un producto real en produccion, es una pieza completa de punta a punta (base de datos, API y frontend) construida para demostrar criterio de diseno y buenas practicas en .NET, Angular y PostgreSQL.

Stack tecnico

Backend: .NET 10 / C#, ASP.NET Core con Controllers (no Minimal API)
ORM: Entity Framework Core (Npgsql), enfoque Database First
Base de datos: PostgreSQL
Frontend: Angular 19, standalone components, sin SSR
Autenticacion: JWT (en progreso)

Estructura del repositorio

CrmViajes.Api es el backend .NET (API REST)
crm-viajes-web es el frontend Angular

Es un monorepo por simplicidad, ya que es un proyecto de portfolio de alcance acotado, no un sistema con equipos separados por repositorio.

Modelo de dominio

El sistema resuelve el flujo real de una agencia: catalogo de destinos y paquetes, un pasajero consulta por un paquete, y se genera una reserva que vincula pasajero y paquete, con su propio estado (Consultado, Cotizado, SenaPagada, PagoTotal, Viajo o Cancelado).

Entidades principales: Usuario (personal interno, autenticacion), Pasajero, Destino, Paquete, EstadoReserva (catalogo) y Reserva (tabla puente entre Pasajero y Paquete, con datos propios del vinculo como monto y fecha).

Decisiones de diseno

Reserva como tabla puente, no una relacion N a N pura. Pasajero y Paquete tienen una relacion muchos a muchos, pero se resuelve a traves de Reserva porque esa relacion tiene informacion propia (estado, monto acordado, fecha) que no pertenece a ninguna de las dos entidades. Es el patron correcto para cualquier relacion N a N con datos propios del vinculo.

Estado de reserva como tabla de catalogo con clave foranea, no como string libre ni numero suelto. Asi la integridad del dato vive en la base, no solo en el frontend, y el significado de cada estado es consultable dentro de la propia base de datos.

DTOs separados de las entidades de EF Core. Los controllers no reciben ni devuelven las entidades de EF Core directamente en las escrituras. Se adopto despues de un error real: exponer la entidad completa hacia que ASP.NET Core exigiera como requerida una propiedad de navegacion que ningun cliente deberia mandar. Los DTOs de escritura excluyen el Id, las propiedades de navegacion y los campos controlados por el servidor.

Un solo proyecto backend, sin separar en capas. Decision deliberada para no sobre disenar un MVP de 6 tablas. Separar en capas tiene sentido cuando la complejidad del dominio lo justifica, no por defecto.

Frontend sin SSR. Es un sistema interno detras de login, sin necesidad de SEO ni de servir contenido a usuarios anonimos. SSR habria sumado complejidad de despliegue sin beneficio real para este caso de uso.

Dinero en tipo Numeric, nunca Float ni Money. Evita errores de redondeo y no ata el dato al locale del servidor de base de datos.

Null como todavia no se sabe, nunca un placeholder como 0. Por ejemplo, el monto acordado de una reserva es nulo hasta que se cotiza. Un 0 ahi seria un dato falso, no una ausencia de dato.

Como correrlo localmente

Backend:

cd CrmViajes.Api
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Database=viajeya;Username=tu_usuario;Password=tu_password"
dotnet run

Requiere una base PostgreSQL llamada viajeya ya creada con el esquema correspondiente.

Frontend:

cd crm-viajes-web
npm install
ng serve

La app queda disponible en localhost 4200 y consume la API en localhost 5149, configurado en cada servicio de Angular.

Estado actual

Implementado: modelo de datos completo en PostgreSQL con constraints e integridad referencial. CRUD completo en el backend de Pasajero, Destino, Paquete y Reserva, con DTOs y validacion. CORS configurado para desarrollo. Frontend con los listados de las 4 entidades consumiendo la API real. Alta de Pasajero con formulario reactivo y validacion. Ficha de Pasajero con detalle e historial de reservas. Identidad visual propia, con paleta de colores, tipografia y sidebar de navegacion colapsable.

Pendiente: login y autenticacion JWT. Edicion y eliminacion de registros desde la interfaz. Busqueda y filtros en tiempo real. Mostrar nombres legibles en la tabla de Reservas en vez de IDs numericos. Sistema de puntos y fidelizacion para pasajeros. Testing automatizado.

Autor

Nicolas Zanini - www.linkedin.com/in/nicolaszanini