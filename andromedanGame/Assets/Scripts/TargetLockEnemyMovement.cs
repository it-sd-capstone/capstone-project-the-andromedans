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
    public float amplitude = 1f;
    [SerializeField]
    public float distance = 5f;

    private Vector3 startPosition;
    private float direction = 1f;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float horizontalOffset = Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        float verticalOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPosition + new Vector3(horizontalOffset, verticalOffset, 0f);
    }
}
