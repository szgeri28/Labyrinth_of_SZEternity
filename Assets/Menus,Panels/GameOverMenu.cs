using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    // Referálás a FailedPanelra
    public GameObject failedPanel;

    public void GameOver()
    {
        //Játék és idõ megállítása, menü megjelenítése
        failedPanel.SetActive(true);
        PauseMenu.GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void Update()
    {
        // Ha a játékos élete 0-ra vagy alá esne, meghívja a GameOver függvényt
        if (PlayerTakeDamage.currentHealth <= 0)
        {
            GameOver();
        }
    }
}
