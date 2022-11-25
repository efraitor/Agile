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
        ////Referenciamos la información del área
        //_area = GetComponent<GameArea>();
        //Inicializamos el área en base a la cámara
        FitToMainCamera();
    }

    //Referencia al GameArea a través de un accesor
    private GameArea Area
    {
        //Obtenemos la información del área
        get { return GetComponent<GameArea>(); }
    }

    private void FitToCamera(Camera cam)
    {
        //Para conocer el tamaño de lo que ve la cámara
        //cam.aspect
        //cam.ortographicSize

        ////Inicializar el área en la posición (0,0)
        //Area.SetArea(new Vector2(0, 0));

        //Con esto ajustamos la nueva área al ancho y alto de visión de la cámara para ese dispositivo concreto
        //Area.SetArea(new Vector2(cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2));
        Area.Size = new Vector2(cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2);
        //Movemos ese área con respecto a la posición y rotación de la cámara
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 0);
        transform.rotation = cam.transform.rotation;
    }

    private void FitToMainCamera()
    {
        //Creamos el área en base a la cámara principal de la escena
        FitToCamera(Camera.main);
    }

    //Es un método que solo se llama para el editor, o cuando hay cambios en el editor en una variable
    private void OnValidate()
    {
        FitToMainCamera();
    }

    //Cuando pulsemos en el botón de Reset en el editor de Unity en este componente se reiniciará el área
    private void Reset()
    {
        FitToMainCamera();
    }
}
