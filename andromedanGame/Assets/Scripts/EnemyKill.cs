using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    private WaveSpawner spawner;

    public void Init(WaveSpawner waveSpawner)
    {
        spawner = waveSpawner;
    }

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.EnemyDeath(gameObject);
        }
    }
}
