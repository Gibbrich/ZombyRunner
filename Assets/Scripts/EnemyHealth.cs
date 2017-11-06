using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 100;

    [SerializeField]
    private AudioClip hurtSFX;

    [SerializeField]
    private AudioClip deathSFX;

    private AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = hurtSFX;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(float damage, Vector3 shootHitPoint)
    {
        health -= damage;

        if (health > 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();   
            }            
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        audioSource.clip = deathSFX;
        audioSource.Play();
        
        Destroy(gameObject, deathSFX.length);
    }
}