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
        // Calcula el steering.
        if (target != null)
        {
            Vector3 v = target.Position - agent.Position;
            v = v.normalized * agent.MaxAcceleration;
            steer.linear = v;
        }
        else
        {
            steer.linear = Vector3.zero;

        }
        steer.angular = 0;
        // Retornamos el resultado final.
        return steer;
    }
}