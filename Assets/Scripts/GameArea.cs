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
    //Atributos de las variables
    //Sigue siendo privada el área pero accesible desde editor
    [SerializeField]
    //No permite que sea accesible desde el editor
    [HideInInspector]
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

    //Creamos una referencia con su accesor para el GameArea principal
    private static GameArea _main;
    public static GameArea Main
    {
        get
        {
            //Si esa referencia está vacía
            if (_main == null)
            {
                //La busco en la escena y la relleno
                _main = FindObjectOfType<GameArea>();
                //Pero si no hay una que recoger de la escena
                if (_main == null)
                {
                    //Creo un objeto vacío con los componentes necesarios que me permita rellenarla
                    GameObject go = new GameObject("Game Area: Main");
                    _main = go.AddComponent<GameArea>();
                    go.AddComponent<FitAreaToCamera>();
                }
            }
                
            return _main;
        }
        set
        {
            _main = value;
        }
    }

    //Tamaño del área
    private Vector2 _size;

    //Creamos un color para los Gizmos
    public Color gizmoColor = new Color(0, 0, 1, 0.2f);
    private Color gizmoWireColor;

    //private void Awake()
    //{
    //    //Creo el área
    //    SetArea(size);
    //    Size = _size;
    //}

    //Accesor a el tamaño y posición del área
    public Vector2 Size
    {
        //Obtenemos la referencia de tamaño del área
        get { return Area.size; }
        //Ponemos el tamaño del área
        set
        {
            _size = value;
            //Posición inicial en X e Y, ancho y alto
            Area = new Rect(value.x * -0.5f, value.y * -0.5f, value.x, value.y);
        }
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
        ////Creo el área pero solo con el propósito de los Gizmos
        //SetArea(size);
        Size = _size;
        //Inicializamos el color de las aristas del gizmo
        gizmoWireColor = new Color(gizmoColor.r, gizmoColor.g, gizmoColor.b, 1);
    }

    //Es un método que nos devuelve una posición aleatoria dentro del área de juego
    public Vector3 GetRandomPosition()
    {
        Vector3 randomPos = Vector3.zero;
        randomPos.x = Random.Range(Area.xMin, Area.xMax);
        randomPos.y = Random.Range(Area.yMin, Area.yMax);
        //Convertimos esas coordenadas locales obtenidas de dentro del área establecida, en globales respecto a Unity
        randomPos = transform.TransformPoint(randomPos);
        return randomPos;
    }
}
