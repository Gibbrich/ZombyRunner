using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour
{
    [SerializeField]
    private float timeSinceLastTrigger = 0f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastTrigger += Time.deltaTime;

        if (!GameManager.Instance.Helicopter.IsCalled && timeSinceLastTrigger >= 1f && Time.realtimeSinceStartup >= 10f )
        {
            SendMessageUpwards("OnFindClearArea");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        timeSinceLastTrigger = 0;
    }
}