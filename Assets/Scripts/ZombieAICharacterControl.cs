using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAICharacterControl : MonoBehaviour
{
    public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
    public ZombieThirdPersonCharacter character { get; private set; } // the character we are controlling
    public Transform target;                                    // target to aim for


    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<NavMeshAgent>();
        character = GetComponent<ZombieThirdPersonCharacter>();

        agent.updateRotation = false;
        agent.updatePosition = true;
    }


    private void FixedUpdate()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.isStopped = true;
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}