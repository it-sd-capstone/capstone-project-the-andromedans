using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0;
    public static ScoreManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        score += Time.deltaTime * 10f;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);

        //Debug.Log(scoreText.text);
    }

    public void AddScore(int value)
    {
        score += value;
    }
}