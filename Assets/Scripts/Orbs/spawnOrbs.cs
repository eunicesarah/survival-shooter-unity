using UnityEngine;

public class SpawnOrbs : MonoBehaviour
{
    public GameObject speedUpOrb;
    public GameObject damageUpOrb;
    public GameObject healthUpOrb;

    public void SpawnOrb(Vector3 position)
    {
        // Randomly select an orb
        int randomOrb = Random.Range(0, 3);
        GameObject orbToSpawn;

        switch (randomOrb)
        {
            case 0:
                orbToSpawn = speedUpOrb;
                break;
            case 1:
                orbToSpawn = damageUpOrb;
                break;
            case 2:
                orbToSpawn = healthUpOrb;
                break;
            default:
                orbToSpawn = healthUpOrb;
                break;
        }

        // Instantiate the orb at the given position
        Instantiate(orbToSpawn, position, Quaternion.identity);
    }

    public void SpawnAllOrbs(Transform playerTransform)
    {
         float distance = 2.0f;
        float yOffset = 0.0f; 
        float xOffset = 1.0f;  

        Vector3 forwardDirection = playerTransform.forward;
        Vector3 rightDirection = playerTransform.right;
        Vector3 playerPosition = playerTransform.position;

        Instantiate(speedUpOrb, playerPosition + forwardDirection * distance + rightDirection * -xOffset + new Vector3(0f, yOffset, 0f), Quaternion.identity);
        Instantiate(damageUpOrb, playerPosition + forwardDirection * distance + new Vector3(0f, yOffset, 0f), Quaternion.identity);
        Instantiate(healthUpOrb, playerPosition + forwardDirection * distance + rightDirection * xOffset + new Vector3(0f, yOffset, 0f), Quaternion.identity);
    }
}