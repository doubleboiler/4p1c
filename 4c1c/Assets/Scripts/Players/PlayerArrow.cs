using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    public float DegreeRotation;

    [ReadOnly]
    public bool IsPressed;

    private Player _playerComponent;

    private void Start()
    {
        _playerComponent = GetComponentInParent<Player>();
    }

    private void OnMouseDown()
    {
        _playerComponent.ArrowPressed(this);
    }
}
