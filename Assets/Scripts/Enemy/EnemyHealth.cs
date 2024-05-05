    using UnityEngine;

    namespace Nightmare
    {
        public class EnemyHealth : MonoBehaviour
        {
            public int startingHealth = 100;
            public float sinkSpeed = 2.5f;
            public int scoreValue = 10;
            public AudioClip deathClip;
            public GameObject powerUpOrb;

            int currentHealth;
            Animator anim;
            AudioSource enemyAudio;
            ParticleSystem hitParticles;
            CapsuleCollider capsuleCollider;
            EnemyMovement enemyMovement;

            EnemyManager enemyManager;

            PowerUp powerUp;


            void Awake ()
            {
                anim = GetComponent <Animator> ();
                enemyAudio = GetComponent <AudioSource> ();
                hitParticles = GetComponentInChildren <ParticleSystem> ();
                capsuleCollider = GetComponent <CapsuleCollider> ();
                enemyMovement = this.GetComponent<EnemyMovement>();
                powerUp = GetComponent<PowerUp>();

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
                    transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
                    if (transform.position.y < -10f)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }

            public bool IsDead()
            {
                return (currentHealth <= 0f);
            }

            public void TakeDamage (int amount, Vector3 hitPoint)
            {
                if (!IsDead())
                {
                    enemyAudio.Play();
                    currentHealth -= amount;

                    if (IsDead())
                    {
                        Death();
                    }
                    else
                    {
                        enemyMovement.GoToPlayer();
                    }
                }
                    
                hitParticles.transform.position = hitPoint;
                hitParticles.Play();
            }

            void Death ()
            {
                EventManager.TriggerEvent("Sound", this.transform.position);
                anim.SetTrigger ("Dead");

                enemyAudio.clip = deathClip;
                enemyAudio.Play ();
                // if (Random.value < 0.5f)
                // {
                //     GameObject orb = Instantiate(powerUpOrb, transform.position, Quaternion.identity);
                //     Debug.Log("Orb created");
                    
                // }
                // if(powerUpOrb != null)
                // {
                //     GameObject orb = Instantiate(powerUpOrb, transform.position, Quaternion.identity);
                //     Debug.Log("Orb created");

                // }else{
                //     Debug.Log("Orb is null");
                
                // }
                // GameObject orb = Instantiate(powerUpOrb, transform.position, Quaternion.identity);
                // Debug.Log("Orb created");
                SpawnOrbs spawnOrbs = FindObjectOfType<SpawnOrbs>();

                // Call the SpawnOrb method
                spawnOrbs.SpawnOrb(transform.position);

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