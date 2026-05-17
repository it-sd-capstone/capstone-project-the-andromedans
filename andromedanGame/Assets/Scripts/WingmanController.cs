using UnityEngine;
using UnityEngine.UI;

public class WingmanController : MonoBehaviour
{
    //Player shooting
    [SerializeField]
    private ObjectPool bulletPool;
    [SerializeField]
    private Transform firePoint;
    public float fireRate = 0.2f;
    public Transform player;
    public float powerupTime = 30f;
    public Slider slider;

    private PlayerControls controls;
    private bool isFocus;
    private bool isFire;
    private float fireTimer;

    private void Awake()
    {
        controls = new PlayerControls();

        //Firing
        controls.Gameplay.Fire.performed += ctx => isFire = true;
        controls.Gameplay.Fire.canceled += ctx => isFire = false;
        controls.Gameplay.Fire.performed += ctx => Debug.Log("Fire pressed");
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
        transform.position = (Vector2)player.position + new Vector2(1.2f, 0f);
        powerupTime -= Time.deltaTime;
        slider.value = powerupTime;
        
        if (powerupTime <= 0)
        {
            gameObject.SetActive(false);
            powerupTime = 30f;
        }

        HandleFiring();
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
        bullet.transform.rotation = Quaternion.identity;
    }
}
