using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider slider;

    void Start()
    {
        slider.maxValue = playerHealth.health;
        slider.value = playerHealth.health;
    }

    void Update()
    {
        slider.value = playerHealth.health;
    }
}
