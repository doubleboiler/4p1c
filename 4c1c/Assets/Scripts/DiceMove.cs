using UnityEngine;

public class DiceMove : MonoBehaviour
{
    private static Rigidbody rigidBody;
    public static Vector3 diceVelocity;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        diceVelocity = rigidBody.velocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);

            transform.position = new Vector3(0, 7, 0);
            transform.rotation = Quaternion.identity;
            rigidBody.AddForce(transform.up * 500);
            rigidBody.AddTorque(dirX, dirY, dirZ);
        }
    }
}
