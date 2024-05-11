using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class Story : MonoBehaviour
{
    public Text Title;

    //Adatok beolvasása indításkor és hozzárendelésük változókhoz
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Story");

        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(textAsset.text);

        XmlNode storyNode = xmlDocument.SelectSingleNode("story");

        string title = storyNode.SelectSingleNode("title").InnerText;
        GameManager.Instance.title = title;

        string introduction = storyNode.SelectSingleNode("introduction").InnerText;
        GameManager.Instance.introduction = introduction;

        XmlNode normalMissionNode = storyNode.SelectSingleNode("normalmission");
        string normalMissionDescription = normalMissionNode.SelectSingleNode("Ndescription").InnerText;

        GameManager.Instance.Ndescription = normalMissionDescription;
        
        XmlNode finalMissionNode = storyNode.SelectSingleNode("finalmission");
        string finalMissionDescription = finalMissionNode.SelectSingleNode("Fdescription").InnerText;

        GameManager.Instance.Fdescription = finalMissionDescription;

        // A "dialog" elemek értékeinek lekérése és tárolása
        for (int i = 1; i <= 10; i++)
        {
            XmlNode dialogNode = storyNode.SelectSingleNode("dialog" + i);

            if (dialogNode != null)
            {
                string dialogText = dialogNode.InnerText;
                GameManager.Instance.dialogs.Add(dialogText);
            }
        }

        // Az "answer" elemek értékeinek lekérése és tárolása
        for (int i = 1; i <= 10; i++)
        {
            XmlNode answerNode = storyNode.SelectSingleNode("answer" + i);

            if (answerNode != null)
            {
                if (answerNode.InnerText == "true")
                {
                    bool answerText = true;
                    GameManager.Instance.answers.Add(answerText);
                }
                else if (answerNode.InnerText == "false")
                {
                    bool answerText = false;
                    GameManager.Instance.answers.Add(answerText);
                }
                
            }
        }

        Title.text = GameManager.Instance.title;

    }
}
