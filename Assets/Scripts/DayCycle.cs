using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    [SerializeField] 
    [Tooltip("Number of minutes per second")]
    private float timeScale = 60f;

    private Quaternion startRotation;
    // Use this for initialization
    void Start()
    {
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float angleThisFrame = Time.deltaTime / 360 * timeScale;
        transform.RotateAround(transform.position, Vector3.forward, angleThisFrame);
    }
}