using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    void Start()
    {
        this.nameSteering = "Seek";
    }

    public override Steering GetSteering(Agent agent)
    {
        Steering steer = new Steering();
        steer.angular = 0;

        if (target != null)
        {
            Vector3 direction = target.Position - agent.Position;
            steer.linear = direction.normalized * agent.MaxAcceleration;
            return steer;
        }

        steer.linear = Vector3.zero;
        return steer;
    }
}