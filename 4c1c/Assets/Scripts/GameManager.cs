using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Side mSide;

    [HideInInspector]
    public List<Player> Players;

    public Player ActivePlayer;

    private int _currentPlayerNumber;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of " + nameof(GameManager) + " in the scene");
            return;
        }
        instance = this;
    }

    void Start()
    {
        SetupPlayers();

        mSide.Setup();
    }

    private void SetupPlayers()
    {
        Players = new List<Player>();

        Players.Add(new Player("Красный", Color.red));
        Players.Add(new Player("Синий", Color.blue));

        _currentPlayerNumber = 0;

        ActivePlayer = Players[_currentPlayerNumber];
    }

    public void NextPlayer()
    {
        if (_currentPlayerNumber + 1 <= Players.Count - 1)
        {
            _currentPlayerNumber++;
        }
        else
        {
            _currentPlayerNumber = 0;
        }

        ActivePlayer = Players[_currentPlayerNumber];
    }
}
