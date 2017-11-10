using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;

    [SerializeField]
    private GameObject zombieParent;

    [SerializeField]
    private float easyMovementSpeed = 0.5f;

    [SerializeField]
    private float mediumMovementSpeed = 0.7f;

    [SerializeField]
    private float hardMovementSpeed = 1f;
    
    [SerializeField]
    private float spawnThresholdMin = 10f;
    
    [SerializeField]
    private float spawnThresholdMax = 15f;

    private float lastSpawnTime = 0;
    private float nextSpawnTime = 0;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Helicopter.CurrentState != Helicopter.State.AWAIT 
            && Time.time - lastSpawnTime >= nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Random.Range(spawnThresholdMin, spawnThresholdMax);
            lastSpawnTime = Time.time;
        }
    }

    private void Spawn()
    {
        GameObject zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        zombie.transform.parent = zombieParent.transform;
        
        AICharacterControl control = zombie.GetComponent<AICharacterControl>();
        control.target = GameManager.Instance.Player.transform;

        // set zombie speed
        float speed;
        GameManager.Difficulty currentDifficulty = GameManager.Instance.CurrentDifficulty;
        if (currentDifficulty == GameManager.Difficulty.EASY)
        {
            speed = easyMovementSpeed;
        }
        else if (currentDifficulty == GameManager.Difficulty.MEDIUM)
        {
            speed = mediumMovementSpeed;
        }
        else
        {
            speed = hardMovementSpeed;
        }

        NavMeshAgent agent = zombie.GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }
}