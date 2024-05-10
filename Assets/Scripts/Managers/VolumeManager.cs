using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public float volumeBGM;
    void Start()
    {
        volumeBGM = GameObject.Find("BGM").GetComponent<AudioSource>().volume;
        GameObject.Find("VolSlider").GetComponent<Slider>().value = volumeBGM;
    }

    void Update()
    {
        GameObject.Find("VolSlider").GetComponent<Slider>().onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float volume)
    {
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = volume;
        volumeBGM = volume;
    }
}
