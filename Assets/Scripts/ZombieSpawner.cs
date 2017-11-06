using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;
    
    [SerializeField]
    private float spawnThresholdMin = 10f;
    
    [SerializeField]
    private float spawnThresholdMax = 15f;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Spawn()
    {
        GameObject zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        AICharacterControl control = zombie.GetComponent<AICharacterControl>();
        control.target = GameManager.Instance.Player.transform;
    }
}