using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField] 
    private AudioClip callSound;
    private AudioSource audioSource;
    
    private bool isCalled = false;
    
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Call()
    {
        if (!isCalled)
        {
        isCalled = true;
        
        audioSource.clip = callSound;
        audioSource.Play();
        }
    }
}