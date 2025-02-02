using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;
    public int maxZombies = 20;
    private int currentZombieCount = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnZombie), 0f, spawnInterval);
    }

    void SpawnZombie()
    {
        if (currentZombieCount >= maxZombies) return;

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(zombiePrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        currentZombieCount++;
    }

    public void ZombieKilled()
    {
        currentZombieCount--;
    }
}
