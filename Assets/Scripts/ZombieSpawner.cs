using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;

    [SerializeField]
    private GameObject zombieParent;
    
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
        if (Time.time - lastSpawnTime >= nextSpawnTime)
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
    }
}