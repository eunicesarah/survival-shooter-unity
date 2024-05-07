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
    private float remainingDuration = 0f;
    public void StartDestroyTimer(float delay)
        {
            StartCoroutine(DestroyAfterDelay(delay));
        }
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        baseSpeed = playerMovement.speed; // Store the base speed
        StartDestroyTimer(5f); // Start the destroy timer
    }


    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            Pickup(other);
        }
    }

    void Pickup(Collider playerCollider)
    {
        if (activePowerUp != null)
        {
            // Update remaining duration and reset speed
            remainingDuration += powerUpDuration;
            playerMovement.speed = baseSpeed * (1 + speedIncreasePercentage);
        }
        else
        {
            activePowerUp = StartCoroutine(PowerUpTimer());
            playerMovement.speed = baseSpeed * (1 + speedIncreasePercentage);
        }

        Debug.Log("Picked up speed power up");
        Destroy(gameObject);
    }

    IEnumerator PowerUpTimer()
    {
        Debug.Log("Power up started. Initial speed: " + playerMovement.speed);

        // Countdown
        while (remainingDuration > 0)
        {
            Debug.Log("Power up ends in: " + remainingDuration + " seconds");
            yield return new WaitForSeconds(1);
            remainingDuration--;
        }

        playerMovement.speed = baseSpeed; // Reset speed to base speed

        Debug.Log("Power up ended. Speed reset to: " + playerMovement.speed);

        activePowerUp = null;
    }
}