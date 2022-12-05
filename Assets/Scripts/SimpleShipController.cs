using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShipController : MonoBehaviour
{
    //Guardar los inputs en X e Y
    private Vector2 _delta = Vector2.zero;
    //Referencia al Rigidbody de la nave
    private Rigidbody2D _rigidbody2D;
    //Inicializamos el vector de fuerza
    private Vector2 _force = Vector2.zero;
    private float _torque;
    //Multiplicadores
    public float thrustMultiplier = 1;
    public float steerMultiplier = 1;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
#if (UNITY_IOS || UNITY_ANDROID && !UNITY_EDITOR || REMOTE)
        if (Input.touchCount > 0)
        {
            Touch t = Input.touches[0];
            if(t.phase == TouchPhase.Moved)
            {
                _delta.x = t.deltaPosition.x;
                _delta.y = t.deltaPosition.y;
            }
        }
#else
        
        _delta.x = Input.GetAxis("Horizontal");
        _delta.y = Input.GetAxis("Vertical");
#endif

        _force.y = _delta.y * thrustMultiplier;
        _torque = -_delta.x * steerMultiplier;

        _rigidbody2D.AddRelativeForce(_force);
        _rigidbody2D.AddTorque(_torque);

        //transform.Translate(0, _delta.y, 0);
        //transform.Rotate(0, 0, -_delta.x);
    }
}
