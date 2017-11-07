﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static readonly string PLAYER_ATTACKED_TRIGGER = "playerAttacked";
    private static readonly string PLAYER_DEAD_TRIGGER = "playerDied";
    private static readonly string PLAYER_RESCUED_TRIGGER = "playerRescued";

    private HealthDisplay healthDisplay;
    private Animator animator;
    
    // Use this for initialization
    void Start()
    {
        healthDisplay = GetComponentInChildren<HealthDisplay>();
        animator = GetComponent<Animator>();
    }
    
    public void UpdateHealthDisplay(float value)
    {
        animator.SetTrigger(PLAYER_ATTACKED_TRIGGER);
        
        healthDisplay.UpdateHealthDisplay(value);
    }

    public void PlayerDied()
    {
        animator.SetTrigger(PLAYER_DEAD_TRIGGER);
    }

    // called by animation event
    public void LoadLevel(string levelName)
    {
        LevelManager.Instance.LoadLevel(levelName);
    }

    public void PlayerRescued()
    {
        animator.SetTrigger(PLAYER_RESCUED_TRIGGER);
    }
}