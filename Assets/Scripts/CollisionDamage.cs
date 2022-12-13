using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Deal with asteroid collisions
 */
//Me agrega en el menú de componentes, un submenú espécifico
[AddComponentMenu("ESI/Collision Damage")]
public class CollisionDamage : MonoBehaviour
{
    //Vida que restamos
    public float damageAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            //Salimos del método
            return;
        //La nave se manda un mensaje así misma
        collision.gameObject.SendMessage("ApplyDamage", damageAmount, SendMessageOptions.DontRequireReceiver);
    }
}
