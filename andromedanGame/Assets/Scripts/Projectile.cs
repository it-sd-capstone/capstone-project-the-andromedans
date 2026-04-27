using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 12f;
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
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    /*
    private void OnBecameInvisible()
    {
        gameObject.SetActive(true);
    }
    */
}
