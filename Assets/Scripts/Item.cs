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

    private AudioSource _audioSrc;
    private Renderer _renderer;
    private Collider2D _collider2D;

    private void Awake()
    {
        _audioSrc = GetComponent<AudioSource>();
        _renderer = GetComponent<Renderer>();
        _collider2D = GetComponent<Collider2D>();
    }

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
                GameManager.Lives++;
                Debug.Log(GameManager.Lives);
                break;
            default:
                break;
        }
        StartCoroutine(PlaySoundAndRelease());
    }

    private IEnumerator PlaySoundAndRelease()
    {
        _renderer.enabled = _collider2D.enabled = false;
        _audioSrc.Play();

        yield return new WaitForSeconds(_audioSrc.clip.length);
        //TODO: Use Object Pooling!
        Destroy(gameObject);
    }
}
