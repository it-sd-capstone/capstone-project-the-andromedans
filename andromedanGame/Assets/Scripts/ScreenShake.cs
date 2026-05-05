using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    public float defaultDuration = 0.2f;
    public float defaultMagnitude = 0.2f;

    private Vector3 originalPosition;
    private Coroutine shakeRoutine;

    private void Awake()
    {
        originalPosition = transform.localPosition;
    }

    public void Shake(float duration, float magnitude)
    {
        if (shakeRoutine != null)
            StopCoroutine(shakeRoutine);

        shakeRoutine = StartCoroutine(ShakeRoutine(duration, magnitude));
    }

    public void ShakeDefault()
    {
        Shake(defaultDuration, defaultMagnitude);
    }

    private IEnumerator ShakeRoutine(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}