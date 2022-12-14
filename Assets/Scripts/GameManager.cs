using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage game states
/// </summary>
[AddComponentMenu("ESI/Game Manager")]
public class GameManager : MonoBehaviour
{

    static private int _lives = 5;
    static public int Lives
    {
        get { return _lives; }
        set
        {
            if (value != _lives)
            {
                _lives = value;
                if(_lives <= 0)
                {
                    //TODO: Handle Game Over State
                }
            }
        }
    }


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
                    Lives--;
                Debug.Log(Lives);
                    _damage = 0;
            }
        }
    }

}
