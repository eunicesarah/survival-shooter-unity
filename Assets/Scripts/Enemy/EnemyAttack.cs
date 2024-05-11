using UnityEngine;
using System.Collections;

namespace Nightmare
{
    public class EnemyAttack : PausibleObject
    {
        public float timeBetweenAttacks = 0.5f;
        public int attackDamage = 10;

        Animator anim;
        GameObject player;
        GameObject mushroom;
        GameObject cactus;
        PlayerHealth playerHealth;
        MushroomHealth mushroomHealth;
        CactusHealth cactusHealth;
        EnemyHealth enemyHealth;
        bool playerInRange;
        float timer;

        void Awake ()
        {
            // Setting up the references.
            player = GameObject.FindGameObjectWithTag ("Player");
            mushroom = GameObject.Find("MushroomSmilePA(Clone)");
            cactus = GameObject.Find("CactusPA(Clone)");
            playerHealth = player.GetComponent <PlayerHealth> ();
            //mushroomHealth = mushroom.GetComponent <MushroomHealth> ();
            //cactusHealth = cactus.GetComponent<CactusHealth>();
            if (mushroom != null)
                mushroomHealth = mushroom.GetComponent<MushroomHealth>();

            if (cactus != null)
                cactusHealth = cactus.GetComponent<CactusHealth>();
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
                // ... the player is in range.
                playerInRange = true;
            }
            if(other.gameObject == mushroom)
            {
                // ... the player is in range.
                // playerInRange = true;
                InvokeRepeating("AttackPet1", 0f, 1f);
            }

            if(other.gameObject == cactus)
            {
                // ... the player is in range.
                // playerInRange = true;
                InvokeRepeating("AttackPet2", 0f, 1f);
            }
        }

        void OnTriggerExit (Collider other)
        {
            // If the exiting collider is the player...
            if(other.gameObject == player)
            {
                // ... the player is no longer in range.
                playerInRange = false;
            }
        }

        void Update ()
        {
            if (isPaused)
                return;
            
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.CurrentHealth() > 0)
            {
                // ... attack.
                Attack ();
            }

            // If the player has zero or less health...
            if(playerHealth.currentHealth <= 0)
            {
                // ... tell the animator the player is dead.
                anim.SetTrigger ("PlayerDead");
            }
        }

        void Attack ()
        {
            // Reset the timer.
            timer = 0f;
            int calculatedAttackDamage = attackDamage * MainManager.Instance.difficulty;
            Debug.Log("haha " + MainManager.Instance.difficulty);
            Debug.Log("cal " + calculatedAttackDamage);
            //if (MainManager.Instance.difficulty == .0f)
            //{
            //    calculatedAttackDamage *= 2; 
            //}
            //else if(MainManager.Instance.difficulty == "Hard")
            //{
            //    calculatedAttackDamage *= 3; 
            //}
            // If the player has health to lose...
            // if (mushroom != null)
            // {
            //     if(mushroomHealth.currentHealth > 0)
            //     {
            //         mushroomHealth.TakeDamage(calculatedAttackDamage);
            //     }
            // }
            // if (cactus != null )
            // {
            //     if(cactusHealth.currentHealth > 0)
            //     {
            //         Debug.Log("Cactus Health: " + cactusHealth.currentHealth);
            //         cactusHealth.TakeDamage(calculatedAttackDamage);
            //     }
            //     // cactusHealth.TakeDamage(attackDamage);
            // }
            if (playerHealth != null && playerHealth.currentHealth > 0)
            {
                // ... damage the player.
                playerHealth.TakeDamage(calculatedAttackDamage);
            }
        }

        void AttackPet1()
        {
            if(mushroom!=null)
            {
                if (mushroomHealth.currentHealth > 0)
                {
                    mushroomHealth.TakeDamage(attackDamage);
                }

            }
        }

        void AttackPet2()
        {
            if(cactus!=null)
            {
                if (cactusHealth.currentHealth > 0)
                {
                    cactusHealth.TakeDamage(attackDamage);
                }
            }
        }
    }
}