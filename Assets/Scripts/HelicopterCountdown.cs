using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class HelicopterCountdown : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
        GameManager.Instance.Clock.OnSecondsChanged += SetTimeLeft;
    }

    private void SetTimeLeft()
    {
        text.text = GameManager.Instance.Clock.TimeInSeconds.ToString();
    }
}