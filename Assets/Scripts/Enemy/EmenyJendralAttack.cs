using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Nightmare{
    public class EmenyJendralAttack : PausibleObject
    {
        public float timeBetweenAttacks = 0.5f;

        public float timeAttackRadius = 1f;
        public int attackDamage = 10;
        public float swordThreshold = 4f;

        Animator anim;
        GameObject player;
        PlayerHealth playerHealth;
        EnemyHealth enemyHealth;
        bool playerInRange;
        float distance;

        bool playerInRadius;
        float timerSword;
        float timerArea;

        void Awake ()
        {
            // Setting up the references.
            player = GameObject.FindGameObjectWithTag ("Player");
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent<EnemyHealth>();
            anim = GetComponent <Animator> ();
            

            StartPausible();
        }

        void OnDestroy()
        {
            StopPausible();
        }

        void OnTriggerEnter (Collider other)
        {

            // If the entering collider is the player...
            if(other.gameObject == player)
            {
                playerInRadius = true;
            }
        }

        void OnTriggerExit (Collider other)
        {
            // If the exiting collider is the player...
            if(other.gameObject == player)
            {
                playerInRadius = false;
            }
        }

        void Update ()
        {
            if (isPaused)
                return;
            
            // Add the time since Update was last called to the timer.
            timerSword += Time.deltaTime;
            timerArea += Time.deltaTime;

            distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance < swordThreshold)
            {
                Debug.Log("Player is near the enemy!");
                playerInRange = true;
            }
            else
            {
                playerInRange = false;
            }

            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if(timerSword >= timeBetweenAttacks && playerInRange && enemyHealth.CurrentHealth() > 0)
            {
                // ... attack.
                //anim.SetBool("isWalking", false);
                anim.SetTrigger("attack");
                Debug.Log("SwordAttack");
                Attack ();

            }
            if(timerArea >= timeAttackRadius && playerInRadius && enemyHealth.CurrentHealth() > 0)
            {
                // ... attack.
                Debug.Log("AreaDamage");
                AreaDamage ();
            }

            // If the player has zero or less health...
            if(playerHealth.currentHealth <= 0)
            {
                // ... tell the animator the player is dead.
                anim.SetTrigger ("PlayerDead");
            }
            anim.SetBool("isWalking", true);

        }

        void Attack ()
        {
            // Reset the timer.
            timerSword = 0f;

            // If the player has health to lose...
            if(playerHealth.currentHealth > 0)
            {
                // ... damage the player.
                playerHealth.TakeDamage (attackDamage*2);
            }
        }

        void AreaDamage()
        {
            timerArea = 0f;
            // If the player has health to lose...
            if(playerHealth.currentHealth > 0)
            {
                // ... damage the player.
                playerHealth.TakeDamage (attackDamage);
            }
        }
    }

}
