using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
}
