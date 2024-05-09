using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

        public GameObject raja;

        public GameObject shop;

        public GameObject CountDown;
        public TextMeshProUGUI CountDownText;


        public bool isQuestCompleted = false;

        public bool isQuestJendralCompleted = false;

        public float countDown = 90f;
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
                if (playerScore >= 500)
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
            else if(currentCanvas.name == "GameScene2")
            {
                GameObject[] kepala = GameObject.FindGameObjectsWithTag("Enemy");
                int countKepalaKeroco = 0;
                if(kepala!=null)
                {
                    foreach (GameObject obj in kepala)
                    {
                        if (obj.name == "KepalaKeroco")
                        {
                            countKepalaKeroco++;
                        }
                    }
                }
                if (countKepalaKeroco<=5)
                {
                    countDown -= Time.deltaTime;
                    CountDown.SetActive(true);
                    CountDownText.text = Mathf.RoundToInt(countDown).ToString();
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

                    if (Input.GetKeyDown(KeyCode.Space) || countDown<=0f)
                    {
                        MainManager.Instance.questCompleted++;
                        MainManager.Instance.playerHealth = playerhealth.currentHealth;
                        MainManager.Instance.coin = coinsmanager.coins;
                        currentCanvas.SetActive(false);
                        nextCanvas.SetActive(true);
                    }

                }
            }
            else if(currentCanvas.name == "GameScene3")
            {
                GameObject jendral = GameObject.FindGameObjectWithTag("Jendral");
                if(jendral==null)
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
                    isQuestJendralCompleted = true;

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        MainManager.Instance.questCompleted++;
                        MainManager.Instance.playerHealth = playerhealth.currentHealth;
                        MainManager.Instance.coin = coinsmanager.coins;
                        enemyManager.SetActive(true);
                        shop.SetActive(false);
                        raja.SetActive(true);
                        isQuestCompleted = false;
                    }
                   
                }
                if(raja==null)
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
                    // shop.SetActive(true);


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
