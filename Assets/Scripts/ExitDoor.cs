using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ExitDoorCollision: MonoBehaviour
{
    //Refer�l�s
    public GameObject questionMenu;
    public static bool GameIsPaused = false;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Player tag� objekttel val� �tk�z�s ellen�rz�se
        if (collision.gameObject.CompareTag("ExitDoor"))
        {
            //K�rd�s panel megjelen�t�se
            questionMenu.SetActive(true);
            GameIsPaused = true;
            Time.timeScale = 0f;
        }
    }
}