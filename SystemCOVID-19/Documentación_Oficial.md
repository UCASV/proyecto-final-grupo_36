# ┏━━━━━━━━・✾・━━━━━━━━┓
# __________ DOCUMENTACION OFICIAL__________
# ┗━━━━━━━━・✾・━━━━━━━━┛
## _Sistema de Vacunación contra el COVID-19_

![imagen1](https://www.simbiotia.com/wp-content/uploads/diseno-de-salas-de-espera.jpg)


## Versión del software:
- 🌎Visual Studio Community - version 16.10
- 🐬MySQL Server - version 8.0.25
- 🐬MySQL Workbench - version 8.0
- 🔶Git Bash - version 2.32.0

# ━━━━━━━━※━━━━━━━━━━

## Version del Framework:
- Microsoft Entity Framework Core - version 5.0.301
# ━━━━━━━━※━━━━━━━━━━

## Patrón de diseño:
- **_View Model:_** Es un actor intermediario entre el modelo y la vista, contiene toda la lógica de presentación y se comporta como una abstracción de la interfaz. La comunicación entre la vista y el viewmodel se realiza por medio los enlaces de datos.
>Se utilizó dicho patrón en el sistema,
>por la simple razón de poder visualizar
>los datos necesarios que deben estar
>en ciertos formularios.

# ━━━━━━━━※━━━━━━━━━━
## Necesito tener una base de datos existente?:
**_Si_**, es necesario tener una base de datos creada para poder correr con total normalidad el programa; Sin embargo, no es necesario el preocuparse sobre como hacerlo, puesto que mas adelante se encuentra una guia para su debida instalacion.
>Tener en cuenta que debe tener instaladas las aplicaciones
>necesarias para correr el programa.
# ━━━━━━━━※━━━━━━━━━━
## Gestor utilizado en la base de datos:
- 👱**Usuario:** HenryChikito
- 🔐**Contraseña:** 12345
# ━━━━━━━━※━━━━━━━━━━
## Paquetes externos:
## 
| Tipo | Name |
| ------ | ------ |
| nugget | Microsoft.EntityFrameworkCore version 5.0.7 |
| nugget | Microsoft.EntityFrameworkCore.MySQL version 5.0.7 |
| nugget | Microsoft.EntityFrameworkCore.Design version 5.0.7 |
# ━━━━━━━━※━━━━━━━━━━
# Guía para instalar el software:
## _Aplicaciones Requeridas:_
-[Visual Studio Community 2019](https://visualstudio.microsoft.com/es/vs/community/) - Aplicacion de escritorio
-[MySQL Server 8.0.25](https://visualstudio.microsoft.com/es/vs/community/) - Aplicacion de escritorio
-[MySQL Workbench 8.0](https://visualstudio.microsoft.com/es/vs/community/)  - Aplicacion de escritorio
-[Git Bash](https://git-scm.com/downloads)  - Aplicacion de escritorio

# Pasos:
## _Clonar el repositorio:_
Una vez instalado el **"MySQL Server"**, **"MySQL Workbench"** y **"Git Bash"**, vamos a abrir la aplicacion del _Workbench_ y vamos a clonar los archivos de todo el programa en el repositorio de Github: https://github.com/UCASV/proyecto-final-grupo_36.

Para ello, vamos a dar _click_ en el botón verde que aparece a un costado derecho llamado:
```sh
🟢Code
```
Y luego vamos a darle _click_ al simbolo de copiar para poner en el portapapeles el link de ese repositorio:
```sh
📋
```
Procedemos a abrir el explorador de archivos, se elige una carpeta de su preferencia y dentro de ella daremos _click derecho_ para presionar la opción llamada: _"Git bash here"_. Una vez hecho esto, se abrirá una pestaña negra en la que se podrá escribir. Debe escribir el siguiente código:
```sh
git clone "URL del repositorio"
```
O puede simplemente copiarlo de aquí y presionar _ENTER_ despúes:
```sh
git clone https://github.com/UCASV/proyecto-final-grupo_36
```
## _____________________________________
## _Instalar la Base de Datos:_
Una vez hecho lo anterior vamos a volver a la aplicación del _Workbench_, vamos a dar _click_ al botón de _File_ y a la opción de _New Query Tab_ para abrir un nuevo archivo al programa. Hacemos esto una vez más para tener 2 pestañas vacias.

Procedemos a ir a la carpeta que se formó al clonar el repositorio en el paso anterior y buscaremos los archivos llamados: **_"Database"_** y **_"Data_Bank"_**; Ambos archivos los abriremos en el blog de notas usando el _click derecho_ y seleccionando la opción llamada: "Abrir con".

Copiaremos el texto de ambos documentos y pegaremos el de cada uno en las dos pestañas que creamos en el _Workbench_ por separado.

Luego, procedemos a realizar estos pasos con ambas pestañas:
- Vamos a seleccionar todo el texto de la pestaña presionando la combinación de teclas: Ctrl + A. Y vamos a dar _click_ al simbolo de rayo que se encuentra en la parte superior:
```sh
⚡️
```
Esto ejecutará todo el texto seleccionado, creara la Base de Datos y los documentos necesarios para su debido funcionamiento.
## _____________________________________
## _Correr el Instalador:_
Una vez hechos los pasos anteriores vamos a abrir el instalador para ejecutar la aplicación del proyecto. Vamos a buscar en la carpeta que se creo al clonar el repositorio en el explorador otra carpeta llamada: "SALUDGODSV" y daremos _doble click_ al archivo llamado:
```sh
setup
```
Inmediatamente se abrirá un programa de instalación para correrlo. Luego podrá usar el usuario y contraseña del gestor puestos más arriba para probar el programa.

>Para conocer las indicaciones de como utilizar el programa,
>revise el manual de usuario puesto en el repositorio, el cual se encuentra
>en formato PDF.
# ━━━━━━━━※━━━━━━━━━━
_Ministerio de Salud/ Gobierno de El Salvador / Sistema de vacunacion contra el COVID-19 ©2021_
