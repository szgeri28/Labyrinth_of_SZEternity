using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //hangerõszabályzó
    public AudioMixer audioMixer;
    //képernyõfelbontás
    Resolution[] resolutions;
    //felbontási opciók felsorolásához
    public TMPro.TMP_Dropdown resolutionDropdown;

    void Start()
    {
        //Összes lehetséges felbontás felismerése
        resolutions = Screen.resolutions;

        //megadott opciók törlése
        resolutionDropdown.ClearOptions();

        //Lista megalkotása a felbontásokhoz
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        //felbontások listába rendezése
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        //felbontások hozzáadása az opciókhoz
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //Beállítja a kívánt felbontást
    public void SetResolution(int  resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    //Hangerõszabályzó
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    //Teljesképrenyõ állítása
    public void SetFullscreen (bool isFullscreen)
    {
        Debug.Log("Fullscreen...");
        Screen.fullScreen = isFullscreen;
    }
}
