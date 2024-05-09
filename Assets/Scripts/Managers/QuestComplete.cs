using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nightmare
{
    public class QuestComplete : MonoBehaviour
    {
        PlayerHealth playerhealth;

        CoinsManager coinsmanager;

        int playerScore;
        ScoreManager scoreManager;
        public GameObject scores;
        public GameObject questCompleteCanvas;
        public GameObject currentCanvas;
        public GameObject nextCanvas;
        //private float survivalTime = 60f;

        public GameObject enemyManager;

        public GameObject shop;

        public bool isQuestCompleted = false;

        Animator anim;


        void Start()
        {

            playerhealth = FindObjectOfType<PlayerHealth>();
            scoreManager = scores.GetComponent<ScoreManager>();
            coinsmanager = FindObjectOfType<CoinsManager>();
            anim = GameObject.Find("HUDCanvas").GetComponent<Animator>();
            


        }
        void Update()
        {
            playerScore = scoreManager.getScore();

            if(currentCanvas.name == "GameScene1" )
            {
                if (playerScore >= 100 || Time.timeSinceLevelLoad >= 60f)
                {
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                    if(enemies!=null)
                    {
                        foreach (GameObject enemy in enemies)
                        {
                            Destroy(enemy);
                        }
                    }
                    enemyManager.SetActive(false);
                    shop.SetActive(true);


                    // questCompleteCanvas.SetActive(true);
                    // playerhealth.godMode = true;
                    if(!isQuestCompleted)
                    {
                        anim.SetTrigger("QuestCompleted");
                    }
                    isQuestCompleted = true;

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        MainManager.Instance.questCompleted++;
                        MainManager.Instance.playerHealth = playerhealth.currentHealth;
                        MainManager.Instance.coin = coinsmanager.coins;
                        currentCanvas.SetActive(false);
                        nextCanvas.SetActive(true);
                    }

                }
            }
        }
    }
}
