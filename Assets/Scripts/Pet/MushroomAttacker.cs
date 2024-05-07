using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Nightmare { 
public class PetAttacker : MonoBehaviour
{
        NavMeshAgent nav;
        private GameObject[] enemies;
        int attackAmount = 10;
        PlayerHealth playerHealth;
        private Transform player;
        GameObject closestEnemy = null;
        float timer;
        public int startingHealth = 100;
        public int CurrentHealth;
        // Start is called before the first frame update
        void Start()
        {
            nav = GetComponent<NavMeshAgent>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerHealth = player.GetComponent<PlayerHealth>();

        }


        // Update is called once per frame
        void Update()
    {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            timer += Time.deltaTime;
            if(timer > 2f && playerHealth.currentHealth > 0)
            {
                AttackEnemy();
            }
    }
        public GameObject GoToEnemy(Vector3 position)
        {
            GameObject closestEnemy = null;
            float closestDistance = Mathf.Infinity;
            Vector3 currentPosition = transform.position;

            foreach (GameObject enemy in enemies)
            {
                Vector3 directionToTarget = enemy.transform.position - currentPosition;
                float distanceToTarget = directionToTarget.magnitude;

                if (distanceToTarget < closestDistance)
                {
                    closestDistance = distanceToTarget;
                    closestEnemy = enemy;
                }
            }

            if (closestEnemy != null)
            {
                GoToPosition(closestEnemy.transform.position);
            }
            return closestEnemy;
        }

        private void GoToPosition(Vector3 position)
        {
                SetDestination(position);
        }

        private void SetDestination(Vector3 position)
        {
            if (nav.isOnNavMesh)
            {
                nav.SetDestination(position);
            }
        }

        void AttackEnemy()
        {
            timer = 0f;
            closestEnemy = GoToEnemy(transform.position);
            if (closestEnemy == null) return;
            EnemyHealth enemyHealth = closestEnemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null && playerHealth != null)
            {
                //Debug.Log("Enemy Health before attack: " + enemyHealth.currentHealth);
                enemyHealth.TakeDamage(attackAmount, closestEnemy.transform.position);
            }
        }
        public void TakeDamage(int amount)
        {
            //Debug.Log("Pet took damage: " + amount);
            CurrentHealth -= amount;
        }

    }
}
