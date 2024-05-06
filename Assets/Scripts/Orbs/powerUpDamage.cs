using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nightmare;

public class powerUpDamage : MonoBehaviour
{
    public GameObject player;
    public PlayerShooting playerShooting;
    public float damageIncreasePercentage = 0.1f; 
    public GameObject pickupEffect;

    private int maxOrbs = 15;
    private int currentOrbs = 0;
    public void StartDestroyTimer(float delay)
        {
            StartCoroutine(DestroyAfterDelay(delay));
        }
   void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerShooting = FindObjectOfType<PlayerShooting>();
        StartCoroutine(DestroyAfterDelay(5f)); // Start the destroy timer
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
            Debug.Log("Player collided with damage power up");
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        if (currentOrbs < maxOrbs)
        {
            currentOrbs++;
            playerShooting.damagePerShot = (int)(playerShooting.damagePerShot * (1 + damageIncreasePercentage));
            Debug.Log("Picked up damage power up");
            Destroy(gameObject); // Destroy the orb when picked up
        }
    }
}