# FDV_Camera

## 1. Instalar el paquete CineMachine y configurar 2 cámaras virtuales con diferentes zonas de seguimiento al jugador. Mostar el efecto mediante un gif animado.

Primero creamos un proyecto con la plantilla `2D (Built-In Render Pipeline)`.

![1  Creación del proyecto](https://github.com/user-attachments/assets/c9e7429d-2383-466a-9da0-3426bdb592e4)

A continuación, abrimos el _package manager_ e instalamos el paquete _Cinemachine_.

![2  Cinemachine PackageManager](https://github.com/user-attachments/assets/2b153cce-ef24-4573-b94b-e5a54603bf39)

Ahora que tenemos el paquete necesario para la práctica, pulsamos el click derecho en la ventana _Hierarchy_ y pulsamos la opción `Cinemachine > 2D Camera`. Esto añadirá de forma automática el componente `CinemachineBrain` a la cámara de la escena, además de crear un GameObject de tipo `CinemachineVirtualCamera`.

![image](https://github.com/user-attachments/assets/9a694b58-58ca-4a8e-8de1-5da25c9601a7)

Los cambios que realizaremos a nuestra primera cámara virtual serán:
* Le asignamos el objetivo que deberá seguir en la propiedad `Follow`
* Modificamos la propiedad `Tracked Object Offset` para que el objeto a seguir esté siempre situado en el cuadrante inferior izquierdo de la cámara.
* Reducimos la propiedad `Lens Ortho Size` para cambiar el tamaño de la lente.

![image](https://github.com/user-attachments/assets/f9f4f26c-150e-495a-b51a-9a69e7629e67)

A continuación, creamos la segunda cámara virtual con los valores por defecto, por lo que estará centrada respecto al personaje.

**CÁMARA VIRTUAL 1**

![1  Cámara A](https://github.com/user-attachments/assets/17d537fc-2c88-4747-8f9e-638212884c65)

**CÁMARA VIRTUAL 2**

![1  Cámara B](https://github.com/user-attachments/assets/944a6241-eb00-42a5-9519-89570b3e4a94)

## 2. Define un área de confinamiento diferente para cada una de las dos cámaras de la tarea anterior. Realiza una prueba de ejecución con el correspondiente gif animado que permita ver las diferencias.

Creamos un objeto vacío en la escena y le añadimos el componente `PollygonCollider2D` para que actúe como área de confinamiento. Luego, le añadimos a la cámara virtual 1 la extensión `CinemachineConfiner2D` y inicializamos la propiedad `BoundingShape2D` al área de confinamiento recién creada.

![image](https://github.com/user-attachments/assets/3a140840-4ce9-4d42-a6b2-706759138a48)

![image](https://github.com/user-attachments/assets/06de803e-5ed4-4301-aa50-9737c3afe540)

![2  Cámara A](https://github.com/user-attachments/assets/7791973d-1259-42e7-b059-d951c98e6f2f)



