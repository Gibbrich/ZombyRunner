using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerVoice : MonoBehaviour
{
    [SerializeField]
    private AudioClip whatHappened;
    [SerializeField]
    private AudioClip goodLandingArea;

    private AudioSource audioSource;

    private RadioSystem radioSystem;
    
    // Use this for initialization
    void Start()
    {
        radioSystem = FindObjectOfType<RadioSystem>();
        
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = whatHappened;
        audioSource.Play();
    }

    public void FindClearArea()
    {
        audioSource.clip = goodLandingArea;
        audioSource.Play();
        
        Invoke("CallHelicopter", goodLandingArea.length + 1);
    }

    private void CallHelicopter()
    {
        radioSystem.CallHelicopter();
    }
}