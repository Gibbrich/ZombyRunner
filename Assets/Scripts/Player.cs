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

    private State currentState = State.ALIVE;
    
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
        Respawn();
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
        int id = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[id].position;
    }
    
    private void DropFlare()
    {
        Flare = Instantiate(flarePrefab, transform.position, Quaternion.identity);
    }

    public void TakeDamage(float damage)
    {
        if (currentState == State.ALIVE)
        {
            Health -= damage;

            if (Health <= 0)
            {
                currentState = State.DEAD;
                
                innerVoice.PlayDieSFX();
                GameManager.Instance.UIManager.PlayerDied();
            }
            else
            {
                innerVoice.PlayHurtSFX();
                GameManager.Instance.UIManager.UpdateHealthDisplay(Health);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Helicopter>())
        {
            currentState = State.RESCUED;
        }
    }

    private enum State
    {
        ALIVE,
        DEAD,
        RESCUED
    }
}