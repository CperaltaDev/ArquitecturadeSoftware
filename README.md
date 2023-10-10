
# Demo arquitectura de software Api rest

Arquitectura del servicio API-rest con framework NET 6 que implementa el patrón de diseño inyección de dependencias (DI) de forma estándar y obligatoria. 

## Capas propuestas 🚀

Orientado a N-Capas independientes y con funciones especificas de la sigueinte manera:

### 01.ServicesLayer 📋

Capa de presentación de las clases de servicio implementadas en los controladores
**Paquetes**: Nlog 5, Nlog.Web.AspNetCore 5, Swashbuckle.AspNetCore 6 (swagger, tokens JWT entre otros) 
```
* Carpeta Controllers: Clases de presentación para los diferentes servicios según su verbo
* Helpers: Clases para proveer servicios personalizados, se implementa personalización del atributo Authorize 	
* Middleware: Clases personalizables para afectar la atención de los request a los servicios. Se implementa para validar el acceso por medio del token JWT
* Archivo de configuración del servicio api appsettings.json: 
* Archivo de configuración del paquete Nlog.config
* Clase program.cs: clase para implementar los middlewares, agregar servicios y características al componente.
* Carpeta Examples: clases para documentar los resquest y response con Swagger según estándar openAPI
```

### 02.BusinessLayer 📋

Capa para implementar las reglas de negocio, definición de servicios y capacidades de los controladores, así como las integraciones con servicios externos y 
objetos necesarios para construir el servicio. Esta es la UNICA capa se realiza las gestiones de errores por medio de bloques try – catch.
**Paquetes**: AutoMapper.Extensions.Microsoft.DependencyInjection

```
* Clases de servicio: son las implementaciones convocadas en los controladores, allí se realiza la implementación de las interfaces de acceso a datos, 
  interfaces de servicio, se realiza la transformación de las clases DTO a Entidades o viceversa. Las clases de entidades solo se deben manipular en 
  esta capa y no deben ser convocadas en otras capas, evitar ello en lo máximo posible.  
* Carpeta Tools: Es la ubicación para todas las clases que son utilidades complementarias a las clases de servicio, por ejemplo, clases de transformación
  de datos, utilidades de cifrado y descrifrado de datos entre otras.
* Caperta AutoMapper: Es la ubicacion de las clases que implementan los perfiles necesarios para implementar autommaper y sus diferentes mapeos entre las 
  clases de modelo-entidades y los DTO construidos en el proyecto.  
* Carpeta Interfaces: Clases interfaz de las clases de servicio para implementar las capacidades de los controladores.
* Carpeta Integration: Clases de integración con servicios externos y servicios internos transversales. 


```

### 03.DataLayer 📋

Capa para el acceso a datos y el mapeo ORM de la o las bases de datos.
**Paquetes**: Entity Framework Core 6, Entity Framework Core SqlServer 6

```
* Las clases terminadas en context implementan la técnica code-first
* Carpeta Interfaces: Clases interfaces del repositorio creado para acceder y manipular los datos de la base de datos
* Carpeta Repository: Clases de implementación para acceder y manipular los datos de la BD.
```

### 04.CrossLayer 📋

Capa para clases transversales 

```
* Carpeta Entities: clases de entidad (tablas, Store Procedure)
* Carpeta Dto: clases de los data transfer object identificando su tipo de implementación en los métodos; In (Parámetros de entrada), Out (objeto de salida)
* Carpeta Common: Clases para crear propiedades extendidas sobre los DTO y clases Enum 

```

## Lecturas complementarias 🔧

* [Tutorial Api](https://docs.microsoft.com/es-es/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio) - Tutorial: Creación de una API web con ASP.NET Core
* [Cambios importantes en .NET 6](https://docs.microsoft.com/es-es/dotnet/core/compatibility/6.0) - Articulo oficial sobre los cambios en Net 6
* [Plantillas Net 6](https://docs.microsoft.com/es-es/dotnet/core/tutorials/top-level-templates) - Articulo oficial sobre las plantillas que genera Net 6
* [Inyección de dependencias](https://docs.microsoft.com/es-es/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0) - Inserción de dependencias en ASP.NET Core
* [Code-First](https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx) - Tutorial: What is Code-First?
* [Swagger](https://editor.swagger.io/) - Editor en linea de Swagger
* [AutoMapper](https://docs.automapper.org/en/stable/index.html) - Tutorial AutoMapper


## Autores ✒️

* **Carlos Peralta** - *Arquitectura de Software* - [cperalta](cperalta)




