using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esto nos sirve para que al llamar a esta clase desde otra, nos dé esta información
/// <summary>
/// Game area.
/// Defines a Rectangular Area
/// </summary>

[AddComponentMenu ("ESI/Game Area")]
public class GameArea : MonoBehaviour
{
    //Hacemos esa referencia privada
    private Rect _area;
    //Para poder acceder a la referencia desde otro script usamos un accesor
    public Rect Area
    {
        //Obtenemos la variable o referencia a la que queremos acceder
        get { return _area; }
        //Ponemos el valor de esa variable o referencia al usar el accesor
        set { _area = value; }
    }

    //Tamaño del área
    public Vector2 size;

    //Creamos un color para los Gizmos
    public Color gizmoColor = new Color(0, 0, 1, 0.2f);
    private Color gizmoWireColor;

    private void Awake()
    {
        //Creo el área
        SetArea(size);
    }

    //Método para generar el área
    public void SetArea(Vector2 size)
    {
        //Area = new Rect (0, 0,, size.x, size.y);
        //Como lo de arriba
        //Area = new Rect (Vector2.zero, size);
        //Posición inicial en X e Y, ancho y alto
        Area = new Rect(size.x * -0.5f, size.y * -0.5f, size.x, size.y);
    }

    //Método que nos permite dibujar Gizmos en la ventana de Escena
    void OnDrawGizmos()
    {
        //Con esto asignamos el gizmo al objeto
        Gizmos.matrix = transform.localToWorldMatrix;
        // Aplicamos el color creado al gizmo
        Gizmos.color = gizmoColor;
        //Dibujamos el área
        Gizmos.DrawCube(Vector3.zero, new Vector3(Area.width, Area.height, 0));
        //Pintamos las aristas del área
        Gizmos.color = gizmoWireColor;
        //Dibujamos las aristas del área
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(Area.width, Area.height, 0));
    }

    //Es un método que solo se llama para el editor, o cuando hay cambios en el editor en una variable
    private void OnValidate()
    {
        //Creo el área pero solo con el propósito de los Gizmos
        SetArea(size);
        //Inicializamos el color de las aristas del gizmo
        gizmoWireColor = new Color(gizmoColor.r, gizmoColor.g, gizmoColor.b, 1);
    }
}
