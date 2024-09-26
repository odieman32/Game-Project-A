using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; //public variable for audio mixer

    public TMPro.TMP_Dropdown resolutionDropdown; //dropdown variable

    Resolution[] resolutions; //represents display resolution

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>(); //makes a list called options

        int currentResolutionIndex = 0; //Integer to find current resoltuon automaticaly

        for (int i = 0; i < resolutions.Length; i++) //for loop to get the width and height for the options list
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRateRatio + " Hz";
            options.Add(option);

            if (resolutions[i].Equals(Screen.currentResolution)) //gets the resolution of your current system
            {
                currentResolutionIndex = i;
            }
            

        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.AddOptions(options); //adds options list to resolution dropdown 
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); //Sets the resolution by default
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume); //sets level of mixer by the value of slider
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); //sets the quality by the drop box
    }
}
