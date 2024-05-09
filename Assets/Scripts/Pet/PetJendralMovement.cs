using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Nightmare
{
    public class PetJendralMovement: MonoBehaviour
    {
        
        Transform jendral;
        private Transform player;

        EnemyHealth enemyHealth;

        PlayerHealth playerHealth;

        EmenyJendralAttack emenyJendralAttack;

        NavMeshAgent nav;
        public float safeDistance = 3f; 
        public float avoidanceWeight = 2f;


        void Awake ()
        {
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            jendral = GameObject.FindGameObjectWithTag ("Jendral").transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = jendral.GetComponent <EnemyHealth> ();
            emenyJendralAttack = jendral.GetComponent <EmenyJendralAttack> ();
            nav = GetComponent<NavMeshAgent>();
            nav.speed = 10f;

            // StartPausible();
        }
    void Update ()
    {

        Vector3 directionToJendral = jendral.position - transform.position;
        Vector3 directionToPlayer = transform.position - player.position;
        Vector3 combinedDirection = directionToJendral * 2f - directionToPlayer * avoidanceWeight;
        Vector3 targetPosition = transform.position + combinedDirection.normalized;
        float distanceToJendral = Vector3.Distance(transform.position, jendral.position);
        if (distanceToJendral < 1f)
        {
            targetPosition = transform.position + (transform.position - jendral.position).normalized;
        }
        else if (distanceToJendral > 5f)
        {
            targetPosition = transform.position + (jendral.position - transform.position).normalized;
        }
        
        nav.SetDestination(targetPosition);
    }
    }

}
