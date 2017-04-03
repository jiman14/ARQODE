# ¿Qué es ARQODE?
ARQODE es una solución de **código abierto** complementaria a Visual Studio para **escribir aplicaciones** en tiempo real o **en tiempo de ejecución**. 

Está desaroollada en C# .Net 4.6 y Visual Studio Community Edition 2017.

ARQODE "amplia" la funcionalidad de Visual Studio "Edit and Continue" permitiendo salvar dos grandes limitaciones:
1. Añádir, modificar y eliminar funciones.
2. Añadir y eliminar eventos.

ARQODE consta de dos herramientas:
1. Un gestor de aplicaciones: **ARQODE APP Manager**
2. Un editor de programas: **ARQODE Program editor**.

# ¿Por qué programar con ARQODE?
AROQDE permite programar "desde dentro" de la aplicación, rodeado de los objetos que necesitas cargados, con la flexibilidad de mover la línea de ejecución adelante y atrás en el tiempo. Visual Studio aporta además:
- Revisión de errores sintácticos en tiempo real.
- Posibiildad de volver a la línea de ejecución fallida después de un error.
- Acceder a la ventana de "Inmediato" para ejecutar comandos.

# ¿Cómo programar con ARQODE?
Una vez creada una aplicación en ARQODE APP Manager, ésta se carga en el proyecto ARQODE y lanza la ejecución del nuevo proyecto en Visual Studio.

## Crear la estructura de la aplicación a alto nivel:

1. Crear la funcionalidad a alto nivel en el árbol de Programas
    * Cada programa contiene procesos o llamadas a otros programas.
2. Crear los procesos, para ello hay un árbol de contenedores de procesos y por cada nodo una lista de procesos asociados.
3. Asignar un programa a un evento de un control.
    * El primer programa debe asignarse al evento Load del formulario principal.

## La unidad de programación: el proceso

Es la unidad mínima de programación, el código del proceso se ejecuta dentro de un contexto que permite
definir entradas y salidas, y también permite tener una configuración propia. Con lo cual **un proceso puede configurarse** desde la interfaz del "Editor de programas".

## Funcionalidad y programas

Los programas son básicamente contenedores de procesos y llamadas a otros programas, que se ejecutan a través de eventos. 

Nota: con el objetivo de una mejor reutilización del código, es recomendable hacer pequeños programas, pero que a su vez resuelvan completamente una funcionalidad. 

Las llamadas recursivas a programas son uno de los pilares de este modelo de programación y, para hacer un mejor seguimiento, en la consola de salida de Visual Studio se podrá ver la traza de procesos / programas ejecutados en todo momento.

Para controlar el flujo del programa hay dos recursos:
1. Se puede detener la ejecución del programa desde el código de cualquier proceso.
2. Se puede encolar la ejecución a un programa, para que se ejecute siempre al final añadiendo el prefijo "&" a la ruta del programa destino dentro de la configuración de la llamada al programa.

Nota: las variables del programa activo se transfieren automáticamente al programa llamado, pero para que pueda hacer uso de ellas
el proceso "hijo" debe definir variables de programa con el mismo nombre.

## Formularios o Vistas

Los formularios, también llamados en ARQODE **vistas**, pueden contener variables que estarán activas mientras el formulario lo esté. Nota: es recomendable introducir en el formulario principal todas las variables globales (en tiempo de ejecución) del programa.

Cada formulario genera un fichero mapeado dentro de la carpeta UI de ARQODE que se puede usar para acceder a los controles
por nombre, a demás de a sus variables de vista. El fichero mapeado se guarda en la carpeta UI junto al correspondiente formulario con el sufijo "_map". 

## Codificar en ARQODE:

Para lanzar la nueva aplicación y empezar a escribir código pulsar en "Run app" en el "ARQODE Program editor". Esto hará saltar un punto 
de ruptura en el fichero "Coder.cs", que será la ventana de acceso a todo el código de la aplicación.

En ella se pueden ver las variables a las que tenemos acceso que principalmente permiten:
1. Acceder a todos los controles de todos los formularios (activos).
2. Acceder a las variables del programa, del proceso y de los formularios.
3. Acceder a los argumentos del evento que ha lanzado el programa.

Nota: las variables se pueden ver en el propio fichero "Coder.cs" 

## Modificar código. El punto de ruptura

Existe **un punto de ruptura del fichero "Coder.cs" que no se debe eliminar**. Se activa en estos casos:
1. La primera vez que se crea un proceso. 
2. Cuando la ejecución del programa pasa por un proceso cuyo check "Editor" (de la lista de procesos del programa) está marcado.
3. Cuando se pulsa sobre el menú contextual "Editar código" en la lista de procesos del programa.
4. Si hay un error en el código, el proceso afectado se carga automáticamente en el fichero "Coder.cs"

Nota: Si no estás familiarizado con la opción "Edit and continue" de Visual Studio, te recomendamos primero leer sobre ella [aquí](https://msdn.microsoft.com/en-us/library/x17d7wxw.aspx).
También es imprescindible usar los [puntos de ruptura] (https://channel9.msdn.com/Blogs/Visual-Studio-Shorts/Using-Breakpoints-for-Debugging-in-Visual-Studio-2015).

# ¿Cómo funiona ARQODE?

ARQODE es un sistema de programación modular de alto nivel que faciilta la integración y la codificación a través de una interfaz gráfica. Los metadatos gestionados por ARQODE se almacenan en formato JSON y se gestionan internamente usando la librería [Newtonsoft.Json] (https://www.nuget.org/packages/Newtonsoft.Json/).

## Sistema de ficheros de ARQODE. 

Cada vez que se genera una nueva aplicación en ARQODE se crea una estructura de carpetas (por defecto dentro de la carpeta "Apps" de la solución) que contiene:
- AppData: Datos relativos a la estructura y funcionamiento del proyecto ARQODE:
    * Ficheros descriptivos de programas y procesos.
    * Ficheros descriptivos de vistas.
    * Librerías
    * Recursos    
- Data: Datos del programa:
    * Errores, datos de depuración y de traza de ejecución
    * Datos globales

## Exportación e importación de proyectos

El proyecto ARQODE sólo mantiene activo un proyecto a la vez, por lo que para gestionar múltiples proyectos la aplicación "App manager" 
permite exportar e importar proyectos. 

De hecho cargar un proyecto "no activo" desde la "App manager" supone exportar previamente el proyecto activo (esto se hace automáticamente) a la carpeta "AppData\VS_PROJECT", que es a su vez un proyecto funcional de Visual Studio, perparado para ser compilado.

La exportación del proyecto está orientada a la ejecución de la aplicación sin necesidad de cargar los metadatos de programas y procesos. Por lo que el contenido de los mismos se integra dentro del proyecto exportado. Por lo que sólo será necesario incluir la carpeta "Data" dentro de la carpeta donde se encuentre el ejecutable.

## Añadir librerías de terceros al proyecto

La integración de librerías no está automatizada desde el Editor de programas, se recomienda gestionar las librerías de terceros desde el getor de paquetes de Visual Studio y hacer referencia a ellas desde el fichero "Coder.cs" sin hacer el "using" de la librería previamente. Esto es, escribiendo la ruta absoluta a la funcionalidad deseada desde código.

## Otras funcionalidades

Hay mucha funcionalidad oculta bajo menús contextuales que es recomendable explorar, pues ayudan a:
- La organización y a la edición de programas y procesos.
- La creación de variables. 
- El acceso al código fuente.

Además la barra superior incluye:
- Un buscador que rastrea la estructura de programas y procesos en ARQODE (no el código fuente).
- Un mapeador de vistas "Map UI" en ficheros json, esto permite la edición de controles gráficos en tiempo real, pues la configuración de los mismos se carga desde el fichero json.
- Un comprobador de entradas y salidas no asignadas
- Información de traza y errores


# Usar ARQODE

1. Descargar la solución
2. Ejecutar el APP Manager, crear un proyecto y cargarlo
3. Empezar a escribir programas, procesos y continuación ejecutar "Run app" para empezar a codificar.
