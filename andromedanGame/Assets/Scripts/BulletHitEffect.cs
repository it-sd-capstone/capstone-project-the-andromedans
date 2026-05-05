using UnityEngine;

public class BulletHitEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public ParticleSystem particles;
    public AudioClip hitSound;
    public float lifetime = 3f;

    private void OnEnable()
    {
        if (particles != null)
        {
            particles.Play();
            //Debug.Log("Played particles");
        }

        if (audioSource != null && hitSound != null)
            audioSource.PlayOneShot(hitSound);

        Destroy(gameObject, lifetime);
    }
}