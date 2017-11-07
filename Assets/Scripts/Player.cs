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
    private GameObject flarePrefab;

    public GameObject Flare { get; private set; }

    private InnerVoice innerVoice;
    
    [SerializeField]
    private bool respawn = false;
    private readonly bool lastRespawnToggle = false;

    public float Health
    {
        get { return health; }
        private set { health = value; }
    }

    private void Start()
    {
        innerVoice = GetComponentInChildren<InnerVoice>();
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
            innerVoice.FindClearArea();
            DropFlare();
        }
    }

    private void Respawn()
    {
        Transform[] spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform>();
        int id = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[id].position;
    }
    
    private void DropFlare()
    {
        Flare = Instantiate(flarePrefab, transform.position, Quaternion.identity);
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