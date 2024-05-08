using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Nightmare
{
    public class RajaAttack : MonoBehaviour
    {

        public float timeBetweenAttacks = 0.5f;
        public int attackDamage = 20;

        public float slowdownDistance = 5f;
        public float slowdownFactor = 0.2f;

        private float timer = 0f;

        Animator anim;
        GameObject player;
        //GameObject mushroom;
        PlayerHealth playerHealth;
        EnemyHealth enemyHealth;
        //MushroomHealth mushroomHealth;
        NavMeshAgent nav;
        bool playerInRange;
        //float timer;
        private PlayerShooting playerDamage;
        private int originalDamagePerShot;


        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            //mushroom = GameObject.Find("MushroomSmilePA");
            playerHealth = player.GetComponent<PlayerHealth>();
            //mushroomHealth = mushroom.GetComponent<MushroomHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            anim = GetComponent<Animator>();
            playerDamage = FindObjectOfType<PlayerShooting>();
            nav = GetComponent<NavMeshAgent>();
            originalDamagePerShot = playerDamage.damagePerShot;

        }
        void OnTriggerEnter(Collider other)
        {

            // If the entering collider is the player...
            if (other.gameObject == player)
            {
                playerInRange = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            // If the exiting collider is the player...
            if (other.gameObject == player)
            {
                playerInRange = false;
            }
        }

        void Update()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            timer += Time.deltaTime; // Accumulate time

            if (distanceToPlayer < slowdownDistance && playerHealth.currentHealth > 0)
            {
                float speedFactor = 1f - (distanceToPlayer / slowdownDistance);
                player.GetComponent<NavMeshAgent>().speed = nav.speed * slowdownFactor;

                // Check if enough time has passed since the last attack
                if (timer >= timeBetweenAttacks)
                {
                    // Reset timer for next attack
                    timer = 0f;

                    // Inflict damage on the player
                    anim.SetTrigger("GolemAttack");
                    playerHealth.TakeDamage(1);
                }

                playerDamage.damagePerShot = (int)(playerDamage.damagePerShot)/2;
                //Debug.Log("player damage " + playerDamage.damagePerShot);
                //Debug.Log("Current PLayer health: " + playerHealth.currentHealth);
            }
            else if (distanceToPlayer > slowdownDistance)
            {
                player.GetComponent<NavMeshAgent>().speed = nav.speed;
                playerDamage.damagePerShot = originalDamagePerShot;

            }
            else if (playerHealth.currentHealth <= 0)
            {
                anim.SetTrigger("PlayerDead");
                anim.SetBool("isGolemVictory", true);
            }
        }

    }
}