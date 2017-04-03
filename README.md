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

Es la unidad mínima de programación, se trata literalmente de un trozo de código que se ejecuta dentro de un contexto y que permite
definir entradas y salidas, así como tener una configuración propia. 

## Funcionalidad en programas

Se trata de un contenedor de procesos o llamadas a otros programas que se ejecuta a través de un evento. Con el objetivo de una mejor
reutilización del código, es recomendable hacer pequeños programas, pero que a su vez resuelvan completamente una funcionalidad. 

Las llamadas recursivas a programas son un pilar de este modelo de programación y para hacer un mejor seguimiento en la consola de salida
de Visual Studio se podrá ver la traza de procesos / programas ejecutados en todo momento.

Para controlar el flujo del programa hay dos grandes recursos:
1. Poder detener la ejecución del programa dentro de cualquier proceso.
2. Poder encolar la llamada a un programa, para que se ejecute siempre al final.
Además el paso de variables del programa activo al programa llamado se hace automáticamente.

## Formularios o Vistas

Cada formulario o vista en ARQODE puede contener variables que estarán activas mientras el formulario lo esté. Por lo que es recomendable
introducir en el formulario principal todas las variables globales en tiempo de ejecución del programa.

Cada formulario genera un fichero mapeado dentro de la carpeta UI de ARQODE que facilita el acceso a los controles por nombre, a demás de 
a sus variables de vista.

## Escribir código:

Para lanzar la nueva aplicación y empezar a escribir código pulsar en "Run app" en el ARQODE Program editor. Esto hará saltar un punto 
de ruptura en el fichero "Coder.cs", que será la ventana de acceso a todo el código de la aplicación.

En ella se pueden ver las variables a las que tenemos acceso que principalmente permiten:
1. Acceder a todos los controles de todos los formularios (activos).
2. Acceder a las variables del programa, del proceso y de los formularios.
3. Acceder a los argumentos del evento que ha lanzado el programa.

## Modificar código Puntos de ruptura

**El punto de ruptura del fichero "Coder.cs" no se debe eliminar**. Se activa en estos casos:
1. La primera vez que se crea un nuevo proceso. 
2. Cuando la ejecución del programa pasa por un proceso cuyo check "Editor" (de la lista de procesos del programa) está marcado.
3. Cuando se pulsa sobre el menú contextual "Editar código" en la lista de procesos del programa.
4. Si hay un error en el código, el proceso afectado se carga automáticamente en el fichero "Coder.cs"

Nota: Si no estás familiarizado con la opción "Edit and continue" de Visual Studio, te recomendamos primero leer sobre ella [aquí](https://msdn.microsoft.com/en-us/library/x17d7wxw.aspx).
También es imprescindible saber usar los [puntos de ruptura] (https://channel9.msdn.com/Blogs/Visual-Studio-Shorts/Using-Breakpoints-for-Debugging-in-Visual-Studio-2015).

# Otras funcionalidades

Hay mucha funcionalidad oculta bajo menús contextuales que es recomendable explorar pues ayudan a:
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
