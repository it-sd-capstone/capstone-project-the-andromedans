using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemies = new GameObject[4];
    public Transform[] spawnpoints;
    public float spawnDelay = 0.5f;
    public float waveDelay = 3f;
    public int enemyNum = 3;

    private int currentWave = 0;
    private List<GameObject> activeEnemies = new List<GameObject>();
    public Transform player;
    public ObjectPool targetLockPool;
    public ObjectPool bulletPool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaveLoop());
    }

    IEnumerator WaveLoop()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            currentWave++;
            int enemyCount = enemyNum + currentWave;
            yield return StartCoroutine(SpawnWave(enemyCount));

            yield return new WaitForSeconds(waveDelay);
        }
    }

    IEnumerator SpawnWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemy()
    {
        Transform spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
        int currentEnemyUnlock = Mathf.Clamp(currentWave / 2, 0, enemies.Length - 1);
        int randomEnemyType = Random.Range(0, currentEnemyUnlock + 1);
        
        GameObject enemy = Instantiate(enemies[randomEnemyType], spawnpoint.position, Quaternion.identity);

        EnemyType enemyTypeHolder = enemy.GetComponent<EnemyType>();

        if (enemyTypeHolder.enemyType == EnemyType.EnemyTypeSelect.Projectile)
        {
            ProjectileEnemyFirePattern projectileEnemyFirePattern = enemy.GetComponent<ProjectileEnemyFirePattern>();
            if (projectileEnemyFirePattern != null)
            {
                projectileEnemyFirePattern.Init(bulletPool);
            }
            
        }

        else if (enemyTypeHolder.enemyType == EnemyType.EnemyTypeSelect.TargetLock)
        {
            TargetLockEnemyFirePattern targetLockEnemyFirePattern = enemy.GetComponent<TargetLockEnemyFirePattern>();
            targetLockEnemyFirePattern.player = player;
            targetLockEnemyFirePattern.pool = targetLockPool;
        }
        else if (enemyTypeHolder.enemyType == EnemyType.EnemyTypeSelect.Shotgun)
        {
            ShotgunEnemyFirePattern shotgunEnemyFirePattern = enemy.GetComponent<ShotgunEnemyFirePattern>();
            shotgunEnemyFirePattern.pool = bulletPool;

            ShotgunEnemyMovement shotgunEnemyMovement = enemy.GetComponent<ShotgunEnemyMovement>();
            shotgunEnemyMovement.player = player;
        }

        activeEnemies.Add(enemy);
        enemy.GetComponent<EnemyKill>().Init(this);
    }


    public void EnemyDeath(GameObject enemy)
    {
        activeEnemies.Remove(enemy);
    }

}
