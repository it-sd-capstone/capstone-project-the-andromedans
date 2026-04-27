using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float despawnTime = 5.5f;

    private void OnEnable()
    {
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

    private void OnBecameInvisible()
    {
        gameObject.SetActive(true);
    }
}
