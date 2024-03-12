using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolumeSlider : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetFloat("volume", 1);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }

    public void changeVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("volume", newVolume);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}
