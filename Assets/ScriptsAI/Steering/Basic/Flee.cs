﻿using System.Collections;
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
                steer.linear = direction.normalized * agent.MaxAcceleration;
                return steer;
            }
        }

        steer.linear = Vector3.zero;
        return steer;
    }
}