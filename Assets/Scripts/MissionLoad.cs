using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionLoad : MonoBehaviour
{
    private float delayBeforeDisappear = 5f;
    public Text MissionDescription;

    private void Start()
    {
        //Küldetés szövegének kiiratása elõrehaladás alapján
        if (GameManager.Instance.stageCounter <= 2)
        {
            MissionDescription.text = GameManager.Instance.Ndescription;
            Invoke("DisappearText", delayBeforeDisappear);
        }
        else
        {
            MissionDescription.text = GameManager.Instance.Fdescription;
            Invoke("DisappearText", delayBeforeDisappear);
        }
    }

    //Küldetés egy idõ után eltûnik
    private void DisappearText()
    {
        gameObject.SetActive(false);

    }
}
