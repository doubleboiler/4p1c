using TMPro;
using UnityEngine;

public class PlayerScoreEntry : MonoBehaviour
{
	public TextMeshProUGUI entryNameText;
	public TextMeshProUGUI entryScoreText;
	ScoreManager scoreManager;

	void Start()
	{
		scoreManager = ScoreManager.instance;
	}

	public void SetPlayerInfo(string name)
    {
		entryNameText.text = name;
		entryScoreText.text = scoreManager.GetScore(name).ToString();
	}
}
