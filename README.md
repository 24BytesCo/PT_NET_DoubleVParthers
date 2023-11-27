**Proyecto con Autenticación, CRUD y Funcionalidades Avanzadas**

---

### Descripción del Proyecto

Este proyecto representa una aplicación completa que implementa un sistema de autenticación con Identity, algunas operaciones CRUD (Create, Read) para usuarios y personas, y diversas funcionalidades avanzadas. A continuación, se detallan las características y enfoques utilizados durante el desarrollo.

### Tecnologías Utilizadas

- **.NET:** La plataforma .NET se empleó como base para el desarrollo del backend, aprovechando sus capacidades para la creación de aplicaciones robustas y seguras.

- **SQL Server:** Como sistema de gestión de bases de datos, se eligió SQL Server para garantizar un almacenamiento eficiente y confiable de los datos.

### Principios de Arquitectura Aplicados

- **Arquitectura Limpia (Clean Architecture):** Se aplicaron los principios de arquitectura limpia para garantizar la separación adecuada de las capas del sistema, facilitando el mantenimiento y la escalabilidad.

### Patrones de Diseño Implementados

- **Patrón de Repositorio:** Para gestionar de manera eficiente el acceso a los datos y abstraer la lógica de acceso a la base de datos.

- **Patrón Mediador:** Implementado para desacoplar los componentes del sistema y permitir una comunicación más eficiente entre ellos.

- **Patrón Unidad de Trabajo:** Para coordinar las operaciones en la base de datos y garantizar la consistencia de los datos.

- **Patrón CQRS (Command Query Responsibility Segregation):** División de las operaciones de lectura (query) y escritura (command) para optimizar el rendimiento y la escalabilidad.

### Funcionalidades Implementadas

- **Sistema de Autenticación con Identity:** Se integró el sistema de autenticación Identity de .NET para gestionar usuarios y sesiones de manera segura.

- **Operaciones CRUD para Usuarios y Personas:** Se implementaron operaciones para crear y leer usuarios y personas.

- **Middleware para Manejar Excepciones:** Se utilizó middleware para manejar las excepciones a nivel global, mejorando la robustez y la capacidad de respuesta del sistema.

- **Mensajes Personalizados para Excepciones:** Se implementaron mensajes personalizados para las excepciones, facilitando la identificación y resolución de problemas.

- **Automapper:** Se utilizó Automapper para facilitar el mapeo entre entidades y modelos DTO (Data Transfer Object).

- **Migraciones y Data Annotations:** Se emplearon migraciones de base de datos y Data Annotations para gestionar y validar la estructura de la base de datos.

### Capas del Proyecto

El proyecto se estructuró en las siguientes capas:

- **API:** Contiene los controladores y la configuración de la API.

- **Infrastructure:** Incluye la implementación concreta de los repositorios, servicios y cualquier lógica de acceso a datos.

- **Application:** Contiene la lógica de la aplicación, incluyendo los servicios de aplicación, los comandos y las consultas.

- **Domain:** Define las entidades del dominio y las interfaces para los repositorios y servicios.

### Instrucciones de Ejecución

Para ejecutar la aplicación localmente, sigue estos pasos:

1. Clona este repositorio en tu máquina local.
2. Asegúrate de tener las versiones adecuadas de .NET y SQL Server instaladas.
3. Configura la cadena de conexión a la base de datos en los archivos de configuración.
4. Ejecuta las migraciones para inicializar la base de datos.
5. Ejecuta la aplicación utilizando las herramientas de desarrollo de .NET.

¡Listo! Ahora puedes explorar y experimentar con la aplicación.
