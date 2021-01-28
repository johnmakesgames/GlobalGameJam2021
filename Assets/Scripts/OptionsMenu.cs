using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    Resolution[] resolutions;

    public Dropdown resDropdown;

    public void Start()
    {
        resolutions = Screen.resolutions;

        resDropdown.ClearOptions();

        List<string> resOptions = new List<string>();

        int currentResIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string options = resolutions[i].width + "x" + resolutions[i].height;
            resOptions.Add(options);

            //Checking if the current res in the dropdown is what the screen res actually is. 
            //Dropdown be weird sometimes don't worry. 
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                //Will be setting the starting dropdown option to actually display what our current res is.
                currentResIndex = i;
            }
        }

        resDropdown.AddOptions(resOptions);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
    }

    public void SetResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetVolume(float value)
    {
        Debug.Log(value);
        //TODO:: SET UP VOLUME FOR GAME AUDIO / BARKS
    }

    public void SetQuality(int index)
    {
        Debug.Log(QualitySettings.GetQualityLevel());
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
