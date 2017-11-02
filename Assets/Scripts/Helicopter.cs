using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField] 
    private AudioClip callSound;
    private AudioSource audioSource;

    private new Rigidbody rigidbody;

    public Helicopter()
    {
        IsCalled = false;
    }

    public bool IsCalled { get; set; }

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponents<AudioSource>()[1];
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Call()
    {
        if (!IsCalled)
        {
            IsCalled = true;

            audioSource.clip = callSound;
            audioSource.Play();

            rigidbody.velocity = new Vector3(0, 0, 50f);
        }
    }
}