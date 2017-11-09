using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    private float countdownTime;
     
    private Text text;
    private State currentState = State.INITIAL;

    private void Start()
    {
        countdownTime = GameManager.Instance.Helicopter.ArrivalTime;
        
        text = GetComponentInChildren<Text>();
        text.text = countdownTime.ToString(CultureInfo.CurrentCulture);
    }

    void Update()
    {
        if (currentState == State.COUNTDOWN)
        {
            countdownTime -= Time.deltaTime;
            /* todo    - round - very rough. Use some time class
             * @author - Dvurechenskiyi
             * @date   - 08.11.2017
             * @time   - 16:25
            */
        
            text.text = Mathf.Round(countdownTime).ToString(CultureInfo.CurrentCulture);
            if(countdownTime <= 0)
            {
                countdownTime = 0;
                currentState = State.STOPPED;
                text.color = Color.white;
            }
        }
    }

    public void StartCountdown()
    {
        currentState = State.COUNTDOWN;
    }
    
    private enum State
    {
        INITIAL,
        COUNTDOWN,
        STOPPED
    }
}