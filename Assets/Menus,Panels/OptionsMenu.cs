using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //hanger�szab�lyz�
    public AudioMixer audioMixer;
    //k�perny�felbont�s
    Resolution[] resolutions;
    //felbont�si opci�k felsorol�s�hoz
    public TMPro.TMP_Dropdown resolutionDropdown;

    void Start()
    {
        //�sszes lehets�ges felbont�s felismer�se
        resolutions = Screen.resolutions;

        //megadott opci�k t�rl�se
        resolutionDropdown.ClearOptions();

        //Lista megalkot�sa a felbont�sokhoz
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        //felbont�sok list�ba rendez�se
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        //felbont�sok hozz�ad�sa az opci�khoz
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //Be�ll�tja a k�v�nt felbont�st
    public void SetResolution(int  resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    //Hanger�szab�lyz�
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    //Teljesk�preny� �ll�t�sa
    public void SetFullscreen (bool isFullscreen)
    {
        Debug.Log("Fullscreen...");
        Screen.fullScreen = isFullscreen;
    }
}
