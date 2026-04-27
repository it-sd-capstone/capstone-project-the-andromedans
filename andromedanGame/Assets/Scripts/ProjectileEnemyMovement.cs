using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public float targetY = 4f;

    private void Update()
    {
        if (transform.position.y > targetY)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}
