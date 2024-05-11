using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Xml;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public GameObject ContinueButton;
    private string campus = "Campus";

    //Játékindítás
    public void PlayGame ()
    {
        //Kitörli az elõzõ mentést és nullázza az elõrehaladás értékeit
        File.Delete(Application.dataPath + "/DataXml.text");
        GameManager.Instance.puska = 0;
        GameManager.Instance.stageCounter = 0;

        //Betölti a Campus scenet
        SceneManager.LoadScene(campus);

        //Ha esetleg a játékból kilépnénk a fõmenûbe és vissza az idõt újra el kell indítanunk
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
    }
    //Mentett állapot esetén folytatás lehetõsége
    public void ContinueGame()
    {
        QuestionMenu questionMenuInstance = new QuestionMenu();

        // Betölti a mentést
        questionMenuInstance.LoadByXml();

        Debug.Log("Continue...");
    }

    //Kilépés a játékból
    public void QuitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }

    // Ha van mentés, megjelenik a Continue gomb, lehetõséget adva a folytatásra
    void Update()
    {
        if (File.Exists(Application.dataPath + "/DataXml.text"))
        {
            ContinueButton.SetActive(true);
        }
    }
}
