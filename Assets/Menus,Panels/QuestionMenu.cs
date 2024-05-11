using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml;
using System.IO;


public class QuestionMenu: MonoBehaviour
{
    //Panelekre val� refer�l�s
    public GameObject questionMenu;
    public static bool GameIsPaused = false;
    public GameObject failedPanel;

    //Jelenetekre vel� refer�l�s
    private string campus = "Campus";
    private string game = "Game";
    private string boss = "Boss";

    //J�t�k jeleneteinek sz�mol�sa
    public int stageCounter = 0;

    //Igen eset�n a k�vetkez� jelenet bet�lt�se, att�l f�gg�en hol tart a j�t�kban
    public void YesButton()
    {
        if (GameManager.Instance.stageCounter < 2)
        {
            SceneManager.LoadScene(campus);
            Door.IsOpened = false;
            GameIsPaused = false;
            Time.timeScale = 1f;

        }
        else
        {
            SceneManager.LoadScene(boss);
            GameIsPaused = false;
            Time.timeScale = 1f;
        }
        GameManager.Instance.stageCounter++;
        ItemPickup.kredit = 0;
        //Autosave a p�ly�k v�g�n
        SaveByXml();
    }

    //Nem v�lasz eset�n menjen tov�bb a j�t�k a labirintusban
    public void NoButton()
    {
        questionMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    //Ment�s
    public void SaveByXml()
    {
        Save save = createSaveGameObject();
        XmlDocument xmlDocument = new XmlDocument();

        XmlElement root = xmlDocument.CreateElement("Save");
        root.SetAttribute("FileName", "File_01");

        XmlElement cheatNumElement = xmlDocument.CreateElement("cheatNum");
        cheatNumElement.InnerText = save.cheatNum.ToString();
        root.AppendChild(cheatNumElement);

        XmlElement roomNumElement = xmlDocument.CreateElement("roomNum");
        roomNumElement.InnerText = save.roomNum.ToString();
        root.AppendChild(roomNumElement);

        xmlDocument.AppendChild(root);

        xmlDocument.Save(Application.dataPath + "/DataXml.text");
        if (File.Exists(Application.dataPath + "/DataXml.text"))
        {
            Debug.Log("XML file saved...");
        }
    }

    //El�z� ment�s bet�lt�se �s j�t�k ind�t�sa
    public void LoadLastCheckpoint()
    {
        LoadByXml();
        failedPanel.SetActive(false);
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
    }

    //Ment�s bet�lt�se �s az adatok t�rol�sa
    public void LoadByXml()
    {
        if (File.Exists(Application.dataPath + "/DataXml.text"))
        {
            Save save = new Save();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Application.dataPath + "/DataXml.text");

            XmlNodeList cheatNum = xmlDocument.GetElementsByTagName("cheatNum");
            int cheatNumCount = int.Parse(cheatNum[0].InnerText);
            save.cheatNum = cheatNumCount;

            XmlNodeList roomNum = xmlDocument.GetElementsByTagName("roomNum");
            int roomNumCount = int.Parse(roomNum[0].InnerText);
            save.roomNum = roomNumCount;

            GameManager.Instance.puska = save.cheatNum;
            GameManager.Instance.stageCounter = save.roomNum;

            if (GameManager.Instance.stageCounter < 3)
            {
                SceneManager.LoadScene(game);
                PauseMenu.GameIsPaused = false;
                Time.timeScale = 1f;
            }
            else
            {
                SceneManager.LoadScene(boss);
                PauseMenu.GameIsPaused = false;
                Time.timeScale = 1f;
            }
            
        }
        else
        {
            Debug.Log("XML file not found...");
        }

    }

    public Save createSaveGameObject()
    {
        Save save = new Save();

        save.cheatNum = GameManager.Instance.puska;
        save.roomNum = GameManager.Instance.stageCounter;

        return save;
    }
}
