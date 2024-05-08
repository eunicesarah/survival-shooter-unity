using System;
using UnityEngine;

public class CactusHealth : MonoBehaviour
{
    public int startingHealth = 40;
    public int currentHealth;

    public event Action OnDeath;
    public event Action<Vector3> OnNoise;

    void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (IsDead())
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
