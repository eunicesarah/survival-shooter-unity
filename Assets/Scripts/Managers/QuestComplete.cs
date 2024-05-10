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
        public GameObject save;


        public GameObject CountDown;
        public TextMeshProUGUI CountDownText;


        public bool isQuestCompleted = false;

        public bool isQuestJendralCompleted = false;

        public bool isFromLoad = false;

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

            if(currentCanvas.name == "GameScene1" && !isFromLoad)
            {
                if (playerScore >= 10)
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
                    // save.SetActive(true);


                    // questCompleteCanvas.SetActive(true);
                    // playerhealth.godMode = true;
                    if(!isQuestCompleted)
                    {
                        anim.SetTrigger("QuestCompleted");
                        MainManager.Instance.coin += 100;
                        coinsmanager.UpdateCoinsUI();
                    }
                    isQuestCompleted = true;

                    if (Input.GetKeyDown(KeyCode.Space) || countDown<=0f)
                    {
                        MainManager.Instance.questCompleted++;
                        MainManager.Instance.playerHealth = playerhealth.currentHealth;
                        currentCanvas.SetActive(false);
                        nextCanvas.SetActive(true);
                    }

                }
            }
            else if(currentCanvas.name == "GameScene2" && !isFromLoad)
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
                    // save.SetActive(true);


                    // questCompleteCanvas.SetActive(true);
                    // playerhealth.godMode = true;
                    if(!isQuestCompleted)
                    {
                        anim.SetTrigger("QuestCompleted");
                        MainManager.Instance.coin += 100;
                        coinsmanager.UpdateCoinsUI();
                    }
                    isQuestCompleted = true;

                    if (Input.GetKeyDown(KeyCode.Space) || countDown<=0f)
                    {
                        MainManager.Instance.questCompleted++;
                        MainManager.Instance.playerHealth = playerhealth.currentHealth;
                        currentCanvas.SetActive(false);
                        nextCanvas.SetActive(true);
                    }

                }
            }
            else if(currentCanvas.name == "GameScene3" && !isFromLoad)
            {
                GameObject jendral = GameObject.FindGameObjectWithTag("Jendral");
                if(jendral==null)
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
                    // save.SetActive(true);


                    // questCompleteCanvas.SetActive(true);
                    // playerhealth.godMode = true;
                    if(!isQuestCompleted)
                    {
                        anim.SetTrigger("QuestCompleted");
                        MainManager.Instance.coin += 100;
                        coinsmanager.UpdateCoinsUI();
                    }
                    isQuestCompleted = true;
                    isQuestJendralCompleted = true;

                    if (Input.GetKeyDown(KeyCode.Space)|| countDown<=0f)
                    {
                        MainManager.Instance.questCompleted++;
                        MainManager.Instance.playerHealth = playerhealth.currentHealth;
                        enemyManager.SetActive(true);
                        shop.SetActive(false);
                        // save.SetActive(false);
                        raja.SetActive(true);
                        CountDown.SetActive(false);
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
                        currentCanvas.SetActive(false);
                        nextCanvas.SetActive(true);
                    }
                }
               
            }
            else if(isFromLoad)
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
                // save.SetActive(true);
                if(!isQuestCompleted)
                    {
                        anim.SetTrigger("QuestCompleted");
                    }
                
                isQuestCompleted = true;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    MainManager.Instance.questCompleted++;
                    MainManager.Instance.playerHealth = playerhealth.currentHealth;
                    currentCanvas.SetActive(false);
                    nextCanvas.SetActive(true);
                }
                
            }
        }
    }
}
