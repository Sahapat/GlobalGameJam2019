using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Option : MonoBehaviour
{
    [SerializeField]Slider volumeSlider = null;
    void Start()
    {
        volumeSlider.value = PlayerData.volume;
    }
    void Update()
    {
        PlayerData.volume = volumeSlider.value;
    }
    void OnDisable()
    {   
        SaveToPref();
    }
    void SaveToPref()
    {
        var temp = PlayerPrefs.HasKey("Volume");
        if(temp)
        {
            PlayerPrefs.SetFloat("Volume",volumeSlider.value);
        }
        else
        {
            PlayerPrefs.SetFloat("Volume",volumeSlider.value);
        }
    }
}
