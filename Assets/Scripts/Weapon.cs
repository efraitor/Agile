using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * To manage weapons of the player
 */
[AddComponentMenu("ESI/Weapon")]
public class Weapon : MonoBehaviour
{
    public GameObject projectile;

    private Collider2D _shipCollider2D;

    private void Awake()
    {
        _shipCollider2D = transform.parent.GetComponent<Collider2D>();
    }

    private void Start()
    {
        //Fire();
    }

    private void Fire()
    {
        GameObject projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
        //Ignoramos las colisiones entre los proyectiles y la nave
        Physics2D.IgnoreCollision(_shipCollider2D, projectileInstance.GetComponent<Collider2D>());
    }
}
