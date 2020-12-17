using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Hat;

    public GameObject[] Arrows;

    [ReadOnly]
    public Vector3 CurrentDirection;
    [ReadOnly]
    public Cell CurrentCell;
    [ReadOnly]
    public Cell OriginalCell;

    private List<GamePlayer> _gamePlayers;
    private GamePlayer _activeGamePlayer;

    public void Start()
    {
        _gamePlayers = new List<GamePlayer>();

        EnableAllArrows();
        CurrentDirection = transform.forward;
    }

    public void ArrowPressed(PlayerArrow pressedArrow)
    {
        RotatePlayer(pressedArrow.DegreeRotation);
        DisableAllArrows();
    }

    private void RotatePlayer(float rotation)
    {
        transform.Rotate(0, rotation, 0, Space.Self);
        CurrentDirection = transform.forward;
    }

    private void DisableAllArrows()
    {
        foreach (var arrowObject in Arrows)
        {
            arrowObject.SetActive(false);
        }
    }

    private void EnableAllArrows()
    {
        foreach (var arrowObject in Arrows)
        {
            arrowObject.SetActive(true);
        }
    }

    public void StartMove(int id)
    {
        _activeGamePlayer = FindGamePlayer(id);

        if (_activeGamePlayer == null)
            return;

        Hat.GetComponent<Renderer>().material.color = _activeGamePlayer.Color;

        EnableAllArrows();
    }

    public void AddGamePlayerToPlayer(GamePlayer gamePlayer)
    {
        _gamePlayers.Add(gamePlayer);
    }

    public GamePlayer FindGamePlayer(int id)
    {
        return _gamePlayers.Find(e => e.Id == id);
    }
}
