using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] music;

    private AudioSource audioSource;
    private int currentTrack = 0;

    private bool isPlaying = false;
    
    [SerializeField]
    private bool shouldPlay = false;
    public bool ShouldPlay
    {
        get { return shouldPlay; }
        set { shouldPlay = value; }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (ShouldPlay && !isPlaying)
        {
            Play();
        }
    }

    public void Play()
    {
        audioSource.clip = music[currentTrack];
        audioSource.Play();
        isPlaying = true;
        Invoke("OnClipEnd", audioSource.clip.length);
    }

    private void OnClipEnd()
    {
        isPlaying = false;
        IncreaseTrackCount();
    }

    private void IncreaseTrackCount()
    {
        currentTrack++;

        if (currentTrack >= music.Length)
        {
            currentTrack = 0;
        }
    }
}