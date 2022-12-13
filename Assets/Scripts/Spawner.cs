using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Spawner class
 * Spawn asteroids in a position inside the game area
 */

//Atributos, en este caso de la clase
[AddComponentMenu("ESI/Spawner")]
public class Spawner : MonoBehaviour
{
    //Atributo de la variable Encabezado
    [Header ("SPAWN")]
    public GameObject reference;

    [Header("SPAWNING")]
    //Atributo de la variable Rango
    [Range (0.001f, 100f)] [SerializeField] float _minRate = 1.0f;
    [Range(0.001f, 100f)] [SerializeField] float _maxRate = 1.0f;
    public bool infinite;
    public int number = 5;

    [Header("LOCATIONSS")]
    public GameArea area;
    //Obtenemos el jugador y una distancia hasta él para que los meteoritos aparezcan alejados
    private Transform _player;
    public float minDistanceFromPlayer;

    [Header("VELOCITY")]
    [Range (-180f, 180f)] public float angle;
    [Range(0f, 360f)]  public float spread = 30f;
    [Range(0f, 10f)] public float minStrength = 1f;
    [Range(0f, 10f)] public float maxStrength = 10f;

    [Header("ANIMATION")]
    public string animatorSpawningParameterName = "Spawning";
    public float animatorDelayIn = 1f;
    public float animatorDelayOut = 1f;
    private Animator _animator;
    //Referencia para el parámetro del Animator
    private int _spawningHashID;

    ////Contador
    //private float _timeStamp;
    //Conteo de objetos que quedan por instanciarse
    private int _remaining;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (_animator)
            _spawningHashID = Animator.StringToHash(animatorSpawningParameterName);
    }

    //Corrutina para que empiecen a salir los asteroides
    private IEnumerator Start()
    {
        //Recogemos un área si no la hubiera
        if (!area)
            area = GameArea.Main;

        //Inicializo con el número público de arriba
        _remaining = number;

        //Obligamos a que haya una mínima distancia de aparición del asteroide desde el jugador
        if(minDistanceFromPlayer > 0)
        {
            //Buscamos al jugador
            GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
            //Comprobamos si existe
            if (playerGO)
                _player = playerGO.transform;
            //Si no existe
            else
                Debug.LogWarning("No player found. Please assign Player tag to Player Object");
        }

        //Si existe un animator
        if (_animator)
        {
            //Hacemos visible el agujero de gusano
            _animator.SetBool(_spawningHashID, true);
            //Esperamos un tiempo
            yield return new WaitForSeconds(animatorDelayIn);
        }

        //Hasta el infinito o hasta que queden asteroides por salir
        while (infinite || _remaining > 0)
        {
            //Se puede sustituir lo de arriba por un operador ternario
            Vector3 _position = area ? area.GetRandomPosition() : transform.position;

            //Si existe un jugador y la distancia entre el meteorito que se va a instanciar y el jugador es menor que la distancia permitida 
            if(_player && Vector3.Distance(_position, _player.position) < minDistanceFromPlayer)
            {
                //Debug.Log(_position);
                //Referencia a un Vector2 que nos sirve para conocer donde a priori aparecería el meteorito
                Vector2 debugPos = _position;
                //Dibujamos un línea en el inspector de Unity, desde el spawner al meteorito
                Debug.DrawLine(_player.position, debugPos);
                //Creamos una posición nueva en la misma dirección, lo suficientemente separada del jugador
                _position = (_position - _player.position).normalized * minDistanceFromPlayer;
                //Dibujamos un línea en el inspector de Unity, desde el spawner al meteorito
                Debug.DrawLine(debugPos, _position);
                //Pausa el juego en el editor de Unit
                //Debug.Break();
            }

            // TODO: Use Object Pooling
            //Instanciamos un objeto y restamos 1 de los que quedan
            GameObject obj = Instantiate(reference, _position, transform.rotation);
            //Referenciamos el Rigidbody del asteroide concreto
            Rigidbody2D rb2D = obj.GetComponent<Rigidbody2D>();
            //Si existe el Rigidbody
            if (rb2D)
            {
                //Nos proporciona un ángulo aleatorio
                float angleDelta = Random.Range(-spread * 0.5f, spread * 0.5f);
                float angle_ = angle + angleDelta;

                //Convertimos los grados a radianes y aplicamos seno y coseno para sacar la dirección a través de la hipotenusa
                Vector2 direction = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle_), Mathf.Cos(Mathf.Deg2Rad * angle_));
                
                //Obtenemos dirección de disparo del asteroide
                direction *= Random.Range(minStrength, maxStrength);
                //Aplicamos la velocidad obtenia al asteroide
                rb2D.velocity = direction;
            }

            _remaining--;

            //Esperamos un tiempo
            yield return new WaitForSeconds(1 / Random.Range(_minRate, _maxRate));
        }

        //Hacemos desaparecer ahora el agujero de gusano
        if (_animator)
        {
            _animator.SetBool(_spawningHashID, false);
            //Esperamos un tiempo
            yield return new WaitForSeconds(animatorDelayOut);
        }

        //Desactivamos el agujero de gusano
        gameObject.SetActive(false);
    }
}
