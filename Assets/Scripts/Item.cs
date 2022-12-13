using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deal with items behaviour
/// </summary>
[AddComponentMenu("ESI/Item")]
public class Item : MonoBehaviour
{
    //Enumeración de items
    public enum TYPE { RepairKit, ExtraLife};
    //Una referencia al item en concreto que es este objeto
    public TYPE type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
        switch (type)
        {
            case TYPE.RepairKit:
                GameManager.Damage = 0;
                break;
            case TYPE.ExtraLife:
                //TODO : lives++;
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }
}
