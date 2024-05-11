using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //Játék megállításhoz és referálások
    public static bool GameIsPaused = false;
    public Text puskaText;
    public GameObject pauseMenu;
    public GameObject youSureExitPanel;

    void Pause()
    {
        //Játék és idõ megállítása, menü behozása
        pauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }


    public void Resume()
    {
        //Játék és idõelindítás, menü eltüntetése
        pauseMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }


    void Update()
    {
        //Ha lenyomjuk a Escape gombot
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //És a játék éppen megy
            if(GameIsPaused == false)
            {
                //A játék álljon meg
                Pause();
            }
            //Ellenkezõ esetben menjen tovább
            else
            {
                Resume();
            }
        }
        //Folyamatosan frissíti a felvett puskák számát a HUD-ban
        if (GameManager.Instance.puska > 0)
        {
            puskaText.text = GameManager.Instance.puska + "";
        }
    }

    //GameOver esetén Main menu-be visszalépés
    public void ExitToMainAfterFail()
    {
        SceneManager.LoadScene("Menu");

        //A felvett krediteket nullázzuk fail esetén
        ItemPickup.kredit = 0;
    }

    //Kilépés a fõmenübe
    public void ExitToMain()
    {
        youSureExitPanel.SetActive(true);
    }

    //ExitToMain után ha biztos ki akar lépni, kilép a menübe
    public void YesButton()
    {
        SceneManager.LoadScene("Menu");
        ItemPickup.kredit = 0;
    }

    //ExitToMain után ha mégsem akar kilépni, folytatja a játékot
    public void NoButton()
    {
        youSureExitPanel.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

}
