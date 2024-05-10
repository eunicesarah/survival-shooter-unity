using Nightmare;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nightmare
{
public class VolumeManager : MonoBehaviour
{
    public Slider slider;
    public float volumeBGM = 0.5f;
    void Start()
    {
        volumeBGM = GameObject.Find("BGM").GetComponent<AudioSource>().volume;
        slider.value = volumeBGM;
        MainManager.Instance.vol = this.volumeBGM;
    }

    void Update()
    {
        slider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float volume)
    {
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = volume;
        this.volumeBGM = volume;
        MainManager.Instance.vol = this.volumeBGM;
    }
}

}
