using UnityEngine;

public class Wander : SteeringBehaviour
{
    [SerializeField] private Face face;
    [SerializeField] private float wanderOffset;
    [SerializeField] private float wanderRadius;
    [SerializeField] private float wanderRate;
    [SerializeField] private Agent npcVirtual;

    private float wanderOrientation;
    private Agent npcVirtualTemp;
    
    void Start()
    {
        this.nameSteering = "Wander";
    }

    public override Steering GetSteering(Agent agent)
    {
        wanderOrientation += Random.Range(-1f, 1f) * wanderRate;

        if (npcVirtualTemp == null)
            npcVirtualTemp = Instantiate(npcVirtual);

        npcVirtualTemp.Orientation = wanderOrientation + agent.Orientation;
        npcVirtualTemp.Position = agent.Position + wanderOffset * agent.OrientationToVector();
        npcVirtualTemp.Position += wanderRadius * npcVirtualTemp.OrientationToVector();
        face.target = npcVirtualTemp;

        Steering steer = face.GetSteering(agent);
        steer.linear = agent.MaxAcceleration * agent.OrientationToVector();
        return steer;
    }
}
