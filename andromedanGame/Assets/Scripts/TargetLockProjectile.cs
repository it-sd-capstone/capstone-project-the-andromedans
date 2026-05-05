using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLockProjectile : MonoBehaviour
{
    public float speed = 8f;
    public float despawnTime = 5.5f;

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
        //transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit");

            // Damage the enemy
            other.GetComponent<PlayerHealth>()?.TakeDamage(1);

            // Disable projectile
            gameObject.SetActive(false);
        }
    }

    /*
    private void OnBecameInvisible()
    {
        gameObject.SetActive(true);
    }
    */
}
