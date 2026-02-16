using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject baseEnemy;
    public Transform[] waypoints;
    public int waveNumber;
    private float difficultyMultiplier;
    private int enemiesPerWave;
    private int spawnDelay;
    private int spawnTimer;
    private int enemiesSpawned;

    void Start()
    {
        enemiesSpawned = 0;
        spawnTimer = 0;
        spawnDelay = 10 * 60; // 5 seconds at 60 FPS
        difficultyMultiplier = 1.0f; // Initial difficulty multiplier
        enemiesPerWave = Mathf.RoundToInt(5 * difficultyMultiplier); // Initial enemies per wave
    }

    void Update()
    {
        spawnTimer++;
        if (spawnTimer >= spawnDelay && enemiesSpawned < enemiesPerWave) // Adds a delay to enemy spawning and only spawns set amount
        {
            SpawnEnemy();
            spawnTimer = 0;
            enemiesSpawned++;
        }
    }

    // Spawns an enemy and sets its patrol points to the waypoints defined in the inspector
    private void SpawnEnemy()
    {
        GameObject enemyObj = Instantiate(baseEnemy, transform.position, Quaternion.identity);
        BaseEnemy enemy = enemyObj.GetComponent<BaseEnemy>();
        enemy.patrolPoints = waypoints;
    }
}
