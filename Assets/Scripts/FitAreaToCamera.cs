using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Atributos, en este caso de la clase
[AddComponentMenu("ESI/Fit Area To Camera")]
//Significa que necesariamente la clase necesita un GameArea para poder funcionar
[RequireComponent (typeof (GameArea))]
public class FitAreaToCamera : MonoBehaviour
{
    ////Referencia al GameArea
    //private GameArea _area;

    //private void Awake()
    //{
    //    //Referenciamos la información del área
    //    _area = GetComponent<GameArea>();
    //}

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

        Area.SetArea(new Vector2(cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2));
        ////Movemos ese área con respecto a la posición y rotación de la cámara
        //transform.position = cam.transform.position;
        //transform.rotation = cam.transform.rotation;
    }
}
