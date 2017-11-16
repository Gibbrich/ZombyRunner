using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private ZombieHealth enemyHealth;
    private NavMeshAgent nav;


    void Awake()
    {
        enemyHealth = GetComponent<ZombieHealth>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (enemyHealth.Health > 0 && GameManager.Instance.Player.Health > 0)
        {
            nav.SetDestination(GameManager.Instance.Player.transform.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}