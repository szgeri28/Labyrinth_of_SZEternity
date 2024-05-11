using System.Collections.Generic;
using UnityEngine;

//Olyan v�ltoz�k l�trehoz�sa, amik nem vesznek el a Scenek v�lt�sakor, �gy t�rolva a bet�lt�tt adatokat
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int puska;
    public int stageCounter;
    public string title;
    public string introduction;
    public string Ndescription;
    public string Fdescription;

    public List<string> dialogs;
    public List<bool> answers;

    //Ne t�r�lje ki ezeket az adatokat Scene v�lt�skor
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}