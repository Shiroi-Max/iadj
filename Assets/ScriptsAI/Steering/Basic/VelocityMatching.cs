using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMatching : SteeringBehaviour
{

    public float timeToTarget = .1f;

    void Start()
    {
        this.nameSteering = "VelocityMatching";
    }

    public override Steering GetSteering(Agent agent)
    {
        Steering steer = new Steering();
        if (target == null) return steer;

        steer.linear = (target.Velocity - agent.Velocity) / timeToTarget;
        if (steer.linear.magnitude > agent.MaxAcceleration)
            steer.linear = steer.linear.normalized * agent.MaxAcceleration;

        return steer;
    }
}