using UnityEngine;

public class ActivePlayerText : MonoBehaviour
{
    TMPro.TMP_Text tmpText;

    void Start()
    {
        tmpText = GetComponent<TMPro.TMP_Text>();
    }

    void Update()
    {
        if (tmpText != null)
        {
            tmpText.text = "Сейчас ходит: " + GameManager.instance.ActivePlayer.NickName;
        }
    }
}
