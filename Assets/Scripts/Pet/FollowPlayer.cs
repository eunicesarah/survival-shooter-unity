using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Nightmare
{
    public class FollowPlayer : MonoBehaviour
    {
        public Transform target;
        private Transform player;
        public Slider playerHealthSlider;
        NavMeshAgent nav;
        PlayerHealth playerHealth;
        float timerPet;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerHealthSlider = GameObject.FindGameObjectWithTag("playerHeartSlider").GetComponent<Slider>();
            playerHealth = player.GetComponent<PlayerHealth>();
            nav = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            timerPet += Time.deltaTime;
            nav.SetDestination(target.position);
            Debug.Log("Current time " + timerPet);
            Debug.Log("Current Player health: " + playerHealth.currentHealth);

            if (timerPet >= 2.0f - 0.001f)
            {
                HealPlayer();
                timerPet = 0f;
                Debug.Log("Player health: " + playerHealth.currentHealth);
            }
        }

        void HealPlayer()
        {
            playerHealth.currentHealth += 1;
            playerHealthSlider.value = playerHealth.currentHealth;
        }
    }
}
