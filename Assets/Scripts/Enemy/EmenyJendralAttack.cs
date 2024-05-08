using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Nightmare{
    public class EmenyJendralAttack : PausibleObject
    {
        public float timeBetweenAttacks = 0.5f;

        public float timeAttackRadius = 1f;
        public int attackDamage = 10;
        public float radiusTreshold = 6f;

        Animator anim;
        GameObject player;
        GameObject pet;
        GameObject[] petAlive;
        PlayerHealth playerHealth;
        EnemyHealth enemyHealth;
        bool playerInRange;
        float distance;

        bool playerInRadius;
        float timerSword;
        float timerArea;
        private int baseAttackDamage;
        private int currentAttackDamage;
        public int alivePets;

        void Awake ()
        {
            // Setting up the references.
            pet = GameObject.Find("Eagle");
            player = GameObject.FindGameObjectWithTag ("Player");
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent<EnemyHealth>();
            anim = GetComponent <Animator> ();
            baseAttackDamage = attackDamage; // Store the base attack damage
            currentAttackDamage = baseAttackDamage;

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
                playerInRange = true;
            }
        }

        void OnTriggerExit (Collider other)
        {
            // If the exiting collider is the player...
            if(other.gameObject == player)
            {
                playerInRange = false;
            }
        }

        void Update ()
        {
            petAlive = GameObject.FindGameObjectsWithTag("PetEnemy");
            alivePets = petAlive.Length;
            
            if (isPaused)
                return;
            
            // Add the time since Update was last called to the timer.
            timerSword += Time.deltaTime;
            timerArea += Time.deltaTime;

            distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance < radiusTreshold)
            {
                Debug.Log("Player is near the enemy!");
                playerInRadius = true;
            }
            else
            {
                playerInRadius = false;
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

            if (petAlive!=null)
            {   
                
                currentAttackDamage = (int)(baseAttackDamage * (1 + 0.2f * alivePets));
                attackDamage = currentAttackDamage;
                Debug.Log("alivePets: " + alivePets);
            }
            else
            {
                Debug.Log("No pets alive");
                currentAttackDamage = baseAttackDamage;
                attackDamage = baseAttackDamage;
            }

        }

        void Attack ()
        {
            // Reset the timer.
            timerSword = 0f;

            // If the player has health to lose...
            if(playerHealth.currentHealth > 0)
            {
                // ... damage the player.
                playerHealth.TakeDamage (currentAttackDamage*2);
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
