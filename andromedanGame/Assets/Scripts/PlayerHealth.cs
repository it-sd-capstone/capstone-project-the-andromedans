using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 20;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player health: " + health);

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
