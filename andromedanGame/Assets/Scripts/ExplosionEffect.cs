using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public float duration = 0.4f;
    public float maxScale = 2f;
    //public SpriteRenderer renderer;
    private float timer;

    void Awake()
    {
        //renderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        timer = 0f;
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / duration;
        float scale = Mathf.Lerp(0f, maxScale, t);
        transform.localScale = new Vector3(scale, scale, t);

        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}
