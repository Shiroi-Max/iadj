using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : SteeringBehaviour
{
    public float fleeRange = 5;

    void Start()
    {
        this.nameSteering = "Flee";
    }

    public override Steering GetSteering(Agent agent)
    {
        Steering steer = new Steering();
        steer.angular = 0;

        if (target != null)
        {
            Vector3 direction = agent.Position - target.Position;
            if (direction.magnitude < fleeRange)
            {
                direction = direction.normalized * agent.MaxAcceleration;
                steer.linear = direction;
                return steer;
            }
        }

        steer.linear = Vector3.zero;
        return steer;
    }
}