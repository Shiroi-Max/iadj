using UnityEngine;

public class Wander : SteeringBehaviour
{
    public Face face;
    public float wanderOffset;
    public float wanderRadius;
    public float wanderRate;
    private float wanderOrientation;
    private Agent npcVirtualTemp;
    public Agent npcVirtual;

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
