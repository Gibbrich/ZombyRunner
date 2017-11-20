using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private int damagePerShot = 20;
    [SerializeField]
    private float timeBetweenBullets = 0.15f;
    [SerializeField]
    private float range = 200f;


    private float timer;
    private Ray shootRay = new Ray();
    private RaycastHit shootHit;
    private int shootableMask;
    private AudioSource gunAudio;
    private Light gunLight;
    private float effectsDisplayTime = 0.2f;


    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    {
        gunLight.enabled = false;
    }


    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            ZombieHealth zombieHealth = shootHit.collider.GetComponentInParent<ZombieHealth>();
            if (zombieHealth != null)
            {
                zombieHealth.TakeDamage(damagePerShot, shootHit.point);
            }
        }
    }
}