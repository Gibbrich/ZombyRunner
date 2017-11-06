using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAggro : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] aggroSFX;
    
    private AudioSource audioSource;    
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            int sfxId = Random.Range(0, aggroSFX.Length);
            audioSource.clip = aggroSFX[sfxId];
            audioSource.Play();
        }
    }
}