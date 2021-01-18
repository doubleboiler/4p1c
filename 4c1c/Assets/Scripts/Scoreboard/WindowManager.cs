using UnityEngine;

public class WindowManager : MonoBehaviour
{

	public GameObject scoreBoard;

	void Start()
	{
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			scoreBoard.SetActive(!scoreBoard.activeSelf);
		}
	}
}
