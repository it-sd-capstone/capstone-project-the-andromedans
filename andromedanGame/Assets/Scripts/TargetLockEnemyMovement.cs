using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLockEnemyMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 2f;
    [SerializeField]
    public float frequency = 2f;
    [SerializeField]
    public float amplitude = 2f;
    private float startX;

    private void Start()
    {
        startX = transform.position.x;
    }

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        
        float newX = startX + Mathf.Sin(Time.time * frequency) * amplitude;

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
