using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ZombieHealth : MonoBehaviour
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
            PlayAudioSingleTime();         
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        audioSource.clip = deathSFX;
        PlayAudioSingleTime();

        /* todo    - Now just stop zombie running. Change for death animation
         * @author - Артур
         * @date   - 07.11.2017
         * @time   - 13:49
        */        
        AICharacterControl control = GetComponent<AICharacterControl>();
        control.target = null;

        Destroy(gameObject, deathSFX.length);
    }

    private void PlayAudioSingleTime()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();   
        }
    }
}