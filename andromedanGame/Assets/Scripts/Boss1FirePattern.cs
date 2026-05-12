using System.Collections;
using UnityEngine;

public class Boss1FirePattern : MonoBehaviour
{
    public Transform shotgunPoint;
    public Transform homingPoint;
    public Transform player;

    public ObjectPool shotgunPool;
    public ObjectPool homingPool;

    public float shotgunSpeed = 6f;
    public float shotgunSpread = 40f;
    public int shotgunProjectiles = 3;
    public float homingSpeed = 7f;

    private void Start()
    {
        StartCoroutine(AttackLoop());
    }

    IEnumerator AttackLoop()
    {
        while (true)
        {
            // Shotgun Phase
            for (int i = 0; i < 3; i++)
            {
                FireShotgun();
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(1f);

            // Homing phase
            for (int i = 0; i < 2; i++)
            {
                FireHoming();
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(1.5f);
        }
    }

    void FireShotgun()
    {
        float startAngle = -shotgunSpread / 2f;
        float angleStep = shotgunSpread / (shotgunProjectiles - 1);

        for(int i = 0; i < shotgunProjectiles; i++)
        {
            float angle = startAngle + (angleStep * i);

            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            GameObject projectile = shotgunPool.GetObject();

            projectile.transform.position = shotgunPoint.position;
            projectile.transform.rotation = rotation;

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.zero;
            Vector2 direction = rotation * Vector2.down;
            rb.linearVelocity = direction * shotgunSpeed;;

            projectile.SetActive(true);
        }
    }

    void FireHoming()
    {
        if (player == null) return;

        GameObject projectile = homingPool.GetObject();
        projectile.transform.position = homingPoint.position;
        Vector2 direction = ((Vector2)player.position - 
                            (Vector2)homingPoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * homingSpeed;

        projectile.SetActive(true);
    }
}
