using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPointsParent;
    
    [SerializeField]
    private bool respawn = false;
    private readonly bool lastToggle = false;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (lastToggle != respawn)
        {
            Respawn();
            respawn = false;
        }
        
        if (Input.GetButtonDown("CallHeli"))
        {
            FindObjectOfType<Helicopter>().Call();
        }
    }

    private void Respawn()
    {
        Transform[] spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform>();
        int id = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[id].position;
    }
}