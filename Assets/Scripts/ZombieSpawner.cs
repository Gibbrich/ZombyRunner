using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class ZombieSpawner : MonoBehaviour
{
    #region Editor tweakable fields
    
    [SerializeField]
    [Tooltip("Minimum interval before next spawn")]
    private float spawnThresholdMin = 10f;
    
    [SerializeField]
    [Tooltip("Maximum interval before next spawn")]
    private float spawnThresholdMax = 15f;
    
    #endregion
    
    #region Private fields
    
    private float lastSpawnTime = 0;
    private float nextSpawnTime = 0;
    
    #endregion
    
    #region Unity callbacks
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Helicopter.CurrentState != Helicopter.State.AWAIT 
            && Time.time - lastSpawnTime >= nextSpawnTime)
        {
            ZombieManager.Instance.Create(transform.position);
            nextSpawnTime = Random.Range(spawnThresholdMin, spawnThresholdMax);
            lastSpawnTime = Time.time;
        }
    }
    
    #endregion
}