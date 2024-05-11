using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionLoad : MonoBehaviour
{
    private float delayBeforeDisappear = 5f;
    public Text MissionDescription;

    private void Start()
    {
        //K�ldet�s sz�veg�nek kiirat�sa el�rehalad�s alapj�n
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

    //K�ldet�s egy id� ut�n elt�nik
    private void DisappearText()
    {
        gameObject.SetActive(false);

    }
}
