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
        PetManager petManager;

        ShopManager shopManager;

        public event Action OnDeath;
        public event Action<Vector3> OnNoise;
        public bool godMode = false;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            petManager = FindObjectOfType<PetManager>();
            shopManager = FindObjectOfType<ShopManager>();
        }
        void OnEnable()
        {
            currentHealth = startingHealth;
        }

        public void TakeDamage(int amount)
        {
            if (godMode)
            {
                return;
            }
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
            petManager.isMushroom = false;
            MainManager.Instance.isMushroom = false;
            // shopManager.CheckPurchaseable();
        }
    }
}