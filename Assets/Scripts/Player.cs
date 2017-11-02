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

    private ClearArea clearArea;
    
    // Use this for initialization
    void Start()
    {
        clearArea = GetComponentInChildren<ClearArea>();
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
            if (clearArea.IsClearArea)
            {
                GameManager.Instance.Helicopter.Call();                
            }
            else
            {
                print("Can't call helicopter. Must find clear area first.");
            }
        }
    }

    private void Respawn()
    {
        Transform[] spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform>();
        int id = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[id].position;
    }
}