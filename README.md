# ¿Qué es ARQODE?
ARQODE es una solución de **código abierto** complementaria a Visual Studio para **escribir aplicaciones** en tiempo real o **en tiempo de ejecución**. 

ARQODE "amplia" la funcionalidad de Visual Studio "Edit and Continue" permitiendo salvar dos grandes limitaciones:
1. Añádir, modificar y eliminar funciones.
2. Añadir y eliminar eventos.

ARQODE consta de dos herramientas:
1. Un gestor de aplicaciones: **ARQODE APP Manager**
2. Un editor de programas: **ARQODE Program editor**.

# ¿Por qué programar con ARQODE?
AROQDE permite programar sin tanta necesidad de abstracción, pues cuando se programa en tiempo de ejecución se tiene acceso a los objetos
reales y a sus variables, además Visual Studio aporta:
- revisión de errores sintácticos en tiempo real
- posibiildad de volver atras la línea de ejecución activa (muy util después de saltar un try ... catch)

# ¿Cómo programar con ARQODE?
Una vez creada una aplicación en ARQODE APP Manager, esta se carga directamente en el proyecto ARQODE y se ejecuta Visual Studio con el
programa recién creado listo para empezar a programar.

La aplicación básica consta de un formulario vacío, que se recomienda editar previamente  en Visual Studio para añadir todos los 
controles gráficos requeridos.

## Crear la estructura de la aplicación a alto nivel:

1. Crear la funcionalidad a alto nivel en el árbol de Programas
  * Cada programa contiene procesos o llamadas a otros programas.
2. Crear los procesos, para ello hay un árbol de contenedores de procesos y por cada nodo una lista de procesos asociados.
3. Asignar un programa a un evento de un control.
  * El primer programa debe asignarse al evento Load del formulario principal.

## El proceso en ARQODE

Es la unidad mínima de programación, se trata literalmente de un trozo de código que se ejecuta dentro de un contexto y que permite
definir entradas y salidas, así como tener una configuración propia. 

## El programa en ARQODE

Se trata de un contenedor de procesos o llamadas a otros programas que se ejecuta a través de un evento. Con el objetivo de una mejor
reutilización del código, es recomendable hacer pequeños programas, pero que a su vez resuelvan completamente una funcionalidad. 

Las llamadas recursivas a programas son un pilar de este modelo de programación y para hacer un mejor seguimiento en la consola de salida
de Visual Studio se podrá ver la traza de procesos / programas ejecutados en todo momento.

Para controlar el flujo del programa hay dos grandes recursos:
1. Poder detener la ejecución del programa dentro de cualquier proceso.
2. Poder encolar la llamada a un programa, para que se ejecute siempre al final.
Además el paso de variables del programa activo al programa llamado se hace automáticamente.

## Formularios o Vistas en ARQODE

Cada formulario o vista en ARQODE puede contener variables que estarán activas mientras el formulario lo esté. Por lo que es recomendable
introducir en el formulario principal todas las variables globales en tiempo de ejecución del programa.

Cada formulario genera un fichero mapeado dentro de la carpeta UI de ARQODE que facilita el acceso a los controles por nombre, a demás de 
a sus variables de vista.

## Escribir el código:

Para lanzar la nueva aplicación y empezar a escribir código pulsar en "Run app" en el ARQODE Program editor. Esto hará saltar un punto 
de ruptura en el fichero "Coder.cs", que será la ventana de acceso a todo el código de la aplicación.

En ella se pueden ver las variables a las que tenemos acceso que principalmente permiten:
1. Acceder a todos los controles de todos los formularios (activos).
2. Acceder a las variables del programa, del proceso y de los formularios.
3. Acceder a los argumentos del evento que ha lanzado el programa.
