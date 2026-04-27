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


        if (hit.collider != null)
        {
            end = hit.point;

            // For later use: player damage logic goes here
            // TBD Week 5 after team discussion
        }

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
