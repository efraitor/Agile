using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Spawner class
 * Spawn asteroids in a position inside the game area
 */

//Atributos, en este caso de la clase
[AddComponentMenu("ESI/Spawner")]
//Significa que necesariamente la clase necesita un GameArea para poder funcionar
[RequireComponent(typeof(GameArea))]
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
    public Transform player;
    public float minDistanceFromPlayer;

    ////Contador
    //private float _timeStamp;
    //Conteo de objetos que quedan por instanciarse
    private int _remaining;

    private void Start()
    {
        //El contador sería el tiempo desde que empezó el juego (osea 0)
        //_timeStamp = Time.time;
        //Inicializo con el número público de arriba
        _remaining = number;

        //Llamamos a la corrutina que instancia los objetos
        StartCoroutine(Spawn());
    }

    //private void Update()
    //{
    //    //Desde que empieza el juego hasta el tiempo del contador
    //    if (Time.time <= _timeStamp)
    //        //Al llegar al tiempo del contador el programa sale del Update
    //        return;

    //    if(_remaining > 0)
    //    {
    //        //Instanciamos asteroides
    //        Instantiate(reference, transform.position, transform.rotation);
    //        //Restamos uno menos a los que quedan
    //        _remaining--;
    //        //Si ya no quedan objetos por instanciarse
    //        if (_remaining <= 0)
    //            //Desactivamos este componente, el Script, con lo que no gastamos más recursos
    //            enabled = false;
    //    }
                

    //    //El contador es el tiempo que ha pasado desde que se inició el juego
    //    _timeStamp = Time.time;
    //}

    private IEnumerator Spawn()
    {
        //Hasta el infinito o hasta que queden asteroides por salir
        while (infinite || _remaining > 0)
        {
            //Vector3 _position;
            ////Si hay un área
            //if (area)
            //    //Guardamos la posición devuelta por el método del GameArea que nos da una posición aleatoria
            //    _position = area.GetRandomPosition();
            ////Si no hay área
            //else
            //    //La posición será la misma que la del Spawner
            //    _position = transform.position;
            //Se puede sustituir lo de arriba por un operador ternario
            Vector3 _position = area ? area.GetRandomPosition() : transform.position;

            //Si existe un jugador y la distancia entre el meteorito que se va a instanciar y el jugador es menor que la distancia permitida 
            if(player && Vector3.Distance(_position, player.position) < minDistanceFromPlayer)
            {
                Debug.Log(_position);
                //Dibujamos un línea en el inspector de Unity, desde el spawner al meteorito
                Debug.DrawLine(player.position, _position);
            }

            //Instanciamos un objeto y restamos 1 de los que quedan
            Instantiate(reference, _position, transform.rotation);
            _remaining--;

            //Esperamos un tiempo
            yield return new WaitForSeconds(1 / Random.Range(_minRate, _maxRate));
        }
    }
}
