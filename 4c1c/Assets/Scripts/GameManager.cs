using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private const int moves_amount = 3;
    private int _currentPlayerNumber;
    private int _currentPlayerMove;

    [ReadOnly]
    public GamePhase ActiveGamePhase;

    [HideInInspector]
    public List<GamePlayer> Players;

    public GamePlayer ActivePlayer;

    private BoardManager _boardManager;
    private PlayersManager _playersManager;

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
        _boardManager = BoardManager.instance;
        _playersManager = PlayersManager.instance;

        _boardManager.GenerateBoard();

        SetupPlayers();
    }

    private void SetupPlayers()
    {
        Players = new List<GamePlayer>();

        Players.Add(new GamePlayer(1, "Красный", Color.red));
        Players.Add(new GamePlayer(2, "Синий", Color.blue));

        SetupTwoInOne();
    }

    private void SetupTwoInOne()
    {
        _playersManager.CreatePlayer(_boardManager.ActiveSide, Players);
    }

    public void SwitchPlayer()
    {
        _currentPlayerMove = 0;

        //_playersManager.StartMove();
    }

    public void CellGotSelected()
    {
        _currentPlayerMove++;

        if (_currentPlayerMove == moves_amount)
        {
            SwitchPlayer();
        }
    }

    private void RotationPhaseActions()
    {
        ActiveGamePhase = GamePhase.Rotation;


    }

    private void MovementPhaseActions()
    {
        ActiveGamePhase = GamePhase.Movement;


    }

    private void CarpetingPhaseActions()
    {
        ActiveGamePhase = GamePhase.Carpeting;


    }
}
