using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ZombieHealth : MonoBehaviour
{
    private static readonly string DIE_TRIGGER = "dieTrigger";
    
    [SerializeField]
    private float health = 100;
    public float Health
    {
        get { return health; }
        private set { health = value; }
    }

    [SerializeField]
    private AudioClip hurtSFX;

    [SerializeField]
    private AudioClip deathSFX;

    private AudioSource audioSource;
    private ParticleSystem hitParticles;

    private bool isDead = false;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = hurtSFX;

        hitParticles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(float damage, Vector3 shotPosition)
    {
        if (!isDead)
        {
            Health -= damage;

            hitParticles.transform.position = shotPosition;
            hitParticles.Play();

            if (Health > 0)
            {
                PlayAudioSingleTime();         
            }
            else
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isDead = true;
        
        AudioSource.PlayClipAtPoint(deathSFX, transform.position);

        Vector3 position = transform.position;
        position.y += 1.5f;
        GameManager.Instance.PlayZombieDeathExplosion(position);
        GameManager.Instance.ZombieCount++;
        
        Destroy(gameObject);
    }

    private void PlayAudioSingleTime()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();   
        }
    }
}