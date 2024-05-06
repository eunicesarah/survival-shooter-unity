﻿using UnityEngine;

namespace Nightmare
{
    public class EnemyManager : PausibleObject
    {
        public GameObject enemy;
        // public GameObject healthOrb; 
        private PlayerHealth playerHealth;
        public float spawnTime = 3f;
        public Transform[] spawnPoints;

        private float timer;
        //private int spawned = 0;

        void Start ()
        {
            timer = spawnTime;
        }

        void OnEnable()
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            StartPausible();
        }

        void OnDestroy()
        {
            StopPausible();
        }

        void Update()
        {
            if (isPaused)
                return;

            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                Spawn();
                timer = spawnTime;
            }
        }

        void Spawn ()
        {           
            // If the player has no health left...
            if(playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            
             // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        // GameObject spawnedEnemy = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
       
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        // Debug.Log("Spawned enemy at " + spawnPoints[spawnPointIndex].position);

        // Get the EnemyHealth component of the spawned enemy
        // EnemyHealth enemyHealth = spawnedEnemy.GetComponent<EnemyHealth>();

        // Assign the powerUpOrb to the EnemyHealth component
        // enemyHealth.powerUpOrb = healthOrb;
        }
    }
}