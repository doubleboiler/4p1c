using UnityEngine;

public class DiceStat : MonoBehaviour
{
    [SerializeField] private Transform[] diceSides;
    public int side = 1;
    public int diceValue;

    void Start()
    {
        
    }

    void Update()
    {
        CheckDiceSides();
        CheckDiceValue(side);
    }

    void CheckDiceSides()
    {
        for(int i = 0; i < diceSides.Length; i++)
        {
            if (diceSides[i].position.y > diceSides[side-1].position.y)
                side = i + 1;
        }
    }

    int CheckDiceValue(int side)
    {
        switch (side)
        {
            case 1:
                return diceValue = 1;
            case 2:
                return diceValue = 5;
            case 3:
                return diceValue = 6;
            case 4:
                return diceValue = 4;
            case 5:
                return diceValue = 3;
            case 6:
                return diceValue = 3;
            case 7:
                return diceValue = 2;
            case 8:
                return diceValue = 4;
            default:
                return diceValue = 0;
        }
    }
}
