using System.Collections;
using System.Collections.Generic;
using Gamelogic.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private Helicopter helicopter;
    public Helicopter Helicopter
    {
        get
        {
            if (!helicopter)
            {
                helicopter = FindObjectOfType<Helicopter>();
            }
            return helicopter;
        }
    }

    private Player player;
    public Player Player
    {
        get
        {
            if (!player)
            {
                player = FindObjectOfType<Player>();
            }
            return player;
        }
    }

    private UIManager uiManager;
    public UIManager UIManager
    {
        get
        {
            if (!uiManager)
            {
                uiManager = FindObjectOfType<UIManager>();
            }
            return uiManager;
        }
    }

    private float mediumThreshold = 0.3f;
    private float hardTreshold = 0.7f;

    private GameDifficulty currentGameDifficulty = GameDifficulty.EASY;
    public GameDifficulty CurrentGameDifficulty
    {
        get { return currentGameDifficulty; }
        set { currentGameDifficulty = value; }
    }
    
    [SerializeField]
    private GameObject deathExplosionParticlesPrefab;

    private ObservedValue<int> zombieCountObservable = new ObservedValue<int>(0);
    public ObservedValue<int> ZombieCountObservable
    {
        get { return zombieCountObservable; }
    }

    public MusicManager MusicManager { get; private set; }

    // Use this for initialization
    void Start()
    {
        MusicManager = FindObjectOfType<MusicManager>();
    }

    private void Update()
    {
        if (Helicopter.CalledTime != -1)
        {
            float timeLeft = Helicopter.CalledTime / Helicopter.ArrivalTime;

            if (timeLeft <= mediumThreshold)
            {
                CurrentGameDifficulty = GameDifficulty.EASY;
            }
            else if (mediumThreshold < timeLeft && timeLeft <= hardTreshold)
            {
                CurrentGameDifficulty = GameDifficulty.MEDIUM;
            }
            else
            {
                CurrentGameDifficulty = GameDifficulty.HARD;
            }
        }
        
        /* todo    - turn on more ZombieSpawners on increasing difficulty
         * @author - Dvurechenskiyi
         * @date   - 10.11.2017
         * @time   - 12:07
        */        
    }

    public enum GameDifficulty
    {
        EASY,
        MEDIUM,
        HARD
    }
}