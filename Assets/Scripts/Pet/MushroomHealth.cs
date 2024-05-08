using System;
using UnityEngine;

namespace Nightmare
{

    public class MushroomHealth : MonoBehaviour
    {
        public int startingHealth = 40;
        public int currentHealth;
        GameObject player;
        PlayerHealth playerHealth;

        public event Action OnDeath;
        public event Action<Vector3> OnNoise;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
        }
        void OnEnable()
        {
            currentHealth = startingHealth;
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            if (IsDead() || playerHealth.currentHealth <= 0)
            {
                Die();
            }
        }

        public bool IsDead()
        {
            return (currentHealth <= 0);
        }

        void Die()
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}