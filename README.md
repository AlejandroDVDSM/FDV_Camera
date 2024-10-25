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
Por último, asignamos esos tres objetos a la lista de seguimiento del último componente mencionado.

![image](https://github.com/user-attachments/assets/1c2c5078-8cde-4433-bf33-1673d600aaec)

![3  Apartado a](https://github.com/user-attachments/assets/6c9f5c8c-c7fd-4e33-827b-7bdbc276903e)


### _b. Agrega 2 sprites adicionales en la escena que estén realizando un movimiento Genera una cámara adicional que le haga el seguimiento a dichos objetos, cada uno con un peso en la importancia del seguimiento diferente._

![image](https://github.com/user-attachments/assets/57dcaffa-82a9-49e7-bbc1-7fb6e87ee43f)

![3  Apartado b](https://github.com/user-attachments/assets/762fac88-5ccd-4f68-8db9-4a295e5d7c3d)

## 4. Impulso

### _a. Cinemachine Impulse Source: el impulso se genera en respuesta a un evento_

Añadimos el componente `CinemachineImpulseListener` en la cámara virtual y luego `CinemachineImpulseSource` en cualquier otro GameObject. El primer componente estará a la escucha de que se dispare un impulso desde `CinemachineImpulseSource`.

Finalmente, creamos un script que genere ese impulso cuando al transcurrir un segundo tras la ejecución del método `Start()`:

```cs
using Cinemachine;
using UnityEngine;

public class CinemachineCameraShaker : MonoBehaviour
{
    private CinemachineImpulseSource _impulseSource;

    private void Start()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        Invoke(nameof(ShakeCam), 1);
    }

    private void ShakeCam()
    {
        _impulseSource.GenerateImpulse();
    }
}
```

![4  Ejercicio 4a](https://github.com/user-attachments/assets/67bcfeeb-089c-439e-821d-aa0bf9cbe68b)


### _b. Cinemachine Collision Impulse Source: el impulso se genera por una colisión._

Añadimos el componente `CinemachineCollisionImpulseSource` a un objeto que tenga a su vez un componente de tipo `Collider2D`.

![image](https://github.com/user-attachments/assets/a6014b0a-dda3-4f76-8983-a03a65fda90e)

![4  Ejercicio 4b](https://github.com/user-attachments/assets/8b9dc82f-4766-4301-9f97-39adbff5fd20)


## 5. Implementar un zoom a la cámara del jugador que se controle con las teclas W y S.

Se añade el siguiente script:

```cs
using Cinemachine;
using UnityEngine;

public class CinemachineZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _vcam;
    [SerializeField] private float _zoom;

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
            _vcam.m_Lens.OrthographicSize += _zoom;
        else if (Input.GetKey(KeyCode.W))
        {
            if (_vcam.m_Lens.OrthographicSize - _zoom > 0.0)
                _vcam.m_Lens.OrthographicSize -= _zoom;
        }
    }
}
```

![5  Ejercicio 5](https://github.com/user-attachments/assets/ed48d1ba-6045-4202-9ef7-c6b2c21dcc15)

## 6. Seleccionar un conjunto de teclas que permitan hacer el cambio entre dos cámaras . (Habilitar/Deshabilitar el gameobject de la cámara virtual)

Las teclas empleadas para desactivar y activar las cámaras son: `1` y `2`. La tecla `1` activa la primera cámara virtual, mientras que la tecla `2` activa la segunda.

```cs
using Cinemachine;
using UnityEngine;

public class CinemachineSwitchVCams : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _cinemachineBrain;
    
    [SerializeField] private CinemachineVirtualCamera _vcam1;
    [SerializeField] private CinemachineVirtualCamera _vcam2;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !_vcam1.gameObject.activeSelf)
        {
            _cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
            _vcam1.gameObject.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.Alpha2) && !_vcam2.gameObject.activeSelf)
        {
            _cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
            _vcam2.gameObject.SetActive(true);            
        }
    }
}
```
![6  Ejercicio 6](https://github.com/user-attachments/assets/a4e8e593-2c6b-4110-b6a6-e7ba498bf166)

## 7. Cámara rápida y lenta

### _a. Crear un script para activar la cámara lenta cuando el personaje entre en colisión con un elemento de la escena que elijas para activar esta propiedad._
### _b. Crear un script para activar la cámara rápida cuando el personaje entre en colisión con un elemento de la escena que elijas para activar esta propiedad._

```cs
using UnityEngine;

public class CinemachineBulletTime : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private bool _bulletTime;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.Equals(_player)) 
            return;

        Time.timeScale = _bulletTime ? .5f : 2.0f;
    }
}
```

![7  Ejercicio 7](https://github.com/user-attachments/assets/3c75d004-01ab-4dca-84e2-3268d523b08e)

## 8. Crear un script para intercambiar la cámara activa, una estará confinada y la otra no, cuando el personaje entre en colisión con un elemento de la escena que elijas para activar esta propiedad.

```cs
using Cinemachine;
using UnityEngine;

public class CinemachineTransition : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _cinemachineBrain;
    [SerializeField] private CinemachineVirtualCamera _vcam;
    
    [SerializeField] private GameObject _player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.Equals(_player))
            return;

        _cinemachineBrain.ActiveVirtualCamera.Priority = 9;
        _vcam.Priority = 10;
    }
}
```

![8  Ejercicio 8](https://github.com/user-attachments/assets/0e6c86e3-2b03-41f8-8660-c43bec1151d4)


