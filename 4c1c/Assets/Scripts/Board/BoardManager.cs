using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager instance;

    public GameObject SidePrefab;

    [ReadOnly]
    public Side ActiveSide;

    [HideInInspector]
    List<Side> Sides;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of " + nameof(BoardManager) + " in the scene");
            return;
        }
        instance = this;
    }

    public void GenerateBoard()
    {
        Sides = new List<Side>();
        GenerateSide();
        ActiveSide = Sides[0];
    }

    private void GenerateSide()
    {
        var sideObject = Instantiate(SidePrefab);
        sideObject.transform.position = Vector3.zero;
        
        Side side = sideObject.GetComponent<Side>();
        if (side == null)
            return;

        Sides.Add(side);
        side.Setup();
    }

    public void UpdateCellStates()
    {
        foreach (var side in Sides)
        {
            foreach (var cell in side.Cells)
            {
                cell.UpdateStatus();
            }
        }
        
    }
}
