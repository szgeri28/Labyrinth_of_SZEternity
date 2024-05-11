using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemPickup: MonoBehaviour
{
    //kezdeti összegyûjtött kredit
    public static int kredit = 0;

    //összegyûjtött puska
    public static int puska;

    //UI textekre való hivatkozás
    public Text kreditText;
    public Text puskaText;

    public void Update()
    {
        //Fail esetén a kreditek nullázása
        if(PlayerTakeDamage.currentHealth <= 0)
        {
            kredit = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Ha érintkezik egy Kredit tegû gameObjecttel
        if (collision.gameObject.CompareTag("Kredit"))
        {
            //Adjon a kredit változóhoz egyet, és ezt adja hozzá a HUDban elhelyezkedõ counterhez is
            kredit++;
            kreditText.text = kredit + "/12";
        }
        //Ha érintkezik egy Puska tegû gameObjecttel
        if (collision.gameObject.CompareTag("Puska"))
        {
            //Adjon a puska változóhoz egyet, és ezt adja hozzá a HUDban elhelyezkedõ counterhez is
            GameManager.Instance.puska++;
            puskaText.text = GameManager.Instance.puska + "";
        }
    }
}