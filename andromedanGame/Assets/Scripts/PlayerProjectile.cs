using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 12f;
    public float despawnTime = 5.5f;
    public GameObject hitEffectPrefab;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke(nameof(Disable), despawnTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        //Debug.Log(gameObject.name + " moving");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");

            // Damage the enemy
            other.GetComponent<EnemyHealth>()?.TakeDamage(1);

            SpawnHitEffect(transform.position);

            // Disable projectile
            gameObject.SetActive(false);
        }
    }

    private void SpawnHitEffect(Vector3 position)
    {
        if (hitEffectPrefab != null)
        {
            Instantiate(hitEffectPrefab, position, Quaternion.identity);
        }
    }

    /*
    private void OnBecameInvisible()
    {
        gameObject.SetActive(true);
    }
    */
}
