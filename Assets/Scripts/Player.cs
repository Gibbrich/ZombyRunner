using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float health = 100;
    
    [SerializeField]
    private GameObject spawnPointsParent;

    [SerializeField]
    private GameObject flare;

    private Vector3 flarePosition;
    
    [SerializeField]
    private bool respawn = false;
    private readonly bool lastRespawnToggle = false;

    public float Health
    {
        get { return health; }
        private set { health = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (lastRespawnToggle != respawn)
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

    private void Respawn()
    {
        Transform[] spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform>();
        int id = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[id].position;
    }
    
    // called by broadcast by ClearArea
    private void OnFindClearArea()
    {
        flarePosition = transform.position;
        Invoke("DropFlare", 3f);
    }

    private void DropFlare()
    {
        Instantiate(flare, flarePosition, Quaternion.identity);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            // play charachter die sound
            GameManager.Instance.UIManager.PlayerDied();
        }
        else
        {
            // play character hurt sound
            GameManager.Instance.UIManager.UpdateHealthDisplay(Health);
        }
    }
}