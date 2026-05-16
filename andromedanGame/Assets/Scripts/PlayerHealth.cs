using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public PlayerHealthBar healthBar;

    [HideInInspector]
    public int health;
    private ScreenShake screenShake;
    private LowHealthEffect lowHealthOverlay;
    public AudioClip hitSound;
    private AudioSource audioSource;

    private void Start()
    {
        health = maxHealth;
        screenShake = FindFirstObjectByType<ScreenShake>();
        lowHealthOverlay = FindFirstObjectByType<LowHealthEffect>();
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        screenShake.Shake(0.3f, 0.05f);
        Debug.Log("Player health: " + health);

        if (hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        // Activate low health screen effect on 1/4 health
        if (health <= (maxHealth / 4))
        {
            if (lowHealthOverlay)
            {
                lowHealthOverlay.SetOpacityPercent(100);
            }
        }

        if (health <= 0)
        {
            Debug.Log("Player death");
            Die();
        }
    }

    void Die()
    {
        //Destroy(gameObject);
        SceneManager.LoadScene("MainMenuScene");
    }
}
