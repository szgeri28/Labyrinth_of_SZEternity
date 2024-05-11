using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ExitDoorCollision: MonoBehaviour
{
    //Referálás
    public GameObject questionMenu;
    public static bool GameIsPaused = false;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Player tagû objekttel való ütközés ellenõrzése
        if (collision.gameObject.CompareTag("ExitDoor"))
        {
            //Kérdés panel megjelenítése
            questionMenu.SetActive(true);
            GameIsPaused = true;
            Time.timeScale = 0f;
        }
    }
}