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
        /*if (player == null)
        {
            return;
        }*/

        GameObject projectile = pool.GetObject();
        projectile.transform.position = launchpoint.position;
        projectile.transform.rotation = Quaternion.identity;
        Vector2 direction = ((Vector2)player.position - (Vector2)launchpoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        
        projectile.SetActive(true);

        if (rb != null)
        {
            rb.linearVelocity = direction * speed;
        }

        
    }
}
