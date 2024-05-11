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

    //J�t�kind�t�s
    public void PlayGame ()
    {
        //Kit�rli az el�z� ment�st �s null�zza az el�rehalad�s �rt�keit
        File.Delete(Application.dataPath + "/DataXml.text");
        GameManager.Instance.puska = 0;
        GameManager.Instance.stageCounter = 0;

        //Bet�lti a Campus scenet
        SceneManager.LoadScene(campus);

        //Ha esetleg a j�t�kb�l kil�pn�nk a f�men�be �s vissza az id�t �jra el kell ind�tanunk
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
    }
    //Mentett �llapot eset�n folytat�s lehet�s�ge
    public void ContinueGame()
    {
        QuestionMenu questionMenuInstance = new QuestionMenu();

        // Bet�lti a ment�st
        questionMenuInstance.LoadByXml();

        Debug.Log("Continue...");
    }

    //Kil�p�s a j�t�kb�l
    public void QuitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }

    // Ha van ment�s, megjelenik a Continue gomb, lehet�s�get adva a folytat�sra
    void Update()
    {
        if (File.Exists(Application.dataPath + "/DataXml.text"))
        {
            ContinueButton.SetActive(true);
        }
    }
}
