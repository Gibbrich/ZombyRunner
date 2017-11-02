using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private AudioClip whatHappened;
    private AudioSource innerVoice;
    
    [SerializeField]
    private GameObject spawnPointsParent;
    
    [SerializeField]
    private bool respawn = false;
    private readonly bool lastToggle = false;
    
    // Use this for initialization
    void Start()
    {
        innerVoice = GetComponents<AudioSource>()[1];
        innerVoice.clip = whatHappened;
        innerVoice.Play();
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
//            if (clearArea.IsClearArea)
//            {
//                GameManager.Instance.Helicopter.Call();                
//            }
//            else
//            {
//                print("Can't call helicopter. Must find clear area first.");
//            }
        }
    }
    
    // called by broadcast by ClearArea
    private void OnFindClearArea()
    {
        GameManager.Instance.Helicopter.Call();
    }

    private void Respawn()
    {
        Transform[] spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform>();
        int id = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[id].position;
    }
}