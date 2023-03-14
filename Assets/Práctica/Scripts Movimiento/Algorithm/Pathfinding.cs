using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Distance
{
    Manhattan,
    Chebyshev,
    Euclidea
}

public class Pathfinding : MonoBehaviour
{
    public GridManager gridManager;
    public Distance distance = Distance.Manhattan;

    void Start()
    {
        gridManager = new GridManager(5, 5, 2, Vector3.zero);
    }

    void Update()
    {
        
    }

    public void Lrta(Agent npc)
    {
        gridManager.InitializeH(gridManager.GetPositionGrid(npc.Position), distance);
    }
}
