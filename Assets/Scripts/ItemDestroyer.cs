using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer: MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Ha a kredit a Player teg� gameobjecthez �r, akkor elt�nik
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Helper"))
        {
            Destroy(gameObject);
        }
    }
}