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

    public void CallHelicopter()
    {
        audioSource.clip = initialHeliCall;
        audioSource.Play();
        
        Invoke("ReplyHelicopter", initialHeliCall.length + 1f);
    }

    private void ReplyHelicopter()
    {
        audioSource.clip = heliCallReply;
        audioSource.Play();
        
        GameManager.Instance.Helicopter.CallHelicopter();
        GameManager.Instance.UIManager.StartHelicopterArriveCountdown();
    }
}