using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FitAraToCamera
/// Needs a GameArea. Return the size of the game area based on camera view
/// </summary>

//Atributos, en este caso de la clase
[AddComponentMenu("ESI/Fit Area To Camera")]
//Significa que necesariamente la clase necesita un GameArea para poder funcionar
[RequireComponent (typeof (GameArea))]
public class FitAreaToCamera : MonoBehaviour
{
    ////Referencia al GameArea
    //private GameArea _area;

    private void Awake()
    {
        ////Referenciamos la informaci�n del �rea
        //_area = GetComponent<GameArea>();
        //Inicializamos el �rea en base a la c�mara
        FitToMainCamera();
    }

    //Referencia al GameArea a trav�s de un accesor
    private GameArea Area
    {
        //Obtenemos la informaci�n del �rea
        get { return GetComponent<GameArea>(); }
    }

    private void FitToCamera(Camera cam)
    {
        //Para conocer el tama�o de lo que ve la c�mara
        //cam.aspect
        //cam.ortographicSize

        ////Inicializar el �rea en la posici�n (0,0)
        //Area.SetArea(new Vector2(0, 0));

        //Con esto ajustamos la nueva �rea al ancho y alto de visi�n de la c�mara para ese dispositivo concreto
        //Area.SetArea(new Vector2(cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2));
        Area.Size = new Vector2(cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2);
        //Movemos ese �rea con respecto a la posici�n y rotaci�n de la c�mara
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 0);
        transform.rotation = cam.transform.rotation;
    }

    private void FitToMainCamera()
    {
        //Creamos el �rea en base a la c�mara principal de la escena
        FitToCamera(Camera.main);
    }

    //Es un m�todo que solo se llama para el editor, o cuando hay cambios en el editor en una variable
    private void OnValidate()
    {
        FitToMainCamera();
    }

    //Cuando pulsemos en el bot�n de Reset en el editor de Unity en este componente se reiniciar� el �rea
    private void Reset()
    {
        FitToMainCamera();
    }
}
