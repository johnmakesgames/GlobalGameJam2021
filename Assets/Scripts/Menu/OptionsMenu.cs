using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioSource audioSource;
    public AudioClip audioClip;

    Resolution[] resolutions;

    public Dropdown resDropdown;
    public Dropdown qualityDropdown;

    public void Start()
    {
        resolutions = Screen.resolutions.Select(resolutions => new Resolution { width = resolutions.width, height = resolutions.height }).Distinct().ToArray();

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

        qualityDropdown.value = QualitySettings.GetQualityLevel();
    }

    public void SetResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        //TODO:: SET UP VOLUME FOR GAME AUDIO / BARKS
        audioMixer.SetFloat("Volume", volume);
//        audioSource.volume = volume;
//        AudioSource.PlayClipAtPoint(audioClip, transform.position, volume);
//        audioSource.PlayOneShot(audioClip, volume);
        
    }

    public void SetQuality(int quality)
    {
        Debug.Log(QualitySettings.GetQualityLevel());
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
