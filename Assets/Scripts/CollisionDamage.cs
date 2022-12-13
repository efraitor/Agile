using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Deal with asteroid collisions
 */
//Me agrega en el men� de componentes, un submen� esp�cifico
[AddComponentMenu("ESI/Collision Damage")]
public class CollisionDamage : MonoBehaviour
{
    //Vida que restamos
    public float damageAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            //Salimos del m�todo
            return;
        //La nave se manda un mensaje as� misma
        collision.gameObject.SendMessage("ApplyDamage", damageAmount, SendMessageOptions.DontRequireReceiver);
    }
}
