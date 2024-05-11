using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class QuestionLoader : MonoBehaviour
{
    //Glob�lis v�ltoz�k �s refer�l�sok
    public Text question;
    public int j = 0;
    public int pontszam = 0;
    public bool response = false;
    public Text Cheats;
    private string ending = "HappyEnding";
    private string menu = "Menu";

    public void Start()
    {
        //Ki�rja az els� k�rd�st
        DisplayNextQuestion();
        Cheats.text = GameManager.Instance.puska.ToString();

    }

    // A k�vetkez� k�rd�s ki�r�sa az el�z� helyett
    public void DisplayNextQuestion()
    {
        if (j < GameManager.Instance.dialogs.Count)
        {
            question.text = GameManager.Instance.dialogs[j];
            response = false;
        }
        else if (pontszam >= 6)
        {
            SceneManager.LoadScene(ending);
            File.Delete(Application.dataPath + "/DataXml.text");
        }
        else
        {
            SceneManager.LoadScene(menu);
            File.Delete(Application.dataPath + "/DataXml.text");
        }
    }

    //True gomb megnyom�sa
    public void TrueButton()
    {
        if (GameManager.Instance.answers[j] == true)
        {
            pontszam++;
        }
        j++;
        DisplayNextQuestion();
    }

    //False gomb megnyom�sa
    public void FalseButton()
    {
        if (GameManager.Instance.answers[j] == false)
        {
            pontszam++;
        }
        j++;
        DisplayNextQuestion();
    }

    //Cheat gomb megnyom�sa
    public void CheatButton()
    {
        if (GameManager.Instance.puska > 0)
        {
            pontszam++;
            GameManager.Instance.puska -= 1;
            Cheats.text = GameManager.Instance.puska.ToString();
            j++;
            DisplayNextQuestion();
        }
    }
}