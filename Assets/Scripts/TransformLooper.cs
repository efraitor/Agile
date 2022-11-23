using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Purpose :
 * Looping the object transform across a rectangle area
*/
//Me agrega en el men� de componentes, un submen� esp�cifico
[AddComponentMenu ("ESI/Transform Looper")]
public class TransformLooper : MonoBehaviour
{
    //Declaramos una nueva �rea
    //public Rect area;
    //Referencia a la clase GameArea
    public GameArea gameArea;

    //Referencia para guardar la posici�n de la nave
    public Vector2 areaSpacePosition;

    // Update is called once per frame
    void Update()
    {
        //Donde se encuentra el objeto en ese momento preciso
        //position = transform.position;
        //InverseTransformPoint, coge una posici�n y la pasa de coordenadas globales a coordenadas locales
        //Realmente lo que hacemos es referenciar o adjuntar en este caso al objeto al �rea
        areaSpacePosition = gameArea.transform.InverseTransformPoint(transform.position);

        //Solo el objeto se encuentra dentro del �rea se ejecuta este return
        if (gameArea.Area.Contains(areaSpacePosition))
        {
            //Salir del bucle Update
            return;
        }
        
        //Alteramos la posici�n del objeto al llegar a los l�mites, para que vaya al lado contrario
        if (areaSpacePosition.x < gameArea.Area.xMin)
            areaSpacePosition.x = gameArea.Area.xMax;
        else if (areaSpacePosition.x > gameArea.Area.xMax)
            areaSpacePosition.x = gameArea.Area.xMin;

        if (areaSpacePosition.y < gameArea.Area.yMin)
            areaSpacePosition.y = gameArea.Area.yMax;
        else if (areaSpacePosition.y > gameArea.Area.yMax)
            areaSpacePosition.y = gameArea.Area.yMin;

        //Movemos al objeto a esa posici�n
        //transform.position = position;
        //TransformPoint, convierte una posici�n local en una posici�n global
        //Con el fin de colocar en una posici�n del mundo al objeto
        transform.position = gameArea.transform.TransformPoint(areaSpacePosition);
    }
}
