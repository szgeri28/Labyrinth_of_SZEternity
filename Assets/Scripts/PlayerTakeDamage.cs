using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTakeDamage : MonoBehaviour
{
    public static int currentHealth;
    public int damage;
    public Text health;

    //Megadjuk a kezdeti �let m�rt�k�t
    public void Start()
    {
        currentHealth = 100;
    }

    //Be�ll�tjuk a csapd�k �s ellenfelek sebz�s�t �s megjelen�tj�k a HUD texten is
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            damage = 10;
            currentHealth = currentHealth - damage;
            health.text = currentHealth + "";
            Debug.Log("Taking damage(10)...");
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damage = 20;
            currentHealth = currentHealth - damage;
            health.text = currentHealth + "";
            Debug.Log("Taking damage(20)...");
        }
    }
}