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
    public GameObject reference;

    private float rate = 1.0f;
    public bool infinite;

    public int number = 5;

    //Contador
    private float _timeStamp;
    //Conteo de objetos que quedan por instanciarse
    private int _remaining;

    private void Start()
    {
        //El contador sería el tiempo desde que empezó el juego (osea 0)
        _timeStamp = Time.time;
        //Inicializo con el número público de arriba
        _remaining = number;
    }

    private void Update()
    {
        //Desde que empieza el juego hasta el tiempo del contador
        if (Time.time <= _timeStamp)
            //Al llegar al tiempo del contador el programa sale del Update
            return;

        if(_remaining > 0)
        {
            //Instanciamos asteroides
            Instantiate(reference, transform.position, transform.rotation);
            //Restamos uno menos a los que quedan
            _remaining--;
            //Si ya no quedan objetos por instanciarse
            if (_remaining <= 0)
                //Desactivamos este componente, el Script, con lo que no gastamos más recursos
                enabled = false;
        }
                

        //El contador es el tiempo que ha pasado desde que se inició el juego
        _timeStamp = Time.time;
    }
}
