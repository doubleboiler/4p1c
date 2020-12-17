using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public GameObject playerScoreEntryPrefab;
    ScoreManager scoreManager;
    int lastChangeCounter;

    private void Start()
    {

    }

    void OnEnable()
    {
        scoreManager = ScoreManager.instance;

        scoreManager.DEBUG_INITIAL_SETUP();
        //if (scoreManager.GetChangeCounter() == lastChangeCounter)
        //{
        //    return;
        //}

        //lastChangeCounter = scoreManager.GetChangeCounter();

        string[] names = scoreManager.GetPlayerNames();

        foreach (string name in names)
        {
            var entryPlayerObject = Instantiate(playerScoreEntryPrefab);
            entryPlayerObject.transform.SetParent(this.transform);
            entryPlayerObject.GetComponent<PlayerScoreEntry>().SetPlayerInfo(name);
        }
    }

    private void OnDisable()
    {
        while (this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }
    }
}
