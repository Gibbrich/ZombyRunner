using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour
{
    [SerializeField]
    private float timeSinceLastTrigger = 0f;

    private bool isFoundClearArea = false;
    
    // Update is called once per frame
    void Update()
    {
        timeSinceLastTrigger += Time.deltaTime;

        if (!isFoundClearArea && timeSinceLastTrigger >= 1f && Time.realtimeSinceStartup >= 10f )
        {
            SendMessageUpwards("OnFindClearArea");
            isFoundClearArea = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("Player"))
        {
            timeSinceLastTrigger = 0;            
        }
    }
}