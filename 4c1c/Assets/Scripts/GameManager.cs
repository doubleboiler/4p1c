using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private const int moves_amount = 3;
    private int _currentPlayerNumber;
    private int _currentPlayerMove;

    [HideInInspector]
    public List<Player> Players;

    public Player ActivePlayer;

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

        BoardManager.instance.GenerateBoard();

        PlayersManager.instance.CreateMainPlayer(ActivePlayer.Color, BoardManager.instance.ActiveSide);
    }

    private void SetupPlayers()
    {
        Players = new List<Player>();

        Players.Add(new Player(1, "Красный", Color.red));
        Players.Add(new Player(2, "Синий", Color.blue));

        _currentPlayerNumber = 0;
        _currentPlayerMove = 0;

        ActivePlayer = Players[_currentPlayerNumber];
    }

    public void SwitchPlayer()
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
        _currentPlayerMove = 0;
    }

    public void CellGotSelected()
    {
        _currentPlayerMove++;

        if (_currentPlayerMove == moves_amount)
        {
            SwitchPlayer();
        }
    }
}
