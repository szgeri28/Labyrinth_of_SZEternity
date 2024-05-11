using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossQuestion : MonoBehaviour
{
    // BossQuestionPanel referálása
    public GameObject bossQuestionPanel;

    // A játék állapotának nyilvántartása
    public static bool GameIsPaused = false;

    // A függvény, ami meghívódik, ha a Player-rel ütközik a "vizsga papír"
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Kérdés panel megjelenítése
            bossQuestionPanel.SetActive(true);
            // Játék szüneteltetése
            GameIsPaused = true;
            // Time Scale beállítása 0-ra a játék megállításához
            Time.timeScale = 0f;
        }
    }
}
