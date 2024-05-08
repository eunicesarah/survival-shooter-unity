using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


namespace Nightmare { 
public class CactusHealer : MonoBehaviour
{
        public Transform target;
        private Transform player;
        NavMeshAgent nav;
        PlayerHealth playerHealth;
        public float healRadius = 5f;
        public float petSpeed = 5f;
        float timerPet;

        // Start is called before the first frame update
        void Start()
    {
            player = GameObject.FindGameObjectWithTag("Player").transform;
//        //playerHealthSlider = GameObject.FindGameObjectWithTag("playerHeartSlider").GetComponent<Slider>();
            playerHealth = player.GetComponent<PlayerHealth>();
            nav = GetComponent<NavMeshAgent>();
            nav.speed = petSpeed;
        }

    // Update is called once per frame
    void Update()
    {
        timerPet += Time.deltaTime;
        Vector3 behindPlayer = player.transform.position - player.transform.forward * 1;
        nav.SetDestination(behindPlayer);
        //Debug.Log("Current time " + timerPet);

            if (Vector3.Distance(player.position, transform.position) <= healRadius && playerHealth.currentHealth < 100)
            {
                if (timerPet >= 2.0f && playerHealth.currentHealth > 0)
                {
                    healPlayer();
                    Debug.Log("Current Player health: " + playerHealth.currentHealth);
                    timerPet = 0f;
                }
            }
            if (playerHealth.currentHealth <= 0)
            {
                timerPet = 3f;
            }
        }
    void healPlayer()
    {

            playerHealth.currentHealth += 1;
            playerHealth.healthSlider.value = playerHealth.currentHealth;
    }
}
}