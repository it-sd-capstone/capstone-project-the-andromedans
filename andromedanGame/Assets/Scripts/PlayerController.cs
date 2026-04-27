using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player movement
    public float speed = 8f;
    public float focusMult = 0.5f;

    //Player shooting
    [SerializeField]
    private ObjectPool bulletPool;
    [SerializeField]
    private Transform firePoint;
    public float fireRate = 0.2f;

    private PlayerControls controls;
    private Vector2 moveInput;
    private bool isFocus;
    private bool isFire;
    private float fireTimer;

    private void Awake()
    {
        controls = new PlayerControls();

        //Moving
        controls.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Gameplay.SlowMove.started += ctx => isFocus = true;
        controls.Gameplay.SlowMove.canceled += ctx => isFocus = false;

        //Firing
        controls.Gameplay.Fire.started += ctx => isFire = true;
        controls.Gameplay.Fire.canceled += ctx => isFire = false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        HandleMovement();
        HandleFiring();
    }

    private void HandleMovement()
    {
        float currentSpeed = isFocus ? speed * focusMult : speed;

        Vector3 move = new Vector3(moveInput.x, moveInput.y, 0f);
        transform.position += move * currentSpeed * Time.deltaTime;
        //Debug.Log(isFocus);
    }

    private void HandleFiring()
    {
        fireTimer -= Time.deltaTime;

        if (isFire && fireTimer <= 0f)
        {
            Fire();
            fireTimer = fireRate;
        }
    }

    private void Fire()
    {
        if (bulletPool == null || firePoint == null) return;

        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = firePoint.position;
    }
}
