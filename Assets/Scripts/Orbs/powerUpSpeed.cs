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

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerMovement = player.GetComponent <PlayerMovement> ();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {

        if (activePowerUp != null)
        {
            StopCoroutine(activePowerUp);
        }
        activePowerUp = StartCoroutine(PowerUpTimer());

        Debug.Log("Picked up speed power up");
        Destroy(gameObject);
    }

   IEnumerator PowerUpTimer()
{
    Debug.Log("Power up started. Initial speed: " + playerMovement.speed);

    playerMovement.speed *= (1 + speedIncreasePercentage);

    Debug.Log("Speed increased to: " + playerMovement.speed);

    yield return new WaitForSeconds(powerUpDuration);

    playerMovement.speed /= (1 + speedIncreasePercentage);

    Debug.Log("Power up ended. Speed reset to: " + playerMovement.speed);

    activePowerUp = null;
}
}