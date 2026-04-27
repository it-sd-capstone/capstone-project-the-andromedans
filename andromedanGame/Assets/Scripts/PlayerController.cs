using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 8f;
    [SerializeField]
    public float focusMult = 0.5f;

    private PlayerControls controls;
    private Vector2 moveInput;
    private bool isFocus;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Gameplay.SlowMove.started += ctx => isFocus = true;
        controls.Gameplay.SlowMove.canceled += ctx => isFocus = false;
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
        float currentSpeed = isFocus ? speed * focusMult : speed;

        Vector3 move = new Vector3(moveInput.x, moveInput.y, 0f);
        transform.position += move * currentSpeed * Time.deltaTime;

        //Debug.Log(isFocus);
    }
}
