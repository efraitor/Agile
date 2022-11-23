using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Purpose :
 * Looping the object transform across a rectangle area
*/
//Me agrega en el menú de componentes, un submenú espécifico
[AddComponentMenu ("ESI/Transform Looper")]
public class TransformLooper : MonoBehaviour
{
    //Declaramos una nueva área
    //public Rect area;
    //Referencia a la clase GameArea
    public GameArea gameArea;

    //Referencia para guardar la posición de la nave
    public Vector2 areaSpacePosition;

    // Update is called once per frame
    void Update()
    {
        //Donde se encuentra el objeto en ese momento preciso
        //position = transform.position;
        //InverseTransformPoint, coge una posición y la pasa de coordenadas globales a coordenadas locales
        //Realmente lo que hacemos es referenciar o adjuntar en este caso al objeto al área
        areaSpacePosition = gameArea.transform.InverseTransformPoint(transform.position);

        //Solo el objeto se encuentra dentro del área se ejecuta este return
        if (gameArea.Area.Contains(areaSpacePosition))
        {
            //Salir del bucle Update
            return;
        }
        
        //Alteramos la posición del objeto al llegar a los límites, para que vaya al lado contrario
        if (areaSpacePosition.x < gameArea.Area.xMin)
            areaSpacePosition.x = gameArea.Area.xMax;
        else if (areaSpacePosition.x > gameArea.Area.xMax)
            areaSpacePosition.x = gameArea.Area.xMin;

        if (areaSpacePosition.y < gameArea.Area.yMin)
            areaSpacePosition.y = gameArea.Area.yMax;
        else if (areaSpacePosition.y > gameArea.Area.yMax)
            areaSpacePosition.y = gameArea.Area.yMin;

        //Movemos al objeto a esa posición
        //transform.position = position;
        //TransformPoint, convierte una posición local en una posición global
        //Con el fin de colocar en una posición del mundo al objeto
        transform.position = gameArea.transform.TransformPoint(areaSpacePosition);
    }
}
