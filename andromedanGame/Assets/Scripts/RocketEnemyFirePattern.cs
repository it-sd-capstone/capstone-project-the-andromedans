using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEnemyFirePattern : MonoBehaviour
{
    public ObjectPool projectilePool;
    // For other team members: add empty game object as child
    // to determine where the beam will fire from
    [SerializeField]
    public Transform launchpoint;
    public float speed = 3f;
    public float delay = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(Fire), delay, delay);
    }

    void Fire()
    {
        //Debug.Log("Fired");
        GameObject projectile = projectilePool.GetObject();
        projectile.SetActive(false);
        projectile.transform.position = launchpoint.position;
        projectile.transform.rotation = Quaternion.identity;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        //Debug.Log("Rocket Fire");

        /*if (rb != null )
        {
            rb.linearVelocity = Vector2.down * speed;
        }*/

        projectile.SetActive(true);
    }

    public void Init(ObjectPool pool)
    {
        projectilePool = pool;
    }
}
