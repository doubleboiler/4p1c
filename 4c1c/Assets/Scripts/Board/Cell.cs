using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Color HoverColor;
    public Color NotAvailableColor;
    public bool IsTaken = false;

    [HideInInspector]
    public Vector2 mPositionXY = Vector2.zero;
    [HideInInspector]
    public Side mParentSide = null;

    private Color _statusColor;
    private Renderer _renderer;
    private GameManager _gameManager;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _statusColor = _renderer.material.color;
        _gameManager = GameManager.instance;
    }

    public void Setup(Side side, Vector2Int positionXY)
    {
        mPositionXY = positionXY;
        mParentSide = side;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        _renderer.material.color = HoverColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _statusColor;
    }

    private void OnMouseDown()
    {
        _renderer.material.color = _gameManager.ActivePlayer.Color;
        _statusColor = _gameManager.ActivePlayer.Color;
        _gameManager.NextPlayer();
    }
}
