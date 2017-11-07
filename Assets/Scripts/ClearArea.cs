using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour
{
    [SerializeField]
    private float timeSinceLastTrigger = 0f;

    private bool isFoundClearArea = false;

    private bool IsFoundClearArea
    {
        get { return isFoundClearArea; }

        set
        {
            if (isFoundClearArea != value)
            {
                GameManager.Instance.UIManager.ClearAreaStateChanged(value);
            }

            isFoundClearArea = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastTrigger += Time.deltaTime;

        IsFoundClearArea = timeSinceLastTrigger >= 1f && Time.time >= 10f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("Player"))
        {
            timeSinceLastTrigger = 0;
        }
    }
}