using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Nightmare
{
    public class petEnemyMovement: MonoBehaviour
    {
        
        Transform jendral;
        private Transform player;

        EnemyHealth enemyHealth;

        PlayerHealth playerHealth;

        EmenyJendralAttack emenyJendralAttack;

        NavMeshAgent nav;


        void Awake ()
        {
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            jendral = GameObject.FindGameObjectWithTag ("Jendral").transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = jendral.GetComponent <EnemyHealth> ();
            emenyJendralAttack = jendral.GetComponent <EmenyJendralAttack> ();
            nav = GetComponent<NavMeshAgent>();

            // StartPausible();
        }

        // void OnEnable()
        // {
        //     nav.enabled = true;
        //     ClearPath();
        //     ScaleVision(1f);
        //     IsPsychic();
        //     timer = 0f;
        // }

        // void ClearPath()
        // {
        //     if (nav.hasPath)
        //         nav.ResetPath();
        // }
        void Start()
        {
            int damageToAdd = (int)(emenyJendralAttack.attackDamage * 0.2f);
            emenyJendralAttack.attackDamage = emenyJendralAttack.attackDamage + damageToAdd;
        }
        void Update ()
        {   
            
            nav.SetDestination(jendral.position);




        }
    }

}
