using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class PauseManager : MonoBehaviour {
	
	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;
	
	public GameObject canvas;
	public GameObject pauseUI;

	public bool  lagiPause = false;
	
	void Awake()
	{
		pauseUI = GameObject.Find("PauseCanvas").transform.GetChild(0).gameObject;
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			lagiPause = !lagiPause;
			//canvas.enabled = !canvas.enabled;
			pauseUI.SetActive(lagiPause);
			Pause();
		}
	}
	
	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		Lowpass ();
		
	}
	
	void Lowpass()
	{
		// if (Time.timeScale == 0)
		// {
		// 	paused.TransitionTo(.01f);
		// }
		
		// else
			
		// {
		// 	unpaused.TransitionTo(.01f);
		// }
	}
	
	public void Quit()
	{
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}
