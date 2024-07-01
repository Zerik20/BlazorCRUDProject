# BlazorCRUDProject

Este proyecto es una aplicación CRUD utilizando Blazor. Sigue los pasos a continuación para configurar y ejecutar el proyecto en tu entorno local.

## Requisitos Previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Instrucciones de Instalación

1. **Clonar el Repositorio**

   ```bash
   git clone https://github.com/Zerik20/BlazorCRUDProject.git
   cd BlazorCRUDProject

2. **Crear las Tablas de la Base de Datos**
  -- scrip.sql
   
3. **Modifica la cadena de conexión**
  -- En el archivo json
   {
  "ConnectionStrings": {
    "DefaultConnection": "Server=tu_servidor;Database=tu_base_de_datos;User Id=tu_usuario;Password=tu_contraseña;"
  }
}

4. **Restaura dependencias y ejecuta**
   

