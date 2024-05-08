using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nightmare;
using System;

public class powerUpSpeed : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float speedIncreasePercentage = 0.2f;
    public GameObject pickupEffect;


    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        // baseSpeed = playerMovement.speed; // Store the base speed
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
    void Pickup(Collider playerCollider)
    {
        playerMovement.ActivatePowerUp();

        Debug.Log("Picked up speed power up");
        Destroy(gameObject);
    }

}
