using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour
{
    public GameObject HoverIndicator;
    public GameObject SelectIndicator;
    public Color GoodSelection;
    public Color BadSelection;

    [ReadOnly]
    public float Width;
    [ReadOnly]
    public bool IsActive;
    [ReadOnly]
    public Vector2 PositionXY = Vector2.zero;

    [HideInInspector]
    public Side ParentSide = null;

    private byte _ownerId;
    private Color _startColor;
    private Renderer _renderer;
    private GameManager _gameManager;

    private bool IsSelectable
    {
        get { return _gameManager.ActivePlayer.Id != _ownerId; }
    }

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
        _gameManager = GameManager.instance;

        _ownerId = 0;

        Width = _renderer.bounds.size.x;
    }

    public void Setup(Side side, Vector2Int positionXY)
    {
        PositionXY = positionXY;
        ParentSide = side;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (_gameManager.ActiveGamePhase != GamePhase.Carpeting)
            return;

        IsActive = true;
        SetCellIndicator(IsSelectable);
    }

    private void OnMouseExit()
    {
        if (_gameManager.ActiveGamePhase != GamePhase.Carpeting && !IsActive)
            return;

        IsActive = false;
        SelectIndicator.SetActive(false);
        HoverIndicator.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (_gameManager.ActiveGamePhase != GamePhase.Carpeting)
            return;

        if (!IsSelectable)
            return;

        _renderer.material.color = _gameManager.ActivePlayer.Color;
        _ownerId = _gameManager.ActivePlayer.Id;

        SetCellIndicator(IsSelectable);

        _gameManager.CellGotSelected();
    }

    private void SetCellIndicator(bool canSelect)
    {
        var nowColor = canSelect ? GoodSelection : BadSelection;

        var hoverRenderer = HoverIndicator.GetComponentInChildren<Renderer>();
        if (hoverRenderer != null)
        {
            hoverRenderer.material.color = new Color(nowColor.r, nowColor.g, nowColor.b, 110f/255f);
            HoverIndicator.SetActive(true);
        }

        var selectRenderer = SelectIndicator.GetComponentInChildren<Renderer>();
        if (selectRenderer != null)
        {
            selectRenderer.material.color = new Color(nowColor.r, nowColor.g, nowColor.b, 1f);
            SelectIndicator.SetActive(true);
        }
    }

    

    public void UpdateStatus()
    {
        if (IsActive)
        {
            SetCellIndicator(IsSelectable);
        }
    }
}
