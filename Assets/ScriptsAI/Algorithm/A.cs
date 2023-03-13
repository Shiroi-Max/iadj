using System.Collections;
using System.Collections.Generic;
using UnityEngine;

private class NodeRecord
{
    public Vector3 node;
    public Grid connection;
    public int costSoFar;

    public NodeRecord(Vector3 node)
    {
        this.node = node;
        connection = null;
        costSoFar = 0;
    }
}

public class A
{   
    public void AlgorithmA(GridManager gridManager, Vector3 start, Vector3 end)
    {
        NodeRecord startRecord = new NodeRecord(start);
        List<NodeRecord> open = new List<NodeRecord>();
        List<NodeRecord> closed = new List<NodeRecord>();
        open.Add(startRecord);
        
        while (open.size > 0)
        {
            NodeRecord current = open[0];
            foreach (NodeRecord nr in open)
                if (nr.costSoFar < current.costSoFar)
                    current = nr;

            if (current.node == end)
                break;
            
            // Implementar el expandir frontera del grid
        }

    }
}
