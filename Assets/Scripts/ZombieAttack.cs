using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private static readonly string ATTACK_TRIGGER = "attackTrigger";
    
    [SerializeField]
    private AudioClip[] attackSFX;

    private AudioSource audioSource;
    
    [SerializeField]
    [Tooltip("Time between attacks")]
    private float attackThreshold = 2;

    [SerializeField]
    private float damage = 10;

    private Animator animator;

    private bool isPlayerInRange = false;
    private float lastAttackTime;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Time.time - lastAttackTime >= attackThreshold)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag.Equals("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.collider.tag.Equals("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void Attack()
    {
        animator.SetTrigger(ATTACK_TRIGGER);
        
        int sfxId = Random.Range(0, attackSFX.Length);
        audioSource.clip = attackSFX[sfxId];
        audioSource.Play();
        
        GameManager.Instance.Player.TakeDamage(damage);
    }
}