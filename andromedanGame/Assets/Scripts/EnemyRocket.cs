using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    public float speed = 5f;
    public float despawnTime = 8f;
    public float distance = 7f;
    public float radius = 2f;
    public int damage = 2;
    public LayerMask mask;
    public GameObject explosionPrefab;
    private Vector3 startPosition;
    private bool exploded;

    private void OnEnable()
    {
        exploded = false;
        startPosition = transform.position;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

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
        if (exploded)
        {
            return;
        }

        transform.Translate(Vector3.down * speed * Time.deltaTime);
        float distanceTraveled = Vector3.Distance(startPosition, transform.position);

        if (distanceTraveled >= distance)
        {
            Explode();
        }

        //Debug.Log(gameObject.name + " moving");
    }

    void Explode()
    {
        if (exploded)
        {
            return;
        }

        exploded = true;

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius, mask);

        foreach (Collider2D hit in hits)
        {
            PlayerHealth health = hit.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
        gameObject.SetActive(false);
    }

    /*
    private void OnBecameInvisible()
    {
        gameObject.SetActive(true);
    }
    */
}
