using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Text text;
    
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.text = GameManager.Instance.Player.Health.ToString(CultureInfo.CurrentCulture);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateHealthDisplay(float value)
    {
        text.text = value.ToString(CultureInfo.CurrentCulture);
    }
}