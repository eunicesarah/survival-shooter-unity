using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nightmare;

public class powerUpSpeed : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playerMovement;
    public float speedIncreasePercentage = 0.2f; 
    public float powerUpDuration = 15f;
    public GameObject pickupEffect;

    private Coroutine activePowerUp = null;
    private float baseSpeed;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        baseSpeed = playerMovement.speed; // Store the base speed
        // StartCoroutine(DestroyAfterDelay(5f)); // Start the destroy timer
    }

    // IEnumerator DestroyAfterDelay(float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     if (gameObject != null)
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            Debug.Log("Player collided with speed power up");
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        if (activePowerUp != null)
        {
            StopCoroutine(activePowerUp);
            playerMovement.speed = baseSpeed; // Reset speed to base speed
        }
        activePowerUp = StartCoroutine(PowerUpTimer());

        Debug.Log("Picked up speed power up");
        Destroy(gameObject); // Destroy the orb when picked up
    }

    // IEnumerator PowerUpTimer()
    // {
    //     Debug.Log("Power up started. Initial speed: " + playerMovement.speed);

    //     playerMovement.speed *= (1 + speedIncreasePercentage);

    //     Debug.Log("Speed increased to: " + playerMovement.speed);

    //     yield return new WaitForSeconds(powerUpDuration);
     

    //     playerMovement.speed = baseSpeed; // Reset speed to base speed

    //     Debug.Log("Power up ended. Speed reset to: " + playerMovement.speed);

    //     activePowerUp = null;
    // }
    IEnumerator PowerUpTimer()
    {
        Debug.Log("Power up started. Initial speed: " + playerMovement.speed);

        playerMovement.speed *= (1 + speedIncreasePercentage);

        Debug.Log("Speed increased to: " + playerMovement.speed);

        // Countdown
        for (float i = powerUpDuration; i > 0; i--)
        {
            Debug.Log("Power up ends in: " + i + " seconds");
            yield return new WaitForSeconds(1);
        }

        playerMovement.speed = baseSpeed; // Reset speed to base speed

        Debug.Log("Power up ended. Speed reset to: " + playerMovement.speed);

        activePowerUp = null;
    }
}