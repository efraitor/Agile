using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShipController : MonoBehaviour
{
    //private Transform _transformComponent;

    // Start is called before the first frame update
    void Start()
    {
        //_transformComponent = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(0, y, 0);
        transform.Rotate(0, 0, -x);
    }
}
