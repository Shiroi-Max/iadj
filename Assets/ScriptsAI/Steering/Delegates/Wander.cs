using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehaviour
{
    public Face face;
    public float wanderOffset;
    public float wanderRadius;
    public float wanderRate;
    private float wanderOrientation;
    private Agent npcvtemp;
    public Agent npcv;

    void Start()
    {
        this.nameSteering = "Wander";
    }

    public override Steering GetSteering(Agent agent)
    {
        wanderOrientation += Random.Range(-1f, 1f) * wanderRate;

        if (npcvtemp == null)
            npcvtemp = Instantiate(npcv);

        npcvtemp.Orientation = wanderOrientation + agent.Orientation;
        npcvtemp.Position = agent.Position + wanderOffset * agent.OrientationToVector();
        npcvtemp.Position += wanderRadius * npcvtemp.OrientationToVector();
        face.target = npcvtemp;

        Steering steer = face.GetSteering(agent);
        steer.linear = agent.MaxAcceleration * agent.OrientationToVector();
        return steer;
    }
}
