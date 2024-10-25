# FDV_Camera

## 1. Instalar el paquete CineMachine y configurar 2 cámaras virtuales con diferentes zonas de seguimiento al jugador. Mostar el efecto mediante un gif animado.

Primero creamos un proyecto con la plantilla `2D (Built-In Render Pipeline)`.

![1  Creación del proyecto](https://github.com/user-attachments/assets/c9e7429d-2383-466a-9da0-3426bdb592e4)

A continuación, abrimos el _package manager_ e instalamos el paquete _Cinemachine_.

![2  Cinemachine PackageManager](https://github.com/user-attachments/assets/2b153cce-ef24-4573-b94b-e5a54603bf39)

Ahora que tenemos el paquete necesario para la práctica, pulsamos el click derecho en la ventana _Hierarchy_ y pulsamos la opción `Cinemachine > 2D Camera`. Esto añadirá de forma automática el componente `CinemachineBrain` a la cámara de la escena, además de crear un GameObject de tipo `CinemachineVirtualCamera`.

![image](https://github.com/user-attachments/assets/9a694b58-58ca-4a8e-8de1-5da25c9601a7)


Los cambios que realizaremos a nuestra primera cámara virtual serán:
* Le asignamos el objetivo que deberá seguir en la propiedad `Follow`.
* Reducimos la propiedad `Lens Ortho Size` para cambiar el tamaño de la lente.
* Modificamos la propiedad `Tracked Object Offset` para que el objeto a seguir esté siempre situado en el cuadrante inferior izquierdo de la cámara.

Los realizados a la segunda cámara virtual son:
* Le asignamos el objetivo que deberá seguir en la propiedad `Follow`.
* Reducimos la propiedad `Lens Ortho Size` para cambiar el tamaño de la lente, aunque no tanto como la primera cámara virtual.
* Aumentamos las propiedades `LookaheadTime` y `LookaheadSmoothing` para que la cámara se adelanta al movimiento del personaje.

![image](https://github.com/user-attachments/assets/316425f4-c2d1-4305-9abe-b12549b77690)

**CÁMARA VIRTUAL 1**

![1  Cámara A](https://github.com/user-attachments/assets/71745de7-38e2-4772-896d-fa9983fadf8a)

**CÁMARA VIRTUAL 2**

![1  Cámara B](https://github.com/user-attachments/assets/08086cf4-492b-4e89-b0cf-286d0fa2bb9b)

## 2. Define un área de confinamiento diferente para cada una de las dos cámaras de la tarea anterior. Realiza una prueba de ejecución con el correspondiente gif animado que permita ver las diferencias.

Añadimos a ambas cámaras virtuales la extensión `CinemachineConfiner2D`.

![image](https://github.com/user-attachments/assets/06de803e-5ed4-4301-aa50-9737c3afe540)

Creamos dos objeto vacíos en la escena y les añadimos el componente `PollygonCollider2D` para que actúe como área de confinamiento. Luego, inicializamos el valor `CinemachineConfiner2D.BoundingShape2D` con el área de confinamiento que deseemos usar para la cámara.

**CÁMARA VIRTUAL 1**

![image](https://github.com/user-attachments/assets/b76302a9-1de8-4103-ba1c-56aaada735a3)


![2  Cámara 1](https://github.com/user-attachments/assets/0d466945-6044-4983-bcbb-099adebd8fa7)


**CÁMARA VIRTUAL 2**

![image](https://github.com/user-attachments/assets/1028a901-dfdc-4195-947d-b5fc83f8c4a5)

![2  Cámara 2](https://github.com/user-attachments/assets/5a3c9035-ce59-422a-91be-bdc9c269e4b5)

## 3. Seguimiento a un grupo de objetivos:

### _a. Agrega varios sprites en la escena que estén realizando un movimiento (mínimo 3). Genera una cámara adicional que le haga el seguimiento a dichos objetos._

Creamos los tres sprites y les asignamos un script de movimiento. En nuestro caso, el rectángulo rosa se moverá a la izquierda en diagonal, mientras que el naranja lo hará en diagonal a la derecha. El rectángulo rojo no se moverá.

![image](https://github.com/user-attachments/assets/35827728-ec16-44a9-8d09-c3da6d08b3a5)

Con los tres objetos que conformarán el grupo en la escena, hacemos click derecho en la pestaña _"Hierarchy"_ y seleccionamos la opción `Cinemachine > Target Group Camera`, que creará una nueva cámara virtual y un objeto de tipo `CinemachineTargetGroup`. 
Por último, 


