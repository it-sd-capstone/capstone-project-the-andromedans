using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemyFirePattern : MonoBehaviour
{
    public ObjectPool projectilePool;
    // For other team members: add empty game object as child
    // to determine where the beam will fire from
    [SerializeField]
    public Transform launchpoint;
    public float speed = 4.5f;
    public float delay = 1f;

    private void Start()
    {
        Invoke(nameof(Fire), delay);
    }

    void Fire()
    {
        GameObject projectile = projectilePool.GetObject();
        projectile.transform.position = launchpoint.position;
        projectile.transform.rotation = Quaternion.identity;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null )
        {
            rb.linearVelocity = Vector2.down * speed;
        }
    }
}
