using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Nightmare;


public class VolumeHandler : MonoBehaviour {

    public float volumeBGM;
    void Start () 
	{
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().volume = MainManager.Instance.vol;
        volumeBGM = MainManager.Instance.vol;
    }

	void Update ()
	{
        GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().volume = MainManager.Instance.vol;
        volumeBGM = MainManager.Instance.vol;
    }
}
