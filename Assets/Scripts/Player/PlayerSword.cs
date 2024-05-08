using Nightmare;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : PausibleObject
{
    public float attackCoolDown = 0.5f;
    public int attackDamage = 100;
    public float swordThreshold = 3f;
    float angleThreshold = 90f;

    Animator animator;
    AudioSource ac;
    WeaponManager weaponManager;
    List<GameObject> enemies = new List<GameObject>(); // List to store all enemies
    List<EnemyHealth> enemyHealths = new List<EnemyHealth>(); // List to store all enemy health scripts
    List<bool> playerInRange = new List<bool>(); // List to store player's proximity to each enemy

    int weapon = 2;
    bool canAttack = true;
    float angle;
    Vector3 directionToEnemy;
    float distanceToEnemy;

    private void Awake()
    {
        weaponManager = FindObjectOfType<WeaponManager>();
        animator = GetComponent<Animator>();
        ac = GetComponent<AudioSource>();

        StartPausible();
    }

    void OnDestroy()
    {
        StopPausible();
    }

    void Update()
    {
        if (isPaused)
            return;

        // Find all enemies with the "Enemy" tag
        GameObject[] foundEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemies.Clear();
        playerInRange.Clear();
        enemyHealths.Clear();

        foreach (GameObject enemy in foundEnemies)
        {
            directionToEnemy = enemy.transform.position - transform.position;
            angle = Vector3.Angle(transform.forward, directionToEnemy);
            if (angle <= angleThreshold)
            {
                distanceToEnemy = Vector3.Distance(enemy.transform.position, transform.position);
                if (distanceToEnemy < swordThreshold)
                {
                    enemies.Add(enemy);
                    playerInRange.Add(Vector3.Distance(enemy.transform.position, transform.position) < swordThreshold);
                    enemyHealths.Add(enemy.GetComponent<EnemyHealth>());
                }
            }          
        }

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (canAttack && weapon == weaponManager.selectedWeapon)
        {
            if (Input.GetButton("Fire1"))
            {
                SwordAttack();
            }
        }
    }

    public void SwordAttack()
    {
        canAttack = false;
        animator.SetTrigger("Attack");
        ac.Play();
        Debug.Log("SwordAttack");

        // Loop through all enemies
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemyHealths[i] != null && playerInRange[i])
            {
                // Damage the enemy
                enemyHealths[i].SwordDamage(attackDamage);
                Debug.Log("Kill " + enemyHealths[i].currentHealth);
            }
        }

        StartCoroutine(ResetAttackCoolDown());
    }

    IEnumerator ResetAttackCoolDown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCoolDown);
        canAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(attackCoolDown);
    }
}
