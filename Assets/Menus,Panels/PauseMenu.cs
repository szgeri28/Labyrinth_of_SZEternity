using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //J�t�k meg�ll�t�shoz �s refer�l�sok
    public static bool GameIsPaused = false;
    public Text puskaText;
    public GameObject pauseMenu;
    public GameObject youSureExitPanel;

    void Pause()
    {
        //J�t�k �s id� meg�ll�t�sa, men� behoz�sa
        pauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }


    public void Resume()
    {
        //J�t�k �s id�elind�t�s, men� elt�ntet�se
        pauseMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }


    void Update()
    {
        //Ha lenyomjuk a Escape gombot
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //�s a j�t�k �ppen megy
            if(GameIsPaused == false)
            {
                //A j�t�k �lljon meg
                Pause();
            }
            //Ellenkez� esetben menjen tov�bb
            else
            {
                Resume();
            }
        }
        //Folyamatosan friss�ti a felvett pusk�k sz�m�t a HUD-ban
        if (GameManager.Instance.puska > 0)
        {
            puskaText.text = GameManager.Instance.puska + "";
        }
    }

    //GameOver eset�n Main menu-be visszal�p�s
    public void ExitToMainAfterFail()
    {
        SceneManager.LoadScene("Menu");

        //A felvett krediteket null�zzuk fail eset�n
        ItemPickup.kredit = 0;
    }

    //Kil�p�s a f�men�be
    public void ExitToMain()
    {
        youSureExitPanel.SetActive(true);
    }

    //ExitToMain ut�n ha biztos ki akar l�pni, kil�p a men�be
    public void YesButton()
    {
        SceneManager.LoadScene("Menu");
        ItemPickup.kredit = 0;
    }

    //ExitToMain ut�n ha m�gsem akar kil�pni, folytatja a j�t�kot
    public void NoButton()
    {
        youSureExitPanel.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

}
