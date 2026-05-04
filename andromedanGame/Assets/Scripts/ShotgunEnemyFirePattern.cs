using UnityEngine;

public class ShotgunEnemyFirePattern : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float fireRate = 1f;
    public float speed = 5f;
    public float spread = 25f;
    public int numProjectile = 3;
    public ObjectPool pool;
    private float fireTimer;

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >=  fireRate)
        {
            FireShotgun();
            fireTimer = 0f;
        }
    }

    void FireShotgun()
    {
        float startAngle = -spread / 2f;
        float nextAngle = spread / (numProjectile - 1);

        for (int i = 0; i < numProjectile; i++)
        {
            float angle = startAngle + (nextAngle * i);
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            GameObject currentProjectile = pool.GetObject();
            currentProjectile.transform.position = firePoint.position;
            currentProjectile.transform.rotation = rotation;

            Rigidbody2D rb = currentProjectile.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.linearVelocity = Vector2.down * speed;
            //Debug.Log("Velocity " + rb.linearVelocity);
            currentProjectile.SetActive(true);
        }
    }
}
