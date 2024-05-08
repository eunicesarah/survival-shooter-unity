using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nightmare
{
    public class QuestComplete : MonoBehaviour
    {
        PlayerHealth playerhealth;
        int playerScore;
        ScoreManager scoreManager;
        public GameObject scores;
        public GameObject questCompleteCanvas;
        public GameObject currentCanvas;
        public GameObject nextCanvas;
        //private float survivalTime = 60f;


        void Start()
        {

            playerhealth = FindObjectOfType<PlayerHealth>();
            scoreManager = scores.GetComponent<ScoreManager>();
            SceneManager.LoadScene(1);


        }
        void Update()
        {
            playerScore = scoreManager.getScore();

            
            if (playerScore >= 100 || Time.timeSinceLevelLoad >= 60f)
            {

                questCompleteCanvas.SetActive(true);
                playerhealth.godMode = true;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    
                    currentCanvas.SetActive(false);
                    nextCanvas.SetActive(true);
                }

            }
        }
    }
}
