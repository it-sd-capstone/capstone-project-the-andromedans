using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLockEnemyFirePattern : MonoBehaviour
{
    public ObjectPool pool;
    public Transform launchpoint;
    public float speed = 5f;
    public float rate = 1f;
    public Transform player;

    private void Start()
    {
        InvokeRepeating(nameof(TargetLockFire), rate, rate);
    }

    private void TargetLockFire()
    {
        if (player == null)
        {
            return;
        }

        GameObject projectile = pool.GetObject();
        projectile.transform.position = launchpoint.position;
        projectile.transform.rotation = Quaternion.identity;
        Vector2 direction = (player.position - launchpoint.position).normalized;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = direction * speed;
        }
    }
}
