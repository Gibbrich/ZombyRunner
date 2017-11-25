using System;
using Gamelogic.Extensions;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class ZombieManager : Singleton<ZombieManager>
    {
        #region Editor tweakable fields

        [SerializeField]
        private Zombie zombiePrefab;

        [SerializeField]
        private GameObject zombieParent;

        [SerializeField]
        [Tooltip("Zombie movement speed")]
        private MovementSpeed movementSpeed;

        #endregion

        #region Private fields

        private MonoBehaviourPool<Zombie> pool;
        private Vector3 spawnPosition = Vector3.zero;

        #endregion

        #region Unity callbacks

        private void Start()
        {
            if (!zombieParent)
            {
                throw new UnityException("Please assign zombie parent object to " + typeof(ZombieManager).Name);
            }

            pool = new MonoBehaviourPool<Zombie>(zombiePrefab, zombieParent, 50, OnZombieWakeUp, OnZombieSetToSleep);
        }

        #endregion

        #region Private methods

        private void OnZombieWakeUp(Zombie zombie)
        {
            // set position
            zombie.gameObject.SetActive(true);
            zombie.transform.position = spawnPosition;
                
            // set player as target
            zombie.GetComponent<ZombieAICharacterControl>().target = GameManager.Instance.Player.transform;
                
            // set zombie speed
            float speed;
            GameManager.GameDifficulty currentGameDifficulty = GameManager.Instance.CurrentGameDifficulty;
            if (currentGameDifficulty == GameManager.GameDifficulty.EASY)
            {
                speed = movementSpeed.Easy;
            }
            else if (currentGameDifficulty == GameManager.GameDifficulty.MEDIUM)
            {
                speed = movementSpeed.Medium;
            }
            else
            {
                speed = movementSpeed.Hard;
            }

            NavMeshAgent agent = zombie.GetComponent<NavMeshAgent>();
            agent.Warp(spawnPosition);
            agent.speed = speed;
        }

        private void OnZombieSetToSleep(Zombie zombie)
        {
            zombie.gameObject.SetActive(false);
            zombie.transform.position = Vector3.zero;
        }

        #endregion

        #region Public methods

        public Zombie Create(Vector3 spawnPosition)
        {
            this.spawnPosition = spawnPosition;
            return pool.GetNewObject();
        }

        public void Release(Zombie zombie)
        {
            pool.ReleaseObject(zombie);
        }

        #endregion
    }
}