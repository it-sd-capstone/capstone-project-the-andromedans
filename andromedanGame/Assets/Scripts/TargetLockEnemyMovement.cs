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
    public float verticalSpeed = 3f;
    private bool entered = false;
    [SerializeField]
    public float targetY = 3f;
    private float sineTimer;
    private Vector3 startPosition;
    //private float direction = 1f;

    /*private void Start()
    {
        startPosition = transform.position;
    }*/

    private void Update()
    {
        if (!entered)
        {
            MoveInFrame();
        }
        else
        {
            sineTimer += Time.deltaTime;
            float horizontalOffset = Mathf.PingPong(sineTimer * speed, distance * 2) * distance;
            float verticalOffset = Mathf.Sin(sineTimer * frequency) * amplitude;
            transform.position = startPosition + new Vector3(horizontalOffset, verticalOffset, 0f);
        }
        
    }

    private void MoveInFrame()
    {
        float newY = transform.position.y - verticalSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        if (newY <= targetY)
        {
            newY = targetY;
            entered = true;
            startPosition = new Vector3(transform.position.x, targetY, transform.position.z);
            sineTimer = 0f;

        }
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
