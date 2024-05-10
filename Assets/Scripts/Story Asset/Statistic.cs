using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

namespace Nightmare {

    
    public class Statistic : MonoBehaviour
    {

    public TextMeshProUGUI Distance;
    public TextMeshProUGUI DeathCount;
    public TextMeshProUGUI EnemyKilled;
    public TextMeshProUGUI StoryProgress;
    public TextMeshProUGUI Accuracy;
    public TextMeshProUGUI PlayTime;
    public DateTime endTime;
    public TimeSpan playTime; 
       public void Start()
        {
            // Cursor.visible = true;
            // Cursor.lockState = CursorLockMode.None;
            
            Distance.text = (MainManager.Instance.totalDistanceTraveled /1000f).ToString() + " km";
            DeathCount.text = MainManager.Instance.deathCount.ToString();
            EnemyKilled.text = MainManager.Instance.enemyKilled.ToString();
            StoryProgress.text = ((float) MainManager.Instance.questCompleted / 4 * 100).ToString() + "%";
            if (MainManager.Instance.totalbullets == 0)
            {
                Accuracy.text = "0%";
            }
            else
            {
                Accuracy.text = ((float) MainManager.Instance.bulletsHit / MainManager.Instance.totalbullets * 100).ToString() + "%";
            }
            // Accuracy.text = ((float) MainManager.Instance.bulletsHitScene / MainManager.Instance.totalbulletsScene * 100).ToString() + "%";
            endTime = DateTime.Now;
            playTime = endTime - MainManager.Instance.startTime;
            string playTimeFormatted = $"{playTime.Hours:00}:{playTime.Minutes:00}:{playTime.Seconds:00}";
            PlayTime.text = playTimeFormatted;

        }
    }
}