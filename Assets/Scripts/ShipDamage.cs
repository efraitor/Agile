using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deal player damage.
/// </summary>
//Me agrega en el men� de componentes, un submen� esp�cifico
[AddComponentMenu("ESI/Ship Damage")]
public class ShipDamage : MonoBehaviour
{
    //Variable para la vulnerabilidad
    public float vulnerability = 1f;

    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    //Variable y su accesor
    //private float _damage;
    public float Damage
    {
        get { return GameManager.Damage; }
        set { GameManager.Damage = value; }
    }

    ////M�todo que aplica el da�o a la nave
    //private void ApplyDamage (float damage)
    //{
    //    Damage += damage;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Dependiendo de la velocidad del asteroide concreto se aplica m�s o menos da�o
        float damage = collision.relativeVelocity.magnitude;

        //if (collision.gameObject.tag == "Asteroid")
        //if(collision.collider.sharedMaterial.name == "Asteroid")
        if (collision.collider.sharedMaterial)
        {
            //Me har� m�s o menos da�o el asteroide dependiendo de la fricci�n y de la capacidad el�stica de ambos cuerpos
            damage *= _collider2D.sharedMaterial.friction *
                collision.collider.sharedMaterial.friction *
                (1 / collision.collider.sharedMaterial.bounciness) *
                (1 / _collider2D.sharedMaterial.bounciness);
        }
        //Si el objeto contra el que colisionamos tiene un Rigidbody
        if (collision.rigidbody)
        {
            //El da�o ser� exponencial dependiendo de las masas de ambos cuerpos
            damage *= (collision.rigidbody.mass / _rigidbody2D.mass);
        }
        Damage += damage; 
    }
}
