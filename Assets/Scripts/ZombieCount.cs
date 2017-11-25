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
        GameManager.Instance.ZombieCount.OnValueChange += UpdateCount;
        UpdateCount(GameManager.Instance.ZombieCount.Value);
    }

    public void UpdateCount(int value)
    {
        text.text = value.ToString();        
    }

    private void OnDestroy()
    {
        GameManager.Instance.ZombieCount.OnValueChange -= UpdateCount;
    }
}