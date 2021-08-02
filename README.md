# Renta-de-vehiculos
Proyecto renta de vehículos

La funcíon principal de este proyecto es gestionar el CRUD de la renta de vehículos, sin embargo tambien gestiona el CRUD de reserva de vehículos, de devolución de vehículos, de clientes, de vehículos y de las diferentes ciudades donde se puede implementar el proyecto.

Primero se debe restaurar el archivo llamado BackUp_DBRentaVehiculos en SQL Server en el cual esta la base de datos implementada para este proyecto, luego se debe abrir el archivo llamado CON_WebProyectoFinalDesarrolloSoftware.xml y dentro de la etiqueta (SERVIDOR) escribir el nombre del servidor de SQL Server, luego copiar y pegar el archivo en la ruta C:\Program Files (x86)\IIS Express.

Todos los archivos .sln se abren con Visual Studio.

Dentro de la carperta libComunes se encuentra el proyecto libComunes.sln en el cual hay una carpeta llamada CapaDatos y otra llamada CapaObjetos, dentro de la carpeta CapaDatos hay una clase llamada ClsConexion.cs y su función principal es abrir, cerrar la conexión de la base de datos y gestionar las sentencias SQL de la misma y hay una clase llamada ClsParametros.cs dentro de esta carpeta la cual no es utilizada en el proyecto. Dentro de la carpeta llamada CapaObjetos hay una clase llamada ClsCombos.cs y su función principal es llenar un DropDownList segun una consulta SQL que se hace a la base de datos y hay una clase llamada ClsGrid.cs y su función principal es llenar un GridView segun una consulta SQL que se hace a la base de datos.

El proyecto libComunes.sln se agrega como referencia al proyecto llamado ProyectoFinalDesarrolloSoftware.sln que esta dentro de la carpeta ProyectoFinalDesarrolloSoftware, dentro de este proyecto hay una carpeta llamada ProyectoFinal y dentro de esta carpeta hay 17 clases las cuales en resumen son las que definen las sentencias SQL para realizar el CRUD de la base de datos y tambien definen que información se muestra en los elementos DropDownList y GridView de la interfaz de usuario y en estas clases se agrega el using de libComunes para poder utilizar sus clases.

El proyecto ProyectoFinalDesarrolloSoftware.sln se agrega como referencia al proyecto llamado WebProyectoFinalDesarrolloSoftware.sln que esta dentro de la carpeta WebProyectoFinalDesarrolloSoftware, dentro de este proyecto hay tres carpetas, una llamada Imagenes Gama Baja la cual contiene las imagenes de los vehículos gama baja utilizados para la renta o reserva, otra llamada Imagenes Gama Media la cual contiene las imagenes de los vehículos gama media utilizados para la renta o reserva y por ultimo esta la carpeta llamada ProyectoFinal la cual contiene las diferentes interfaces de usuario implementadas en el proyecto, dentro de los archivos aspx.cs de las interfaces se agrega el using de ProyectoFinalDesarrolloSoftware para poder utilizar sus clases.

Para ver el proyecto en funcionamiento se debe abrir el archivo llamado WebProyectoFinalDesarrolloSoftware.sln y ejecutarlo.


