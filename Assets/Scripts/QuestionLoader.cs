using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class QuestionLoader : MonoBehaviour
{
    //Globális változók és referálások
    public Text question;
    public int j = 0;
    public int pontszam = 0;
    public bool response = false;
    public Text Cheats;
    private string ending = "HappyEnding";
    private string menu = "Menu";

    public void Start()
    {
        //Kiírja az elsõ kérdést
        DisplayNextQuestion();
        Cheats.text = GameManager.Instance.puska.ToString();

    }

    // A következõ kérdés kiírása az elõzõ helyett
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

    //True gomb megnyomása
    public void TrueButton()
    {
        if (GameManager.Instance.answers[j] == true)
        {
            pontszam++;
        }
        j++;
        DisplayNextQuestion();
    }

    //False gomb megnyomása
    public void FalseButton()
    {
        if (GameManager.Instance.answers[j] == false)
        {
            pontszam++;
        }
        j++;
        DisplayNextQuestion();
    }

    //Cheat gomb megnyomása
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