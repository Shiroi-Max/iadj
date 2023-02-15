using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : SteeringBehaviour
{
    public Seek seek;
    private Agent npcvtemp;
    public Agent npcv;
    public float maxPrediction = 10;


    void Start()
    {
        this.nameSteering = "Pursue";
    }

    public override Steering GetSteering(Agent agent)
    {
        Vector3 direction = target.Position - agent.Position;
        float distance = direction.magnitude;
        float speed = agent.Velocity.magnitude;

        float prediction;
        if (speed <= distance / maxPrediction)
            prediction = maxPrediction;
        else
            prediction = distance / speed;

        if (npcvtemp == null)
            npcvtemp = Instantiate(npcv);
        npcvtemp.Position = target.Position;
        npcvtemp.Position += target.Velocity * prediction;
        seek.target = npcvtemp;

        return seek.GetSteering(agent);
    }
}
