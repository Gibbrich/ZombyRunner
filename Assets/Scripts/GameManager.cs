using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Helicopter Helicopter { get; private set; }

    public Player Player { get; private set; }

    public HealthDisplay HealthDisplay { get; private set; }

    public UIManager UIManager { get; private set; }

    private float mediumThreshold = 0.3f;
    private float hardTreshold = 0.7f;

    private Difficulty currentDifficulty = Difficulty.EASY;
    public Difficulty CurrentDifficulty
    {
        get { return currentDifficulty; }
        set { currentDifficulty = value; }
    }
    
    [SerializeField]
    private GameObject deathExplosionParticlesPrefab;

    private int zombieCount;
    public int ZombieCount
    {
        get { return zombieCount; }

        set
        {
            zombieCount = value;
            UIManager.UpdateZombieKillCountDisplay();
        }
    }

    // Use this for initialization
    void Start()
    {
        Player = FindObjectOfType<Player>();
        Helicopter = FindObjectOfType<Helicopter>();
        HealthDisplay = FindObjectOfType<HealthDisplay>();
        UIManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if (Helicopter.CalledTime != -1)
        {
            float timeLeft = Helicopter.CalledTime / Helicopter.ArrivalTime;

            if (timeLeft <= mediumThreshold)
            {
                CurrentDifficulty = Difficulty.EASY;
            }
            else if (mediumThreshold < timeLeft && timeLeft <= hardTreshold)
            {
                CurrentDifficulty = Difficulty.MEDIUM;
            }
            else
            {
                CurrentDifficulty = Difficulty.HARD;
            }
        }
        
        /* todo    - turn on more ZombieSpawners on increasing difficulty
         * @author - Dvurechenskiyi
         * @date   - 10.11.2017
         * @time   - 12:07
        */        
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    /* todo    - move to ZombieHealth script
     * @author - Артур
     * @date   - 09.11.2017
     * @time   - 23:11
    */
    
    public void PlayZombieDeathExplosion(Vector3 position)
    {
        GameObject explosion = Instantiate(deathExplosionParticlesPrefab, position, Quaternion.identity);
        Destroy(explosion, 3f);
    }
    
    
    
    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD
    }
}