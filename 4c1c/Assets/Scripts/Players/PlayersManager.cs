using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public static PlayersManager instance;
    public GameObject MainPlayerPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of " + nameof(PlayersManager) + " in the scene");
            return;
        }
        instance = this;
    }

    public void CreateMainPlayer(Color playerColor, Side activeSide)
    {
        GameObject mainPlayerObject = Instantiate(MainPlayerPrefab);
        mainPlayerObject.transform.SetParent(activeSide.transform);

        mainPlayerObject.transform.localScale = new Vector3(1, 0.5f, 1);
        mainPlayerObject.transform.localRotation = Quaternion.identity;
        mainPlayerObject.transform.position = activeSide.Cells[2,2].Center;

        //mainPlayerObject.transform.
    }
}
