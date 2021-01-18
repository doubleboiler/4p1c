using UnityEngine;

public class DiceMove : MonoBehaviour
{
    [SerializeField] Transform[] diceSides;
    public int side = 1;
    public int diceValue;

    static Rigidbody rb;
    public static Vector3 diceVelocity;
    bool hasLanded;
    bool thrown;
    Vector3 initPosition;

    //float throwForce = 600;
    //bool canHold;
    //bool isHolding;

    //RaycastHit hit;
    //GameObject dice;
    //Transform dicePos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
    }

    void Update()
    {
        diceVelocity = rb.velocity;
        CheckDiceSides();
        CheckDiceValue(side);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }

        if (rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;

            CheckDiceSides();
            CheckDiceValue(side);
        }
        else if (rb.IsSleeping() && hasLanded && diceValue == 0)

        {
            RollAgain();
        }

        //if (isHolding == true)
        //{

        //    if (Input.GetMouseButtonDown(1))
        //    {
        //        rb.AddForce(initPosition * throwForce);
        //        isHolding = false;
        //    }
        //}


        //if(Input.GetMouseButtonDown(0) && Physics.Raycast(initPosition, transform.forward, out hit, 15) &&
        //    hit.transform.GetComponent<Rigidbody>())
        //{
        //    dice = hit.transform.gameObject;
        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    dice = null;
        //}
        //if (dice)
        //{
        //    dice.GetComponent<Rigidbody>().velocity = dicePos.position - dice.transform.position;
        //}
    }

    void RollDice()
    {
        if (!thrown && !hasLanded)
        {
            thrown = true;
            Physics.gravity = new Vector3(0f, -35f, 0f);
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.AddTorque(Random.Range(100, 800), Random.Range(0, 800), Random.Range(0, 800), ForceMode.Impulse);
        }
        else if (thrown && hasLanded)
        {
            Reset();
        }
    }

    void RollAgain()
    {
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(100, 800), Random.Range(0, 800), Random.Range(0, 800), ForceMode.Impulse);

    }


    private void Reset()
    {
        transform.position = initPosition;
        transform.rotation = Quaternion.identity;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    //void OnMouseDown()
    //{
    //    isHolding = true;
    //    rb.useGravity = false;
    //    rb.detectCollisions = true;
    //}


    //void OnMouseUp()
    //{
    //    isHolding = false;
    //    rb.useGravity = true;
    //}

    void CheckDiceSides()
    {
        for (int i = 0; i < diceSides.Length; i++)
        {
            if (diceSides[i].position.y > diceSides[side - 1].position.y)
            {
                side = i + 1;
            }
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
