En esta práctica he desarrollado una escena tipo first person shooter (FPS) en Unity, partiendo de un proyecto básico y añadiendo control del jugador, disparo, enemigos con distintos comportamientos, sistema de vida, interfaz y condición de victoria.

Control del jugador

El jugador se controla en primera persona. El movimiento se hace con WASD y la cámara se controla con el ratón. El giro horizontal se aplica al propio jugador, mientras que el giro vertical se aplica a la cámara, limitándolo con un Clamp para que no pueda girar de forma irreal. Además, el jugador puede saltar con la tecla Espacio, usando un Rigidbody con gravedad y una comprobación sencilla para saber si está tocando el suelo.

Sistema de disparo

El disparo se realiza con un sistema de raycast, que es lo que se pedía en la práctica. Cuando se hace clic izquierdo, se lanza un rayo desde el punto de disparo del arma (BulletSpawn) hacia delante. Si el rayo impacta contra un enemigo, se busca su script de vida (HealthClase) y se le aplica daño con TakeDamage(). También se controla la cadencia de disparo con un fireRate, para que no pueda disparar infinitamente en un solo frame.

Enemigos

Se han creado tres tipos de enemigos usando objetos 3D simples:

Enemy → una Sphere, que persigue siempre al jugador.
EnemyFast → un Cube, que hace lo mismo pero con más velocidad.
EnemyPatrol → un Cylinder, que patrulla entre varios puntos del mapa y solo persigue al jugador cuando entra dentro de un rango de detección.

Para moverlos se usa NavMeshAgent, así que el suelo está preparado con NavMesh para que los enemigos puedan navegar correctamente. La idea importante aquí es que EnemyFastClase y EnemyPatrolClase heredan de EnemyClase, reutilizando la lógica común y modificando solo el comportamiento que cambia en cada caso.

Vida del jugador y de los enemigos

Se ha implementado un script reutilizable llamado HealthClase, que sirve tanto para el jugador como para los enemigos. Este script guarda la vida actual y tiene un método TakeDamage(int cantidad) que reduce la vida cuando recibe daño.

Si el objeto es un enemigo y su vida llega a 0, se destruye.
Si el objeto es el jugador, al quedarse sin vida se reinicia la escena.

De esta forma, el sistema de daño queda centralizado y no hay que duplicar lógica entre distintos scripts.

Interfaz

También se ha añadido una interfaz básica en pantalla usando Canvas + TextMeshPro. En ella se muestra:

La vida actual del jugador
El número de enemigos restantes

Esto se actualiza en tiempo real con un script de HUD que consulta tanto la vida del jugador como los enemigos que quedan en la escena con el tag Enemy.

Condición de victoria

Por último, se ha añadido un GameManager que comprueba constantemente si quedan enemigos con tag Enemy. Cuando el número de enemigos llega a 0, se carga la escena de victoria. Con esto se cierra el bucle básico de gameplay: el jugador entra en la escena, dispara, elimina a todos los enemigos y gana la partida.

Estructura general del proyecto

Los scripts principales utilizados en esta práctica son:

PlayerControlerClase → movimiento, cámara y salto del jugador
ShootRaycastClase → disparo con raycast
HealthClase → sistema de vida y daño
EnemyClase → enemigo base que persigue
EnemyFastClase → enemigo rápido
EnemyPatrolClase → enemigo que patrulla y persigue si detecta al jugador
HUDUpdaterClase → actualización de la interfaz
GameManager → control de la victoria
