using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour
{
    [SerializeField]
    private AudioClip initialHeliCall;

    [SerializeField]
    private AudioClip heliCallReply;
    
    private AudioSource audioSource;
    
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMakeInitialHeliCall()
    {
        audioSource.clip = initialHeliCall;
        audioSource.Play();
        
        Invoke("ReplyInitialCall", initialHeliCall.length + 1f);
    }

    private void ReplyInitialCall()
    {
        audioSource.clip = heliCallReply;
        audioSource.Play();
        
        BroadcastMessage("OnDispatchHelicopter");
    }
}