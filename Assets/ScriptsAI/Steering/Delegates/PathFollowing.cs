using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : SteeringBehaviour
{
    public Seek seek;
    private Agent npcVirtualTemp;
    public Agent npcVirtual;
    public List<Vector3> nodes = new List<Vector3>();
    public float radius;

    [Range(1, 3)]
    public int option = 1;
    private int currentNode;
    private int pathDir;

    void Start()
    {
        this.nameSteering = "PathFollowing";
        currentNode = 0;
        pathDir = 1;
    }

    public override Steering GetSteering(Agent agent)
    {
        if (currentNode >= nodes.Count || currentNode < 0)
            return new Steering();

        if ((nodes[currentNode] - agent.Position).magnitude <= radius) currentNode += pathDir;
        switch (option)
        {
            case 1:
                if (currentNode >= nodes.Count) currentNode = nodes.Count - 1;
                break;
            case 2:
                if (currentNode >= nodes.Count || currentNode < 0)
                {
                    pathDir = -pathDir;
                    currentNode += pathDir;
                }
                break;
            case 3:
                if (currentNode >= nodes.Count || currentNode < 0)
                    return new Steering();
                break;
        }

        if (npcVirtualTemp == null)
            npcVirtualTemp = Instantiate(npcVirtual);

        npcVirtualTemp.Position = nodes[currentNode];
        seek.target = npcVirtualTemp;

        return seek.GetSteering(agent);
    }
}
