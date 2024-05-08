using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nightmare
{
    public class PetJendralHealth : MonoBehaviour
    {
        public int startingHealth = 100;
        public float sinkSpeed = 2.5f;
        public int scoreValue = 10;
        public AudioClip deathClip;

        public int currentHealth;
        Transform jendral;

        Animator anim;
        AudioSource enemyAudio;
        ParticleSystem hitParticles;
        CapsuleCollider capsuleCollider;
        PetJendralMovement enemyMovement;
        EnemyHealth enemyHealth;


        void Awake ()
        {
            jendral = GameObject.FindGameObjectWithTag ("Jendral").transform;
            enemyHealth = jendral.GetComponent <EnemyHealth> ();
            anim = GetComponent <Animator> ();
            enemyAudio = GetComponent <AudioSource> ();
            hitParticles = GetComponentInChildren <ParticleSystem> ();
            capsuleCollider = GetComponent <CapsuleCollider> ();
            enemyMovement = this.GetComponent<PetJendralMovement>();
        }

        void OnEnable()
        {
            currentHealth = startingHealth;
            SetKinematics(false);
        }

        private void SetKinematics(bool isKinematic)
        {
            capsuleCollider.isTrigger = isKinematic;
            capsuleCollider.attachedRigidbody.isKinematic = isKinematic;
        }

        void Update ()
        {
            if (IsDead())
            {
                // transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
                // if (transform.position.y < -10f)
                // {
                //     Destroy(this.gameObject);
                // }
                Debug.Log("PetJendral is dead");
                Destroy(this.gameObject);

            }
        }

        public bool IsDead()
        {
            return ((currentHealth <= 0f) || (enemyHealth.CurrentHealth() <= 0));

        }

        public void TakeDamage (int amount, Vector3 hitPoint)
        {
            if (!IsDead())
            {
                enemyAudio.Play();
                currentHealth -= amount;

                if (IsDead())
                {
                Debug.Log("PetJendral is dead");

                    Death();
                }
                else
                {
                    // enemyMovement.GoToPlayer();
                }
            }
                
            hitParticles.transform.position = hitPoint;
            hitParticles.Play();
        }

        public void SwordDamage(int amount)
        {
            if (!IsDead())
            {
                enemyAudio.Play();

                if (currentHealth < amount)
                {
                    currentHealth = 0;
                }
                else
                {
                    currentHealth -= amount;
                }
                

                if (IsDead())
                {
                    Death();
                }
                else
                {
                    // enemyMovement.GoToPlayer();
                }
            }
        }

        void Death ()

        {
            EventManager.TriggerEvent("Sound", this.transform.position);
            // anim.SetTrigger ("Dead");
            Debug.Log("PetJendral is dead");
            enemyAudio.clip = deathClip;
            enemyAudio.Play ();

            
            SpawnOrbs spawnOrbs = FindObjectOfType<SpawnOrbs>();

                // Call the SpawnOrb method
            if(Random.Range(0, 10) < 4)
            {
                spawnOrbs.SpawnOrb(transform.position);

            }
        }

        public void StartSinking ()
        {
            GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
            SetKinematics(true);

            ScoreManager.score += scoreValue;
        }

        public int CurrentHealth()
        {
            return currentHealth;
        }
    }
}