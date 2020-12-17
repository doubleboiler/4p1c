using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public static PlayersManager instance;
    public GameObject MainPlayerPrefab;

    private List<Player> _playersList;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of " + nameof(PlayersManager) + " in the scene");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        _playersList = new List<Player>();
    }

    public void CreatePlayer(Side activeSide, List<GamePlayer> gamePlayersForPlayer)
    {
        GameObject playerObject = Instantiate(MainPlayerPrefab);
        playerObject.transform.localScale = new Vector3(1f, 1f, 1f);

        Player playerForObject = playerObject.GetComponent<Player>();
        _playersList.Add(playerForObject);

        foreach (var gamePlayer in gamePlayersForPlayer)
        {
            playerForObject.AddGamePlayerToPlayer(gamePlayer);
        }

        MovePlayer(playerObject, activeSide);
    }

    private void MovePlayer(GameObject playerObject, Side activeSide)
    {
        GameObject cellObject = activeSide.Cells[2, 2].gameObject;
        Vector3 cellPosition = cellObject.transform.position;
        Quaternion cellRotation = cellObject.transform.rotation;

        var playerHeight = playerObject.GetComponent<Renderer>().bounds.size.y;
        var cellHeight = cellObject.GetComponent<Renderer>().bounds.size.y;

        playerObject.transform.position = cellPosition + new Vector3(0, playerHeight / 2, 0) + new Vector3(0, cellHeight / 2, 0);
        playerObject.transform.rotation = cellRotation;
    }

    public void StartMove(int id)
    {
        foreach (var player in _playersList)
        {
            if (player.FindGamePlayer(id) != null)
            {
                player.StartMove(id);
            }
        }
    }
}
