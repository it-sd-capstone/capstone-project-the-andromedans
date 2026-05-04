using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed = 2f;
    public Transform bg1;
    public Transform bg2;

    private float height;

    void Start()
    {
      height = bg1.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
      Vector3 move = Vector3. down * speed * Time.deltaTime;

      bg1.position += move;
      bg2.position += move;

      if (bg1.position.y <= -height)
      {
        bg1.position = new Vector3(bg1.position.x, bg2.position.y + height, 0f);
      }

      if (bg2.position.y <= -height)
      {
        bg2.position = new Vector3(bg2.position.x, bg1.position.y + height, 0f);
      }
    }
}
