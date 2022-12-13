using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage game states
/// </summary>
[AddComponentMenu("ESI/Game Manager")]
public class GameManager : MonoBehaviour
{
    //Su valor nunca puede cambiar
    public const float maxDamage = 100;
    static private float _damage;
    static public float Damage
    {
        get { return _damage; }
        set
        {
            if (value != _damage)
            {
                _damage = value;
                Debug.Log(value);

                if (_damage >= maxDamage)
                    //TODO: lives--;
                    _damage = 0;
            }
        }
    }

}
