using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    private static readonly string COMPLETED = "1/1";
    
    [SerializeField]
    private Text state;

    private Text objective;
    
    // Use this for initialization
    void Start()
    {
        objective = GetComponent<Text>();
    }

    public void Show()
    {
        objective.enabled = true;
        state.enabled = true;
    }

    public void Complete()
    {
        state.text = COMPLETED;
    }
}