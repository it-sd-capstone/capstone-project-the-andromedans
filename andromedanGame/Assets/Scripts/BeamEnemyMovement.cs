using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeamEnemyMovement : MonoBehaviour
{
    [SerializeField] 
    public float verticalSpeed = 3f;
    [SerializeField]
    public float horizontalSpeed = 2f;
    [SerializeField]
    public float targetY = 3f;
    [SerializeField]
    public float maxLeft = -5f;
    [SerializeField]
    public float maxRight = 5f;
    private bool entered = false;
    private int direction = 1;

    private void Update()
    {
        if (!entered)
        {
            MoveInFrame();
        }
        else
        {
            MoveSideways();
        }
    }

    private void MoveInFrame()
    {
        if (transform.position.y > targetY)
        {
            transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
        }
        else
        {
            entered = true;
        }
    }

    private void MoveSideways()
    {
        transform.position += Vector3.right * direction * horizontalSpeed * Time.deltaTime;

        if (transform.position.x >= maxRight)
        {
            direction = -1;
        }
        else if (transform.position.x <= maxLeft)
        {
            direction = 1;
        }
    }
}
