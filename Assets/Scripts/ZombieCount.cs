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
        GameManager.Instance.ZombieCountObservable.OnValueChange += UpdateCount;
        UpdateCount();
    }

    public void UpdateCount()
    {
        text.text = GameManager.Instance.ZombieCountObservable.Value.ToString();        
    }

    private void OnDestroy()
    {
        GameManager.Instance.ZombieCountObservable.OnValueChange -= UpdateCount;
    }
}