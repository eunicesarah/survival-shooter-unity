using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nightmare;

public class PowerUp : MonoBehaviour
{
    public GameObject player;

    public PlayerHealth playerHealth;

    public float healthIncreasePercentage = 0.2f; 
    public GameObject pickupEffect;
    public void StartDestroyTimer(float delay)
        {
            StartCoroutine(DestroyAfterDelay(delay));
        }
    private GameObject activeOrb;
    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        StartCoroutine(DestroyAfterDelay(5f));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
            // StopCoroutine(DestroyAfterDelay(5f)); 
            // Destroy(gameObject);
            
        }
    }

    void Pickup(Collider player)
    {
        int healthToAdd = (int)(playerHealth.startingHealth * healthIncreasePercentage);
        playerHealth.currentHealth = Mathf.Min(playerHealth.currentHealth + healthToAdd, playerHealth.startingHealth);
        playerHealth.healthSlider.value = playerHealth.currentHealth;

        Debug.Log("Picked up power up health");
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}