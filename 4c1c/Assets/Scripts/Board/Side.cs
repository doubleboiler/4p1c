using System;
using UnityEngine;

public class Side : MonoBehaviour
{
    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = TILE_SIZE/2;

    public GameObject CellPrefab;

    [ReadOnly]
    public float Width;

    [HideInInspector]
    public Vector3Int Position;
    [HideInInspector]
    public RectTransform RectTransform;
    [HideInInspector]
    public Cell[,] Cells = new Cell[5, 5];

    private Vector3 _mainCorner;

    private void Start()
    {
        Width = GetComponent<Renderer>().bounds.size.x;
    }

    private void Update()
    {
        DrawGrid();
    }

    public void Setup()
    {
        _mainCorner = CalculateMainCorner();
        SetupCells();
    }

    private void SetupCells()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject cell = Instantiate(CellPrefab, transform.position, transform.rotation);

                Transform cellTransform = cell.GetComponent<Transform>();
                cellTransform.localPosition = _mainCorner + new Vector3((i * TILE_SIZE) + TILE_OFFSET, 0, (j * TILE_SIZE) + TILE_OFFSET);

                Cells[i, j] = cell.GetComponent<Cell>();
                Cells[i, j].Setup(this, new Vector2Int(i, j));
            }
        }
    }

    private void DrawGrid()
    {
        for (int i = 0; i <= 5; i++)
        {
            Vector3 startA = _mainCorner + Vector3.forward * i + new Vector3(0, 0.06f, 0);
            Debug.DrawLine(startA, startA + (Vector3.right * 5));
            for (int j = 0; j <= 5; j++)
            {
                Vector3 startB = _mainCorner + Vector3.right * j + new Vector3(0, 0.06f, 0);
                Debug.DrawLine(startB, startB + (Vector3.forward * 5));
            }
        }
    }

    private Vector3 CalculateMainCorner()
    {
        var renderer = GetComponent<MeshRenderer>();

        var cornerX = renderer.bounds.center.x - (renderer.bounds.size.x / 2);
        var cornerZ = renderer.bounds.center.z - (renderer.bounds.size.z / 2);

        return new Vector3(cornerX, 0, cornerZ);
    }
}
