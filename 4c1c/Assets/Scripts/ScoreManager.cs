using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance;
	Dictionary<string, int> playersScores;
	static int defaultScore = 120;
	int changeCounter = 0;

    void Awake()
    {
		if (instance != null)
		{
			Debug.Log("More than one instance of " + nameof(ScoreManager) + " in the scene");
			return;
		}

		instance = this;
	}

    void Start()
	{
		//DEBUG_INITIAL_SETUP();
	}

	void Init()
	{
		if (playersScores != null)
			return;

		playersScores = new Dictionary<string, int>();
	}

	public void Reset()
	{
		changeCounter++;
		playersScores = null;
	}

	public int GetScore(string username)
	{
		Init();

		if (playersScores.ContainsKey(username) == false)
		{
			return 0;
		}

		return playersScores[username];
	}

	public void SetScore(string username, int value)
	{
		Init();

		changeCounter++;

		if (playersScores.ContainsKey(username) == false)
		{
			playersScores.Add(username, defaultScore);
		}

		playersScores[username] = value;
	}

	public void ChangeScore(string username, int amount)
	{
		Init();
		int currScore = GetScore(username);
		SetScore(username, currScore + amount);
	}

	public string[] GetPlayerNames()
	{
		Init();
		return playersScores.Keys.OrderByDescending(n => GetScore(n)).ToArray();
	}

	public int GetChangeCounter()
	{
		return changeCounter;
	}

	public void DEBUG_INITIAL_SETUP()
	{
		SetScore("john", 0);
		SetScore("bob", 1);
		SetScore("james", 4);
		SetScore("sam", 3);
	}

}
