using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    //Kilépés a játékból
    public void QuitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }
}