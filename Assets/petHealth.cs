using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Nightmare{
    public class PetHealth : MonoBehaviour
{   
    GameObject player;
    Transform jendral;
    EnemyHealth enemyHealth;
    public float sinkSpeed = 2.5f;

    public int startingHealth = 100;
    int currentHealth;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    Animator anim;




    // Start is called before the first frame update
    void Awake()
    {
        jendral = GameObject.FindGameObjectWithTag ("Jendral").transform;
        enemyHealth = jendral.GetComponent <EnemyHealth> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

    }
    void Start()
    {
        
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
    // Update is called once per frame
    void Update()
    {
        if (IsDead())
        {
            Destroy(this.gameObject);

            // transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
            //     if (transform.position.y < -10f)
            //     {
            //         Destroy(this.gameObject);
            //     }
        }
    }
    public void TakeDamage (int amount, Vector3 hitPoint)
        {
            if (!IsDead())
            {
                // enemyAudio.Play();
                currentHealth -= amount;

                // if (IsDead())
                // {
                //     Death();
                // }
                // else
                // {
                //     enemyMovement.GoToPlayer();
                // }
            }
                
            // hitParticles.transform.position = hitPoint;
            // hitParticles.Play();
        }

    public bool IsDead(){
        return ((currentHealth <= 0f) || (enemyHealth.CurrentHealth() <= 0));
    }
}
}
