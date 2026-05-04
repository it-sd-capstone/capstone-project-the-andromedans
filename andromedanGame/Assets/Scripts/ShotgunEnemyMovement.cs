using UnityEngine;
using System.Collections.Generic;

public class ShotgunEnemyMovement : MonoBehaviour
{
    public Transform player;
    public float delay = 0.8f;
    public float movementSpeed = 5f;

    private Queue<PositionSample> playerPosition = new Queue<PositionSample> ();
    private struct PositionSample {
        public float time;
        public float x;
        public PositionSample(float t, float xPos)
        {
            time = t;
            x = xPos;
        }
    
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        playerPosition.Enqueue(new PositionSample(Time.time, player.position.x));

        while (playerPosition.Count > 0 && Time.time - playerPosition.Peek().time > delay)
        {
            PositionSample targetSample = playerPosition.Dequeue();

            Vector3 targetPosition = new Vector3(targetSample.x, transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        }
    }


}
