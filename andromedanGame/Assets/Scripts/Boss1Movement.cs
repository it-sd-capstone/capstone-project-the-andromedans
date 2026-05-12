using UnityEngine;

public class Boss1Movement : MonoBehaviour
{
    public float xSpeed = 3f;
    public float xRange = 6f;

    public float ySpeed = 1.5f;
    public float yRange = 1.5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * xSpeed) * xRange;
        float y = Mathf.Sin(Time.time * ySpeed) * yRange;

        transform.position = startPos + new Vector3(x, y, 0f);
    }
}
