using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour
{
    [SerializeField]
    private AudioClip initialHeliCall;

    [SerializeField]
    private AudioClip heliCallReply;

    [SerializeField]
    private AudioClip heliInPosition;

    [SerializeField]
    private AudioClip heliInPositionReply;
    
    private AudioSource audioSource;
    
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void CallHelicopter()
    {
        Action action = () => Invoke("ReplyHelicopter", initialHeliCall.length + 1f);
        PlayDialog(Dialog.Character.PLAYER, initialHeliCall, DialogText.EVACUATION_REQUIRE, action);
    }

    private void ReplyHelicopter()
    {
        Action action = () =>
        {
            GameManager.Instance.UIManager.ShowCurrentObjective();
            GameManager.Instance.Helicopter.CallHelicopter();
            GameManager.Instance.StartHelicopterArrivalCountdown();
            GameManager.Instance.MusicManager.ShouldPlay = true;
        };
        
        PlayDialog(Dialog.Character.PILOT, heliCallReply, DialogText.ROGER_THAT, action);
    }

    public void PlayHelicopterInPosition()
    {
        Action action = () => Invoke("PlayHelicopterInPositionReply", heliInPosition.length + 1f);
        PlayDialog(Dialog.Character.PILOT, heliInPosition, DialogText.HELO_IN_POSITION, action);
    }

    public void PlayDialog(Dialog.Character character, AudioClip clip, string message, Action postAction)
    {
        audioSource.clip = clip;
        audioSource.Play();
        
        GameManager.Instance.UIManager.Dialog.ShowDialog(character, message, clip.length);

        if (postAction != null)
        {
            postAction.Invoke();
        }
    }

    private void PlayHelicopterInPositionReply()
    {
        PlayDialog(Dialog.Character.PLAYER, heliInPositionReply, DialogText.ITS_ABOUT_TIME, null);
    }
}