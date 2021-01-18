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

	public void SetPlayerInfo(string name, int score)
    {
		entryNameText.text = name;
		entryScoreText.text = score.ToString();
	}
}
