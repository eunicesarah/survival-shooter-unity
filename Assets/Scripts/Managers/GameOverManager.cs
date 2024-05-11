using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Nightmare
{
    public class GameOverManager : MonoBehaviour
    {
        private PlayerHealth playerHealth;
        Animator anim;

        LevelManager lm;
        private UnityEvent listener;

        void Awake ()
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            anim = GetComponent <Animator> ();
            lm = FindObjectOfType<LevelManager>();
            MainManager.Instance.startTimeScene = System.DateTime.Now;
            MainManager.Instance.enemyKilledScene = 0;
            // EventManager.StartListening("GameOver", ShowGameOver);
        }

        void OnDestroy()
        {
            // EventManager.StopListening("GameOver", ShowGameOver);
        }

        void ShowGameOver()
        {
            // anim.SetBool("GameOver", true);

        }

        private void ResetLevel()
        {
            ScoreManager.score = 0;
            LevelManager lm = FindObjectOfType<LevelManager>();
            lm.LoadInitialLevel();
            anim.SetBool("GameOver", false);
            playerHealth.ResetPlayer();
        }
    }
}