using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeSpawn = 5f;
    private float countdown = 2f;

    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnEnemy();
            countdown = timeSpawn;
        }
        countdown -= Time.deltaTime;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
