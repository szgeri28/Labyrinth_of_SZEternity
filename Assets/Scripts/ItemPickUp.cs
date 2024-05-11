using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemPickup: MonoBehaviour
{
    //kezdeti �sszegy�jt�tt kredit
    public static int kredit = 0;

    //�sszegy�jt�tt puska
    public static int puska;

    //UI textekre val� hivatkoz�s
    public Text kreditText;
    public Text puskaText;

    public void Update()
    {
        //Fail eset�n a kreditek null�z�sa
        if(PlayerTakeDamage.currentHealth <= 0)
        {
            kredit = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Ha �rintkezik egy Kredit teg� gameObjecttel
        if (collision.gameObject.CompareTag("Kredit"))
        {
            //Adjon a kredit v�ltoz�hoz egyet, �s ezt adja hozz� a HUDban elhelyezked� counterhez is
            kredit++;
            kreditText.text = kredit + "/12";
        }
        //Ha �rintkezik egy Puska teg� gameObjecttel
        if (collision.gameObject.CompareTag("Puska"))
        {
            //Adjon a puska v�ltoz�hoz egyet, �s ezt adja hozz� a HUDban elhelyezked� counterhez is
            GameManager.Instance.puska++;
            puskaText.text = GameManager.Instance.puska + "";
        }
    }
}