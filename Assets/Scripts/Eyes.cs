using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    private float defaultFOV;

    // Use this for initialization
    void Start()
    {
        defaultFOV = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Zoom"))
        {
            Camera.main.fieldOfView = defaultFOV / 1.5f;
        }
        else
        {
            Camera.main.fieldOfView = defaultFOV;
        }
    }
}