using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Nightmare
{
    public class PetJendralMovement : PausibleObject
    {
        public float visionRange = 10f;
        public float hearingRange = 20f;
        public float wanderDistance = 10f;
        public Vector2 idleTimeRange;
        [Range(0f,1f)]
        public float psychicLevels = 0.2f;

        float currentVision; 
        Transform player;
        Transform mushroom;
        Transform cactus;
        PlayerHealth playerHealth;
        MushroomHealth mushroomHealth;
        CactusHealth cactusHealth;
        PetJendralHealth petHealth;
        NavMeshAgent nav;
        public float timer = 0f;

        void Awake ()
        {
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            mushroom = GameObject.Find("MushroomSmilePA")?.transform;
            cactus = GameObject.Find("CactusPA")?.transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            //mushroomHealth = mushroom.GetComponent <MushroomHealth> ();
            //cactusHealth = cactus.GetComponent<CactusHealth>();
            if (mushroom != null)
                mushroomHealth = mushroom.GetComponent<MushroomHealth>();

            if (cactus != null)
                cactusHealth = cactus.GetComponent<CactusHealth>();
            petHealth = GetComponent <PetJendralHealth> ();
            nav = GetComponent<NavMeshAgent>();

            StartPausible();
        }

        void OnEnable()
        {
            nav.enabled = true;
            ClearPath();
            ScaleVision(1f);
            IsPsychic();
            timer = 0f;
        }

        void ClearPath()
        {
            if (nav.hasPath)
                nav.ResetPath();
        }

        void Update ()
        {
            if (!isPaused)
            {
                if (player == null && mushroom == null && cactus == null)
                {
                    // One of the GameObject references is null, handle this case appropriately.
                    return;
                }
                if(mushroom != null){
                    if (petHealth.CurrentHealth() > 0 && mushroomHealth.currentHealth > 0 )
                    {
                        LookForMushroom();
                        //
                    }
                // If both the enemy and the player have health left...
                // WanderOrIdle();
                }
                else if(cactus != null){
                    if (petHealth.CurrentHealth() > 0 && cactusHealth.currentHealth > 0 )
                    {
                        LookForCactus();
                        // WanderOrIdle();
                    }
                }
                
                else if (petHealth.CurrentHealth() > 0 && playerHealth.currentHealth > 0 && player != null)
                {
                    LookForPlayer();
                    // WanderOrIdle();
                 }
                else
                 {
                     nav.enabled = false;
                 }
            }
        }

        void OnDestroy()
        {
            nav.enabled = false;
            StopPausible();
            if (cactus != null)
            {
                if (cactusHealth != null)
                {
                    cactusHealth.OnDeath -= GoToCactus;
                    cactusHealth.OnNoise -= HearPoint;
                }
            }
            else if(mushroom != null)
            {
                if (mushroomHealth != null)
                {
                    mushroomHealth.OnDeath -= GoToMushroom;
                    mushroomHealth.OnNoise -= HearPoint;
                }
            }
        }

        public override void OnPause()
        {
            if (nav.hasPath)
                nav.isStopped = true;
        }

        public override void OnUnPause()
        {
            if (nav.hasPath)
                nav.isStopped = false;
        }

        private void LookForPlayer()
        {
            TestSense(player.position, currentVision);
        }
        private void LookForMushroom()
        {
            TestSense(mushroom.position, currentVision);
        }
        private void LookForCactus()
        {
            TestSense(cactus.position, currentVision);
        }

        private void HearPoint(Vector3 position)
        {
            TestSense(position, hearingRange);
        }

        private void TestSense(Vector3 position, float senseRange)
        {
            if (Vector3.Distance(this.transform.position, position) <= senseRange)
            {
                GoToPosition(position);
            }
        }

        public void GoToPlayer()
        {
            GoToPosition(player.position);
        }
        public void GoToMushroom()
        {
            GoToPosition(mushroom.position);
        }
        public void GoToCactus()
        {
            GoToPosition(cactus.position);
        }

        private void GoToPosition(Vector3 position)
        {
            timer = -1f;
            if (!petHealth.IsDead())
             {
                SetDestination(position);
             }
        }

        private void SetDestination(Vector3 position)
        {
            if (nav.isOnNavMesh)
            {
                nav.SetDestination(position);
            }
        }

        private void WanderOrIdle()
        {
            if (!nav.hasPath)
            {
                if (timer <= 0f)
                {
                    SetDestination(GetRandomPoint(wanderDistance, 5));
                    if (nav.pathStatus == NavMeshPathStatus.PathInvalid)
                    {
                        ClearPath();
                    }
                    timer = Random.Range(idleTimeRange.x, idleTimeRange.y);
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
        }

        private void IsPsychic()
        {
            GoToPlayer();
            if (mushroom != null)
            {
            GoToMushroom();

            }
            else if (cactus != null)
            {

            GoToCactus();
            }
        }

        private Vector3 GetRandomPoint(float distance, int layermask)
        {
            Vector3 randomPoint = UnityEngine.Random.insideUnitSphere * distance + this.transform.position;;

            NavMeshHit navHit;
            NavMesh.SamplePosition(randomPoint, out navHit, distance, layermask);

            return navHit.position;
        }

        public void ScaleVision(float scale)
        {
            currentVision = visionRange * scale;
        }

        private int GetCurrentNavArea()
        {
            NavMeshHit navHit;
            nav.SamplePathPosition(-1, 0.0f, out navHit);

            return navHit.mask;
        }

        //void OnDrawGizmos()
        //{
        //    Vector3 position = this.transform.position;
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawWireSphere(position, currentVision);
        //    Gizmos.color = Color.yellow;
        //    Gizmos.DrawWireSphere(position, hearingRange);
        //}
    }
}