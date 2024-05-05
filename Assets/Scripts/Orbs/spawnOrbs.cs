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
}