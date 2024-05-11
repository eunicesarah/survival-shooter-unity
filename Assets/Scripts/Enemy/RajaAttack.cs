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

        public float slowdownDistance = 10f;
        public float slowdownFactor = 0.2f;

        private float timer = 0f;
        private float distanceToPlayer; // Declare distanceToPlayer as a class-level variable

        Animator anim;
        Transform player;
        Transform mushroom;
        Transform cactus;
        PlayerHealth playerHealth;
        MushroomHealth mushroomHealth;
        CactusHealth cactusHealth;
        EnemyHealth enemyHealth;
        NavMeshAgent nav;
        bool playerInRange;
        private PlayerShooting playerDamage;
        private int originalDamagePerShot;

        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            mushroom = GameObject.Find("MushroomSmilePA(Clone)")?.transform;
            cactus = GameObject.Find("CactusPA(Clone)")?.transform;
            playerHealth = player.GetComponent<PlayerHealth>();
            if (mushroom != null)
                mushroomHealth = mushroom.GetComponent<MushroomHealth>();

            if (cactus != null)
                cactusHealth = cactus.GetComponent<CactusHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            anim = GetComponent<Animator>();
            playerDamage = FindObjectOfType<PlayerShooting>();
            nav = GetComponent<NavMeshAgent>();
            originalDamagePerShot = playerDamage.damagePerShot;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player)
            {
                playerInRange = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject == player)
            {
                playerInRange = false;
            }
        }

        void Update()
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.position); // Calculate distance to player

            timer += Time.deltaTime; // Accumulate time
            Transform target = GetPriorityTarget();

            if (target != null)
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
                    Debug.Log("Takedamage");
                }

                playerDamage.damagePerShot = (int)(playerDamage.damagePerShot) / 2;
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

        Transform GetPriorityTarget()
        {
            if (mushroom != null && cactus != null)
            {
                float distanceToMushroom = Vector3.Distance(transform.position, mushroom.position);
                float distanceToCactus = Vector3.Distance(transform.position, cactus.position);

                if (distanceToPlayer <= slowdownDistance && playerHealth.currentHealth > 0)
                {
                    return player;
                }
                else if (distanceToMushroom <= slowdownDistance && mushroomHealth.currentHealth > 0)
                {
                    return mushroom.transform;
                }
                else if (distanceToCactus <= slowdownDistance && cactusHealth.currentHealth > 0)
                {
                    return cactus.transform;
                }
            }
            else if (mushroom != null)
            {
                float distanceToMushroom = Vector3.Distance(transform.position, mushroom.position);
                if (distanceToPlayer <= slowdownDistance && playerHealth.currentHealth > 0)
                {
                    return player;
                }
                else if (distanceToMushroom <= slowdownDistance && mushroomHealth.currentHealth > 0)
                {
                    return mushroom.transform;
                }
            }
            else if (cactus != null)
            {
                float distanceToCactus = Vector3.Distance(transform.position, cactus.position);
                if (distanceToPlayer <= slowdownDistance && playerHealth.currentHealth > 0)
                {
                    return player;
                }
                else if (distanceToCactus <= slowdownDistance && cactusHealth.currentHealth > 0)
                {
                    return cactus.transform;
                }
            }
            else
            {
                if (distanceToPlayer <= slowdownDistance && playerHealth.currentHealth > 0)
                {
                    return player;
                }
            }

            return null;
        }
    }
}
