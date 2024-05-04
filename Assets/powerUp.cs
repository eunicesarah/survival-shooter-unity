using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nightmare;

public class powerUp : MonoBehaviour
{
    public GameObject player;

    public PlayerHealth playerHealth;

    public float healthIncreasePercentage = 0.2f; 
    public GameObject pickupEffect;

    void Awake ()
    {

        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
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
}