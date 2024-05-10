using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Nightmare
{
    public class RetryManager : MonoBehaviour
    {

        public Text Distance;
        public Text DeathCount;
        public Text EnemyKilled;
        public Text StoryProgress;
        public Text Accuracy;
        public Text PlayTime;

        public Text CountDown;

        public DateTime endTime;
        public TimeSpan playTime; 
        public float countDown = 10f;

        public Animator anim;

        public GameObject HUDUI;

        public void Start()
        {
            // Cursor.visible = true;
            // Cursor.lockState = CursorLockMode.None;
            
            Distance.text = (MainManager.Instance.distanceTraveledScene /1000f).ToString() + " km";
            DeathCount.text = MainManager.Instance.deathCount.ToString();
            EnemyKilled.text = MainManager.Instance.enemyKilledScene.ToString();
            if (MainManager.Instance.questCompleted >= 4)
            {
                StoryProgress.text = "100%";
            }
            else
            {
                StoryProgress.text = ((float) MainManager.Instance.questCompleted / 4 * 100).ToString() + "%";
            }
            if (MainManager.Instance.totalbulletsScene == 0)
            {
                Accuracy.text = "0%";
            }
            else
            {
                Accuracy.text = ((float) MainManager.Instance.bulletsHitScene / MainManager.Instance.totalbulletsScene * 100).ToString() + "%";
            }
            // Accuracy.text = ((float) MainManager.Instance.bulletsHitScene / MainManager.Instance.totalbulletsScene * 100).ToString() + "%";
            endTime = DateTime.Now;
            playTime = endTime - MainManager.Instance.startTimeScene;
            string playTimeFormatted = $"{playTime.Hours:00}:{playTime.Minutes:00}:{playTime.Seconds:00}";
            PlayTime.text = playTimeFormatted;
            CountDown.text = countDown.ToString();

        }
        public void Update()
        {
            countDown -= Time.deltaTime;
            CountDown.text = Mathf.RoundToInt(countDown).ToString();

            if (Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (countDown <= 0f)
            {
                anim.SetBool("GameOver", true);
                Invoke("LoadSceneDelayed", 4f);
            }

        }

        void LoadSceneDelayed()
        {
            SceneManager.LoadScene(0);
        }

    }
}