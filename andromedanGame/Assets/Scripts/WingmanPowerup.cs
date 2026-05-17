using UnityEngine;

public class WingmanPowerup : MonoBehaviour
{
    public GameObject wingmanToSpawn;
    public float speed = 3f;
    public float lifespan = 10f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        lifespan -= Time.deltaTime;

        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!wingmanToSpawn.activeSelf)
            {
                wingmanToSpawn.SetActive(true);
            }
            
            Destroy(gameObject);
        }
    }
}
