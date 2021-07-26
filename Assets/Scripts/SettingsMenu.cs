using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    

    Resolution[] resolutions;
    public Dropdown resolutionDropdown;

    public Slider sliderX;
    public Slider sliderY;

    public Slider VolumeSlider;

    private void Start()
    {
        StaticVariables.x = PlayerPrefs.GetFloat("OrbitX");
        StaticVariables.y = PlayerPrefs.GetFloat("OrbitY");

        sliderX.value = (StaticVariables.x - 20)/15;
        sliderY.value = (StaticVariables.y - 20)/15;

        float volume = PlayerPrefs.GetFloat("Volume");
        audioMixer.SetFloat("masterVol", volume);
        VolumeSlider.value = volume;


        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("masterVol", volume);
        PlayerPrefs.SetFloat("Volume", volume);
        Debug.Log(volume);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen)
        {
            PlayerPrefs.SetInt("fullScreen", 0);
        }
        else
        {
            PlayerPrefs.SetInt("fullScreen", 1);
        }
        
    }

    public void AdjustXSpeed(float value)
    {
        StaticVariables.x = 20 + (value * 15);
        PlayerPrefs.SetFloat("OrbitX", StaticVariables.x);
    }
    public void AdjustYSpeed(float value)
    {
        StaticVariables.y = 20 + (value * 15);

        PlayerPrefs.SetFloat("OrbitY", StaticVariables.y);
    }

}
