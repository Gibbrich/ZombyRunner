using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieCount : MonoBehaviour
{
    private Text text;
    
    // Use this for initialization
    void Start()
    {
        text = GetComponentInChildren<Text>();
        UpdateCount();
    }

    public void UpdateCount()
    {
        text.text = GameManager.Instance.ZombieCount.ToString();        
    }
}