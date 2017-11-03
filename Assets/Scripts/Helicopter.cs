using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public Helicopter()
    {
        IsCalled = false;
    }

    public bool IsCalled { get; set; }

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnDispatchHelicopter()
    {
        if (!IsCalled)
        {
            IsCalled = true;
            rigidbody.velocity = new Vector3(0, 0, 50f);
        }
    }
}