using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    //Kil�p�s a j�t�kb�l
    public void QuitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }
}