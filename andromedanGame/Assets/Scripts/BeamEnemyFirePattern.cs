using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeamEnemyFirePattern : MonoBehaviour
{
    [SerializeField]
    public float length = 8f;
    [SerializeField]
    public float duration = 2f;
    [SerializeField]
    public float delay = 3f;
    [SerializeField]
    private float damageInterval = 0.05f;
    private float damageTimer;
    public Transform launchpoint;
    public LayerMask mask;
    private LineRenderer lineRenderer;
    private bool firing = false;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(FireRoutine());
    }

    System.Collections.IEnumerator FireRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            firing = true;
            lineRenderer.enabled = true;
            float timer = 0f;

            while (timer < duration)
            {
                UpdateBeam();
                timer += Time.deltaTime;
                yield return null;
            }

            lineRenderer.enabled = false;
            firing = false;
        }
    }

    private void UpdateBeam()
    {
        Vector3 start = launchpoint.position;
        Vector3 end = start + Vector3.down * length;

        RaycastHit2D hit = Physics2D.Raycast(start, Vector2.down, length, mask);
        bool playerHit = false;


        if (hit.collider != null)
        {
            end = hit.point;

            if (hit.collider.CompareTag("Player"))
            {
                playerHit = true;
            }
        }

        if (playerHit)
        {
            //Debug.Log("Player hit");
            damageTimer += Time.deltaTime;
            //Debug.Log("DamageTimer = " + damageTimer);
            //Debug.Log(hit.collider.name);
            //Debug.Log("Timer: " + damageTimer + " Interval: " + damageInterval);

            if (damageTimer >= damageInterval)
            {
                //Debug.Log("Beam hit");
                
                hit.collider.GetComponent<PlayerHealth>()?.TakeDamage(1);
                damageTimer = 0f;
            }
        }
        else
        {
            damageTimer = 0f;
        }

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
