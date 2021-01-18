using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public GameObject playerScoreEntryPrefab;
    ScoreManager scoreManager;
    int lastChangeCounter;
    Transform entryContainer;

    private void Start()
    {
        //scoreManager = ScoreManager.instance;

        scoreManager = GameObject.FindObjectOfType<ScoreManager>();

        scoreManager.DEBUG_INITIAL_SETUP();

        lastChangeCounter = scoreManager.GetChangeCounter();

        entryContainer = transform.Find("Table");
    }

    void Update()
    {
        if (scoreManager == null)
        {
            Debug.LogError("You forgot to add the score manager component to a game object!");
            return;
        }


        //if (scoreManager.GetChangeCounter() == lastChangeCounter)
        //{
        //    return;
        //}

        lastChangeCounter = scoreManager.GetChangeCounter();

        while (entryContainer.childCount > 0)
        {
            Transform c = entryContainer.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }

        string[] names = scoreManager.GetPlayerNames();

        foreach (string name in names)
        {
            var entryPlayerObject = Instantiate(playerScoreEntryPrefab);
            entryPlayerObject.transform.SetParent(entryContainer);
            entryPlayerObject.GetComponent<PlayerScoreEntry>().SetPlayerInfo(name, scoreManager.GetScore(name));
        }
    }

    //private void OnDisable()
    //{
    //    while (this.transform.childCount > 0)
    //    {
    //        Transform c = this.transform.GetChild(0);
    //        c.SetParent(null);
    //        Destroy(c.gameObject);
    //    }
    //}
}
