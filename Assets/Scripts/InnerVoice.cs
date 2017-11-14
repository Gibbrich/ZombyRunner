using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerVoice : MonoBehaviour
{
    [SerializeField]
    private AudioClip whatHappened;
    
    [SerializeField]
    private AudioClip goodLandingArea;

    [SerializeField]
    private AudioClip[] hurtSFX;
    
    [SerializeField]
    private AudioClip[] dieSFX;

    private AudioSource audioSource;

    private RadioSystem radioSystem;
    
    // Use this for initialization
    void Start()
    {
        radioSystem = FindObjectOfType<RadioSystem>();
        
        audioSource = GetComponent<AudioSource>();
        PlayDialog(whatHappened, "");
    }

    private void PlayDialog(AudioClip clip, string message)
    {
        audioSource.clip = whatHappened;
        audioSource.Play();
    }

    public void FindClearArea()
    {
        /* todo    - for now do not play goodLandingArea clip
         * @author - Dvurechenskiyi
         * @date   - 10.11.2017
         * @time   - 9:41
        */        
//        audioSource.clip = goodLandingArea;
//        audioSource.Play();
//        
//        Invoke("CallHelicopter", goodLandingArea.length + 1);
        
        CallHelicopter();
    }

    private void CallHelicopter()
    {
        radioSystem.CallHelicopter();
    }

    public void PlayHurtSFX()
    {
        int sfxId = Random.Range(0, hurtSFX.Length);
        audioSource.clip = hurtSFX[sfxId];
        audioSource.Play();
    }

    public void PlayDieSFX()
    {
        int sfxId = Random.Range(0, dieSFX.Length);
        audioSource.clip = dieSFX[sfxId];
        audioSource.Play();
    }
}