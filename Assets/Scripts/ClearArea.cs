using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour
{
    public bool IsClearArea { get; set; }
    private float timeSinceLastTrigger = 0f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastTrigger += Time.deltaTime;
        IsClearArea = timeSinceLastTrigger >= 1f;
    }

    private void OnTriggerStay(Collider other)
    {
        timeSinceLastTrigger = 0;
    }
}