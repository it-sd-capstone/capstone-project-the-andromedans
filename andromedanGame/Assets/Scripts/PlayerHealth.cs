using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 20;

    [Header("Invincibility Frames")]
    public float invincibilityDuration = 1.0f;

    private bool isInvincible = false;
    private float invincibilityTimer = 0f;

    private DeathScreen deathScreen;

    void Awake()
    {
        deathScreen = FindFirstObjectByType<DeathScreen>(FindObjectsInactive.Include);
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;

            if (invincibilityTimer <= 0f)
            {
                isInvincible = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
            return;

        health -= damage;

        if (health <= 0)
        {
            Die();
            return;
        }

        isInvincible = true;
        invincibilityTimer = invincibilityDuration;
    }

    void Die()
    {
        if (deathScreen != null)
        {
            deathScreen.gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
}