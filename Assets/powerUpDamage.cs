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

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerShooting = player.GetComponent <PlayerShooting> ();
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
        if (currentOrbs < maxOrbs)
        {
            currentOrbs++;
            playerShooting.damagePerShot = (int)(playerShooting.damagePerShot * (1 + damageIncreasePercentage));
            Debug.Log("Picked up damage power up");
            Destroy(gameObject);
        }
    }
}