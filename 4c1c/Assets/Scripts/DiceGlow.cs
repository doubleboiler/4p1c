using UnityEngine;

public class DiceGlow : MonoBehaviour
{
    [SerializeField] private GameObject[] sidesF;
    private DiceMove diceStat;

    void Start()
    {
        diceStat = gameObject.GetComponent<DiceMove>();
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
