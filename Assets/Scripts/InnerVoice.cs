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
    
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = whatHappened;
        audioSource.Play();
    }

    // called by broadcast by ClearArea
    private void OnFindClearArea()
    {
        audioSource.clip = goodLandingArea;
        audioSource.Play();
        
        Invoke("CallHeli", goodLandingArea.length + 1f);
    }

    private void CallHeli()
    {
        SendMessageUpwards("OnMakeInitialHeliCall");
    }
}