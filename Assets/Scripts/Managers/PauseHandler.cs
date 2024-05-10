using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Nightmare
{
    public class PauseHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        PauseManager pauseManager;
        void Start()
        {
            pauseManager = FindObjectOfType<PauseManager>();   
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void ResumeButton()
        {
            Debug.Log("Resume Button Clicked");
            pauseManager.Pause();
            pauseManager.pauseUI.SetActive(false);
            pauseManager.lagiPause = false;
        }

        public void RestartButton()
        {
            Debug.Log("Restart Button Clicked");
            pauseManager.Pause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void MainMenuButton()
        {
            Debug.Log("Main Menu Button Clicked");
            pauseManager.Pause();
            SceneManager.LoadScene(0);
        }

    }

}
