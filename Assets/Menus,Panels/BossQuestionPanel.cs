using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossQuestion : MonoBehaviour
{
    // BossQuestionPanel refer�l�sa
    public GameObject bossQuestionPanel;

    // A j�t�k �llapot�nak nyilv�ntart�sa
    public static bool GameIsPaused = false;

    // A f�ggv�ny, ami megh�v�dik, ha a Player-rel �tk�zik a "vizsga pap�r"
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // K�rd�s panel megjelen�t�se
            bossQuestionPanel.SetActive(true);
            // J�t�k sz�neteltet�se
            GameIsPaused = true;
            // Time Scale be�ll�t�sa 0-ra a j�t�k meg�ll�t�s�hoz
            Time.timeScale = 0f;
        }
    }
}
