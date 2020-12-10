using UnityEngine;

public class DiceGlow : MonoBehaviour
{
    [SerializeField] private GameObject[] sidesF;
    private DiceStat diceStat;

    void Start()
    {
        diceStat = gameObject.GetComponent<DiceStat>();
    }

    void Update()
    {
        HighLightSides();
    }

    void HighLightSides()
    {
        for(int i = 0; i<sidesF.Length; i++)
        {
            sidesF[i].SetActive(false);
        }

        sidesF[diceStat.side - 1].SetActive(true);
    }
}
