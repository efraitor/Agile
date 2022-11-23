using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShipController : MonoBehaviour
{
    //private Transform _transformComponent;

    //Guardar los inputs en X e Y
    private Vector2 _delta = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        //_transformComponent = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
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

        transform.Translate(0, _delta.y, 0);
        transform.Rotate(0, 0, -_delta.x);
    }
}
