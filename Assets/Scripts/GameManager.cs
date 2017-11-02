using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Helicopter Helicopter { get; private set; }

    public Player Player { get; private set; }
    // Use this for initialization
    void Start()
    {
        Player = FindObjectOfType<Player>();
        Helicopter = FindObjectOfType<Helicopter>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}