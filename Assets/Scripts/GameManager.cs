using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Gamelogic.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GlobalSingleton<GameManager>
{
    #region Properties

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
    
    private ObservableValue<int> zombieCount;
    public ObservableValue<int> ZombieCount
    {
        get
        {
            if (zombieCount == null)
            {
                zombieCount = new ObservableValue<int>(0);
            }
            return zombieCount;
        }
    }

    private Clock clock;
    public Clock Clock
    {
        get
        {
            if (clock == null)
            {
                clock = new Clock();
                clock.Reset(arrivalTime);
            }
            return clock;
        }
    }
    
    #endregion

    #region Editor tweakable fields

    [SerializeField]
    [Tooltip("Helicopter arrival time")]
    private float arrivalTime = 300;

    #endregion
    
    private float mediumThreshold = 0.3f;
    private float hardTreshold = 0.7f;

    private GameDifficulty currentGameDifficulty = GameDifficulty.EASY;
    public GameDifficulty CurrentGameDifficulty
    {
        get { return currentGameDifficulty; }
        set { currentGameDifficulty = value; }
    }

    public MusicManager MusicManager { get; private set; }

    #region Unity callbacks

    // Use this for initialization
    void Start()
    {
        MusicManager = FindObjectOfType<MusicManager>();
    }

    private void Update()
    {
        clock.Update(Time.deltaTime);
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

    #endregion

    public void StartHelicopterArrivalCountdown()
    {
        if (clock.IsPaused && !clock.IsDone)
        {
            clock.Unpause();
        }
    }

    public enum GameDifficulty
    {
        EASY,
        MEDIUM,
        HARD
    }
}