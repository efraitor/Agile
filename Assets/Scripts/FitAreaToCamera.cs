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
    //    //Referenciamos la informaci�n del �rea
    //    _area = GetComponent<GameArea>();
    //}

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

        Area.SetArea(new Vector2(cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2));
        ////Movemos ese �rea con respecto a la posici�n y rotaci�n de la c�mara
        //transform.position = cam.transform.position;
        //transform.rotation = cam.transform.rotation;
    }
}
