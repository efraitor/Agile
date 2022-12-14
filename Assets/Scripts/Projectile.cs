using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deal with projectile shoot
/// </summary>
[AddComponentMenu("ESI/Projectile")]
public class Projectile : MonoBehaviour
{
    public float speed = 0.5f;

    private void FixedUpdate()
    {
        //Trasladamos al cohete a partir de su propia posición en ese momento
        transform.Translate(0, speed * Time.deltaTime, 0, Space.Self);
    }
}
